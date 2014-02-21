using System;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.RulesCore.Common {
	public class SectorCoordinate {

		#region Fields

		private Coordinate system;
		private Coordinate sector;
		private static readonly SectorCoordinate dummy = new SectorCoordinate(Coordinate.Dummy,Coordinate.Dummy);

		#endregion Fields

		#region Properties

		public Coordinate System {
			get { return system; }
			set { system = value; }
		}

		public Coordinate Sector {
			get { return sector; }
			set { sector = value; }
		}

		public static SectorCoordinate Dummy {
			get { return dummy; }
		}

		#endregion Properties

        #region Public

        /// <summary>
        /// Verifies if the sector coordinate is valid
        /// </summary>
		/// <param name="privateSystem">if we are testing a private system</param>
        /// <returns>true if it's valid, false otherwise</returns>
		public bool IsValid(bool privateSystem) {
            if (privateSystem){
				return system.IsPrivateSystem() && sector.IsValidSector();
            }
			return system.IsValid() && sector.IsValidSector();
		}

		public override string ToString() {
			return string.Format("{0}:{1}:{2}:{3}", System.X,System.Y,Sector.X,Sector.Y);
		}

        public string ToString(string separator){
            return string.Format("{0}{4}{1}{4}{2}{4}{3}", System.X, System.Y, Sector.X, Sector.Y,separator);
        }

		#endregion

		#region Operator Overloading
		
		public override bool Equals(object obj) {
			if (obj != null && obj is SectorCoordinate) {
				SectorCoordinate c = obj as SectorCoordinate;
				return this == c;
			}
			return false;
		}

		public override int GetHashCode() {
			return system.X*1000000+System.Y*10000+Sector.X*100+Sector.Y;
		}

		public static bool operator ==(SectorCoordinate c1, SectorCoordinate c2) {
			if (Equals(c1, null) && Equals(c2, null)) {
				return true;
			}
			if (Equals(c1, null) || Equals(c2, null)) {
				return false;
			}

			return c1.System == c2.System && c1.Sector == c2.Sector;
		}

		public static bool operator !=(SectorCoordinate c1, SectorCoordinate c2) {
			if( c1 == null && c2 == null ) {
				return false;
			}
			if( c1 == null || c2 == null ) {
				return true;
			}

			return !(c1.System == c2.System) && !(c1.Sector == c2.Sector);
		}

		#endregion Operator Overloading

		#region Constructor

		public SectorCoordinate(Coordinate system, Coordinate sector) {
			System = system;
			Sector = sector;
		}

		public SectorCoordinate(int systemX, int systemY, int sectorX, int sectorY ) {
			System = new Coordinate(systemX,systemY);
			Sector = new Coordinate(sectorX,sectorY);
		}

        public SectorCoordinate(string systemX, string systemY, string sectorX, string sectorY):
            this(int.Parse(systemX), int.Parse(systemY), int.Parse(sectorX), int.Parse(sectorY))
        {
        }

        public SectorCoordinate(string sector)
        {
            string[] coor = sector.Split(new char[] { ':','_' }, StringSplitOptions.RemoveEmptyEntries);
            System = new Coordinate(int.Parse(coor[0]), int.Parse(coor[1]));
            Sector = new Coordinate(int.Parse(coor[2]), int.Parse(coor[3]));

        }

		#endregion Constructor

	}
}
