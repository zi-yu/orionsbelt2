using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.BattleCore {
	public class InvalidCoordinate : ResultItem {

		#region Constructor

		public InvalidCoordinate( string reason ) {
			parameters = new string[] { reason };
			log = "Invalid Coordinate: {0}";
		}

        public InvalidCoordinate(SectorCoordinate coordinate)
        {
            log =
                string.Format("Coordinate {0}:{1}:{2}:{3} is invalid.", coordinate.System.X, coordinate.System.Y,
                              coordinate.Sector.X,
                              coordinate.Sector.Y);
        }
		#endregion Constructor

	}
}
