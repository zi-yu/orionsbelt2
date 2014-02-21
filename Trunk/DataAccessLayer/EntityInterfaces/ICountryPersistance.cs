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
    /// Handles persistance for Country objects
    /// </summary>
	public interface ICountryPersistance : IPersistance<Country> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Country based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Country collection</returns>
		IList<Country> SelectById ( int id );

        /// <summary>
        /// Gets the number of Country with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Country based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Country collection</returns>
		IList<Country> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Country based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Country collection</returns>
		IList<Country> SelectByName ( string name );

        /// <summary>
        /// Gets the number of Country with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all Country based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Country collection</returns>
		IList<Country> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all Country based on the abbreviation field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Country collection</returns>
		IList<Country> SelectByAbbreviation ( string abbreviation );

        /// <summary>
        /// Gets the number of Country with the given abbreviation
        /// </summary>
        /// <param name="id">The abbreviation</param>
        /// <returns>The count</returns>
        long CountByAbbreviation ( string abbreviation );
        
		/// <summary>
        /// Selects all Country based on the abbreviation field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Country collection</returns>
		IList<Country> SelectByAbbreviation ( int start, int count, string abbreviation );
		
 		/// <summary>
        /// Selects all Country based on the isEU field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Country collection</returns>
		IList<Country> SelectByIsEU ( bool isEU );

        /// <summary>
        /// Gets the number of Country with the given isEU
        /// </summary>
        /// <param name="id">The isEU</param>
        /// <returns>The count</returns>
        long CountByIsEU ( bool isEU );
        
		/// <summary>
        /// Selects all Country based on the isEU field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Country collection</returns>
		IList<Country> SelectByIsEU ( int start, int count, bool isEU );
		
 		#endregion ExtendedMethods

	};
}
