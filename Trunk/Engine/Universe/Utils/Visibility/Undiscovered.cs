namespace OrionsBelt.Engine.Universe {
	public class Undiscovered : UniverseVisibility {

		#region Fields

		private static readonly Undiscovered instance = new Undiscovered();

		#endregion Fields

		#region Properties

		public static UniverseVisibility Instance {
			get { return instance; }
		}

		public override int ImportanceLevel {
			get { return 0; }
		}

		#endregion Properties

		#region Constructor

		private Undiscovered() { }

		#endregion Constructor

	}
}