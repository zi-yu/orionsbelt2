using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.Engine.Common;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {

	/// <summary>
	/// Represents a sector of empty space
	/// </summary>
	[FactoryKey("PlanetBattleSector")]
	public class PlanetBattleSector : Sector {

		#region Fields

		private int battleId;
		private static readonly string type = "PlanetBattleSector";
		
		#endregion Fields

		#region Properties

		public override bool IsInBattle {
			get {
				return true;
			}
			set {}
		}

		public override string Type {
			get { return type; }
		}

		public override string DisplayTypeShort {
			get { return GetPlanet().Info.ShortIdentifier + "b"; }
		}

		public override bool IsStatic {
			get {
				return true;
			}
			set {}
		}

		public int BattleId {
			get { return battleId; }
		}

		#endregion Properties

		#region Private

		protected override object CreateSector(SectorStorage sectorStorage) {
			return new PlanetBattleSector(sectorStorage);
		}

		#endregion Private

		#region Public

		public override IFleetInfo GetBattleFleet() {
			foreach (ICelestialBody celestialbody in CelestialBodies) {
				if (celestialbody is IFleetInfo) {
					IFleetInfo f = (IFleetInfo)celestialbody;
					if (f.IsPlanetDefenseFleet) {
						return f;
					}
				}
			}
			throw new EngineException("There should be a Defense Fleet in a planet sector");
		}

		public override bool IsOwner(IPlayer player) {
			foreach (ICelestialBody body in CelestialBodies) {
				if (body is IFleetInfo) {
					if (player.Equals(((IFleetInfo)body).Owner)) {
						return true;
					}
				}
				if (body is IPlanet) {
					if (player.Equals(((IPlanet)body).Owner)) {
						return true;
					}
				}
			}

			return false;
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

		public IFleetInfo GetEnemyFleet() {
			foreach (ICelestialBody celestialbody in CelestialBodies) {
				if (celestialbody is IFleetInfo) {
					IFleetInfo f = (IFleetInfo)celestialbody;
					if ( !f.IsPlanetDefenseFleet ) {
						return f;
					}
				}
			}
			throw new EngineException("There should be a valif fleet");
		}

        #endregion Public

		#region IBackToStorage<SectorStorage> Members

		public override void UpdateStorage() {
			base.UpdateStorage();
			if( IsInBattle ) {
				storage.AdditionalInformation = battleId.ToString();
			}
			storage.Type = Type;
			IsDirty = false;
		}

		#endregion IBackToStorage<SectorStorage> Members
		
		#region Constructor

		public PlanetBattleSector() { }

		public PlanetBattleSector(Coordinate system, Coordinate sector, int level, int battleId)
			: base(system, sector,level) {
			this.battleId = battleId;
		}

		public PlanetBattleSector(SectorStorage sectorStorage) 
			: base(sectorStorage) 
		{
			battleId = int.Parse(sectorStorage.AdditionalInformation);
			LoadCelestialBodies(sectorStorage);
			isDirty = false;
		}

		private void LoadCelestialBodies(SectorStorage sectorStorage) {
			foreach (Fleet f in sectorStorage.Fleets) {
				IFleetInfo fleet = new FleetInfo(f);
				AddCelestialBody(fleet);	
			}
			
			IPlanet planet = PlanetConversion.ConvertToPlanet(sectorStorage.Planets[0], this);
			CelestialBodies.Add(planet);
		}

		#endregion Constructor

	}
}
