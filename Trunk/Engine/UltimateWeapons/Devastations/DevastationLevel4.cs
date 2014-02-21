using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("DevastationLevel4")]
	public class DevastationLevel4 : DevastationCreatorBase {

		#region Fields

		private static readonly DevastationLevel4 instance = new DevastationLevel4();

		#endregion Fields

		#region Protected

        protected override void FireDevastation(SectorCoordinate coordinate, IPlayer owner) {
			MakeDamageOneSquare(coordinate, owner);
		}

		protected override int Percentage {
			get { return 36; }
		}

		#endregion Protected

		#region Public

		public override bool IsReady(IPlayer owner) {
			return
				owner.HasQuantity(Gold.Resource, 28000) &&
				owner.HasQuantity(Titanium.Resource, 28000) &&
				owner.HasQuantity(Uranium.Resource, 28000) &&
				owner.HasQuantity(Argon.Resource, 4000) &&
				owner.HasQuantity(Astatine.Resource, 4000) &&
				owner.HasQuantity(Cryptium.Resource, 4000) &&
				owner.HasQuantity(Prismal.Resource, 4000) &&
				owner.HasQuantity(Radon.Resource, 4000);
		}

		public override void ChargeUsage(IUltimateWeaponArgs args) {
			args.Owner.RemoveQuantity(Gold.Resource, 28000);
			args.Owner.RemoveQuantity(Titanium.Resource, 28000);
			args.Owner.RemoveQuantity(Uranium.Resource, 28000);
			args.Owner.RemoveQuantity(Argon.Resource, 4000);
			args.Owner.RemoveQuantity(Astatine.Resource, 4000);
			args.Owner.RemoveQuantity(Cryptium.Resource, 4000);
			args.Owner.RemoveQuantity(Prismal.Resource, 4000);
			args.Owner.RemoveQuantity(Radon.Resource, 4000);
		}

		public override void RefundUsage(IUltimateWeaponArgs args) {
			args.Owner.AddQuantity(Gold.Resource, 28000);
			args.Owner.AddQuantity(Titanium.Resource, 28000);
			args.Owner.AddQuantity(Uranium.Resource, 28000);
			args.Owner.AddQuantity(Argon.Resource, 4000);
			args.Owner.AddQuantity(Astatine.Resource, 4000);
			args.Owner.AddQuantity(Cryptium.Resource, 4000);
			args.Owner.AddQuantity(Prismal.Resource, 4000);
			args.Owner.AddQuantity(Radon.Resource, 4000);
		}


		public override int Cooldown{
            get { return 7; }
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
