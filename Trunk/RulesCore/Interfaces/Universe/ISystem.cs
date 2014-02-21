using System.Collections.Generic;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface ISystem {

		/// <summary>
		/// Coordinate of the System
		/// </summary>
		Coordinate Coordinate {get;set;}

		/// <summary>
		/// Level of the system
		/// </summary>
		int Level {get;set;}

		/// <summary>
		/// List of all sectors
		/// </summary>
		Dictionary<Coordinate, ISector> Sectors {get;}

		/// <summary>
		/// Owner of the system
		/// </summary>
		IPlayer Owner {get;set;}

		/// <summary>
		/// Adds a sector to this system
		/// </summary>
		/// <param name="sector">Sector to add</param>
		void AddSector( ISector sector );

		/// <summary>
		/// Adds a sector to this system
		/// </summary>
		/// <param name="sector">Sector to add</param>
		void UpdateSector( ISector sector);

		/// <summary>
		/// Gets the sector with the passed coordinate
		/// </summary>
		/// <param name="sectorCoordinate">Sector's coordinate</param>
		ISector GetSector(Coordinate sectorCoordinate);

		/// <summary>
		/// Removes the passed sector
		/// </summary>
		/// <param name="sectorCoordinate">The sector to remove</param>
		void RemoveSector(Coordinate sectorCoordinate);

		/// <summary>
		/// checks if the system contains the passed coordinate
		/// </summary>
		bool HasSector(Coordinate sectorCoordinate);

		/// <summary>
		/// Adds a range of sectors
		/// </summary>
		/// <param name="s"></param>
		void AddSectorRange(List<ISector> s);
	}
}
