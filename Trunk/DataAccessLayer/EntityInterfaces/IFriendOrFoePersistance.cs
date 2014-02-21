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
    /// Handles persistance for FriendOrFoe objects
    /// </summary>
	public interface IFriendOrFoePersistance : IPersistance<FriendOrFoe> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all FriendOrFoe based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The FriendOrFoe collection</returns>
		IList<FriendOrFoe> SelectById ( int id );

        /// <summary>
        /// Gets the number of FriendOrFoe with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all FriendOrFoe based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The FriendOrFoe collection</returns>
		IList<FriendOrFoe> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all FriendOrFoe based on the isFriend field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The FriendOrFoe collection</returns>
		IList<FriendOrFoe> SelectByIsFriend ( bool isFriend );

        /// <summary>
        /// Gets the number of FriendOrFoe with the given isFriend
        /// </summary>
        /// <param name="id">The isFriend</param>
        /// <returns>The count</returns>
        long CountByIsFriend ( bool isFriend );
        
		/// <summary>
        /// Selects all FriendOrFoe based on the isFriend field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The FriendOrFoe collection</returns>
		IList<FriendOrFoe> SelectByIsFriend ( int start, int count, bool isFriend );
		
 		/// <summary>
        /// Selects all FriendOrFoe based on the source field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The FriendOrFoe collection</returns>
		IList<FriendOrFoe> SelectBySource ( PlayerStorage source );

        /// <summary>
        /// Gets the number of FriendOrFoe with the given source
        /// </summary>
        /// <param name="id">The source</param>
        /// <returns>The count</returns>
        long CountBySource ( PlayerStorage source );
        
		/// <summary>
        /// Selects all FriendOrFoe based on the source field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The FriendOrFoe collection</returns>
		IList<FriendOrFoe> SelectBySource ( int start, int count, PlayerStorage source );
		
 		/// <summary>
        /// Selects all FriendOrFoe based on the target field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The FriendOrFoe collection</returns>
		IList<FriendOrFoe> SelectByTarget ( PlayerStorage target );

        /// <summary>
        /// Gets the number of FriendOrFoe with the given target
        /// </summary>
        /// <param name="id">The target</param>
        /// <returns>The count</returns>
        long CountByTarget ( PlayerStorage target );
        
		/// <summary>
        /// Selects all FriendOrFoe based on the target field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The FriendOrFoe collection</returns>
		IList<FriendOrFoe> SelectByTarget ( int start, int count, PlayerStorage target );
		
 		#endregion ExtendedMethods

	};
}
