using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Marks an IResourceOwner with intrinsic resources richness
    /// </summary>
    public interface IResourceRichness {

        #region Properties

        /// <summary>
        /// Richness per resource
        /// </summary>
        Dictionary<IResourceInfo, int> Richness { get;set;}

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the richness for the specified resource
        /// </summary>
        /// <param name="info">The resource</param>
        /// <returns>The richness</returns>
        int GetRichness(IResourceInfo info);

        /// <summary>
        /// Sets the richness for a resource
        /// </summary>
        /// <param name="info">The resource</param>
        /// <param name="quantity">The richness</param>
        void SetRichness(IResourceInfo info, int quantity);

        /// <summary>
        /// Adds the specified value to the current resource richness
        /// </summary>
        /// <param name="info">The resource</param>
        /// <param name="quantity">The quantity</param>
        void AddToRichness(IResourceInfo info, int quantity);

        #endregion Methods

    };
}
