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
    [DesignPatterns.Attributes.FactoryKey("Bugs")]
    public class BugsInfo : RaceInfo {

        #region RaceInfo Implementation

        public override Race Race {
            get { return Race.Bugs; }
        }

        public override IIntrinsicInfo RichResource {
            get { return Prismal.Resource; }
        }

        public override IIntrinsicInfo MoreNeededResource {
            get { return Argon.Resource; }
        }

        public override void Initialize(IPlayer player)
        {
            player.AddQuantity(Elk.Resource, 500);
            player.AddQuantity(Protol.Resource, 500);
            player.AddQuantity(Astatine.Resource, 80);
        }

        #endregion RaceInfo Implementation

    };
}
