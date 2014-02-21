using System.Collections.Generic;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine.Universe {
	public class SectorCoordinateContainer {

		#region Fields

		private readonly List<Coordinate> systemCoordinates = new List<Coordinate>();
		private readonly List<SectorCoordinate> orderedSectors = new List<SectorCoordinate>();
		private readonly Dictionary<Coordinate, List<SectorCoordinate>> sectorInformationContainer = new Dictionary<Coordinate, List<SectorCoordinate>>();
		private SectorCoordinate startCoordinate;
		private SectorCoordinate exceptionCoordinate;

		#endregion Fields

		#region Properties

		public SectorCoordinate StartCoordinate {
			get { return startCoordinate; }
			set { startCoordinate = value; }
		}

		public List<Coordinate> SystemCoordinates {
			get { return systemCoordinates; }
		}

		public List<SectorCoordinate> OrderedSectors {
			get { return orderedSectors; }
		}

		public SectorCoordinate ExceptionCoordinate {
			get { return exceptionCoordinate; }
			set { exceptionCoordinate = value; }
		}

		#endregion Properties

		#region Public

		/// <summary>
		/// Adds a new object that represents the information of a sector to render
		/// </summary>
		/// <param name="information">Sector Information to add to the container</param>
		public void Add(SectorCoordinate information) {
			if( !sectorInformationContainer.ContainsKey(information.System) ) {
				sectorInformationContainer.Add(information.System, new List<SectorCoordinate>());
				systemCoordinates.Add(information.System);
			}
			sectorInformationContainer[information.System].Add(information);
			orderedSectors.Add(information);
		}

		/// <summary>
		/// Obtains a list of all informations related with the passed system
		/// </summary>
		/// <param name="systemCoordinate">Coordinate of the system</param>
		/// <returns>List of all informations related with the passed system</returns>
		public List<SectorCoordinate> GetSystemInformation(Coordinate systemCoordinate) {
			if (sectorInformationContainer.ContainsKey(systemCoordinate)) {
				return sectorInformationContainer[systemCoordinate];
			}

			throw new UIException("Coordinate '{0}' not found in SectorCoordinateContainer", systemCoordinate);
		}
		
		#endregion Public

		
	}
}
