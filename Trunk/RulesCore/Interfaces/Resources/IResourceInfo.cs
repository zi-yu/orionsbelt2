using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Rules;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Resource metadata
    /// </summary>
    public interface IResourceInfo {

        #region Properties

        /// <summary>
        /// Gets the resource unique identifier
        /// </summary>
        string Identifier { get;}

        /// <summary>
        /// The resource name
        /// </summary>
        string Name { get;}

        /// <summary>
        /// The resource type
        /// </summary>
        ResourceType Type { get;}

        /// <summary>
        /// Tells that this resource is rare
        /// </summary>
        bool IsRare { get;}

        /// <summary>
        /// Indicates that this resource is related to a concept (QueueSpace) and not a generic resource (Gold)
        /// </summary>
        bool Conceptual { get;}

        /// <summary>
        /// That races that have this resource available
        /// </summary>
        Race[] Races { get;}

        /// <summary>
        /// When created, the level at with this resource starts
        /// </summary>
        int StartLevel { get;}

        /// <summary>
        /// True if this resource can be acumulated with others of the same type
        /// </summary>
        bool CanAcumulate { get;}

        /// <summary>
        /// True if this resource can be added to the production queue
        /// </summary>
        bool IsBuildable { get;}

        /// <summary>
        /// The groups a resource can be into
        /// </summary>
        AuctionHouseType AuctionType { get;}

        /// <summary>
        /// True if this resource has multiple levels
        /// </summary>
        bool CanLevelUp { get;}

        /// <summary>
        /// The max level of this resource
        /// </summary>
        int MaxLevel { get;}

        /// <summary>
        /// True if this resource can be unloaded from a fleet
        /// </summary>
        bool CanUnloadFromFleet { get;}

        /// <summary>
        /// True if this resource can travel trough worm holes
        /// 
        /// </summary>
        bool CanPassWormHoles { get;}

        /// <summary>
        /// True if this resource is meant only for trade routes
        /// </summary>
        bool IsTradeRouteSpecific { get;}

        /// <summary>
        /// True if this resource may be used as a cost for another resource
        /// </summary>
        bool IsResourceCost { get;}

        /// <summary>
        /// True if the level of this resource should be mapped on the planet facility level
        /// </summary>
        bool CountsForFacilityLevel { get;}

		/// <summary>
		/// If this resource is dropped by mobs
		/// </summary>
		bool IsDroppable { get;}

		/// <summary>
		/// Drop rate of the resource
		/// </summary>
		int DropRate { get;}

        #endregion Properties

        #region Methods

        /// <summary>
        /// True if this resource is available to the given race
        /// </summary>
        /// <param name="race">The race</param>
        /// <returns>True if available</returns>
        bool IsAvailableToRace(Race race);

        /// <summary>
        /// Checks if this resource is avaialble on the given planet
        /// </summary>
        /// <returns>The query result</returns>
        Result IsAvailable(IPlanetResource resource);

        /// <summary>
        /// Checks if the upgrade for the next level is available
        /// </summary>
        /// <param name="resource">The wanted resource</param>
        /// <returns>The result</returns>
        Result IsUpgradeAvailable(IPlanetResource resource);

        /// <summary>
        /// Checks the cost rules
        /// </summary>
        /// <param name="owner">The resource owner</param>
        /// <param name="resource">The resource</param>
        /// <param name="quantity">The quantity</param>
        /// <returns>The result</returns>
        Result CheckCost(IResourceOwner owner, IPlanetResource resource, int quantity);

        /// <summary>
        /// The base cost attenuaion
        /// </summary>
        /// <returns>The attenuation</returns>
        double GetBaseCostAttenuation(RuleArgs args,IIntrinsicInfo resource);

        /// <summary>
        /// Gets the build duration for the given resource
        /// </summary>
        /// <param name="owner">The owner</param>
        /// <param name="resource">The resource</param>
        /// <returns>The duration</returns>
        int GetBuildDuration(IResourceOwner owner, IPlanetResource resource);

        /// <summary>
        /// Gets the base duration for this resource
        /// </summary>
        /// <param name="level">The level</param>
        /// <param name="quantity">The quantity</param>
        /// <returns>Number of ticks</returns>
        int GetFixedBuildDuration(int level, int quantity);

        /// <summary>
        /// Gets score earn for this resource
        /// </summary>
        /// <param name="level">The level</param>
        /// <param name="quantity">The quantity</param>
        /// <returns>Number of ticks</returns>
        int GetScore(int level, int quantity);

        /// <summary>
        /// Runs OnComplete Rules
        /// </summary>
        /// <param name="resource">The completed resource</param>
        void OnComplete(IPlanetResource resource);

        /// <summary>
        /// Actions when this resource is destroyed
        /// </summary>
        /// <param name="resource">The resource</param>
        void OnDestroy(IPlanetResource resource);

        /// <summary>
        /// Checks if the given resource can be built on the given planet
        /// </summary>
        /// <param name="planet">The planet</param>
        /// <returns>True if available</returns>
        Result IsBuildAvailable(IPlanet planet);

        /// <summary>
        /// PRocesses the cost
        /// </summary>
        /// <param name="resource">The resource to charge</param>
        void ProcessCost(IPlanetResource resource);

        /// <summary>
        /// Undo the cost rules
        /// </summary>
        /// <param name="resource">The resource</param>
        void UndoCost(IPlanetResource resource);

        #endregion Methods

    };
}
