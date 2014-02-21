using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;

namespace OrionsBelt.RulesCore.Interfaces
{
    public interface IBattleResult
    {
        /// <summary>
        /// Player information
        /// </summary>
        Principal Player { get; set; }

        /// <summary>
        /// Score information
        /// </summary>
        int ScoreMade { get; set; }

        /// <summary>
        /// True if player lost the battle
        /// </summary>
        bool HasLost { get; set; }
    }
}
