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
    [FactoryKey("Ice")]
    public class IceTerrainInfo : TerrainInfo {

        #region ITerrainInfo Implementation

        public override Terrain Terrain {
            get { return Terrain.Ice; }
        }

        #endregion ITerrainInfo Implementation

        #region Ctor

        public IceTerrainInfo()
        {
            SetRichness(Gold.Resource, 40);
            SetRichness(Titanium.Resource, 70);
            SetRichness(Uranium.Resource, 80);

            SetRichness(Energy.Resource, 30);
            SetRichness(Mithril.Resource, 50);
            SetRichness(Serium.Resource, 40);

            SetRichness(Elk.Resource, 40);
            SetRichness(Protol.Resource, 40);

            SetRichness(Radon.Resource, 35);
            SetRichness(Astatine.Resource, 45);
            SetRichness(Prismal.Resource, 35);
            SetRichness(Cryptium.Resource, 45);
            SetRichness(Argon.Resource, 40);
        }

        #endregion Ctor

    };
}
