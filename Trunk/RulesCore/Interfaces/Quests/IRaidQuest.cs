using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;
using OrionsBelt.Core;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents a quest that handles planet raids
    /// </summary>
    public interface IRaidQuest {

        /// <summary>
        /// Processes the raid
        /// </summary>
        /// <param name="data">The original data</param>
        /// <param name="winner">The raider</param>
        /// <param name="looser">The raidee</param>
        void Process(IQuestData data, IPlayer winner, IPlayer looser );

    };

}
