using System;
using System.Collections.Generic;
using System.Text;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// A resource is not available for construction
    /// </summary>
    public class ResourceNotAvailable : RulesResultItem  {

        #region Ctor & Properties

        public ResourceNotAvailable() : base("Resource Not Available")
        {
        }

        public override bool Ok {
	        get { 
		         return false;
	        }
        }

        #endregion Ctor & Properties

    };
}
