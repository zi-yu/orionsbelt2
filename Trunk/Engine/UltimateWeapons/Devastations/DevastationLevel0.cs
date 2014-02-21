using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine {

	[FactoryKey("DevastationLevel0")]
	public class DevastationLevel0 : DevastationCreatorBase {

		#region Fields

		private static readonly DevastationLevel0 instance = new DevastationLevel0();

		#endregion Fields

		#region Protected

        protected override void FireDevastation(SectorCoordinate coordinate, IPlayer owner)
        {
			
		}

		protected override int Percentage {
			get { return 0; }
		}

		#endregion Protected

		#region Public

		public override bool IsReady(IPlayer owner){
            return false;
        }

		public override void ChargeUsage(IUltimateWeaponArgs args) {
		}

		public override void RefundUsage(IUltimateWeaponArgs args) {
		}

		public override int Cooldown{
            get { return 0; }
        }

        public override int Duration{
            get { return 0; }
        }

		public override object create(object args) {
			return instance;
		}

		#endregion Public

	}
}
