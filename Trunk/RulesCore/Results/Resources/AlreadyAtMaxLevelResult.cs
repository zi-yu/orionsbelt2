using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// AlreadyAtMaxLevelResult result
    /// </summary>
    public class AlreadyAtMaxLevelResult : RulesResultItem  {

        #region Ctor & Properties

        public AlreadyAtMaxLevelResult(IPlanetResource resource)
            : base(string.Format("Resource {0} already at max level", resource.Info.Name))
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
