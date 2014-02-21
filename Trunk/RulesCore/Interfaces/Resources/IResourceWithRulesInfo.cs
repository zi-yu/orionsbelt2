using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Resource metadata
    /// </summary>
    public interface IResourceWithRulesInfo : IResourceInfo {
        
        #region Properties

        /// <summary>
        /// This facility rules
        /// </summary>
        IRuleSet Rules { get;}

        /// <summary>
        /// The initial resource state when created
        /// </summary>
        ResourceState InitialState { get;}
    
        #endregion Properties

        #region Methods

        

        #endregion Methods

    };
}
