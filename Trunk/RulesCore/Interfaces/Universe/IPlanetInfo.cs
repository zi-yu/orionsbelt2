using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents a planet configuration
    /// </summary>
    public interface IPlanetInfo : IResourceRichness {

        #region Properties

        /// <summary>
        /// The planet config identifier
        /// </summary>
        string Identifier { get;}

		/// <summary>
		/// The planet config identifier
		/// </summary>
		string ShortIdentifier { get;}

        /// <summary>
        /// The race related to this planet type
        /// </summary>
        IRaceInfo RaceInformation { get;}

        /// <summary>
        /// The race type
        /// </summary>
        Race RaceType { get;}

        /// <summary>
        /// True if this is a planet for the private zone
        /// </summary>
        bool HotZone { get; }

        /// <summary>
        /// True if this planet is abandonable
        /// </summary>
        bool MayAbandonPlanet { get;}

        /// <summary>
        /// Gets the planet facility slots
        /// </summary>
        IList<IFacilitySlot> FacilitySlots { get;}

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets a facility slot
        /// </summary>
        /// <param name="identifier">The identifier</param>
        /// <returns>The facility slot</returns>
        IFacilitySlot GetSlot(string identifier);

        /// <summary>
        /// Initializes a planet
        /// </summary>
        /// <param name="planet">The planet</param>
        void Initialize(IPlanet planet);

        /// <summary>
        /// Gets the facility that builds units on this planet
        /// </summary>
        /// <returns>The facility</returns>
        IFacilityInfo GetUnitBuilderFacility();

        /// <summary>
        /// If this planet has a main facility (eg: CommandCenter), returns it
        /// </summary>
        /// <returns></returns>
        IFacilityInfo GetMainFacility();

        #endregion Methods

    };
}
