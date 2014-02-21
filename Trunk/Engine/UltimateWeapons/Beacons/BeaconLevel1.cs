using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("BeaconLevel1")]
	public class BeaconLevel1 : BeaconCreatorBase {

		#region Fields

		private static readonly BeaconLevel1 instance = new BeaconLevel1();

		#endregion Fields

		#region Public

        public override int Cooldown{
            get { return 10; }
        }

		public override int Duration {
			get { return 1; }
		}

		public override int VisibleArea {
			get { return 2; }
		}

		public override object create(object args) {
			return instance;
		}

	
		#endregion Public

        #region Contructor

        public BeaconLevel1() {
            intrinsicQuantity = 300;
            rareQuantity = 60;
        }

        #endregion Contructor

    }
}
