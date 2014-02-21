using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("WormHoleLevel3")]
	public class WormHoleLevel3 : WormHoleCreatorBase {

		#region Fields

		private static readonly WormHoleLevel3 instance = new WormHoleLevel3();

		#endregion Fields

		#region Public

		public override int Cooldown{
            get { return 8; }
        }

		public override int Duration {
            get { return 3; }
		}

		public override object create(object args) {
			return instance;
		}

        public override bool CanPass(IPlayer owner, IPlayer playerToPass) {
            return owner.Id == playerToPass.Id;
        }

		#endregion Public

        #region Contructor

        public WormHoleLevel3() {
            intrinsicResources = 600;
            rareResources = 150;
        }

        #endregion Contructor
		
	}
}
