using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// QuantityRestrictionResult result
    /// </summary>
    public class QuantityRestrictionResult : RulesResultItem  {

        #region Ctor & Properties

        private int wanted;
        private int max;

        public QuantityRestrictionResult(IPlayer player, int wanted, int max)
            : base("Player can't build ultimates", wanted.ToString(), max.ToString())
        {
            this.wanted = wanted;
            this.max = max;
        }

        public override bool Ok {
	        get {
                return this.wanted <= this.max; ;
	        }
        }

        #endregion Ctor & Properties

    };
}
