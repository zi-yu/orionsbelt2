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
    /// Handles persistance for ForumTopic objects
    /// </summary>
	public interface IForumTopicPersistance : IPersistance<ForumTopic> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all ForumTopic based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectById ( int id );

        /// <summary>
        /// Gets the number of ForumTopic with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all ForumTopic based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all ForumTopic based on the title field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectByTitle ( string title );

        /// <summary>
        /// Gets the number of ForumTopic with the given title
        /// </summary>
        /// <param name="id">The title</param>
        /// <returns>The count</returns>
        long CountByTitle ( string title );
        
		/// <summary>
        /// Selects all ForumTopic based on the title field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectByTitle ( int start, int count, string title );
		
 		/// <summary>
        /// Selects all ForumTopic based on the lastPost field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectByLastPost ( DateTime lastPost );

        /// <summary>
        /// Gets the number of ForumTopic with the given lastPost
        /// </summary>
        /// <param name="id">The lastPost</param>
        /// <returns>The count</returns>
        long CountByLastPost ( DateTime lastPost );
        
		/// <summary>
        /// Selects all ForumTopic based on the lastPost field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectByLastPost ( int start, int count, DateTime lastPost );
		
 		/// <summary>
        /// Selects all ForumTopic based on the totalPosts field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectByTotalPosts ( int totalPosts );

        /// <summary>
        /// Gets the number of ForumTopic with the given totalPosts
        /// </summary>
        /// <param name="id">The totalPosts</param>
        /// <returns>The count</returns>
        long CountByTotalPosts ( int totalPosts );
        
		/// <summary>
        /// Selects all ForumTopic based on the totalPosts field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectByTotalPosts ( int start, int count, int totalPosts );
		
 		/// <summary>
        /// Selects all ForumTopic based on the totalThreads field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectByTotalThreads ( int totalThreads );

        /// <summary>
        /// Gets the number of ForumTopic with the given totalThreads
        /// </summary>
        /// <param name="id">The totalThreads</param>
        /// <returns>The count</returns>
        long CountByTotalThreads ( int totalThreads );
        
		/// <summary>
        /// Selects all ForumTopic based on the totalThreads field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectByTotalThreads ( int start, int count, int totalThreads );
		
 		/// <summary>
        /// Selects all ForumTopic based on the isPrivate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectByIsPrivate ( bool isPrivate );

        /// <summary>
        /// Gets the number of ForumTopic with the given isPrivate
        /// </summary>
        /// <param name="id">The isPrivate</param>
        /// <returns>The count</returns>
        long CountByIsPrivate ( bool isPrivate );
        
		/// <summary>
        /// Selects all ForumTopic based on the isPrivate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectByIsPrivate ( int start, int count, bool isPrivate );
		
 		/// <summary>
        /// Selects all ForumTopic based on the forumRoles field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectByForumRoles ( string forumRoles );

        /// <summary>
        /// Gets the number of ForumTopic with the given forumRoles
        /// </summary>
        /// <param name="id">The forumRoles</param>
        /// <returns>The count</returns>
        long CountByForumRoles ( string forumRoles );
        
		/// <summary>
        /// Selects all ForumTopic based on the forumRoles field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectByForumRoles ( int start, int count, string forumRoles );
		
 		/// <summary>
        /// Selects all ForumTopic based on the description field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectByDescription ( string description );

        /// <summary>
        /// Gets the number of ForumTopic with the given description
        /// </summary>
        /// <param name="id">The description</param>
        /// <returns>The count</returns>
        long CountByDescription ( string description );
        
		/// <summary>
        /// Selects all ForumTopic based on the description field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumTopic collection</returns>
		IList<ForumTopic> SelectByDescription ( int start, int count, string description );
		
 		#endregion ExtendedMethods

	};
}
