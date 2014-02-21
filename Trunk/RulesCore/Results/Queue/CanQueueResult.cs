using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// CanQueue result
    /// </summary>
    public class CanQueueResult : RulesResultItem  {

        #region Ctor & Properties

        public CanQueueResult(bool available)
            : base("Available Queue Space")
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
