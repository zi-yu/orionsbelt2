using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents a quest that handles trade routes
    /// </summary>
	public interface IMobsQuest {

        /// <summary>
        /// Processes trade route resources
        /// </summary>
        /// <param name="coordinate">Coordinate of the sector</param>
        /// <param name="data">The quest data</param>
        /// <param name="resources">The resources</param>
		void Process(SectorCoordinate coordinate, IQuestData data, params IResourceQuantity[] resources);
    };

}
