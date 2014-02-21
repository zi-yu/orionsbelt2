using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Entity that owns resources
    /// </summary>
    public interface IResourceOwner  {

        #region Properties

        /// <summary>
        /// Gets all the resources, grouped by type
        /// </summary>
        Dictionary<ResourceType, ResourceList> Resources { get;}

        /// <summary>
        /// The Facilities
        /// </summary>
        ResourceList Facilities { get;}

        /// <summary>
        /// The Intrinsic resources
        /// </summary>
        ResourceList Intrinsic { get;}

        /// <summary>
        /// The units
        /// </summary>
        ResourceList Units { get;}

        /// <summary>
        /// Gets the resourceOwner's master
        /// </summary>
        IPlayer Owner { get; set;}

        /// <summary>
        /// True if this resource owner has a master
        /// </summary>
        bool HasOwner { get;}

        /// <summary>
        /// Get's the production speed of this resource owner
        /// </summary>
        double ProductionFactor { get; set;}

        /// <summary>
        /// Get's the production speed with bonuts of this resource owner
        /// </summary>
        double FinalProductionFactor { get; }

        #endregion Properties

        #region Resource Utilities

        /// <summary>
        /// Adds the given resource to this planet
        /// </summary>
        /// <param name="resource">The resource</param>
        void AddResource(IPlanetResource resource);

        /// <summary>
        /// Removes the given quantity to the given resource
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="quantity">The quantity</param>
        void RemoveQuantity(IResourceInfo resource, int quantity);

        /// <summary>
        /// Gets the planet resources of the given type
        /// </summary>
        /// <param name="resource">The resource definition</param>
        /// <returns>The available resources</returns>
        IList<IPlanetResource> GetResources(IResourceInfo resource);

        /// <summary>
        /// Gets the planet resource of the given type
        /// </summary>
        /// <param name="resource">The resource definition</param>
        /// <returns>The available resources</returns>
        IPlanetResource GetResource(IResourceInfo resource);

        /// <summary>
        /// Gets the maximim level in the planet of a given resource
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <returns>The max level</returns>
        int MaxResourceLevel(IResourceInfo resource);

        /// <summary>
        /// Checks if this planet has the given resource at the provided level
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="level">The level</param>
        /// <returns>True if exists</returns>
        bool HasResourceLevel(IResourceInfo resource, int level);

        /// <summary>
        /// Checks if the given resource is available and with the provided quantity
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="quantity">The quantity</param>
        /// <returns>True if there is such a quantity</returns>
        bool IsResourceAvailable(IResourceInfo resource, int quantity);

        /// <summary>
        /// Checks id the given resource is available for build
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <returns>True if is abailable</returns>
        bool IsBuildAvailable(IResourceInfo resource);

        /// <summary>
        /// Checks if is it possible to upgrade a resource
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <returns>True if is possible</returns>
        Result IsUpgradeAvailable(IPlanetResource resource);

        /// <summary>
        /// Returns the ammout to be added per tick for the given resource
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <returns>The quantity to add</returns>
        int GetPerTick(IResourceInfo resource);

        #endregion Resource Utilities

        #region Resource Construction

        /// <summary>
        /// Checks if the current resource can be added to the building queue
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Result CanQueue(IPlanetResource resource, int quantity);

        /// <summary>
        /// Gets all the resources currently in production
        /// </summary>
        /// <param name="resourceType">The resource type filter</param>
        /// <returns></returns>
        IList<IPlanetResource> GetResourcesInProduction(ResourceType resourceType);

        /// <summary>
        /// Cancels the production of the given resource
        /// </summary>
        /// <param name="resource">The resource</param>
        void CancelProduction(IPlanetResource resource);

        #endregion Resource Construction

        #region Quantity Handing

        /// <summary>
        /// Adds the provided quantity to the given resource
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="quantity">The quantity</param>
        int AddQuantity(IResourceInfo resource, int quantity);

        /// <summary>
        /// Sets the current resource quantity
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <param name="quantity">The quantity</param>
        void SetQuantity(IResourceInfo resource, int quantity);

        /// <summary>
        /// Gets the quantity for the given resource
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <returns>The quantity</returns>
        int GetQuantity(IResourceInfo resource);

        /// <summary>
        /// Verifies if the the quantity of the 
        /// passed resource is available
        /// </summary>
        /// <param name="resource">Resource to check</param>
        /// <param name="quantity">Quantity to check</param>
        /// <returns>True if the quantity is available</returns>
        bool HasQuantity(IResourceInfo resource, int quantity);

        #endregion Quantity Handing

    };
}
