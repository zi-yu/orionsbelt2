using System.Collections.Generic;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using OrionsBelt.Engine.Quests;
using OrionsBelt.RulesCore.Results;

namespace OrionsBelt.Engine {

    /// <summary>
    /// Planet related utilities
    /// </summary>
    public static class PlanetUtils {

        #region Creation

        public static IPlanet GeneratePlanet(IPlayer newOwner, PlanetSector sector, SectorCoordinate coordinate)
        {
			Planet planet = new Planet(sector.GetPlanetInfo(), sector.GetTerrainInfo());
			planet.Location = coordinate;
            planet.Level = sector.Level;
			sector.AddCelestialBody(planet);

			IFleetInfo fleet = new FleetInfo("DefenseFleet", newOwner, true, coordinate);
			fleet.CurrentPlanet = planet;
        	fleet.Owner = newOwner;
        	fleet.Sector = sector;
			sector.AddCelestialBody(fleet);

			ColonizeEmptyPlanet(sector, newOwner);

			planet.AddFleet(fleet);	
			newOwner.AddFleet(fleet);

            return planet;
        }
		
		private static void CreatePlanet(IPlayer newOwner, SectorCoordinate coordinate, PlanetSector sector) {
			IPlanet planet = GeneratePlanet(newOwner, sector, coordinate);
			if (sector.SystemCoordinate.IsPrivateSystem()) {
				planet.IsPrivate = true;
			} else {
				planet.IsPrivate = false;
			}
			sector.IsPrivate = planet.IsPrivate;
			planet.Location = sector.Coordinate;
            planet.LastConquerTick = Clock.Instance.Tick;
		}

        #endregion Creation

        #region Conquest

        /// <summary>
        /// Checks if the player can get additional planets
        /// </summary>
        /// <param name="player">The player</param>
        /// <returns>True if it can colonize</returns>
        public static bool CanTakePlanet(IPlayer player)
        {
            if (player.Planets.Count < MaxPlanetsPerPlayer) {
                return true;
            }
            Messenger.Add(new AlreadyAtPlanetLimitMessage(player.Id, player.Name));
            return false;
        }

        public static bool CanConquer(IPlayer player, ISector sector){
            IPlanet planet = sector.GetPlanet();
            if (planet != null && !planet.CanConquer){
                Messenger.Add(new PlanetInConquerCoolDown(player.Id, planet.Name));
                return false;
            }
            return true;
        }

        public static int MaxPlanetsPerPlayer = 5 + 8;

		/// <summary>
		/// Used when the planet was abandoned
		/// </summary>
		/// <param name="sector">Sector of the planet</param>
		/// <param name="newOwner">New owner of the planet</param>
		public static void ColonizeEmptyPlanet(PlanetSector sector, IPlayer newOwner) {
            if (!CanTakePlanet(newOwner) || !CanConquer(newOwner, sector)){
                return;
            }

			IPlanet planet = sector.GetPlanet();
			if (sector.Owner != null && !sector.SystemCoordinate.IsPrivateSystem() ) {
				Messenger.Add(new LostPlanetMessage(sector.Owner.Id, sector.Coordinate));
                sector.Owner.Score -= planet.Score;
                newOwner.Score += planet.Score;
                GameEngine.Persist(sector.Owner, false, false);
                GameEngine.Persist(newOwner, false, false);
			}

			newOwner.ColonizerRanking += planet.Level * 2;
			SetOwner(planet, newOwner);
			planet.Info.Initialize(planet);
		    planet.LastConquerTick = Clock.Instance.Tick;
			if (planet.DefenseFleet != null){
				newOwner.AddFleet(planet.DefenseFleet);
				planet.DefenseFleet.EmptyUnits();
			}
			sector.Owner = newOwner;
			Messenger.Add(new ConquerMessage(newOwner.Id, sector.Coordinate));
		}

