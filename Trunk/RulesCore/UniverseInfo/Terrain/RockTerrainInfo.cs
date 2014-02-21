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
    [FactoryKey("Rock")]
    public class RockTerrainInfo : TerrainInfo {

        #region ITerrainInfo Implementation

        public override Terrain Terrain {
            get { return Terrain.Rock; }
        }

        #endregion ITerrainInfo Implementation

        #region Ctor

        public RockTerrainInfo()
        {
            SetRichness(Gold.Resource, 70);
            SetRichness(Titanium.Resource, 60);
            SetRichness(Uranium.Resource, 80);

            SetRichness(Energy.Resource, 30);
            SetRichness(Mithril.Resource, 99);
            SetRichness(Serium.Resource, 50);

            SetRichness(Elk.Resource, 40);
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
