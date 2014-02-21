using System.Collections.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {
	public class HammingSectorComparer : IComparer<ISector> {

		#region Fields

		private readonly SectorCoordinate destinySectorCoordinate;
		private static readonly HammingDistanceComparer hammingDistanceComparer = new HammingDistanceComparer();
		
		#endregion

		#region IComparer<Sector> Members

		public int Compare(ISector x, ISector y) {
			CoordinateDistance cd1 = new CoordinateDistance(x.SystemCoordinate, x.SectorCoordinate, destinySectorCoordinate.System, destinySectorCoordinate.Sector);
			CoordinateDistance cd2 = new CoordinateDistance(y.SystemCoordinate, y.SectorCoordinate, destinySectorCoordinate.System, destinySectorCoordinate.Sector);

			return hammingDistanceComparer.Compare(cd1, cd2);
		}

		#endregion IComparer<Sector> Members

		#region Constructor

		public HammingSectorComparer(SectorCoordinate destinySectorCoordinate) {
			this.destinySectorCoordinate = destinySectorCoordinate;
		}

		#endregion Constructor


	}
}