		/// <summary>
		/// Used when the planet is colonized for the first time
		/// </summary>
		/// <param name="sector">Sector of the planet</param>
		/// <param name="newOwner">New owner of the planet</param>
		public static void ColonizeNewPlanet(PlanetSector sector, IPlayer newOwner) {
            if (!CanTakePlanet(newOwner) || !CanConquer(newOwner, sector)){
                return;
            }
			CreatePlanet(newOwner, sector.Coordinate, sector);
			sector.Owner = newOwner;
		}

		/// <summary>
		/// Used to change the owner of the planet
		/// </summary>
		/// <param name="sector">Sector of the planet</param>
		/// <param name="oldOwner">Old owner of the planet</param>
		/// <param name="newOwner">New owner of the planet</param>
        public static void Conquer(ISector sector, IPlayer oldOwner, IPlayer newOwner)
        {
            if (!CanTakePlanet(newOwner) || !CanConquer(newOwner, sector)) {
                return;
            }

        	IPlanet planet = sector.GetPlanet();
            
			newOwner.ColonizerRanking += planet.Level;
            newOwner.Score += planet.Score;
            oldOwner.Score -= planet.Score;

            ChangeOwner(planet, oldOwner, newOwner);
            planet.Info.Initialize(planet);
            planet.LastConquerTick = Clock.Instance.Tick;

        	sector.Owner = newOwner;
        }

        public static void Abandon(IPlayer player, IPlanet planet)
        {

            player.Score -= planet.Score;
            planet.Score = 0;
            planet.FacilityLevel = 0;
            player.Planets.Remove(planet);
			planet.DefenseFleet.Owner = null;

            planet.Owner = null;
        	planet.Sector.Owner = null;
            planet.LastConquerTick = 0;
        	
			foreach (IPlanetResource resource in planet.Facilities.Resources) {
                resource.State = ResourceState.Deleted;
            }
            planet.Modifiers = new Dictionary<IResourceInfo,int>();
            planet.Richness = new Dictionary<IResourceInfo, int>();
        }

        public static void ChangeOwner(IPlanet planet, IPlayer oldOwner, IPlayer newOnwer)
        {
            oldOwner.Planets.Remove(planet);
            SetOwner(planet, newOnwer);
        	planet.DefenseFleet.Owner = newOnwer;
        }

        public static void SetOwner(IPlanet planet, IPlayer owner)
        {
            owner.Planets.Add(planet);
            planet.Owner = owner;
        }

        #endregion Conquest

        #region Fleet interaction

		public static Result UnloadCargo(IPlanet planet, IFleetInfo fleet) {
			//List<ResourceQuantity> resourcesToRemove = TryRemoveAllCargo(fleet, planet);
			//RemoveResources(fleet, resourcesToRemove);
        	Result result = new Result();

			result.Merge( RemoveUnits(fleet, planet) );
        	result.Merge( RemoveResources(fleet) );

        	return result;
        }

		public static void DropTradeCargo(IFleetInfo fleet) {
			if (fleet.Cargo != null) {
				Dictionary<IResourceInfo, int> cargo = new Dictionary<IResourceInfo, int>(fleet.Cargo);
				foreach (KeyValuePair<IResourceInfo, int> info in cargo) {
					if (info.Key.IsTradeRouteSpecific) {
						fleet.RemoveCargo(info.Key);
					}
				}
			}
		}

		//private static void RemoveResources(IFleetInfo fleet, List<ResourceQuantity> resourcesToRemove) {
		//    foreach (ResourceQuantity info in resourcesToRemove) {
		//        fleet.UpdateCargo(info.Resource, info.Quantity);
		//    }
		//}

