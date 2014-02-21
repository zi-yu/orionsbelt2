namespace OrionsBelt.RulesCore.Interfaces {
	public interface IBonus {

		/// <summary>
		/// Gets the attack bonus
		/// </summary>
		int GetAttack();

		/// <summary>
		/// Gets the defense bonus
		/// </summary>
		int GetDefense();

		/// <summary>
		/// Gets the range bonus
		/// </summary>
		int GetRange();
	}
}
