using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// UltimateRestrictionResult result
    /// </summary>
    public class UltimateRestrictionResult : RulesResultItem  {

        #region Ctor & Properties

        private int nUltimates;
        private int nFacilities;

        public UltimateRestrictionResult(IPlayer player, int nUltimates, int nFacilities)
            : base("Player can't build ultimates", nUltimates.ToString(), nFacilities.ToString())
        {
            this.nUltimates = nUltimates;
            this.nFacilities = nFacilities;
        }

        public override bool Ok {
	        get {
                return this.nFacilities > this.nUltimates; ;
	        }
        }

        #endregion Ctor & Properties

    };
}
