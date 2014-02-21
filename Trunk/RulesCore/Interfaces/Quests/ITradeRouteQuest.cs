using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;
using OrionsBelt.Core;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents a quest that handles trade routes
    /// </summary>
    public interface ITradeRouteQuest {

        /// <summary>
        /// Processes trade route resources
        /// </summary>
        /// <param name="market">The market where the goods were delivered</param>
        /// <param name="data">The quest data</param>
        /// <param name="resources">The resources</param>
        void Process(Market market, IQuestData data, params IResourceQuantity[] resources );
    };

}
