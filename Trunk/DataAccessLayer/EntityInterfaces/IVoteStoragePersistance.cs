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
    /// Handles persistance for VoteStorage objects
    /// </summary>
	public interface IVoteStoragePersistance : IPersistance<VoteStorage> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all VoteStorage based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The VoteStorage collection</returns>
		IList<VoteStorage> SelectById ( int id );

        /// <summary>
        /// Gets the number of VoteStorage with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all VoteStorage based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The VoteStorage collection</returns>
		IList<VoteStorage> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all VoteStorage based on the data field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The VoteStorage collection</returns>
		IList<VoteStorage> SelectByData ( string data );

        /// <summary>
        /// Gets the number of VoteStorage with the given data
        /// </summary>
        /// <param name="id">The data</param>
        /// <returns>The count</returns>
        long CountByData ( string data );
        
		/// <summary>
        /// Selects all VoteStorage based on the data field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The VoteStorage collection</returns>
		IList<VoteStorage> SelectByData ( int start, int count, string data );
		
 		/// <summary>
        /// Selects all VoteStorage based on the ownerId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The VoteStorage collection</returns>
		IList<VoteStorage> SelectByOwnerId ( int ownerId );

        /// <summary>
        /// Gets the number of VoteStorage with the given ownerId
        /// </summary>
        /// <param name="id">The ownerId</param>
        /// <returns>The count</returns>
        long CountByOwnerId ( int ownerId );
        
		/// <summary>
        /// Selects all VoteStorage based on the ownerId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The VoteStorage collection</returns>
		IList<VoteStorage> SelectByOwnerId ( int start, int count, int ownerId );
		
 		#endregion ExtendedMethods

	};
}
