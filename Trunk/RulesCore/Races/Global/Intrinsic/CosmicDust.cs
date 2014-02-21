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
    [DesignPatterns.Attributes.FactoryKey("CosmicDust")]
    public class CosmicDust : BaseIntrinsic {

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
            get { return "CosmicDust"; }
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
            get { return RulesUtils.GetIntrinsic(typeof(CosmicDust)); }
        }

        #endregion Static Utils

    };

}
