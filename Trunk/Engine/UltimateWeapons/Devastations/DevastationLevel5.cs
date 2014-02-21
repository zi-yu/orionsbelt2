using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("DevastationLevel5")]
	public class DevastationLevel5 : DevastationCreatorBase {

		#region Fields

		private static readonly DevastationLevel5 instance = new DevastationLevel5();

		#endregion Fields

		#region Protected

        protected override void FireDevastation(SectorCoordinate coordinate, IPlayer owner) {
			MakeDamageOneSquare(coordinate, owner);
		}

		protected override int Percentage {
			get { return 45; }
		}

		#endregion Protected

		#region Public

		public override bool IsReady(IPlayer owner) {
			return
				owner.HasQuantity(Gold.Resource, 35000) &&
				owner.HasQuantity(Titanium.Resource, 35000) &&
				owner.HasQuantity(Uranium.Resource, 35000) &&
				owner.HasQuantity(Argon.Resource, 5000) &&
				owner.HasQuantity(Astatine.Resource, 5000) &&
				owner.HasQuantity(Cryptium.Resource, 5000) &&
				owner.HasQuantity(Prismal.Resource, 5000) &&
				owner.HasQuantity(Radon.Resource, 5000);
		}

		public override void ChargeUsage(IUltimateWeaponArgs args) {
			args.Owner.RemoveQuantity(Gold.Resource, 35000);
			args.Owner.RemoveQuantity(Titanium.Resource, 35000);
			args.Owner.RemoveQuantity(Uranium.Resource, 35000);
			args.Owner.RemoveQuantity(Argon.Resource, 5000);
			args.Owner.RemoveQuantity(Astatine.Resource, 5000);
			args.Owner.RemoveQuantity(Cryptium.Resource, 5000);
			args.Owner.RemoveQuantity(Prismal.Resource, 5000);
			args.Owner.RemoveQuantity(Radon.Resource, 5000);
		}

		public override void RefundUsage(IUltimateWeaponArgs args) {
			args.Owner.AddQuantity(Gold.Resource, 35000);
			args.Owner.AddQuantity(Titanium.Resource, 35000);
			args.Owner.AddQuantity(Uranium.Resource, 35000);
			args.Owner.AddQuantity(Argon.Resource, 5000);
			args.Owner.AddQuantity(Astatine.Resource, 5000);
			args.Owner.AddQuantity(Cryptium.Resource, 5000);
			args.Owner.AddQuantity(Prismal.Resource, 5000);
			args.Owner.AddQuantity(Radon.Resource, 5000);
		}


		public override int Cooldown{
            get { return 6; }
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
