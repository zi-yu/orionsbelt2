using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine {

	[FactoryKey("WormHoleLevel0")]
	public class WormHoleLevel0 : WormHoleCreatorBase {

		#region Fields

		private static readonly WormHoleLevel0 instance = new WormHoleLevel0();

		#endregion Fields

		#region Public

        public override bool IsReady(IPlayer owner){
            return false;
        }

		public override int Duration {
			get { return 0; }
		}

        public override int Cooldown{
            get { return -1; }
        }

		public override object create(object args) {
			return instance;
		}

        public override bool CanPass(IPlayer owner, IPlayer playerToPass) {
            return false;
        }

		public override void ChargeUsage(IUltimateWeaponArgs args) {
		}

		public override void RefundUsage(IUltimateWeaponArgs args) {
		}

		#endregion Public


		
	}
}
