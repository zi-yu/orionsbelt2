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
    /// Handles persistance for ForumPost objects
    /// </summary>
	public interface IForumPostPersistance : IPersistance<ForumPost> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all ForumPost based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumPost collection</returns>
		IList<ForumPost> SelectById ( int id );

        /// <summary>
        /// Gets the number of ForumPost with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all ForumPost based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumPost collection</returns>
		IList<ForumPost> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all ForumPost based on the text field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumPost collection</returns>
		IList<ForumPost> SelectByText ( string text );

        /// <summary>
        /// Gets the number of ForumPost with the given text
        /// </summary>
        /// <param name="id">The text</param>
        /// <returns>The count</returns>
        long CountByText ( string text );
        
		/// <summary>
        /// Selects all ForumPost based on the text field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumPost collection</returns>
		IList<ForumPost> SelectByText ( int start, int count, string text );
		
 		/// <summary>
        /// Selects all ForumPost based on the thread field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumPost collection</returns>
		IList<ForumPost> SelectByThread ( ForumThread thread );

        /// <summary>
        /// Gets the number of ForumPost with the given thread
        /// </summary>
        /// <param name="id">The thread</param>
        /// <returns>The count</returns>
        long CountByThread ( ForumThread thread );
        
		/// <summary>
        /// Selects all ForumPost based on the thread field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumPost collection</returns>
		IList<ForumPost> SelectByThread ( int start, int count, ForumThread thread );
		
 		/// <summary>
        /// Selects all ForumPost based on the owner field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumPost collection</returns>
		IList<ForumPost> SelectByOwner ( PlayerStorage owner );

        /// <summary>
        /// Gets the number of ForumPost with the given owner
        /// </summary>
        /// <param name="id">The owner</param>
        /// <returns>The count</returns>
        long CountByOwner ( PlayerStorage owner );
        
		/// <summary>
        /// Selects all ForumPost based on the owner field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumPost collection</returns>
		IList<ForumPost> SelectByOwner ( int start, int count, PlayerStorage owner );
		
 		#endregion ExtendedMethods

	};
}
