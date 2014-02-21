using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("WormHoleLevel9")]
	public class WormHoleLevel9 : WormHoleCreatorBase {

		#region Fields

		private static readonly WormHoleLevel9 instance = new WormHoleLevel9();

		#endregion Fields

		#region Public

        public override bool LimitedToPlanetsSurroundings {
            get { return false; }
        }

		public override int Cooldown{
            get { return 2; }
        }

        public override int Duration{
            get { return 9; }
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

        public WormHoleLevel9() {
            intrinsicResources = 1800;
            rareResources = 450;
        }

        #endregion Contructor
		
	}
}
