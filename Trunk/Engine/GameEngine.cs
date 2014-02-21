using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.Engine.Actions;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using OrionsBelt.DataAccessLayer;
using Loki.DataRepresentation;
using OrionsBelt.RulesCore.UniverseInfo;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.Engine {

    /// <summary>
    /// Handles the game top level's operations
    /// </summary>
    public static class GameEngine {

        #region Initialization

        public static void Init()
        {
			
        }

        #endregion Initialization

        #region Resource Management

        public static void ProcessTick()
        {
            try {

                if (Server.Properties.Running) {
                    ActionManager.ProcessActions(Visibility.Public);
                    ActionManager.ProcessActions(Visibility.Private);
                }

            } catch (Exception ex) {
                Console.WriteLine(ex);
                ExceptionLogger.Log(ex);
            }
        }

        private static void ProcessUltimateCooldown(IPlayer player){
            if (player.UltimateWeaponCooldown > 0){
                int gap = Clock.Instance.Tick - player.LastProcessedTick;
				if(gap < 0 ) {
					gap = 0;
				}
                player.UltimateWeaponCooldown = player.UltimateWeaponCooldown - gap;
                if (player.UltimateWeaponCooldown < 0) {
                    player.UltimateWeaponCooldown = 0;
                }
            }
        }

        public static void ProcessPlayer(IPlayer player)
        {
            if (player.InVacations) {
                return;
            }
            if (player.LastProcessedTick == Clock.Instance.Tick) {
                return;
            }
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance())
            {
                try {
                    session.StartTransaction();
                    ProcessUltimateCooldown(player);
                    ActionManager.ProcessActions(session, player);
                    PlanetUtils.SetPlayerPlanetLevel(player);
                    
                    Persist(player, false,false);
                    session.CommitTransaction();
                } catch {
                    session.RollbackTransaction();
                    throw;
                }
            }
        }

        #endregion Resource Management

        #region Persistance

		public static void Persist(IPlayer player) {
			Persist(player, false, true);
		}

		public static void Persist(IPlayer player, bool isCreation) {
			Persist(player, isCreation, true);
		}

    	public static void Persist(IPlayer player, bool isCreation, bool flush )
        {
            if (player.IsDirty) {
                player.UpdateStorage();
            	PlayerUtils.Update(player);
                player.IsDirty = false;
            }

			if( player.HasLoadedActions() ) {
				foreach (ITimedAction action in player.Actions) {
					Persist(action);
				}
			}	
			
			if( player.HasLoadedPlanets() ) {
				foreach (IPlanet planet in player.Planets) {
					Persist(planet);
				}
			}

    		if( player.HasLoadedFleets() ) {
				foreach (IFleetInfo fleet in player.Fleets) {
					Persist(fleet);
				}
			}

    		if( player.HasLoadedSectors() ) {
				if (player.HasPrivateSystem) {
					foreach (ISector sector in player.PrivateSystem.Sectors.Values) {
						Persist(sector, false, isCreation);
					}
				}
			}

			if (player.HasLoadedQuests()) {
				foreach (IQuestData quest in player.Quests) {
					Persist(quest);
				}
			}

    		PersistResourceOwner(player);

			if( isCreation ) {
				FogOfWarUtils.CreateInitialFogOfWar(player);
			}

			if (flush){
				Persistance.Flush();
			}
        }

        public static void Persist(IQuestData quest)
        {
            if (quest.IsDirty) {
                quest.PrepareStorage();
                quest.UpdateStorage();
                quest.IsDirty = false;
                using (IQuestStoragePersistance persistance = Persistance.Instance.GetQuestStoragePersistance()) {
                    persistance.Update(quest.Storage);
                }
            }
        }

        public static void Persist(IPlanet planet)
        {
            PersistResourceOwner(planet);
            if (planet.IsDirty) {
				planet.UpdateStorage();
                ResourceUtils.Update(planet);
                planet.IsDirty = false;
            }

			if( planet.HasLoadedFleets() ) {
				foreach (IFleetInfo fleet in planet.Fleets) {
					Persist(fleet);
				}
			}
			if( planet.HasLoadedDefenseFleet() ) {
				Persist(planet.DefenseFleet);
			}
        }

		public static void Persist(IFleetInfo fleetInfo) {
			if (fleetInfo.IsDirty) {
				fleetInfo.PrepareStorage();
				fleetInfo.UpdateStorage();
				using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance()) {
					persistance.Update(fleetInfo.Storage);
				}
                fleetInfo.IsDirty = false;
			}
		}

        public static void PersistResourceOwner(IResourceOwner owner)
        {
            foreach (IPlanetResource resource in ResourceUtils.GetResources(owner)) {
                Persist(resource);
            }
        }

        public static void Persist(IPlanetResource resource)
        {
            if (resource.IsTemplate || resource.State == ResourceState.Available) {
                return;
            }
            if (resource.State == ResourceState.Deleted) {
                ResourceUtils.Delete(resource);
                resource.IsDirty = false;
                return;
            }
            if (resource.IsDirty) {
                resource.UpdateStorage();
                ResourceUtils.Update(resource);
                resource.IsDirty = false;
            }
        }

        public static void Persist(ITimedAction action)
        {
            if (action.IsDirty && action.IsPersistable) {
                action.UpdateStorage();
                ActionUtils.PersistAction(action.Storage);
                action.IsDirty = false;
            }
        }

		public static void Persist(ISector sector) {
			Persist(sector,true,false);
		}

		public static void Persist(ISector sector, bool flush) {
			Persist(sector, flush, false);
		}

    	public static void Persist(ISector sector, bool flush, bool forceSectorPersist) {
			if (sector.IsDirty || forceSectorPersist) {
				sector.PrepareStorage();
				sector.UpdateStorage();
				using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
					persistance.Update(sector.Storage);	
				}
			}

			IPlanet planet = sector.GetPlanet();
			if( planet != null ) {
				planet.Sector = sector;
				Persist(planet);
			}

			foreach (IFleetInfo fleet in sector.GetFleets()) {
				if (planet != null && fleet.CurrentPlanet != null) {
					fleet.CurrentPlanet = planet;
				}
				fleet.Sector = sector;
				Persist(fleet);
			}
		
			if (sector is PrivateWormHoleSector) {
				UniversePersistance.AddSpecialSector(sector.Owner, sector, SpecialSectorType.Wormhole);
			}

			if (flush){
				Persistance.Flush();
			}
		}

		public static void PersistUniverse() {
			DateTime start3 = DateTime.Now;
			foreach (ISystem system in Universe.Universe.AllUniverse.Values) {
				foreach (ISector sector in system.Sectors.Values) {
					if( sector.IsDirty ) {
						Persist(sector,false);
					}
				}
			}
			foreach (ISystem system in Universe.Universe.PrivateUniverses.Values) {
				foreach (ISector sector in system.Sectors.Values) {
					if (sector.IsDirty) {
						Persist(sector, false);
					}
				}
			}
			
			Console.WriteLine(" » Persisting Sectors took {0}ms", (DateTime.Now - start3).TotalMilliseconds);
		}

        #endregion Persistance

        #region Automatic Tick Processing

        static GameEngine()
        {
            if (Server.UsingInProcClock) {
                Clock.Instance.Ticked += new ClockTicked(Clock_Ticked);
            }
        }

        internal static void Clock_Ticked()
        {
            ProcessTick();
        }

        #endregion Automatic Tick Processing

		#region Player

        private static void CreatePrivateFogOfWar(IPlayer player){
           FogOfWar fogOfWar = new FogOfWar(new Coordinate(0, 0));
           fogOfWar.Owner = player;
           fogOfWar.HasDiscoveredAll = true;

           using (IFogOfWarStoragePersistance fogPersistance = Persistance.Instance.GetFogOfWarStoragePersistance()) {
		        fogOfWar.PrepareStorage();
				fogOfWar.UpdateStorage();
               
				fogPersistance.Update(fogOfWar.Storage);
			}
        }

		/// <summary>
		/// Creates a Player in the universe
		/// </summary>
		/// <param name="p">Principal that owns the player</param>
		/// <param name="name">Name of the player</param>
		/// <returns>The object that represents the player</returns>
		public static IPlayer CreatePlayer(Principal p, string name) {
            return CreatePlayer(p, name, RaceInfo.Get(Race.LightHumans));
		}

        /// <summary>
        /// Creates a player
        /// </summary>
        /// <param name="principal">The owner principal</param>
        /// <param name="name">The player name</param>
        /// <param name="raceInfo">The player race</param>
        /// <returns>The player</returns>
        public static IPlayer CreatePlayer(Principal principal, string name, IRaceInfo raceInfo)
        {
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance()) {
                if (persistance.CountByName(name) > 0) {
                    return new Player(persistance.SelectByName(name)[0]);
				}

                try {

                    persistance.StartTransaction();
                    PlayerStats stats;
                    using (IPlayerStatsPersistance persistance2 = Persistance.Instance.GetPlayerStatsPersistance(persistance))
                    {
                        stats = persistance2.Create();
                        stats.NumberBountyQuests = 0;
                        stats.NumberColonizerQuests = 0;
                        stats.NumberGladiatorQuests = 0;
                        stats.NumberMerchantQuests = 0;
                        stats.NumberOfPlayedBattles = 0;
                        stats.NumberPirateQuest = 0;
                        persistance2.Update(stats);
                    }

                    IPlayer player = new Player();

                    if (principal.Player.Count == 0)
                    {
                        player.IsPrimary = true;
                    }

                    player.Name = name;
                    player.Principal = principal;
                    player.RaceInfo = raceInfo;
                    player.Active = true;
                    //player.ActivatedInTick = Clock.Instance.Tick;
                    player.ActivatedInTick = 0;

                    UniverseCreation.CreatePrivateUniverse(player);
                    PlayerUtils.Initialize(player);
                    player.Storage.Stats = stats;
                    Persist(player,true, false);

                    Messenger.Add(new WelcomeToTheGame(player.Id), persistance);

                    CreatePrivateFogOfWar(player);
                    
                    persistance.CommitTransaction();

                    PlayerUtils.Current = player;
				    return player;

                } catch {
                    persistance.RollbackTransaction();
                    throw;
                }
			}
        }

     

		#endregion

    };
}
