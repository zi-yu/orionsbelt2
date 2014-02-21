using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.Engine {
    public class DevastationCreatorArgs : IUltimateWeaponArgs {

        #region Fields

        private readonly SectorCoordinate coordinate;
		private readonly IPlayer owner;

        #endregion Fields

		#region Properties

		public IPlayer Owner {
			get { return owner; }
		}

		public SectorCoordinate Coordinate{
            get { return coordinate; }
		}

		#endregion Properties

		#region Constructor

		public DevastationCreatorArgs(IPlayer owner, SectorCoordinate coordinate) {
            this.owner = owner;
			this.coordinate = coordinate;
        }

        #endregion Constructor

	}
}
