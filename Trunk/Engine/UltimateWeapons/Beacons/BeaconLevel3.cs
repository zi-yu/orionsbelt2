using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("BeaconLevel3")]
	public class BeaconLevel3 : BeaconCreatorBase {

		#region Fields

		private static readonly BeaconLevel3 instance = new BeaconLevel3();

		#endregion Fields

		#region Public

        public override int Cooldown{
            get { return 8; }
        }

		public override int Duration {
			get { return 3; }
		}

		public override int VisibleArea {
			get { return 3; }
		}

		public override object create(object args) {
			return instance;
		}
	
		#endregion Public

        #region Contructor

        public BeaconLevel3() {
            intrinsicQuantity = 900;
            rareQuantity = 180;
        }

        #endregion Contructor
		
	}
}
