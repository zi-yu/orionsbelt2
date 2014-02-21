using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using DesignPatterns;
using OrionsBelt.RulesCore.Enum;
using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.RulesCore.UniverseInfo {

    /// <summary>
    /// Static terrain information/configuration for Water
    /// </summary>
    [FactoryKey("Space")]
    public class SpaceTerrainInfo : TerrainInfo {

        #region ITerrainInfo Implementation

        public override Terrain Terrain {
            get { return Terrain.Space; }
        }

        #endregion ITerrainInfo Implementation

		#region Properties

		public override bool AvailableForPlanets {
			get { return false; }
		}

		#endregion Properties

        #region Ctor

		public SpaceTerrainInfo()
        {
        }

        #endregion Ctor

    };
}
