using System;
using System.Collections.Generic;
using System.Text;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// A resource is available for construction
    /// </summary>
    public class ResourceAvailable : RulesResultItem  {

        #region Ctor & Properties

        public ResourceAvailable()
            : base("Resource Available")
        {
        }

        public override bool Ok {
	        get { 
		         return true;
	        }
        }

        #endregion Ctor & Properties

    };
}
