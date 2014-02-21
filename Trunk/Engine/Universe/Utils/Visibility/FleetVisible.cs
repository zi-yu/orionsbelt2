namespace OrionsBelt.Engine.Universe {
	public class FleetVisible : UniverseVisibility {

		#region Fields

		private static readonly FleetVisible instance = new FleetVisible();

		#endregion Fields

		#region Properties

		public static UniverseVisibility Instance {
			get { return instance; }
		}

		public override int ImportanceLevel {
			get { return 2; }
		}

		#endregion Properties

		#region Constructor

		private FleetVisible() { }

		#endregion Constructor

	}
}