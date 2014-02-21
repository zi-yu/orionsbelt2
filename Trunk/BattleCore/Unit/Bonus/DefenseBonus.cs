namespace OrionsBelt.BattleCore {

	public class DefenseBonus: Bonus {

		#region Fields

		private readonly int defenseBonus;

		#endregion Fields

		#region Public

		/// <summary>
		/// Gets the defense bonus
		/// </summary>
		public override int GetDefense() {
			return defenseBonus;
		}

		#endregion Public

		#region Constructor

		public DefenseBonus( int defenseBonus ) {
			this.defenseBonus = defenseBonus;
		}

		#endregion Constructor
	}
}
