using System.Collections.Generic;

namespace OrionsBelt.BattleCore {
	internal class ScoreTeamVictoryComparer: IComparer<ScoreTeam> {

		#region IComparer<ScoreTeam> Members

		public int Compare( ScoreTeam x, ScoreTeam y ) {
			if( x.VictoryPercentage > y.VictoryPercentage ) {
				return 1;
			}

			if( x.VictoryPercentage == y.VictoryPercentage ) {
				return 0;
			}
			return -1;
		}

		#endregion
	}
}
