using System.Collections.Generic;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface IUnitBonus {

		/// <summary>
		/// Container with all the bonus
		/// </summary>
		Dictionary<string, IBonus> Bonus{ get; }

		/// <summary>
		/// Gets the attack with all the bonus
		/// </summary>
		int GetAttack( Terrain terrain, IUnitInfo target );

		/// <summary>
		/// Gets the defense with all the bonus
		/// </summary>
		int GetDefense( Terrain terrain, IUnitInfo target );

		/// <summary>
		/// Gets the range with all the bonus
		/// </summary>
		int GetRange( Terrain terrain, IUnitInfo target );
	}
}
