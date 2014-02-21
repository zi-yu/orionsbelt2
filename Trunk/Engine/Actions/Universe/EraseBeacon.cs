using System;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Battle Timeout
    /// </summary>
    public class EraseBeacon : OneTimeAction {

		#region Fields

    	private int sectorId;

		#endregion Fields

		#region Properties

		private int SectorId {
			get { return sectorId;}
			set { sectorId = value; }
		}

		public override string Data {
			get { return SectorId.ToString(); }
			set { SectorId = int.Parse(value); }
		}

		#endregion

	    #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Private; }
        }

        protected override void ProcessAction(bool forcedEnd) {
			using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
				int deleted = persistance.Delete("from SpecializedSectorStorage s where s.Type = 'BeaconSector' and s.Id = '{0}'", SectorId);
				Console.WriteLine("\tBeacon '{0}' deleted!", SectorId);
				Ended = deleted > 0;
			}
        }

		#endregion Base Implementation

		#region Constructor

		public EraseBeacon() {
		}

		public EraseBeacon(int sectorId, int delay) {
			SectorId = sectorId;
			Start(delay);
		}

		#endregion Constructor

    };

}
