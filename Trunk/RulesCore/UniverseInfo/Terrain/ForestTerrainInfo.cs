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
    [FactoryKey("Forest")]
    public class ForestTerrainInfo : TerrainInfo {

        #region ITerrainInfo Implementation

        public override Terrain Terrain {
            get { return Terrain.Forest; }
        }

        #endregion ITerrainInfo Implementation

        #region Ctor

        public ForestTerrainInfo()
        {
            SetRichness(Gold.Resource, 60);
            SetRichness(Titanium.Resource, 60);
            SetRichness(Uranium.Resource, 60);

            SetRichness(Energy.Resource, 50);
            SetRichness(Mithril.Resource, 10);
            SetRichness(Serium.Resource, 60);

            SetRichness(Elk.Resource, 50);
            SetRichness(Protol.Resource, 50);

            SetRichness(Radon.Resource, 25);
            SetRichness(Astatine.Resource, 15);
            SetRichness(Prismal.Resource, 35);
            SetRichness(Cryptium.Resource, 45);
            SetRichness(Argon.Resource, 30);
        }

        #endregion Ctor

    };
}
