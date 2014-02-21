using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Gold resource
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("QueueSpace")]
    public class QueueSpace : BaseIntrinsic {

        #region Properties

        public override string Name {
            get { return "QueueSpace"; }
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
            get { return RulesUtils.GetResource(typeof(QueueSpace)); }
        }

        #endregion Static Utils

    };

}
