
using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.Engine.Universe {
	internal class FogOfWarContainer {

		#region Fields

		private readonly Dictionary<Coordinate, FogOfWar> discoveredElements = new Dictionary<Coordinate, FogOfWar>();
		private readonly Dictionary<SectorCoordinate, UniverseVisibility> visibleCoordinates = new Dictionary<SectorCoordinate, UniverseVisibility>();

		#endregion Fields

		#region Properties

		public List<SectorCoordinate> VisibleCoordinates {
			get { return new List<SectorCoordinate>(visibleCoordinates.Keys); }
		}

		public Dictionary<Coordinate, FogOfWar> DiscoveredElements {
			get { return discoveredElements; }
		}

		#endregion Properties

		#region Public

		public void AddVisibleCoordinates(SectorInformation currentSector) {
			int w = currentSector.WidthVisibility*2 + 1;
			int h = currentSector.HeightVisibility*2 + 1;

			SectorCoordinate start =
				CoordinateRangeCalculator.GetStartSystemAndSectorVisibility(currentSector.Coordinate.System,
				                                                            currentSector.Coordinate.Sector,
				                                                            currentSector.HeightVisibility,
				                                                            currentSector.WidthVisibility);
			foreach (SectorCoordinate coordinate in CoordinateRangeCalculator.GetPossibleCoordinates(start, h, w)) {
				if (!visibleCoordinates.ContainsKey(coordinate)) {
					visibleCoordinates.Add(coordinate, currentSector.VisibleToken);
				}
				else {
					UniverseVisibility curr = visibleCoordinates[coordinate];
					visibleCoordinates[coordinate] = curr.EvalImportance(currentSector.VisibleToken);
				}
			}
		}

		public UniverseVisibility GetVisibility(SectorInformation currentSector) {
			return GetVisibility(currentSector.Coordinate);
		}

		public UniverseVisibility GetVisibility(SectorCoordinate currentSector) {
			if (visibleCoordinates.ContainsKey(currentSector) ) {
				return visibleCoordinates[currentSector];
			}

			if (discoveredElements.ContainsKey(currentSector.System)) {
				FogOfWar fogsOfWar = DiscoveredElements[currentSector.System];
				return fogsOfWar.CoordinateState(currentSector);
			}

			return Undiscovered.Instance;
		}

		public void AddFogOfWar(FogOfWarStorage storage) {
			FogOfWar fogOfWar = new FogOfWar(storage);
			discoveredElements[fogOfWar.System] = fogOfWar;
		}

		#endregion public

		#region Constructor

		public FogOfWarContainer(IList<FogOfWarStorage> fogsOfWar) {
			foreach (FogOfWarStorage storage in fogsOfWar) {
				AddFogOfWar(storage);
			}
		}
		public FogOfWarContainer() {}

		#endregion Constructor

		
	}
}
