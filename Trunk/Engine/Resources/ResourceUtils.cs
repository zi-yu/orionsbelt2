using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using System.IO;
using OrionsBelt.RulesCore;
using OrionsBelt.Engine.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.Engine.Actions;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Results;

namespace OrionsBelt.Engine.Resources {

    public static class ResourceUtils {

        #region Load/Store 

        public static ResourceState GetState(string stateName)
        {
            return (ResourceState) Enum.Parse(typeof(ResourceState), stateName);
        }

        #endregion Load/Store

        #region ResourceList Load/Store

        public static string SerializeResourceList(ResourceList list)
        {
            using (TextWriter writer = new StringWriter()) {

                foreach (IPlanetResource resource in list.Resources) {
                    writer.Write(resource.Info.Name);
                    writer.Write(",");
                    writer.Write(resource.State);
                    writer.Write(",");
                    writer.Write(resource.Level);
                    writer.Write(",");
                    writer.Write(resource.Quantity);
                    writer.Write(";");
                }

                return writer.ToString();
            }
        }

        private static readonly char[] ResourceSeparator = {';'};
        private static readonly char[] ResourcePropertySeparator = { ',' };

        public static ResourceList DeserializeResourceList(string data)
        {
            try {
                ResourceList list = new ResourceList();

                if (string.IsNullOrEmpty(data)) {
                    return list;
                }

                string[] parts = data.Split(ResourceSeparator, System.StringSplitOptions.RemoveEmptyEntries);

                foreach (string part in parts) {
                    DeserializeResource(list, part);
                }

                return list;
            } catch( Exception ex ) {
                throw new EngineException(ex, "Error deserializing ResourceList");
            }
        }

        private static void DeserializeResource(ResourceList list, string part)
        {
            try {

                string[] props = part.Split(ResourcePropertySeparator, StringSplitOptions.RemoveEmptyEntries);
                IPlanetResource resource = CreateResource(props);
                list.DirectAdd(resource);

            } catch (Exception ex) {
                throw new EngineException(ex, "Error parsing `{0}'", part);
            }
        }

        private static IPlanetResource CreateResource(string[] props)
        {
            string rawType = GetRawResourceProperty(props, 0);
            string rawState = GetRawResourceProperty(props, 1);
            string rawLevel = GetRawResourceProperty(props, 2);
            string rawQuantity = GetRawResourceProperty(props, 3);

            IResourceInfo type = RulesUtils.GetResource(rawType);

            PlanetResource resource = new PlanetResource(type);

            resource.Level = int.Parse(rawLevel);
            resource.Quantity = int.Parse(rawQuantity);
            resource.State = GetState(rawState);

            return resource;
        }

        private static string GetRawResourceProperty(string[] props, int pos)
        {
            if (props.Length == 0 || props.Length <= pos) {
                throw new EngineException("Error getting property at position `{0}' Length: `{1}'", pos, props.Length);
            }
            return props[pos];
        }

        #endregion ResourceList Load/Store

        #region Get/Set Resources

        internal static Player ResolvePlayer(IResourceOwner owner)
        {
            return (Player)owner.Owner;
        }

        public static IResourceOwner ResolveOwner(IResourceOwner owner, IResourceInfo info)
        {
            return ResolveOwner(owner, info.Type);
        }

        public static IResourceOwner ResolveOwner(IResourceOwner owner, ResourceType resourceType)
        {
            if (resourceType != ResourceType.Intrinsic) {
                return owner;
            }

            if (owner.HasOwner) {
                return owner.Owner;
            }

            return owner;
        }

        public static ResourceList GetResourcesByType(IResourceOwner owner, ResourceType resourceType)
        {
            owner = ResolveOwner(owner, resourceType);
            if (owner.Resources.ContainsKey(resourceType)) {
                return owner.Resources[resourceType];
            }
            ResourceList list = new ResourceList();
            owner.Resources.Add(resourceType, list);
            return list;
        }

        public static IPlanetResource GetResource(int storageId)
        {
            IPlayer player = PlayerUtils.Current;
            if (player == null) {
                throw new EngineException("No current player found");
            }
            foreach (IPlanetResource resource in GetAllPlayerResources(player)) {
                if (resource.Storage.Id == storageId) {
                    return resource;
                }
            }
            throw new EngineException("No resource with id `{0}' found at player {1}", storageId, player);
        }

