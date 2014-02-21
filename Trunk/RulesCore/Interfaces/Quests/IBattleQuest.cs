using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents a quest that handles battles
    /// </summary>
    public interface IBattleQuest {

        /// <summary>
        /// Processes a battle
        /// </summary>
        /// <param name="data">The quest data</param>
        /// <param name="battle">The battle</param>
        /// <param name="winners">The winners</param>
        /// <param name="loosers">The loosers</param>
        /// <param name="won">If the current player won</param>
        void Process(IQuestData data, IBattleInfo battle, IEnumerable<IPlayerOwner> winners, IEnumerable<IPlayerOwner> loosers, bool won);
    };

}
