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
    /// Handles persistance for Medal objects
    /// </summary>
	public interface IMedalPersistance : IPersistance<Medal> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Medal based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Medal collection</returns>
		IList<Medal> SelectById ( int id );

        /// <summary>
        /// Gets the number of Medal with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Medal based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Medal collection</returns>
		IList<Medal> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Medal based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Medal collection</returns>
		IList<Medal> SelectByName ( string name );

        /// <summary>
        /// Gets the number of Medal with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all Medal based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Medal collection</returns>
		IList<Medal> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all Medal based on the isAuto field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Medal collection</returns>
		IList<Medal> SelectByIsAuto ( bool isAuto );

        /// <summary>
        /// Gets the number of Medal with the given isAuto
        /// </summary>
        /// <param name="id">The isAuto</param>
        /// <returns>The count</returns>
        long CountByIsAuto ( bool isAuto );
        
		/// <summary>
        /// Selects all Medal based on the isAuto field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Medal collection</returns>
		IList<Medal> SelectByIsAuto ( int start, int count, bool isAuto );
		
 		/// <summary>
        /// Selects all Medal based on the player field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Medal collection</returns>
		IList<Medal> SelectByPlayer ( PlayerStorage player );

        /// <summary>
        /// Gets the number of Medal with the given player
        /// </summary>
        /// <param name="id">The player</param>
        /// <returns>The count</returns>
        long CountByPlayer ( PlayerStorage player );
        
		/// <summary>
        /// Selects all Medal based on the player field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Medal collection</returns>
		IList<Medal> SelectByPlayer ( int start, int count, PlayerStorage player );
		
 		/// <summary>
        /// Selects all Medal based on the principal field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Medal collection</returns>
		IList<Medal> SelectByPrincipal ( Principal principal );

        /// <summary>
        /// Gets the number of Medal with the given principal
        /// </summary>
        /// <param name="id">The principal</param>
        /// <returns>The count</returns>
        long CountByPrincipal ( Principal principal );
        
		/// <summary>
        /// Selects all Medal based on the principal field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Medal collection</returns>
		IList<Medal> SelectByPrincipal ( int start, int count, Principal principal );
		
 		#endregion ExtendedMethods

	};
}
