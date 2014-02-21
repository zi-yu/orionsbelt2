using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {

	/// <summary>
	/// Represents a sector of empty space
	/// </summary>
	[FactoryKey("BugsWormHoleSector")]
	public class BugsWormHoleSector : UltimateSectorBase {

		#region Fields

		private static readonly string type = "BugsWormHoleSector";

		#endregion Fields

		#region Properties

		public override string Type {
			get { return type; }
		}

		public override string DisplayTypeShort {
			get { return "bw"; }
		}

		#endregion Properties

		#region Private

		protected override object CreateSector(SectorStorage sectorStorage) {
			return new BugsWormHoleSector(sectorStorage);
		}

		#endregion Private

		#region Constructor

		public BugsWormHoleSector() { }

		public BugsWormHoleSector(IPlayer owner, SectorCoordinate coordinate, int level)
			: base(owner,coordinate, level) {
			
		}

		public BugsWormHoleSector(SectorStorage sectorStorage)
			: base(sectorStorage) {
			if (!string.IsNullOrEmpty(sectorStorage.AdditionalInformation)) {
				UltimateLevel = int.Parse(sectorStorage.AdditionalInformation);
			}
		}

		#endregion Constructor

	}
}

