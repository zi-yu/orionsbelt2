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
    [FactoryKey("Terrest")]
    public class TerrestTerrainInfo : TerrainInfo {

        #region ITerrainInfo Implementation

        public override Terrain Terrain {
            get { return Terrain.Terrest; }
        }

        #endregion ITerrainInfo Implementation

        #region Ctor

        public TerrestTerrainInfo()
        {
            SetRichness(Gold.Resource, 70);
            SetRichness(Titanium.Resource, 40);
            SetRichness(Uranium.Resource, 40);

            SetRichness(Energy.Resource, 90);
            SetRichness(Mithril.Resource, 30);
            SetRichness(Serium.Resource, 30);

            SetRichness(Elk.Resource, 70);
            SetRichness(Protol.Resource, 50);

            SetRichness(Radon.Resource, 20);
            SetRichness(Astatine.Resource, 30);
            SetRichness(Prismal.Resource, 5);
            SetRichness(Cryptium.Resource, 15);
            SetRichness(Argon.Resource, 10);
        }

        #endregion Ctor

    };
}
