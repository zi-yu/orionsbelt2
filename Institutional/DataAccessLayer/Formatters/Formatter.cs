using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Loki.DataRepresentation;
using Loki.Generic.Formatting;
using DesignPatterns;
using Institutional.Core;

namespace Institutional.DataAccessLayer {

	/// <summary>
    /// Provides formatter objects
    /// </summary>
    public static class Formatter {

        #region Static Information

        private static FactoryContainer factories = new FactoryContainer(typeof(FormatterCreator), typeof(Formatter).Assembly);

        public static FactoryContainer Factories {
            get {
                return factories;
            }
        }

        #endregion Static Information

        #region Static Access

        /// <summary>
        /// Gets the entity formatter for the given key
        /// </summary>
        /// <param name="key">The formatter key</param>
        /// <returns>The formatter</returns>
        public static IEntityFormatter<T> Get<T>(string key)
        {
            try {
            
                IEntityFormatter<T> formatter = (IEntityFormatter<T>) Factories.create(key);
                return formatter;

            } catch( Exception ex ) {
                throw new DALException("Error getting formatter for '{0}'", ex, key);
            }
        }
        
        /// <summary>
        /// Gets a formatter based on a format type
        /// </summary>
        /// <typeparam name="T">The entity</typeparam>
        /// <param name="format">The format</param>
        /// <returns>The formatter</returns>
        public static IEntityFormatter<T> GetByFormat<T>(string format)
        {
            return Get<T>( string.Format("{0}-{1}", typeof(T).Name, format.ToLower()) );
        }

        #endregion Static Access

    };
}

