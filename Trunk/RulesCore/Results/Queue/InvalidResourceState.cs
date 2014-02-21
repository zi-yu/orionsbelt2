using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// CanQueue result
    /// </summary>
    public class InvalidResourceState : RulesResultItem  {

        #region Ctor & Properties

        public InvalidResourceState()
            : base("Resource not in a valid queue state")
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
