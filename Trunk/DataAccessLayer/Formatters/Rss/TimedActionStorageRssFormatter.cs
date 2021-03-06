﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Loki.DataRepresentation;
using Loki.Generic.Formatting;
using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {

	/// <summary>
    /// Formatter object for TimedActionStorage
    /// </summary>
    [FactoryKey("TimedActionStorage-rss")]
    public class TimedActionStorageRssFormatter : RssFormatter<TimedActionStorage> {
   
        #region Formatter Implementation

        /// <summary>
        /// Gets an entity given its Id
        /// </summary>
        /// <typeparam name="E">The target entity type</typeparam>
        /// <param name="propertyName">The property name</param>
        /// <param name="propertyValue">The property value</param>
        /// <returns>The entity</returns>
        protected override IEntity GetEntity<E>( string propertyName, string propertyValue)
        {
            return (IEntity) Persistance.GetEntity<E>(propertyName, propertyValue);
        }

        /// <summary>
        /// Create Entity via DAL
        /// </summary>
        /// <returns></returns>
        protected override TimedActionStorage CreateEntity()
        {
            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance ()) {
                return persistance.Create();
            }
        }

        #endregion Formatter Implementation

    };
}

