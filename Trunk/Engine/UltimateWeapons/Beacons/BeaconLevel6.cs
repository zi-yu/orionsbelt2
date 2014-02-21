using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("BeaconLevel6")]
	public class BeaconLevel6 : BeaconCreatorBase {

		#region Fields

		private static readonly BeaconLevel6 instance = new BeaconLevel6();

		#endregion Fields

		#region Public

        public override int Cooldown{
            get { return 5; }
        }

		public override int Duration {
			get { return 6; }
		}

		public override int VisibleArea {
			get { return 3; }
		}

		public override object create(object args) {
			return instance;
		}
	
		#endregion Public

        #region Contructor

        public BeaconLevel6() {
            intrinsicQuantity = 1800;
            rareQuantity = 360;
        }

        #endregion Contructor
		
	}
}
