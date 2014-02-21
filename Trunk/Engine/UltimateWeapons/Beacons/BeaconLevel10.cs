using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("BeaconLevel10")]
	public class BeaconLevel10 : BeaconCreatorBase {

		#region Fields

		private static readonly BeaconLevel10 instance = new BeaconLevel10();

		#endregion Fields

		#region Public

        public override bool LimitedToPlanetsSurroundings {
            get { return false; }
        }

        public override int Cooldown{
            get { return 1; }
        }

		public override int Duration {
			get { return 10; }
		}

		public override int VisibleArea {
			get { return 5; }
		}

		public override object create(object args) {
			return instance;
		}
	
		#endregion Public

        #region Contructor

        public BeaconLevel10() {
            intrinsicQuantity = 3000;
            rareQuantity = 600;
        }

        #endregion Contructor
		
	}
}
