using System;
using System.Collections.Generic;
using System.Text;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// A resource is not available for construction
    /// </summary>
    public class FleetCreated : RulesResultItem  {

        #region Ctor & Properties

		public FleetCreated(string fleetName)
			: base("Fleet '{0}' created.",fleetName)
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
