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
    [FactoryKey("Water")]
    public class WaterTerrainInfo : TerrainInfo {

        #region ITerrainInfo Implementation

        public override Terrain Terrain {
            get { return Terrain.Water; }
        }

        #endregion ITerrainInfo Implementation

        #region Ctor

        public WaterTerrainInfo()
        {
            SetRichness(Gold.Resource, 20);
            SetRichness(Titanium.Resource, 40);
            SetRichness(Uranium.Resource, 40);

            SetRichness(Energy.Resource, 80);
            SetRichness(Mithril.Resource, 5);
            SetRichness(Serium.Resource, 5);

            SetRichness(Elk.Resource, 90);
            SetRichness(Protol.Resource, 90);

            SetRichness(Radon.Resource, 5);
            SetRichness(Astatine.Resource, 45);
            SetRichness(Prismal.Resource, 35);
            SetRichness(Cryptium.Resource, 45);
            SetRichness(Argon.Resource, 1);
        }

        #endregion Ctor

    };
}
