using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("BeaconLevel5")]
	public class BeaconLevel5 : BeaconCreatorBase {

		#region Fields

		private static readonly BeaconLevel5 instance = new BeaconLevel5();

		#endregion Fields

		#region Public

        public override int Cooldown{
            get { return 6; }
        }

		public override int Duration {
			get { return 5; }
		}

		public override int VisibleArea {
			get { return 3; }
		}

		public override object create(object args) {
			return instance;
		}
	
		#endregion Public

        #region Contructor

        public BeaconLevel5() {
            intrinsicQuantity = 1500;
            rareQuantity = 300;
        }

        #endregion Contructor
		
	}
}
