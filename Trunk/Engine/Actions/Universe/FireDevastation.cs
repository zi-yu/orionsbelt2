using System;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Battle Timeout
    /// </summary>
    public class FireDevastation : OneTimeAction {

		#region Fields

		private SectorCoordinate coordinate;

		#endregion Fields

		#region Properties

		private SectorCoordinate Coordinate {
			get {
				if (coordinate == null) {
					coordinate = new SectorCoordinate(Data);
				}
				return coordinate;
			}
			set {
				Data = value.ToString();
				coordinate = value;
			}
		}

		#endregion
       
		#region Private

		 
		#endregion Private

	    #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Private; }
        }

        protected override void ProcessAction(bool forcedEnd) {
        	IPlayer owner = PlayerUtils.LoadPlayer(Storage.Player);
        	IUltimateWeapon weapon = UltimateWeaponChooser.GetUltimateWeapon(owner);
			DevastationCreatorArgs args = new DevastationCreatorArgs(owner,Coordinate);
			weapon.Use(args);
			Console.WriteLine("\tDevastation fired at coordinate '{0}'!", Coordinate);
        	Ended = true;
        }

		#endregion Base Implementation

		#region Constructor

		public FireDevastation() {
		}

		public FireDevastation(IPlayer owner, SectorCoordinate coordinate, int delay) {
			Coordinate = coordinate;
			Start(delay);
			PrepareStorage();
			UpdateStorage();
			Storage.Player = owner.Storage;
		}

		#endregion Constructor

    };

}
