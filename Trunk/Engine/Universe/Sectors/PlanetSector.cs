using System;
using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.UniverseInfo;

namespace OrionsBelt.Engine.Universe {

	[FactoryKey("PlanetSector")]
	public class PlanetSector : Sector {

		#region Fields

		private static readonly string type = "PlanetSector";
		private IPlanetInfo planetInfo;
		private ITerrainInfo terrainInfo;

		#endregion Fields

		#region Properties

		public override string Type {
			get { return type; }
		}

		public override bool IsStatic {
			get { return true; }
		}

		public override bool IsConstructing {
			get { return false; }
			set { }
		}

		public override string DisplayType {
			get { return planetInfo.Identifier; }
		}

		public override string DisplayTypeShort {
			get { return planetInfo.ShortIdentifier; }
		}

        public bool HasPlanet{
            get { return GetPlanet() != null; }
        }

		public override IPlayer Owner {
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

		#endregion Properties

		#region Private

		private void LoadInfos(){
			string[] types = SubType.Split(separator);
			planetInfo = PlanetInfo.Get(types[0]);
			terrainInfo = TerrainInfo.Get(types[1]);
		}

		protected override object CreateSector(SectorStorage sectorStorage) {
			return new PlanetSector(sectorStorage);
		}

		private void SetInfos(bool isPrivate,IPlayer owner) {
			if (isPrivate && owner != null) {
				planetInfo = PlanetInfo.GetRandomPrivateZone(owner);
			} else {
				planetInfo = PlanetInfo.GetRandomHotZone();
			}
			terrainInfo = TerrainInfo.GetRandom();
			SubType = string.Format("{0};{1}", planetInfo.Identifier, terrainInfo.Terrain);
		}

		#endregion Private

		#region Public

		public override IFleetInfo GetBattleFleet() {
			return ((IPlanet) CelestialBodies[0]).DefenseFleet;
		}

		public override IPlanet GetPlanet() {
			if (CelestialBodies.Count == 0) {
				LoadPlanet(Storage);
			}

			ICelestialBody planet = CelestialBodies.Find(delegate(ICelestialBody body) { return body is IPlanet; });
			if (planet != null) {
				return (IPlanet)planet;
			}

			return null;
		}

		public IPlanetInfo GetPlanetInfo() {
			return planetInfo;
		}

		public ITerrainInfo GetTerrainInfo() {
			return terrainInfo;
		}

		#endregion Public

		#region Constructor

		public PlanetSector() { }

		public PlanetSector(Coordinate system, Coordinate sector, IPlanet planet, int level)
			: this(system, sector, planet, level, false) {
		}

		public PlanetSector(Coordinate system, Coordinate sector, int level, bool isPrivate)
			: this(null, system,sector,level, isPrivate) {
		}

		public PlanetSector(IPlayer owner, Coordinate system, Coordinate sector, int level, bool isPrivate)
			: this(system,sector,null,level, isPrivate) {
			SetInfos(isPrivate, owner);
		}

		public PlanetSector(Coordinate system, Coordinate sector, IPlanet planet, int level, bool isPrivate)
			: base(system, sector, level) {
			IsPrivate = isPrivate;
			if (planet != null) {
                SubType = string.Format("{0};{1}", planet.Info.Identifier, planet.Terrain.Terrain);
				owner = planet.Owner;
                AddCelestialBody(planet);
                AddCelestialBody(planet.DefenseFleet);
			}else {
				SetInfos(isPrivate,null);
			}
		}

		public PlanetSector(SectorStorage sectorStorage)
			: base(sectorStorage) {
			LoadInfos();
			isDirty = false;
		}

		#endregion Constructor

	}
}
