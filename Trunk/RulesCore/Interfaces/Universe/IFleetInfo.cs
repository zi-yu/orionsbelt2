using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.RulesCore.Interfaces {
    public interface IFleetInfo : ICelestialBody, IBackToStorage<Fleet>{

		/// <summary>
		/// Id of the fleet
		/// </summary>
		int Id { get; set; }

		/// <summary>
		/// Name of the Fleet
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Indicates if this fleet is a tournament fleet
		/// </summary>
		bool TournamentFleet { get; set; }

		/// <summary>
		/// Indicates if this fleet has a ultimate unit
		/// </summary>
		bool HasUltimateUnit { get; }

		/// <summary>
		/// Indicates if this fleet has a ultimate unit
		/// </summary>
		IUnitInfo UltimateUnit {get;set;}

		/// <summary>
		/// Container with all the units of this fleet
		/// </summary>
		Dictionary<string, IFleetElement> Units { get; set; }

    	/// <summary>
    	/// True if the fleet is in a battle
    	/// </summary>
    	bool IsInBattle {get;set;}

		/// <summary>
		/// True if the fleet is moving
		/// </summary>
		bool IsMoving { get;}

    	/// <summary>
    	/// Fleet has units
    	/// </summary>
    	bool HasUnits {get;}

    	/// <summary>
    	/// Onwer, if any, of the fleet
    	/// </summary>
    	IPlayer Owner {get;set;}

    	/// <summary>
    	/// Is this fleet a defense fleet
    	/// </summary>
    	bool IsPlanetDefenseFleet {get;set;}

    	/// <summary>
    	/// Current planet where the fleet is
    	/// </summary>
    	IPlanet CurrentPlanet {get;set;}

    	/// <summary>
    	/// Gets the Visibility range
    	/// </summary>
    	int VisibilityRange {get;}

    	/// <summary>
    	/// Gets the Movement duration
    	/// </summary>
    	int MovementDuration {get;}

        /// <summary>
        /// Cargo of the fleet
        /// </summary>
        Dictionary<IResourceInfo, int> Cargo{get; set;}

        /// <summary>
        /// Returns the quantity already on cargo for the given resource
        /// </summary>
        /// <param name="info">The resource</param>
        /// <returns>The quantity</returns>
        int GetCargoQuantity(IResourceInfo info);

        /// <summary>
        /// Onwer, if any, of the fleet
        /// </summary>
        Principal PrincipalOwner {get;set;}

        /// <summary>
        /// If the fleet has Cargo
        /// </summary>
        bool HasCargo{get;}

    	/// <summary>
    	/// Total value of the fleet based on the value of each unit
    	/// </summary>
    	int FleetValue {get;}

        /// <summary>
        /// If this fleet can pass in a wormhole
        /// </summary>
        bool CanPassWormHoles{get;}

    	/// <summary>
    	/// True if the fleet is idle
    	/// </summary>
    	bool IsIdle {get;}

    	/// <summary>
    	/// If this fleet belongs to a bot
    	/// </summary>
    	bool IsBot {get;set;}
		
		/// <summary>
		/// Fleet waypoints
		/// </summary>
		List<Coordinate> WayPoints { get; set; }

        /// <summary>
        /// The Fleet has waypoints
        /// </summary>
        bool HasWayPoints{get;}

    	/// <summary>
		/// Add a new unit
		/// </summary>
		void Add( string name, int quantity );

		/// <summary>
		/// Add a new unit
		/// </summary>
		void Add( IUnitInfo info, int quantity );

    	/// <summary>
    	/// Add a new element
    	/// </summary>
    	void Add(IElement element, IBattlePlayer player);

		/// <summary>
		/// Add new resource
		/// </summary>
		/// <param name="resource"></param>
		void Add(IPlanetResource resource);

		/// <summary>
		/// Add the units of the passed fleet to the current fleet
		/// </summary>
		/// <param name="fleet"></param>
		void Add(IFleetInfo fleet);

		/// <summary>
		/// Set the unit quantity with the value passed
		/// </summary>
		void Update(IUnitInfo name, int quantity);

    	/// <summary>
    	/// Removes a qunatity from a unit
    	/// </summary>
    	void Remove(string unitName, int quantity);

		/// <summary>
		/// verifies if the fleet has enough units of that type
		/// </summary>
		bool HasEnoughUnits(string unitName, int quantity);

		/// <summary>
		/// Adds Cargo to the current Fleet
		/// </summary>
		/// <param name="resource">Resource thats going to be added to the cargo</param>
		/// <param name="quantity">Quantity of that resource</param>
		void AddCargo(IResourceInfo resource, int quantity);
		
		/// <summary>
        /// Adds Cargo to the current Fleet
        /// </summary>
        /// <param name="resource">Resource thats going to be added to the cargo</param>
        void AddCargo(IResourceQuantity resource);

		/// <summary>
		/// Adds Cargo to the current Fleet
		/// </summary>
		/// <param name="resource">Resource thats going to be added to the cargo</param>
		void AddCargo(List<IResourceQuantity> resource);

		/// <summary>
		/// Adds Cargo to the current Fleet
		/// </summary>
		/// <param name="fleet">fleet to taske the cargo from</param>
		void AddCargo(IFleetInfo fleet);

		/// <summary>
		/// Empties the Cargo of a fleet
		/// </summary>
		void EmptyCargo();

    	/// <summary>
    	/// If the current fleet is stronger than the passed fleet
    	/// </summary>
    	bool IsStronger( IFleetInfo fleetInfo );

    	/// <summary>
    	/// If the current fleet is weaker than the passed fleet
    	/// </summary>
    	bool IsWeaker(IFleetInfo fleetInfo);

    	/// <summary>
    	/// if the fleets can enter in a battle
    	/// </summary>
    	bool CanBattle(IFleetInfo fleetInfo);

    	/// <summary>
    	/// Empties the Cargo of a fleet
    	/// </summary>
    	void EmptyUnits();

        /// <summary>
        /// Removes a resource from the cargo
        /// </summary>
        /// <param name="resource">Resource to remove from cargo</param>
        void RemoveCargo(IResourceInfo resource);

        /// <summary>
        /// updates the quantity of a resource
        /// </summary>
        /// <param name="resource">Resource to updates</param>
        /// <param name="quantity">Quantity to update</param>
        void UpdateCargo(IResourceInfo resource, int quantity);

		/// <summary>
		/// Decrement the quantity of a resource
		/// </summary>
		/// <param name="resource">Resource to Remove</param>
		/// <param name="quantity">Quantity to remove</param>
		void DecrementCargo(IResourceInfo resource, int quantity);

        /// <summary>
        /// Add the units of the passed fleet to the current fleet
        /// </summary>
        /// <param name="fleet"></param>
        void AddHalfUnits(IFleetInfo fleet);

        /// <summary>
        /// Fleet Immunity Start Tick
        /// </summary>
        int ImmunityStartTick { get; set; }
    }
}