        private static IEnumerable<IPlanetResource> GetAllPlayerResources(IPlayer player)
        {
            foreach (IPlanet planet in player.Planets) {
                foreach (IPlanetResource resource in GetResources(planet)) {
                    yield return resource;
                }
            }
            foreach (IPlanetResource resource in GetResources(player)) {
                yield return resource;
            }
        }

        public static IEnumerable<KeyValuePair<IResourceInfo,int>> GetAuctionHouseResources(IPlayer player)
        {
            foreach( KeyValuePair<IResourceInfo,int> pair in player.IntrinsicQuantities ) {
                if (!pair.Key.Conceptual && !pair.Key.IsTradeRouteSpecific)
                {
                    yield return pair;
                }
            }
        }

        public static bool IsAvailableToPlayer(IPlayer player, IResourceInfo resource)
        {
            foreach (Race race in resource.Races) {
                if (race == Race.Global || race == player.RaceInfo.Race) {
                    return true;
                }
            }
            return false;
        }

        public static IPlanetResource GetResource(IResourceOwner owner, int storageId)
        {
            foreach (IPlanetResource resource in GetResources(owner)) {
                if (resource.Storage.Id == storageId) {
                    return resource;
                }
            }

            throw new EngineException("No planet resource with id {0} found", storageId);
        }

        public static IPlanetResource GetResource(IResourceOwner owner, IResourceInfo resource)
        {
            IList<IPlanetResource> resources = GetResources(owner, resource);
            if (resource.Type == ResourceType.Facility) {
                foreach (IPlanetResource facility in resources) {
                    if (facility.State == ResourceState.Running) {
                        return facility;
                    }
                }
                return PlanetResource.Create(owner, resource, 0);
            }
            if (resources.Count != 1 ) {
                IPlanetResource res = PlanetResource.Create(owner, resource, 1);
                res.IsTemplate = true;
                return res;
            }
            return resources[0];
        }

        public static IEnumerable<IPlanetResource> GetResources(IResourceOwner owner)
        {
            foreach(ResourceList list in owner.Resources.Values ) {
                foreach (IPlanetResource resource in list.Resources) {
                    yield return resource;
                }
            }
        }

        public static IList<IPlanetResource> GetResources(IResourceOwner owner, IResourceInfo resource)
        {
            return GetResourcesByType(owner, resource.Type).Get(resource);
        }

        public static int MaxResourceLevel(IResourceOwner owner, IResourceInfo info)
        {
            int max = 0;

            foreach (IPlanetResource resource in GetResources(owner, info)) {
                if (IsAvailable(resource) && resource.Level > max) {
                    max = resource.Level;
                }
            }

            return max;
        }

        public static bool IsAvailable(IPlanetResource resource)
        {
            return !IsUnavailable(resource) && resource.Quantity > 0;
        }

        public static bool IsUnavailable(IPlanetResource resource)
        {
            return resource.State == ResourceState.InQueue ||
                resource.State == ResourceState.InConstruction ||
                resource.State == ResourceState.UnAvailable ||
                resource.State == ResourceState.Deleted;
            
        }

        public static bool HasResourceLevel(IResourceOwner owner, IResourceInfo resource, int level)
        {
            return MaxResourceLevel(owner, resource) >= level;
        }

        public static void AddResource(IResourceOwner owner, IPlanetResource resource)
        {
            AddOrAcumulateResource(owner, resource);
        }

        private static void DirectAddResource(IResourceOwner owner, IPlanetResource resource)
        {
            GetResourcesByType(owner, resource.Info.Type).DirectAdd(resource);
            resource.Owner = owner;
            ResourceUtils.PrepareStorageRelation(resource);
        }

        private static void AddOrAcumulateResource(IResourceOwner owner, IPlanetResource resource)
        {
            IList<IPlanetResource> inPlanet = GetResources(owner, resource.Info);
            if (inPlanet.Count == 0 || !IsResourceAvailable(resource) || (resource.Info.Type == ResourceType.Facility)) {
                DirectAddResource(owner, resource);
                return;
            }

            if (inPlanet.Count == 1 ) {
                inPlanet[0].Quantity += resource.Quantity;
            }
        }

