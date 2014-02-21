using System.Collections.Generic;

namespace OrionsBelt.BattleCore {
	internal class DominationPointsComparer : IComparer<DominationTeam> {
		#region IComparer<DominationTeam> Members

		public int Compare( DominationTeam x, DominationTeam y ) {
			return y.DominationPoints.CompareTo(x.DominationPoints);
		}

		#endregion IComparer<DominationTeam> Members
	}
}
