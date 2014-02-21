using OrionsBelt.Core;

namespace OrionsBelt.Engine.Universe {
	internal class WormHoleCount {

		#region Fields

		private SectorStorage wormHole;
		private WormHolePlayers wormHolePlayers;

		#endregion Fields

		#region Properties

		public SectorStorage WormHole {
			get { return wormHole; }
			set { wormHole = value; }
		}

		public int Count {
			get { return wormHolePlayers.PlayerCount; }
			set { wormHolePlayers.PlayerCount = value; }
		}

		public WormHolePlayers WormHolePlayers {
			get { return wormHolePlayers; }
			set { wormHolePlayers = value; }
		}

		#endregion Properties

		#region Constructor

		public WormHoleCount(SectorStorage wormHole, WormHolePlayers wormHolePlayers) {
			WormHole = wormHole;
			WormHolePlayers = wormHolePlayers;
		}

		#endregion Constructor

		
	}
}