        public static bool IsResourceAvailable(IPlanetResource resource)
        {
            if (resource == null) {
                return false;
            }
            return resource.State == ResourceState.Available || resource.State == ResourceState.Running;
        }

        public static void RemoveQuantity(IResourceOwner owner, IResourceInfo resource, int quantity)
        {
            AddQuantity(owner, resource, quantity * -1);
        }

        public static bool IsResourceAvailable(IResourceOwner owner, IResourceInfo resourceInfo, int quantity)
        {
            if (resourceInfo.Type == ResourceType.Intrinsic) {
                return owner.Owner.GetQuantity(resourceInfo) >= quantity;
            }

            owner = ResolveOwner(owner, resourceInfo);
            IPlanetResource resource = GetResource(owner, resourceInfo);

            if (resource == null) {
                return false;
            }

            return resource.Quantity >= quantity;
        }

        public static void ClearResources(IResourceOwner owner)
        {
            foreach (ResourceList list in owner.Resources.Values) {
                list.Clear();
            }
        }

        #endregion Get/Set Resources

        #region Quantities

        public static int AvailableCapacity(IPlayer player, IResourceInfo info)
        {
            int limit = player.GetLimit(null);
            int quantity = player.GetQuantity(info);

            return limit - quantity;
        }

        public static int AddQuantity(IResourceOwner owner, IResourceInfo resource, int quantity)
        {
            Player player = ResolvePlayer(owner);
            PrepareResourceOnPlayer(resource, player);

            int availableSpace = AvailableCapacity(player, resource);
            if( quantity > availableSpace ){
                quantity = availableSpace;
            }

            player.IntrinsicQuantities[resource] += quantity;
            player.Touch();

            return quantity;
        }

        private static void PrepareResourceOnPlayer(IResourceInfo resource, Player player)
        {
            if (!player.IntrinsicQuantities.ContainsKey(resource)) {
                player.IntrinsicQuantities.Add(resource, 0);
            }
        }

        public static void SetQuantity(IResourceOwner owner, IResourceInfo resource, int quantity)
        {
            Player player = ResolvePlayer(owner);
            PrepareResourceOnPlayer(resource, player);

            player.IntrinsicQuantities[resource] = quantity;
            player.Touch();
        }

        public static int GetQuantity(IResourceOwner owner, IResourceInfo resource)
        {
            Player player = ResolvePlayer(owner);
            PrepareResourceOnPlayer(resource, player);

            return player.IntrinsicQuantities[resource];
        }

        #endregion Quantities

        #region Resource Construction

        public static void Initialize(IPlayer player)
        {
            InitializeIntrinsic(player, 0);
        }

        public static void Initialize(IPlanet planet)
        {
            InitializeUnit(planet, 0);
            InitializeFacility(planet, 0);
        }

        public static void FullInitialize(IResourceOwner owner, int quantity)
        {
            InitializeIntrinsic(owner, quantity);
            InitializeUnit(owner, quantity);
            InitializeFacility(owner, quantity);
        }

        public static void InitializeUnit(IResourceOwner owner, int quantity)
        {
            foreach (IUnitInfo info in RulesUtils.GetUnitResources()){
                IPlanetResource resource = PlanetResource.Create(owner, info, quantity);
                resource.IsTemplate = true;
            }
        }

        public static void InitializeFacility(IResourceOwner owner, int quantity)
        {
            foreach (IFacilityInfo info in RulesUtils.GetFacilityResources(owner)){
                IPlanetResource facility = PlanetResource.Create(owner, info, quantity);
                facility.IsTemplate = true;
                facility.State = info.InitialState;
            }
        }

        public static IResourceOwner InitializeIntrinsic(IResourceOwner owner, int quantity)
        {
            owner = ResolveOwner(owner, ResourceType.Intrinsic);
            foreach (IIntrinsicInfo info in RulesUtils.GetIntrinsicResources()){
                owner.SetQuantity(info, 0);
            }
            owner.SetQuantity(ProductionSpace.Resource, 1);
            owner.SetQuantity(QueueSpace.Resource, 1);
            return owner;
        }

