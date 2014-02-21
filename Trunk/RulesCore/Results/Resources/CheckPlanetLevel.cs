using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// CheckPlayerPlanetLevel result
    /// </summary>
    public class CheckPlanetLevel : RulesResultItem  {

        #region Ctor & Properties

        public CheckPlanetLevel(int planetLevel, int requiredLevel)
            : base(string.Format("Insuficient planet level, Current: {0}, Required: {1}", planetLevel, requiredLevel), planetLevel.ToString(), requiredLevel.ToString())
        {
        }

        public override bool Ok {
	        get { return false; }
        }

        #endregion Ctor & Properties

    };
}
