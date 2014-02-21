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
    /// Handles persistance for Asset objects
    /// </summary>
	public interface IAssetPersistance : IPersistance<Asset> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Asset based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Asset collection</returns>
		IList<Asset> SelectById ( int id );

        /// <summary>
        /// Gets the number of Asset with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Asset based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Asset collection</returns>
		IList<Asset> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Asset based on the type field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Asset collection</returns>
		IList<Asset> SelectByType ( string type );

        /// <summary>
        /// Gets the number of Asset with the given type
        /// </summary>
        /// <param name="id">The type</param>
        /// <returns>The count</returns>
        long CountByType ( string type );
        
		/// <summary>
        /// Selects all Asset based on the type field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Asset collection</returns>
		IList<Asset> SelectByType ( int start, int count, string type );
		
 		/// <summary>
        /// Selects all Asset based on the description field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Asset collection</returns>
		IList<Asset> SelectByDescription ( string description );

        /// <summary>
        /// Gets the number of Asset with the given description
        /// </summary>
        /// <param name="id">The description</param>
        /// <returns>The count</returns>
        long CountByDescription ( string description );
        
		/// <summary>
        /// Selects all Asset based on the description field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Asset collection</returns>
		IList<Asset> SelectByDescription ( int start, int count, string description );
		
 		/// <summary>
        /// Selects all Asset based on the coordinate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Asset collection</returns>
		IList<Asset> SelectByCoordinate ( string coordinate );

        /// <summary>
        /// Gets the number of Asset with the given coordinate
        /// </summary>
        /// <param name="id">The coordinate</param>
        /// <returns>The count</returns>
        long CountByCoordinate ( string coordinate );
        
		/// <summary>
        /// Selects all Asset based on the coordinate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Asset collection</returns>
		IList<Asset> SelectByCoordinate ( int start, int count, string coordinate );
		
 		/// <summary>
        /// Selects all Asset based on the owner field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Asset collection</returns>
		IList<Asset> SelectByOwner ( PlayerStorage owner );

        /// <summary>
        /// Gets the number of Asset with the given owner
        /// </summary>
        /// <param name="id">The owner</param>
        /// <returns>The count</returns>
        long CountByOwner ( PlayerStorage owner );
        
		/// <summary>
        /// Selects all Asset based on the owner field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Asset collection</returns>
		IList<Asset> SelectByOwner ( int start, int count, PlayerStorage owner );
		
 		/// <summary>
        /// Selects all Asset based on the task field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Asset collection</returns>
		IList<Asset> SelectByTask ( Task task );

        /// <summary>
        /// Gets the number of Asset with the given task
        /// </summary>
        /// <param name="id">The task</param>
        /// <returns>The count</returns>
        long CountByTask ( Task task );
        
		/// <summary>
        /// Selects all Asset based on the task field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Asset collection</returns>
		IList<Asset> SelectByTask ( int start, int count, Task task );
		
 		/// <summary>
        /// Selects all Asset based on the alliance field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Asset collection</returns>
		IList<Asset> SelectByAlliance ( AllianceStorage alliance );

        /// <summary>
        /// Gets the number of Asset with the given alliance
        /// </summary>
        /// <param name="id">The alliance</param>
        /// <returns>The count</returns>
        long CountByAlliance ( AllianceStorage alliance );
        
		/// <summary>
        /// Selects all Asset based on the alliance field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Asset collection</returns>
		IList<Asset> SelectByAlliance ( int start, int count, AllianceStorage alliance );
		
 		#endregion ExtendedMethods

	};
}
