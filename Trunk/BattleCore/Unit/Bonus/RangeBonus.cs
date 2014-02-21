namespace OrionsBelt.BattleCore {

	public class RangeBonus: Bonus {

		#region Fields

		private readonly int rangeBonus;

		#endregion Fields

		#region Public

		/// <summary>
		/// Gets the range bonus
		/// </summary>
		public override int GetRange() {
			return rangeBonus;
		}

		#endregion Public

		#region Constructor

		public RangeBonus( int rangeBonus ) {
			this.rangeBonus = rangeBonus;
		}

		#endregion Constructor
	}
}
