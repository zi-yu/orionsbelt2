using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("BeaconLevel2")]
	public class BeaconLevel2 : BeaconCreatorBase {

		#region Fields

		private static readonly BeaconLevel2 instance = new BeaconLevel2();

		#endregion Fields

		#region Public

        public override int Cooldown{
            get { return 9; }
        }

		public override int Duration {
			get { return 2; }
		}

		public override int VisibleArea {
			get { return 2; }
		}

		public override object create(object args) {
			return instance;
		}
	
		#endregion Public

        #region Contructor

        public BeaconLevel2() {
            intrinsicQuantity = 600;
            rareQuantity = 120;
        }

        #endregion Contructor
		
	}
}
