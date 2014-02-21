using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using DesignPatterns;
using OrionsBelt.RulesCore.UniverseInfo;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.RulesCore.UniverseInfo {

    /// <summary>
    /// Static race information/configuration
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("DarkHumans")]
    public class DarkHumansInfo : RaceInfo {

        #region RaceInfo Implementation

        public override Race Race {
            get { return Race.DarkHumans; }
        }

        public override IIntrinsicInfo RichResource {
            get { return Cryptium.Resource; }
        }

        public override IIntrinsicInfo MoreNeededResource {
            get { return Prismal.Resource; }
        }

        public override void Initialize(IPlayer player)
        {
            player.AddQuantity(Gold.Resource, 500);
            player.AddQuantity(Titanium.Resource, 500);
            player.AddQuantity(Uranium.Resource, 0);
            player.AddQuantity(Astatine.Resource, 80);
        }

        #endregion RaceInfo Implementation

    };
}
