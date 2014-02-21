using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using System.Collections.Specialized;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents a type of quest
    /// </summary>
    public interface IQuestInfo {

        #region Properties

        /// <summary>
        /// The quest info name
        /// </summary>
        string Name { get;}

        /// <summary>
        /// True if the quest has progressive counting
        /// </summary>
        bool IsProgressive { get; }

        /// <summary>
        /// This quest context
        /// </summary>
        QuestContext Context { get;}

        /// <summary>
        /// The target Context player that the player needs
        /// </summary>
        int TargetLevel { get;}

        /// <summary>
        /// The target race, if any
        /// </summary>
        IRaceInfo TargetRace { get;}

        /// <summary>
        /// The orions that this quest will give
        /// </summary>
        int OrionsReward { get;}

        /// <summary>
        /// The score that this quest will give
        /// </summary>
        int ScoreReward { get;}

        /// <summary>
        /// The profession points
        /// </summary>
        Dictionary<Profession, int> ProfessionPoints { get;}

        /// <summary>
        /// The Intrinsic rewards
        /// </summary>
        Dictionary<IResourceInfo, int> IntrinsicRewards { get;}

        /// <summary>
        /// List of other quest dependencies
        /// </summary>
        IList<IQuestInfo> Dependencies { get; }

        /// <summary>
        /// True if only one exclusive quest can be done at a time
        /// </summary>
        bool IsExclusive { get;}

        /// <summary>
        /// True if the player can have several of this quest at the same time
        /// </summary>
        bool CanAcceptMultiple { get;}

		/// <summary>
		/// Resources needed to this quest
		/// </summary>
		IEnumerable<IResourceQuantity> MustHaveResources { get;}

        #endregion Properties

        #region Methods

        /// <summary>
        /// Checks if a quest is available to a player
        /// </summary>
        /// <param name="player">The player</param>
        /// <returns>True if is available</returns>
        bool IsAvailable(IPlayer player);

        /// <summary>
        /// Checks if the given quest can be completes
        /// </summary>
        /// <param name="quest">The quest</param>
        /// <returns>The result</returns>
        Result CanComplete(IQuestData quest);

        /// <summary>
        /// Completes the quest
        /// </summary>
        /// <param name="quest">The quest</param>
        void Complete(IQuestData quest);

        /// <summary>
        /// Adds this quest to a player
        /// </summary>
        /// <param name="winner"></param>
        IQuestData AddToPlayer(IPlayer player);

        /// <summary>
        /// Prepares the data if needed
        /// </summary>
        /// <param name="data">The target data to prepare</param>
        /// <param name="col">The parameters</param>
        void PrepareDataFromArgs(IQuestData data, NameValueCollection col);

        /// <summary>
        /// Gets scora based on the given data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int GetDataScore(IQuestData data);

        /// <summary>
        /// To run when a quest is abandoned
        /// </summary>
        /// <param name="data">The related data</param>
        void OnAbandon(IQuestData data);

        #endregion Methods

    };

}
