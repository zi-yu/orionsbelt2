using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.BattleCore;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Quests;

namespace OrionsBelt.Engine {
	internal static class EndBattleUtils {

		#region Private

		#region Ranking Update

		#region Get Principals

		//private static string GetPrincipalWhere( IBattleInfo battleInfo ) {
		//    StringBuilder builder = new StringBuilder();
		//    builder.AppendFormat("p.Id = {0}", battleInfo.Players[0].Owner.Id);
		//    for( int i = 1; i < battleInfo.Players.Count; ++i ) {
		//        builder.AppendFormat(" or p.Id = {0}", battleInfo.Players[i].Owner.Id);
		//    }
		//    return builder.ToString();
		//}

		private static List<Principal> GetAllPrincipals( IBattleInfo battleInfo ) {
			//using( IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance() ) {
			//    return (List<Principal>) persistance.TypedQuery("from SpecializedPrincipal p where {0}", GetPrincipalWhere(battleInfo));
			//}
			List<Principal> principals = new List<Principal>();
			foreach (IBattlePlayer player in battleInfo.Players) {
				PrincipalOwner principal = (PrincipalOwner)player.Owner;
				principals.Add(principal.Principal);
			}
			return principals;
		}

		private static List<IPlayerOwner> GetWinnerPlayers(IBattleInfo battleInfo) {
			List<IPlayerOwner> players = new List<IPlayerOwner>();
			foreach (IBattleOwner player in battleInfo.GetBattleOwnerWinners()) {
				PlayerOwner p = (PlayerOwner)player;
				players.Add(p);
			}
			return players;
		}

		private static List<IPlayerOwner> GetLooserPlayers(IBattleInfo battleInfo) {
			List<IPlayerOwner> players = new List<IPlayerOwner>();
			foreach (IBattleOwner player in battleInfo.GetBattleOwnerLosers()) {
				PlayerOwner p = (PlayerOwner)player;
				players.Add(p);
			}
			return players;
		}

		private static List<Principal> GetAllPrincipalsTests( IBattleInfo battleInfo ) {
			List<Principal> principals = new List<Principal>();
			using( IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance() ) {
				foreach( IBattlePlayer player in battleInfo.Players ) {
					IList<Principal> p = persistance.SelectById(player.Owner.Id);
					principals.Add(p[0]);
				}
			}
			return principals;
		}

		#endregion Get Principals

		#region Get BattleResults

		private static IBattleResult GetBattleResult( IBattlePlayer player, List<Principal> principals ) {
			Principal current = principals.Find(delegate( Principal p ) { return p.Id == player.Owner.Id; });
			return new BattleResult(current, player.WinScore, player.HasLost);
		}

		private static IEnumerable<List<IBattlePlayer>> GetPlayerTeams( IBattleInfo battleInfo ) {
			List<List<IBattlePlayer>> teams = GetPlayerRawTeams(battleInfo);

			foreach( List<IBattlePlayer> team in teams ) {
				yield return team;
			}
		}

		private static List<List<IBattlePlayer>> GetPlayerRawTeams( IBattleInfo battleInfo ) {
			List<List<IBattlePlayer>> teams = new List<List<IBattlePlayer>>();
			foreach( IBattlePlayer player in battleInfo.Players ) {
				List<IBattlePlayer> team = teams.Find(delegate( List<IBattlePlayer> t ) {
					return t[0].TeamNumber == player.TeamNumber;
				});
				if( team == null ) {
					team = new List<IBattlePlayer>();
					teams.Add(team);
				}
				team.Add(player);
			}
			return teams;
		}

		private static List<List<IBattleResult>> GetTeams( IBattleInfo battleInfo ) {
			List<List<IBattleResult>> teams = new List<List<IBattleResult>>();
			List<Principal> principals;
			if( Server.IsInTests ) {
				principals = GetAllPrincipalsTests(battleInfo);
			} else {
				principals = GetAllPrincipals(battleInfo);
			}

			foreach( List<IBattlePlayer> player in GetPlayerTeams(battleInfo) ) {
				List<IBattleResult> team = new List<IBattleResult>();
				foreach( IBattlePlayer battlePlayer in player ) {
					team.Add(GetBattleResult(battlePlayer, principals));
				}
				teams.Add(team);
			}

			return teams;
		}

