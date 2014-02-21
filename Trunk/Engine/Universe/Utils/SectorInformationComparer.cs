using System.Collections.Generic;

namespace OrionsBelt.Engine.Universe {
	public class SectorInformationComparer : IComparer<SectorInformation> {

		#region IComparer<SectorInformation> Members

		public int Compare(SectorInformation x, SectorInformation y) {
			return x.Coordinate.Sector.CompareTo(y.Coordinate.Sector);
		}

		#endregion
	}
}
