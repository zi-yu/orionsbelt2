using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {

	/// <summary>
	/// Represents a sector of empty space
	/// </summary>
	[FactoryKey("RelicBattleSector")]
	public class RelicBattleSector : Sector {

		#region Fields

		private readonly int battleId;
		private static readonly string type = "RelicBattleSector";
		
		#endregion Fields

		#region Properties

		public override bool IsInBattle {
			get { return true;}
			set {}
		}

		public override string Type {
			get { return type; }
		}

		public override string DisplayTypeShort {
			get { return "rb"; }
		}

		public int BattleId {
			get { return battleId; }
		}

		#endregion Properties

		#region Private

		protected override object CreateSector(SectorStorage sectorStorage) {
			return new RelicBattleSector(sectorStorage);
		}

		private void LoadFleet() {
			foreach (Fleet f in storage.Fleets) {
				IFleetInfo fleet = new FleetInfo(f);
				fleet.Sector = this;
				CelestialBodies.Add(fleet);
			}
		}

		#endregion Private

		#region Public

		/// <summary>
		/// Event that is called when a object is moved to this sector
		/// </summary>
		/// <param name="args">Arguments of the movement</param>
		public override void OnMove(IUniverseMoveArgs args) {
		}

		public override bool IsOwner(IPlayer player) {
			foreach (ICelestialBody body in CelestialBodies) {
				if (body is IFleetInfo) {
					if (player.Equals(((IFleetInfo) body).Owner)) {
						return true;
					}
				}
			}
			
			return false;
		}

		#endregion Public

		#region IBackToStorage<SectorStorage> Members

		public override void UpdateStorage() {
			base.UpdateStorage();
			if (IsInBattle) {
				storage.AdditionalInformation = battleId.ToString();
			}
			storage.Type = Type;
			IsDirty = false;
		}

		#endregion IBackToStorage<SectorStorage> Members

		#region Constructor

		public RelicBattleSector() { }

		public RelicBattleSector(Coordinate system, Coordinate sector, int level, int battleId)
			: base(system, sector,level) {
			this.battleId = battleId;
		}

		public RelicBattleSector(SectorStorage sectorStorage) 
			: base(sectorStorage) 
		{
			battleId = int.Parse(sectorStorage.AdditionalInformation);
			LoadFleet();
			isDirty = false;
		}

		#endregion Constructor

	}
}
