using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents a race configuration
    /// </summary>
    public interface IRaceInfo : IResourceRichness {

        #region Properties

        /// <summary>
        /// The target race
        /// </summary>
        Race Race { get;}

        /// <summary>
        /// A resource that this race can more easilly get
        /// </summary>
        IIntrinsicInfo RichResource { get;}

        /// <summary>
        /// A resource that this race need more often
        /// </summary>
        IIntrinsicInfo MoreNeededResource { get;}

        #endregion Properties

        #region Methods

        /// <summary>
        /// Initialized a player for this race
        /// </summary>
        /// <param name="player">The player</param>
        void Initialize(IPlayer player);

        #endregion Methods

    };
}
