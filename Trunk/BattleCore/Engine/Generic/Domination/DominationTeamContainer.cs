using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	internal class DominationTeamContainer {

		#region Fields

		private readonly List<DominationTeam> dominationTeamContainer = new List<DominationTeam>();
		private readonly static DominationPointsComparer comparer = new DominationPointsComparer();

		#endregion Fields

		#region Public

		/// <summary>
		/// Get's the team with the passed number. 
		/// </summary>
		/// <param name="player"></param>
		/// <returns>
		/// The object that represents the team. If the team 
		/// doesn't exists, then null is returned
		/// </returns>
		public void AddPlayer( IBattlePlayer player ) {
			DominationTeam dominationTeam = dominationTeamContainer.Find(delegate(DominationTeam t) { return t.TeamNumber == player.TeamNumber; });
			if( dominationTeam == null ) {
				dominationTeam = new DominationTeam(player);
				dominationTeamContainer.Add(dominationTeam);
			}else {
				dominationTeam.AddPlayer(player);
			}
		}

		/// <summary>
		/// Sorts the teams by domination points
		/// </summary>
		public void Sort() {
			dominationTeamContainer.Sort(comparer);		
		}

		/// <summary>
		/// Resolves the result of a battle
		/// </summary>
		/// <returns>True if there is a Team that has won, false otherside</returns>
		internal bool ResolveResult(IBattleInfo battleInfo) {
			Sort();
			if( dominationTeamContainer[0].DominationPoints > dominationTeamContainer[1].DominationPoints ) {
				for( int i = 1; i < dominationTeamContainer.Count; ++i ) {
					dominationTeamContainer[i].Lost();
				}
				return true;
			}

			int reference = dominationTeamContainer[0].DominationPoints;
			foreach (DominationTeam team in dominationTeamContainer) {
				if( team.DominationPoints < reference ) {
					team.Lost(battleInfo);
				}
			}
			return false;
		}

		#endregion Public


		
	}
}
