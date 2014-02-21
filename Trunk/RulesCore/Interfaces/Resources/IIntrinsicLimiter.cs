using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Marks an IResourceOwner with intrinsic storage limits
    /// </summary>
    public interface IIntrinsicLimiter {

        #region Properties

        /// <summary>
        /// Gets the limits
        /// </summary>
        Dictionary<IResourceInfo, int> Limits { get;set;}

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets the limit for the specified resource
        /// </summary>
        /// <param name="info">The resource</param>
        /// <returns>The limit</returns>
        int GetLimit(IResourceInfo info);

        /// <summary>
        /// Sets the limit for a resource
        /// </summary>
        /// <param name="info">The resource</param>
        /// <param name="quantity">The limit</param>
        void SetLimit(IResourceInfo info, int quantity);

        /// <summary>
        /// Adds the specified value to the current resource limit
        /// </summary>
        /// <param name="info">The resource</param>
        /// <param name="quantity">The quantity</param>
        void AddToLimit(IResourceInfo info, int quantity);

        #endregion Methods

    };
}
