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
    /// Handles persistance for ForumThread objects
    /// </summary>
	public interface IForumThreadPersistance : IPersistance<ForumThread> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all ForumThread based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumThread collection</returns>
		IList<ForumThread> SelectById ( int id );

        /// <summary>
        /// Gets the number of ForumThread with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all ForumThread based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumThread collection</returns>
		IList<ForumThread> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all ForumThread based on the title field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumThread collection</returns>
		IList<ForumThread> SelectByTitle ( string title );

        /// <summary>
        /// Gets the number of ForumThread with the given title
        /// </summary>
        /// <param name="id">The title</param>
        /// <returns>The count</returns>
        long CountByTitle ( string title );
        
		/// <summary>
        /// Selects all ForumThread based on the title field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumThread collection</returns>
		IList<ForumThread> SelectByTitle ( int start, int count, string title );
		
 		/// <summary>
        /// Selects all ForumThread based on the totalViews field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumThread collection</returns>
		IList<ForumThread> SelectByTotalViews ( int totalViews );

        /// <summary>
        /// Gets the number of ForumThread with the given totalViews
        /// </summary>
        /// <param name="id">The totalViews</param>
        /// <returns>The count</returns>
        long CountByTotalViews ( int totalViews );
        
		/// <summary>
        /// Selects all ForumThread based on the totalViews field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumThread collection</returns>
		IList<ForumThread> SelectByTotalViews ( int start, int count, int totalViews );
		
 		/// <summary>
        /// Selects all ForumThread based on the totalReplies field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumThread collection</returns>
		IList<ForumThread> SelectByTotalReplies ( int totalReplies );

        /// <summary>
        /// Gets the number of ForumThread with the given totalReplies
        /// </summary>
        /// <param name="id">The totalReplies</param>
        /// <returns>The count</returns>
        long CountByTotalReplies ( int totalReplies );
        
		/// <summary>
        /// Selects all ForumThread based on the totalReplies field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumThread collection</returns>
		IList<ForumThread> SelectByTotalReplies ( int start, int count, int totalReplies );
		
 		/// <summary>
        /// Selects all ForumThread based on the topic field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumThread collection</returns>
		IList<ForumThread> SelectByTopic ( ForumTopic topic );

        /// <summary>
        /// Gets the number of ForumThread with the given topic
        /// </summary>
        /// <param name="id">The topic</param>
        /// <returns>The count</returns>
        long CountByTopic ( ForumTopic topic );
        
		/// <summary>
        /// Selects all ForumThread based on the topic field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumThread collection</returns>
		IList<ForumThread> SelectByTopic ( int start, int count, ForumTopic topic );
		
 		/// <summary>
        /// Selects all ForumThread based on the owner field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumThread collection</returns>
		IList<ForumThread> SelectByOwner ( PlayerStorage owner );

        /// <summary>
        /// Gets the number of ForumThread with the given owner
        /// </summary>
        /// <param name="id">The owner</param>
        /// <returns>The count</returns>
        long CountByOwner ( PlayerStorage owner );
        
		/// <summary>
        /// Selects all ForumThread based on the owner field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumThread collection</returns>
		IList<ForumThread> SelectByOwner ( int start, int count, PlayerStorage owner );
		
 		#endregion ExtendedMethods

	};
}
