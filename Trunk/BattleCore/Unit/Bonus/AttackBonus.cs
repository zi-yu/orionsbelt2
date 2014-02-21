namespace OrionsBelt.BattleCore {

	public class AttackBonus: Bonus {

		#region Fields

		private readonly int attackBonus;

		#endregion Fields

		#region Public

		/// <summary>
		/// Gets the attack bonus
		/// </summary>
		public override int GetAttack() {
			return attackBonus;
		}

		#endregion Public

		#region Constructor

		public AttackBonus( int attackBonus ) {
			this.attackBonus = attackBonus;
		}

		#endregion Constructor
	}
}
