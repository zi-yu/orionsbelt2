using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.UniverseInfo;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.RulesCore.UniverseInfo {

    /// <summary>
    /// Static race information/configuration
    /// </summary>
    [DesignPatterns.Attributes.FactoryKey("SpaceForce")]
    public class SpaceForce : RaceInfo
    {

        #region RaceInfo Implementation

        public override Race Race {
            get { return Race.SpaceForce; }
        }

        public override IIntrinsicInfo RichResource {
            get { return Astatine.Resource; }
        }

        public override IIntrinsicInfo MoreNeededResource {
            get { return Prismal.Resource; }
        }

        public override void Initialize(IPlayer player)
        {
			player.AddQuantity(Energy.Resource, 500);
			player.AddQuantity(Serium.Resource, 500);
			player.AddQuantity(Mithril.Resource, 0);
			player.AddQuantity(Astatine.Resource, 80);
        }

        #endregion RaceInfo Implementation

    };
}
