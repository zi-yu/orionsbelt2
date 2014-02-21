using System;
using System.Collections.Generic;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.TournamentCore.Exceptions;
using OrionsBelt.TournamentCore.Results;

namespace OrionsBelt.TournamentCore
{
    public class ArenaUtil
    {
        #region Public Methods

        /// <summary>
        /// Make a conquest/challenge move in an arena
        /// </summary>
        /// <param name="arenaId">Arena identifier</param>
        /// <param name="player">Challenger player</param>
        /// <returns>The result object with que success information</returns>
        static public Result Challenge(int arenaId, IPlayer player)
        {
            using (IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance())
            {
                IList<ArenaStorage> arenas = persistance.SelectById(arenaId);

                if(arenas.Count == 0)
                {
                    return new Result(new ArenaResultItem("Invalid arena identifier."));
                }
                
                if (arenas[0].Owner != null && arenas[0].Owner.Id == player.Id)
                {
                    return new Result(new ArenaResultItem("You are already the Arena owner."));
                }
                if (arenas[0].IsInBattle != 0)
                {
                    return new Result(new ArenaResultItem("Arena already in battle."));
                }

                if(arenas[0].ConquestTick == 0)
                {
                    ConquererArena(player, arenas[0], persistance);
                    return new Result(new ArenaConquest("Arena found."));
                }
                else
                {
                    if (!EnoughCredits(player, arenas[0].Payment))
                    {
                        return new Result(new ArenaResultItem("Player does not have enough credits."));
                    }
                    BattleArena(player, arenas[0], persistance);
                    using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
                    {
                        player.Principal.Credits -= arenas[0].Payment;
                        persistance2.Update(player.Principal);
                    }
                    return new Result(new ArenaBattle("Arena in battle."));
                }
            }
        }

        /// <summary>
        /// End arena battle
        /// </summary>
        /// <param name="battleId">Battle identifier</param>
        /// <param name="winnerId">Winner player identifier</param>
        /// <returns>The arena updated</returns>
        static public ArenaStorage EndBattle(int battleId, int winnerId)
        {
            int currTick = Clock.Instance.Tick;
            using (IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance())
            {
                IList<ArenaStorage> arenas = persistance.SelectByIsInBattle(battleId);
                ArenaStorage arena = arenas[0];
                PlayerStorage winner = GetPlayer(winnerId, persistance);
                if (winner.Id != arena.Owner.Id)
                {
                    arenas[0].ConquestTick = currTick;
                }
                arena.IsInBattle = 0;
                arena.Owner = winner;
                persistance.Update(arena);
                if (!Server.IsInTests)
                {
                    UpdateEndSector(arena, persistance);
                }
                UpdateHistorical(arena.Historical, currTick, battleId, winnerId, arena.Payment, persistance);
                UpdateGladiatorLevel(winner, arenas[0]);

                return arena;
            }
            


        }

        #endregion Public Methods

        #region Private Methods

        private static void UpdateGladiatorLevel(PlayerStorage winner, ArenaStorage arena)
        {
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())
            {
                winner.GladiatorRanking += arena.Level*10;
                persistance.Update(winner);
            }
        }

        private static void UpdateEndSector(ArenaStorage arenaStorage, IPersistanceSession persistance)
        {
            SectorStorage sector = GetSector(arenaStorage, persistance);
            using (ISectorStoragePersistance persistance2 = Persistance.Instance.GetSectorStoragePersistance(persistance))
            {
                sector.IsInBattle = false;
                sector.Owner = arenaStorage.Owner;

                persistance2.Update(sector);
            }
        }

        private static SectorStorage GetSector(ArenaStorage arena, IPersistanceSession persistance)
        {
            SectorCoordinate coor = GetCoordinates(arena.Coordinate);
            using (ISectorStoragePersistance persistance2 = Persistance.Instance.GetSectorStoragePersistance(persistance))
            {
                IList<SectorStorage> sectores = persistance2.TypedQuery("select e from SpecializedSectorStorage e where e.SystemX={0} and e.SystemY={1} and e.SectorX={2} and e.SectorY={3}", 
                    coor.System.X, coor.System.Y, coor.Sector.X, coor.Sector.Y);

                if(sectores.Count == 0)
                {
                    throw new ArenaException("Invalid coordinate.");
                }
                return sectores[0];
            }
        }

