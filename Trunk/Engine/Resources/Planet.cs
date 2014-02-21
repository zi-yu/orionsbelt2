using System;
using System.Collections.Generic;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Common;
using OrionsBelt.Generic;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Resources {

    /// <summary>
    /// This class represents a planet 
    /// </summary>
    public class Planet : CelestialBody, IPlanet {

		#region Fields

    	private IFleetInfo defenseFleet;

		#endregion;

        #region Ctor

        public Planet()
        {
             ResourceUtils.Initialize(this);
        }

        public Planet(IPlanetInfo planetInfo, ITerrainInfo terrainInfo)
        {
            Info = planetInfo;
            Terrain = terrainInfo;
            ResourceUtils.Initialize(this);
        }

		public Planet(string name) {
			Name = name;
			ResourceUtils.Initialize(this);
		}
 	       
		public Planet(IPlayer owner, string planetName)
 			: this(planetName) {
 	        owner.RegisterPlanet(this);
 	    }

        #endregion Ctor

		#region ICelestialBodyProperties

    	/// <summary>
    	/// if the sector was loaded
    	/// </summary>
    	public override bool HasLoadedSector {
    		get { return sector != null;}
    	}

		protected ISector sector = null;
		/// <summary>
		/// The planet's sector
		/// </summary>
		public override ISector Sector {
			get {
				if (sector == null && Storage.Sector != null) {
					if (Location.System.IsPrivateSystem()) {
						sector = Owner.PrivateSystem.GetSector(Location.Sector);
					} else {
						sector = SectorUtils.LoadSector(Storage.Sector);
					}
					sector.AddCelestialBody(this);
					sector.AddCelestialBody(DefenseFleet);
				}
				return sector;
			}
			set {
				Touch();
				sector = value;
				Location = sector.Coordinate;
			}
		}

		#endregion

        #region IPlanet Properties

        private string name;
        public string Name {
            get {
                if (string.IsNullOrEmpty(name)) {
                    return "(no name)";
                }
                return name; 
            }
            set {
                Touch();
                name = value; 
            }
        }

        private int score;
        public int Score {
            get { return score; }
            set {
                Touch();
                score = value; 
            }
        }

        private int level;
        public int Level {
            get { return level; }
            set {
                Touch();
                level = value; 
            }
        }

        private int facilityLevel;
        public int FacilityLevel {
            get { return facilityLevel; }
            set {
                Touch();
                facilityLevel = value; 
            }
        }

        public IRaceInfo RaceInformation {
            get {
                if (Info != null && Info.RaceInformation != null)  {
                    return Info.RaceInformation;
                }
                if (HasOwner) {
                    return Owner.RaceInfo;
                }
                return null;
            }
        }

        private IPlanetInfo info = null;
        public IPlanetInfo Info {
            get { return info; }
            set { info = value; Touch(); }
        }

        private ITerrainInfo terrain = null;
        public ITerrainInfo Terrain {
            get { return terrain; }
            set { terrain = value; Touch(); }
        }

		private bool isPrivate;
		public bool IsPrivate {
			get { return isPrivate; }
			set {
				Touch();
				isPrivate = value;
			}
		}

    	private List<IFleetInfo> fleets = null;
    	public List<IFleetInfo> Fleets {
    		get {
				if (fleets == null || fleets.Count == 0) {
					List<SectorCoordinate> coordinates = SectorUtils.GetPossibleCoordinates(Location,2);
					
					fleets = Owner.AllFleets.FindAll(
						delegate(IFleetInfo fleet) {
							if(fleet.CurrentPlanet != null && fleet.CurrentPlanet.Storage != null && fleet.CurrentPlanet.Storage.Id == storage.Id) {
								return true;
							}
							SectorCoordinate sc = coordinates.Find(
								delegate(SectorCoordinate s) {
									return s.Equals(fleet.Location);
										
								});
							return sc != null;
						}
					);
				}
				return fleets;
			}
    	}

		public IFleetInfo DefenseFleet {
			get {
				if( defenseFleet == null ) {
					if( fleets != null ) {
						defenseFleet = Fleets.Find(delegate(IFleetInfo fleet) { return fleet.IsPlanetDefenseFleet && fleet.CurrentPlanet.Storage.Id == Storage.Id; });	
					}
					if (defenseFleet == null && storage.Fleets.Count > 0) {
						defenseFleet = new FleetInfo(storage.Fleets[0],this);
					}
                    if (defenseFleet == null) { 
                        //CreateDefenseFleet
                    }
				}
				return defenseFleet;
			}
		}

        private int lastPillageTick;
        public int LastPillageTick {
            get { return lastPillageTick; }
            set {
                Touch();
                lastPillageTick = value;
            }
        }

        public bool CanPillage {
            get { return !(Clock.Instance.Tick < LastPillageTick + PlanetUtils.PlanetPillageDelay); }
        }

        private int lastConquerTick;
        public int LastConquerTick {
            get { return lastConquerTick; }
            set {
                Touch();
                lastConquerTick = value;
            }
        }

        public bool CanConquer {
            get {
                if(Server.IsInTests) {
                    return true;
                }
                return Clock.Instance.Tick < 200 || !(Clock.Instance.Tick < LastConquerTick + PlanetUtils.PlanetConquerDelay);
            }
        }

        #endregion IPlanet Properties

        #region IPlanetOwner Properties

        private Dictionary<ResourceType, ResourceList> resources = new Dictionary<ResourceType, ResourceList>();
        public Dictionary<ResourceType, ResourceList> Resources {
            get { return resources; }
        }

        public ResourceList Facilities {
            get { return ResourceUtils.GetResourcesByType(this, ResourceType.Facility); }
        }

        public ResourceList Intrinsic {
            get { return ResourceUtils.GetResourcesByType(this, ResourceType.Intrinsic); }
        }

        public ResourceList Units {
            get { return ResourceUtils.GetResourcesByType(this, ResourceType.Unit); }
        }

        private IPlayer owner = null;
        public IPlayer Owner {
            get { return owner; }
            set { owner = value; Touch(); }
        }

        public bool HasOwner {
            get { return Owner != null; }
        }

        private double productionFactor = 100;
        public double ProductionFactor {
            get { return productionFactor; }
            set {
                Touch();
                productionFactor = value; 
            }
        }

        public double FinalProductionFactor {
            get {
                if (HasOwner && Owner.HasService(ServiceType.BuyFastSpeed)) {
                    return ProductionFactor / 2;
                }
                return ProductionFactor; 
            }
        }

        #endregion IPlanetOwner Properties

        #region IPlanet Methods

        public void AddResource(IPlanetResource resource)
        {
            ResourceUtils.AddResource(this, resource);
        }

        public void RemoveQuantity(IResourceInfo resource, int quantity)
        {
            AddQuantity(resource, quantity * -1);
        }

        public int MaxResourceLevel(IResourceInfo info)
        {
            return ResourceUtils.MaxResourceLevel(this, info);
        }

        public bool HasResourceLevel(IResourceInfo resource, int level)
        {
            return ResourceUtils.HasResourceLevel(this, resource, level);
        }

        public IPlanetResource GetResource(IResourceInfo resource)
        {
            return ResourceUtils.GetResource(this, resource);
        }

        public IList<IPlanetResource> GetResources(IResourceInfo resource)
        {
            return ResourceUtils.GetResources(this, resource);
        }

        public bool IsResourceAvailable(IResourceInfo resource, int quantity)
        {
            return ResourceUtils.IsResourceAvailable(this, resource, quantity);
        }

        public Result IsDestroyAvailable(IPlanetResource resource)
        {
            return ResourceUtils.CanDestroy(this, resource);
        }

        public void Destroy(IPlanetResource resource)
        {
            ResourceUtils.Destroy(this, resource);
        }

        public bool HasFacilityAvailableForSlot(IFacilitySlot slot)
        {
            foreach (IFacilityInfo info in slot.SupportedFacilities) {
                if (info.IsBuildAvailable(this).Ok) {
                    return true;
                }
            }
            return false;
        }

        public void AddFacility(string slotIdentifier, IFacilityInfo info)
        {
            IFacilitySlot slot = Info.GetSlot(slotIdentifier);
            IPlanetResource resource = GetFacility(slot);
            if (resource != null) {
                return;
            }

            resource = GetResource(info);

            if (resource.Quantity > 0) {
                return;
            }

            resource.Slot = slot;
            resource.OnComplete();
            resource.IsTemplate = false;
        }

        public IPlanetResource GetFacility(IFacilitySlot slot)
        {
            foreach(IPlanetResource resource in ResourceUtils.GetResourcesByType(this, ResourceType.Facility).Resources ){
                if (resource.Slot != null && resource.Slot.Identifier == slot.Identifier && resource.State != ResourceState.Deleted && resource.State != ResourceState.UnAvailable) {
                    return resource;
                }
            }
            return null;
        }

		/// <summary>
		/// Add fleets to the planet
		/// </summary>
		/// <param name="list"></param>
		public void AddFleets(List<IFleetInfo> list) {
			fleets = list;
		}

		/// <summary>
		/// Add fleets to the planet
		/// </summary>
		/// <param name="fleet">fleet to add</param>
		public void AddFleet(IFleetInfo fleet) {
			Fleets.Add(fleet);
		}

		/// <summary>
		/// Gets the fleet with the passed id
		/// </summary>
		/// <param name="id">Id of the fleet to return</param>
		/// <returns>An object that represents the fleet with the passed id</returns>
		public IFleetInfo GetFleet(int id) {
			return Fleets.Find(delegate(IFleetInfo fleet) { return fleet.Id == id; });
		}

    	/// <summary>
		/// If the planet loaded fleets
		/// </summary>
		/// <returns>fleets</returns>
		public bool HasLoadedFleets() {
			return fleets != null && fleets.Count > 0;
		}

		/// <summary>
		/// If the planet has a loaded defense fleets
		/// </summary>
		/// <returns>fleets</returns>
		public bool HasLoadedDefenseFleet() {
			return defenseFleet != null;
		}

		/// <summary>
		/// If the planet has a location
		/// </summary>
		/// <returns>fleets</returns>
		public bool HasLocation() {
			return location != null;
		}

		/// <summary>
		/// Steals the resources of the passed planet
		/// </summary>
		/// <returns></returns>
		public List<IResourceQuantity> StealResources() {
            List<IResourceQuantity> list = new List<IResourceQuantity>();
            if (!CanPillage) {
                return list;
            }

            StealResource(list, RaceInformation.RichResource);
            StealResource(list, GetOtherResourceToSteal());
            LastPillageTick = Clock.Instance.Tick;

            return list;
		}

        private static Random rnd = new Random();
        private IResourceInfo GetOtherResourceToSteal()
        {
            List<IResourceInfo> list = new List<IResourceInfo>();
            list.Add(Astatine.Resource);
            list.Add(Radon.Resource);
            list.Add(Argon.Resource);
            list.Add(Prismal.Resource);
            list.Add(Cryptium.Resource);
            list.Remove(RaceInformation.RichResource);

            return list[rnd.Next(0, list.Count)];
        }

        private void StealResource(List<IResourceQuantity> list, IResourceInfo info) 
        {
            double level = Level;
            double percent = level * 10 / 3 /100;
            int currQuantity = GetQuantity(info);
            int stolen = (int)Math.Round(currQuantity * percent);

            if (stolen == 0) {
                return;
            }

            RemoveQuantity(info, stolen);
            list.Add(new ResourceQuantity(info, stolen));
        }

		/// <summary>
		/// Get's the level of the current planet (different from the planet universe level)
		/// </summary>
		/// <returns>The level of the planet</returns>
		public int GetPlanetLevel() {
            if (FacilityLevel > 0) {
                return FacilityLevel;
            }
			return 1;
		}

        /// <summary>
        /// Creates a ultimate fleet near the planet
        /// </summary>
        /// <param name="unit">Ultimate unit </param>
        public void CreateUltimateFleet(IUnitInfo unit) {
            if (unit.IsUltimate){
                if (Owner.Fleets.Count < PlayerUtils.MaxFleetNumber){
                    SectorUtils.CreateFleetSector(Location, Owner, unit.Name, unit);
                }else{
                    DefenseFleet.AddCargo(new ResourceQuantity(unit,1));
                }
            }
        }

    	#endregion IPlanet Methods

        #region Resource Construction

        public bool IsBuildAvailable(IResourceInfo info)
        {
            return ResourceUtils.IsBuildAvailable(this, info);
        }

        public Result IsUpgradeAvailable(IPlanetResource resource)
        {
            return ResourceUtils.IsUpgradeAvailable(this, resource);
        }

        public IList<IPlanetResource> GetResourcesInProduction(ResourceType resourceType)
        {
            return ResourceUtils.GetResourcesInProduction(this, resourceType);
        }

        public void CancelProduction(IPlanetResource resource)
        {
            ResourceUtils.CancelProduction(this, resource);
        }

        #endregion Resource Construction

        #region IResourceOwner quantity handling

        public int AddQuantity(IResourceInfo resource, int quantity)
        {
            if (resource.Type == ResourceType.Intrinsic) {
                return ResourceUtils.AddQuantity(Owner, resource, quantity);
            } else {
                GetResource(resource).Quantity += quantity;
                return quantity;
            }
        }

        public void SetQuantity(IResourceInfo resource, int quantity)
        {
            if (resource.Type == ResourceType.Intrinsic) {
                ResourceUtils.SetQuantity(Owner, resource, quantity);
            } else {
                GetResource(resource).Quantity = quantity;
            }
        }

        public int GetQuantity(IResourceInfo resource)
        {
            if (resource.Type == ResourceType.Intrinsic) {
                return ResourceUtils.GetQuantity(Owner, resource);
            }

            int sum = 0;
            foreach (IPlanetResource res in GetResources(resource)) {
                if (ResourceUtils.IsAvailable(res)) {
                    sum += res.Quantity;
                }
            }
            return sum;
        }

        public bool HasQuantity(IResourceInfo resource, int quantity){
            return GetQuantity(resource) >= quantity;
        }

        public int GetPerTick(IResourceInfo resource)
        {
            return ResourceUtils.GetPerTick(this, resource);
        }

        #endregion IResourceOwner quantity handling

        #region IResourceQueue Implementation

        public int TotalQueueSpace {
            get {
                return QueueUtils.GetTotalQueueSpace(this);
            }
        }

        IResourceOwner IResourceQueue.ResourceOwner {
            get {
                return this;
            }
        }

        public int GetUsedQueueSpace(ResourceType type)
        {
            return QueueUtils.GetUsedQueueSpace(this, type);
        }

        public Result CanQueue(IPlanetResource resource)
        {
            return CanQueue(resource, resource.Quantity);
        }

        public Result CanQueue(IPlanetResource resource, int quantity)
        {
            return ResourceUtils.CanQueue(this, resource, quantity);
        }

        public IPlanetResource Enqueue(IPlanetResource resource)
        {
            return QueueUtils.Enqueue(this, resource);
        }

        public void Dequeue(IPlanetResource resource)
        {
            QueueUtils.Dequeue(this, resource);
        }

        public IList<IPlanetResource> GetQueueList(ResourceType type)
        {
            return QueueUtils.GetQueueList(this, type);
        }

        #endregion IResourceQueue Implementation

        #region IModifierHandler Implementation

        private Dictionary<IResourceInfo, int> modifiers = new Dictionary<IResourceInfo,int>();
        public Dictionary<IResourceInfo, int> Modifiers {
            get { return modifiers; }
            set { modifiers = value; }
        }

        public int GetModifier(IResourceInfo info)
        {
            if (Modifiers.ContainsKey(info)) {
                return Modifiers[info];
            }
            return 0;
        }

        public void AddToModifier(IResourceInfo info, int change)
        {
            Touch();
            ResourceUtils.AddToModifier(this, info, change);
        }

        #endregion IModifierHandler Implementation

        #region IResourceRichness Implementation

        private Dictionary<IResourceInfo, int> richness = new Dictionary<IResourceInfo, int>();
        public Dictionary<IResourceInfo, int> Richness { 
            get { return richness; }
            set { richness = value; Touch(); }
        }

        public int GetRichness(IResourceInfo info)
        {
            if (!Richness.ContainsKey(info)) {
                return 100;
            }
            return Richness[info];
        }

        public void SetRichness(IResourceInfo info, int quantity)
        {
            Touch();
            Richness[info] = quantity;
        }

        public void AddToRichness(IResourceInfo info, int quantity)
        {
            SetRichness(info, GetRichness(info) + quantity);
        }

        #endregion IResourceRichness Implementation

        #region IBackToStorage Implementation

        private PlanetStorage storage;
        public PlanetStorage Storage {
            get {
                if (storage == null) {
                    throw new EngineException("Storage is null");
                }
                return storage;
            }
            set { storage = value; }
        }

        public void PrepareStorage()
        {
            if (this.storage == null) {
                this.storage = PlanetConversion.ConvertToStorage(this);
            }
        }

        public void UpdateStorage()
        {
            PlanetConversion.SetStorage(storage, this);
        }

        public void Touch()
        {
            IsDirty = true;
        }

        private bool dirty = false;
        public bool IsDirty {
            get { return dirty; }
            set { dirty = value; }
        }

        #endregion IBackToStorage Implementation

    };
}
