using System.Collections;
using System.Collections.Generic;
using OrionsBelt.Engine.Common;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Resources;
using System.Web;
using OrionsBelt.WebComponents;
using OrionsBelt.RulesCore.Enum;
using System;
using OrionsBelt.Engine.Alliances;
using System.IO;
using OrionsBelt.Generic;
using Loki.DataRepresentation;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.Engine {

    /// <summary>
    /// Relics utilities
    /// </summary>
    public static class RelicsManager {

        #region Properties

        public static string RelicSectorType {
            get { return "RelicSector";  }
        }

        #endregion Properties

        #region Income Processing

        public static void ProcessIncome()
        {
            using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {

                using (IAllianceStoragePersistance persistance2 = Persistance.Instance.GetAllianceStoragePersistance(persistance))
                {
                    IList <AllianceStorage> alls = persistance2.TypedQuery("select e from SpecializedAllianceStorage e where e.TotalRelics <> 0");
                    foreach (AllianceStorage all in alls)
                    {
                        all.TotalRelics = 0;
                        all.TotalRelicsIncome = 0;
                    }
                    persistance2.Update(alls);
                }
                IList<SectorStorage> list = persistance.TypedQuery("select s from SpecializedSectorStorage s left join fetch s.OwnerNHibernate player where s.Type = 'RelicSector' or s.Type = 'RelicBattleSector'");
                Console.WriteLine("Loaded {0} RelicSectors", list.Count);
                Dictionary<AllianceStorage, List<SectorStorage>> group = GroupByAlliance(list);
                foreach (KeyValuePair<AllianceStorage, List<SectorStorage>> pair in group) {
                    ProcessAlliance(pair.Key, pair.Value, list);
                }
            }
        }

        private static void ProcessAlliance(AllianceStorage alliance, List<SectorStorage> list, IList<SectorStorage> allRelics)
        {
            using (IAllianceStoragePersistance persistance = Persistance.Instance.GetAllianceStoragePersistance()) {
                persistance.StartTransaction();

                Console.WriteLine("Handling alliance {0}... ", alliance.Name);

                alliance.TotalRelics = list.Count;
                alliance.TotalRelicsIncome = GetTotalIncome(list, allRelics);

                Console.WriteLine("\tRelics: {0}", alliance.TotalRelics);
                Console.WriteLine("\tIncome: {0}", alliance.TotalRelicsIncome);

                persistance.Update(alliance);

                Dictionary<AllianceRank, double> percents = GetRelicShare(alliance);
                DeliverPlayersShare(alliance, percents, persistance);

                persistance.CommitTransaction();
            }
        }

        private static void DeliverPlayersShare(AllianceStorage alliance, Dictionary<AllianceRank, double> percents, IPersistanceSession session)
        {
            IResourceInfo curr = GetCurrResourceInfo();
            using(IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance(session) ) {
                foreach (PlayerStorage storage in alliance.Players) {
                    if (!PlayerUtils.IsActive(storage))
                    {
                        continue;
                    }
                    IPlayer player = new Player(storage);
                    int share = Convert.ToInt32( percents[player.AllianceRank] * alliance.TotalRelicsIncome );
                    player.AddQuantity(curr, share);
                    Messenger.Add(new RelicIncomeReceived(player.Id, share, curr.Name, alliance.TotalRelicsIncome, alliance.TotalRelics), session);
                    player.UpdateStorage();
                    persistance.Update(player.Storage);
                    Console.WriteLine("\t\t{0}: {1} {2}", player.Name, share, curr.Name);
                }
            }
        }

        private static IResourceInfo GetCurrResourceInfo()
        {
            IResourceInfo[] res = { Argon.Resource, Astatine.Resource, Cryptium.Resource, Radon.Resource, Prismal.Resource };
            return res[DateTime.Now.DayOfYear % res.Length];
        }

        public static Dictionary<AllianceRank, double> GetRelicShare(AllianceStorage alliance)
        {
            Dictionary<AllianceRank, double> dic = new Dictionary<AllianceRank, double>();
            Dictionary<AllianceRank, int> counts = new Dictionary<AllianceRank, int>();
            double total = 0;

            foreach (PlayerStorage player in alliance.Players) {
                if(!PlayerUtils.IsActive(player))
                {
                    continue;
                }
                AllianceRank rank = (AllianceRank)Enum.Parse(typeof(AllianceRank), player.AllianceRank);
                if (!counts.ContainsKey(rank)) {
                    counts.Add(rank, 1);
                } else {
                    ++counts[rank];
                }
            }

            foreach (KeyValuePair<AllianceRank, int> pair in counts) {
                total += pair.Value * GetScale(pair.Key);
            }

            foreach (KeyValuePair<AllianceRank, int> pair in counts) {
                double share = Convert.ToDouble(pair.Value * GetScale(pair.Key)) / total / pair.Value;
                dic.Add(pair.Key, share);
                Console.WriteLine("\t\t{2} {0}: {1}%", pair.Key, share * 100, pair.Value);
            }

            return dic;
        }

        private static int GetScale(AllianceRank allianceRank)
        {
            switch (allianceRank) {
                case AllianceRank.Admiral: return 4;
                case AllianceRank.ViceAdmiral: return 3;
                case AllianceRank.Corporal: return 2;
                case AllianceRank.Member: return 1;
                default: return 0;
            }
        }

        private static int GetTotalIncome(List<SectorStorage> ownedRelics, IList<SectorStorage> allRelics)
        {
            const int K = 300;
            double sum = 0;

            foreach (SectorStorage sector in ownedRelics) {
                int income = sector.Level * K;
                if (sector.IsInBattle) {
                    income /= 10;
                }
                sum += income;
            }

            return Convert.ToInt32(Math.Round(sum * (1 + ((double)ownedRelics.Count / (double)allRelics.Count))));
        }

        private static Dictionary<AllianceStorage, List<SectorStorage>> GroupByAlliance(IList<SectorStorage> list)
        {
            Dictionary<AllianceStorage, List<SectorStorage>> group = new Dictionary<AllianceStorage, List<SectorStorage>>();

            foreach (SectorStorage sector in list) {
                if (sector.Owner == null || sector.Owner.Alliance == null) {
                    continue;
                }
                if (!group.ContainsKey(sector.Owner.Alliance)) {
                    group.Add(sector.Owner.Alliance, new List<SectorStorage>());
                }
                group[sector.Owner.Alliance].Add(sector);
            }

            return group;
        }

        #endregion Income Processing

        #region Add Relics to Universe

        public static void AddRelics(int zoneLevel)
        {
            Dictionary<int, List<Coordinate>> coords = GetTargetSystems();
            foreach (Coordinate coord in coords[zoneLevel]) {
                Console.WriteLine("Checking coordinate {0}...", coord);
                ISystem system = UniversePersistance.LoadSystem(coord);
                if (AlreadyHasRelic(system)) {
                    Console.WriteLine("\tThis system already has a relic");
                    continue;
                }
                Coordinate lucky = GetEmptySectorCoordinate(system);
                if (lucky == null) {
                    Console.WriteLine("\tNo empty coordinate found... continuing");
                    continue;
                }
                Console.WriteLine("\tEmpty space: {0}", lucky);
                Sector sector = new RelicSector(coord, lucky, zoneLevel);
                GameEngine.Persist(sector, true, true);
            }
        }

        private static Coordinate GetEmptySectorCoordinate(ISystem system)
        {
            foreach (Coordinate lucky in SectorUtils.GenerateSectorCoordinates()) {
                if( !IsOccupied(system, lucky)) {
                    return lucky;
                }
            }
            return null;
        }

        private static bool IsOccupied(ISystem system, Coordinate lucky)
        {
            foreach (ISector sector in system.Sectors.Values) {
                if (sector.Coordinate.Sector == lucky && sector.Type != "NormalSector") {
                    return true;
                }
            }
            return false;
        }

        private static bool AlreadyHasRelic(ISystem system)
        {
            foreach (ISector sector in system.Sectors.Values) {
                if (sector.Type == RelicSectorType) {
                    return true;
                }
            }
            return false;
        }

        private static Dictionary<int, List<Coordinate>> GetTargetSystems()
        {
            Dictionary<int, List<Coordinate>> dic = new Dictionary<int, List<Coordinate>>();

            dic.Add(10, new List<Coordinate>());
            dic[10].Add(new Coordinate(17, 19));
            dic[10].Add(new Coordinate(19, 17));
            dic[10].Add(new Coordinate(19, 21));
            dic[10].Add(new Coordinate(21, 19));

            dic.Add(9, new List<Coordinate>());
            dic[9].Add(new Coordinate(14, 19));
            dic[9].Add(new Coordinate(14, 24));
            dic[9].Add(new Coordinate(14, 14));
            dic[9].Add(new Coordinate(24, 19));
            dic[9].Add(new Coordinate(24, 24));
            dic[9].Add(new Coordinate(24, 14));
            dic[9].Add(new Coordinate(19, 14));
            dic[9].Add(new Coordinate(19, 24));

            return dic;
        }

        #endregion Add Relics to Universe

    };
}

