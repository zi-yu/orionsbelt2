using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Argon resource
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("Animals")]
    public class Animals : BaseIntrinsic {

        #region Properties

        public override int StartLevel {
            get { return 10; }
        }

        public override AuctionHouseType AuctionType
        {
            get
            {
                return AuctionHouseType.None;
            }
        }

        public override string Name {
            get { return "Animals"; }
        }

        public override Race[] Races {
            get { return RaceUtils.NoRace; }
        }

        public override bool IsRare {
            get { return false; }
        }

        public override bool CanUnloadFromFleet {
            get { return false; }
        }

        #endregion Properties

        #region Static Utils

        public static IIntrinsicInfo Resource {
            get { return RulesUtils.GetIntrinsic(typeof(Animals)); }
        }

        #endregion Static Utils

    };

}
