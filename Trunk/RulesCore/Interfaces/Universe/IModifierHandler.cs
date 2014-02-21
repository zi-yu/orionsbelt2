using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.Core;
using System.Collections.Generic;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents an entity with intrinsic modifiers
    /// </summary>
    public interface IModifierHandler {

        #region Methods

        /// <summary>
        /// Gets the modifier for the given resource
        /// </summary>
        /// <param name="info">The resource</param>
        /// <returns>The modifier</returns>
        int GetModifier(IResourceInfo info);

        /// <summary>
        /// Changes the modifier for the given resource
        /// </summary>
        /// <param name="info">The resource</param>
        /// <param name="change">The change</param>
        void AddToModifier(IResourceInfo info, int change);

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets the modifiers container
        /// </summary>
        Dictionary<IResourceInfo, int> Modifiers { get; set;}

        #endregion Properties

    };

}
