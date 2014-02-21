using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("WormHoleLevel10")]
	public class WormHoleLevel10 : WormHoleCreatorBase {

		#region Fields

		private static readonly WormHoleLevel10 instance = new WormHoleLevel10();

		#endregion Fields

		#region Public

        public override bool LimitedToPlanetsSurroundings {
            get { return false; }
        }

		public override int Cooldown{
            get { return 1; }
        }

        public override int Duration{
            get { return 10; }
        }

		public override object create(object args) {
			return instance;
		}
        public override bool CanPass(IPlayer owner, IPlayer playerToPass) {
            return
                playerToPass.PlanetLevel > 5 && 
                owner.Alliance != null && playerToPass.Alliance != null && owner.Alliance.Storage.Id == playerToPass.Alliance.Storage.Id;
        }


		#endregion Public

        #region Contructor

        public WormHoleLevel10() {
            intrinsicResources = 2000;
            rareResources = 500;
        }

        #endregion Contructor
		
	}
}
