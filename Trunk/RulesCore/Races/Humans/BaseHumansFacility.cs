using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.RulesCore.Races {

    /// <summary>
    /// Base Humans facility
    /// </summary>
    [DesignPatterns.Attributes.NoAutoRegister]
    public abstract class BaseHumansFacility : BaseFacility {

        #region BaseFacility Implementation

        public override Race[] Races {
            get { return RaceUtils.LightHumans; }
        }

        #endregion BaseFacility Implementation

    };

}
