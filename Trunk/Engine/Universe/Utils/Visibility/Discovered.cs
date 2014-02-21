namespace OrionsBelt.Engine.Universe {
	public class Discovered : UniverseVisibility {

		#region Fields

		private static readonly Discovered discovered = new Discovered();

		#endregion Fields

		#region Properties

		public static UniverseVisibility Instance {
			get { return discovered; }
		}

		public override int ImportanceLevel {
			get { return 1; }
		}

		#endregion Properties

		#region Constructor

		private Discovered(){}

		#endregion Constructor

	}
}