		//private static List<ResourceQuantity> TryRemoveAllCargo(IFleetInfo fleet, IPlanet planet) {
		//    List<ResourceQuantity> resourcesToRemove = new List<ResourceQuantity>();
		//    foreach (KeyValuePair<IResourceInfo, int> pair in fleet.Cargo) {
		//        if (!pair.Key.CanUnloadFromFleet) {
		//            continue;
		//        }
		//        int total;
		//        if( pair.Key is IUnitInfo ) {
		//            IUnitInfo unit = (IUnitInfo)pair.Key;
		//            int quantity = pair.Value;
		//            total = quantity - UnloadUnit(unit, quantity, planet);
		//        }else{
		//            int i = fleet.Owner.AddQuantity(pair.Key, pair.Value);
		//            total = pair.Value - i;
		//        }

		//        resourcesToRemove.Add(new ResourceQuantity(pair.Key, total));
		//    }
		//    return resourcesToRemove;
		//}

		//private static int UnloadUnit(IUnitInfo unit, int quantity, IPlanet planet) {
		//    if( unit.IsUltimate ) {
		//        int total = 0;
		//        for( int i = 0; i < quantity; ++i ) {
		//            if (PlayerUtils.Current.Fleets.Count <= PlayerUtils.MaxFleetNumber) {
		//                SectorUtils.CreateFleetSector(planet.Location, planet.Owner, unit.Name, unit);
		//                ++total;	
		//            }
		//        }
		//        return total;
		//    }

		//    planet.DefenseFleet.Add(unit, quantity);
		//    return quantity;	
		//}




		private static Result RemoveUnits(IFleetInfo fleet, IPlanet planet) {
			Result result = new Result();

			List<IResourceInfo> resourcesToRemove = new List<IResourceInfo>(fleet.Cargo.Keys);
			foreach (IResourceInfo resource in resourcesToRemove) {
				if (!resource.CanUnloadFromFleet) {
					continue;
				}
				if (resource is IUnitInfo) {
					IUnitInfo unit = (IUnitInfo)resource;
					int quantity = fleet.Cargo[resource];
					if (unit.IsUltimate) {
						for (int i = 0; i < quantity; ++i) {
                            if (fleet.Owner.Fleets.Count < PlayerUtils.MaxFleetNumber) {
								SectorUtils.CreateFleetSector(planet.Location, planet.Owner, unit.Name, unit);
								fleet.DecrementCargo(resource, 1);
							}else {
								result.AddFailed( new OrionsBelt.RulesCore.Results.MaximumFleets() );
								break;
							}
						}
					}else {
						planet.DefenseFleet.Add(unit, quantity);
						fleet.DecrementCargo(resource, quantity);
					}
				}
			}
			return result;
		}

		private static Result RemoveResources(IFleetInfo fleet) {
			Result result = new Result();
			List<IResourceInfo> resources = new List<IResourceInfo>(fleet.Cargo.Keys);
			foreach (IResourceInfo resource in resources) {
				if (!resource.CanUnloadFromFleet) {
					continue;
				}
				if (!(resource is IUnitInfo)) {
					int quantity = fleet.Cargo[resource];
					int i = fleet.Owner.AddQuantity(resource, quantity);
					if( i == 0 ) {
						result.AddFailed(new RulesCore.Results.DropAlreadyAtMaxLevelResult(resource));
						continue;
					}
					if (i != quantity) {
						result.AddFailed(new RulesCore.Results.DropSomeAlreadyAtMaxLevelResult(resource, i));
					}
					fleet.DecrementCargo(resource, i);
					result.AddPassed(new RulesCore.Results.DropResourcesSuccessfulResult(resource, quantity));
				}
			}
			return result;
		}

    	#endregion Fleet interaction

        #region Utils

