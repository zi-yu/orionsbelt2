using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// A resource is not available for construction
    /// </summary>
    public class NotEnoughUnits : RulesResultItem  {

        #region Ctor & Properties

		public NotEnoughUnits(IFleetInfo fleet, string unitName, int quantity)
			: base("Fleet '{0}' doesn't have {1} {2}.", fleet.Name, quantity.ToString(), unitName)
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
