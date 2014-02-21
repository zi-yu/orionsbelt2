using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.Generic;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents quest information
    /// </summary>
    public interface IQuestData : IBackToStorage<QuestStorage> {

        #region Properties

        /// <summary>
        /// The quest owner
        /// </summary>
        IPlayer Player { get;set; }

        /// <summary>
        /// True if the quest has progressive counting
        /// </summary>
        bool IsProgressive { get; set;}

        /// <summary>
        /// True if the quest was already completed
        /// </summary>
        bool Completed { get;set;}

        /// <summary>
        /// The completness of the quest
        /// </summary>
        double Percentage { get;set;}

        /// <summary>
        /// True id this data is a template
        /// </summary>
        bool IsTemplate { get;set;}

        /// <summary>
        /// The quest name
        /// </summary>
        string Name { get;set;}

        /// <summary>
        /// The quest type
        /// </summary>
        IQuestInfo Info { get;set;}

        /// <summary>
        /// The deadline tick
        /// </summary>
        int DeadlineTick { get;set;}

        /// <summary>
        /// The start tick
        /// </summary>
        int StartTick { get;set;}

        /// <summary>
        /// The quest reward
        /// </summary>
        Dictionary<IResourceInfo, int> Reward { get;set;}

        /// <summary>
        /// The quest configuration
        /// </summary>
        Dictionary<string, string> QuestStringConfig { get;set;}

        /// <summary>
        /// The quest configuration
        /// </summary>
        Dictionary<string, int> QuestIntConfig { get;set;}

        /// <summary>
        /// The quest progress
        /// </summary>
        Dictionary<string, int> QuestIntProgress { get;set;}

        /// <summary>
        /// The quest progress
        /// </summary>
        Dictionary<string, string> QuestStringProgress { get;set;}

        #endregion Properties

        #region Methods

        /// <summary>
        /// Checks if the quest can be completed at this time
        /// </summary>
        /// <returns></returns>
        Result CanComplete();

        /// <summary>
        /// Completes the quest
        /// </summary>
        void Complete();

        #endregion Methods

    };

}
