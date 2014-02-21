using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.Generic;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents a resource provider entity in the universe
    /// </summary>
	public interface IPlanet :
			ICelestialBody,
			IResourceOwner,
			IResourceQueue,
			IModifierHandler,
			IResourceRichness,
			IBackToStorage<PlanetStorage> {

		#region Planet Properties

		/// <summary>
		/// The planet's name
		/// </summary>
		string Name { get; set;}

        /// <summary>
        /// The planet's score
        /// </summary>
        int Score { get; set;}

        /// <summary>
        /// The planet's universe level
        /// </summary>
        int Level { get; set;}

		/// <summary>
		/// Planet generic configuration
		/// </summary>
		IPlanetInfo Info { get;set;}

		/// <summary>
		/// The planet's terrain type
		/// </summary>
		ITerrainInfo Terrain { get;set;}

		/// <summary>
		/// Tells if the planet is private or not
		/// </summary>
		bool IsPrivate { get;set;}

		/// <summary>
		/// List of the planet
		/// </summary>
		List<IFleetInfo> Fleets { get; }

		/// <summary>
		/// Defense fleet of the planet
		/// </summary>
		IFleetInfo DefenseFleet { get;}

        /// <summary>
        /// The race of this planet
        /// </summary>
        IRaceInfo RaceInformation { get;}

        /// <summary>
        /// The tick when this planet was last pillaged
        /// </summary>
        int LastPillageTick { get; set;}

        /// <summary>
        /// True if someone can pillage this planet
        /// </summary>
        bool CanPillage { get;}

        /// <summary>
        /// The tick whhen this planet was last conquererd
        /// </summary>
        int LastConquerTick { get;set;}

        /// <summary>
        /// True if this planet can be conquered
        /// </summary>
        bool CanConquer { get;}

        /// <summary>
        /// The facility level of this planet
        /// </summary>
        int FacilityLevel { get; set;}

		#endregion Planet Properties

		#region Facility Methods

		/// <summary>
		/// Adds a facility to an empty slot
		/// </summary>
		/// <param name="slotIdentifier">The slot identifier</param>
		/// <param name="info">The facility</param>
		void AddFacility(string slotIdentifier, IFacilityInfo info);

		/// <summary>
		/// Checks if is there any facility available for the given slot
		/// </summary>
		/// <param name="slot">The slot</param>
		/// <returns>True if is available</returns>
		bool HasFacilityAvailableForSlot(IFacilitySlot slot);

		/// <summary>
		/// Returns the planetresource at the given slot, or null if the slot is empty
		/// </summary>
		/// <param name="slot">The slot</param>
		/// <returns>The resource</returns>
		IPlanetResource GetFacility(IFacilitySlot slot);

		/// <summary>
		/// Checks if the given resource can be destroyed
		/// </summary>
		/// <param name="resource">The resource</param>
		/// <returns>The result</returns>
		Result IsDestroyAvailable(IPlanetResource resource);

		/// <summary>
		/// Destroys the given resource
		/// </summary>
		/// <param name="resource">The resource to be destroyed</param>
		void Destroy(IPlanetResource resource);

		/// <summary>
		/// Add fleets to the planet
		/// </summary>
		/// <param name="list"></param>
		void AddFleets(List<IFleetInfo> list);

		/// <summary>
		/// Add fleets to the planet
		/// </summary>
		/// <param name="fleet">fleet to add</param>
		void AddFleet(IFleetInfo fleet);

    	/// <summary>
    	/// Gets the fleet with the passed id
    	/// </summary>
    	/// <param name="id">Id of the fleet to return</param>
    	/// <returns>An object that represents the fleet with the passed id</returns>
    	IFleetInfo GetFleet(int id);

		/// <summary>
		/// If the planet loaded fleets
		/// </summary>
		/// <returns>fleets</returns>
		bool HasLoadedFleets();

    	/// <summary>
    	/// If the planet has a loaded defense fleets
    	/// </summary>
    	/// <returns>fleets</returns>
    	bool HasLoadedDefenseFleet();

		/// <summary>
		/// If the planet has a location
		/// </summary>
		/// <returns>fleets</returns>
		bool HasLocation();

    	/// <summary>
    	/// Steals the resources of the passed planet
    	/// </summary>
    	/// <returns></returns>
    	List<IResourceQuantity> StealResources();

    	/// <summary>
    	/// Get's the level of the current planet (different from the planet universe level)
    	/// </summary>
    	/// <returns>The level of the planet</returns>
    	int GetPlanetLevel();

        /// <summary>
        /// Creates a ultimate fleet near the planet
        /// </summary>
        /// <param name="unit">Ultimate unit </param>
        void CreateUltimateFleet(IUnitInfo unit);

		#endregion Facility Methods
	}
}
