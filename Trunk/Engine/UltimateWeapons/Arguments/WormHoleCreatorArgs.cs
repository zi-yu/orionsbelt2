using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.Engine {
    public class WormHoleCreatorArgs : IUltimateWeaponArgs {

        #region Fields

        private readonly SectorCoordinate coordinate;
		private readonly IPlayer owner;

        #endregion Fields

		#region Properties

		public IPlayer Owner {
			get { return owner; }
		}

		#endregion Properties

		#region Public

		public SectorCoordinate Coordinate{
            get { return coordinate; }
        }

        #endregion Public

        #region Constructor

		public WormHoleCreatorArgs(IPlayer owner, SectorCoordinate coordinate) {
            this.owner = owner;
			this.coordinate = coordinate;
        }

        #endregion Constructor

	}
}
