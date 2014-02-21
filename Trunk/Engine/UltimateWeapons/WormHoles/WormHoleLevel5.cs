using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("WormHoleLevel5")]
	public class WormHoleLevel5 : WormHoleCreatorBase {

		#region Fields

		private static readonly WormHoleLevel5 instance = new WormHoleLevel5();

		#endregion Fields

		#region Public

		public override int Cooldown{
            get { return 6; }
        }

		public override int Duration {
            get { return 5; }
		}

		public override object create(object args) {
			return instance;
		}

        public override bool CanPass(IPlayer owner, IPlayer playerToPass) {
            return
                owner.RaceInfo.Race == playerToPass.RaceInfo.Race &&
                playerToPass.PlanetLevel > 5 &&
                owner.Alliance != null && playerToPass.Alliance != null &&
                owner.Alliance.Storage.Id == playerToPass.Alliance.Storage.Id;
        }

		#endregion Public

        #region Contructor

        public WormHoleLevel5() {
            intrinsicResources = 1000;
            rareResources = 250;
        }

        #endregion Contructor
		
	}
}
