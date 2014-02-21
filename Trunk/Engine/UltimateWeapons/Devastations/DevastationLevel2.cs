using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("DevastationLevel2")]
	public class DevastationLevel2 : DevastationCreatorBase {

		#region Fields

		private static readonly DevastationLevel2 instance = new DevastationLevel2();

		#endregion Fields

		#region Protected

        protected override void FireDevastation(SectorCoordinate coordinate, IPlayer owner) {
			MakeDamageOneSquare(coordinate, owner);
		}

		protected override int Percentage {
			get { return 18; }
		}

		#endregion Protected

		#region Public

		public override bool IsReady(IPlayer owner) {
			return
				owner.HasQuantity(Gold.Resource, 14000) &&
				owner.HasQuantity(Titanium.Resource, 14000) &&
				owner.HasQuantity(Uranium.Resource, 14000) &&
				owner.HasQuantity(Argon.Resource, 2000) &&
				owner.HasQuantity(Astatine.Resource, 2000) &&
				owner.HasQuantity(Cryptium.Resource, 2000) &&
				owner.HasQuantity(Prismal.Resource, 2000) &&
				owner.HasQuantity(Radon.Resource, 2000);
		}

		public override void ChargeUsage(IUltimateWeaponArgs args) {
			args.Owner.RemoveQuantity(Gold.Resource, 14000);
			args.Owner.RemoveQuantity(Titanium.Resource, 14000);
			args.Owner.RemoveQuantity(Uranium.Resource, 14000);
			args.Owner.RemoveQuantity(Argon.Resource, 2000);
			args.Owner.RemoveQuantity(Astatine.Resource, 2000);
			args.Owner.RemoveQuantity(Cryptium.Resource, 2000);
			args.Owner.RemoveQuantity(Prismal.Resource, 2000);
			args.Owner.RemoveQuantity(Radon.Resource, 2000);
		}

		public override void RefundUsage(IUltimateWeaponArgs args) {
			args.Owner.AddQuantity(Gold.Resource, 14000);
			args.Owner.AddQuantity(Titanium.Resource, 14000);
			args.Owner.AddQuantity(Uranium.Resource, 14000);
			args.Owner.AddQuantity(Argon.Resource, 2000);
			args.Owner.AddQuantity(Astatine.Resource, 2000);
			args.Owner.AddQuantity(Cryptium.Resource, 2000);
			args.Owner.AddQuantity(Prismal.Resource, 2000);
			args.Owner.AddQuantity(Radon.Resource, 2000);
		}

		public override int Cooldown{
            get { return 9; }
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