        internal static void SetPlayerPlanetLevel(IPlayer player)
        {
            int count = 0;
            int minLevel = int.MaxValue;

            foreach (IPlanet planet in player.Planets) {
                if (planet.Info == null) {
                    continue;
                }
                IFacilityInfo mf = planet.Info.GetMainFacility();
                if (mf != null) {
                    ++count;
                    int flevel = int.MaxValue;
                    IFacilitySlot slot = planet.Info.GetSlot(mf.Name);
                    IPlanetResource resource = planet.GetFacility(slot);
                    if( resource.State == ResourceState.Running ) {
                        flevel = resource.Level;
                    }
                    if( resource.State == ResourceState.InQueue || resource.State == ResourceState.InConstruction ) {
                        flevel = resource.Level - 1;
                    }
                   if (flevel < minLevel) {
                        minLevel = flevel;
                    }
 
                }
            }

            if (count != TotalPlanetsPerPrivateZone) {
                minLevel = 1;
            }

            if (minLevel > 10) { 
                // ham... wierd bug?!
                minLevel = 1;
            }

            if (minLevel != player.PlanetLevel) {
                player.PlanetLevel = minLevel;
            }
        }

        public static int TotalPlanetsPerPrivateZone {
            get { return 5; }
        }

        #endregion Utils

        #region Settings

        public static int PlanetPillageDelay {
            get { return 80;  }
        }

        public static int PlanetConquerDelay {
            get { return 100;  }
        }

        #endregion Settings

		#region Raid

		public static void RaidEndBattle(IPlanet planet, IFleetInfo fleetInfo) {
			if( planet.Owner.HasSamePrincipal(fleetInfo.Owner) ) {
				Messenger.Add(new SamePrincipalRaidedMessage(fleetInfo.Owner.Id, planet.Name, fleetInfo.Owner.Name));
				return;
			}

			if( !planet.CanPillage ) {
				Messenger.Add(new PillageCoolDownMessage(fleetInfo.Owner.Id, planet.Name));
				return;
			}

			List<IResourceQuantity> resources = planet.StealResources();
			if (resources.Count > 0) {
				Messenger.Add(new StolenResourcesMessage(fleetInfo.Owner.Id, planet.Owner.Name, UniverseUtils.ConvertToString(resources)));
				Messenger.Add(new ResourcesStolenMessage(planet.Owner.Id, fleetInfo.Owner.Name,planet.Name,planet.Location, UniverseUtils.ConvertToString(resources)));

				fleetInfo.Owner.PirateRanking += planet.Level * planet.Level * 2;
				fleetInfo.AddCargo(resources);
				GameEngine.Persist(planet.Owner, false, false);
				GameEngine.Persist(fleetInfo.Owner, false, false);
			}
		}

		public static void RaidWithoutProtection(FleetSector fleetSector, IPlanet planet) {
			if (planet.Owner.HasSamePrincipal(fleetSector.Owner)) {
				Messenger.Add(new SamePrincipalRaidedMessage(fleetSector.Owner.Id, planet.Name, fleetSector.Owner.Name));
				return;
			}

			if (!planet.CanPillage) {
				Messenger.Add(new PillageCoolDownMessage(fleetSector.Owner.Id, planet.Name));
				return;
			}

			IFleetInfo fleet = fleetSector.GetBattleFleet();
			IFleetInfo defenseFleet = planet.DefenseFleet;
			List<IResourceQuantity> resources = planet.StealResources();
			if (resources.Count > 0) {
				Messenger.Add(new StolenResourcesMessage(fleet.Owner.Id, defenseFleet.Owner.Name, UniverseUtils.ConvertToString(resources)));
				Messenger.Add(new ResourcesStolenMessage(defenseFleet.Owner.Id, fleet.Owner.Name, planet.Name, planet.Location, UniverseUtils.ConvertToString(resources)));

				fleet.Owner.PirateRanking += planet.Level * planet.Level * 2;
				fleet.AddCargo(resources);
				
				QuestManager.ProcessRaid(fleet.Owner, defenseFleet.Owner);
				GameEngine.Persist(fleetSector, false);
				GameEngine.Persist(fleet.Owner, false, false);
				GameEngine.Persist(planet.Owner, false, false);
                GameEngine.Persist(planet);
			}
		}

		#endregion

    };
}
