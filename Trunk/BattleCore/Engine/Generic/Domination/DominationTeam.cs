using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	internal class DominationTeam {

		#region Fields

		private readonly List<IBattlePlayer> players = new List<IBattlePlayer>();
		private int dominationPoints;
		private readonly int teamNumber;

		#endregion Fields

		#region Properties

		public int DominationPoints {
			get { return dominationPoints; }
		}

		public int TeamNumber {
			get { return teamNumber; }
		}

		#endregion Properties

		#region Public
		
		/// <summary>
		/// Adds a new player to the team
		/// </summary>
		/// <param name="p">Player to add</param>
		internal void AddPlayer( IBattlePlayer p  ) {
			players.Add(p);
			dominationPoints += p.DominationPoints;
		}

		/// <summary>
		/// Sets all the HasLost property of the player of this team to true
		/// </summary>
		internal void Lost() {
			foreach (IBattlePlayer player in players) {
				player.HasLost = true;
			}
		}

		/// <summary>
		/// Sets all the HasLost property of the player of this team to true
		/// and removes all the units from the battle
		/// </summary>
		internal void Lost(IBattleInfo battleInfo) {
			foreach( IBattlePlayer player in players ) {
				player.HasLost = true;
				battleInfo.RemovePlayerUnits(player);
			}
		}

		#endregion Public

		#region Constructor

		public DominationTeam(IBattlePlayer p ) {
			teamNumber = p.TeamNumber;
			dominationPoints = p.DominationPoints;
			players.Add(p);
		}

		#endregion Constructor

	}
}
