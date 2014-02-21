namespace OrionsBelt.Engine.Universe {
	public class PlanetVisible : UniverseVisibility {

		#region Fields

		private static readonly PlanetVisible instance = new PlanetVisible();

		#endregion Fields

		#region Properties

		public static UniverseVisibility Instance {
			get { return instance; }
		}

		public override int ImportanceLevel {
			get { return 3; }
		}

		#endregion Properties

		#region Constructor

		private PlanetVisible() { }

		#endregion Constructor

	}
}