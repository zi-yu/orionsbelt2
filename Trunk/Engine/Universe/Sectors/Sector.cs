using System.Collections.Generic;
using DesignPatterns;
using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {

	[NoAutoRegister]
	public abstract class Sector : ISector, IFactory {

		#region Fields

		protected static readonly char[] separator = new char[] { ';' };
		private int level;
		protected SectorCoordinate currentCoordinate;
		protected bool isStatic;
		protected bool isConstructing;
		protected bool isInBattle;
		protected bool isMoving;
		private bool isPrivate = false;
		protected string subType;
		private readonly List<ICelestialBody> celestialBodies = new List<ICelestialBody>();
		protected IPlayer owner;
		private IResourceQuantity resource = null;
		protected SectorStorage storage;
		protected bool isDirty = false;
		protected bool loadOwner = true;

		#endregion Fields

		#region Properties

		public virtual SectorCoordinate Coordinate {
			get { return currentCoordinate; }
			set { Touch(); currentCoordinate = value; }
		}

		public Coordinate SystemCoordinate {
			get { return currentCoordinate.System; }
			set { Touch(); currentCoordinate.System = value; }
		}

		public Coordinate SectorCoordinate {
			get { return currentCoordinate.Sector; }
			set { Touch(); currentCoordinate.Sector = value; }
		}

		public virtual bool IsInBattle {
			get { return isInBattle; }
			set {
				isInBattle = value;
				Touch();
			}
		}

		public bool HasResource {
			get { return resource != null; }
		}

		public string SubType {
			get { return subType; }
			set { Touch(); subType = value; }
		}

		public int Level {
			get { return level; }
			set { Touch(); level = value; }
		}

		public virtual bool IsStatic {
			get { return isStatic; }
			set {
				isStatic = value;
				Touch();
			}
		}

		public virtual IPlayer Owner {
			get {
				if (owner == null && loadOwner) {
					if (Storage != null && Storage.Owner != null) {
						owner = PlayerUtils.LoadPlayer(Storage.Owner);
					}
				}
				
				return owner;
			}
			set {
				loadOwner = false;
				owner = value;
				Touch();
			}
		}

		public virtual bool IsConstructing {
			get { return isConstructing; }
			set {
				isConstructing = value;
				Touch();
			}
		}

		public virtual bool IsMoving {
			get { return isMoving; }
			set { 
				isMoving = value;
				Touch();  
			}
		}

		public bool IsPrivate {
			get { return isPrivate; }
			set {
				isPrivate = value;
				Touch(); 
			}
		}

		public List<ICelestialBody> CelestialBodies {
			get { return celestialBodies; }
		}

		public IResourceQuantity Resource {
			get { return resource; }
			set { Touch(); resource = value; }
		}

		#endregion Properties

		#region Static

		public static readonly Coordinate MinCoordinate = new Coordinate(1, 1);
		public static readonly Coordinate MaxCoordinate = new Coordinate(7, 10);

		#endregion Static

		#region IBackToStorage<SectorStorage> Members

		public SectorStorage Storage {
			get { return storage; }
			set { storage = value; }
		}

		public virtual void UpdateStorage() {
			SectorUtils.UpdateStorage(storage,this);
			IsDirty = false;
		}

		public virtual void PrepareStorage() {
			if( storage == null ) {
				storage = SectorUtils.ConvertToStorage(this);
			}
		}

		public void Touch() {
			IsDirty = true;
		}

		public virtual bool IsDirty {
			get { return isDirty; }
			set { isDirty = value; }
		}

		#endregion IBackToStorage<SectorStorage> Members

		#region IFactory Members

		/// <summary>
		/// Creates a new instance of this object
		/// </summary>
		/// <param name="args">SectorStorage to create a new Sector</param>
		/// <returns>A new Sector</returns>
		public object create(object args) {
			SectorStorage sectorStorage = (SectorStorage)args;
			return CreateSector(sectorStorage);
		}

		#endregion IFactory Members

		#region Abstract & Virtual

		protected abstract object CreateSector(SectorStorage sectorStorage);

        protected void LoadPlanet(SectorStorage sectorStorage) {
			if( sectorStorage.Planets.Count > 0 ) {
				IPlanet planet = PlanetConversion.ConvertToPlanet(sectorStorage.Planets[0], this);
				CelestialBodies.Add(planet);
			}
		}

		public abstract string Type { get; }
		
		/// <summary>
		/// Friendly Name to display
		/// </summary>
		public virtual string DisplayType {
			get{ return Type; }
		}

		/// <summary>
		/// Friendly Name to display
		/// </summary>
		public virtual string DisplayTypeShort {
			get { return Type; }
		}

		/// <summary>
		/// Event that is called when a object is moved to this sector
		/// </summary>
		/// <param name="args">Arguments of the movement</param>
		public virtual void OnMove(IUniverseMoveArgs args) { }

		/// <summary>
		/// Method call when the turn is passed
		/// </summary>
		public virtual void Turn(){}

		/// <summary>
		/// Adds a new celestial body to this sector
		/// </summary>
		/// <param name="celestialBody"></param>
		public virtual void AddCelestialBody(ICelestialBody celestialBody) {
			celestialBody.Sector = this;
			celestialBodies.Add(celestialBody);
			Touch();
		}

		/// <summary>
		/// Adds the celestial bodies from the passed sector to the current sector
		/// </summary>
		/// <param name="sector"></param>
		public virtual void AddCelestialBodies(ISector sector) {
			foreach( ICelestialBody celestialBody in sector.CelestialBodies ) {	
				celestialBodies.Add(celestialBody);
                celestialBody.Sector = this;
			}
			Touch();
		}

		/// <summary>
		/// Gets the fleet to enter in the battle
		/// </summary>
		/// <returns>the object that represent the fleet that is going to enter in the battle</returns>
		public virtual IFleetInfo GetBattleFleet() {
			return null;
		}

		/// <summary>
		/// Gets the fleet with the passed id
		/// </summary>
		/// <returns></returns>
		public IFleetInfo GetFleet(int id) {
			foreach (ICelestialBody celestialBody in CelestialBodies) {
				if( celestialBody is IFleetInfo ) {
					IFleetInfo fleet = (IFleetInfo) celestialBody;
					if( fleet.Id == id ) {
						return fleet;
					}
				}
			}
			return null;
		}

		#endregion Abstract & Virtual

		#region Public

		public override string ToString() {
			return string.Format("{0}:{1}", currentCoordinate.Sector.X, currentCoordinate.Sector.Y);
		}

		public virtual bool IsOwner(IPlayer player) {
			return Owner != null && Owner.Equals(player);
		}

		public IEnumerable<IFleetInfo> GetFleets() {
			foreach (ICelestialBody celestialbody in celestialBodies) {
				if (celestialbody is IFleetInfo) {
					yield return (IFleetInfo)celestialbody;
				}
				if (celestialbody is IPlanet) {
					yield return ((IPlanet)celestialbody).DefenseFleet;
				}
			}
		}

		public virtual IPlanet GetPlanet() {
            return null;
		}

		#endregion Public

		#region Constructor

		public Sector() {}

		public Sector( Coordinate system, Coordinate sector, int level) 
			: this(system,sector,level,false){}

		public Sector(Coordinate system, Coordinate sector, int level, bool isPrivate ) {
			currentCoordinate = new SectorCoordinate(system,sector);
			isStatic = false;
			isConstructing = false;
			isInBattle = false;
			isMoving = false;
			Level = level;
			IsPrivate = isPrivate;
			Touch();
		}

		public Sector(SectorStorage sectorStorage) {
			Coordinate system = new Coordinate(sectorStorage.SystemX, sectorStorage.SystemY);
			Coordinate sector = new Coordinate(sectorStorage.SectorX, sectorStorage.SectorY);
			currentCoordinate = new SectorCoordinate(system, sector);
			isStatic = sectorStorage.IsStatic;
			isConstructing = sectorStorage.IsConstructing;
			isInBattle = sectorStorage.IsInBattle;
			//isPrivate = ;
			isMoving = sectorStorage.IsMoving;
			SubType = sectorStorage.SubType;
			storage = sectorStorage;
			level = sectorStorage.Level;
			isDirty = false;
		}

		#endregion Constructor

	}
}
