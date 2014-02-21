using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("DevastationLevel7")]
	public class DevastationLevel7 : DevastationCreatorBase {

		#region Fields

		private static readonly DevastationLevel7 instance = new DevastationLevel7();

		#endregion Fields

		#region Protected

        protected override void FireDevastation(SectorCoordinate coordinate, IPlayer owner) {
			MakeDamageAOE1(coordinate, owner);
		}

		protected override int Percentage {
			get { return 63; }
		}

		#endregion Protected

		#region Public

		public override bool IsReady(IPlayer owner) {
			return
				owner.HasQuantity(Gold.Resource, 49000) &&
				owner.HasQuantity(Titanium.Resource, 49000) &&
				owner.HasQuantity(Uranium.Resource, 49000) &&
				owner.HasQuantity(Argon.Resource, 7000) &&
				owner.HasQuantity(Astatine.Resource, 7000) &&
				owner.HasQuantity(Cryptium.Resource, 7000) &&
				owner.HasQuantity(Prismal.Resource, 7000) &&
				owner.HasQuantity(Radon.Resource, 7000);
		}

		public override void ChargeUsage(IUltimateWeaponArgs args) {
			args.Owner.RemoveQuantity(Gold.Resource, 49000);
			args.Owner.RemoveQuantity(Titanium.Resource, 49000);
			args.Owner.RemoveQuantity(Uranium.Resource, 49000);
			args.Owner.RemoveQuantity(Argon.Resource, 7000);
			args.Owner.RemoveQuantity(Astatine.Resource, 7000);
			args.Owner.RemoveQuantity(Cryptium.Resource, 7000);
			args.Owner.RemoveQuantity(Prismal.Resource, 7000);
			args.Owner.RemoveQuantity(Radon.Resource, 7000);
		}

		public override void RefundUsage(IUltimateWeaponArgs args) {
			args.Owner.AddQuantity(Gold.Resource, 49000);
			args.Owner.AddQuantity(Titanium.Resource, 49000);
			args.Owner.AddQuantity(Uranium.Resource, 49000);
			args.Owner.AddQuantity(Argon.Resource, 7000);
			args.Owner.AddQuantity(Astatine.Resource, 7000);
			args.Owner.AddQuantity(Cryptium.Resource, 7000);
			args.Owner.AddQuantity(Prismal.Resource, 7000);
			args.Owner.AddQuantity(Radon.Resource, 7000);
		}


		public override int Cooldown{
            get { return 4; }
        }

        public override int Duration{
            get { return 3; }
        }

		public override object create(object args) {
			return instance;
		}

		#endregion Public
		
	}
}