		#endregion Get BattleResults

		private static void UpdateNormalRanking( IBattleInfo battleInfo ) {
			List<List<IBattleResult>> results = GetTeams(battleInfo);
            TournamentManager.WinOrions(results[0], results[1], battleInfo);
			TournamentManager.CalcElo(results[0], results[1], battleInfo.BattleType);
            TournamentManager.UpdateStats(results[0], results[1], battleInfo);
		}

		private static void UpdateLadderRanking( IBattleInfo battleInfo ) {
			if( battleInfo.NumberOfPlayers == 2 ) {
				TournamentManager.CalcLadderResult(battleInfo.Players[0], battleInfo.Players[1]);
			} else {
				List<List<IBattlePlayer>> results = GetPlayerRawTeams(battleInfo);
				TournamentManager.CalcLadderResult(results[0], results[1]);
			}
		}

		private static void UpdateTournamentRanking( IBattleInfo battleInfo ) {
            if( battleInfo.NumberOfPlayers == 2 ) {
				TournamentManager.CalcGroupPoints(battleInfo.Battle, battleInfo.Players[0], battleInfo.Players[1]);
			} else {
				List<List<IBattlePlayer>> results = GetPlayerRawTeams(battleInfo);
				TournamentManager.CalcGroupPoints(battleInfo.Battle, results[0], results[1]);
			}
		}

		#endregion Ranking Update

		#region Fleet Utils

		private static void RestoreOriginalUnits(IFleetInfo fleetInfo, IBattlePlayer player) {
			fleetInfo.Units.Clear();
			foreach (IElement element in player.InitialContainer.InitialUnits) {
				fleetInfo.Add(element, player);
			}
		}

		private static List<IFleetInfo> GetFleets(IBattleInfo battleInfo) {
			List<IFleetInfo> fleets = new List<IFleetInfo>();
			foreach (IBattlePlayer player in battleInfo.Players) {
				IFleetInfo fleetInfo = BattlePersistance.GetFleet(player.FleetId, player.Owner);
				fleets.Add(fleetInfo);
				foreach (IElement element in battleInfo.GetBoard().Values) {
					if (element.Owner.PlayerNumber == player.PlayerNumber && element.Unit.CanBeSaved ) {
						fleetInfo.Add(element, player);
					}
				}
				if( player.HasUltimateUnit ) {
					fleetInfo.UltimateUnit = player.UltimateUnit.Element.Unit;
				}else {
					fleetInfo.UltimateUnit = null;
				}
			}
			return fleets;
		}

		private static Dictionary<IResourceInfo, int> GetCargos(List<IFleetInfo> fleets) {
			Dictionary<IResourceInfo, int> cargos = new Dictionary<IResourceInfo, int>();
			foreach (IFleetInfo info in fleets) {
				if( info.HasCargo ) {
					foreach (KeyValuePair<IResourceInfo, int> pair in info.Cargo) {
						if (cargos.ContainsKey(pair.Key)) {
							cargos[pair.Key] += pair.Value;
						} else {
							cargos.Add(pair.Key, pair.Value);
						}
					}
                    info.EmptyCargo();
				}
			}
			return cargos;
		}
		#region Planet End Battle

		private static void UpdateDefeatedPlanet(IFleetInfo fleetInfo, PlanetSector planetSector, IPlanet planet, IBattleInfo battleInfo) {
            if (!battleInfo.IsPlanetPillage) {
				//Messenger.Add(new PlanetBattleLostMessage(planet.Owner.Id, planet.Name));
				if (planet.Owner != fleetInfo.Owner) {
					PlanetUtils.ColonizeEmptyPlanet(planetSector, fleetInfo.Owner);
                }
                if (planet.Owner == fleetInfo.Owner) {
                    planet.DefenseFleet.AddHalfUnits(fleetInfo);
                    Messenger.Add(new AllUnitsAreNowOnThePlanetsDefenseFleet(fleetInfo.Owner.Id, fleetInfo.Name, planet.Name, planet.Location));
                }
                planet.LastConquerTick = Clock.Instance.Tick;
            } else {
				PlanetUtils.RaidEndBattle(planet, fleetInfo);
                planet.DefenseFleet.EmptyUnits();
			}
		}

