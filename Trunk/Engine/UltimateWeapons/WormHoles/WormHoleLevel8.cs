using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("WormHoleLevel8")]
	public class WormHoleLevel8 : WormHoleCreatorBase {

		#region Fields

		private static readonly WormHoleLevel8 instance = new WormHoleLevel8();

		#endregion Fields

		#region Public

        public override bool LimitedToPlanetsSurroundings {
            get { return false; }
        }

		public override int Cooldown{
            get { return 3; }
        }

        public override int Duration{
            get { return 8; }
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

        public WormHoleLevel8() {
            intrinsicResources = 1600;
            rareResources = 400;
        }

        #endregion Contructor
		
	}
}
