using System.Collections.Generic;

namespace OrionsBelt.BattleCore {
	internal class ScoreTeamTopComparer : IComparer<ScoreTeam> {

		#region IComparer<ScoreTeam> Members

		public int Compare( ScoreTeam x, ScoreTeam y ) {
			if( x.Rank > y.Rank ) {
				return 1;
			}

			if( x.Rank == y.Rank ) {
				return 0;
			}
			return -1;
		}

		#endregion
	}
}
