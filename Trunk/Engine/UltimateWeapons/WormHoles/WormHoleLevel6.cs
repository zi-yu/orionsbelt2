using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("WormHoleLevel6")]
	public class WormHoleLevel6 : WormHoleCreatorBase {

		#region Fields

		private static readonly WormHoleLevel6 instance = new WormHoleLevel6();

		#endregion Fields

		#region Public

        public override bool LimitedToPlanetsSurroundings {
            get { return false; }
        }

        public override int Cooldown{
            get { return 5; }
        }

        public override int Duration{
            get { return 6; }
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

        public WormHoleLevel6() {
            intrinsicResources = 1200;
            rareResources = 300;
        }

        #endregion Contructor
		
	}
}
