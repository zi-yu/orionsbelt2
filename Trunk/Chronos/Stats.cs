using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using System.Collections;

namespace OrionsBelt.Chronos
{
    public class Stats
    {
        #region Public Methods

        public static void CreateXMLs(string dir)
        {
            IList<PlayerStorage> players;
            Console.WriteLine("Get Players from DB...");
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())
            {
                players = persistance.Select("Score", false);
            }

            IList<Principal> principals;
            Console.WriteLine("Get Principals from DB...");
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                principals = persistance.Select("Id",true);
            }

            IList<Fleet> fleet;
            Console.WriteLine("Get Fleets from DB...");
            using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance())
            {
                fleet = persistance.TypedQuery("select e from SpecializedFleet e where e.TournamentFleet=0");
            }

            IList alliances;
            Console.WriteLine("Get Alliances from DB...");
            using (IAllianceStoragePersistance persistance = Persistance.Instance.GetAllianceStoragePersistance())
            {
                alliances = persistance.Query(GetAllianceHql());
            }

            IList<TeamStorage> teams;
            Console.WriteLine("Get Teams from DB...");
            using (ITeamStoragePersistance persistance = Persistance.Instance.GetTeamStoragePersistance())
            {
                teams = persistance.Select("Id",true);
            }
         
            Console.WriteLine("Writing Players stats...");
            CreatePlayersXMLs(dir, players);
            Console.WriteLine("Writing Alliances stats...");
            CreateAlliancesXMLs(dir, alliances);
            Console.WriteLine("Writing Teams stats...");
            CreateTeamsXMLs(dir, teams);
            Console.WriteLine("Writing Generic stats...");
            CreateGenericsXMLs(dir, principals, players, fleet);
        }

        private static string GetAllianceHql()
        {
            TextWriter writer = new StringWriter();

            writer.Write(" select alliance.Id, alliance.Name, sum(distinct player.Score), count(distinct planet), count(distinct player) from SpecializedAllianceStorage alliance ");
            writer.Write(" inner join alliance.PlayersNHibernate player ");
            writer.Write(" inner join player.PlanetsNHibernate planet ");
            writer.Write(" group by alliance ");
            writer.Write(" order by sum(distinct player.Score) desc ");

            return writer.ToString();
        }

        public static void CreateHTMLs(string dir, string baseWrite)
        {
            WritePlayersHTML(dir, baseWrite);
            WriteAlliancesHTML(dir, baseWrite);
            WriteTeamsHTML(dir, baseWrite);
        }

        public static string GetDate()
        {
            return string.Format("{0}{1}{2}", DateTime.Now.Year, DateTime.Now.Month.ToString("D2"), DateTime.Now.Day.ToString("D2"));
        }

        public static void GenerateDBStats()
        {
            int tick = Clock.Instance.Tick;
            int players = WriteNumberOfPlayers(tick);
            WriteNumberOfActivePlayers(tick);
            WriteNumberOfPlayersPerRace(tick);
            WriteNumberOfPrincipals(tick);
            WriteNumberOfBattles(tick);
            WriteNumberOfBattlesInLast24h(tick);
            WriteNumberOfResources(tick);
            WriteNumberOfPlayersLevel(tick);
            WriteNumberOfUnits(tick);
            WriteNumberOfFleets(tick);
            WriteNumberOfPlanetsInPrivate(tick);
            int colonized = WriteNumberOfPlanetsInHot(tick);
            WriteNumberOfUncolonizedPlanetsInHot(tick, colonized);
            NumberOfPlayerWith1Planet(tick);
            NumberOfPlayerWithAllPrivatePlanets(tick);
            NumberOfPlayerWithAllHotPlanets(tick);
            AverageHotPlanetsPerPlayer(tick, players, colonized);
            AverageCredits(tick);
            CreditsSpendInLast24h(tick);
            CreditsGainInLast24h(tick);
            CreditsBuyedInLast24h(tick);
            AuctionHouseInLast24h(tick);
            RegistsInLast24h(tick);
            ShopSells(tick);
            VotingPrizes(tick);
            PirateBays(tick);
            Academys(tick);

            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                persistance.Flush();
            }
        }

        #endregion Public Methods

        #region Private Methods

        #region DB Stats

        private static void VotingPrizes(int tick)
        {
            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                long count = persistance.ExecuteScalar("SELECT COUNT(t) FROM SpecializedTransaction t where t.TransactionContext='VotingPrize' and t.CreatedDate > '{0}'", (DateTime.Now.AddDays(-1)).ToString("yyyy-MM-dd hh:mm:ss"));
                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = count;
                    stats.Text = "VotingPrize";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Principals.ToString();
                    persistance2.Update(stats);
                }
            }
        }

        private static void PirateBays(int tick)
        {
            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                long count = persistance.ExecuteScalar("SELECT sum(t.CreditsGain) FROM SpecializedTransaction t where t.TransactionContext='PirateBay' and t.CreatedDate > '{0}'", (DateTime.Now.AddDays(-1)).ToString("yyyy-MM-dd hh:mm:ss"));
                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = count;
                    stats.Text = "PirateBay";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Universe.ToString();
                    persistance2.Update(stats);
                }
            }
        }

        private static void Academys(int tick)
        {
            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                long count = persistance.ExecuteScalar("SELECT sum(t.CreditsGain) FROM SpecializedTransaction t where t.TransactionContext='Academy' and t.CreatedDate > '{0}'", (DateTime.Now.AddDays(-1)).ToString("yyyy-MM-dd hh:mm:ss"));
                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = count;
                    stats.Text = "Academy";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Universe.ToString();
                    persistance2.Update(stats);
                }
            }
        }

        private static void ShopSells(int tick)
        {
            using (
                ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance())
            {
                IList counts = persistance.Query(
                    "SELECT e.Data, COUNT(e.Data) FROM  SpecializedTimedActionStorage e WHERE e.Name='ShopTimeout' and e.CreatedDate > '{0}' GROUP BY e.Data",
                    DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd hh:mm:ss"));

                string[] services = Enum.GetNames(typeof(ServiceType));

                foreach (string service in services)
                {
                    double count = GetCount(service, counts);
                    using (
                        IGlobalStatsPersistance persistance2 =
                            Persistance.Instance.GetGlobalStatsPersistance(persistance))
                    {
                        GlobalStats stats = persistance2.Create();
                        stats.Number = count;//Convert.ToDouble(((IList) counts[0])[0]);
                        stats.Text = service;
                        stats.Tick = tick;
                        stats.Type = GlobalStatType.Shop.ToString();
                        persistance2.Update(stats);
                    }
                }
            }
        }

        private static double GetCount(string service, IList counts)
        {
            foreach (IList list in counts)
            {
                if (list[0].ToString() == service)
                    return Convert.ToDouble(list[1]);
            }
            return 0;
        }

        private static void AuctionHouseInLast24h(int tick)
        {
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                IList counts = persistance.Query(
                    "SELECT COUNT(*), SUM(e.CurrentBid), sum(e.OrionsPaid) FROM SpecializedAuctionHouse e where e.BuyedInTick > {0}", 
                    tick - 144);
                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    
                    GlobalStats stats = persistance2.Create();
                    stats.Number = Convert.ToDouble(((IList)counts[0])[0]);
                    stats.Text = "AHSellsNumber";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Universe.ToString();
                    persistance2.Update(stats);

                    if(stats.Number > 0)
                    {
                        stats = persistance2.Create();
                        stats.Number = Convert.ToDouble(((IList)counts[0])[1]);
                        stats.Text = "AHCreditsSpend";
                        stats.Tick = tick;
                        stats.Type = GlobalStatType.Universe.ToString();
                        persistance2.Update(stats);

                        stats = persistance2.Create();
                        stats.Number = Convert.ToDouble(((IList)counts[0])[2]);
                        stats.Text = "AHCreditsGain";
                        stats.Tick = tick;
                        stats.Type = GlobalStatType.Universe.ToString();
                        persistance2.Update(stats);
                    }
                }
            }
        }

        private static void WriteNumberOfActivePlayers(int tick)
        {
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())
            {
                long count = persistance.ExecuteScalar("SELECT count(*) FROM SpecializedPlayerStorage t where t.LastProcessedTick > {0} and t.CreatedDate < '{1}'",
                                                tick-(144*7),DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd hh:mm:ss"));
                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = count;
                    stats.Text = "Actives";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Principals.ToString();
                    persistance2.Update(stats);
                }
            }
        }

        private static void RegistsInLast24h(int tick)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                long count = persistance.ExecuteScalar("SELECT count(*) FROM SpecializedPrincipal t where t.CreatedDate > '{0}'", (DateTime.Now.AddDays(-1)).ToString("yyyy-MM-dd hh:mm:ss"));
                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = count;
                    stats.Text = "RegistsLast24h";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Principals.ToString();
                    persistance2.Update(stats);
                }
            }
        }

        private static void CreditsBuyedInLast24h(int tick)
        {
            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                long count = persistance.ExecuteScalar("SELECT sum(t.CreditsGain) FROM SpecializedTransaction t where t.TransactionContext='Payment' and t.CreatedDate > '{0}'", (DateTime.Now.AddDays(-1)).ToString("yyyy-MM-dd hh:mm:ss"));
                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = count;
                    stats.Text = "OrionsBuyedLast24h";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Principals.ToString();
                    persistance2.Update(stats);
                }
            }
        }

        private static void CreditsGainInLast24h(int tick)
        {
            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                long count = persistance.ExecuteScalar("SELECT sum(t.CreditsGain) FROM SpecializedTransaction t where t.IdentityTypeGain='Principal' and t.TransactionContext<>'Payment' and t.CreatedDate > '{0}'", (DateTime.Now.AddDays(-1)).ToString("yyyy-MM-dd hh:mm:ss"));
                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = count;
                    stats.Text = "OrionsGainLast24h";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Principals.ToString();
                    persistance2.Update(stats);
                }
            }
        }

        private static void CreditsSpendInLast24h(int tick)
        {
            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                long count = persistance.ExecuteScalar("SELECT sum(t.CreditsSpend) FROM SpecializedTransaction t where t.IdentityTypeSpend='Player' and t.CreatedDate > '{0}'", (DateTime.Now.AddDays(-1)).ToString("yyyy-MM-dd hh:mm:ss"));
                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = count;
                    stats.Text = "OrionsSpendLast24h";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Principals.ToString();
                    persistance2.Update(stats);
                }
            }

        }

        private static void AverageCredits(int tick)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                IList count =
                    persistance.Query(
                        "SELECT avg(p.Credits) FROM SpecializedPrincipal p Where p.RawRoles <> 'admin' or p.RawRoles is null");

                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = Convert.ToDouble(count[0]);
                    stats.Text = "AverageCredits";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Principals.ToString();
                    persistance2.Update(stats);
                }
            }
        }

        private static void AverageHotPlanetsPerPlayer(int tick, int players, int colonized)
        {
            using (IGlobalStatsPersistance persistance = Persistance.Instance.GetGlobalStatsPersistance())
            {
                GlobalStats stats = persistance.Create();
                stats.Number = (double) colonized/players;
                stats.Text = "AverageHotPlanetsPerPlayer";
                stats.Tick = tick;
                stats.Type = GlobalStatType.Universe.ToString();
                persistance.Update(stats);
            }
        }

        private static void NumberOfPlayerWithAllHotPlanets(int tick)
        {
            IList res = Sql.Query(@"SELECT count(*) from(
                                    SELECT count(*) as cnt FROM planetstorage p
                                    where isprivate=0 and PlayerId is not null
                                    group by PlayerId
                                    order by cnt desc)as der
                                  where cnt=8");

            using (IGlobalStatsPersistance persistance = Persistance.Instance.GetGlobalStatsPersistance())
            {
                GlobalStats stats = persistance.Create();
                stats.Number = Convert.ToDouble(res[0]);
                stats.Text = "PlayerWithAllHotPlanets";
                stats.Tick = tick;
                stats.Type = GlobalStatType.Universe.ToString();
                persistance.Update(stats);
            }
        }

        private static void NumberOfPlayerWithAllPrivatePlanets(int tick)
        {
            IList res = Sql.Query(@"SELECT count(*) from(
                                    SELECT count(*) as cnt FROM planetstorage p
                                    where isprivate=1 and PlayerId is not null
                                    group by PlayerId
                                    order by cnt desc)as der
                                  where cnt=5");

            using (IGlobalStatsPersistance persistance = Persistance.Instance.GetGlobalStatsPersistance())
            {
                GlobalStats stats = persistance.Create();
                stats.Number = Convert.ToDouble(res[0]);
                stats.Text = "PlayerWithAllPrivatePlanets";
                stats.Tick = tick;
                stats.Type = GlobalStatType.Universe.ToString();
                persistance.Update(stats);
            }
        }

        private static void NumberOfPlayerWith1Planet(int tick)
        {
            IList res = Sql.Query(@"SELECT count(*) from(
                                    SELECT count(*) as cnt FROM planetstorage p
                                    where isprivate=1 and PlayerId is not null
                                    group by PlayerId
                                    order by cnt desc)as der
                                  where cnt=1");

            using (IGlobalStatsPersistance persistance = Persistance.Instance.GetGlobalStatsPersistance())
            {
                GlobalStats stats = persistance.Create();
                stats.Number = Convert.ToDouble(res[0]);
                stats.Text = "PlayerWith1Planet";
                stats.Tick = tick;
                stats.Type = GlobalStatType.Universe.ToString();
                persistance.Update(stats);
            }
        }

        private static void WriteNumberOfUncolonizedPlanetsInHot(int tick, int colonized)
        {
            using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance())
            {
                long count = persistance.ExecuteScalar("SELECT count(*) FROM SpecializedSectorStorage e where e.Type='PlanetSector' and e.SystemX<>0");
                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = count-colonized;
                    stats.Text = "UncolonizedPlanetsInHot";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Universe.ToString();
                    persistance2.Update(stats);
                }
            }
        }

        private static void WriteNumberOfPlanetsInPrivate(int tick)
        {
            using (IPlanetStoragePersistance persistance = Persistance.Instance.GetPlanetStoragePersistance())
            {
                long count = persistance.ExecuteScalar("SELECT count(*) FROM SpecializedPlanetStorage e where e.IsPrivate=1");
                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = count;
                    stats.Text = "PrivatePlanets";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Universe.ToString();
                    persistance2.Update(stats);
                }
            }
        }

        private static int WriteNumberOfPlanetsInHot(int tick)
        {
            using (IPlanetStoragePersistance persistance = Persistance.Instance.GetPlanetStoragePersistance())
            {
                long count = persistance.ExecuteScalar("SELECT count(*) FROM SpecializedPlanetStorage e where e.IsPrivate=0 and e.PlayerNHibernate is null");
                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = count;
                    stats.Text = "HotPlanets";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Universe.ToString();
                    persistance2.Update(stats);
                    return Convert.ToInt32(count);
                }
            }
        }

        private static void WriteNumberOfFleets(int tick)
        {
            using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance())
            {
                long fleetCount =
                    persistance.ExecuteScalar("SELECT count(*) FROM SpecializedFleet e where e.TournamentFleet=0 and e.SectorX<>0 and e.IsPlanetDefenseFleet=0");

                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = fleetCount;
                    stats.Text = "NumberOfFleets";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Universe.ToString();
                    persistance2.Update(stats);
                }
            }
        }

        private static void WriteNumberOfUnits(int tick)
        {
            using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance())
            {
                IList units = persistance.Query("SELECT e.Units FROM SpecializedFleet e where e.TournamentFleet=0 and SectorX<>0");

                Dictionary<string, int> data = new Dictionary<string, int>();

                foreach (string unitString in units)
                {
                    string[] separate = unitString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string res in separate)
                    {
                        string[] finalData = res.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        if (data.ContainsKey(finalData[0]))
                        {
                            data[finalData[0]] += Convert.ToInt32(finalData[1]);
                        }
                        else
                        {
                            data.Add(finalData[0], Convert.ToInt32(finalData[1]));
                        }
                    }
                }

                using (IGlobalStatsPersistance persistance2 =
                            Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    foreach (IResourceInfo info in RulesUtils.GetResources())
                    {
                        if (info is IUnitInfo)
                        {
                            IUnitInfo unit = ((IUnitInfo) info);
                            if (data.ContainsKey(unit.Code))
                            {
                                GlobalStats stats = persistance2.Create();
                                stats.Number = Convert.ToDouble(data[unit.Code]);
                                stats.Text = unit.Name;
                                stats.Tick = tick;
                                stats.Type = GlobalStatType.Units.ToString();
                                persistance2.Update(stats);
                            }
                        }
                    }
                }
            }
        }
 
        private static void WriteNumberOfPlayersLevel(int tick)
        {

            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())
            {
                IList levels = persistance.Query("SELECT e.PlanetLevel, count(e.PlanetLevel) FROM SpecializedPlayerStorage e group by e.PlanetLevel");

                Dictionary<int, int> data = new Dictionary<int, int>();
                foreach (IList level in levels)
                {
                    int levelNum = Convert.ToInt32(level[0]);
                    int levelVal = Convert.ToInt32(level[1]);
                    data.Add(levelNum, levelVal);
                }
                
                using (IGlobalStatsPersistance persistance2 =
                            Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    foreach (KeyValuePair<int, int> pair in data)
                    {
                        GlobalStats stats = persistance2.Create();
                        stats.Number = Convert.ToDouble(pair.Value);
                        stats.Text = "InLevel " + pair.Key;
                        stats.Tick = tick;
                        stats.Type = GlobalStatType.Players.ToString();
                        persistance2.Update(stats);
                    }
                }
            }
        }
      
        private static void WriteNumberOfResources(int tick)
        {
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())
            {
                IList resources = persistance.Query("SELECT e.IntrinsicQuantities FROM SpecializedPlayerStorage e");

                Dictionary<string, int> data = new Dictionary<string, int>();

                foreach (string resourceString in resources)
                {
                    string[] separate = resourceString.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string res in separate)
                    {
                        string[] finalData = res.Split(new char[] {':'}, StringSplitOptions.RemoveEmptyEntries);
                        if (data.ContainsKey(finalData[0]))
                        {
                            data[finalData[0]] += Convert.ToInt32(finalData[1]);
                        }
                        else
                        {
                            data.Add(finalData[0], Convert.ToInt32(finalData[1]));
                        }
                    }
                }

                using (IGlobalStatsPersistance persistance2 =
                            Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    foreach (KeyValuePair<string, int> pair in data)
                    {
                        GlobalStats stats = persistance2.Create();
                        stats.Number = Convert.ToDouble(pair.Value);
                        stats.Text = pair.Key;
                        stats.Tick = tick;
                        stats.Type = GlobalStatType.Resources.ToString();
                        persistance2.Update(stats);
                    }
                }
            }
        }

        private static void WriteNumberOfBattlesInLast24h(int tick)
        {
            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance())
            {
                long count = persistance.ExecuteScalar("SELECT count(*) FROM SpecializedBattle b where b.BattleMode='Battle' and b.CreatedDate > '{0}'", (DateTime.Now.AddDays(-1)).ToString("yyyy-MM-dd hh:mm:ss"));
                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = count;
                    stats.Text = "StartedInLast24h";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Battles.ToString();
                    persistance2.Update(stats);
                }
            }
        }

        private static void WriteNumberOfBattles(int tick)
        {
            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance())
            {
                IList counts =
                    persistance.Query("SELECT e.BattleMode, e.TournamentMode, count(*) FROM SpecializedBattle e where e.HasEnded=0 group by e.BattleMode, e.TournamentMode");

                foreach (IList count in counts)
                {
                    using (
                        IGlobalStatsPersistance persistance2 =
                            Persistance.Instance.GetGlobalStatsPersistance(persistance))
                    {
                        string type = (string) count[0];
                        if ("Tournament" == type && "Normal" != (string)count[1])
                        {
                            type = (string) count[1];
                        }
                        GlobalStats stats = persistance2.Create();
                        stats.Number = Convert.ToDouble(count[2]);
                        stats.Text = "NumberOf" + type;
                        stats.Tick = tick;
                        stats.Type = GlobalStatType.Battles.ToString();
                        persistance2.Update(stats);
                    }
                }
            }
        }

        private static void WriteNumberOfPlayersPerRace(int tick)
        {

            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())
            {
                IList counts =
                    persistance.Query("SELECT e.Race, count(*) FROM SpecializedPlayerStorage e group by e.Race");

                foreach (IList count in counts)
                {
                    using (
                        IGlobalStatsPersistance persistance2 =
                            Persistance.Instance.GetGlobalStatsPersistance(persistance))
                    {
                        GlobalStats stats = persistance2.Create();
                        stats.Number = Convert.ToDouble(count[1]);
                        stats.Text = "NumberOf" + (string)count[0];
                        stats.Tick = tick;
                        stats.Type = GlobalStatType.Players.ToString();
                        persistance2.Update(stats);
                    }
                }
            }
        }

        private static void WriteNumberOfPrincipals(int tick)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                long count = persistance.GetCount();

                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = count;
                    stats.Text = "NumberOfPrincipals";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Principals.ToString();
                    persistance2.Update(stats);
                }
            }
        }

        private static int WriteNumberOfPlayers(int tick)
        {
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())
            {
                long count = persistance.GetCount();

                using (IGlobalStatsPersistance persistance2 = Persistance.Instance.GetGlobalStatsPersistance(persistance))
                {
                    GlobalStats stats = persistance2.Create();
                    stats.Number = count;
                    stats.Text = "NumberOfPlayers";
                    stats.Tick = tick;
                    stats.Type = GlobalStatType.Players.ToString();
                    persistance2.Update(stats);
                    return Convert.ToInt32(count);
                }
            }
        }

        #endregion DB Stats

        #region Stats Creators

        private static void CreateTeamsXMLs(string dir, IEnumerable<TeamStorage> teams)
        {
            string mainDir = string.Format("{0}/{1}/Teams", dir, GetDate());
            if (!Directory.Exists(mainDir))
            {
                Directory.CreateDirectory(mainDir);
            }
            DirectoryInfo lastSub = GetLastSub(dir);
            DirectoryInfo[] temp = lastSub.GetDirectories("Teams");

            if (temp.Length > 0)
            {
                lastSub = temp[0];
            }
            else
            {
                lastSub = lastSub.CreateSubdirectory("Teams");
            }

            CreateTeamsXML(mainDir, lastSub, teams);
        }

        private static void CreateAlliancesXMLs(string dir, IEnumerable alliances)
        {
            string mainDir = string.Format("{0}/{1}/Alliances", dir, GetDate());
            if (!Directory.Exists(mainDir))
            {
                Directory.CreateDirectory(mainDir);
            }
            DirectoryInfo lastSub = GetLastSub(dir);
            DirectoryInfo[] temp = lastSub.GetDirectories("Alliances");

            if(temp.Length > 0)
            {
                lastSub = temp[0];
            }
            else
            {
                lastSub = lastSub.CreateSubdirectory("Alliances");
            }
            

            CreateAlliancesXML(mainDir, lastSub, alliances);
        }

        private static void CreatePlayersXMLs(string dir, IEnumerable<PlayerStorage> players)
        {
            string mainDir = string.Format("{0}/{1}/Players", dir, GetDate());
            if (!Directory.Exists(mainDir))
            {
                Directory.CreateDirectory(mainDir);
            }
            DirectoryInfo lastSub = GetLastSub(dir);
            DirectoryInfo[] temp = lastSub.GetDirectories("Players");

            if (temp.Length > 0)
            {
                lastSub = temp[0];
            }
            else
            {
                lastSub = lastSub.CreateSubdirectory("Players");
            }


            CreatePlayersXML(mainDir, lastSub, players);
        }

        private static void CreateTeamsXML(string dir, DirectoryInfo lastDir, IEnumerable<TeamStorage> teams)
        {
            foreach (TeamStorage team in teams)
            {
                string filePath = string.Format("{0}/{1}.xml", dir, team.Id);
                WriteTeamInfo(lastDir, filePath, team);
            }
        }

        private static void CreateAlliancesXML(string dir, DirectoryInfo lastDir, IEnumerable alliances)
        {
            int position = 0;
            foreach (object[] alliance in alliances)
            {
                string filePath = string.Format("{0}/{1}.xml", dir, alliance[0]);
                WriteAllianceInfo(lastDir, filePath, alliance, ++position);
            }
        }

        private static void CreatePlayersXML(string dir, DirectoryInfo lastDir, IEnumerable<PlayerStorage> players)
        {
            int position = 0;
            foreach (PlayerStorage player in players)
            {
                string filePath = string.Format("{0}/{1}.xml", dir, player.Id);
                WritePlayerInfo(lastDir, filePath, player, ++position);
            }
        }

        private static void CreateGenericsXMLs(string dir, IEnumerable<Principal> principals,
            IEnumerable<PlayerStorage> players, IEnumerable<Fleet> fleets)
        {
            string generals = string.Format("{0}/{1}/Generics", dir,  GetDate());
            if (!Directory.Exists(generals))
            {
                Directory.CreateDirectory(generals);
            }

            DirectoryInfo lastSub = GetLastSub(dir);
            lastSub = lastSub.GetDirectories("Generics")[0];

            CreateScoreXML(generals, lastSub, players);
            CreateCreditsXML(generals, lastSub, principals);
            CreateLoginsXML(generals, lastSub, principals);

            Dictionary<string, int> resources = new Dictionary<string, int>();

            foreach (IResourceInfo info in RulesUtils.GetResources())
            {
                if (info is IIntrinsicInfo)
                {
                    resources.Add(info.Name, CreateResourceXML(generals, lastSub, players, info.Name));
                    continue;
                }

                if (info is IUnitInfo)
                {
                    resources.Add(info.Name, CreateUnitXML(generals, lastSub, fleets, ((IUnitInfo)info)));
                    continue;
                }
            }
            CreateResourcesXML(generals, lastSub, resources);
        }

        private static int CreateUnitXML(string dir, DirectoryInfo lastDir, IEnumerable<Fleet> fleets, IUnitInfo unit)
        {
            string filePath = string.Format("{0}/{1}.xml", dir, unit.Name);
            return WriteUnitInfo(lastDir, filePath, fleets, unit.Code);
        }

        private static int CreateResourceXML(string dir, DirectoryInfo lastDir, IEnumerable<PlayerStorage> players, string resource)
        {
            string filePath = string.Format("{0}/{1}.xml", dir, resource);
            return WritePlayersInfo(lastDir, filePath, players, resource, true);
        }

        private static void CreateLoginsXML(string dir, DirectoryInfo lastDir, IEnumerable<Principal> principals)
        {
            string filePath = dir + "/LastLogin.xml";
            WritePrincipalsInfo(lastDir, filePath, principals, "LastLogin");
        }

        private static void CreateCreditsXML(string dir, DirectoryInfo lastDir, IEnumerable<Principal> principals)
        {
            string filePath = dir + "/Credits.xml";
            WritePrincipalsInfo(lastDir, filePath, principals, "Credits");
        }

        private static void CreateScoreXML(string dir, DirectoryInfo lastDir, IEnumerable<PlayerStorage> players)
        {
            string filePath = dir + "/Score.xml";
            WritePlayersInfo(lastDir, filePath, players, "Score", false);
        }

        private static void CreateResourcesXML(string dir, DirectoryInfo lastDir, IEnumerable<KeyValuePair<string, int>> resources)
        {
            string filePath = dir + "/Resources.xml";
            WriteDictionaryInfo(lastDir, filePath, resources);
        }

        #endregion Stats Creators

        #region HTML Writers

        private static void WriteAlliancesHTML(string dir, string baseWrite)
        {
            string baseDir = string.Format("{0}/Alliances", baseWrite);

            if (!Directory.Exists(baseDir))
            {
                Directory.CreateDirectory(baseDir);
            }

            DirectoryInfo playerDir = new DirectoryInfo(string.Format("{0}/Alliances", dir));
            FileInfo[] files = playerDir.GetFiles();
            Console.WriteLine("Found {0} Alliances", files.Length);

            foreach (FileInfo file in files)
            {
                
                string fileName = Path.GetFileNameWithoutExtension(file.Name);
                try{
                    FileStream fs =
                        new FileStream(string.Format("{1}/{0}.html", fileName, baseDir), FileMode.Create,
                                       FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(file.FullName);
                    sw.Write("<div>");

                    WriteGraphic(xmlDoc, sw, "Score", true, 0);
                    WriteGraphic(xmlDoc, sw, "Position", false, 13);
                    WriteGraphic(xmlDoc, sw, "TotalMembers", true, 14);
                    WriteGraphic(xmlDoc, sw, "Planets", true, 15);

                    sw.Write("</div>");
                    sw.Close();
                    fs.Close();
                }catch(Exception)
                {
                    Console.WriteLine("Couldn't write in file {0}", fileName);
                }
            }
            Console.WriteLine("Alliances HTML generated");
        }

        private static void WriteTeamsHTML(string dir, string baseWrite)
        {
            string baseDir = string.Format("{0}/Teams", baseWrite);

            if (!Directory.Exists(baseDir))
            {
                Directory.CreateDirectory(baseDir);
            }

            DirectoryInfo playerDir = new DirectoryInfo(string.Format("{0}/Teams", dir));
            FileInfo[] files = playerDir.GetFiles();
            Console.WriteLine("Found {0} Teams", files.Length);

            foreach (FileInfo file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.Name);
                try
                {
                    FileStream fs =
                        new FileStream(string.Format("{1}/{0}.html", fileName, baseDir), FileMode.Create,
                                       FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(file.FullName);
                    
                    sw.Write("<div>");
                    WriteGraphic(xmlDoc, sw, "EloRanking", true, 0);
                    sw.Write("</div>"); sw.Close();
                    fs.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("Couldn't write in file {0}", fileName);
                }
            }
            Console.WriteLine("Teams HTML generated");
        }

        private static void WritePlayersHTML(string dir, string baseWrite)
        {
            string baseDir = string.Format("{0}/Players", baseWrite);

            if (!Directory.Exists(baseDir))
            {
                Directory.CreateDirectory(baseDir);
            }

            DirectoryInfo playerDir = new DirectoryInfo(string.Format("{0}/Players", dir));
            FileInfo[] files = playerDir.GetFiles();
            Console.WriteLine("Found {0} Players", files.Length);
            foreach (FileInfo file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.Name);
                try
                {
                    FileStream fs =
                        new FileStream(string.Format("{1}/{0}.html", fileName, baseDir), FileMode.Create,
                                       FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(file.FullName);
                    
                    sw.Write("<div>");
                    WriteGraphic(xmlDoc, sw, "EloRanking", true, 14);
                    sw.Write("</div>");

                    sw.Write("<div>");
                    WriteGraphic(xmlDoc, sw, "Score", true, 0);
                    WriteGraphic(xmlDoc, sw, "Position", false, 13);
                    WriteGraphic(xmlDoc, sw, "BountyRanking", true, 15);
                    WriteGraphic(xmlDoc, sw, "ColonizerRanking", true, 16);
                    WriteGraphic(xmlDoc, sw, "GladiatorRanking", true, 17);
                    WriteGraphic(xmlDoc, sw, "MerchantRanking", true, 18);
                    WriteGraphic(xmlDoc, sw, "PirateRanking", true, 19);
                    WriteGraphic(xmlDoc, sw, "NumberOfPlanets", true, 20);
                    sw.Write("</div>");

                    

                    sw.Close();
                    fs.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("Couldn't write in file {0}", fileName);
                }
            }
            Console.WriteLine("Players HTML generated");
        }

        private static void WriteGraphic(XmlNode xmlDoc, TextWriter sw, string attribute, bool isAscending, int titleTranslateIdx)
        {
            Dictionary<string, int> data = GetData(xmlDoc, attribute);
            int[] yValues = GetYValues(data);
            sw.Write("<img alt='{");
            sw.Write(titleTranslateIdx);
            sw.Write("}' src='http://chart.apis.google.com/chart?chxt=x,y&cht=lc&chg=5,6.26,1,3&chco=ff0000&chm=x,aaaaaa,0,-1,8&chf=bg,s,5c5d5d00|c,s,5d5d5d00&chs=250x200&chtt={");
            sw.Write(titleTranslateIdx);
            sw.Write("}&chts=dddddd,16&chxl=0:");
            //WriteXValues(sw, data);
            WriteXValues(sw, data, 5);
            sw.Write("|1:");
            WriteYValues(sw, yValues, isAscending);
            WriteData(sw, data);
            WriteScale(sw, yValues, isAscending);
            sw.Write("&chxs=0,dddddd,12,0,lt|1,dddddd,10,1,lt");
            sw.Write("' />");
        }

        private static void WriteScale(TextWriter sw, int[] yValues, bool isAscending)
        {
            sw.Write("&chds=");
            if(isAscending)
            {
                sw.Write(string.Format("{0},{1}", yValues[0], yValues[yValues.Length - 1]));
            }
            else
            {
                sw.Write(string.Format("{1},{0}", yValues[0], yValues[yValues.Length - 1]));
            }
        }

        private static void WriteData(TextWriter sw, IDictionary<string, int> data)
        {
            sw.Write("&chd=t:");
            bool isFirst = true;
            foreach (int value in data.Values)
            {
                if(isFirst)
                {
                    sw.Write(value);
                    isFirst = false;
                }
                else
                {
                    sw.Write(string.Format(",{0}",value));
                }
            }
        }

        private static void WriteYValues(TextWriter sw, int[] yValues, bool isAscending)
        {
            if(isAscending)
            {
                foreach (int val in yValues)
                {
                    sw.Write(string.Format("|{0}", val));
                }
            }
            else
            {
                for(int iter = yValues.Length-1; iter >= 0; --iter)
                {
                    sw.Write(string.Format("|{0}", yValues[iter]));
                }
            }
        }

        /*
        private static void WriteXValues(TextWriter sw, IDictionary<string, int> data)
        {
            foreach (string key in data.Keys)
            {
                sw.Write(string.Format("|{0}", key));
            }
        }
        */
        private static void WriteXValues(TextWriter sw, IDictionary<string, int> data, int numberOfValues)
        {
            if (data.Count <= numberOfValues)
            {
                foreach (string key in data.Keys)
                {
                    sw.Write(string.Format("|{0}", key));
                }
            }
            else
            {

                string[] values = GetPartOfYValues(data.Keys, numberOfValues);

                foreach (string key in values)
                {
                    sw.Write(string.Format("|{0}", key));
                }
            }
        }



        private static string[] GetPartOfYValues(ICollection<string> keys, int numberOfValues)
        {
            int jump = keys.Count/(numberOfValues-1);
            int gap = jump;
            string[] toReturn = new string[numberOfValues];
            List<string> values = new List<string>();
            foreach (string s in keys)
            {
                values.Add(s);
            }
            toReturn[0] = values[0];

            for (int iter = 1; iter < numberOfValues - 1; ++iter)
            {
                toReturn[iter] = values[jump];
                jump += gap;
            }

            toReturn[numberOfValues - 1] = values[values.Count - 1];

            return toReturn;
        }

        #endregion HTML Writers

        #region XML Writers

        private static void WriteTeamInfo(DirectoryInfo lastDir, string filePath, TeamStorage team)
        {
            string date = GetDate();
            FileInfo[] files = lastDir.GetFiles(team.Id + ".xml");
            if (files.Length == 0)
            {
                XmlTextWriter auxFile = new XmlTextWriter(filePath, null);
                auxFile.WriteStartDocument();
                auxFile.WriteStartElement("Data");

                auxFile.WriteStartElement("Date");
                auxFile.WriteAttributeString("Value", GetLastWeekDate());

                auxFile.WriteStartElement("Info");
                auxFile.WriteAttributeString("Id", team.Id.ToString());
                auxFile.WriteAttributeString("Name", team.Name);
                auxFile.WriteAttributeString("EloRanking", "1000");

                auxFile.WriteEndElement();
                auxFile.WriteEndElement();

                auxFile.WriteStartElement("Date");
                auxFile.WriteAttributeString("Value", date);

                auxFile.WriteStartElement("Info");
                auxFile.WriteAttributeString("Id", team.Id.ToString());
                auxFile.WriteAttributeString("Name", team.Name);
                auxFile.WriteAttributeString("EloRanking", team.EloRanking.ToString());

                auxFile.WriteEndElement();
                auxFile.WriteEndElement();

                auxFile.WriteEndElement();
                auxFile.WriteEndDocument();
                auxFile.Close();
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(files[0].FullName);

                TruncateXml(xmlDoc);
                XmlElement newDate = xmlDoc.CreateElement("Date");
                WriteAttribute(xmlDoc, newDate, "Value", date);

                XmlElement info = xmlDoc.CreateElement("Info");
                WriteAttribute(xmlDoc, info, "Id", team.Id.ToString());
                WriteAttribute(xmlDoc, info, "Name", team.Name);
                WriteAttribute(xmlDoc, info, "EloRanking", team.EloRanking.ToString());
                newDate.AppendChild(info);

                xmlDoc.DocumentElement.InsertAfter(newDate, xmlDoc.DocumentElement.LastChild);
                xmlDoc.Save(filePath);

            }
        }

        private static void WriteAllianceInfo(DirectoryInfo lastDir, string filePath, object[] alliance, int position)
        {
            string date = GetDate();
            FileInfo[] files = lastDir.GetFiles(alliance[0] + ".xml");
            if (files.Length == 0)
            {
                XmlTextWriter auxFile = new XmlTextWriter(filePath, null);
                auxFile.WriteStartDocument();
                auxFile.WriteStartElement("Data");

                auxFile.WriteStartElement("Date");
                auxFile.WriteAttributeString("Value", GetLastWeekDate());

                auxFile.WriteStartElement("Info");
                auxFile.WriteAttributeString("Id", alliance[0].ToString());
                auxFile.WriteAttributeString("Name", alliance[1].ToString());
                auxFile.WriteAttributeString("Position", position.ToString());
                auxFile.WriteAttributeString("Score", "0");
                auxFile.WriteAttributeString("Planets", "0");
                auxFile.WriteAttributeString("TotalMembers", "0");

                auxFile.WriteEndElement();
                auxFile.WriteEndElement();

                auxFile.WriteStartElement("Date");
                auxFile.WriteAttributeString("Value", date);

                auxFile.WriteStartElement("Info");
                auxFile.WriteAttributeString("Id", alliance[0].ToString());
                auxFile.WriteAttributeString("Name", alliance[1].ToString());
                auxFile.WriteAttributeString("Position", position.ToString());
                auxFile.WriteAttributeString("Score", alliance[2].ToString());
                auxFile.WriteAttributeString("Planets", alliance[3].ToString());
                auxFile.WriteAttributeString("TotalMembers", alliance[4].ToString());

                auxFile.WriteEndElement();
                auxFile.WriteEndElement();

                auxFile.WriteEndElement();
                auxFile.WriteEndDocument();
                auxFile.Close();
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(files[0].FullName);
                TruncateXml(xmlDoc);
                XmlElement newDate = xmlDoc.CreateElement("Date");
                WriteAttribute(xmlDoc, newDate, "Value", date);

                XmlElement info = xmlDoc.CreateElement("Info");
                WriteAttribute(xmlDoc, info, "Id", alliance[0].ToString());
                WriteAttribute(xmlDoc, info, "Position", position.ToString());
                WriteAttribute(xmlDoc, info, "Name", alliance[1].ToString());
                WriteAttribute(xmlDoc, info, "Score", alliance[2].ToString());
                WriteAttribute(xmlDoc, info, "Planets", alliance[3].ToString());
                WriteAttribute(xmlDoc, info, "TotalMembers", alliance[4].ToString());

                newDate.AppendChild(info);

                xmlDoc.DocumentElement.InsertAfter(newDate, xmlDoc.DocumentElement.LastChild);
                xmlDoc.Save(filePath);

            }
        }

        private static void WritePlayerInfo(DirectoryInfo lastDir, string filePath, PlayerStorage player, int position)
        {
            string date = GetDate();
            FileInfo[] files = lastDir.GetFiles(player.Id + ".xml");
            if (files.Length == 0)
            {
                XmlTextWriter auxFile = new XmlTextWriter(filePath, null);
                auxFile.WriteStartDocument();
                auxFile.WriteStartElement("Data");

                auxFile.WriteStartElement("Date");
                auxFile.WriteAttributeString("Value", GetLastWeekDate());

                auxFile.WriteStartElement("Info");
                auxFile.WriteAttributeString("Id", player.Id.ToString());
                auxFile.WriteAttributeString("Name", player.Name);
                auxFile.WriteAttributeString("Position", position.ToString());
                auxFile.WriteAttributeString("Score", "0");
                auxFile.WriteAttributeString("EloRanking", "1000");
                auxFile.WriteAttributeString("BountyRanking", "0");
                auxFile.WriteAttributeString("ColonizerRanking", "0");
                auxFile.WriteAttributeString("GladiatorRanking", "0");
                auxFile.WriteAttributeString("IntrinsicLimits", "");
                auxFile.WriteAttributeString("IntrinsicQuantities", "");
                auxFile.WriteAttributeString("MerchantRanking", "0");
                auxFile.WriteAttributeString("PirateRanking", "0");
                auxFile.WriteAttributeString("NumberOfPlanets", "0");
                auxFile.WriteAttributeString("NumberOfWorm", "0");

                auxFile.WriteEndElement();
                auxFile.WriteEndElement();

                auxFile.WriteStartElement("Date");
                auxFile.WriteAttributeString("Value", date);

                auxFile.WriteStartElement("Info");
                auxFile.WriteAttributeString("Id", player.Id.ToString());
                auxFile.WriteAttributeString("Name", player.Name);
                auxFile.WriteAttributeString("Position", position.ToString());
                auxFile.WriteAttributeString("Score", player.Score.ToString());
                if (null != player.Principal)
                {
                    auxFile.WriteAttributeString("EloRanking", player.Principal.EloRanking.ToString());
                }
                auxFile.WriteAttributeString("BountyRanking", player.BountyRanking.ToString());
                auxFile.WriteAttributeString("ColonizerRanking", player.ColonizerRanking.ToString());
                auxFile.WriteAttributeString("GladiatorRanking", player.GladiatorRanking.ToString());
                auxFile.WriteAttributeString("IntrinsicLimits", player.IntrinsicLimits);
                auxFile.WriteAttributeString("IntrinsicQuantities", player.IntrinsicQuantities);
                auxFile.WriteAttributeString("MerchantRanking", player.MerchantRanking.ToString());
                auxFile.WriteAttributeString("PirateRanking", player.PirateRanking.ToString());
                auxFile.WriteAttributeString("NumberOfPlanets", player.Planets.Count.ToString());
                auxFile.WriteAttributeString("NumberOfWorm", player.SpecialSectores.Count.ToString());

                auxFile.WriteEndElement();
                auxFile.WriteEndElement();

                auxFile.WriteEndElement();
                auxFile.WriteEndDocument();
                auxFile.Close();
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(files[0].FullName);
                TruncateXml(xmlDoc);
                XmlElement newDate = xmlDoc.CreateElement("Date");
                WriteAttribute(xmlDoc, newDate, "Value", date);

                XmlElement info = xmlDoc.CreateElement("Info");
                WriteAttribute(xmlDoc, info, "Id", player.Id.ToString());
                WriteAttribute(xmlDoc, info, "Position", position.ToString());
                WriteAttribute(xmlDoc, info, "Name", player.Name);
                WriteAttribute(xmlDoc, info, "Score", player.Score.ToString());
                if (null != player.Principal)
                {
                    WriteAttribute(xmlDoc, info, "EloRanking", player.Principal.EloRanking.ToString());
                }
                WriteAttribute(xmlDoc, info, "BountyRanking", player.BountyRanking.ToString());
                WriteAttribute(xmlDoc, info, "ColonizerRanking", player.ColonizerRanking.ToString());
                WriteAttribute(xmlDoc, info, "GladiatorRanking", player.GladiatorRanking.ToString());
                WriteAttribute(xmlDoc, info, "IntrinsicLimits", player.IntrinsicLimits);
                WriteAttribute(xmlDoc, info, "IntrinsicQuantities", player.IntrinsicQuantities);
                WriteAttribute(xmlDoc, info, "MerchantRanking", player.MerchantRanking.ToString());
                WriteAttribute(xmlDoc, info, "PirateRanking", player.PirateRanking.ToString());
                WriteAttribute(xmlDoc, info, "NumberOfPlanets", player.Planets.Count.ToString());
                WriteAttribute(xmlDoc, info, "NumberOfWorm", player.SpecialSectores.Count.ToString());
                newDate.AppendChild(info);

                xmlDoc.DocumentElement.InsertAfter(newDate, xmlDoc.DocumentElement.LastChild);
                xmlDoc.Save(filePath);

            }
        }

        private static int WriteUnitInfo(DirectoryInfo lastDir, string filePath, IEnumerable<Fleet> fleets, string prop)
        {
            int toReturn = 0;
            string date = GetDate();
            string fileName = filePath.Substring(filePath.LastIndexOf('/') + 1);
            Console.WriteLine("Generating file: " + fileName);
            FileInfo[] files = lastDir.GetFiles(fileName);
            if (files.Length == 0)
            {
                XmlTextWriter auxFile = new XmlTextWriter(filePath, null);
                auxFile.WriteStartDocument();
                auxFile.WriteStartElement("Data");
                auxFile.WriteStartElement("Date");
                auxFile.WriteAttributeString("Value", date);
                foreach (Fleet fleet in fleets)
                {
                    //Console.WriteLine("Fleet name: " + fleet.Name + "; ID: " + fleet.Id);
                    auxFile.WriteStartElement("Info");
                    auxFile.WriteAttributeString("Id", fleet.Id.ToString());
                    if (fleet.PlayerOwner != null)
                    {
                        auxFile.WriteAttributeString("OwnerId", fleet.PlayerOwner.Id.ToString());
                        auxFile.WriteAttributeString("OwnerName", fleet.PlayerOwner.Name);
                    }
                    string value = GetResource(fleet.Units, prop);
                    toReturn += Convert.ToInt32(value);
                    auxFile.WriteAttributeString("Value", value);

                    auxFile.WriteEndElement();
                }
                auxFile.WriteEndElement();
                auxFile.WriteEndElement();
                auxFile.WriteEndDocument();
                auxFile.Close();
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(files[0].FullName);
                XmlElement newDate = xmlDoc.CreateElement("Date");
                WriteAttribute(xmlDoc, newDate, "Value", date);

                foreach (Fleet fleet in fleets)
                {
                    if (fleet.PlayerOwner != null)
                    {
                        XmlElement info = xmlDoc.CreateElement("Info");

                        WriteAttribute(xmlDoc, info, "Id", fleet.Id.ToString());
                        if (fleet.PlayerOwner != null)
                        {
                            WriteAttribute(xmlDoc, info, "OwnerId", fleet.PlayerOwner.Id.ToString());
                            WriteAttribute(xmlDoc, info, "OwnerName", fleet.PlayerOwner.Name);
                        }
                        string value = GetResource(fleet.Units, prop);
                        toReturn += Convert.ToInt32(value);
                        WriteAttribute(xmlDoc, info, "Value", value);

                        newDate.AppendChild(info);
                    }
                }

                xmlDoc.DocumentElement.InsertAfter(newDate,
                                                   xmlDoc.DocumentElement.LastChild);
                xmlDoc.Save(filePath);
            }
            return toReturn;
        }

        private static int WritePlayersInfo(DirectoryInfo lastDir, string filePath, IEnumerable<PlayerStorage> players, string prop, bool isComplexProp)
        {
            int toReturn = 0;
            string date = GetDate();
            FileInfo[] files = lastDir.GetFiles(prop + ".xml");
            if (files.Length == 0)
            {
                XmlTextWriter auxFile = new XmlTextWriter(filePath, null);
                auxFile.WriteStartDocument();
                auxFile.WriteStartElement("Data");
                auxFile.WriteStartElement("Date");
                auxFile.WriteAttributeString("Value", date);
                foreach (PlayerStorage player in players)
                {
                    auxFile.WriteStartElement("Info");
                    auxFile.WriteAttributeString("Id", player.Id.ToString());
                    auxFile.WriteAttributeString("Player", player.Name);
                    if (isComplexProp)
                    {
                        string value = GetResource(player.IntrinsicQuantities, prop);
                        toReturn += Convert.ToInt32(value);
                        auxFile.WriteAttributeString("Value", value);
                    }
                    else
                    {
                        auxFile.WriteAttributeString("Value",
                                                     player.GetType().GetProperty(prop).GetValue(player, null).ToString());
                    }
                    auxFile.WriteEndElement();
                }
                auxFile.WriteEndElement();
                auxFile.WriteEndElement();
                auxFile.WriteEndDocument();
                auxFile.Close();
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(files[0].FullName);
                XmlElement newDate = xmlDoc.CreateElement("Date");
                WriteAttribute(xmlDoc, newDate, "Value", date);

                foreach (PlayerStorage player in players)
                {
                    XmlElement info = xmlDoc.CreateElement("Info");

                    WriteAttribute(xmlDoc, info, "Id", player.Id.ToString());
                    WriteAttribute(xmlDoc, info, "Player", player.Name);
                    if (isComplexProp)
                    {
                        string value = GetResource(player.IntrinsicQuantities, prop);
                        toReturn += Convert.ToInt32(value);
                        WriteAttribute(xmlDoc, info, "Value", value);
                    }
                    else
                    {
                        WriteAttribute(xmlDoc, info, prop,
                                       player.GetType().GetProperty(prop).GetValue(player, null).ToString());
                    }

                    newDate.AppendChild(info);
                }

                xmlDoc.DocumentElement.InsertAfter(newDate,
                                                   xmlDoc.DocumentElement.LastChild);
                xmlDoc.Save(filePath);
            }
            return toReturn;
        }

        private static void WritePrincipalsInfo(DirectoryInfo lastDir, string filePath, IEnumerable<Principal> players, string prop)
        {
            string date = GetDate();
            FileInfo[] files = lastDir.GetFiles(prop + ".xml");
            if (files.Length == 0)
            {
                XmlTextWriter auxFile = new XmlTextWriter(filePath, null);
                auxFile.WriteStartDocument();
                auxFile.WriteStartElement("Data");
                auxFile.WriteStartElement("Date");
                auxFile.WriteAttributeString("Value", date);
                foreach (Principal player in players)
                {
                    auxFile.WriteStartElement("Info");
                    auxFile.WriteAttributeString("Id", player.Id.ToString());
                    auxFile.WriteAttributeString("Principal", player.Name);
                    auxFile.WriteAttributeString(prop, player.GetType().GetProperty(prop).GetValue(player, null).ToString());
                    auxFile.WriteEndElement();
                }
                auxFile.WriteEndElement();
                auxFile.WriteEndElement();
                auxFile.WriteEndDocument();
                auxFile.Close();
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(files[0].FullName);
                XmlElement newDate = xmlDoc.CreateElement("Date");
                WriteAttribute(xmlDoc, newDate, "Value", date);

                foreach (Principal player in players)
                {
                    XmlElement info = xmlDoc.CreateElement("Info");

                    WriteAttribute(xmlDoc, info, "Id", player.Id.ToString());
                    WriteAttribute(xmlDoc, info, "Principal", player.Name);
                    WriteAttribute(xmlDoc, info, prop, player.GetType().GetProperty(prop).GetValue(player, null).ToString());

                    newDate.AppendChild(info);
                }

                xmlDoc.DocumentElement.InsertAfter(newDate,
                                                   xmlDoc.DocumentElement.LastChild);
                xmlDoc.Save(filePath);

            }
        }

        private static void WriteDictionaryInfo(DirectoryInfo lastDir, string filePath, IEnumerable<KeyValuePair<string, int>> resources)
        {
            string date = GetDate();
            FileInfo[] files = lastDir.GetFiles(filePath.Substring(filePath.LastIndexOf('/') + 1));
            if (files.Length == 0)
            {
                XmlTextWriter auxFile = new XmlTextWriter(filePath, null);
                auxFile.WriteStartDocument();
                auxFile.WriteStartElement("Data");
                auxFile.WriteStartElement("Date");
                auxFile.WriteAttributeString("Value", date);
                foreach (KeyValuePair<string, int> resource in resources)
                {
                    auxFile.WriteStartElement("Info");
                    auxFile.WriteAttributeString("Resouce", resource.Key);
                    auxFile.WriteAttributeString("Value", resource.Value.ToString());
                    auxFile.WriteEndElement();
                }
                auxFile.WriteEndElement();
                auxFile.WriteEndElement();
                auxFile.WriteEndDocument();
                auxFile.Close();
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(files[0].FullName);
                XmlElement newDate = xmlDoc.CreateElement("Date");
                WriteAttribute(xmlDoc, newDate, "Value", date);

                foreach (KeyValuePair<string, int> resource in resources)
                {
                    XmlElement info = xmlDoc.CreateElement("Info");

                    WriteAttribute(xmlDoc, info, "Resouce", resource.Key);
                    WriteAttribute(xmlDoc, info, "Value", resource.Value.ToString());
                    newDate.AppendChild(info);
                }

                xmlDoc.DocumentElement.InsertAfter(newDate,
                                                   xmlDoc.DocumentElement.LastChild);
                xmlDoc.Save(filePath);

            }
        }

        private static void WriteAttribute(XmlDocument xmlDoc, XmlElement info, string key, string value)
        {
            XmlAttribute attr = xmlDoc.CreateAttribute(key);
            attr.Value = value;
            info.SetAttributeNode(attr);
        }

        #endregion XML Writers

        #region Aux Methods

        private static string GetResource(string resources, string resource)
        {
            int idx = resources.IndexOf(resource+"-");
            if (idx < 0)
            {
                return "0";
            }
            int idxEnd = resources.IndexOf(';', idx);
            int idxStart = idx + resource.Length + 1;
            return resources.Substring(idxStart, idxEnd - idxStart);
        }

        public static DirectoryInfo GetLastSub(string dir)
        {
            Console.WriteLine("\tGetting last directory child of: {0}",dir);
            DirectoryInfo info = new DirectoryInfo(dir);
            DirectoryInfo[] subs = info.GetDirectories();
            string date = GetDate();
            DirectoryInfo lastSub = null;
            foreach (DirectoryInfo sub in subs)
            {
                if ((null == lastSub && sub.Name != date) || (null != lastSub && Convert.ToInt32(lastSub.Name) < Convert.ToInt32(sub.Name) && sub.Name != date))
                {
                    lastSub = sub;
                }
            }
            if (null == lastSub)
            {
                lastSub = BaseDirectories(info);
            }
            Console.WriteLine("\tLast directory found: {0}", lastSub.FullName);
            return lastSub;
        }

        private static DirectoryInfo BaseDirectories(DirectoryInfo info)
        {
            string folder = GetLastWeekDate();
            info.CreateSubdirectory(folder);
            info.CreateSubdirectory(folder + "/Generics");
            info.CreateSubdirectory(folder + "/Players");
            info.CreateSubdirectory(folder + "/Teams");
            info.CreateSubdirectory(folder + "/Alliances");
            return info.GetDirectories()[0];
        }

        private static string GetLastWeekDate()
        {
            return string.Format("{0}{1}{2}", DateTime.Now.AddDays(-7).Year, DateTime.Now.AddDays(-7).Month.ToString("D2"), DateTime.Now.AddDays(-7).Day.ToString("D2"));
        }

        private static void TruncateXml(XmlNode xmlDoc)
        {
            XmlNode parent = xmlDoc.SelectSingleNode("Data");
            while (parent.ChildNodes.Count > 19)
            {
                parent.RemoveChild(parent.FirstChild);
            }
        }

        private static Dictionary<string, int> GetData(XmlNode xmlDoc, string prop)
        {
            XmlNode parent = xmlDoc.SelectSingleNode("Data");
            Dictionary<string, int> toReturn = new Dictionary<string, int>(parent.ChildNodes.Count);
            foreach (XmlNode child in parent.ChildNodes)
            {
                string key = GetFormatedDate(child.Attributes);
                int value = 0;
                if (null != child.FirstChild.Attributes[prop])
                {
                     value = Convert.ToInt32(child.FirstChild.Attributes[prop].Value);
                }
 
                toReturn.Add(key,value);
            }
            return toReturn;
        }

        private static string GetFormatedDate(XmlAttributeCollection attribs)
        {
            string date = attribs["Value"].Value;
            string month, day;
            if(date[4] == '0')
            {
                month = "{" + date[5] + "}";
            }
            else
            {
                month = "{" + date.Substring(4,2) + "}";
            }

            if (date[6] == '0')
            {
                day = date[7].ToString();
            }
            else
            {
                day = date.Substring(6, 2);
            }

            return string.Format("{0}+{1}",month, day);
        }

        private static int[] GetYValues(IDictionary<string, int> data)
        {
            int[] toReturn = new int[9];
            
            int min = int.MaxValue, max = int.MinValue;

            foreach (int value in data.Values)
            {
                if(min > value)
                {
                    min = value;
                }

                if (max < value)
                {
                    max = value;
                }
            }

            if(max-min < 10)
            {
                max += 10;
            }

            double gap = max - min;
            gap = Math.Ceiling(gap/2/2/2);

            for (int iter = 0; iter < toReturn.Length; ++iter )
            {
                toReturn[iter] = (int)(min + iter*gap);
            }
            return toReturn;
        }
        #endregion Aux Methods

        #endregion Private Methods
    }
}
