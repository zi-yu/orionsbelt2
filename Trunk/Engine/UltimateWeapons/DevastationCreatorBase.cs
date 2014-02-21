using System.Collections.Generic;
using DesignPatterns.Attributes;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Actions;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.Generic.Log;

namespace OrionsBelt.Engine {

	[NoAutoRegister]
	public abstract class DevastationCreatorBase : UltimateCreatorBase {

		#region Fields

		private int totalUnitsDestroyed = 0;

		#endregion Fields

		#region Private

		private int GiveDamage(IFleetInfo info) {
            int partialTotalUnitsDestroyed = 0;
			List<IFleetElement> temp = new List<IFleetElement>(info.Units.Values);
			foreach( IFleetElement unit in temp ) {
				if( unit.Quantity == 1 ) {
					info.Remove(unit.Name,unit.Quantity);
                    partialTotalUnitsDestroyed += 1;
				}else{
					float q = (unit.Quantity * Percentage) / 100;
                    partialTotalUnitsDestroyed += (int)q;
					info.Update(unit.UnitInfo,unit.Quantity - (int)q);
				}
			}
			info.Touch();
		    return partialTotalUnitsDestroyed;
		}

        private void MakeDamage(ISector sector, IPlayer owner) {
			IEnumerable<IFleetInfo> fleets = sector.GetFleets();
			foreach (IFleetInfo info in fleets) {
				if (info != null && !info.IsInBattle && info.Owner != null) {
				    int partialTotalUnitsDestroyed = GiveDamage(info);
                    Logger.Info(owner.Name, "Devastation attack Fired at coordinate {0}. Target: {1}. Fleet: {3} Damage: {2} units", LogType.Ultimate, sector.Coordinate, info.Owner.Name, partialTotalUnitsDestroyed, info.Name);
					if( info.HasUnits ) {
						GameEngine.Persist(info);
                        Messenger.Add(new DevastationAttackDamage(info.Owner.Id, info.Name, partialTotalUnitsDestroyed, info.Location));
					}else {
                        Messenger.Add(new DevastationAttackDestroyFleet(info.Owner.Id, info.Name, partialTotalUnitsDestroyed, info.Location.ToString()));
                        if (!info.IsPlanetDefenseFleet) {
                            FleetPersistance.DeleteFleet(info);
                            Logger.Info(owner.Name, "Devastation attack Fired deleted a fleet in coordinate {0}.", LogType.Ultimate, sector.Coordinate);
                        }
					}
				    totalUnitsDestroyed += partialTotalUnitsDestroyed;
				}
			}
		}

		private void MakeDamageAOE(SectorCoordinate coordinate, int distance, IPlayer owner) {
            List<SectorCoordinate> coordinates = SectorUtils.GetAllPossibleCoordinates(coordinate, distance);
			List<ISector> sectors = Universe.Universe.GetSectors(coordinates);

            List<SectorCoordinate> coordinatesForVisibility = SectorUtils.GetAllPossibleCoordinates(coordinate, 10);
            List<ISector> sectorsForVisibility = Universe.Universe.GetSectors(coordinatesForVisibility, owner);
            SectorInformationContainer container = UniverseUtils.GetSectorInformationContainer(sectorsForVisibility, owner, true);
            
            Logger.Info(owner.Name, "Devastation attack AOE Fired at coordinate {0}", LogType.Ultimate, coordinate );

			foreach (ISector sector in sectors) {
                if( sector.Owner != null ) {
                    SectorInformation info = container.Get(sector.Coordinate);
                    if(info != null && !(info.Visibility is OtherBeaconVisible || info.Visibility is BeaconVisible)) {
                        MakeDamage(sector, owner);
                    } else {
                        Logger.Info(owner.Name, "Devastation attack Fired at coordinate {0}. Coordinate protected by beacon", LogType.Ultimate, sector.Coordinate );
                        Messenger.Add(new BeaconInTheSurroundingDevastationCoordinate(owner.Id, info.Coordinate));
                    }
                }
			}
		}

		private void UpdateOwner(IPlayer owner, SectorCoordinate coordinate) {
			Messenger.Add(new DevastationAttackResult(owner.Id, coordinate, totalUnitsDestroyed));
			owner.UltimateWeaponCooldown = Cooldown;
			GameEngine.Persist(owner, false, false);
		}

		#endregion Private

		#region Protected

        protected void MakeDamageOneSquare(SectorCoordinate coordinate, IPlayer owner) {
			ISector sector = Universe.Universe.GetSector(coordinate);
            if(sector.Owner != null) {
                List<SectorCoordinate> coordinatesForVisibility = SectorUtils.GetAllPossibleCoordinates(coordinate, 10);
                List<ISector> sectorsForVisibility = Universe.Universe.GetSectors(coordinatesForVisibility, owner);
                SectorInformationContainer container = UniverseUtils.GetSectorInformationContainer(sectorsForVisibility, owner, true);

                SectorInformation info = container.Get(sector.Coordinate);
                if(info != null && !(info.Visibility is OtherBeaconVisible || info.Visibility is BeaconVisible)) {
                    MakeDamage(sector, owner);
                }
            }
		}

        protected void MakeDamageAOE1(SectorCoordinate coordinate, IPlayer owner) {
            MakeDamageAOE(coordinate, 1, owner);
		}

        protected void MakeDamageAOE2(SectorCoordinate coordinate, IPlayer owner) {
            MakeDamageAOE(coordinate, 2, owner);
		}

		protected abstract void FireDevastation(SectorCoordinate coordinate, IPlayer owner);
		protected abstract int Percentage{ get; }

		#endregion Protected

		#region UltimateCreatorBase Members

		public override bool LimitedToPlanetsSurroundings {
            get { return false; }
        }

		public override bool HasLimits {
			get { return false; }
		}

		public override void Use(IUltimateWeaponArgs args) {
			using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
				persistance.StartTransaction();
				if (IsVisible(args)) {
					FireDevastation(args.Coordinate,args.Owner);
					UpdateOwner(args.Owner, args.Coordinate);
				} else {
					Messenger.Add(new BeaconInTheSurroundingDevastation(args.Owner.Id));
					RefundUsage(args);
				}
				persistance.CommitTransaction();
			}
		}

		public void CreateDevastationAction(IPlayer owner, SectorCoordinate coordinate) {
			FireDevastation fireDevastation = new FireDevastation(owner, coordinate, Duration);
			fireDevastation.PrepareStorage();
			fireDevastation.UpdateStorage();
			ActionUtils.PersistAction(fireDevastation.Storage);
		}

		#endregion IUltimateWeapon Members
	}
}