        public static int GetResourceQuantity(IResourceOwner owner, Type type)
        {
            return owner.GetQuantity(RulesUtils.GetResource(type));
        }

        public static Result CanQueue(IResourceOwner owner, IPlanetResource resource, int quantity)
        {
            Result result = new Result();

            IPlanet planet = (IPlanet) owner;

            if (!resource.Info.IsBuildable) {
                return Result.Fail;
            }

            result.Merge( QueueUtils.CanQueue(planet, resource) );
            result.Merge( resource.Info.CheckCost(owner, resource, quantity) );

            return result;
        }

        public static IEnumerable<IPlanetResource> GetResourcesInProduction(IResourceOwner owner)
        {
            foreach (IPlanetResource resource in GetResourcesInProduction(owner, ResourceType.Facility)) {
                yield return resource;
            }
            foreach (IPlanetResource resource in GetResourcesInProduction(owner, ResourceType.Unit)) {
                yield return resource;
            }
        }

        public static IList<IPlanetResource> GetResourcesInProduction(IResourceOwner owner, ResourceType resourceType)
        {
            ResourceList list = ResourceUtils.GetResourcesByType(owner, resourceType);
            List<IPlanetResource> inconstruction = list.Get(ResourceState.InConstruction);
            return inconstruction;
        }

        internal static void CancelProduction(Planet planet, IPlanetResource resource)
        {
            if (resource.Level > 1) {
                --resource.Level;
                resource.State = ResourceState.Running;
            } else {
                resource.State = ResourceState.Deleted;
            }
        }

        internal static void CheckProductionQueue(IPlayer player)
        {
            foreach (IPlanet planet in player.Planets) {
                ProcessProductionQueue(planet);
            }
        }

        internal static void ProcessProductionQueue(IPlanet planet)
        {
            ProcessProductionQueue(planet, ResourceType.Unit);
            ProcessProductionQueue(planet, ResourceType.Facility);
        }

        private static void ProcessProductionQueue(IPlanet planet, ResourceType type)
        {
            if (GetResourcesInProduction(planet, type).Count >= GetTotalProductionSpace(planet)){
                return;
            }

            IPlanetResource resource = QueueUtils.GetNextResourceToProduction(planet, type);
            if (resource == null) {
                return;
            }

            AddResourceToProduction(resource);
        }

        public static void AddResourceToProduction(IPlanetResource resource)
        {
            resource.State = ResourceState.InConstruction;
            Update(resource);
            ActionUtils.RegisterResourceConstruction(resource);
        }

        public static void Delete(IPlanetResource resource)
        {
            using (IPlanetResourceStoragePersistance persistance = Persistance.Instance.GetPlanetResourceStoragePersistance()) {
                persistance.Delete(resource.Storage);
            }
        }

        public static void Update(IPlanetResource resource)
        {
            resource.PrepareStorage();
            using (IPlanetResourceStoragePersistance persistance = Persistance.Instance.GetPlanetResourceStoragePersistance()) {
                persistance.Update(resource.Storage);
            }
        }

        public static void Update(IPlanet planet)
        {
            planet.PrepareStorage();
            using (IPlanetStoragePersistance persistance = Persistance.Instance.GetPlanetStoragePersistance()) {
                persistance.Update(planet.Storage);
            }
        }

        public static int GetTotalProductionSpace(IResourceOwner owner)
        {
            owner = ResolveOwner(owner, ResourceType.Intrinsic);
            return owner.GetQuantity(ProductionSpace.Resource);
        }

        public static int GetDuration(IPlanetResource resource)
        {
            return resource.Info.GetBuildDuration(resource.Owner, resource);
        }

        public static bool IsBuildAvailable(IPlanet planet, IResourceInfo info)
        {
            return info.IsBuildAvailable(planet).Ok;
        }

        internal static Result IsUpgradeAvailable(Planet planet, IPlanetResource resource)
        {
            Result result = new Result();

            if (resource.Level >= resource.Info.MaxLevel) {
                return Result.Create(new AlreadyAtMaxLevelResult(resource));
            }

            PlanetResource res = new PlanetResource(resource);
            res.IsTemplate = true;
            ++res.Level;

            result.Merge( QueueUtils.CanQueue(planet, res) );
            result.Merge( resource.Info.CheckCost(planet, res, 1) );

            res.State = ResourceState.UnAvailable;

            return result;
        }

