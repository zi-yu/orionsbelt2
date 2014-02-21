using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Gold resource
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("ProductionSpace")]
    public class ProductionSpace : BaseIntrinsic {

        #region Properties

        public override string Name {
            get { return "ProductionSpace"; }
        }

        public override Race[] Races {
            get { return RaceUtils.AllRaces; }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override bool Conceptual {
            get { return true; }
        }

        #endregion Properties

        #region Static Utils

        public static IResourceInfo Resource {
            get { return RulesUtils.GetResource(typeof(ProductionSpace)); }
        }

        #endregion Static Utils

    };

}
