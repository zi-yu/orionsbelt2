using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("BeaconLevel4")]
	public class BeaconLevel4 : BeaconCreatorBase {

		#region Fields

		private static readonly BeaconLevel4 instance = new BeaconLevel4();

		#endregion Fields

		#region Public

        public override int Cooldown{
            get { return 7; }
        }

		public override int Duration {
			get { return 4; }
		}

		public override int VisibleArea {
			get { return 3; }
		}

		public override object create(object args) {
			return instance;
		}
	
		#endregion Public

        #region Contructor

        public BeaconLevel4() {
            intrinsicQuantity = 1200;
            rareQuantity = 240;
        }

        #endregion Contructor
		
	}
}
