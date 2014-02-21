using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("WormHoleLevel4")]
	public class WormHoleLevel4 : WormHoleCreatorBase {

		#region Fields

		private static readonly WormHoleLevel4 instance = new WormHoleLevel4();

		#endregion Fields

		#region Public

		public override int Cooldown{
            get { return 7; }
        }

		public override int Duration {
            get { return 4; }
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

        public WormHoleLevel4() {
            intrinsicResources = 800;
            rareResources = 200;
        }

        #endregion Contructor
		
	}
}
