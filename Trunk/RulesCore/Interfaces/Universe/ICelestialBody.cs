using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents an object that is present in the Universe
    /// </summary>
    public interface ICelestialBody {

        /// <summary>
        /// The body location
        /// </summary>
        SectorCoordinate Location { get; set;}

        /// <summary>
        /// Indicates if the object is fixed or not
        /// </summary>
        bool Movable { get; set; }

		/// <summary>
		/// The planet's sector
		/// </summary>
		ISector Sector { get;set;}

		/// <summary>
		/// if the sector was loaded
		/// </summary>
		bool HasLoadedSector { get;}

		/// <summary>
		/// if the sector was loaded
		/// </summary>
		bool HasLoadedOwner { get; }


    };
}
