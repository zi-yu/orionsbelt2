
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public abstract class Bonus : IBonus{

		#region IBonus Members

		/// <summary>
		/// Gets the attack bonus
		/// </summary>
		public virtual int GetAttack() {
			return 0;
		}

		/// <summary>
		/// Gets the defense bonus
		/// </summary>
		public virtual int GetDefense() {
			return 0;
		}

		/// <summary>
		/// Gets the range bonus
		/// </summary>
		public virtual int GetRange() {
			return 0;
		}

		#endregion IBonus Members
	}
}
