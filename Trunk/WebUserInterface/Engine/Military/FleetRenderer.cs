using System.Collections.Generic;
using System.IO;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebUserInterface.WebBattle;

namespace OrionsBelt.WebUserInterface.Engine {
	public class FleetRenderer {

		#region Private

		private static void RenderUnits(TextWriter writer, IFleetInfo fleet) {
			foreach (FleetElement unit in fleet.Units.Values) {
				writer.Write("<div class='fleetListUnit' unitName='{0}'>", unit.Name);
				writer.Write("<img src='{0}' title='{1}' quantity='{2}' />", ResourcesManager.GetUnitImage(unit.Name), unit.Name, unit.Quantity);
				writer.Write("<br/><span>{0}</span>",unit.Quantity);
				writer.Write("</div>");
			}
		}

		private static string RenderOptions(IFleetInfo fleet) {
			return RenderOptions(null,fleet);
		}

		private static string RenderOptions(IPlanet planet,IFleetInfo fleet) {
			if ( fleet.IsInBattle ) {
				return string.Format("- <strong>{0}</strong>", LanguageManager.Instance.Get("InBattle"));
			}

			if( (fleet.Movable && planet != null) ){
				StringWriter writer = new StringWriter();
				writer.Write("<a href='javascript:Fleet.deleteFleet({2},{3},{4});'><img src='{0}' alt='{1}' title='{1}' /></a>", ResourcesManager.GetImage("Error.gif"), LanguageManager.Instance.Get("DeleteFleet"), planet.Storage.Id, fleet.Id,planet.DefenseFleet.Id);
				return writer.ToString();
			}
			if( !fleet.HasUnits && !fleet.IsPlanetDefenseFleet ) {
				StringWriter writer = new StringWriter();
                writer.Write("<a href='javascript:Fleet.deleteEmptyFleet({2});'><img src='{0}' alt='{1}' title='{1}' /></a>", ResourcesManager.GetImage("Error.gif"), LanguageManager.Instance.Get("DeleteFleet"), fleet.Id);
				return writer.ToString();
			}

			return string.Empty;
		}

		private static void RenderCargo(TextWriter writer, IFleetInfo fleet) {
			RenderCargo(writer,fleet,null);
		}

		private static void RenderCargo(TextWriter writer, IFleetInfo fleet, IPlanet planet) {
			string cargoId = string.Format("fleet{0}Cargo", fleet.Id);
			writer.Write("<div id='{0}' class='fleetCargo'>", cargoId);
			if (fleet.Cargo != null && fleet.Cargo.Count > 0 ) {
                bool hasTradeCargo = false;
				foreach (KeyValuePair<IResourceInfo, int> c in fleet.Cargo) {
					writer.Write("<div class='cargoList' isTradeResource='{0}'>", c.Key.IsTradeRouteSpecific.ToString().ToLower());
					writer.Write(GetResourceImageName(c.Key));
					writer.Write("<br/><span>{0}</span>", c.Value);
					writer.Write("</div>");
                    if (c.Key.IsTradeRouteSpecific){
                        hasTradeCargo = true;
                    }
        		}
				
				if( planet != null ) {
					RenderCargoButton(fleet, planet, writer, cargoId);
				}
                if (hasTradeCargo) {
                    RendereDropTradeCargoButton(fleet, writer, cargoId);
                }
			}
			writer.Write("</div>");
        }

		private static string GetResourceImageName(IResourceInfo resource) {
			if( resource is IUnitInfo ) {
				return string.Format("<img src='{0}' title='{1}' alt='{1}' resourcename='{1}' class='unitSmall'/>", ResourcesManager.GetUnitImage(resource.Name), resource.Name);
			}
			return ResourcesManager.GetResourceSmallImageHtml(resource);				
		}

		private static void RenderCargoButton(IFleetInfo fleet, IPlanet planet, TextWriter writer, string cargoId) {
			writer.Write("<div class='unloadFleetCargo'>");
			string href;
			if( fleet.IsInBattle) {
				href = string.Format("javascript:RaiseError.unloadCargoFleetInBattle();");
			}else {
				href = string.Format("javascript:Planet.unloadCargo({0},{1},\"{2}\");", planet.Storage.Id, fleet.Id, cargoId);
				
			}
			GenericRenderer.WriteRightLinkButton(writer,href,LanguageManager.Instance.Get("UnloadCargo"));
			writer.Write("</div>");
		}

        private static void RendereDropTradeCargoButton(IFleetInfo fleet, TextWriter writer, string cargoId){
            writer.Write("<div class='dropTradeFleetCargo'>");
			string href;
			if (fleet.IsInBattle) {
				href = string.Format("javascript:RaiseError.dropCargoFleetInBattle();");
			}else {
				href = string.Format("javascript:Fleet.dropTradeCargo({0},\"{1}\");", fleet.Id, cargoId);
			}
				GenericRenderer.WriteRightLinkButton(writer, href, LanguageManager.Instance.Get("DropTradeCargo"));
			writer.Write("</div>");
        }

		#endregion

		#region Public

		public static void Render(TextWriter writer, IFleetInfo fleet) {
			writer.Write("<div class='fleet'>");
			writer.Write("<h3>{0} - {1} {2}</h3>", fleet.Name, fleet.Location, RenderOptions(fleet));
            writer.Write("<div id='fleet{0}' fleetid='{0}' class='{2}' isInBattle='{1}' isMoving='{3}'>", fleet.Id, fleet.IsInBattle.ToString().ToLower(), GetFleetType(fleet), GetIsMoving(fleet));
			RenderUnits(writer,fleet);
			writer.Write("</div>");
			RenderCargo(writer, fleet);
			writer.Write("</div>");
		}

        private static string GetIsMoving(IFleetInfo fleet)
        {
            if (fleet.Storage != null) {
                return fleet.IsMoving.ToString().ToLower();
            }
            return "false";
        }

		public static void RenderInPlanet(TextWriter writer, IPlanet planet, IFleetInfo fleet) {
			writer.Write("<div class='fleet'>");
			writer.Write("<h3>{3} : {0} - {1} {2}</h3>", fleet.Name, fleet.Location, RenderOptions(planet,fleet), planet.Name);
			writer.Write("<div id='fleet{0}' fleetid='{0}' class='{2}' isInBattle='{1}' isMoving='{3}'>", fleet.Id, fleet.IsInBattle.ToString().ToLower(), GetFleetType(fleet), fleet.IsMoving.ToString().ToLower());
			RenderUnits(writer, fleet);
			writer.Write("</div>");
			RenderCargo(writer, fleet,planet);
			writer.Write("</div>");
		}

		private static string GetFleetType( IFleetInfo fleet ) {
			if( fleet.HasUltimateUnit ) {
				return string.Format("{0}Units", fleet.UltimateUnit.Name);
			}

			return "fleetUnits";
		}

        #endregion Public

	}
}
