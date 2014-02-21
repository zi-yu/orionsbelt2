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
    /// Handles persistance for Necessity objects
    /// </summary>
	public interface INecessityPersistance : IPersistance<Necessity> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Necessity based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Necessity collection</returns>
		IList<Necessity> SelectById ( int id );

        /// <summary>
        /// Gets the number of Necessity with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Necessity based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Necessity collection</returns>
		IList<Necessity> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Necessity based on the type field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Necessity collection</returns>
		IList<Necessity> SelectByType ( string type );

        /// <summary>
        /// Gets the number of Necessity with the given type
        /// </summary>
        /// <param name="id">The type</param>
        /// <returns>The count</returns>
        long CountByType ( string type );
        
		/// <summary>
        /// Selects all Necessity based on the type field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Necessity collection</returns>
		IList<Necessity> SelectByType ( int start, int count, string type );
		
 		/// <summary>
        /// Selects all Necessity based on the description field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Necessity collection</returns>
		IList<Necessity> SelectByDescription ( string description );

        /// <summary>
        /// Gets the number of Necessity with the given description
        /// </summary>
        /// <param name="id">The description</param>
        /// <returns>The count</returns>
        long CountByDescription ( string description );
        
		/// <summary>
        /// Selects all Necessity based on the description field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Necessity collection</returns>
		IList<Necessity> SelectByDescription ( int start, int count, string description );
		
 		/// <summary>
        /// Selects all Necessity based on the coordinate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Necessity collection</returns>
		IList<Necessity> SelectByCoordinate ( string coordinate );

        /// <summary>
        /// Gets the number of Necessity with the given coordinate
        /// </summary>
        /// <param name="id">The coordinate</param>
        /// <returns>The count</returns>
        long CountByCoordinate ( string coordinate );
        
		/// <summary>
        /// Selects all Necessity based on the coordinate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Necessity collection</returns>
		IList<Necessity> SelectByCoordinate ( int start, int count, string coordinate );
		
 		/// <summary>
        /// Selects all Necessity based on the status field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Necessity collection</returns>
		IList<Necessity> SelectByStatus ( string status );

        /// <summary>
        /// Gets the number of Necessity with the given status
        /// </summary>
        /// <param name="id">The status</param>
        /// <returns>The count</returns>
        long CountByStatus ( string status );
        
		/// <summary>
        /// Selects all Necessity based on the status field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Necessity collection</returns>
		IList<Necessity> SelectByStatus ( int start, int count, string status );
		
 		/// <summary>
        /// Selects all Necessity based on the creator field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Necessity collection</returns>
		IList<Necessity> SelectByCreator ( PlayerStorage creator );

        /// <summary>
        /// Gets the number of Necessity with the given creator
        /// </summary>
        /// <param name="id">The creator</param>
        /// <returns>The count</returns>
        long CountByCreator ( PlayerStorage creator );
        
		/// <summary>
        /// Selects all Necessity based on the creator field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Necessity collection</returns>
		IList<Necessity> SelectByCreator ( int start, int count, PlayerStorage creator );
		
 		/// <summary>
        /// Selects all Necessity based on the alliance field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Necessity collection</returns>
		IList<Necessity> SelectByAlliance ( AllianceStorage alliance );

        /// <summary>
        /// Gets the number of Necessity with the given alliance
        /// </summary>
        /// <param name="id">The alliance</param>
        /// <returns>The count</returns>
        long CountByAlliance ( AllianceStorage alliance );
        
		/// <summary>
        /// Selects all Necessity based on the alliance field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Necessity collection</returns>
		IList<Necessity> SelectByAlliance ( int start, int count, AllianceStorage alliance );
		
 		#endregion ExtendedMethods

	};
}
