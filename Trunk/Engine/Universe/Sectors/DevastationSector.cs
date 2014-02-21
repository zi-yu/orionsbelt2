using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {

	/// <summary>
	/// Represents a sector of empty space
	/// </summary>
	[FactoryKey("DevastationSector")]
	public class DevastationSector : Sector{

		#region Fields

		private static readonly string type = "DevastationSector";
		
		#endregion Fields

		#region Properties

		public override string Type {
			get { return type; }
		}

		public override string DisplayTypeShort {
			get { return "ds"; }
		}

		#endregion Properties

		#region Private

		protected override object CreateSector(SectorStorage sectorStorage) {
			return new DevastationSector(sectorStorage);
		}

		#endregion Private

		#region Public

		/// <summary>
		/// Event that is called when a object is moved to this sector
		/// </summary>
		/// <param name="args">Arguments of the movement</param>
		public override void OnMove(IUniverseMoveArgs args) {
		}

		public override void AddCelestialBody(ICelestialBody celestialBody) { }

		#endregion Public

		#region IBackToStorage<SectorStorage> Members

		public override bool IsDirty {
			get { return false; }
			set {}
		}

		#endregion IBackToStorage<SectorStorage> Members

		#region Constructor

		public DevastationSector() {}

		public DevastationSector(Coordinate system, Coordinate sector, IPlayer owner)
			: base(system, sector, SectorUtils.GetLevel(system)) {
			this.owner = owner;
		}

		public DevastationSector(SectorStorage sectorStorage) 
			: base(sectorStorage) {
			isDirty = false;
		}

		#endregion Constructor

	}
}
