using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.Core;
using System.Collections.Generic;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// This is a planet resource
    /// </summary>
    public interface IPlanetResource : IBackToStorage<PlanetResourceStorage> {

        #region Properties

        /// <summary>
        /// The resource quantity
        /// </summary>
        int Quantity { get; set;}

        /// <summary>
        /// The resource state
        /// </summary>
        ResourceState State { get;set;}

        /// <summary>
        /// The resource level
        /// </summary>
        int Level { get;set;}

        /// <summary>
        /// The owner planet
        /// </summary>
        IResourceOwner Owner { get; set;}

        /// <summary>
        /// True if this resource is attached to a Owner
        /// </summary>
        bool HasOwner { get;}

        /// <summary>
        /// Resource metadata
        /// </summary>
        IResourceInfo Info { get; set;}

        /// <summary>
        /// Gets the queue order for this object
        /// </summary>
        int QueueOrder { get; set;}

        /// <summary>
        /// Gets the facility slot (if this is in fact a facility)
        /// </summary>
        IFacilitySlot Slot { get; set;}

        /// <summary>
        /// While on construction, this field gives the end tick
        /// </summary>
        int EndTick { get; set;}

        /// <summary>
        /// Indicates that this resource is a template and should not be persisted
        /// </summary>
        bool IsTemplate { get; set;}

        #endregion Properties

        #region Methods

        /// <summary>
        /// Checks if there is an upgrade available
        /// </summary>
        /// <returns>The result</returns>
        Result IsUpgradeAvailable();

        /// <summary>
        /// Runs OnComplete Logic
        /// </summary>
        void OnComplete();

        /// <summary>
        /// Prepares the relation between this resource and the current owner
        /// </summary>
        void AttachToOwner(IResourceOwner owner);

        #endregion Methods

    };

}
