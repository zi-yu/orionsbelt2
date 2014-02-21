using System;
using System.Collections.Generic;
using System.Text;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// A resource is not available for construction
    /// </summary>
    public class MaximumFleets : RulesResultItem  {

        #region Ctor & Properties

		public MaximumFleets()
			: base("Maximum Fleets Achieved")
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
