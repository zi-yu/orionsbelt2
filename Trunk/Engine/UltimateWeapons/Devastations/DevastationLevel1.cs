using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("DevastationLevel1")]
	public class DevastationLevel1 : DevastationCreatorBase {

		#region Fields

		private static readonly DevastationLevel1 instance = new DevastationLevel1();

		#endregion Fields

		#region Protected

		protected override void FireDevastation(SectorCoordinate coordinate, IPlayer owner) {
			MakeDamageOneSquare(coordinate, owner);
		}

		protected override int Percentage {
			get { return 9; }
		}

		#endregion Protected

		#region Public

		public override bool IsReady(IPlayer owner) {
			return
				owner.HasQuantity(Gold.Resource, 7000) &&
				owner.HasQuantity(Titanium.Resource, 7000) &&
				owner.HasQuantity(Uranium.Resource, 7000) &&
				owner.HasQuantity(Argon.Resource, 1000) &&
				owner.HasQuantity(Astatine.Resource, 1000) &&
				owner.HasQuantity(Cryptium.Resource, 1000) &&
				owner.HasQuantity(Prismal.Resource, 1000) &&
				owner.HasQuantity(Radon.Resource, 1000);
		}

		public override void ChargeUsage(IUltimateWeaponArgs args) {
			args.Owner.RemoveQuantity(Gold.Resource, 7000);
			args.Owner.RemoveQuantity(Titanium.Resource, 7000);
			args.Owner.RemoveQuantity(Uranium.Resource, 7000);
			args.Owner.RemoveQuantity(Argon.Resource, 1000);
			args.Owner.RemoveQuantity(Astatine.Resource, 1000);
			args.Owner.RemoveQuantity(Cryptium.Resource, 1000);
			args.Owner.RemoveQuantity(Prismal.Resource, 1000);
			args.Owner.RemoveQuantity(Radon.Resource, 1000);
		}

		public override void RefundUsage(IUltimateWeaponArgs args) {
			args.Owner.AddQuantity(Gold.Resource, 7000);
			args.Owner.AddQuantity(Titanium.Resource, 7000);
			args.Owner.AddQuantity(Uranium.Resource, 7000);
			args.Owner.AddQuantity(Argon.Resource, 1000);
			args.Owner.AddQuantity(Astatine.Resource, 1000);
			args.Owner.AddQuantity(Cryptium.Resource, 1000);
			args.Owner.AddQuantity(Prismal.Resource, 1000);
			args.Owner.AddQuantity(Radon.Resource, 1000);
		}

		public override int Cooldown{
            get { return 10; }
        }

        public override int Duration{
            get { return 1; }
        }

		public override object create(object args) {
			return instance;
		}

		#endregion Public
		
	}
}
