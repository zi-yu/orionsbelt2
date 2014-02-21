using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Entity that provides queue operations for resources
    /// </summary>
    public interface IResourceQueue {

        #region Properties

        /// <summary>
        /// Gets to total available queue space
        /// </summary>
        int TotalQueueSpace { get;}

        /// <summary>
        /// Gets this queue owner
        /// </summary>
        IResourceOwner ResourceOwner { get;}

        #endregion Properties

        #region Methods

        /// <summary>
        /// Checks if the given resource can be queued
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <returns>The result</returns>
        Result CanQueue(IPlanetResource resource);

        /// <summary>
        /// Queues a resource for production
        /// </summary>
        /// <param name="resource">The resource</param>
        /// <returns>The queued resource</returns>
        IPlanetResource Enqueue(IPlanetResource resource);

        /// <summary>
        /// Removes a resource from que production queue
        /// </summary>
        /// <param name="resource">The resource</param>
        void Dequeue(IPlanetResource resource);

        /// <summary>
        /// Retrieves all the queued resources
        /// </summary>
        /// <param name="type">The resource type</param>
        /// <returns>The resources, the next to produce is the first</returns>
        IList<IPlanetResource> GetQueueList(ResourceType type);

        /// <summary>
        /// Gets the used queue space for a given resource type
        /// </summary>
        /// <param name="type">The resource type</param>
        /// <returns>The used space</returns>
        int GetUsedQueueSpace(ResourceType type);

        #endregion Methods

    };
}
