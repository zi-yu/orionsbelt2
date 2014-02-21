using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("BeaconLevel8")]
	public class BeaconLevel8 : BeaconCreatorBase {

		#region Fields

		private static readonly BeaconLevel8 instance = new BeaconLevel8();

		#endregion Fields

		#region Public

        public override bool LimitedToPlanetsSurroundings{
            get{return false;}
        }

        public override int Cooldown{
            get { return 3; }
        }

		public override int Duration {
			get { return 8; }
		}

		public override int VisibleArea {
			get { return 4; }
		}

		public override object create(object args) {
			return instance;
		}
	
		#endregion Public

        #region Contructor

        public BeaconLevel8() {
            intrinsicQuantity = 2400;
            rareQuantity = 480;
        }

        #endregion Contructor
		
	}
}