        private static SectorCoordinate GetCoordinates(string coordinate)
        {
            string[] coor = coordinate.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if(coor.Length != 4)
            {
                throw new ArenaException("Invalid number of coordinates.");
            }
            return new SectorCoordinate(coor[0], coor[1], coor[2], coor[3]);
        }

        private static void UpdateHistorical(IEnumerable<ArenaHistorical> historical, int currTick, 
            int battleId, int winnerId, int payment, IPersistanceSession persistance)
        {
            ArenaHistorical last = null, beforeLast = null;

            foreach (ArenaHistorical hist in historical)
            {
                if(0 == hist.Winner)
                {
                    last = hist;
                }

                if(null == beforeLast)
                {
                    beforeLast = hist;
                }
                else
                {
                    if(beforeLast.EndTick <= hist.EndTick)
                    {
                        beforeLast = hist;
                    }
                }
            }
            last.EndTick = currTick;
            last.BattleId = battleId;
            last.Winner = winnerId;
            if(last.ChampionId == winnerId)
            {
                last.WinningSequence = beforeLast.WinningSequence + 1;
            	last.Arena.Owner.Principal.Credits += payment/2;
				using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance)) {
					persistance2.Update(last.Arena.Owner.Principal);
				}
            }
            else
            {
                last.WinningSequence = 1;
            }
            using (IArenaHistoricalPersistance persistance2 = Persistance.Instance.GetArenaHistoricalPersistance(persistance))
            {
                persistance2.Update(last);
            }
        }

        private static PlayerStorage GetPlayer(int winnerId, IPersistanceSession persistance)
        {
            using (IPlayerStoragePersistance persistance2 = Persistance.Instance.GetPlayerStoragePersistance(persistance))
            {
                return persistance2.SelectById(winnerId)[0];
            }
        }

        private static void BattleArena(IPlayer player, ArenaStorage arena, IPersistanceSession persistance)
        {
            if (!Server.IsInTests)
            {
                UpdateStartSector(arena, persistance, false);
            }

            using (IArenaHistoricalPersistance persistance2 = Persistance.Instance.GetArenaHistoricalPersistance(persistance))
            {
                ArenaHistorical historical = persistance2.Create();
                historical.Arena = arena;
                historical.StartTick = Clock.Instance.Tick;
                historical.ChampionId = arena.Owner.Id;
                historical.ChallengerId = player.Id;
                historical.Winner = 0;
                persistance2.Update(historical);
                persistance2.Flush();
            }

            
        }

        private static bool EnoughCredits(IPlayer player, int payment)
        {
            return player.Principal.Credits >= payment;
        }

        private static void ConquererArena(IPlayer player, ArenaStorage arena, IPersistanceSession persistance)
        {
            int currTick = Clock.Instance.Tick;
            using (IArenaStoragePersistance persistance2 = Persistance.Instance.GetArenaStoragePersistance(persistance))
            {
                arena.IsInBattle = 0;
                arena.ConquestTick = currTick;
                arena.Owner = player.Storage;
                persistance2.Update(arena);
            }
            
            if(!Server.IsInTests)
            {
                UpdateStartSector(arena, persistance, false);
            }

            using (IArenaHistoricalPersistance persistance2 = Persistance.Instance.GetArenaHistoricalPersistance(persistance))
            {
                ArenaHistorical historical = persistance2.Create();
                historical.Arena = arena;
                historical.EndTick = currTick;
                historical.StartTick = currTick;
                historical.Winner = player.Id;
                historical.WinningSequence = 0;
                persistance2.Update(historical);
                persistance2.Flush();
            }

            
        }

        private static void UpdateStartSector(ArenaStorage arena, IPersistanceSession persistance, bool startBattle)
        {
            SectorStorage sector = GetSector(arena, persistance);
            using (ISectorStoragePersistance persistance2 = Persistance.Instance.GetSectorStoragePersistance(persistance))
            {
                sector.IsInBattle = startBattle;
                if (!startBattle)
                {
                    sector.Owner = arena.Owner;
                }

                persistance2.Update(sector);
            }
        }
        #endregion Private Methods
    }
}
