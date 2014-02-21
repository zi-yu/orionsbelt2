namespace OrionsBelt.BattleCore {
	internal class Modifier {

		#region Fields

		private readonly int max;
		private readonly int min;
		private readonly double value;

		#endregion Fields

		#region Properties

		public int Min {
			get { return min; }
		}

		public double Value {
			get { return value; }
		}

		public int Max {
			get { return max; }
		}

		#endregion Properties

		#region Constructor

		public Modifier( int min, int max, double value ) {
			this.min = min;
			this.max = max;
			this.value = value;
		}

		#endregion Constructor


	}
}
