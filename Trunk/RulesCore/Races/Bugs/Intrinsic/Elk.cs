using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Elk resource
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("Elk")]
    public class Elk : BaseIntrinsic {

        #region Properties

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Intrinsic | AuctionHouseType.Bugs;
            }
        }

        public override string Name {
            get { return "Elk"; }
        }

        public override bool IsResourceCost {
            get { return true; }
        }

        public override Race[] Races {
            get { return RaceUtils.Bugs; }
        }

        public override bool IsRare {
            get { return false; }
        }

        #endregion Properties

        #region Static Utils

        public static IIntrinsicInfo Resource {
            get { return RulesUtils.GetIntrinsic(typeof(Elk)); }
        }

        #endregion Static Utils

    };

}