		private static bool ResolvePlanetEndBattle(IFleetInfo fleetInfo, IFleetInfo defense, IBattleInfo battleInfo, bool findSurroundSectors) {
			PlanetSector planetSector = SectorUtils.ConvertToPlanetSector(defense.Sector);
			IPlanet planet = planetSector.GetPlanet();
			planet.DefenseFleet.IsInBattle = false;
            
			if (fleetInfo.Id != defense.Id) {
				//Planet Lost the Battle
				UpdateDefeatedPlanet(fleetInfo, planetSector, planet, battleInfo);
			} else {
				//Planet Won the Battle
				findSurroundSectors = false;
			}

            GameEngine.Persist(planetSector, false);
			return findSurroundSectors;
		}

		#endregion Planet End Battle

		#region Relic End Battle

		private static bool ResolveRelicEndBattle(IFleetInfo fleetInfo, IFleetInfo defense, IBattleInfo battleInfo, bool findSurroundSectors) {
			RelicSector relicSector = SectorUtils.ConvertToRelicSector(defense.Sector);
			relicSector.AddCelestialBody(defense);
			defense.IsInBattle = false;

			if (fleetInfo.Id != defense.Id) {
				if(fleetInfo.Owner.Alliance == null) {
					Messenger.Add(new RelicCannotConquerNoAlliance(fleetInfo.Owner.Id, relicSector.Coordinate));	
				}else {
					//Relic Lost the Battle
					Messenger.Add(new RelicLostMessage(relicSector.Owner.Id, relicSector.Coordinate));
					Messenger.Add(new RelicConqueredMessage(fleetInfo.Owner.Id, relicSector.Coordinate));
					relicSector.Owner = fleetInfo.Owner;
                    defense.Owner = fleetInfo.Owner;
				}
				defense.EmptyUnits();
			} else {
				//Relic Won the Battle
				findSurroundSectors = false;
			}

		    relicSector.LastConquerTick = Clock.Instance.Tick;
			GameEngine.Persist(relicSector, false, true);
			return findSurroundSectors;
		}

		#endregion Relic End Battle

        private static void ResolveFleetVictory(IFleetInfo fleetInfo, IFleetInfo defense, IBattlePlayer player, bool findSurroundSectors, List<IFleetInfo> fleets, IBattleInfo battleInfo, Dictionary<IResourceInfo, int> cargos) {
            fleetInfo.Cargo = cargos;
            fleetInfo.ImmunityStartTick = Clock.Instance.Tick;
			
			Messenger.Add(new FleetCargoUpdatedMessage(player.Owner.Id, fleetInfo.Name));
			Messenger.Add(new FleetWonMessage(player.Owner.Id, fleetInfo.Name));

			if (defense != null) {
				if( defense.Sector is PlanetBattleSector ) {
					findSurroundSectors = ResolvePlanetEndBattle(fleetInfo, defense, battleInfo, findSurroundSectors);	
				}

				if (defense.Sector is RelicBattleSector) {
					findSurroundSectors = ResolveRelicEndBattle(fleetInfo, defense, battleInfo, findSurroundSectors);	
				}
			}
			if (fleetInfo.IsBot) {
				RestoreOriginalUnits(fleetInfo, player);
			}

			BattlePersistance.UpdateFleet(fleetInfo, findSurroundSectors);
		}

		private static void ResolveFleetDefeat(IFleetInfo fleetInfo, IBattlePlayer player) {
			if (!fleetInfo.IsPlanetDefenseFleet) {
				Messenger.Add(new LostAllCargoMessage(player.Owner.Id, fleetInfo.Name));
				Messenger.Add(new FleetLostMessage(player.Owner.Id, fleetInfo.Name));
				BattlePersistance.UpdateFleet(fleetInfo, true);
			}
		}

