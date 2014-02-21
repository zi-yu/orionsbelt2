using System;
using System.Collections.Generic;
using System.Text;

namespace OrionsBelt.RulesCore.Common {

    /// <summary>
    /// Specifies a resource state
    /// </summary>
    public enum ResourceState {

        /// <summary>
        /// The resource isn't available
        /// </summary>
        UnAvailable,

        /// <summary>
        /// The resource is available for construction
        /// </summary>
        Available,

        /// <summary>
        /// The resource is in queue for construction
        /// </summary>
        InQueue,

        /// <summary>
        /// The resource is in the middle of its construction
        /// </summary>
        InConstruction,

        /// <summary>
        /// The resource is complete
        /// </summary>
        Complete,

        /// <summary>
        /// The resource is operating as it should
        /// </summary>
        Running,

        /// <summary>
        /// This resource is marked for removal
        /// </summary>
        Deleted,

        /// <summary>
        /// This resource was destroyed
        /// </summary>
        Destroyed

    };

}
