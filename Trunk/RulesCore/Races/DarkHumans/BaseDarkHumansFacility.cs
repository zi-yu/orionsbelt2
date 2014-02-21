using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Base DarkHumans facility
    /// </summary>
    [DesignPatterns.Attributes.NoAutoRegister]
    public abstract class BaseDarkHumansFacility : BaseFacility {

        #region BaseFacility Implementation

        public override Race[] Races {
            get { return RaceUtils.DarkHumans; }
        }

        #endregion BaseFacility Implementation

    };

}
