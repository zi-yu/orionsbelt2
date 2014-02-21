using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Results {

    /// <summary>
    /// CheckPlayerPlanetLevel result
    /// </summary>
    public class CheckPlayerPlanetLevel : RulesResultItem  {

        #region Ctor & Properties

        public CheckPlayerPlanetLevel(int playerLevel, int requiredLevel)
            : base(string.Format("Insuficient player level, Current: {0}, Required: {1}", playerLevel, requiredLevel), playerLevel.ToString(), requiredLevel.ToString())
        {
        }

        public override bool Ok {
	        get { return false; }
        }

        #endregion Ctor & Properties

    };
}
