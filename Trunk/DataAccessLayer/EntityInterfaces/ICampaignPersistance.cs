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
    /// Handles persistance for Campaign objects
    /// </summary>
	public interface ICampaignPersistance : IPersistance<Campaign> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Campaign based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Campaign collection</returns>
		IList<Campaign> SelectById ( int id );

        /// <summary>
        /// Gets the number of Campaign with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Campaign based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Campaign collection</returns>
		IList<Campaign> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Campaign based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Campaign collection</returns>
		IList<Campaign> SelectByName ( string name );

        /// <summary>
        /// Gets the number of Campaign with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all Campaign based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Campaign collection</returns>
		IList<Campaign> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all Campaign based on the principal field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Campaign collection</returns>
		IList<Campaign> SelectByPrincipal ( Principal principal );

        /// <summary>
        /// Gets the number of Campaign with the given principal
        /// </summary>
        /// <param name="id">The principal</param>
        /// <returns>The count</returns>
        long CountByPrincipal ( Principal principal );
        
		/// <summary>
        /// Selects all Campaign based on the principal field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Campaign collection</returns>
		IList<Campaign> SelectByPrincipal ( int start, int count, Principal principal );
		
 		#endregion ExtendedMethods

	};
}
