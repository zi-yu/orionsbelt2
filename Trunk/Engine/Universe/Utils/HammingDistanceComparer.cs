using System.Collections.Generic;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.Engine.Universe {
	public class HammingDistanceComparer : IComparer<CoordinateDistance> {
		#region IComparer<CoordinateDistance> Members

		public int Compare(CoordinateDistance x, CoordinateDistance y) {
			if( x.HammingSystemDistance == y.HammingSystemDistance ) {
				return x.HammingSectorDistance.CompareTo(y.HammingSectorDistance);
			}
			return x.HammingSystemDistance.CompareTo(y.HammingSystemDistance);
		}

		#endregion
	}
}
