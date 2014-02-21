using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// CanQueue result
    /// </summary>
    public class InvalidSlot : RulesResultItem  {

        #region Ctor & Properties

        public InvalidSlot(IFacilitySlot slot)
            : base("The provided slot `{0}' is invalid", slot != null? slot.Identifier : "null")
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
