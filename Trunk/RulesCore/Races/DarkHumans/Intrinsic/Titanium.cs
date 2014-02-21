using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Titanium resource
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("Titanium")]
    public class Titanium : BaseIntrinsic {

        #region Properties

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Intrinsic | AuctionHouseType.DarkHuman;
            }
        }

        public override string Name {
            get { return "Titanium"; }
        }

        public override Race[] Races {
            get { return RaceUtils.DarkHumans; }  
        }

        public override bool IsResourceCost {
            get { return true; }
        }

        public override bool IsRare {
            get { return false; }
        }

        #endregion Properties

        #region Static Utils

        public static IIntrinsicInfo Resource {
            get { return RulesUtils.GetIntrinsic(typeof(Titanium)); }
        }

        #endregion Static Utils

    };

}
