using System;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	internal class ScoreTeamTopContainer {

		#region Fields

		private readonly List<ScoreTeam> container = new List<ScoreTeam>();
		private static readonly ModifierContainer topRulerModifier = new ModifierContainer();
		private static readonly ScoreTeamTopComparer topComparer = new ScoreTeamTopComparer();

		#endregion Fields

		#region Private

		private ScoreTeam GetTeam( IBattlePlayer player ) {
			return container.Find(delegate(ScoreTeam team) { return team.TeamNumber == player.TeamNumber; });
		}

		#region Top Modifier

		/// <summary>
		/// Gets the other value to calculate the modifier of the current player
		/// </summary>
		/// <param name="i">Index of the current player</param>
		/// <returns>Value of the other rank to calculate the modifier</returns>
		private int GetOtherRank( int i ) {
			switch( i ) {
				case 0:
					return container[2].Rank;
				case 1:
					if( container.Count == 4 ) {
						return container[3].Rank;
					}
					return container[2].Rank;
				case 2:
					return container[0].Rank;
				default:
					return container[1].Rank;
			}
		}

		/// <summary>
		/// Gets the modifer for the current player
		/// </summary>
		/// <param name="i">Index, in the team container, of the current player</param>
		/// <returns>Modifier for the current player</returns>
		private double GetTopModifier( int i ) {
			int currentRank = container[i].Rank;
			int otherRank = GetOtherRank(i);
			double mult = i > 2 ? 1 : -1;

			double mod = topRulerModifier.GetModifier(Math.Abs(currentRank - otherRank));

			return mod * mult;
		}

		/// <summary>
		/// Gets the top modifer when there are 2 teams in a battle
		/// </summary>
		/// <param name="player">Current Player to calculate the score</param>
		/// <returns>The value of the modifier</returns>
		private double TopModifier2Teams( IBattlePlayer player ) {
			int value = Math.Abs(container[0].Rank - container[1].Rank);
			double mod = topRulerModifier.GetModifier(value);
			if( container[0].ContainsPlayer(player) ) {
				return -mod;
			}
			return mod;
		}

		/// <summary>
		/// Gets the top modifer when there are 4 teams in a battle
		/// </summary>
		/// <param name="player">Current Player to calculate the score</param>
		/// <returns>The value of the modifier</returns>
		private double TopModifier4Teams( IBattlePlayer player ) {
			for( int i = 0; i < container.Count; ++i ) {
				if( container[i].TeamNumber == player.TeamNumber ) {
					return GetTopModifier(i);
				}
			}
			return 1;
		}

		#endregion

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
		public double GetTopModifier( IBattlePlayer player ) {
			container.Sort(topComparer);
			if( container.Count == 2 ) {
				return TopModifier2Teams(player);
			}
			return TopModifier4Teams(player);
		}

		#endregion Public

		#region Constructor

		static ScoreTeamTopContainer() {
			topRulerModifier.Add(1, 4, 0);
			topRulerModifier.Add(5, 19, 0.1d);
			topRulerModifier.Add(20, 39, 0.2d);
			topRulerModifier.Add(40, 59, 0.3d);
			topRulerModifier.Add(60, 79, 0.4d);
			topRulerModifier.Add(79, 0.5d);
		}

		#endregion Constructor

	}
}
