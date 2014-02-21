using OrionsBelt.BattleCore;
using OrionsBelt.Core;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {
    public static class FleetConversion {

		#region Private

		private static bool HasUltimateUnit(Fleet storage) {
			return storage.UltimateUnit != null && storage.UltimateUnit.Length > 0;
		}

        #endregion Private

        #region Public

        /// <summary>
        /// Converts a IFleetInfo to a Fleet Storage
        /// </summary>
        /// <param name="fleetInfo">Fleet to convert</param>
        public static void ConvertToStorage( IFleetInfo fleetInfo ){
            Fleet fleetStorage = fleetInfo.Storage;

			if (fleetInfo.HasUltimateUnit){
				fleetStorage.UltimateUnit = fleetInfo.UltimateUnit.Code;
			}
            fleetStorage.IsInBattle = fleetInfo.IsInBattle;
            fleetStorage.IsMovable = fleetInfo.Movable;
            fleetStorage.Units = fleetInfo.ToString();
            fleetStorage.TournamentFleet = fleetInfo.TournamentFleet;
            fleetStorage.IsPlanetDefenseFleet = fleetInfo.IsPlanetDefenseFleet;
            fleetStorage.Name = fleetInfo.Name;
            fleetStorage.SystemX = fleetInfo.Location.System.X;
            fleetStorage.SystemY = fleetInfo.Location.System.Y;
            fleetStorage.SectorX = fleetInfo.Location.Sector.X;
            fleetStorage.SectorY = fleetInfo.Location.Sector.Y;
			fleetStorage.IsBot = fleetInfo.IsBot;
            fleetStorage.WayPoints = SectorUtils.ConvertWaypoints(fleetInfo.WayPoints);
            fleetStorage.ImmunityStartTick = fleetInfo.ImmunityStartTick;
            
            if (fleetInfo.Cargo != null && fleetInfo.Cargo.Count > 0){
                fleetStorage.Cargo = PlanetConversion.ModifiersRepresentation(fleetInfo.Cargo);
            }else {
				fleetStorage.Cargo = string.Empty;
            }

			if (fleetInfo.HasLoadedOwner && fleetInfo.Owner != null) {
                fleetStorage.PlayerOwner = fleetInfo.Owner.Storage;
            }

            if (fleetInfo.CurrentPlanet != null){
                fleetStorage.CurrentPlanet = fleetInfo.CurrentPlanet.Storage;
            }

			if ( fleetInfo.HasLoadedSector && fleetInfo.Sector != null) {
                fleetStorage.Sector = fleetInfo.Sector.Storage;
            }

            fleetInfo.IsDirty = false;
        }

        public static void ConvertFromStorage(IFleetInfo fleetInfo, Fleet storage, IPlayer owner){
            fleetInfo.Id = storage.Id;
            fleetInfo.Name = storage.Name;
            fleetInfo.TournamentFleet = storage.TournamentFleet;
            fleetInfo.Movable = storage.IsMovable;
			if (HasUltimateUnit(storage)) {
				fleetInfo.UltimateUnit = Unit.Create(storage.UltimateUnit);
			}
            fleetInfo.IsPlanetDefenseFleet = storage.IsPlanetDefenseFleet;
			fleetInfo.IsInBattle = storage.IsInBattle;
			fleetInfo.Owner = owner;
            fleetInfo.Storage = storage;
            fleetInfo.WayPoints = SectorUtils.ConvertWaypoints(storage.WayPoints);
			
            fleetInfo.Location = new SectorCoordinate(storage.SystemX, storage.SystemY, storage.SectorX, storage.SectorY);
        	fleetInfo.IsBot = storage.IsBot;
            fleetInfo.ImmunityStartTick = storage.ImmunityStartTick;

            if( !string.IsNullOrEmpty(storage.Cargo) ) {
                fleetInfo.Cargo = PlanetConversion.ParseModifiers(storage.Cargo);
            }
        	fleetInfo.IsDirty = false;
        }

        public static void ConvertFromStorage(IFleetInfo fleetInfo, Fleet storage){
            fleetInfo.Id = storage.Id;
            fleetInfo.Name = storage.Name;
            fleetInfo.TournamentFleet = storage.TournamentFleet;
            fleetInfo.Movable = storage.IsMovable;
			if ( HasUltimateUnit(storage) ) {
				fleetInfo.UltimateUnit = Unit.Create(storage.UltimateUnit);
			}
			fleetInfo.IsPlanetDefenseFleet = storage.IsPlanetDefenseFleet;
        	fleetInfo.IsInBattle = storage.IsInBattle;
			if (storage.PrincipalOwner != null) {
                fleetInfo.PrincipalOwner = storage.PrincipalOwner;
			}
            fleetInfo.Storage = storage;
            fleetInfo.Location = new SectorCoordinate(storage.SystemX, storage.SystemY, storage.SectorX, storage.SectorY);
        	fleetInfo.IsBot = storage.IsBot;
            fleetInfo.WayPoints = SectorUtils.ConvertWaypoints(storage.WayPoints);
            fleetInfo.ImmunityStartTick = storage.ImmunityStartTick;

            if( !string.IsNullOrEmpty(storage.Cargo) ) {
                fleetInfo.Cargo = PlanetConversion.ParseModifiers(storage.Cargo);
            }
			fleetInfo.IsDirty = false;
        }

        #endregion Public


    }
}
