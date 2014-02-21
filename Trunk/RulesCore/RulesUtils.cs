using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using DesignPatterns;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.RulesCore {

    /// <summary>
    /// Utility Methods
    /// </summary>
    public static class RulesUtils {

        #region Static Fields

        private static FactoryContainer resourceFactory = new FactoryContainer(typeof(BaseResource));
        private static List<IResourceInfo> resources = new List<IResourceInfo>();

        static RulesUtils()
        {
            foreach (IFactory factory in resourceFactory.Values) {
                BaseResource baseResource = (BaseResource)factory.create(null);
                resources.Add(baseResource);
            }

            foreach (BaseResource resource in resources)  {
                resource.Init();
            }

            if (resources.Count != resourceFactory.Count) {
                throw new RulesException("Not all resoures loaded!");
            }
        }

        public static FactoryContainer GetFactory() 
        {
            return resourceFactory;
        }

        public static int TotalResourceCount {
            get { return GetResources().Count; }
        }

        public static int TotalIntrinsicCount {
            get { return GetIntrinsicResources().Count; }
        }

        public static int TotalUnitCount {
            get { return GetUnitResources().Count; }
        }

        public static int TotalFacilityCount {
            get { return GetFacilityResources().Count; }
        }

        #endregion Static Fields

        #region Resources By Type

        /// <summary>
        /// Returns all available resources
        /// </summary>
        /// <returns>All resources</returns>
        public static List<IResourceInfo> GetResources()
        {
            return resources;
        }

        /// <summary>
        /// Returns all auction house resources
        /// </summary>
        /// <returns>All resources</returns>
        public static List<IResourceInfo> GetAuctionHouseResources()
        {
            List<IResourceInfo> toReturn = new List<IResourceInfo>();
            foreach (IResourceInfo info in resources)
            {
                if(!info.Conceptual && (info.Type == ResourceType.Intrinsic || info.Type == ResourceType.Unit))
                {
                    toReturn.Add(info);
                }
            }
            return toReturn;
        }

        /// <summary>
        /// Returns all auction house resources
        /// </summary>
        /// <returns>All resources</returns>
        public static List<IResourceInfo> GetIntrinsicNonConceptualResources()
        {
            List<IResourceInfo> toReturn = new List<IResourceInfo>();
            foreach (IResourceInfo info in resources) {
                if (info.IsResourceCost) {
                    toReturn.Add(info);
                }
            }
            return toReturn;
        }

		/// <summary>
		/// Returns all intrinsic resources
		/// </summary>
		/// <returns>All resources</returns>
		public static List<IResourceInfo> GetInstrinsicResources() {
			List<IResourceInfo> intrinsicResources = new List<IResourceInfo>();
			List<IResourceInfo> resourceInfos = GetResources(ResourceType.Intrinsic);
			foreach( IResourceInfo info in resourceInfos ) {
				if( !info.Conceptual ) {
					intrinsicResources.Add(info);
				}
			}
			return intrinsicResources;
		}

        public static List<IResourceInfo> GetInstrinsicResources(IPlayer player)
        {
            List<IResourceInfo> intrinsicResources = new List<IResourceInfo>();

            foreach (IResourceInfo info in GetInstrinsicResources()) {
                if (MatchRace(info.Races, player)) {
                    intrinsicResources.Add(info);
                }
            }

            intrinsicResources.Sort(CompareResources);

            return intrinsicResources;
        }

        public static int CompareResources(IResourceInfo r1, IResourceInfo r2)
        {
            if (r1.IsRare != r2.IsRare) {
                if (r1.IsRare) {
                    return 1;
                }
                return -1;
            }
            return r1.Name.CompareTo(r2.Name);
        }

		public static List<IResourceInfo> GetBasicResources(IPlayer player) {
			List<IResourceInfo> intrinsicResources = new List<IResourceInfo>();

			foreach (IResourceInfo info in GetInstrinsicResources()) {
				if (MatchRace(info.Races, player) && !info.IsRare) {
					intrinsicResources.Add(info);
				}
			}

			return intrinsicResources;
		}

        public static List<IResourceInfo> GetResources(ResourceType type)
        {
            return resources.FindAll(delegate(IResourceInfo res) { return res.Type == type; });
        }

        /// <summary>
        /// Returns all intrinsic resources
        /// </summary>
        /// <returns>All intrinsic</returns>
        public static List<IIntrinsicInfo> GetIntrinsicResources()
        {
            List<IIntrinsicInfo> list = new List<IIntrinsicInfo>();

            foreach (IResourceInfo info in GetResources()) {
                IIntrinsicInfo intrinsic = info as IIntrinsicInfo;
                if (intrinsic != null) {
                    list.Add(intrinsic);
                }
            }

            return list;
        }

		/// <summary>
		/// Returns all intrinsic resources
		/// </summary>
		/// <returns>All intrinsic</returns>
		public static List<IIntrinsicInfo> GetRareResources() {
			List<IIntrinsicInfo> list = new List<IIntrinsicInfo>();

			foreach (IResourceInfo info in GetResources()) {
				IIntrinsicInfo intrinsic = info as IIntrinsicInfo;
				if (intrinsic != null && intrinsic.IsRare) {
					list.Add(intrinsic);
				}
			}

			return list;
		}

        /// <summary>
        /// Returns all trade resources
        /// </summary>
        /// <returns>All trade resources</returns>
        public static List<IIntrinsicInfo> GetTradeResources()
        {
            List<IIntrinsicInfo> list = new List<IIntrinsicInfo>();

            foreach (IResourceInfo info in GetResources())
            {
                IIntrinsicInfo intrinsic = info as IIntrinsicInfo;
                if (intrinsic != null)
                {
                    if (intrinsic.IsTradeRouteSpecific)
                    {
                        list.Add(intrinsic);
                    }
                }
            }

            list.Sort(delegate(IIntrinsicInfo c1, IIntrinsicInfo c2) 
                    {
                        return c1.Name.CompareTo(c2.Name);
                    });

            return list;
        }

        /// <summary>
        /// Returns all facility resources
        /// </summary>
        /// <returns>All facility</returns>
        public static List<IFacilityInfo> GetFacilityResources()
        {
            List<IFacilityInfo> list = new List<IFacilityInfo>();

            foreach (IResourceInfo info in GetResources()) {
                IFacilityInfo facility = info as IFacilityInfo;
                if (facility != null) {
                    list.Add(facility);
                }
            }

            return list;
        }

        /// <summary>
        /// Gets the facilities of the given owner
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static List<IFacilityInfo> GetFacilityResources(IResourceOwner owner)
        {
            IPlanet planet = GetPlanet(owner);

            List<IFacilityInfo> list = new List<IFacilityInfo>();

            foreach (IResourceInfo info in GetResources()) {
                IFacilityInfo facility = info as IFacilityInfo;
                if (facility != null && MatchRace(facility.Races, planet)) {
                    list.Add(facility);
                }
            }

            return list;
        }

        private static IPlanet GetPlanet(IResourceOwner owner)
        {
            IPlanet planet = owner as IPlanet;
            if (planet == null) {
                throw new RulesException("Onwer is not planet, ist: {0}", owner);
            }
            return planet;
        }

        /// <summary>
        /// Checks if the given race matches the races array
        /// </summary>
        /// <param name="races"></param>
        /// <param name="race"></param>
        /// <returns></returns>
        public static bool MatchRace(Race[] races, Race race)
        {
            foreach (Race r in races) {
                if (r == Race.Global || r == race) {
                    return true;
                }
            }
            return false;
        }

        public static bool MatchRace(Race[] races, IRaceInfo race)
        {
            if (race == null) {
                return true;
            }
            return MatchRace(races, race.Race);
        }

        public static bool MatchRace(Race[] races, IPlayer player)
        {
            if (player == null) {
                return true;
            }
            return MatchRace(races, player.RaceInfo);
        }

        public static bool MatchRace(Race[] races, IPlanet planet)
        {
            return MatchRace(races, planet.RaceInformation);
        }

        public static bool MatchRace(Race[] races, IPlanetInfo planet)
        {
            if( planet == null || planet.RaceInformation == null ) {
                return true;
            }
            return MatchRace(races, planet.RaceInformation);
        }

        /// <summary>
        /// Gets the player of the given Resource Owner
        /// </summary>
        /// <param name="owner">The  owner</param>
        /// <returns>The player</returns>
        public static IPlayer GetPlayer(IResourceOwner owner)
        {
            if (owner is IPlanet) {
                return ((IPlanet)owner).Owner;
            }
            if (owner is IPlayer) {
                return (IPlayer)owner;
            }
            throw new RulesException("Can't get player from owner {0}", owner);
        }

        /// <summary>
        /// Returns all unit resources
        /// </summary>
        /// <returns>All units</returns>
        public static List<IUnitInfo> GetUnitResources()
        {
            List<IUnitInfo> list = new List<IUnitInfo>();

            foreach (IResourceInfo info in GetResources()) {
                IUnitInfo unit = info as IUnitInfo;
                if (unit != null) {
                    list.Add(unit);
                }
            }

            return list;
        }

        public static IEnumerable<IUnitInfo> GetRaceUnits(IPlanet planet)
        {
            return GetRaceUnits(planet.Info);
        }

        public static IEnumerable<IUnitInfo> GetRaceUnits(IPlanetInfo info)
        {
            foreach (IUnitInfo unit in GetUnitResources()) {
                if (MatchRace(unit.Races, info.RaceInformation.Race)) {
                    yield return unit;
                }
            }
        }

        #endregion Resources By Name

        #region Resources By Name

        /// <summary>
        /// Gets a resource given its name
        /// </summary>
        /// <param name="name">The resource name</param>
        /// <returns>The resource</returns>
        public static IResourceInfo GetResource(string name)
        {
            IResourceInfo resource = (IResourceInfo) GetFactory().create(name);
            if (resource == null) {
                throw new RulesException("There is no resource with the name `{0}'", name);
            }
            return resource;
        }

        /// <summary>
        /// Gets a resource given its type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The resource</returns>
        public static IResourceInfo GetResource(Type type)
        {
            return GetResource(type.Name);
        }

        /// <summary>
        /// Gets a resource given its name
        /// </summary>
        /// <param name="name">The resource name</param>
        /// <returns>The IResourceWithRulesInfo</returns>
        public static IResourceWithRulesInfo GetResourceWithRules(string name)
        {
            IResourceWithRulesInfo resource = GetResource(name) as IResourceWithRulesInfo;
            if (resource == null) {
                throw new RulesException("Resource `{0}' is not IResourceWithRulesInfo", name);
            }
            return resource;
        }

        /// <summary>
        /// Gets a resource given its name
        /// </summary>
        /// <param name="type">The resource type</param>
        /// <returns>The IResourceWithRulesInfo</returns>
        public static IResourceWithRulesInfo GetResourceWithRules(Type type)
        {
            return GetResourceWithRules(type.Name);
        }

        /// <summary>
        /// Gets a unit intrinsic its name
        /// </summary>
        /// <param name="name">The intrinsic name</param>
        /// <returns>The intrinsic</returns>
        public static IIntrinsicInfo GetIntrinsic(string name)
        {
            IIntrinsicInfo resource = GetResource(name) as IIntrinsicInfo;
            if (resource == null) {
                throw new RulesException("Resource `{0}' is not intrinsic", name);
            }
            return resource;
        }

        /// <summary>
        /// Gets an intrinsic given its type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The intrinsic</returns>
        public static IIntrinsicInfo GetIntrinsic(Type type)
        {
            return GetIntrinsic(type.Name);
        }

        /// <summary>
        /// Gets a facility given its name
        /// </summary>
        /// <param name="name">The facility name</param>
        /// <returns>The facility</returns>
        public static IFacilityInfo GetFacility(string name)
        {
            IFacilityInfo resource = GetResource(name) as IFacilityInfo;
            if (resource == null) {
                throw new RulesException("Resource `{0}' is not a facility", name);
            }
            return resource;
        }

        /// <summary>
        /// Gets a facility given its type
        /// </summary>
        /// <param name="type">The facility type</param>
        /// <returns>The facility metadata</returns>
        public static IFacilityInfo GetFacility(Type type)
        {
            return GetFacility(type.Name);
        }

        /// <summary>
        /// Gets a unit given its name
        /// </summary>
        /// <param name="name">The unit name</param>
        /// <returns>The unit</returns>
        public static IUnitInfo GetUnit(string name)
        {
            IUnitInfo resource = GetResource(name) as IUnitInfo;
            if (resource == null) {
                throw new RulesException("Resource `{0}' is not a unit", name);
            }
            return resource;
        }

        #endregion Resources By Name

        #region Random Resources Utils

        private static Random randomResources = new Random(DateTime.Now.Millisecond);

        public static IResourceInfo GetRandomRareResource(IRaceInfo race)
        {
            int value = randomResources.Next(0, 100);

            if (value > 50) {
                return race.RichResource;
            }

            if (value <= 5) {
                return race.MoreNeededResource;
            }

            List<IResourceInfo> others = GetRareResourcesExcept(race.MoreNeededResource, race.RichResource);
            return others[randomResources.Next(0, others.Count)];
        }

		public static IResourceInfo GetRandomRareResource() {
			List<IIntrinsicInfo> rare = GetRareResources();
			return rare[randomResources.Next(0, rare.Count)];
		}

        public static List<IResourceInfo> GetRareResourcesExcept(params IIntrinsicInfo[] resources)
        {
            List<IResourceInfo> list = new List<IResourceInfo>();

            foreach(IResourceInfo info in GetInstrinsicResources() ) {
                if (!info.IsRare) {
                    continue;
                }
                if (!Array.Exists(resources, delegate(IIntrinsicInfo r) { return r.Name == info.Name; }))
                {
                    list.Add(info);
                }
            }

            return list;
        }

        public static IFacilityInfo GetRandomFacility()
        {
            IList<IFacilityInfo> list = GetFacilityResources();
            return list[ randomResources.Next(0, list.Count) ];
        }

        public static IUnitInfo GetRandomUnit()
        {
            IList<IUnitInfo> list = GetUnitResources();
            return list[randomResources.Next(0, list.Count)];
        }

        public static IIntrinsicInfo GetRandomIntrinsic()
        {
            IList<IIntrinsicInfo> list = GetIntrinsicResources();
            return list[randomResources.Next(0, list.Count)];
        }

        #endregion Random Resources Utils

        #region Generic Rules

        public static bool IsUpgrade(IPlanetResource resource)
        {
            return resource.Level > 1;
        }

        #endregion Generic Rules

        #region Get Rules

        public static IEnumerable<IRule> GetOnComplete(IResourceWithRulesInfo info)
        {
            foreach (IRule rule in info.Rules.GetRulesByState(ResourceState.Running)) {
                yield return rule;
            }
        }

        public static IEnumerable<KeyValuePair<IResourceInfo, int>> GetCost(IResourceWithRulesInfo info, IPlayer player, int level)
        {
            foreach (IRule rule in info.Rules.GetRulesByState(ResourceState.InQueue)) {
                Cost cost = rule as Cost;
                if (cost != null) {
                    RuleArgs args = new RuleArgs();
                    args.TargetLevel = level;
                    args.ResourceOwner = player;
                    int value = cost.GetCost(args);
                    if (value > 0) {
                        yield return new KeyValuePair<IResourceInfo, int>(cost.CostResource, value);
                    }
                }
            }
        }

        #endregion Get Rules

        #region Durations

        public static int GetBuildDuration(IResourceOwner owner, IResourceInfo info, int level, int quantity)
        {
            double productionFactor = 100;
            if (owner != null) {
                productionFactor = owner.FinalProductionFactor;
            }
            double raw = (productionFactor/100) * info.GetFixedBuildDuration(level, quantity);
            return (int)Math.Ceiling(raw);
        }

        #endregion Durations

    };

}
