using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {
	internal class FogOfWar : IBackToStorage<FogOfWarStorage> {

		#region Fields

		private static readonly char[] separator = new char[] { ';' };
		private bool hasDiscoveredAll;
		private bool hasDiscoveredHalf;
		private List<SectorCoordinate> coordinates = new List<SectorCoordinate>();
		private readonly Coordinate system;
		private FogOfWarStorage storage;
		private bool isDirty = false;
        private IPlayer owner = null;

        #endregion Fields

		#region Properties

		public bool HasDiscoveredAll {
			get { return hasDiscoveredAll; }
			set {
				Touch(); hasDiscoveredAll = value; }
		}

		public bool HasDiscoveredHalf {
			get { return hasDiscoveredHalf; }
			set { Touch(); hasDiscoveredHalf = value; }
		}

		public Coordinate System {
			get { return system; }
		}

        public IPlayer Owner {
            get { return owner; }
			set { Touch(); owner = value; }
        }

		#endregion Properties

		#region Private

		private string GetAllSectors() {
			StringBuilder builder = new StringBuilder();
			foreach (SectorCoordinate c in coordinates) {
				builder.AppendFormat("{0};", c.Sector);
			}
			return builder.ToString();
		}

		private void FillCoordinates(string sectors) {
			if( hasDiscoveredAll ) {
				return;
			}
			string[] coords = sectors.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			foreach (string c in coords) {
				coordinates.Add(new SectorCoordinate(System, new Coordinate(c)));
			}
			Touch();
		}

		private List<SectorCoordinate> FillMissingCoordinates() {
			List<SectorCoordinate> undiscovered = new List<SectorCoordinate>();
			for( int x = 1; x <= 7 ; ++x) {
				for (int y = 1; y <= 10; ++y) {
					SectorCoordinate coordinate = new SectorCoordinate(system, new Coordinate(x,y));
					if (!coordinates.Contains(coordinate)) {
						undiscovered.Add(coordinate);
					}
				}	
			}
			return undiscovered;
		}

		#endregion Private

		#region Public

		/// <summary>
		/// Returns the state of the coordinate. 
		/// 1 is not visible
		/// 2 is discovered but not visible
		/// </summary>
		/// <returns></returns>
		public UniverseVisibility CoordinateState(SectorCoordinate currentSector) {
			//If discovered all, all the coordinates are discovered. At this point there 
			//are only not visibles left
			if( hasDiscoveredAll ) {
				return Discovered.Instance;
			}

			//if half of the sector has been discovered, the coordinates
			//in the container are the coordinates yet to be discovered
			if( HasDiscoveredHalf ) {
				if( coordinates.Contains(currentSector)) {
					return Undiscovered.Instance;
				}
				return Discovered.Instance;
			}

			//if half of the sector has not been discovered, the coordinates
			//in the container are the coordinates already discovered
			if (coordinates.Contains(currentSector)) {
				return Discovered.Instance;
			}
			return Undiscovered.Instance;
		}

		public void AddCoordinate(SectorCoordinate coordinate) {
			if( hasDiscoveredAll) {
				return;
			}
			if( !hasDiscoveredHalf){
				if (!coordinates.Contains(coordinate)){
					coordinates.Add(coordinate);
				}
			}else {
				coordinates.Remove(coordinate);
				
			}
			Touch();
		}

		#endregion Public

		#region IBackToStorage<FogOfWarStorage> Members

		public FogOfWarStorage Storage {
			get { return storage; }
			set { storage = value; }
		}

		public void UpdateStorage() {
			if (owner != null) {
				storage.Owner = owner.Storage;
			}

			storage.SystemX = system.X;
			storage.SystemY = system.Y;

			if (HasDiscoveredHalf && coordinates.Count == 0 ) {
				HasDiscoveredAll = true;
			}

			if( coordinates.Count > 35 ) {
				HasDiscoveredHalf = true;
				coordinates = FillMissingCoordinates();
			}

			storage.HasDiscoveredAll = HasDiscoveredAll;
			storage.HasDiscoveredHalf = HasDiscoveredHalf;
			storage.Sectors = GetAllSectors();
		}

		public void PrepareStorage() {
			if( storage == null ) {
				storage = Persistance.Create<FogOfWarStorage>();
			}
		}

		public void Touch() {
			isDirty = true;
		}

		public bool IsDirty {
			get { return isDirty; }
			set { isDirty = value; }
		}

		#endregion IBackToStorage<FogOfWarStorage> Members

		#region Constructor

		public FogOfWar(FogOfWarStorage storage) {
			system = new Coordinate(storage.SystemX, storage.SystemY);
			HasDiscoveredAll = storage.HasDiscoveredAll;
			HasDiscoveredHalf = storage.HasDiscoveredHalf;
			FillCoordinates(storage.Sectors);

			if (storage.Owner != null ) {
                owner = PlayerUtils.LoadPlayer(storage.Owner);
			}
            this.storage = storage;
			isDirty = false;
		}

		public FogOfWar(Coordinate system) {
			this.system = system;
			HasDiscoveredAll = false;
			HasDiscoveredHalf = false;
			isDirty = true;
		}

		#endregion Constructor

	}
}