        internal static void CheckCompleted(IPlayer player)
        {
            foreach(IPlanet planet in player.Planets ) {
                foreach (IPlanetResource resource in GetResourcesInProduction(planet)) {
                    if (player.LastProcessedTick >= resource.EndTick) {
                        resource.State = ResourceState.Complete;
                        resource.OnComplete();
                    }
                }
            }
        }

        internal static Result CanDestroy(IPlanet planet, IPlanetResource resource)
        {
            if (resource.Info.Type != ResourceType.Facility) {
                return Result.Fail;
            }
            if (resource.State != ResourceState.Running) {
                return Result.Create(new InvalidResourceState());
            }
            if (resource.Slot.SupportedFacilities.Count > 1) {
                return Result.Success;
            }
            return Result.Fail;
        }

        internal static void Destroy(IPlanet planet, IPlanetResource resource)
        {
            resource.State = ResourceState.Destroyed;
            resource.Info.OnDestroy(resource);
            resource.Slot = null;
        }

        public static bool CanBuildUnits(IPlanet planet)
        {
            return planet.Info.GetUnitBuilderFacility() != null;
        }

        #endregion Resource Construction

        #region References

        internal static IPlayer GetPlayer(IPlanetResource resource)
        {
            if (resource.Owner is IPlayer) {
                return (IPlayer)resource.Owner;
            }

            if (resource.Owner is IPlanet){
                return ((IPlanet)resource.Owner).Owner;
            }

            throw new EngineException("Can't resolve player for resource `{0}'", resource);
        }

        public static void PrepareStorageRelation(IPlanetResource resource)
        {
            resource.PrepareStorage();
            if (resource.Storage.Planet != null || resource.Storage.Player != null) {
                return;
            }
            if (resource.HasOwner) {
                IPlanet ownerPlanet = resource.Owner as IPlanet;
                IPlayer ownerPlayer = resource.Owner as IPlayer;
                if (ownerPlanet != null){
                    ownerPlanet.PrepareStorage();
                    resource.Storage.Planet = ownerPlanet.Storage;
                    ownerPlanet.Storage.Resources.Add(resource.Storage);
                } else if(ownerPlayer != null) {
                    ownerPlayer.PrepareStorage();
                    resource.Storage.Player = ownerPlayer.Storage;
                    ownerPlayer.Storage.Resources.Add(resource.Storage);
                } else {
                    resource.Storage.Planet = null;
                    resource.Storage.Player = null;
                }
            }
        }

        #endregion References

        #region IModifierHandler helpers

        public static void AddToModifier(IModifierHandler owner, IResourceInfo info, int change)
        {
            if (!owner.Modifiers.ContainsKey(info)) {
                owner.Modifiers.Add(info, 0);
            }
            owner.Modifiers[info] += change;
        }

        public static void ProcessModifiers(IPlayer player)
        {
            foreach (IPlanet planet in player.Planets) {
                foreach (KeyValuePair<IResourceInfo, int> pair in planet.Modifiers) {
                    int perTick = planet.GetPerTick(pair.Key);
                    planet.AddQuantity(pair.Key, perTick);
                }
            }
            LimitIntrinsic(player);
        }

        public static void LimitIntrinsic(IPlayer player)
        {
            Dictionary<IResourceInfo, int> trims = new Dictionary<IResourceInfo, int>();

            int max = player.GetLimit(null);
            if (max < 0) {
                return;
            }

            foreach (KeyValuePair<IResourceInfo, int> quant in player.IntrinsicQuantities) {
                if (quant.Value > max) {
                    trims.Add(quant.Key, max);
                }
            }

            foreach (KeyValuePair<IResourceInfo, int> quant in trims)  {
                player.SetQuantity(quant.Key, quant.Value);
            }
        }

        public static int GetPerTick(IPlanet planet, IResourceInfo resource)
        {
            int richness = planet.GetRichness(resource);
            int raw = planet.GetModifier(resource);
            double value = richness * raw;

            return (int) Math.Ceiling(value / 100);
        }

