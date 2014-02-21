using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.Engine.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {

	/// <summary>
	/// Represents a sector of empty space
	/// </summary>
	[FactoryKey("RelicSector")]
	public class RelicSector : Sector {

		#region Fields

		private static readonly string type = "RelicSector";
        private static readonly int RelicConquerDelay = 100;
        private int lastConquerTick = 0;

		#endregion Fields

		#region Properties

		public override string Type {
			get { return type; }
		}

		public override bool IsStatic {
			get { return true; }
			set { }
		}

		public override bool IsConstructing {
			get { return false; }
			set {}
		}

		public override string DisplayTypeShort {
			get { return "r"; }
		}

        public bool CanConquer{
            get { 
                if(Server.IsInTests) {
                    return true;
                }
                return !(Clock.Instance.Tick < LastConquerTick + RelicConquerDelay); 
            }
        }

        public int LastConquerTick{
            get { return lastConquerTick; }
            set{
                Touch();
                lastConquerTick = value;
            }
        }

		#endregion Properties

		#region Private

		protected override object CreateSector(SectorStorage sectorStorage) {
			return new RelicSector(sectorStorage);
		}

		private void LoadFleet(SectorStorage sectorStorage) {
			if (sectorStorage.Fleets.Count > 0) {
				IFleetInfo fleet = new FleetInfo(sectorStorage.Fleets[0]);
				fleet.Sector = this;
				fleet.IsInBattle = false;
				CelestialBodies.Add(fleet);
			}
		}

		#endregion Private

		#region Public

		public override void UpdateStorage() {
			if(CelestialBodies.Count > 0) {
				IFleetInfo fleet = GetBattleFleet();
				fleet.PrepareStorage();
				fleet.UpdateStorage();
				storage.Fleets.Add(fleet.Storage);
                storage.AdditionalInformation = LastConquerTick.ToString();
			}
			base.UpdateStorage();
		}

		public override IFleetInfo GetBattleFleet() {
			if (CelestialBodies == null || CelestialBodies.Count == 0) {
				throw new EngineException("FleetSector at {0} is invalid. Id: {1}", Coordinate.ToString(), Storage.Id);
			}
			return (IFleetInfo)CelestialBodies[0];
		}

		public bool HasBattleFleet() {
			return CelestialBodies != null && CelestialBodies.Count > 0;
		}

		#endregion Public

		#region Constructor

		public RelicSector(){}

		public RelicSector(Coordinate system, Coordinate sector, int level)
			: base(system, sector, level) {
		}

		public RelicSector(SectorStorage sectorStorage) 
			: base(sectorStorage) 
		{
			LoadFleet(sectorStorage);
            if( !string.IsNullOrEmpty(sectorStorage.AdditionalInformation) ) {
                lastConquerTick = int.Parse(sectorStorage.AdditionalInformation);
            }
		}

		#endregion Constructor

	}
}
