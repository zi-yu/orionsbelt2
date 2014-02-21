using System.Collections.Generic;
using OrionsBelt.Engine.Common;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {
	public class System : ISystem {

		#region Fields

		private Coordinate coordinate;
		private readonly Dictionary<Coordinate, ISector> sectors = new Dictionary<Coordinate, ISector>();
		private int level = 1;
		private IPlayer owner;

		#endregion Fields

		#region Properties

		public Coordinate Coordinate {
			get { return coordinate; }
			set { coordinate = value; }
		}

		public int Level {
			get { return level; }
			set { level = value; }
		}

		public Dictionary<Coordinate, ISector> Sectors {
			get { return sectors; }
		}

		public IPlayer Owner {
			get { return owner; }
			set { owner = value; }
		}

		#endregion Properties

		#region Public

		/// <summary>
		/// Adds a sector to this system
		/// </summary>
		/// <param name="sector">Sector to add</param>
		public void AddSector(ISector sector) {
			if (Sectors.ContainsKey(sector.SectorCoordinate)) {
				string owner = sector.Owner != null ? sector.Owner.Name : string.Empty;
				throw new EngineException("System {0} already contains sector {1}. Owner: {2}", Coordinate, sector.SectorCoordinate, owner);
			}
			Sectors.Add(sector.SectorCoordinate, sector);
		}

		public void AddSectorRange(List<ISector> s) {
			foreach (ISector sector in s) {
				AddSector(sector);
			}
		}

		/// <summary>
		/// Adds a sector to this system
		/// </summary>
		/// <param name="sector">Sector to add</param>
		public void UpdateSector(ISector sector) {
			Sectors[sector.SectorCoordinate] = sector;
		}

		/// <summary>
		/// Gets the sector with the passed coordinate
		/// </summary>
		/// <param name="sectorCoordinate">Sector's coordinate</param>
		public ISector GetSector(Coordinate sectorCoordinate) {
			if (!Sectors.ContainsKey(sectorCoordinate)) {
				return new NormalSector(Coordinate, sectorCoordinate, level, owner);
			}
			return Sectors[sectorCoordinate];
		}

		/// <summary>
		/// Removes the passed sector
		/// </summary>
		/// <param name="sectorCoordinate">The sector to remove</param>
		public void RemoveSector(Coordinate sectorCoordinate) {
			if (Sectors.ContainsKey(sectorCoordinate)) {
				Sectors.Remove(sectorCoordinate);
			}
		}

		/// <summary>
		/// checks if the system contains the passed coordinate
		/// </summary>
		public bool HasSector(Coordinate sectorCoordinate) {
			return Sectors.ContainsKey(sectorCoordinate);
		}

		public override string ToString() {
			return string.Format("{0} - {1}", coordinate, level);
		}

		#endregion Public

		#region Constructor

		public System( Coordinate coordinate, int level ) {
			Coordinate = coordinate;
			Level = level;
		}

		public System(Coordinate coordinate, int level, IPlayer owner) {
			Coordinate = coordinate;
			Level = level;
			Owner = owner;
		}

		#endregion Constructor


		
	}
}
