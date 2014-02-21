using System;
using OrionsBelt.Engine.Common;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Common;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {
	internal static class FleetMovement {

		#region Fields

		private delegate void ProcessFleetArrival(ISector sector, FleetSector fleetSector);
		private static readonly Dictionary<string, ProcessFleetArrival> mapping = new Dictionary<string, ProcessFleetArrival>();

		#endregion Fields

		#region Private

		#region Arena Arrival

		private static void ProcessArenaArrival(ISector sector, FleetSector fleetSector) {
            if( fleetSector.FleetSectorMoveArgs.ChallengeWhenArrive && !sector.IsInBattle) {
                SectorCoordinate sc = new SectorCoordinate(sector.SystemCoordinate, sector.SectorCoordinate);
                ArenaManager.Challenge(sc, fleetSector.Owner);
                GameEngine.Persist(fleetSector, false);    
            }
            UniversePersistance.AddSpecialSector(fleetSector.Owner, sector, SpecialSectorType.Arena);
		}

		#endregion Arena

		#region WormHole Arrival

        private static void PassNormalWormHole(FleetSector fleetSector) {
            ISector destiny = Universe.GetSurroundAvailableCoordinate(fleetSector.FleetSectorMoveArgs.WormHoleCoordinate, fleetSector.Owner);
            SectorCoordinate wormHoleCoordinate = fleetSector.FleetSectorMoveArgs.WormHoleCoordinate;
            ISector wormHole = Universe.GetSector(fleetSector.Owner, wormHoleCoordinate.System, wormHoleCoordinate.Sector);
            if (destiny != null) {
                Messenger.Add(new WormHoleTravelMessage(fleetSector.Owner.Id, fleetSector.FleetName, destiny.Coordinate));
                if (UniversePersistance.AddSpecialSector(fleetSector.Owner, wormHole, SpecialSectorType.Wormhole)) {
                    Messenger.Add(new NewWormHoleFoundMessage(fleetSector.Owner.Id, fleetSector.FleetSectorMoveArgs.WormHoleCoordinate));
                }
                Universe.SwapSectors(fleetSector, destiny);
				FogOfWarUtils.SaveFogOfWar(wormHole, wormHole,fleetSector.Owner);
            }
        }

        private static void PassBugWormHole(ISector sector, FleetSector fleetSector) {
            BugsWormHoleSector wh = (BugsWormHoleSector)sector;
            WormHoleCreatorBase wormhole = UltimateWeaponChooser.GetWormHoleUltimateWeapon(wh.UltimateLevel);

            if (wormhole.CanPass(sector.Owner, fleetSector.Owner)) {
                PassNormalWormHole(fleetSector);
            }
        }

		private static void ResolveWormHoleArrival(ISector sector, FleetSector fleetSector) {
		    bool canPassWormholes = fleetSector.GetBattleFleet().CanPassWormHoles;
            if (!canPassWormholes){
                Messenger.Add(new CannotPassWormHoleMessage(fleetSector.Owner.Id, fleetSector.FleetName));
                return;
            }

			if (fleetSector.FleetSectorMoveArgs.Teletransporting ) {
                if (sector is BugsWormHoleSector) {
                    PassBugWormHole(sector, fleetSector);
                }else {
                    PassNormalWormHole(fleetSector);
                }
			}
		}

        #endregion WormHole Arrival

		#region Fleet Arrival

		private static void StartBattle(FleetSector fleet1Sector, IFleetInfo fleet1, FleetSector fleet2Sector, IFleetInfo fleet2) {
            if (fleet1.Location.System.IsPrivateSystem() || fleet2.Location.System.IsPrivateSystem()) {
                return;
            }

            if (fleet1.Storage != null) { 
                fleet1.Storage.Sector.IsMoving = false;
            }
            if (fleet2.Storage != null) {
                fleet2.Storage.Sector.IsMoving = false;
            }

			int battleId = BattleManager.CreateBattleBetweenFleets(fleet1.Owner, fleet1, fleet2.Owner, fleet2, Terrain.Space);
			if (battleId > 0) {
				SectorUtils.ConvertFleetSectorToFleetBattleSector(fleet1Sector, fleet2Sector, battleId);
				Messenger.Add(new BattleStartedMessage(fleet2.Owner.Id, fleet2.Location));
				Messenger.Add(new BattleStartedMessage(fleet1.Owner.Id, fleet2.Location));
			}
			//if (battleId > 0 ) {
			//    
			//}else {
			//    if (fleet1.IsStronger(fleet2)) {
			//        Messenger.Add(new FleetToWeakToStartBattleMessage(fleet2.Owner.Id, fleet2.Name, fleet1.Owner.Name));
			//        Messenger.Add(new FleetWonMessage(fleet1.Owner.Id, fleet1.Name));
			//    }else {
			//        Messenger.Add(new FleetToWeakToStartBattleMessage(fleet1.Owner.Id, fleet1.Name, fleet2.Owner.Name));
			//        Messenger.Add(new FleetWonMessage(fleet2.Owner.Id, fleet2.Name));
			//    }
			//}	
		}

		private static void ClearEmptyFleet(IFleetInfo fleet1, IFleetInfo fleet2) {
			if (!fleet1.HasUnits) {
				fleet2.AddCargo(fleet1);
				Messenger.Add(new EmptyFleetDestroyedMessage(fleet1.Owner.Id, fleet1.Name));
				Messenger.Add(new EmptyFleetDestroyedMessage(fleet2.Owner.Id, fleet1.Name));
				FleetPersistance.DeleteFleet(fleet1);
			}
			if (!fleet2.HasUnits) {
				fleet1.AddCargo(fleet2);
				Messenger.Add(new EmptyFleetDestroyedMessage(fleet1.Owner.Id, fleet2.Name));
				Messenger.Add(new EmptyFleetDestroyedMessage(fleet2.Owner.Id, fleet2.Name));
				FleetPersistance.DeleteFleet(fleet2);
			}
		}

		private static void ProcessArrivedToFleet(ISector sector, FleetSector fleet1Sector) {
            if( fleet1Sector.FleetSectorMoveArgs != null && !fleet1Sector.FleetSectorMoveArgs.AttackWhenArrive ) {
                return;
            }

            if (sector.Owner != fleet1Sector.Owner) {
#if !DEBUG
                if( !fleet1Sector.GetBattleFleet().IsBot && SectorUtils.GetLevel(sector.Coordinate.System) < 3 ){
			 		int minGap = fleet1Sector.Owner.PlanetLevel-2;
			 		minGap = minGap > 5 ? 5 : minGap;
					if (sector.Owner.PlanetLevel < 5 && minGap > sector.Owner.PlanetLevel) {
						Messenger.Add(new PlayerIsToWeakMessage(fleet1Sector.Owner.Id, sector.Owner.Name, minGap));
						return;
					}
				}
#endif		 
				FleetSector fleet2Sector = (FleetSector)sector;
				if (sector.Owner.Alliance == null || fleet1Sector.Owner.Alliance == null || sector.Owner.Alliance.Storage.Id != fleet1Sector.Owner.Alliance.Storage.Id ) {
					if (fleet1Sector.FleetSectorMoveArgs.AttackWhenArrive) {
						IFleetInfo fleet1 = fleet1Sector.GetBattleFleet();
						IFleetInfo fleet2 = fleet2Sector.GetBattleFleet();
                        //int immunity = fleet2.ImmunityStartTick + 100;
                        //if (immunity <= Clock.Instance.Tick) {
                        //    Messenger.Add(new FleetInAttackCoolDown(fleet1.Owner.Id, fleet2.Name));
                        //    return;
                        //}
						if( !fleet1.HasUnits || !fleet2.HasUnits ) {
							ClearEmptyFleet(fleet1, fleet2);
						}else {
							StartBattle(fleet1Sector, fleet1, fleet2Sector, fleet2);
						}
					}
				}
			}
		}

		#endregion Fleet Arrival

		#region Planet Arrival

		private static void ConquerPlanet(PlanetSector p, ISector fleetSector) {
			if (!p.HasPlanet) {
				PlanetUtils.ColonizeNewPlanet(p, fleetSector.Owner);
			} else {
				if (p.Owner == null) {
					PlanetUtils.ColonizeEmptyPlanet(p, fleetSector.Owner);
				}
			}
			GameEngine.Persist(fleetSector.Owner, false, false);
            GameEngine.Persist(fleetSector, false);

			if (Server.IsInTests && p.Storage.Planets.Count == 0 ) {
				p.Storage.Planets.Add(p.GetPlanet().Storage);
				p.Storage.Fleets.Add(p.GetBattleFleet().Storage);
			}
		}

        private static void ConquerEmptyPlanet(PlanetSector p, ISector fleetSector){
            PlanetUtils.ColonizeEmptyPlanet(p, fleetSector.Owner);
			GameEngine.Persist(fleetSector.Owner, false,false);
			GameEngine.Persist(fleetSector, false);

			if (Server.IsInTests && p.Storage.Planets.Count == 0 ) {
				p.Storage.Planets.Add(p.GetPlanet().Storage);
			    p.Storage.Fleets.Add(p.GetBattleFleet().Storage);
			}
        }

	    private static void AttackPlanet(PlanetSector p, FleetSector fleetSector) {
			IPlanet planet = p.GetPlanet();
	        if (!planet.CanConquer){
                Messenger.Add(new PlanetInAttackCoolDown(fleetSector.Owner.Id, planet.Name));
                return;
            }

			if (fleetSector.Owner.Alliance == null || planet.Owner.Alliance == null || fleetSector.Owner.Alliance.Storage.Id != p.Owner.Alliance.Storage.Id) {
				int battleId = BattleManager.CreateBattleInPlanet(fleetSector.Owner, fleetSector.GetBattleFleet(), planet.Owner, planet.DefenseFleet, planet.Terrain.Terrain, fleetSector.FleetSectorMoveArgs.ConquerWhenArrive);
				if (battleId > 0){
					SectorUtils.ConvertPlanetSectorToPlanetBattleSector(fleetSector, p, battleId);
					Messenger.Add(new StartBattleMessage(fleetSector.Owner.Id, planet.Owner.Name));
					Messenger.Add(new PlanetAttackedMessage(planet.Owner.Id, planet.Name, planet.Location, fleetSector.Owner.Name));
				}
				//if( battleId > 0 ) {
				//    SectorUtils.ConvertPlanetSectorToPlanetBattleSector(fleetSector, p, battleId);
				//    Messenger.Add(new StartBattleMessage(fleetSector.Owner.Id, planet.Owner.Name));
				//    Messenger.Add(new AttackedMessage(planet.Owner.Id, fleetSector.FleetName, fleetSector.Owner.Name));
				//}else {
				//    if (fleet1.IsStronger(fleet2)) {
				//        Messenger.Add(new FleetToWeakToStartBattleMessage(fleet2.Owner.Id, fleet2.Name));
				//        Messenger.Add(new LostPlanetMessage(fleet2.Owner.Id, planet.Location));
				//        Messenger.Add(new FleetWonMessage(fleet1.Owner.Id, fleet1.Name));
				//        Messenger.Add(new ConquerMessage(fleet1.Owner.Id, planet.Location));
				//    } else {
				//        Messenger.Add(new FleetToWeakToStartBattleMessage(fleet1.Owner.Id, fleet1.Name));
				//        Messenger.Add(new FleetWonMessage(fleet2.Owner.Id, fleet2.Name));
				//    }
				//}
			}
            GameEngine.Persist(fleetSector.Owner,false,false);
		}

		private static void ResolveFleetPlanetAttack(FleetSector fleetSector, PlanetSector planetSector) {
			if (planetSector.HasPlanet && planetSector.Owner != null) {
				IFleetInfo fleet = fleetSector.GetBattleFleet();
				IPlanet planet = planetSector.GetPlanet();
				IFleetInfo defenseFleet = planet.DefenseFleet;
				if (!defenseFleet.HasUnits /*|| fleet.IsStronger(defenseFleet)*/) {
					Messenger.Add(new PlanetDoesntHaveDefense(fleet.Owner.Id, fleet.Name, planet.Name));
					if (fleetSector.FleetSectorMoveArgs.ConquerWhenArrive) {
						ConquerEmptyPlanet(planetSector, fleetSector);
					} else {
						PlanetUtils.RaidWithoutProtection(fleetSector, planet);
					}
				} else {
					AttackPlanet(planetSector, fleetSector);
				}
			}
		}

		private static void AddMessage(FleetSector fleetSector, ResultItem ri) {
			List<string> l = new List<string>(ri.Params);
			Messenger.Add(Category.Universe, ri.Name, l, fleetSector.Owner.Id, string.Empty);
		}

		private static void UnloadCargo(PlanetSector p, FleetSector fleetSector) {
			IFleetInfo f = fleetSector.GetBattleFleet();
			if( f.HasCargo ) {
				Result r = PlanetUtils.UnloadCargo(p.GetPlanet(), fleetSector.GetBattleFleet());
				if (r.Ok) {
					foreach (ResultItem ri in r.Passed) {
						AddMessage(fleetSector, ri);
					}
				} else {
					foreach (ResultItem ri in r.Failed) {
						AddMessage(fleetSector, ri);
					}
				}
				GameEngine.Persist(fleetSector.Owner,false,false);
			}else {
				Messenger.Add(new NoCargoToUnload(fleetSector.Owner.Id, f.Name));
			}
		}

		
		private static void ProcessArrivedToPlanet(ISector sector, FleetSector fleetSector) {
			PlanetSector p = (PlanetSector)sector;
			bool isOwner = p.Owner == fleetSector.Owner;

			if (!isOwner || !p.HasPlanet) {
				if (SectorUtils.GetLevel(sector.Coordinate.System) < 3) {
                    int minGap = fleetSector.Owner.PlanetLevel - 2;
                    minGap = minGap > 5 ? 5 : minGap;
                    if (sector.Owner != null && sector.Owner.PlanetLevel < 5 && minGap > sector.Owner.PlanetLevel) {
                        Messenger.Add(new PlayerIsToWeakMessage(fleetSector.Owner.Id, sector.Owner.Name, minGap));
                        return;
                    }
                }
				
				if( fleetSector.FleetSectorMoveArgs.AttackWhenArrive) {
					ResolveFleetPlanetAttack(fleetSector, p);
					return;
				}

				if (fleetSector.FleetSectorMoveArgs.ConquerWhenArrive) {
					ConquerPlanet(p, fleetSector);
				}
			}else{
				if (isOwner && fleetSector.FleetSectorMoveArgs.UnloadCargo) {
					UnloadCargo(p, fleetSector);
				}
                GameEngine.Persist(fleetSector, false);
		    }
		}

		#endregion Planet Arrival

        #region Battle Arrival

        private static void ProcessArrivedToABattle(ISector sector, FleetSector fleetSector){

        }

        #endregion Battle Arrival

		#region Market Arrival

		private static void ProcessMarketArrival(ISector sector, FleetSector fleetSector) {
            UniversePersistance.AddSpecialSector(fleetSector.Owner, sector, SpecialSectorType.Market);
		}

		#endregion Market Arrival

		#region Normal Arrival

		private static void UseUltimateWeapon(ISector sector, ISector fleetSector) {
            IPlayer player = fleetSector.Owner;
			IUltimateWeapon weapon = UltimateWeaponChooser.GetUltimateWeapon(player);
            IUltimateWeaponArgs args = UltimateWeaponChooser.GetParameters(player, sector);
			weapon.Use(args);
		}

		private static void ProcessArrivalNormal(ISector sector, FleetSector fleetSector) {
			ProcessFleetMovement(sector, fleetSector);
		}

		#endregion

		#region Academy Arrival

		private static void ProcessAcademyArrival(ISector sector, FleetSector fleetSector) {
			
		}

		#endregion Academy Arrival

		#region PirateBay Arrival

		private static void ProcessPirateBayArrival(ISector sector, FleetSector fleetSector) {

		}

		#endregion PirateBay Arrival

		#region Relic Arrival

		private static void ProcessRelicArrival(ISector sector, FleetSector fleetSector) {
			RelicSector relicSector = (RelicSector)sector;
			bool isOwner = relicSector.Owner == fleetSector.Owner;
            bool isPOwner = relicSector.Owner.Principal.Id == fleetSector.Owner.Principal.Id;

            if (!isOwner && !isPOwner) {
                if (fleetSector.FleetSectorMoveArgs.AttackWhenArrive) {
                    ResolveFleetRelicAttack(fleetSector, relicSector);
                    return;
                }

                if (fleetSector.FleetSectorMoveArgs.ConquerWhenArrive) {
                    if (relicSector.HasBattleFleet()) {
                        IFleetInfo defenseFleet = relicSector.GetBattleFleet();
                        if (!defenseFleet.HasUnits) {
                            ConquerRelic(fleetSector, relicSector);
                        } else {
                            Messenger.Add(new RelicCannotConquerAlreadyHasOwner(fleetSector.Owner.Id, relicSector.Coordinate));
                        }
                    } else {
                        ConquerRelic(fleetSector, relicSector);
                    }
                }
            } else {
                Messenger.Add(new SamePrincipalAttackMessage(fleetSector.Owner.Id, relicSector.Owner.Name));
            }
		}

		private static void ConquerRelic(FleetSector fleetSector, RelicSector relicSector) {
            if (!relicSector.CanConquer){
                Messenger.Add(new RelicInConquerCoolDown(fleetSector.Owner.Id, relicSector.Coordinate));
                return;
            }

			if( fleetSector.Owner.Alliance == null ) {
				Messenger.Add(new RelicCannotConquerNoAlliance(fleetSector.Owner.Id, relicSector.Coordinate));	
			}else{
				if (relicSector.Owner == null) {
					ConquerEmptyRelic(fleetSector, relicSector);
				}else {
					Messenger.Add(new RelicStolenMessage(relicSector.Owner.Id, relicSector.Coordinate, fleetSector.Owner.Name));
					relicSector.Owner = fleetSector.Owner;
					relicSector.GetBattleFleet().Owner = fleetSector.Owner;
				}
				Messenger.Add(new RelicConqueredMessage(fleetSector.Owner.Id, relicSector.Coordinate));
                relicSector.LastConquerTick = Clock.Instance.Tick;
			}
            
			Universe.ReplaceSector(relicSector);
			GameEngine.Persist(relicSector, false, true);
			GameEngine.Persist(fleetSector.Owner, false, false);
			GameEngine.Persist(fleetSector, false);
		}

		private static void ConquerEmptyRelic(ISector fleetSector, RelicSector relicSector) {
			relicSector.Owner = fleetSector.Owner;

			IFleetInfo fleet = new FleetInfo("DefenseFleet", fleetSector.Owner, true, relicSector.Coordinate);
			relicSector.AddCelestialBody(fleet);
			
			if (Server.IsInTests && relicSector.GetBattleFleet() == null) {
				fleet.PrepareStorage();
				fleet.UpdateStorage();
				relicSector.Storage.Fleets.Add(fleet.Storage);
			}
		}

		private static void ResolveFleetRelicAttack(FleetSector fleetSector, RelicSector relicSector) {
            if(!relicSector.CanConquer) {
                Messenger.Add(new RelicInAttackCoolDown(fleetSector.Owner.Id, relicSector.Coordinate));
                return;
            }

			if (fleetSector.Owner.Alliance == null) {
				Messenger.Add(new RelicCannotAttackNoAlliance(fleetSector.Owner.Id, relicSector.Coordinate));
				return;
			}

			if (relicSector.Owner != null) {
				IFleetInfo fleet = fleetSector.GetBattleFleet();
				IFleetInfo defenseFleet = relicSector.GetBattleFleet();
				if (!defenseFleet.HasUnits) {
					Messenger.Add(new RelicDoesntHaveDefense(fleet.Owner.Id, fleet.Name, relicSector.Coordinate));
					if (fleetSector.FleetSectorMoveArgs.ConquerWhenArrive) {
						ConquerRelic(fleetSector, relicSector);
					}
				} else {
					AttackRelic(fleetSector, relicSector);
				}
			}
		}

		private static void AttackRelic(FleetSector fleetSector, RelicSector relicSector) {
			if (relicSector.Owner.Alliance == null || fleetSector.Owner.Alliance.Storage.Id != relicSector.Owner.Alliance.Storage.Id) {
				int battleId = BattleManager.CreateBattleInPlanet(fleetSector.Owner, fleetSector.GetBattleFleet(), relicSector.Owner, relicSector.GetBattleFleet(), Terrain.Space, fleetSector.FleetSectorMoveArgs.ConquerWhenArrive);
				if (battleId > 0) {
					SectorUtils.ConvertRelicSectorToRelicBattleSector(fleetSector, relicSector, battleId);
					Messenger.Add(new StartBattleMessage(fleetSector.Owner.Id, relicSector.Owner.Name));
					Messenger.Add(new RelicAttackedMessage(relicSector.Owner.Id, relicSector.Coordinate, fleetSector.Owner.Name));
				}
			}
			GameEngine.Persist(fleetSector.Owner, false, false);
		}

		#endregion

		#endregion Private

		#region Public

		public static void ProcessStuckFleet(FleetSector fleetSector) {
			fleetSector.IsMoving = false;
			Messenger.Add(new CannotMoveMessage(fleetSector.Owner.Id, fleetSector.FleetName));
		}

		public static void ProcessFleetMovement(ISector s, FleetSector fleetSector ) {
			if (SectorUtils.IsSpace(s)) {
				try {
					FleetSectorMoveArgs args = fleetSector.FleetSectorMoveArgs;
					args.AddLastCoordinate(new SectorCoordinate(fleetSector.SystemCoordinate, fleetSector.SectorCoordinate));
					fleetSector.GetBattleFleet().Location = new SectorCoordinate(s.SystemCoordinate, s.SectorCoordinate);
					Universe.SwapSectors(fleetSector, s);	
				} catch (Exception e) {
					throw new EngineException(e, "Error processing fleet movement");
				}
			} else {
				throw new EngineException("Next move coordinate should be a NormalSector");
			}
		}

		public static void ProcessFleetArrived(ISector sector, FleetSector fleetSector) {
            fleetSector.IsMoving = false;
            Messenger.Add(new FleetArrivedMessage(fleetSector.Owner.Id, fleetSector.FleetName, fleetSector.Coordinate));
			Console.WriteLine(" » Arrival: {0}", sector.Type);
            if (fleetSector.FleetSectorMoveArgs.UseUltimateWeapon){
                UseUltimateWeapon(sector, fleetSector);
            }else{
                if (mapping.ContainsKey(sector.Type)){
			        mapping[sector.Type](sector, fleetSector);
                }
            }
		}

		#endregion Public

		#region Constructor

		static FleetMovement() {
            mapping["PlanetBattleSector"] = ProcessArrivedToABattle;
            mapping["FleetBattleSector"] = ProcessArrivedToABattle;
			mapping["PlanetSector"] = ProcessArrivedToPlanet;
			mapping["WormHoleSector"] = ResolveWormHoleArrival;
			mapping["PrivateWormHoleSector"] = ResolveWormHoleArrival;
			mapping["FleetSector"] = ProcessArrivedToFleet;
            mapping["NormalSector"] = ProcessArrivalNormal;
			mapping["ArenaSector"] = ProcessArenaArrival;
			mapping["MarketSector"] = ProcessMarketArrival;
			mapping["ResourceSector"] = ProcessFleetMovement;
			mapping["BugsWormHoleSector"] = ResolveWormHoleArrival;
			mapping["AcademySector"] = ProcessAcademyArrival;
			mapping["PirateBaySector"] = ProcessPirateBayArrival;
			mapping["RelicSector"] = ProcessRelicArrival;
			mapping["RelicBattleSector"] = ProcessArrivedToABattle;
		}

	    #endregion Constructor
	}
}
