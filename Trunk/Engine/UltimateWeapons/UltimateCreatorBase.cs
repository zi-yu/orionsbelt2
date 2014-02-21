using System.Collections.Generic;
using DesignPatterns;
using DesignPatterns.Attributes;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using System;

namespace OrionsBelt.Engine {

	[NoAutoRegister]
	public abstract class UltimateCreatorBase : IUltimateWeapon, IFactory {

        #region Protected

        protected static int GetTicks(int days) {
            return Clock.Instance.ConvertToTicks(TimeSpan.FromDays(days));
        }

		protected static bool IsVisible(IUltimateWeaponArgs args) {
            List<SectorCoordinate> coordinates = SectorUtils.GetAllPossibleCoordinates(args.Coordinate, 10);
			List<ISector> sectors = Universe.Universe.GetSectors(coordinates, args.Owner);
			SectorInformationContainer container = UniverseUtils.GetSectorInformationContainer(sectors, args.Owner, true);
			SectorInformation info = container.Get(args.Coordinate);
            //return info != null && !(info.Visibility is OtherBeaconVisible && info.Level > args.Owner.UltimateWeaponLevel); ter em conta o nível da outra ultimate
            return info != null && !(info.Visibility is OtherBeaconVisible || info.Visibility is BeaconVisible);
		}

        #endregion Protected

        #region IUltimateWeapon Members

        public abstract int Duration { get; }

        public abstract int Cooldown { get; }

        public abstract bool LimitedToPlanetsSurroundings { get; }

        public abstract void Use(IUltimateWeaponArgs args);

        public abstract void ChargeUsage(IUltimateWeaponArgs args);

        public abstract void RefundUsage(IUltimateWeaponArgs args);

        public abstract bool IsReady(IPlayer owner);

		public abstract bool HasLimits { get; }

        #endregion IUltimateWeapon Members

        #region IFactory Members

        public abstract object create(object args);

		#endregion IFactory Members

    }
}
