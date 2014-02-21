using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Battle Timeout
    /// </summary>
    public class PrivateFleetMovement : AutoRepeteAction {

		#region Ctor

        public PrivateFleetMovement(){
			Start(1);
		}

        #endregion Ctor 

		#region Private

		private static void MovePrivateFleets(List<FleetSector> fleets) {
			List<FleetSector> nonPursuitFleets = fleets.FindAll(delegate(FleetSector s) { return !s.FleetSectorMoveArgs.Pursuit; });
            NHibernateUtilities.Statistics.Clear();
			foreach (FleetSector fleet in nonPursuitFleets) {
				fleet.Turn();
			}
		}

		#endregion Private

        #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Public; }
        }

        protected override void ProcessAction(bool forcedEnd) {
			NHibernateUtilities.Statistics.Clear();
			Universe.Universe.Clear();
            Universe.Universe.LoadPrivateUniverse();

            List<FleetSector> fleets = Universe.Universe.PrivateFleetsInMovement;
			if (fleets.Count > 0 ) {
                MovePrivateFleets(fleets);
				GameEngine.PersistUniverse();
			}
			using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
				persistance.StartTransaction();	
				persistance.CommitTransaction();
			}
        }

		#endregion Base Implementation

    };

}
