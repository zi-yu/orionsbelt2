using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Engine {
	public class CenterCoordinate {

		#region Fields

		private int fleetId;
		private SectorCoordinate center;

		#endregion Fields
		
		#region Properties

		public SectorCoordinate Center {
			get {
				if( fleetId == 0 ) {
					return center;	
				}
				return CenterFleet;
			}
			set { center = value; }
		}

		public SectorCoordinate CenterFleet {
			get {
				IPlayer player = PlayerUtils.Current;
				IFleetInfo fleet = player.GetFleet(fleetId);
				if (fleet!= null) {
					center = fleet.Location;
					return center;
				}
				if (player.HasMoveableFleets ) {
					fleetId = player.Fleets[0].Id;
					center = player.Fleets[0].Location;
					return center;
				}

				return center;
			}
		}

		
		public IFleetInfo GetCenterFleet() {
			IPlayer player = PlayerUtils.Current;
			IFleetInfo fleet = player.GetFleet(fleetId);
			if (fleet == null) {
				if (player.HasMoveableFleets) {
					return player.Fleets[0];
				}
			}
			return null;
		}

		public void SetCenter(SectorCoordinate newCoordinate) {
			fleetId = 0;
			center = newCoordinate;
		}

		public void SetCenterInFleet(int fleetId) {
			this.fleetId = fleetId;
			if (fleetId != 0) {
				center = CenterFleet;
			} else {
				center = new SectorCoordinate(0, 0, 1, 1);
			}
		}

		#endregion Properties

		#region Public

		public static CenterCoordinate Current {
			get {
			    string playerName = PlayerUtils.Current.Name;
                if (State.HasSession("CurrentCenterFleet" + playerName)){
                    return (CenterCoordinate)State.GetSession("CurrentCenterFleet" + playerName);
				}

				CenterCoordinate center;
				if (PlayerUtils.Current.HasMoveableFleets) {
					center = new CenterCoordinate(PlayerUtils.Current.Fleets[0].Id);
				}else {
					center = new CenterCoordinate(0);
				}

                State.SetSession("CurrentCenterFleet" + playerName, center);
				return center;
			}
			set {
                State.SetSession("CurrentCenterFleet" + PlayerUtils.Current.Name, value);
			}
		}

		
		#endregion Public

		#region Coordinate

		public CenterCoordinate(int fleetId) {
			this.fleetId = fleetId;
			if (fleetId != 0 ) {
				center = CenterFleet;	
			}else {
				center = new SectorCoordinate(0,0,1,1);
			}
			
		}

		#endregion Coordinate
	}
}
