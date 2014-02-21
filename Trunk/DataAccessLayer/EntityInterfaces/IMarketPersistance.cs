using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	/// <summary>
    /// Handles persistance for Market objects
    /// </summary>
	public interface IMarketPersistance : IPersistance<Market> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Market based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Market collection</returns>
		IList<Market> SelectById ( int id );

        /// <summary>
        /// Gets the number of Market with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Market based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Market collection</returns>
		IList<Market> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Market based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Market collection</returns>
		IList<Market> SelectByName ( string name );

        /// <summary>
        /// Gets the number of Market with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all Market based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Market collection</returns>
		IList<Market> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all Market based on the level field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Market collection</returns>
		IList<Market> SelectByLevel ( int level );

        /// <summary>
        /// Gets the number of Market with the given level
        /// </summary>
        /// <param name="id">The level</param>
        /// <returns>The count</returns>
        long CountByLevel ( int level );
        
		/// <summary>
        /// Selects all Market based on the level field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Market collection</returns>
		IList<Market> SelectByLevel ( int start, int count, int level );
		
 		/// <summary>
        /// Selects all Market based on the coordinates field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Market collection</returns>
		IList<Market> SelectByCoordinates ( string coordinates );

        /// <summary>
        /// Gets the number of Market with the given coordinates
        /// </summary>
        /// <param name="id">The coordinates</param>
        /// <returns>The count</returns>
        long CountByCoordinates ( string coordinates );
        
		/// <summary>
        /// Selects all Market based on the coordinates field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Market collection</returns>
		IList<Market> SelectByCoordinates ( int start, int count, string coordinates );
		
 		/// <summary>
        /// Selects all Market based on the sector field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Market collection</returns>
		IList<Market> SelectBySector ( SectorStorage sector );

        /// <summary>
        /// Gets the number of Market with the given sector
        /// </summary>
        /// <param name="id">The sector</param>
        /// <returns>The count</returns>
        long CountBySector ( SectorStorage sector );
        
		/// <summary>
        /// Selects all Market based on the sector field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Market collection</returns>
		IList<Market> SelectBySector ( int start, int count, SectorStorage sector );
		
 		#endregion ExtendedMethods

	};
}
