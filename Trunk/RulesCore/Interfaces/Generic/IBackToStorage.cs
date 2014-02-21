using System;
using System.Collections.Generic;
using System.Text;

namespace OrionsBelt.RulesCore.Interfaces {

    /// <summary>
    /// Represents an entity with a reference to a storage
    /// </summary>
    public interface IBackToStorage<T> {

        /// <summary>
        /// Gets/Sets the storage object
        /// </summary>
        T Storage {get; set;}

        /// <summary>
        /// Updates the data in the storage
        /// </summary>
        void UpdateStorage();

        /// <summary>
        /// Checks if the storage exists, and if it does not, it prepares it
        /// </summary>
        void PrepareStorage();

        /// <summary>
        /// Marks this object as dirty
        /// </summary>
        void Touch();

        /// <summary>
        /// True if this object was changed and needs to be persisted
        /// </summary>
        bool IsDirty { get; set;}

    };
}
