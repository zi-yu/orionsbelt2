using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// A resource is not available for construction
    /// </summary>
    public class DropMaximumFleets : RulesResultItem  {

        #region Ctor & Properties

		public DropMaximumFleets( IResourceInfo resource )
			: base(string.Format("Not all {0}s could be created because the maximum number of fleets has been achieved",resource.Name), resource.Name)
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
