using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using System.Web;

namespace OrionsBelt.WebUserInterface.Engine {
	
	public class FleetActions : ActionBase {

        #region Private

       
        #endregion Private

		#region Delegates

		private void Changes() {
			bool toUpdate= false;
            string isInPlanet = HttpContext.Current.Request.QueryString["IsInPlanet"];

            string changes = HttpContext.Current.Request.QueryString["Changes"];
			if (!string.IsNullOrEmpty(changes)) {	
				Result results = FleetChangesInterpreter.Interpretate(changes,isInPlanet.Equals("1"));
				toUpdate = true;
			}

            string cargoChanges = HttpContext.Current.Request.QueryString["CargoChanges"];
			if (!string.IsNullOrEmpty(cargoChanges)) {
				Result results = FleetChangesInterpreter.InterpretateCargo(cargoChanges, isInPlanet.Equals("1"));
				toUpdate = true;
			}

			if(toUpdate){
				Persistance.Flush();
			}
		}

		private void Delete() {
			int fleetId = ConvertToInt("FleetId");
			int planetId = ConvertToInt("PlanetId");
			if( planetId > 0 && fleetId > 0 ) {
				IPlanet planet = PlayerUtils.Current.GetPlanet(planetId);
				IFleetInfo fleet = planet.GetFleet(fleetId);
				if (fleet != null ) {
					if (!fleet.IsInBattle) {
						if (fleet.HasUnits) {
							planet.DefenseFleet.Add(fleet);
							GameEngine.Persist(planet.DefenseFleet);
						}
						FleetPersistance.DeleteFleet(fleet);
						Persistance.Flush();
					}else {
						
					}
				}
			}
		}

		private void DeleteEmpty() {
			int fleetId = ConvertToInt("FleetId");
			if( fleetId > 0 ) {
				IFleetInfo fleet = FleetPersistance.GetFleet(fleetId);
				if (fleet != null ) {
					FleetPersistance.DeleteFleet(fleet);
					Persistance.Flush();
				}
			}
		}
		
        private void DropTradeFleetCargo(){
            string fleetIdStr = HttpContext.Current.Request.QueryString["FleetId"];
            if (!string.IsNullOrEmpty(fleetIdStr)){
                int fleetId;
                if (int.TryParse(fleetIdStr, out fleetId)){
                    IFleetInfo fleet = FleetPersistance.GetFleet(fleetId);
                    if (fleet != null && fleet.Cargo != null){
                        PlanetUtils.DropTradeCargo(fleet);
                        GameEngine.Persist(fleet);
                        Persistance.Flush();
                    }
                }
            }
        }

		#endregion Delegates

		#region Constructor

		public FleetActions() {
			actions["change"] = Changes;
			actions["delete"] = Delete;
			actions["deleteEmpty"] = DeleteEmpty;
            actions["dropfleetcargo"] = DropTradeFleetCargo;
		}

		#endregion Constructor
	
	}
}
