using System;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Battle Timeout
    /// </summary>
    public class CreateBugWormHole : OneTimeAction {

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
			
        }

		#endregion Base Implementation

		#region Constructor

		public CreateBugWormHole() {
		}

		public CreateBugWormHole(int sectorId, int delay) {
			SectorId = sectorId;
			Start(delay);
		}

		#endregion Constructor

    };

}
