using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Uranium resource
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("Uranium")]
    public class Uranium : BaseIntrinsic {

        #region Properties

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Intrinsic | AuctionHouseType.DarkHuman;
            }
        }

        public override string Name {
            get { return "Uranium"; }
        }

        public override Race[] Races {
            get { return RaceUtils.DarkHumans; }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override bool IsResourceCost {
            get { return true; }
        }

        #endregion Properties

        #region Static Utils

        public static IIntrinsicInfo Resource {
            get { return RulesUtils.GetIntrinsic(typeof(Uranium)); }
        }

        #endregion Static Utils

    };

}
