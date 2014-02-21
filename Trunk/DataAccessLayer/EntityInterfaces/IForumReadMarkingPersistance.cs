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
    /// Handles persistance for ForumReadMarking objects
    /// </summary>
	public interface IForumReadMarkingPersistance : IPersistance<ForumReadMarking> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all ForumReadMarking based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumReadMarking collection</returns>
		IList<ForumReadMarking> SelectById ( int id );

        /// <summary>
        /// Gets the number of ForumReadMarking with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all ForumReadMarking based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumReadMarking collection</returns>
		IList<ForumReadMarking> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all ForumReadMarking based on the lastRead field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumReadMarking collection</returns>
		IList<ForumReadMarking> SelectByLastRead ( DateTime lastRead );

        /// <summary>
        /// Gets the number of ForumReadMarking with the given lastRead
        /// </summary>
        /// <param name="id">The lastRead</param>
        /// <returns>The count</returns>
        long CountByLastRead ( DateTime lastRead );
        
		/// <summary>
        /// Selects all ForumReadMarking based on the lastRead field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumReadMarking collection</returns>
		IList<ForumReadMarking> SelectByLastRead ( int start, int count, DateTime lastRead );
		
 		/// <summary>
        /// Selects all ForumReadMarking based on the player field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumReadMarking collection</returns>
		IList<ForumReadMarking> SelectByPlayer ( PlayerStorage player );

        /// <summary>
        /// Gets the number of ForumReadMarking with the given player
        /// </summary>
        /// <param name="id">The player</param>
        /// <returns>The count</returns>
        long CountByPlayer ( PlayerStorage player );
        
		/// <summary>
        /// Selects all ForumReadMarking based on the player field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumReadMarking collection</returns>
		IList<ForumReadMarking> SelectByPlayer ( int start, int count, PlayerStorage player );
		
 		/// <summary>
        /// Selects all ForumReadMarking based on the thread field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ForumReadMarking collection</returns>
		IList<ForumReadMarking> SelectByThread ( ForumThread thread );

        /// <summary>
        /// Gets the number of ForumReadMarking with the given thread
        /// </summary>
        /// <param name="id">The thread</param>
        /// <returns>The count</returns>
        long CountByThread ( ForumThread thread );
        
		/// <summary>
        /// Selects all ForumReadMarking based on the thread field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ForumReadMarking collection</returns>
		IList<ForumReadMarking> SelectByThread ( int start, int count, ForumThread thread );
		
 		#endregion ExtendedMethods

	};
}
