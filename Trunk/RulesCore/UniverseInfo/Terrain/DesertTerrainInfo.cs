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
    [FactoryKey("Desert")]
    public class DesertTerrainInfo : TerrainInfo {

        #region ITerrainInfo Implementation

        public override Terrain Terrain {
            get { return Terrain.Desert; }
        }

        #endregion ITerrainInfo Implementation

        #region Ctor

        public DesertTerrainInfo()
        {
            SetRichness(Gold.Resource, 50);
            SetRichness(Titanium.Resource, 70);
            SetRichness(Uranium.Resource, 80);

            SetRichness(Energy.Resource, 99);
            SetRichness(Mithril.Resource, 40);
            SetRichness(Serium.Resource, 20);

            SetRichness(Elk.Resource, 30);
            SetRichness(Protol.Resource, 70);

            SetRichness(Radon.Resource, 40);
            SetRichness(Astatine.Resource, 10);
            SetRichness(Prismal.Resource, 15);
            SetRichness(Cryptium.Resource, 5);
            SetRichness(Argon.Resource, 10);
        }

        #endregion Ctor

    };
}
