using DesignPatterns.Attributes;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("BeaconLevel7")]
	public class BeaconLevel7 : BeaconCreatorBase {

		#region Fields

		private static readonly BeaconLevel7 instance = new BeaconLevel7();

		#endregion Fields

		#region Public

        public override bool LimitedToPlanetsSurroundings{
            get{return false;}
        }

        public override int Cooldown{
            get { return 4; }
        }

		public override int Duration {
			get { return 7; }
		}

		public override int VisibleArea {
			get { return 4; }
		}

		public override object create(object args) {
			return instance;
		}
	
		#endregion Public

        #region Contructor

        public BeaconLevel7() {
            intrinsicQuantity = 2100;
            rareQuantity = 420;
        }

        #endregion Contructor
		
	}
}
