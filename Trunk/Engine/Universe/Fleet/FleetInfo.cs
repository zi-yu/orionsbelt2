using System;
using System.Collections.Generic;
using System.Text;
using DesignPatterns;
using OrionsBelt.BattleCore;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Common;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.RulesCore.Common {
	public class FleetInfo : IFleetInfo {

		#region Fields

		private static readonly FactoryContainer battleCoreContainer = new FactoryContainer(typeof(BaseUnit), typeof(Unit).Assembly);
		private static readonly FactoryContainer container = new FactoryContainer(typeof(BaseUnit));
		private int id;
		private string name;
		private bool tournamentFleet = false;
		private bool moveable = false;
		private IUnitInfo ultimateUnit;
		private bool isInBattle = false;
		private bool isPlanetDefenseFleet = false;
		private Dictionary<string, IFleetElement> units = new Dictionary<string, IFleetElement>();
	    private Dictionary<IResourceInfo, int> cargo = null;
		private IPlanet currentPlanet;
		private IPlayer owner;
		private Principal principalOwner;
		private SectorCoordinate coordinate;
		private Fleet fleetStorage;
		private int visibilityRange = 1;
		private int movementDuration = 1;
		private bool dirty = false;
		private ISector sector;
		private int fleetValue = 0;
		private bool isBot = false;
		private List<Coordinate> wayPoints;
        private int immunityStartTick = 0;

		#endregion Fields

		#region Properties

		/// <summary>
		/// Id of the fleet
		/// </summary>
		public int Id {
			get { return id; }
			set { Touch(); id = value; }
		}

		/// <summary>
		/// Name of the Fleet
		/// </summary>
		public string Name {
			get { return name; }
			set { Touch(); name = value; }
		}

		/// <summary>
		/// Indicates if this fleet is a tournament fleet
		/// </summary>
		public bool TournamentFleet {
			get { return tournamentFleet; }
			set { Touch(); tournamentFleet = value; }
		}

		/// <summary>
		/// Indicates if this fleet has a ultimate unit
		/// </summary>
		public bool HasUltimateUnit { 
			get { return ultimateUnit != null;}
		}

		/// <summary>
		/// Indicates if this fleet has a ultimate unit
		/// </summary>
		public IUnitInfo UltimateUnit {
			get { return ultimateUnit; }
			set { Touch(); ultimateUnit = value; }
		}

		/// <summary>
		/// Container with all the units of this fleet
		/// </summary>
		public Dictionary<string, IFleetElement> Units {
			get { return units; }
			set { Touch(); units = value; }
		}

		/// <summary>
		/// Onwer, if any, of the fleet
		/// </summary>
		public IPlayer Owner {
			get {
				if( owner == null ) {
					if (Storage.PlayerOwner != null) {
						owner = PlayerUtils.LoadPlayer(Storage.PlayerOwner);
					}
				}
				return owner;
			}
			set { Touch(); owner = value; }
		}

		public bool HasLoadedOwner {
			get { return owner != null; }
		}

		/// <summary>
		/// Onwer, if any, of the fleet
		/// </summary>
		public Principal PrincipalOwner {
			get { return principalOwner; }
			set { Touch(); principalOwner = value; }
		}

		/// <summary>
		/// Current planet where the fleet is
		/// </summary>
		public IPlanet CurrentPlanet {
			get {
				if (currentPlanet == null && Storage.CurrentPlanet!= null) {
					currentPlanet = Owner.GetPlanet(Storage.CurrentPlanet.Id);
					if( currentPlanet == null ) {
						currentPlanet = PlanetConversion.ConvertToPlanet(Storage.CurrentPlanet);
					}
				}
				return currentPlanet;
			}
			set { Touch(); currentPlanet = value; }
		}

		/// <summary>
		/// True if the fleet is in a battle
		/// </summary>
		public bool IsInBattle {
			get { return isInBattle; }
			set { Touch(); isInBattle = value; }
		}

		/// <summary>
		/// Fleet has units
		/// </summary>
		public bool HasUnits {
			get { return Units.Count > 0; }
		}

		/// <summary>
		/// Is this fleet a defense fleet
		/// </summary>
		public bool IsPlanetDefenseFleet {
			get { return isPlanetDefenseFleet; }
			set { Touch(); isPlanetDefenseFleet = value; }
		}

		/// <summary>
		/// Gets the Visibility range
		/// </summary>
		public int VisibilityRange {
			get { return visibilityRange; }
		}

		/// <summary>
		/// Gets the Movement duration
		/// </summary>
		public int MovementDuration {
			get { return movementDuration; }
		}

		/// <summary>
		/// The Fleet's sector
		/// </summary>
		public ISector Sector {
			get {
				if (sector == null && Storage.Sector != null) {
					if( Location.System.IsPrivateSystem()) {
						sector = Owner.PrivateSystem.GetSector(Location.Sector);	
					}else {
						sector = SectorUtils.LoadSector(Storage.Sector);
					}
					sector.Owner = Owner;
				}
				return sector;
			}set{
			    Touch(); 
                sector = value;
			    Location = sector.Coordinate;
			}
		}

		/// <summary>
		/// if the sector was loaded
		/// </summary>
		public bool HasLoadedSector {
			get { return sector != null; }
		}

		/// <summary>
        /// Cargo of the fleet
        /// </summary>
        public Dictionary<IResourceInfo, int> Cargo{
            get { return cargo; }
			set { Touch(); cargo = value; }
        }

        /// <summary>
        /// If the fleet has Cargo
        /// </summary>
        public bool HasCargo{
            get { return cargo != null && cargo.Count > 0; }
        }

		/// <summary>
		/// Total value of the fleet based on the value of each unit
		/// </summary>
		public int FleetValue {
			get {
				return fleetValue;
			}
		}

        /// <summary>
        /// If this fleet can pass in a wormhole
        /// </summary>
	    public bool CanPassWormHoles{
	        get{
                return !HasTradeGoodsWithWormHoleRestriction();
	        }
	    }

		/// <summary>
		/// True if the fleet is moving
		/// </summary>
		public bool IsMoving {
			get { return fleetStorage.Sector.IsMoving; }
		}

		/// <summary>
		/// True if the fleet is idle
		/// </summary>
		public bool IsIdle {
			get { return !IsMoving && !IsInBattle; }
		}

		/// <summary>
		/// If this fleet belongs to a bot
		/// </summary>
		public bool IsBot {
			get { return isBot; }
            set { Touch(); isBot = value; }
		}

        /// <summary>
        /// The Fleet has waypoints
        /// </summary>
        public bool HasWayPoints{
            get { return wayPoints != null && wayPoints.Count > 0; }
        }
        
        /// <summary>
		/// FLeet waypoints
		/// </summary>
		public List<Coordinate> WayPoints {
			get { return wayPoints; }
            set { Touch(); wayPoints = value; }
		}


        /// <summary>
        /// Fleet Immunity Start Tick
        /// </summary>
        public int ImmunityStartTick {
            get { return immunityStartTick;  }
            set { Touch(); immunityStartTick = value;}
        }

        #endregion Properties

		#region Private

		private void ParseVisibilityAndMovement(UnitCategory unitType) {
			if (unitType == UnitCategory.Heavy) {
				visibilityRange = 2;
				movementDuration = 3;
			}
			if (movementDuration < 3 ) {
				if (unitType == UnitCategory.Medium) {
					visibilityRange = 2;
					movementDuration = 2;
				}
			}
		}

		private void ParseUnits( string rawUnits ) {
			string[] rawUnitsList = rawUnits.Split(new char[]{';'}, StringSplitOptions.RemoveEmptyEntries);
			foreach( string rawUnit in rawUnitsList ) {
				string[] unit = rawUnit.Split('-');
				if( unit.Length != 2) {
					throw new EngineException("Error parsing unit '{0}'.", rawUnit);	
				}
				try {
					int quantity = int.Parse(unit[1]);
					FleetElement element = new FleetElement(unit[0], quantity);
					ParseVisibilityAndMovement(element.UnitInfo.UnitCategory);
					units.Add(element.Name, element);
				}catch( Exception e ) {
					throw new EngineException("Exception parsing unit '{0}'. Message: {1}", rawUnit, e.Message );	
				}
			}
		}

		private void CalculateFleetValue() {
			foreach (IFleetElement unit in units.Values) {
				fleetValue += unit.UnitInfo.UnitValue * unit.Quantity;
			}
		}

		private void IncrementFleetValue(IUnitInfo unit, int quantity) {
			fleetValue += unit.UnitValue * quantity;
		}

		private void DecrementFleetValue(IUnitInfo unit, int quantity) {
			fleetValue -= unit.UnitValue * quantity;
		}

        private bool HasTradeGoodsWithWormHoleRestriction(){
            if( HasCargo ){
                foreach (IResourceInfo resource in Cargo.Keys){
                    if( !resource.CanPassWormHoles ){
                        return true;
                    }
                }
            }
            return false;
        }

		#endregion Private

		#region Public

		/// <summary>
		/// Gets a Unit by name
		/// </summary>
		/// <param name="unitName">Name of the unit</param>
		/// <returns>Object that represents the unit</returns>
		public static IUnitInfo GetUnit( string unitName ) {
			IUnitInfo unitInfo = container.create(unitName) as IUnitInfo;
			if( null == unitInfo ) {
				throw new EngineException("Cannot find unit '{0}'.", unitName);
			}
			return unitInfo;
		}

		/// <summary>
		/// Gets a Unit by it's short name
		/// </summary>
		/// <param name="unitName">Name of the unit</param>
		/// <returns>Object that represents the unit</returns>
		public static IUnitInfo GetUnitByShortName(string unitName) {
			IUnitInfo unitInfo = battleCoreContainer.create(unitName) as IUnitInfo;
			if( null == unitInfo ) {
				throw new EngineException("Cannot find unit '{0}'.", unitName);
			}
			return unitInfo;
		}

		/// <summary>
		/// Add a new unit
		/// </summary>
		public void Add( string unitName, int quantity ) {
			Touch();
			Add(GetUnit(unitName),quantity);
		}


		/// <summary>
		/// Adds a ultimate unit to this fleet
		/// </summary>
		/// <param name="unitName"></param>
		public void AddUltimate(string unitName) {
			UltimateUnit = GetUnit(unitName);
		}

		/// <summary>
		/// Adds a ultimate unit to this fleet
		/// </summary>
		public void AddUltimate(IUnitInfo info) {
			UltimateUnit = info;
		}

		public void Add(IPlanetResource resource) {
			Add(resource.Info.Name,resource.Quantity);
		}

		/// <summary>
		/// Add a new unit
		/// </summary>
		public void Add( IUnitInfo info, int quantity ) {
			Touch();
			if (Units.ContainsKey(info.Name) ) {
				Units[info.Name].Quantity += quantity;
			}else {
				Units.Add(info.Name, new FleetElement(info, quantity));
			}
			IncrementFleetValue(info, quantity);
		}

		/// <summary>
		/// Add a new element
		/// </summary>
		public void Add( IElement element, IBattlePlayer player ) {
			Touch();
			if( element.Owner.PlayerNumber == player.PlayerNumber ) {
				IElement original = player.InitialContainer.GetElement(element.Unit.Code);
				Add(element.Unit,element.Quantity);
				IncrementFleetValue(element.Unit, element.Quantity);
			}
		}

		/// <summary>
		/// Add the units of the passed fleet to the current fleet
		/// </summary>
		/// <param name="fleet"></param>
		public void Add(IFleetInfo fleet) {
			Touch();
			foreach (IFleetElement element in fleet.Units.Values ) {
				Add(element.UnitInfo,element.Quantity);
				IncrementFleetValue(element.UnitInfo, element.Quantity);
			}
		}

        /// <summary>
		/// Add the units of the passed fleet to the current fleet
		/// </summary>
		/// <param name="fleet"></param>
        public void AddHalfUnits(IFleetInfo fleet){
			Touch();
			foreach (IFleetElement element in fleet.Units.Values ) {
			    int q = element.Quantity/2;
                if( q > 0 ){
				    Add(element.UnitInfo,q);
                    fleet.Update(element.UnitInfo, element.Quantity-q);
				    IncrementFleetValue(element.UnitInfo, element.Quantity);
                }
			}
		}

		/// <summary>
		/// updates the unit of the passed
		/// </summary>
		public void Update(IUnitInfo info, int quantity) {
			if (Units.ContainsKey(info.Name)) {
				Units[info.Name].Quantity = quantity;
			} else {
				Units.Add(info.Name, new FleetElement(info, quantity));
			}
			CalculateFleetValue();
		}

		/// <summary>
		/// Removes a qunatity from a unit
		/// </summary>
		public void Remove(string unitName, int quantity) {
			if (Units.ContainsKey(unitName)) {
				Touch();
				IFleetElement element = Units[unitName];
				element.Quantity -= quantity;
				if( element.Quantity < 1 ) {
					Units.Remove(unitName);
				}
				DecrementFleetValue(element.UnitInfo, quantity);
			}
		}

	    /// <summary>
		/// verifies if the fleet has enough units of that type
		/// </summary>
		public bool HasEnoughUnits(string unitName, int quantity) {
			if(Units.ContainsKey(unitName) ) {
				IFleetElement element = Units[unitName];
				return element.Quantity >= quantity;
			}
	    	return false;
		}

        /// <summary>
		/// Empties the Cargo of a fleet
		/// </summary>
		public void EmptyUnits() {
			Touch();
			units.Clear();
		}

		/// <summary>
		/// If the current fleet is stronger than the passed fleet
		/// </summary>
		public bool IsStronger( IFleetInfo fleetInfo ) {
			return FleetValue > fleetInfo.FleetValue;
		}

		/// <summary>
		/// If the current fleet is weaker than the passed fleet
		/// </summary>
		public bool IsWeaker(IFleetInfo fleetInfo) {
			return FleetValue < fleetInfo.FleetValue;
		}

		/// <summary>
		/// if the fleets can enter in a battle
		/// </summary>
		public bool CanBattle(IFleetInfo fleetInfo) {
			if( FleetValue >= fleetInfo.FleetValue ) {
				return fleetInfo.FleetValue/FleetValue >= 0.05;
			}

			return FleetValue / fleetInfo.FleetValue >= 0.05;
		}

		#region Cargo
		
		public void AddCargo(IResourceInfo resource, int quantity) {
			AddCargo(new ResourceQuantity(resource,quantity));
		}

        /// <summary>
        /// Adds Cargo to the current Fleet
        /// </summary>
        /// <param name="resource">Resource thats going to be added to the cargo</param>
        public void AddCargo(IResourceQuantity resource){
            if( cargo == null){
                 cargo = new Dictionary<IResourceInfo,int>();
            }
            if (cargo.ContainsKey(resource.Resource)){
                cargo[resource.Resource] = cargo[resource.Resource] + resource.Quantity;
            }else{
                cargo.Add(resource.Resource,resource.Quantity);
            }
            Touch();
        }

		/// <summary>
		/// Adds Cargo to the current Fleet
		/// </summary>
		/// <param name="resources">List of Resources to be added to the cargo</param>
		public void AddCargo(List<IResourceQuantity> resources) {
			foreach (IResourceQuantity resource in resources) {
				AddCargo(resource);
			}
		}

		/// <summary>
		/// Adds Cargo to the current Fleet
		/// </summary>
		/// <param name="fleet">fleet to taske the cargo from</param>
		public void AddCargo(IFleetInfo fleet) {
			if( fleet.Cargo != null ) {
				foreach (KeyValuePair<IResourceInfo,int> resource in fleet.Cargo) {
					AddCargo(new ResourceQuantity(resource.Key,resource.Value));
				}	
			}
		}

        /// <summary>
        /// Returns the quantity already on cargo for the given resource
        /// </summary>
        /// <param name="info">The resource</param>
        /// <returns>The quantity</returns>
        public int GetCargoQuantity(IResourceInfo info)
        {
            if( Cargo == null ) {
                return 0;
            }
            if (!Cargo.ContainsKey(info)) {
                return 0;
            }
            return Cargo[info];
        }

		/// <summary>
		/// Empties the Cargo of a fleet
		/// </summary>
		public void EmptyCargo() {
			Touch();
			cargo = null;
		}

        /// <summary>
        /// Removes a resource from the cargo
        /// </summary>
        /// <param name="resource">Resource to remove from cargo</param>
        public void RemoveCargo(IResourceInfo resource){
            if( cargo !=null && cargo.ContainsKey(resource)){
                cargo.Remove(resource);
                Touch();
            }
        }

        /// <summary>
        /// updates the quantity of a resource
        /// </summary>
        /// <param name="resource">Resource to updates</param>
        /// <param name="quantity">Quantity to update</param>
        public void UpdateCargo(IResourceInfo resource, int quantity){
            if( cargo !=null && cargo.ContainsKey(resource)){
                if (quantity > 0 ) {
                    cargo[resource] = quantity;
                }else{
                    cargo.Remove(resource);
                }
                Touch();
            }
        }

		/// <summary>
		/// Decrement the quantity of a resource
		/// </summary>
		/// <param name="resource">Resource to Remove</param>
		/// <param name="quantity">Quantity to remove</param>
		public void DecrementCargo(IResourceInfo resource, int quantity) {
			if (cargo != null && cargo.ContainsKey(resource)) {
				int q = cargo[resource];
				int newQuantity = q - quantity;
				if (newQuantity > 0) {
					cargo[resource] = newQuantity;
				} else {
					cargo.Remove(resource);
				}
				Touch();
			}
		}

        #endregion Cargo

		#endregion Public

		#region Overriden

		public override string ToString() {
			StringBuilder builder = new StringBuilder();
			foreach (IFleetElement element in Units.Values ) {
				builder.Append(element.ToString());
			}
			return builder.ToString();
		}

		#endregion Overriden

		#region ICelestialBody Members

		public SectorCoordinate Location {
			get { return coordinate; }
			set { Touch(); coordinate = value; }
		}

		public bool Movable {
			get { return moveable; }
			set { Touch(); moveable = value; }
		}

		#endregion

		#region Constructor

		public FleetInfo(string name)
			: this(name, new SectorCoordinate(0,0,0,0)) {
		}

		public FleetInfo( string name, SectorCoordinate location )
			: this(name, false, location) { }

		public FleetInfo(string name, bool isPlanetDefenseFleet, SectorCoordinate location) {
			Name = name;
			IsPlanetDefenseFleet = isPlanetDefenseFleet;
			Location = location;
			CalculateFleetValue();
		}

		public FleetInfo(string name, IPlayer owner, bool isPlanetDefenseFleet, SectorCoordinate location) {
			Name = name;
			IsPlanetDefenseFleet = isPlanetDefenseFleet;
			Owner = owner;
			Location = location;
			CalculateFleetValue();
		}

		public FleetInfo( Fleet fleet )
			:this(fleet,true) {}

		public FleetInfo(Fleet fleet, IPlanet currentPlanet)
			: this(fleet, true) {
			CurrentPlanet = currentPlanet;
			dirty = false;
		}

		public FleetInfo( Fleet fleet, bool parseUnits ){
            FleetConversion.ConvertFromStorage(this, fleet);
			if (parseUnits) {
				ParseUnits(fleet.Units);
				CalculateFleetValue();
			}
		}

		public FleetInfo(string name,Principal owner, string rawUnits ){
			Name = name;
			PrincipalOwner = owner;
			ParseUnits(rawUnits);
			coordinate = new SectorCoordinate(0,0,0,0);
		}


		/// <summary>
		/// Constructor used for Universe fleets
		/// </summary>
		/// <param name="fleet">Fleet database representation</param>
		/// <param name="owner">Fleet owner</param>
		public FleetInfo(Fleet fleet, IPlayer owner) {
			FleetConversion.ConvertFromStorage(this,fleet,owner);
            ParseUnits(fleet.Units);
			CalculateFleetValue();
		}
		
		#endregion Constructor

		#region IBackToStorage<Fleet> Members

		public Fleet Storage {
			get {return fleetStorage;}
			set { Touch(); fleetStorage = value; }
		}

		public void UpdateStorage() {
		    FleetConversion.ConvertToStorage(this);
		}

		public void PrepareStorage() {
			if (fleetStorage == null) {
				fleetStorage = Persistance.Create<Fleet>();
			}
		}

		public void Touch() {
			dirty = true;
		}

		public bool IsDirty {
			get {return dirty;}
			set {dirty = value;}
		}

	   #endregion

        #region Build Random Fleet

        private static Random random = new Random();

        public static FleetInfo GetRandom(bool hasUltimate)
        {
            int lucky = random.Next(0, 100);
            if (lucky < 50) {
                return GetRandomFleetAllUnits(hasUltimate);
            } else if( lucky < 60 ) {
                return GetRandomBugsFleet(hasUltimate);
            } else if ( lucky < 75 ) {
                return GetRandomDarkHumansFleet(hasUltimate);
            } else if ( lucky < 90 ) {
                return GetRandomFleetUtopianUnits(hasUltimate);
            }
            return GetRandomMobsFleet(hasUltimate);
        }

        private static FleetInfo GetRandomFleetAllUnits(bool hasUltimate)
        {
            FleetInfo fleet = new FleetInfo("Random");
            fleet.TournamentFleet = true;

            IUnitInfo[] cannonFooder = { Rain.Resource, DarkRain.Resource, Seeker.Resource, Anubis.Resource, Sentry.Resource };
            IUnitInfo[] specialLight = { Samurai.Resource, Raptor.Resource, Toxic.Resource, Panther.Resource, Interceptor.Resource, Reaper.Resource };

            IUnitInfo[] medium1 = { Eagle.Resource, Kahuna.Resource, Driller.Resource, Scourge.Resource };
            IUnitInfo[] medium2 = { Pretorian.Resource, Scarab.Resource, HiveProtector.Resource };
            IUnitInfo[] medium3 = { Kamikaze.Resource, Destroyer.Resource, Vector.Resource, Walker.Resource };
            IUnitInfo[] medium4 = { Worm.Resource, Krill.Resource, Spider.Resource, Stinger.Resource };

            IUnitInfo[] heavy1 = { Crusader.Resource, DarkCrusader.Resource, Bozer.Resource, HeavySeeker.Resource, Taurus.Resource, DarkTaurus.Resource, Titan.Resource };
            IUnitInfo[] heavy2 = { Doomer.Resource, Fenix.Resource, BlackWidow.Resource, HiveKing.Resource, Nova.Resource };

            IUnitInfo[] ultimate = { Queen.Resource, BattleMoon.Resource, Blinker.Resource };

            AddRandom(fleet, cannonFooder, 100);
            AddRandom(fleet, specialLight, 65);

            AddRandom(fleet, medium1, 50);
            AddRandom(fleet, medium2, 40);
            AddRandom(fleet, medium3, 50);
            AddRandom(fleet, medium4, 50);

            AddRandom(fleet, heavy1, 15);
            AddRandom(fleet, heavy2, 20);

            if (hasUltimate)
            {
                AddUltimateRandom(fleet, ultimate);
            }

            return fleet;
        }

        private static FleetInfo GetRandomFleetUtopianUnits(bool hasUltimate)
        {
            FleetInfo fleet = new FleetInfo("RandomUtopians");
            fleet.TournamentFleet = true;

            IUnitInfo[] cannonFooder = { Rain.Resource };
            IUnitInfo[] specialLight = { Samurai.Resource, Raptor.Resource };

            IUnitInfo[] medium1 = { Eagle.Resource };
            IUnitInfo[] medium2 = { Pretorian.Resource, Krill.Resource };
            IUnitInfo[] medium3 = { Kahuna.Resource };

            IUnitInfo[] heavy1 = { Taurus.Resource, };
            IUnitInfo[] heavy2 = { Fenix.Resource };
            IUnitInfo[] heavy3 = { Crusader.Resource, Nova.Resource };

            IUnitInfo[] ultimate = { Blinker.Resource };

            AddRandom(fleet, cannonFooder, 100);
            AddRandom(fleet, specialLight, 65);

            AddRandom(fleet, medium1, 50);
            AddRandom(fleet, medium2, 40);
            AddRandom(fleet, medium3, 50);

            AddRandom(fleet, heavy1, 15);
            AddRandom(fleet, heavy2, 20);
            AddRandom(fleet, heavy3, 15);

            if (hasUltimate) {
                AddUltimateRandom(fleet, ultimate);
            }

            return fleet;
        }

        private static FleetInfo GetRandomBugsFleet(bool hasUltimate)
        {
            FleetInfo fleet = new FleetInfo("Random");
            fleet.TournamentFleet = true;

            IUnitInfo[] cannonFooder = { Seeker.Resource };
            IUnitInfo[] specialLight = { Sentry.Resource };

            IUnitInfo[] medium1 = { HiveProtector.Resource };
            IUnitInfo[] medium2 = { Destroyer.Resource };
            IUnitInfo[] medium3 = { Worm.Resource, Stinger.Resource };
            IUnitInfo[] medium4 = { Spider.Resource };

            IUnitInfo[] heavy1 = { BlackWidow.Resource};
            IUnitInfo[] heavy2 = { HeavySeeker.Resource, HiveKing.Resource };

            IUnitInfo[] ultimate = { Queen.Resource };

            AddRandom(fleet, cannonFooder, 80);
            AddRandom(fleet, specialLight, 80);

            AddRandom(fleet, medium1, 40);
            AddRandom(fleet, medium2, 60);
            AddRandom(fleet, medium3, 50);
            AddRandom(fleet, medium4, 40);

            AddRandom(fleet, heavy1, 20);
            AddRandom(fleet, heavy2, 20);

            if (hasUltimate) {
                AddUltimateRandom(fleet, ultimate);
            }

            return fleet;
        }

        private static FleetInfo GetRandomDarkHumansFleet(bool hasUltimate)
        {
            FleetInfo fleet = new FleetInfo("Random");
            fleet.TournamentFleet = true;

            IUnitInfo[] cannonFooder = { DarkRain.Resource, Anubis.Resource};
            IUnitInfo[] specialLight = { Toxic.Resource, Panther.Resource };

            IUnitInfo[] medium1 = { Driller.Resource };
            IUnitInfo[] medium2 = { Scarab.Resource };
            IUnitInfo[] medium3 = { Kamikaze.Resource };
            IUnitInfo[] medium4 = { Vector.Resource };
            

            IUnitInfo[] heavy1 = { DarkCrusader.Resource, Bozer.Resource, DarkTaurus.Resource};
            IUnitInfo[] heavy2 = { Doomer.Resource };

            IUnitInfo[] ultimate = { BattleMoon.Resource };

            AddRandom(fleet, cannonFooder, 100);
            AddRandom(fleet, specialLight, 80);

            AddRandom(fleet, medium1, 50);
            AddRandom(fleet, medium2, 40);
            AddRandom(fleet, medium3, 50);
            AddRandom(fleet, medium4, 45);

            AddRandom(fleet, heavy1, 15);
            AddRandom(fleet, heavy2, 20);

            if (hasUltimate) {
                AddUltimateRandom(fleet, ultimate);
            }

            return fleet;
        }

        private static FleetInfo GetRandomMobsFleet(bool hasUltimate)
        {
            FleetInfo fleet = new FleetInfo("Random");
            fleet.TournamentFleet = true;

            IUnitInfo[] cannonFooder = { Sentry.Resource };
            IUnitInfo[] specialLight = { Reaper.Resource };

            IUnitInfo[] medium1 = { Scourge.Resource };
            IUnitInfo[] medium2 = { Walker.Resource };

            IUnitInfo[] heavy1 = { Titan.Resource };

            IUnitInfo[] boss1 = { SilverBeard.Resource };
            IUnitInfo[] boss2 = { MetallicBeard.Resource };

            AddRandom(fleet, cannonFooder, 80);
            AddRandom(fleet, specialLight, 80);

            AddRandom(fleet, medium1, 150);
            AddRandom(fleet, medium2, 150);

            AddRandom(fleet, heavy1, 100);

            AddRandom(fleet, boss1, 1);
            AddRandom(fleet, boss2, 1);

            return fleet;
        }

        private static void AddRandom(FleetInfo fleet, IUnitInfo[] units, int quantity)
        {
            IUnitInfo lucky = units[ random.Next(0, units.Length) ];
            fleet.Add(lucky, quantity);
        }

        private static void AddUltimateRandom(FleetInfo fleet, IUnitInfo[] units)
        {
            IUnitInfo lucky = units[random.Next(0, units.Length)];
            fleet.AddUltimate(lucky);
        }

        #endregion Build Random Fleet

    }
}
