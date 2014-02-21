using System.Collections.Generic;
using DesignPatterns;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface IScore: IFactory {

		/// <summary>
		/// Calculates the partial score, the score vefore the game ends
		/// </summary>
		/// <param name="allPlayers">Other Players in combat</param>
		/// <returns>The total value with the modifiers applied</returns>
		void SetPlayersScore(List<IBattlePlayer> allPlayers);
	}
}
