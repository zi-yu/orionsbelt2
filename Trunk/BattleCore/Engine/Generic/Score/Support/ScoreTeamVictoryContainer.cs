using System;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	internal class ScoreTeamVictoryContainer {

		#region Fields

		private readonly List<ScoreTeam> container = new List<ScoreTeam>();
		private static readonly ModifierContainer victoryPercentageModifier = new ModifierContainer();
		private static readonly ScoreTeamVictoryComparer victoryComparer = new ScoreTeamVictoryComparer();

		#endregion Fields

		#region Private

		private ScoreTeam GetTeam( IBattlePlayer player ) {
			return container.Find(delegate(ScoreTeam team) { return team.TeamNumber == player.TeamNumber; });
		}

		#region Modifiers
		
		/// <summary>
		/// helper method to get the modifier for a 2 players battle
		/// </summary>
		/// <param name="s1"></param>
		/// <param name="s2"></param>
		/// <param name="mod"></param>
		/// <returns></returns>
		private static double GetMod( ScoreTeam s1, ScoreTeam s2, double mod ) {
			if( s1.VictoryPercentage > s2.VictoryPercentage ) {
				return -mod;
			}
			return mod;
		}

		/// <summary>
		/// Gets the modifer when there are 2 teams in a battle
		/// </summary>
		/// <param name="player">Current Player to calculate the score</param>
		/// <returns>The value of the modifier</returns>
		private double VictoryModifier2Teams( IBattlePlayer player ) {
			double mod = victoryPercentageModifier.GetModifier(player.VictoryPercentage);
			if( container[0].ContainsPlayer(player) ) {
				return GetMod(container[0], container[1], mod);
			}
			return GetMod(container[1], container[0], mod);
		}

		/// <summary>
		/// Gets the other value to calculate the modifier of the current player
		/// </summary>
		/// <param name="i">Index of the current player</param>
		/// <returns>Value of the other rank to calculate the modifier</returns>
		private int GetOtherVictory( int i ) {
			switch( i ) {
				case 0:
					return container[2].VictoryPercentage;
				case 1:
					if( container.Count == 4 ) {
						return container[3].VictoryPercentage;
					}
					return container[2].VictoryPercentage;
				case 2:
					return container[0].VictoryPercentage;
				default:
					return container[1].VictoryPercentage;
			}
		}

		/// <summary>
		/// Gets the modifer for the current player
		/// </summary>
		/// <param name="i">Index, in the team container, of the current player</param>
		/// <returns>Modifier for the current player</returns>
		private double GetVictoryModifier( int i ) {
			int victory = container[i].VictoryPercentage;
			int otherVictory = GetOtherVictory(i);
			double mult = i > 2 ? 1 : -1;

			double mod = victoryPercentageModifier.GetModifier(Math.Abs(victory - otherVictory));

			return mod * mult;
		}

		/// <summary>
		/// Gets the modifer when there are 2 teams in a battle
		/// </summary>
		/// <param name="player">Current Player to calculate the score</param>
		/// <returns>The value of the modifier</returns>
		private double VictoryModifier4Teams( IBattlePlayer player ) {
			for( int i = 0; i < container.Count; ++i ) {
				if( container[i].TeamNumber == player.TeamNumber ) {
					return GetVictoryModifier(i);
				}
			}
			return 1;
		}

		#endregion Victory Modifier

		#endregion Private

		#region Public

		public void AddPlayers( List<IBattlePlayer> players ) {
			foreach (IBattlePlayer player in players) {
				ScoreTeam team = GetTeam(player);
				if( null != team ) {
					team.AddPlayer(player);
				} else {
					container.Add(new ScoreTeam(player));
				}
			}
		}

		/// <summary>
		/// Gets the modifier for the passed player
		/// </summary>
		public double GetVictoryModifier( IBattlePlayer player ) {
			container.Sort(victoryComparer);
			if( container.Count == 2 ) {
				return VictoryModifier2Teams(player);
			}
			return VictoryModifier4Teams(player);
		}

		#endregion Public

		#region Constructor

		static ScoreTeamVictoryContainer() {
			victoryPercentageModifier.Add(95, 100, 0.9d);
			victoryPercentageModifier.Add(90, 94, 0.8d);
			victoryPercentageModifier.Add(85, 89, 0.7d);
			victoryPercentageModifier.Add(80, 84, 0.6d);
			victoryPercentageModifier.Add(75, 79, 0.5d);
			victoryPercentageModifier.Add(70, 74, 0.4d);
			victoryPercentageModifier.Add(65, 69, 0.3d);
			victoryPercentageModifier.Add(60, 64, 0.2d);
			victoryPercentageModifier.Add(55, 59, 0.1d);
			victoryPercentageModifier.Add(50, 54, 0d);
			victoryPercentageModifier.Add(45, 49, 0d);
			victoryPercentageModifier.Add(40, 44, 0.1d);
			victoryPercentageModifier.Add(35, 39, 0.2d);
			victoryPercentageModifier.Add(30, 34, 0.3d);
			victoryPercentageModifier.Add(25, 29, 0.4d);
			victoryPercentageModifier.Add(20, 24, 0.5d);
			victoryPercentageModifier.Add(15, 19, 0.6d);
			victoryPercentageModifier.Add(10, 14, 0.7d);
			victoryPercentageModifier.Add(5, 9, 0.8d);
			victoryPercentageModifier.Add(0, 4, 0.9d);
		}

		#endregion Constructor

	}
}
