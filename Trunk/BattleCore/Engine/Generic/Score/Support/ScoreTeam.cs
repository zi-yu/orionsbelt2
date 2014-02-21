
using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	public class ScoreTeam {

		#region Fields

		private readonly List<IBattlePlayer> players = new List<IBattlePlayer>();
		private int rank = 0;
		private int percentage = 0;
		private readonly int teamNumber = 0;

		#endregion Fields

		#region Properties

		public int Rank {
			get { return rank; }
		}

		public int TeamNumber {
			get { return teamNumber; }
		}

		public int VictoryPercentage {
			get { return percentage; }
		}

		#endregion Properties

		#region Public

		/// <summary>
		/// Adds a new player to the team
		/// </summary>
		/// <param name="player">Player to add</param>
		public void AddPlayer( IBattlePlayer player ) {
			players.Add(player);
			rank += player.Owner.Ranking;
			percentage += player.VictoryPercentage;
		}

		/// <summary>
		/// If the team contains the player
		/// </summary>
		/// <param name="player">Player to search</param>
		/// <returns>True of the team contains the player</returns>
		public bool ContainsPlayer( IBattlePlayer player ) {
			IBattlePlayer found = players.Find(delegate(IBattlePlayer p) { return player.PlayerNumber == p.PlayerNumber; });
			return found != null;
		}

		#endregion Public

		#region Constructor

		public ScoreTeam( IBattlePlayer player ) {
			AddPlayer(player);
			teamNumber = player.TeamNumber;
		}

		#endregion Constructor
		
	}
}
