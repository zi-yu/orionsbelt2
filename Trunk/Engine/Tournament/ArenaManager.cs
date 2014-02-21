using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.BattleCore;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Results;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.TournamentCore;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Engine.MarketPlace;

namespace OrionsBelt.Engine.Tournament
{
    public class ArenaManager
    {
        #region Ctor

        static ArenaManager()
        {
        }

        #endregion Ctor

        /// <summary>
        /// Make a conquest/challenge move in an arena
        /// </summary>
        /// <param name="arenaId">Arena identifier</param>
        /// <param name="player">Challenger player</param>
        /// <returns>The result object with que success information</returns>
        static public Result Challenge(int arenaId, IPlayer player)
        {
            Result res = ArenaUtil.Challenge(arenaId, player);
            IList<ArenaStorage> arenas = null;
            if(res.PassedCount == 1 && res.Passed[0].Name == "ArenaBattle")
            {
                
                using (IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance())
                {
                    arenas = persistance.SelectById(arenaId);
                    TransactionManager.ArenaChallengeTransaction(arenas[0], player.Storage, persistance);
                }

                IList<IPlayer> players = new List<IPlayer>(2);
                players.Add(new Player(arenas[0].Owner));
                players.Add(player);
                int battleId = BattleManager.CreateArenaBattle(players, new FleetInfo(arenas[0].Fleet), (BattleType)Enum.Parse(typeof(BattleType),arenas[0].BattleType));

                using (IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance())
                {
                    arenas[0].IsInBattle = battleId;
                    persistance.Update(arenas[0]);
                }
            }

            return res;
        }

		/// <summary>
        /// Make a conquest/challenge move in an arena
        /// </summary>
		/// <param name="coordinate">Arena coordinate</param>
        /// <param name="player">Challenger player</param>
        /// <returns>The result object with que success information</returns>
		static public Result Challenge(SectorCoordinate coordinate, IPlayer player) {
			int arenaId = GetArenaId( coordinate);
			return Challenge(arenaId, player);
		}

        /// <summary>
        /// Method to be call when an arena battle ends
        /// </summary>
        /// <param name="info">Battle info</param>
        static public void EndBattle(IBattleInfo info)
        {
            int winner;
            if(!info.Players[0].HasLost)
            {
                winner = info.Players[0].Owner.Id;
            }
            else
            {
                winner = info.Players[1].Owner.Id;
            }
            ArenaStorage arena = ArenaUtil.EndBattle(info.Id,winner);
            TransactionManager.ArenaEndTransaction(arena);
        }

        public static Result CreateArena(string name, int level, int prize, IFleetInfo units, Coordinate system, Coordinate sector)
        {
            GameEngine.Persist(units);
            Fleet fleet = units.Storage;
            SectorCoordinate coordinate = new SectorCoordinate(system,sector);
            return CreateArena("Arena"+name, "TotalAnnihalation", level.ToString(), prize.ToString(), fleet, coordinate);
        }

        public static Result CreateArena(string name, string type, string level, string prize, Fleet fleet, SectorCoordinate coordinate)
        {
            using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance())
            {
                IList<SectorStorage> sectores = persistance.TypedQuery("select e from SpecializedSectorStorage e where e.SystemX={0} and e.SystemY={1} and e.SectorX={2} and e.SectorY={3}",
                    coordinate.System.X, coordinate.System.Y, coordinate.Sector.X, coordinate.Sector.Y);

                if (sectores.Count != 0)
                {
                    return new Result(new InvalidCoordinate(coordinate));
                }


                SectorStorage sector = persistance.Create();
                sector.Level = SectorUtils.GetLevel(coordinate.System);
                sector.IsStatic = true;
                sector.Type = "ArenaSector";
                sector.SystemX = coordinate.System.X;
                sector.SystemY = coordinate.System.Y;
                sector.SectorX = coordinate.Sector.X;
                sector.SectorX = coordinate.Sector.Y;
                persistance.Update(sector);
                using (IArenaStoragePersistance persistance2 = Persistance.Instance.GetArenaStoragePersistance(persistance))
                {
                    ArenaStorage arena = persistance2.Create();
                    arena.Fleet = fleet;
                    arena.Coordinate = string.Format("{0}:{1}:{2}:{3}", coordinate.System.X, coordinate.System.Y,
                                                     coordinate.Sector.X, coordinate.Sector.Y);
                    arena.ConquestTick = 0;
                    arena.BattleType = type;
                    arena.Payment = int.Parse(prize);
                    arena.IsInBattle = 0;
                    arena.Level = sector.Level;
                    arena.Name = name;
                    arena.Sector = sector;
                    persistance2.Update(arena);
                }
                persistance.Flush();
            }
            return Result.Success;
        }

        public static ArenaSector CreateMYArena(string name, int prize, IFleetInfo fleet, SectorCoordinate coordinate){
            ArenaSector sector = new ArenaSector(coordinate.System,coordinate.Sector,SectorUtils.GetLevel(coordinate.System));
            GameEngine.Persist(sector, true, true);
            GameEngine.Persist(fleet);
            
            using (IArenaStoragePersistance persistance2 = Persistance.Instance.GetArenaStoragePersistance()){
                ArenaStorage arena = persistance2.Create();
                arena.Fleet = fleet.Storage;
                arena.Coordinate = coordinate.ToString();
                arena.ConquestTick = 0;
                arena.BattleType = "TotalAnnihalation";
                arena.Payment = prize;
                arena.IsInBattle = 0;
                arena.Level = sector.Level;
                arena.Name = name;
                arena.Sector = sector.Storage;
                persistance2.Update(arena);
                persistance2.Flush();
            }
            
            return sector;
        }
        
        private static int GetArenaId(SectorCoordinate coordinate)
        {
            using (IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance())
            {
                return
                    persistance.SelectByCoordinate(
                        string.Format("{0}:{1}:{2}:{3}", coordinate.System.X, coordinate.System.Y, coordinate.Sector.X,
                                      coordinate.Sector.Y))[0].Id;
            }
        }
    }
}
