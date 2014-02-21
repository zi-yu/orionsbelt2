using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Radon resource
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("Radon")]
    public class Radon : BaseIntrinsic {

        #region Properties

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Rare;
            }
        }

        public override string Name {
            get { return "Radon"; }
        }

        public override Race[] Races {
            get { return RaceUtils.AllRaces; }
        }

        public override bool IsResourceCost {
            get { return true; }
        }

        public override bool IsRare {
            get { return true; }
        }

        #endregion Properties

        #region Static Utils

        public static IIntrinsicInfo Resource {
            get { return RulesUtils.GetIntrinsic(typeof(Radon)); }
        }

        #endregion Static Utils

    };

}
