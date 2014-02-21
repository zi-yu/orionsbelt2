using System;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Resources {

    /// <summary>
    /// This class represents a Celestial Body 
    /// </summary>
    public abstract class CelestialBody : ICelestialBody {

        #region ICelestialBody Members

		protected SectorCoordinate location;
        public SectorCoordinate Location {
            get {
                if (location == null) {
                    throw new Exception("This body does not have a location");
                }
                return location;
            }
            set { location = value; }
        }

        public virtual bool Movable {
            get { return false; }
			set {}
        }

		public bool HasLoadedOwner {
			get { return true; }
		}

		public abstract bool HasLoadedSector {get;}

		public abstract ISector Sector {get;set; }

    	#endregion

    };
}