         private static void SendWonMessage(IBattlePlayer player, IBattleInfo battleInfo){
            if (battleInfo.BattleMode == BattleMode.Battle || battleInfo.BattleMode == BattleMode.Arena ){
                Messenger.Add(new WinBattleMessage(player.Owner.Id, player.WinScore, battleInfo.Id));    
            }else{
                Messenger.Add(new WinPrincipalBattleMessage(player.Owner.Id, battleInfo.Id));
            }
        }

        private static void SendLostMessage(IBattlePlayer player, IBattleInfo battleInfo){
            if (battleInfo.BattleMode == BattleMode.Battle || battleInfo.BattleMode == BattleMode.Arena ){
                Messenger.Add(new LostBattleMessage(player.Owner.Id, Math.Abs(player.LoseScore), battleInfo.Id));    
            }else{
                Messenger.Add(new LostPrincipalBattleMessage(player.Owner.Id, battleInfo.Id));
            }
        }

		#endregion Fleet Utils

		#region Campaign Utils

		private static bool PlayerWon(IBattleInfo battleInfo) {
			foreach (IBattleOwner player in battleInfo.GetBattleOwnerWinners()) {
				PrincipalOwner p = (PrincipalOwner)player;
				if(p.IsBot) {
					return false;
				}
			}
			return true;
		}

		#endregion Campaign Utils

		#endregion Private

		#region Public

		public static void ProcessEndBattle(IBattleInfo battleInfo) {
			if (battleInfo.BattleMode == BattleMode.Battle) {
				QuestManager.ProcessBattle(battleInfo, GetWinnerPlayers(battleInfo), GetLooserPlayers(battleInfo));
				BattlePersistance.UpdateBattlePlayers(battleInfo);
			}
            if (battleInfo.BattleMode == BattleMode.Arena){
				QuestManager.ProcessBattle(battleInfo, GetWinnerPlayers(battleInfo), GetLooserPlayers(battleInfo));
                ArenaManager.EndBattle(battleInfo);
            }
			if (battleInfo.BattleMode == BattleMode.Campaign) {
				CampaignManager.ProcessBattle(battleInfo, PlayerWon(battleInfo));
			}
		}

		public static void ProcessRanking(IBattleInfo battleInfo) {
			if (battleInfo.BattleMode == BattleMode.Tournament) {
				UpdateNormalRanking(battleInfo);
				if (battleInfo.TournamentMode == TournamentMode.Ladder) {
					UpdateLadderRanking(battleInfo);
				} else {
					UpdateTournamentRanking(battleInfo);
				}
			}
		}

		public static void UpdateEndBattleFleets(IBattleInfo battleInfo) {
			if (battleInfo.UpdateFleets) {
				List<IFleetInfo> fleets = GetFleets(battleInfo);
				IFleetInfo defense = fleets.Find(delegate(IFleetInfo f) { return f.IsPlanetDefenseFleet; });
                bool findSurroundSectors = defense != null;

                Dictionary<IResourceInfo,int> cargos =  GetCargos(fleets);

				for (int i = 0; i < battleInfo.Players.Count; ++i ) {
					IBattlePlayer player = battleInfo.Players[i];
					IFleetInfo fleetInfo = fleets[i];
					fleetInfo.IsInBattle = false;
					if (player.HasLost || player.HasGaveUp) {
					    ResolveFleetDefeat(fleetInfo, player);
					} else {
						ResolveFleetVictory(fleetInfo, defense, player, findSurroundSectors, fleets, battleInfo, cargos);
						findSurroundSectors = true;
					}
				}
			}
		}

         public static void SendEndBattleMessages(IBattleInfo battleInfo){
            foreach( IBattlePlayer player in battleInfo.Players ){
                if (player.HasLost || player.HasGaveUp) {
                    SendLostMessage(player, battleInfo);
				} else {
                    SendWonMessage(player, battleInfo);
				}    
            }
        }

		#endregion Public
       
    }
}
