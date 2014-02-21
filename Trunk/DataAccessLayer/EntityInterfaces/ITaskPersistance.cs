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
    /// Handles persistance for Task objects
    /// </summary>
	public interface ITaskPersistance : IPersistance<Task> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Task based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Task collection</returns>
		IList<Task> SelectById ( int id );

        /// <summary>
        /// Gets the number of Task with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Task based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Task collection</returns>
		IList<Task> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Task based on the status field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Task collection</returns>
		IList<Task> SelectByStatus ( string status );

        /// <summary>
        /// Gets the number of Task with the given status
        /// </summary>
        /// <param name="id">The status</param>
        /// <returns>The count</returns>
        long CountByStatus ( string status );
        
		/// <summary>
        /// Selects all Task based on the status field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Task collection</returns>
		IList<Task> SelectByStatus ( int start, int count, string status );
		
 		/// <summary>
        /// Selects all Task based on the priority field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Task collection</returns>
		IList<Task> SelectByPriority ( string priority );

        /// <summary>
        /// Gets the number of Task with the given priority
        /// </summary>
        /// <param name="id">The priority</param>
        /// <returns>The count</returns>
        long CountByPriority ( string priority );
        
		/// <summary>
        /// Selects all Task based on the priority field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Task collection</returns>
		IList<Task> SelectByPriority ( int start, int count, string priority );
		
 		/// <summary>
        /// Selects all Task based on the title field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Task collection</returns>
		IList<Task> SelectByTitle ( string title );

        /// <summary>
        /// Gets the number of Task with the given title
        /// </summary>
        /// <param name="id">The title</param>
        /// <returns>The count</returns>
        long CountByTitle ( string title );
        
		/// <summary>
        /// Selects all Task based on the title field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Task collection</returns>
		IList<Task> SelectByTitle ( int start, int count, string title );
		
 		/// <summary>
        /// Selects all Task based on the necessity field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Task collection</returns>
		IList<Task> SelectByNecessity ( Necessity necessity );

        /// <summary>
        /// Gets the number of Task with the given necessity
        /// </summary>
        /// <param name="id">The necessity</param>
        /// <returns>The count</returns>
        long CountByNecessity ( Necessity necessity );
        
		/// <summary>
        /// Selects all Task based on the necessity field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Task collection</returns>
		IList<Task> SelectByNecessity ( int start, int count, Necessity necessity );
		
 		#endregion ExtendedMethods

	};
}
