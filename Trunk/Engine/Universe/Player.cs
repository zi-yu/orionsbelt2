using System.Collections.Generic;
using System.IO;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Common;
using OrionsBelt.Generic;
using System;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Engine.Actions;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Resources {

    /// <summary>
    /// This class represents a planet resource
    /// </summary>
    public class Player : IPlayer {

		#region Fields

        private List<UniverseSpecialSector> wormholes = null;
		private List<IFleetInfo> allFleets = null;
    	private ISystem privateSystem;
		private string avatar;

		#endregion Fields

		#region Private

		private void TouchAlliance() {
			allianceLoaded = true;
		}

		private void LoadAlliance() {
			if (alliance == null && !allianceLoaded) {
			    PlayerConversion.SetPlayerAlliance(this, Storage);
				TouchAlliance();
			}
		}

		#endregion Private

		#region Ctor

		public Player(PlayerStorage playerStorage, bool initialize)
        {
            if (initialize) {
                ResourceUtils.Initialize(this);
            }
            PlayerConversion.SetPlayer(this, playerStorage);
            Init();
        }

		public Player( PlayerStorage playerStorage)
            :this(playerStorage, true)
        {
        }

		public Player()
        {
            ResourceUtils.Initialize(this);
			IsDirty = true;
            Init();
        }

        private void Init()
        {
            Actions.Add(PeriodicIncome.Instance);
            Actions.Add(ResourceConstruction.Instance);
            Actions.Add(CheckProductionQueue.Instance);
        }

        #endregion Ctor

        #region IResourceOwner Properties

        private Dictionary<IResourceInfo, int> intrinsicQuantities = null;

        public Dictionary<IResourceInfo, int> IntrinsicQuantities {
            get {
                if (intrinsicQuantities == null) { 
                    intrinsicQuantities = new Dictionary<IResourceInfo,int>();
                }
                return intrinsicQuantities; 
            }
            set { intrinsicQuantities = value; }
        }

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

        public IPlayer Owner {
            get { return this; }
            set {  }
        }

        public bool HasOwner {
            get { return false; }
        }

        public double ProductionFactor {
            get {
                if (Planets.Count == 0) {
                    return 0;
                }

                double sum = 0;
                foreach (IPlanet planet in Planets) {
                    sum += planet.ProductionFactor;
                }

                return sum / Planets.Count;
            }
            set {
                throw new EngineException("Can't set ProductionFactor for a Player");
            }
        }

        public double FinalProductionFactor {
            get { return ProductionFactor; }
        }

        private List<IPlanet> planets = null;
        public IList<IPlanet> Planets {
            get {
                if (planets == null || planets.Count == 0) {
                    planets = new List<IPlanet>();
                    PlayerConversion.SetPlayerPlanets(this, Storage, planets);
                }
                return planets; 
            }
        }

        private List<SectorCoordinate> relics = null;
        public IList<SectorCoordinate> Relics{
            get{
                if(relics == null) {
                    relics = new List<SectorCoordinate>();
                }
                if ( relics.Count == 0){
                    PlayerConversion.SetPlayerRelics(this, Storage, relics);
                }
                return relics;
            }
        }

		public string Avatar {
			get { return avatar; }
			set {Touch(); avatar = value; }
		}

        #endregion IResourceOwner Properties

        #region IResourceOwner Methods

        public void AddResource(IPlanetResource resource)
        {
            throw new NotImplementedException();
        }

        public void RemoveQuantity(IResourceInfo resource, int quantity)
        {
            ResourceUtils.RemoveQuantity(this, resource, quantity);
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
            throw new NotImplementedException();
        }

        public IList<IPlanetResource> GetResources(IResourceInfo resource)
        {
            throw new NotImplementedException();
        }

        public bool IsResourceAvailable(IResourceInfo resource, int quantity)
        {
            return ResourceUtils.IsResourceAvailable(this, resource, quantity);
        }

        public bool IsBuildAvailable(IResourceInfo info)
        {
            return false;
        }

        public Result IsUpgradeAvailable(IPlanetResource resource)
        {
            return Result.Fail;
        }

        public int GetPerTick(IResourceInfo resource)
        {
            return ResourceUtils.GetPerTick(this, resource);
        }

        #endregion IResourceOwner Methods

        #region IIntrinsicLimiter Implementation

        private Dictionary<IResourceInfo, int> limits = new Dictionary<IResourceInfo, int>();
        public Dictionary<IResourceInfo, int> Limits {
            get { return limits; }
            set { limits = value; Touch(); }
        }

        private static IResourceInfo AllResourcesFilter = QueueSpace.Resource;

        public int GetLimit(IResourceInfo info)
        {
            if (info == null) {
                info = AllResourcesFilter;
            }
            if (!Limits.ContainsKey(info)) {
                if (Limits.ContainsKey(AllResourcesFilter))  {
                    return Limits[AllResourcesFilter];
                }
                return -1;
            }
            return Limits[info];
        }

        public void SetLimit(IResourceInfo info, int quantity)
        {
            Touch();
            if (info == null) {
                info = AllResourcesFilter;
            }
            Limits[info] = quantity;
        }

        public void AddToLimit(IResourceInfo info, int quantity)
        {
            if (info == null) {
                info = AllResourcesFilter;
            }
            if (!Limits.ContainsKey(info)) {
                SetLimit(info, 0);
            }
            SetLimit(info, GetLimit(info) + quantity);
        }

        #endregion IIntrinsicLimiter Implementation

        #region IPlayer Members

		public int Id {
			get {
				if (storage == null) {
					return 0;
				}
				return storage.Id;
			}
		}

        public bool InVacations {
            get {
                return Storage.IsOnVacations;
            }
        }

        private int planetLevel;
        public int PlanetLevel {
            get { return planetLevel; }
            set {
                Touch();
                planetLevel = value; 
            }
        }

        private bool isActive;
        public bool Active  {
            get { return isActive; }
            set {
                Touch();
                isActive = value; 
            }
        }

        private bool isPrimary;
        public bool IsPrimary
        {
            get { return isPrimary; }
            set
            {
                Touch();
                isPrimary = value;
            }
        }

        private int activatedInTick;
        public int ActivatedInTick
        {
            get { return activatedInTick; }
            set
            {
                Touch();
                activatedInTick = value;
            }
        }
	

        private string name = "Player";
        public string Name {
            get { return name; }
            set {
                Touch();
                name = value; 
            }
        }

		private bool allianceLoaded = false;
		public bool AllianceLoaded {
			get { return allianceLoaded; }
		}

        private IAlliance alliance = null;
        public IAlliance Alliance {
            get {
            	LoadAlliance();
            	return alliance;
            }
			set { alliance = value; Touch();TouchAlliance(); }
        }

    	public bool HasAlliance {
            get {
				LoadAlliance();
				return alliance != null;
            }
        }

        private AllianceRank allianceRank = AllianceRank.None;
        public AllianceRank AllianceRank {
            get {
				LoadAlliance();
            	return allianceRank;
            }
			set { allianceRank = value; Touch(); TouchAlliance(); }
        }

		private int score = 0;
		public int Score {
			get { return score; }
			set {
				Touch();
				score = value;
			}
		}

        private IList<IQuestData> quests = null;
        public IList<IQuestData> Quests {
            get {
                if (quests == null) {
                    quests = PlayerConversion.LoadQuests(this);
                }
                return quests; 
            }
            set { 
                quests = value;
                Touch();
            }
        }

        private int lastProcessedTurn = 0;
        public int LastProcessedTick {
            get { return lastProcessedTurn; }
            set {
                Touch();
                lastProcessedTurn = value; 
            }
        }

        private IRaceInfo raceInfo = null;
        public IRaceInfo RaceInfo {
            get { return raceInfo; }
            set { raceInfo = value; }
        }

		private Principal principal = null;
		public Principal Principal {
			get {
				if (principal == null && storage != null) {
					principal = storage.Principal;
				}
				return principal;
			}
			set {
				Touch();
				principal = value;
			}
		}

    	private int homePlanetId;
    	public int HomePlanetId {
			get { return homePlanetId; }
			set { Touch(); homePlanetId = value; }
    	}
	
		public int Ranking {
			get { return 1; }
		}

    	public bool HasMoveableFleets {
    		get { return Fleets.Count != 0; }
    	}

        public List<UniverseSpecialSector> SpecialSectors
        {
			get {
				if (wormholes == null) {
					wormholes = (List<UniverseSpecialSector>)Storage.SpecialSectores;
				}
				return wormholes;
			}
		}

		public List<IFleetInfo> Fleets {
			get {
				return AllFleets.FindAll(delegate(IFleetInfo fleet) { return fleet.Movable; });
			}
		}

		public List<IFleetInfo> AllFleets {
			get {
				if (allFleets == null || allFleets.Count == 0) {
					allFleets = PlayerConversion.LoadAllPlayerFleets(this);
					if (allFleets == null) {
						allFleets = new List<IFleetInfo>();
					}
				}
				return allFleets;
			}
		}

    	public void RegisterPlanet(IPlanet planet) {
			Planets.Add(planet);
			planet.Owner = this;
			Touch();
		}

        public void AddQuest(IQuestData quest)
        {
            quest.Player = this;
            Quests.Add(quest);
        }

		public void AddFleet(IFleetInfo fleet) {
			fleet.Owner = this;
			AllFleets.Add(fleet);
		}

		/// <summary>
		/// Adds a  list of fleets to the player
		/// </summary>
		/// <param name="fleet">The fleet</param>
		public void AddFleets(List<IFleetInfo> fleet) {
			if (allFleets == null) {
				allFleets = new List<IFleetInfo>();
			}
			allFleets.AddRange(fleet);
		}

    	public IFleetInfo GetFleet(int fleetId) {
			return AllFleets.Find(delegate(IFleetInfo fleet) { return fleet.Id == fleetId; });
		}

        public IPlanet GetHomePlanet()
        {
        	return GetPlanet(HomePlanetId);
        }

		public IPlanet GetPlanet(int id) {
			foreach (IPlanet planet in Planets) {
				if (planet.Storage.Id == id) {
					return planet;
				}
			}

			return null;
        }

		public bool HasSamePrincipal( IPlayer player ) {
			return Principal == player.Principal;
		}

        #region Universe 

        public bool HasPrivateSystem {
			get { return privateSystem != null; }
    	}

		public ISystem PrivateSystem {
			get {
				if (!HasPrivateSystem) {
					if(Server.IsChronos){
						privateSystem = Universe.Universe.GetPrivateSystem(Id);
					}
					if (privateSystem == null){
						privateSystem = UniversePersistance.LoadPrivateSystem(this);
					}
				}
				return privateSystem;
			}
			set {
				privateSystem = value;
			}
		}


		public ISector GetSector(Coordinate sectorCoordinate) {
			return PrivateSystem.GetSector(sectorCoordinate);
		}

        /// <summary>
        /// Gets a list of sectrs
        /// </summary>
        /// <param name="coordinates">Coordinates of the sectors to return</param>
        /// <returns>List of sectors</returns>
        public List<ISector> GetSectors(List<CoordinateDistance> coordinates){
            List<ISector> sectors = new List<ISector>();
			foreach (CoordinateDistance c in coordinates) {
                sectors.Add(PrivateSystem.GetSector(c.CurrentSector));
			}
            return sectors;
        }

        /// <summary>
        /// Gets a list of sectrs
        /// </summary>
        /// <param name="coordinates">Coordinates of the sectors to return</param>
        /// <returns>List of sectors</returns>
        public List<ISector> GetSectors(List<SectorCoordinate> coordinates) {
            List<ISector> sectors = new List<ISector>();
			foreach (SectorCoordinate c in coordinates) {
                sectors.Add(PrivateSystem.GetSector(c.Sector));
			}
            return sectors;
        }

		public void ResolveHomePlanet() {
            if (Planets.Count != 1) {
                throw new EngineException("At this time, Player should have 1, and only 1 planet, the home planet, and has {0}", Planets.Count);
            }

			IPlanet planet = Planets[0];
			planet.PrepareStorage();
			Persistance.ResolveTransient(planet.Storage);
			HomePlanetId = planet.Storage.Id;
        }

		private int ultimateWeaponLevel;
		public int UltimateWeaponLevel {
			get { return ultimateWeaponLevel; }
			set {Touch(); ultimateWeaponLevel = value; }
		}

        private int ultimateWeaponCooldown;
        public int UltimateWeaponCooldown{
            get { return ultimateWeaponCooldown; }
            set { Touch(); ultimateWeaponCooldown = value; }
        }

        public bool HasUltimateCooldown {
            get { return UltimateWeaponCooldown > 0; }
        }

		public bool IsUltimateWeaponReady {
    		get {
    			IUltimateWeapon weapon = UltimateWeaponChooser.GetUltimateWeapon(this);
    			return !HasUltimateCooldown && weapon.IsReady(this);
    		}
    	}

        #endregion Universe

        public bool HasLoadedPlanets() {
			return planets != null;
		}

		public bool HasLoadedFleets() {
			return allFleets != null;
		}

		public bool HasLoadedQuests() {
			return quests != null;
		}

		public bool HasLoadedActions() {
			return actions != null;
		}

		public bool HasLoadedSectors() {
			return privateSystem != null;
		}

        public string GetResourcesInJson(){
            using (StringWriter writer = new StringWriter()) {
                writer.Write("{currOrions:");
                writer.Write(Principal.Credits);
                writer.Write(",Capacity:{0}", GetLimit(null));
                writer.Write(",QueueSpace:{0}", GetQuantity(QueueSpace.Resource));
                foreach (IResourceInfo info in RulesUtils.GetInstrinsicResources(this)) {
                    writer.Write(",");
                    writer.Write(info.Name);
                    writer.Write(":");
                    writer.Write(GetQuantity(info));
                    writer.Write(",");
                    writer.Write(info.Name);
                }
                writer.Write("}");
                return writer.ToString();
            }
        }

        private bool isGeneralActive;
		public bool IsGeneralActive {
			get { return isGeneralActive; }
			set {
                Touch();
                isGeneralActive = value; 
            }
		}

        private int generalId;
		public int GeneralId {
			get { return generalId; }
            set { Touch(); generalId = value; }
		}

        private string generalName;
		public string GeneralName {
            get { return generalName; }
            set { Touch(); generalName = value; }
		}

        private string generalFriendlyName;
		public string GeneralFriendlyName {
			get { return generalFriendlyName; }
            set { Touch(); generalFriendlyName = value; }
		}

        private string forumRole;
        public string ForumRole {
            get { return forumRole; }
            set { Touch(); forumRole = value; }
        }

        private string forumSignature;
        public string ForumSignature {
            get { return forumSignature; }
            set { Touch(); forumSignature = value; }
        }

        private int totalPosts;
        public int TotalPosts {
            get { return totalPosts; }
            set { Touch(); totalPosts = value; }
        }

        #endregion

        #region Profession Properties

        public Profession MainProfession {
            get {
                if (PirateRanking > BountyRanking && PirateRanking > MerchantRanking) {
                    return Profession.Pirate;
                }
                if (BountyRanking > PirateRanking && BountyRanking > MerchantRanking) {
                    return Profession.BountyHunter;
                }
                if (MerchantRanking > PirateRanking && MerchantRanking > BountyRanking)   {
                    return Profession.Merchant;
                }
                return Profession.Colonizer;
            }
        }

        private int colonizerRanking;
        public int ColonizerRanking {
            get { return colonizerRanking; }
            set {
                Touch();
                colonizerRanking = value; 
            }
        }

        private int pirateRanking;
        public int PirateRanking {
            get { return pirateRanking; }
            set {
                Touch();
                pirateRanking = value; 
            }
        }

        private int bountyRanking;
        public int BountyRanking {
            get { return bountyRanking; }
            set {
                Touch();
                bountyRanking = value; 
            }
        }

        private int gladiatorRanking;
        public int GladiatorRanking {
            get { return gladiatorRanking; }
            set {
                Touch();
                gladiatorRanking = value; 
            }
        }

        private int merchantRanking;
        public int MerchantRanking {
            get { return merchantRanking; }
            set {
                Touch();
                merchantRanking = value; 
            }
        }

        #endregion Profession Properties

        #region Resource Construction

        public Result CanQueue(IPlanetResource resource, int quantity)
        {
            return Result.Fail;
        }

        public IList<IPlanetResource> GetResourcesInProduction(ResourceType resourceType)
        {
            throw new NotImplementedException();
        }

        public void CancelProduction(IPlanetResource resource)
        {
            throw new NotImplementedException();
        }

        public Result CanBuildUltimateUnit(int quantity)
        {
            return ResourceUtils.CanBuildUltimateUnit(this, quantity);
        }

    	#endregion Resource Construction

        #region IResourceOwner quantity handling

        public int AddQuantity(IResourceInfo resource, int quantity)
        {
            return ResourceUtils.AddQuantity(this, resource, quantity);
        }

        public void SetQuantity(IResourceInfo resource, int quantity)
        {
            ResourceUtils.SetQuantity(this, resource, quantity);
        }

        public int GetQuantity(IResourceInfo resource)
        {
            return ResourceUtils.GetQuantity(this, resource);
        }

        public bool HasQuantity(IResourceInfo resource, int quantity){
            return ResourceUtils.GetQuantity(this, resource) >= quantity;
        }

        #endregion IResourceOwner quantity handling

        #region IBackToStorage Implementation

        private PlayerStorage storage;
        public PlayerStorage Storage {
            get {
                PrepareStorage();
                return storage;
            }
            set { storage = value; }
        }

        public void PrepareStorage()
        {
            if (this.storage == null) {
                this.storage = PlayerConversion.ConvertToStorage(this);
            }
        }

        public void UpdateStorage()
        {
            PrepareStorage();
            PlayerConversion.SetStorage(storage, this);
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

        #region IActionOwner Implementation

        private IList<ITimedAction> actions = new List<ITimedAction>();
        private IList<ITimedAction> added = new List<ITimedAction>();
        private IList<ITimedAction> removed = new List<ITimedAction>();

        public IList<ITimedAction> Actions  {
            get {
                if (added.Count > 0 || removed.Count > 0) {
                    SyncActions();
                }
                return actions; 
            }
            set { actions = value; }
        }

    	public void RegisterAction(ITimedAction action)
        {
            added.Add(action);
        }

        public void RemoveAction(ITimedAction action)
        {
            removed.Add(action);
        }

        public void SyncActions()
        {
            foreach (ITimedAction action in removed) {
                actions.Remove(action);
            }
            foreach (ITimedAction action in added) {
                actions.Add(action);
            }
            removed.Clear();
            added.Clear();
        }

        #endregion IActionOwner Implementation

        #region Quests

        private Dictionary<QuestContext, int> questLevel = null;
        public Dictionary<QuestContext, int> QuestContextLevel {
            get { return questLevel; }
            set { questLevel = value; }
        }

        public int GetQuestContextLevel(QuestContext context)
        {
            if( questLevel == null || questLevel.Count == 0 ) {
                return 0;
            }
            if (!questLevel.ContainsKey(context)) { 
                return 0;
            }
            return questLevel[context];
        }

        public bool ChekQuestLevel(QuestContext context, int targetLevel)
        {
            return GetQuestContextLevel(context) == targetLevel;
        }

        public void SetQuestContextLevel(QuestContext context, int level)
        {
            if (questLevel == null) {
                questLevel = new Dictionary<QuestContext, int>();
            }
            if (!questLevel.ContainsKey(context)) {
                questLevel.Add(context, level);
            } else {
                questLevel[context] = level;
            }
            Touch();
        }

        #endregion Quests

        #region Operators Overloading

        public override bool Equals( object obj ) {
			if( base.Equals(null) ) {
				return true;			
			}
			Player p = (Player)obj;
			return p.storage.Id == storage.Id;
		}

		public override int GetHashCode() {
			return storage.Id;
		}

		public static bool operator ==(Player c1, Player c2) {
			if( Equals(c1,null) && Equals(c2,null) ) {
				return true;
			}
			if ( Equals(c1, null) || Equals(c2, null) ) {
				return false;
			}

			return c1.Storage.Id == c2.Storage.Id;
		}

		public static bool operator !=(Player c1, Player c2) {
			return !(c1 == c2);
		}

		#endregion Operators Overloading

        #region Services

        private List<ServiceType> services = null;

        public List<ServiceType> Services {
            get { return services; }
            set { services = value; }
        }

        public void AddService(ServiceType type)
        {
            if (Services == null) {
                Services = new List<ServiceType>();
            }
            Services.Add(type);
            Touch();
        }

        public void RemoveService(ServiceType type)
        {
            if (Services == null) {
                return;
            }
            Services.Remove(type);
            Touch();
        }

        public bool HasService(ServiceType type)
        {
            if (Services == null) {
                return false;
            }
            return Services.Contains(type);
        }

        #endregion Services


	};
}
