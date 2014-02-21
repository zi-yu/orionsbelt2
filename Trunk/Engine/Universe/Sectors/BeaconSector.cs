
using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {

	/// <summary>
	/// Represents a sector of empty space
	/// </summary>
	[FactoryKey("BeaconSector")]
	public class BeaconSector : UltimateSectorBase {

		#region Fields

		private static readonly string type = "BeaconSector";
		private int visibleArea;

		#endregion Fields

		#region Properties

		public override string Type {
			get { return type; }
		}

		public override string DisplayTypeShort {
			get { return "bc"; }
		}

		public int VisibleArea {
			get { return visibleArea; }
			set {
				Touch(); visibleArea = value; }
		}

		#endregion Properties

		#region Private

		protected override object CreateSector(SectorStorage sectorStorage) {
			return new BeaconSector(sectorStorage);
		}

		#endregion Private

		#region Public

		public override void UpdateStorage() {
			base.UpdateStorage();
			storage.AdditionalInformation = string.Format("{0};{1}",UltimateLevel,visibleArea);
			IsDirty = false;
		}

		#endregion Public

		#region Constructor

		public BeaconSector() { }

		public BeaconSector(IPlayer owner, SectorCoordinate coordinate, int level, int visibleArea)
			: base(owner,coordinate, level) {
			VisibleArea = visibleArea;
		}

		public BeaconSector(SectorStorage sectorStorage)
			: base(sectorStorage) {
			if (!string.IsNullOrEmpty(sectorStorage.AdditionalInformation)) {
				string[] info = sectorStorage.AdditionalInformation.Split(separator);
				UltimateLevel = int.Parse(info[0]);
				VisibleArea = int.Parse(info[1]);
			}
		}

		#endregion Constructor

	}
}
