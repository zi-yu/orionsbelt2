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
    /// Handles persistance for WormHolePlayers objects
    /// </summary>
	public interface IWormHolePlayersPersistance : IPersistance<WormHolePlayers> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all WormHolePlayers based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The WormHolePlayers collection</returns>
		IList<WormHolePlayers> SelectById ( int id );

        /// <summary>
        /// Gets the number of WormHolePlayers with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all WormHolePlayers based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The WormHolePlayers collection</returns>
		IList<WormHolePlayers> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all WormHolePlayers based on the playerCount field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The WormHolePlayers collection</returns>
		IList<WormHolePlayers> SelectByPlayerCount ( int playerCount );

        /// <summary>
        /// Gets the number of WormHolePlayers with the given playerCount
        /// </summary>
        /// <param name="id">The playerCount</param>
        /// <returns>The count</returns>
        long CountByPlayerCount ( int playerCount );
        
		/// <summary>
        /// Selects all WormHolePlayers based on the playerCount field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The WormHolePlayers collection</returns>
		IList<WormHolePlayers> SelectByPlayerCount ( int start, int count, int playerCount );
		
 		#endregion ExtendedMethods

	};
}
