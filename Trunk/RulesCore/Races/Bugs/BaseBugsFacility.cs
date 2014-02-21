using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Base DarkHumans facility
    /// </summary>
    [DesignPatterns.Attributes.NoAutoRegister]
    public abstract class BaseBugsFacility : BaseFacility {

        #region BaseFacility Implementation

        public override Race[] Races {
            get { return RaceUtils.Bugs; }
        }

        #endregion BaseFacility Implementation

    };

}
