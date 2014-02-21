using System;
using DesignPatterns.Attributes;
using OrionsBelt.Engine.Actions;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine {

	[NoAutoRegister]
	public abstract class BeaconCreatorBase : UltimateCreatorBase {

        #region Fields

        protected int intrinsicQuantity = 0;
        protected int rareQuantity = 0;

        #endregion Fields

        #region Private

        private void CreateEraseBeaconAction(BeaconSector beacon) {
			int ticks = Clock.Instance.ConvertToTicks(TimeSpan.FromDays(Duration));
			EraseBeacon eraseBeacon = new EraseBeacon(beacon.Storage.Id, ticks);
			eraseBeacon.PrepareStorage();
			eraseBeacon.UpdateStorage();
			ActionUtils.PersistAction(eraseBeacon.Storage);
		}

		#endregion Private

		#region UltimateCreatorBase Members

        public override bool LimitedToPlanetsSurroundings {
            get { return true; }
        }

		public override bool HasLimits {
			get { return LimitedToPlanetsSurroundings; }
		}

        public override void Use(IUltimateWeaponArgs args){
			BeaconCreatorArgs wormHoleCreatorArgs = (BeaconCreatorArgs)args;
			SectorCoordinate coordinate = wormHoleCreatorArgs.Coordinate;
			ISector sector = Universe.Universe.GetSector(coordinate);
			if (sector is NormalSector) {
				if (IsVisible(args)) {
					BeaconSector beacon =
						new BeaconSector(args.Owner, coordinate, SectorUtils.GetLevel(coordinate.System), VisibleArea);

					args.Owner.UltimateWeaponCooldown = Cooldown;
					GameEngine.Persist(beacon, false, true);

					CreateEraseBeaconAction(beacon);

					Universe.Universe.ReplaceSector(beacon);
				} else {
					Messenger.Add(new BeaconInTheSurroundingBeacon(args.Owner.Id));
					RefundUsage(args);
				}
			}else{
                RefundUsage(args);
			}
            GameEngine.Persist(args.Owner, false, false);
		}

		public virtual int VisibleArea {
			get { return 0; }
		}

        public override bool IsReady(IPlayer owner) {
            if (Server.IsInTests) {
                return true;
            }
            return owner.HasQuantity(Energy.Resource, intrinsicQuantity) &&
                owner.HasQuantity(Mithril.Resource, intrinsicQuantity) &&
                owner.HasQuantity(Serium.Resource, intrinsicQuantity) &&
                owner.HasQuantity(Prismal.Resource, rareQuantity) &&
                owner.HasQuantity(Argon.Resource, rareQuantity) &&
                owner.HasQuantity(Astatine.Resource, rareQuantity) &&
                owner.HasQuantity(Cryptium.Resource, rareQuantity) &&
                owner.HasQuantity(Radon.Resource, rareQuantity);
        }

        public override void ChargeUsage(IUltimateWeaponArgs args) {
            args.Owner.RemoveQuantity(Energy.Resource, intrinsicQuantity);
            args.Owner.RemoveQuantity(Mithril.Resource, intrinsicQuantity);
            args.Owner.RemoveQuantity(Serium.Resource, intrinsicQuantity);
            args.Owner.RemoveQuantity(Prismal.Resource, rareQuantity);
            args.Owner.RemoveQuantity(Argon.Resource, rareQuantity);
            args.Owner.RemoveQuantity(Astatine.Resource, rareQuantity);
            args.Owner.RemoveQuantity(Cryptium.Resource, rareQuantity);
            args.Owner.RemoveQuantity(Radon.Resource, rareQuantity);
        }

        public override void RefundUsage(IUltimateWeaponArgs args) {
            args.Owner.AddQuantity(Energy.Resource, intrinsicQuantity);
            args.Owner.AddQuantity(Mithril.Resource, intrinsicQuantity);
            args.Owner.AddQuantity(Serium.Resource, intrinsicQuantity);
            args.Owner.AddQuantity(Prismal.Resource, rareQuantity);
            args.Owner.AddQuantity(Argon.Resource, rareQuantity);
            args.Owner.AddQuantity(Astatine.Resource, rareQuantity);
            args.Owner.AddQuantity(Cryptium.Resource, rareQuantity);
            args.Owner.AddQuantity(Radon.Resource, rareQuantity);
            Messenger.Add(new BeaconUltimateRefund(args.Owner.Id));
        }

		#endregion IUltimateWeapon Members
	}
}
