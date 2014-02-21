using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("DevastationLevel10")]
	public class DevastationLevel10 : DevastationCreatorBase {

		#region Fields

		private static readonly DevastationLevel10 instance = new DevastationLevel10();

		#endregion Fields

		#region Protected

        protected override void FireDevastation(SectorCoordinate coordinate, IPlayer owner) {
			MakeDamageAOE2(coordinate, owner);
		}

		protected override int Percentage {
			get { return 90; }
		}

		#endregion Protected

		#region Public

		public override bool IsReady(IPlayer owner) {
			return
				owner.HasQuantity(Gold.Resource, 90000) &&
				owner.HasQuantity(Titanium.Resource, 90000) &&
				owner.HasQuantity(Uranium.Resource, 90000) &&
				owner.HasQuantity(Argon.Resource, 20000) &&
				owner.HasQuantity(Astatine.Resource, 20000) &&
				owner.HasQuantity(Cryptium.Resource, 20000) &&
				owner.HasQuantity(Prismal.Resource, 30000) &&
				owner.HasQuantity(Radon.Resource, 30000);
		}

		public override void ChargeUsage(IUltimateWeaponArgs args) {
			args.Owner.RemoveQuantity(Gold.Resource, 90000);
			args.Owner.RemoveQuantity(Titanium.Resource, 90000);
			args.Owner.RemoveQuantity(Uranium.Resource, 90000);
			args.Owner.RemoveQuantity(Argon.Resource, 20000);
			args.Owner.RemoveQuantity(Astatine.Resource, 20000);
			args.Owner.RemoveQuantity(Cryptium.Resource, 20000);
			args.Owner.RemoveQuantity(Prismal.Resource, 20000);
			args.Owner.RemoveQuantity(Radon.Resource, 20000);
		}

		public override void RefundUsage(IUltimateWeaponArgs args) {
			args.Owner.AddQuantity(Gold.Resource, 90000);
			args.Owner.AddQuantity(Titanium.Resource, 90000);
			args.Owner.AddQuantity(Uranium.Resource, 90000);
			args.Owner.AddQuantity(Argon.Resource, 20000);
			args.Owner.AddQuantity(Astatine.Resource, 20000);
			args.Owner.AddQuantity(Cryptium.Resource, 20000);
			args.Owner.AddQuantity(Prismal.Resource, 20000);
			args.Owner.AddQuantity(Radon.Resource, 20000);
		}


		public override int Cooldown{
            get { return 1; }
        }

        public override int Duration{
            get { return 5; }
        }

		public override object create(object args) {
			return instance;
		}

		#endregion Public
		
	}
}
