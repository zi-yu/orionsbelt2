using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine {

	[FactoryKey("BeaconLevel0")]
	public class BeaconLevel0 : BeaconCreatorBase {

		#region Fields

		private static readonly BeaconLevel0 instance = new BeaconLevel0();

		#endregion Fields

		#region Public

        public override bool IsReady(IPlayer owner){
            return false;
        }

        public override int Cooldown{
            get { return 0; }
        }

		public override int Duration {
			get { return 0; }
		}

		public override object create(object args) {
			return instance;
		}

        public override void ChargeUsage(IUltimateWeaponArgs args){
            
        }

        public override void RefundUsage(IUltimateWeaponArgs args){
            
        }

		#endregion Public
		
	}
}
