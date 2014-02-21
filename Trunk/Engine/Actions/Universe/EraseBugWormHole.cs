using System;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Core;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Battle Timeout
    /// </summary>
    public class EraseBugWormHole : OneTimeAction {

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
       
		#region Private

		 
		#endregion Private

	    #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Private; }
        }

        protected override void ProcessAction(bool forcedEnd) {
			using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
                int deleted = persistance.Delete("from SpecializedUniverseSpecialSector s where s.SectorNHibernate.Id = {0}", SectorId);
                Console.WriteLine("\tUniverseSpecialSector '{0}' deleted!", deleted);
				deleted = persistance.Delete("from SpecializedSectorStorage s where s.Type = 'BugsWormHoleSector' and s.Id = {0}", SectorId);
				Console.WriteLine("\tWormHole '{0}' deleted!", SectorId);
				Ended = deleted > 0;
                persistance.Flush();
			}
        }

		#endregion Base Implementation

		#region Constructor

		public EraseBugWormHole() {
		}

		public EraseBugWormHole(int sectorId, int delay) {
			SectorId = sectorId;
			Start(delay);
		}

		#endregion Constructor

    };

}
