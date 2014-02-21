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
	public abstract class WormHoleCreatorBase : UltimateCreatorBase {

        #region Fields

        protected int intrinsicResources = 0;
        protected int rareResources = 0;

        #endregion Fields

        #region Private

        private void CreateEraseWormHoleAction(BugsWormHoleSector wormHole) {
			int ticks = GetTicks(Duration);
			EraseBugWormHole eraseBugWormHole = new EraseBugWormHole(wormHole.Storage.Id, ticks);
			eraseBugWormHole.PrepareStorage();
			eraseBugWormHole.UpdateStorage();
			ActionUtils.PersistAction(eraseBugWormHole.Storage);
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
            WormHoleCreatorArgs wormHoleCreatorArgs = (WormHoleCreatorArgs)args;
            SectorCoordinate coordinate = wormHoleCreatorArgs.Coordinate;
            ISector sector = Universe.Universe.GetSector(coordinate);

			if (sector is NormalSector) {
				if( IsVisible(args) ) {
					BugsWormHoleSector wormHole = new BugsWormHoleSector(args.Owner, coordinate, SectorUtils.GetLevel(coordinate.System));
	                
					args.Owner.UltimateWeaponCooldown = Cooldown;
					GameEngine.Persist(wormHole, false, true);
	                
					CreateEraseWormHoleAction(wormHole);

					Universe.Universe.ReplaceSector(wormHole);
				}else {
					Messenger.Add(new BeaconInTheSurroundingWormHole(args.Owner.Id));
					RefundUsage(args);
				}
            }else{
                RefundUsage(args);
            }
            GameEngine.Persist(args.Owner, false, false);
		}

        public override bool IsReady(IPlayer owner) {
            if (Server.IsInTests) {
                return true;
            }
            return
                owner.HasQuantity(Protol.Resource, intrinsicResources) &&
                owner.HasQuantity(Elk.Resource, intrinsicResources) &&
                owner.HasQuantity(Prismal.Resource, rareResources) &&
                owner.HasQuantity(Argon.Resource, rareResources) &&
                owner.HasQuantity(Astatine.Resource, rareResources) &&
                owner.HasQuantity(Cryptium.Resource, rareResources) &&
                owner.HasQuantity(Radon.Resource, rareResources);
        }

        public override void RefundUsage(IUltimateWeaponArgs args) {
            args.Owner.AddQuantity(Protol.Resource, intrinsicResources);
            args.Owner.AddQuantity(Elk.Resource, intrinsicResources);
            args.Owner.AddQuantity(Prismal.Resource, rareResources);
            args.Owner.AddQuantity(Argon.Resource, rareResources);
            args.Owner.AddQuantity(Astatine.Resource, rareResources);
            args.Owner.AddQuantity(Cryptium.Resource, rareResources);
            args.Owner.AddQuantity(Radon.Resource, rareResources);
            Messenger.Add(new WormHoleUltimateRefund(args.Owner.Id));
        }

        public override void ChargeUsage(IUltimateWeaponArgs args) {
            args.Owner.RemoveQuantity(Protol.Resource, intrinsicResources);
            args.Owner.RemoveQuantity(Elk.Resource, intrinsicResources);
            args.Owner.RemoveQuantity(Prismal.Resource, rareResources);
            args.Owner.RemoveQuantity(Argon.Resource, rareResources);
            args.Owner.RemoveQuantity(Astatine.Resource, rareResources);
            args.Owner.RemoveQuantity(Cryptium.Resource, rareResources);
            args.Owner.RemoveQuantity(Radon.Resource, rareResources);
        }

		#endregion UltimateCreatorBase Members

        #region Public

        public abstract bool CanPass(IPlayer owner, IPlayer playerToPass);

        #endregion Public
    }
}
