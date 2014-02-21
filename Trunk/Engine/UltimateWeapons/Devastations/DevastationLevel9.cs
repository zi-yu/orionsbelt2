using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[FactoryKey("DevastationLevel9")]
	public class DevastationLevel9 : DevastationCreatorBase {

		#region Fields

		private static readonly DevastationLevel9 instance = new DevastationLevel9();

		#endregion Fields

		#region Protected

        protected override void FireDevastation(SectorCoordinate coordinate, IPlayer owner) {
			MakeDamageAOE1(coordinate, owner);
		}

		protected override int Percentage {
			get { return 81; }
		}

		#endregion Protected

		#region Public

		public override bool IsReady(IPlayer owner) {
			return
				owner.HasQuantity(Gold.Resource, 75000) &&
				owner.HasQuantity(Titanium.Resource, 75000) &&
				owner.HasQuantity(Uranium.Resource, 75000) &&
				owner.HasQuantity(Argon.Resource, 15000) &&
				owner.HasQuantity(Astatine.Resource, 15000) &&
				owner.HasQuantity(Cryptium.Resource, 15000) &&
				owner.HasQuantity(Prismal.Resource, 15000) &&
				owner.HasQuantity(Radon.Resource, 15000);
		}

		public override void ChargeUsage(IUltimateWeaponArgs args) {
			args.Owner.RemoveQuantity(Gold.Resource, 75000);
			args.Owner.RemoveQuantity(Titanium.Resource, 75000);
			args.Owner.RemoveQuantity(Uranium.Resource, 75000);
			args.Owner.RemoveQuantity(Argon.Resource, 15000);
			args.Owner.RemoveQuantity(Astatine.Resource, 15000);
			args.Owner.RemoveQuantity(Cryptium.Resource, 15000);
			args.Owner.RemoveQuantity(Prismal.Resource, 15000);
			args.Owner.RemoveQuantity(Radon.Resource, 15000);
		}

		public override void RefundUsage(IUltimateWeaponArgs args) {
			args.Owner.AddQuantity(Gold.Resource, 75000);
			args.Owner.AddQuantity(Titanium.Resource, 75000);
			args.Owner.AddQuantity(Uranium.Resource, 75000);
			args.Owner.AddQuantity(Argon.Resource, 15000);
			args.Owner.AddQuantity(Astatine.Resource, 15000);
			args.Owner.AddQuantity(Cryptium.Resource, 15000);
			args.Owner.AddQuantity(Prismal.Resource, 15000);
			args.Owner.AddQuantity(Radon.Resource, 15000);
		}


		public override int Cooldown{
            get { return 2; }
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
