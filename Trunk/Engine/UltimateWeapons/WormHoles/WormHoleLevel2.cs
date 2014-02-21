using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("WormHoleLevel2")]
	public class WormHoleLevel2 : WormHoleCreatorBase {

		#region Fields

		private static readonly WormHoleLevel2 instance = new WormHoleLevel2();

		#endregion Fields

		#region Public

		public override int Cooldown{
            get { return 9; }
        }

		public override int Duration {
            get { return 2; }
		}

		public override object create(object args) {
			return instance;
		}

        public override bool CanPass(IPlayer owner, IPlayer playerToPass) {
            return owner.Id == playerToPass.Id;
        }

		#endregion Public

        #region Contructor

        public WormHoleLevel2() {
            intrinsicResources = 400;
            rareResources = 100;
        }

        #endregion Contructor

		
	}
}
