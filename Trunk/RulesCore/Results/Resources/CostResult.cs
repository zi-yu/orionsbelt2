using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// Cost result
    /// </summary>
    public class CostResult : RulesResultItem  {

        #region Ctor & Properties

        public CostResult(IIntrinsicInfo resource, int quantity, bool available)
            : base(string.Format("Resource needed: {1} {0}", resource.Name, quantity), resource.Name, quantity.ToString())
        {
            this.available = available;
        }

        private bool available = false;
        public override bool Ok {
	        get { 
		         return available;
	        }
        }

        #endregion Ctor & Properties

    };
}
