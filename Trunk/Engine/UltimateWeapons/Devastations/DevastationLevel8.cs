using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("DevastationLevel8")]
	public class DevastationLevel8: DevastationCreatorBase {

		#region Fields

		private static readonly DevastationLevel8 instance = new DevastationLevel8();

		#endregion Fields

		#region Protected

		protected override void FireDevastation(SectorCoordinate coordinate, IPlayer owner) {
            MakeDamageAOE1(coordinate, owner);
		}

		protected override int Percentage {
			get { return 72; }
		}

		#endregion Protected

		#region Public

		public override bool IsReady(IPlayer owner) {
			return
				owner.HasQuantity(Gold.Resource, 65000) &&
				owner.HasQuantity(Titanium.Resource, 65000) &&
				owner.HasQuantity(Uranium.Resource, 65000) &&
				owner.HasQuantity(Argon.Resource, 10000) &&
				owner.HasQuantity(Astatine.Resource, 10000) &&
				owner.HasQuantity(Cryptium.Resource, 10000) &&
				owner.HasQuantity(Prismal.Resource, 10000) &&
				owner.HasQuantity(Radon.Resource, 10000);
		}

		public override void ChargeUsage(IUltimateWeaponArgs args) {
			args.Owner.RemoveQuantity(Gold.Resource, 65000);
			args.Owner.RemoveQuantity(Titanium.Resource, 65000);
			args.Owner.RemoveQuantity(Uranium.Resource, 65000);
			args.Owner.RemoveQuantity(Argon.Resource, 10000);
			args.Owner.RemoveQuantity(Astatine.Resource, 10000);
			args.Owner.RemoveQuantity(Cryptium.Resource, 10000);
			args.Owner.RemoveQuantity(Prismal.Resource, 10000);
			args.Owner.RemoveQuantity(Radon.Resource, 10000);
		}

		public override void RefundUsage(IUltimateWeaponArgs args) {
			args.Owner.AddQuantity(Gold.Resource, 65000);
			args.Owner.AddQuantity(Titanium.Resource, 65000);
			args.Owner.AddQuantity(Uranium.Resource, 65000);
			args.Owner.AddQuantity(Argon.Resource, 10000);
			args.Owner.AddQuantity(Astatine.Resource, 10000);
			args.Owner.AddQuantity(Cryptium.Resource, 10000);
			args.Owner.AddQuantity(Prismal.Resource, 10000);
			args.Owner.AddQuantity(Radon.Resource, 10000);
		}


		public override int Cooldown{
            get { return 3; }
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
