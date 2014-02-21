using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.Engine.Results {

    /// <summary>
    /// A ResultItem provided by RulesCore
    /// </summary>
    public class NotEmptyCoordinate : ResultItem {

        #region Ctor

        public NotEmptyCoordinate(SectorCoordinate coordinate)
        {
            log = log =
                string.Format("Coordinate {0}:{1}:{2}:{3} is not empty.", coordinate.System.X, coordinate.System.Y,
                              coordinate.Sector.X,
                              coordinate.Sector.Y);
        }

        #endregion Ctor

        public override bool Ok
        {
            get
            {
                return false;
            }
        }

    };
}