        public static int GetPerTick(IPlayer player, IResourceInfo resource)
        {
            int sum = 0;
            foreach (IPlanet planet in player.Planets) {
                sum += GetPerTick(planet, resource);
            }
            return sum;
        }

        #endregion IModifierHandler helpers

        #region Utilities

        public static bool HasUnitsAvailable(IPlanet planet)
        {
            IFacilityInfo info = planet.Info.GetUnitBuilderFacility();
            if (info == null) {
                return false;
            }
            return planet.HasResourceLevel(info, 1);
        }

        public static int GetMaxQuantityToBuild(IPlayer player, IResourceWithRulesInfo info)
        {
            Dictionary<IResourceInfo, int> costs = new Dictionary<IResourceInfo, int>();
            int level = 1;
            foreach (IRule rule in info.Rules.GetRulesByState(ResourceState.InQueue)) {
                Cost cost = rule as Cost;
                if (cost != null ) {
                    RuleArgs args = new RuleArgs();
                    args.ResourceOwner = player;
                    args.TargetLevel = level;
                    int resourceCost = cost.GetCost(args);
                    if (resourceCost > 0) {
                        costs.Add(cost.CostResource, resourceCost);
                    }
                }
            }

            int max = int.MaxValue;
            foreach (KeyValuePair<IResourceInfo, int> pair in costs) {
                int available = player.GetQuantity(pair.Key);
                int units = available / pair.Value;
                if (units < max) {
                    max = units;
                }
            }

            return max;
        }

        #endregion Utilities

        #region Units

        public static List<PlayersUnits> GetPlayersUnits(IList<Fleet> fleets)
        {
            List<PlayersUnits> toReturn = new List<PlayersUnits>();

            PlayersUnits info = null;
            for(int iter = 0; iter < fleets.Count; ++iter)
            {
                if (0 == iter)
                {
                    info = new PlayersUnits(fleets[iter].PlayerOwner.Id, fleets[iter].PlayerOwner.Name);
                }
                else
                {
                    if(fleets[iter].PlayerOwner.Id != fleets[iter-1].PlayerOwner.Id)
                    {
                        toReturn.Add(info);
                        info = new PlayersUnits(fleets[iter].PlayerOwner.Id, fleets[iter].PlayerOwner.Name);
                    }
                }
                info.AddUnits(fleets[iter]);
            }
            return toReturn;
        }

        public static Result CanBuildUltimateUnit(IPlayer player, int quantity)
        {
            Result result = new Result();

            if (quantity != 1) {
                result.Add( new QuantityRestrictionResult(player, quantity, 1));
                return result;
            }

            int currentUltimates = GetOwnedUltimateUnits(player);
            int currentUltimateFacilities = GetOwnedUltimageUnitFacilities(player);
            result.Add(new UltimateRestrictionResult(player, currentUltimates, currentUltimateFacilities));

            return result;
        }

        private static int GetOwnedUltimageUnitFacilities(IPlayer player)
        {
            return Convert.ToInt32(Hql.ExecuteScalar("select count(res) from SpecializedPlayerStorage player inner join player.PlanetsNHibernate planet inner join planet.ResourcesNHibernate res where player.Id = :id and (res.Type = 'BlinkerAssembler' or res.Type = 'QueenHatchery' or res.Type = 'BattleMoonAssembler') and res.Level > 0", Hql.Param("id", player.Id)));
        }

        private static int GetOwnedUltimateUnits(IPlayer player)
        {
            int actual = Convert.ToInt32(Hql.ExecuteScalar("select count(fleet) from SpecializedPlayerStorage player inner join player.FleetsNHibernate fleet where player.Id = :id and fleet.UltimateUnit is not null and fleet.UltimateUnit <> ''", Hql.Param("id", player.Id)));
            int building = Convert.ToInt32(Hql.ExecuteScalar("select count(res) from SpecializedPlayerStorage player inner join player.PlanetsNHibernate planet inner join planet.ResourcesNHibernate res where player.Id = :id and (res.Type = 'Blinker' or res.Type = 'Queen' or res.Type = 'BattleMoon') and res.Level = 1", Hql.Param("id", player.Id)));

            return actual + building;
        }

        #endregion Units

    };
}
