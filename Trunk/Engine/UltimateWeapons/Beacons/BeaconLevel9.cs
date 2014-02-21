using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("BeaconLevel9")]
	public class BeaconLevel9 : BeaconCreatorBase {

		#region Fields

		private static readonly BeaconLevel9 instance = new BeaconLevel9();

		#endregion Fields

		#region Public

        public override bool LimitedToPlanetsSurroundings{
            get{return false;}
        }

        public override int Cooldown{
            get { return 2; }
        }

		public override int Duration {
			get { return 9; }
		}

		public override int VisibleArea {
			get { return 4; }
		}

		public override object create(object args) {
			return instance;
		}
	
		#endregion Public

        #region Contructor

        public BeaconLevel9() {
            intrinsicQuantity = 2700;
            rareQuantity = 540;
        }

        #endregion Contructor
		
	}
}
