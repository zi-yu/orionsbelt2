using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Astatine resource
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("Astatine")]
    public class Astatine : BaseIntrinsic {

        #region Properties

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.Rare;
            }
        }

        public override string Name {
            get { return "Astatine"; }
        }

        public override bool IsResourceCost {
            get { return true; }
        }

        public override Race[] Races {
            get { return RaceUtils.AllRaces; }
        }

        public override bool IsRare {
            get { return true; }
        }

        #endregion Properties

        #region Static Utils

        public static IIntrinsicInfo Resource {
            get { return RulesUtils.GetIntrinsic(typeof(Astatine)); }
        }

        #endregion Static Utils

    };

}
