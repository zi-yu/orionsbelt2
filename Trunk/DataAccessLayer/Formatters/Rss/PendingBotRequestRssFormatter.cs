using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Loki.DataRepresentation;
using Loki.Generic.Formatting;
using DesignPatterns.Attributes;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {

	/// <summary>
    /// Formatter object for PendingBotRequest
    /// </summary>
    [FactoryKey("PendingBotRequest-rss")]
    public class PendingBotRequestRssFormatter : RssFormatter<PendingBotRequest> {
   
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
        protected override PendingBotRequest CreateEntity()
        {
            using (IPendingBotRequestPersistance persistance = Persistance.Instance.GetPendingBotRequestPersistance ()) {
                return persistance.Create();
            }
        }

        #endregion Formatter Implementation

    };
}

