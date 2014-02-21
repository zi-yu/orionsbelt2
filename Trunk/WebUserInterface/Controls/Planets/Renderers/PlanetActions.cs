using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using OrionsBelt.Engine.Universe;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using System.IO;
using DesignPatterns;
using OrionsBelt.RulesCore;
using OrionsBelt.Generic;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Results;
using System.Collections.Generic;
using Loki.DataRepresentation;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Actions that renderers may perform
    /// </summary>
	public abstract class PlanetActions {

        #region Ctor

        private delegate bool DoAction(TextWriter writer, IPlanet planet);

        private Dictionary<string, DoAction> actions = new Dictionary<string, DoAction>();

        public PlanetActions()
        {
            actions.Add("Build", this.CheckAutoStart);
            actions.Add("Upgrade", this.CheckAutoUpgrade);
            actions.Add("RemoveQueue", this.CheckAutoRemoveQueue);
            actions.Add("RemoveProduction", this.CheckAutoProductionCancel);
            actions.Add("CreateFleet", this.CheckCreateFleet);
			actions.Add("UnloadFleet", this.UnloadFleetCargo);
            actions.Add("Destroy", this.CheckAutoDestroy);
            actions.Add("ChangeName", this.ChangePlanetName);
            actions.Add("AbandonPlanet", this.AbandonPlanet);
        }

        #endregion Ctor

        #region Events

        protected bool CheckActions(TextWriter writer, IPlanet planet, PlanetRendererPanel panel)
        {
            CurrentPanel = panel;

            string action = HttpContext.Current.Request.QueryString["Action"];
            if (!string.IsNullOrEmpty(action)) {
                if (actions.ContainsKey(action)) {
                    return actions[action](writer, planet);
                } else {
                    throw new UIException("Action '{0}' not recognized", action);
                }
            }

            return false;
        }

		#endregion Events

        #region Actions

        protected bool AbandonPlanet(TextWriter writer, IPlanet planet)
        {
            IPlayer curr = PlayerUtils.Current;
            IPlanet currPlanet = curr.GetPlanet(planet.Storage.Id);
            if (planet == null) {
                throw new UIException("Current player doesn't own planet");
            }
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {

            	ISector planetSector = currPlanet.Sector;
                if (planetSector.IsInBattle) {
                    SetMessage("InBattle");
                    return false;
                }

                session.StartTransaction();

                PlanetUtils.Abandon(curr, currPlanet);
                GameEngine.Persist(curr);
				GameEngine.Persist(planetSector,false);

                session.CommitTransaction();
            }

            return true;
        }

        protected bool ChangePlanetName(TextWriter writer, IPlanet planet)
        {
            string newName = HttpContext.Current.Request.QueryString["NewName"];

            if (string.IsNullOrEmpty(newName)) {
                throw new UIException("Trying to change planet's name, but no new name found");
            }

            planet.Name = newName.Replace("\"", string.Empty).Replace("'", string.Empty);

            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                session.StartTransaction();
                GameEngine.Persist(planet);
                session.CommitTransaction();
            }

            return false;
        }

        protected bool CheckAutoDestroy(TextWriter writer, IPlanet planet)
        {
            IPlanetResource resource = planet.GetFacility(CurrentFacilitySlot);
            Result result = planet.IsDestroyAvailable(resource);
            if (result.Ok) {
                planet.Destroy(resource);
                GameEngine.Persist(PlayerUtils.Current);
            } else {
                WriteResult(writer, planet, result);
            }

            return false;
        }

        protected bool CheckAutoStart(TextWriter writer, IPlanet planet)
        {
            IPlanetResource newResource = PlanetResource.Create(CurrentResourceInfo, 1);
            if (CurrentResourceType == ResourceType.Facility){
                newResource.Slot = CurrentFacilitySlot;
            }
            if (CurrentResourceType == ResourceType.Unit) {
                newResource.Quantity = CurrentQuantity;
            }

            Result result = planet.CanQueue(newResource);
            if (result.Ok) {
                planet.Enqueue(newResource);
                GameEngine.Persist(CurrentPlanet.Owner);
            } else {
                WriteResult(writer, planet, result);
            }

            return false;
        }

        protected bool CheckAutoRemoveQueue(TextWriter writer, IPlanet planet)
        {
            IPlanetResource resource = ResourceUtils.GetResource(CurrentPlanet, CurrentResourceId);
            CurrentPlanet.Dequeue(resource);
            GameEngine.Persist(CurrentPlanet.Owner);

            return false;
        }

        protected bool CheckAutoProductionCancel(TextWriter writer, IPlanet planet)
        {
            IPlanetResource resource = ResourceUtils.GetResource(CurrentPlanet, CurrentResourceId);
            CurrentPlanet.CancelProduction(resource);
            GameEngine.Persist(PlayerUtils.Current);

            return false;
        }

        protected bool CheckAutoUpgrade(TextWriter writer, IPlanet planet)
        {
            IPlanetResource resource = planet.GetFacility(CurrentFacilitySlot);
            Result result = planet.IsUpgradeAvailable(resource);
            if (result.Ok) {
                ++resource.Level;
                planet.Enqueue(resource);
                GameEngine.Persist(PlayerUtils.Current);
            } else {
                WriteResult(writer, planet, result);
            }

            return false;
        }

		protected bool CheckCreateFleet(TextWriter writer, IPlanet planet) {
			string fleetName = HttpContext.Current.Request.QueryString["FleetName"];
			Result result = new Result();
			Match m = Regex.Match(fleetName, "^[0-9a-zA-Z]+$");
			if( string.IsNullOrEmpty(fleetName) || !m.Success) {
				fleetName = fleetName.Replace("<", "&lt;").Replace(">'","&gt");
				result.AddFailed(new InvalidFleetName(fleetName));
			}else{
				
                fleetName = fleetName.Replace("\"", string.Empty).Replace("'", string.Empty);
				
				if (planet.Owner.Fleets.Count < PlayerUtils.MaxFleetNumber) {
                    SectorUtils.CreateFleetSector(planet.Location, PlayerUtils.Current, fleetName);
					result.AddPassed(new FleetCreated(fleetName));
				}else{
					result.AddFailed(new MaximumFleets());
				}
			}
			WriteResult(writer, planet, result);
            return false;
		}

		protected bool UnloadFleetCargo(TextWriter writer, IPlanet planet) {
			string fleetIdStr = HttpContext.Current.Request.QueryString["FleetId"];
			if (!string.IsNullOrEmpty(fleetIdStr)) {
				Result result = new Result();
				int fleetId;
				if( int.TryParse(fleetIdStr,out fleetId) ) {
					IFleetInfo fleet = planet.GetFleet(fleetId);
					if (fleet != null && fleet.Cargo != null) {
						result.Merge(PlanetUtils.UnloadCargo(planet, fleet));
						GameEngine.Persist(fleet.Owner);
					}
				}

				WriteResult(writer, planet, result);
			}

            return false;
		}

		#endregion Actions

        #region Utilities

        private PlanetRendererPanel panel;
        protected PlanetRendererPanel CurrentPanel {
            get { return panel;  }
            set { panel = value;  }
        }

        protected virtual ResourceType CurrentResourceType { 
            get {
                if (CurrentPanel == PlanetRendererPanel.Units) {
                    return ResourceType.Unit;
                }
                return ResourceType.Facility; 
            }
        }

        public IResourceInfo CurrentResourceInfo {
            get { 
                string res = HttpContext.Current.Request.QueryString["Resource"];
                return RulesCore.RulesUtils.GetResource(res);
            }
        }

        public int CurrentQuantity {
            get { 
                string res = HttpContext.Current.Request.QueryString["Quantity"];
                return int.Parse(res);
            }
        }

        public IFacilitySlot CurrentFacilitySlot {
            get { 
                string name = HttpContext.Current.Request.QueryString["SlotName"];
                return CurrentPlanet.Info.GetSlot(name);
            }
        }

        public int CurrentResourceId {
            get {
                string raw = HttpContext.Current.Request.QueryString["ResourceId"];
                return int.Parse(raw);
            }
        }

        private IPlanet planet;

        public IPlanet CurrentPlanet {
            get { return planet; }
            set { planet = value; }
        }

        protected void WriteResult(TextWriter writer, IPlanet planet, Result result)
        {
            writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("Result"));
            writer.Write("<div class='panelPlaceHolder'>");

            writer.Write("<ul id='resultItems'>");
            foreach(ResultItem item in result.Failed ) {
                WriteResultItem(writer, "Failed", item);
            }
            foreach(ResultItem item in result.Passed ) {
                WriteResultItem(writer, "Passed", item);
            }
            writer.Write("</ul>");
            writer.Write("</div>");
        }

        private static void WriteResultItem(TextWriter writer, string result, ResultItem item)
        {
            string translated = item.Log(LanguageParameterTranslator.Instance);
            if (!string.IsNullOrEmpty(translated)) {
                writer.Write("<li class='{2}'>{1}: {0}</li>", translated, LanguageManager.Instance.Get(result), result.ToLower());
            }
        }

        private string token = null;
        private void SetMessage(string token)
        {
            this.token = token;
        }

        protected void ShowMessage(TextWriter writer)
        {
            if (!string.IsNullOrEmpty(token)) {
                writer.Write("<div class='panelPlaceHolder'>");
                writer.Write(LanguageManager.Instance.Get(token));
                writer.Write("</div>");
            }
        }

	
        #endregion Utilities

    };
}

