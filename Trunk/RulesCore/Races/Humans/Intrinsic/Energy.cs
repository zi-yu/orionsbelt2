using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Gold resource
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("Energy")]
    public class Energy : BaseIntrinsic {

        #region Properties

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Intrinsic | AuctionHouseType.Human;
            }
        }

        public override string Name {
            get { return "Energy"; }
        }

        public override Race[] Races {
            get { return RaceUtils.Dummy; }
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
            get { return RulesUtils.GetIntrinsic(typeof(Energy)); }
        }

        #endregion Static Utils

    };

}
