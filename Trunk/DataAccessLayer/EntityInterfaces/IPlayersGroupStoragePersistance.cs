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
    /// Handles persistance for PlayersGroupStorage objects
    /// </summary>
	public interface IPlayersGroupStoragePersistance : IPersistance<PlayersGroupStorage> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all PlayersGroupStorage based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayersGroupStorage collection</returns>
		IList<PlayersGroupStorage> SelectById ( int id );

        /// <summary>
        /// Gets the number of PlayersGroupStorage with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all PlayersGroupStorage based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayersGroupStorage collection</returns>
		IList<PlayersGroupStorage> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all PlayersGroupStorage based on the eliminatoryNumber field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayersGroupStorage collection</returns>
		IList<PlayersGroupStorage> SelectByEliminatoryNumber ( int eliminatoryNumber );

        /// <summary>
        /// Gets the number of PlayersGroupStorage with the given eliminatoryNumber
        /// </summary>
        /// <param name="id">The eliminatoryNumber</param>
        /// <returns>The count</returns>
        long CountByEliminatoryNumber ( int eliminatoryNumber );
        
		/// <summary>
        /// Selects all PlayersGroupStorage based on the eliminatoryNumber field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayersGroupStorage collection</returns>
		IList<PlayersGroupStorage> SelectByEliminatoryNumber ( int start, int count, int eliminatoryNumber );
		
 		/// <summary>
        /// Selects all PlayersGroupStorage based on the playersIds field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayersGroupStorage collection</returns>
		IList<PlayersGroupStorage> SelectByPlayersIds ( string playersIds );

        /// <summary>
        /// Gets the number of PlayersGroupStorage with the given playersIds
        /// </summary>
        /// <param name="id">The playersIds</param>
        /// <returns>The count</returns>
        long CountByPlayersIds ( string playersIds );
        
		/// <summary>
        /// Selects all PlayersGroupStorage based on the playersIds field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayersGroupStorage collection</returns>
		IList<PlayersGroupStorage> SelectByPlayersIds ( int start, int count, string playersIds );
		
 		/// <summary>
        /// Selects all PlayersGroupStorage based on the groupNumber field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayersGroupStorage collection</returns>
		IList<PlayersGroupStorage> SelectByGroupNumber ( int groupNumber );

        /// <summary>
        /// Gets the number of PlayersGroupStorage with the given groupNumber
        /// </summary>
        /// <param name="id">The groupNumber</param>
        /// <returns>The count</returns>
        long CountByGroupNumber ( int groupNumber );
        
		/// <summary>
        /// Selects all PlayersGroupStorage based on the groupNumber field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayersGroupStorage collection</returns>
		IList<PlayersGroupStorage> SelectByGroupNumber ( int start, int count, int groupNumber );
		
 		/// <summary>
        /// Selects all PlayersGroupStorage based on the tournament field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayersGroupStorage collection</returns>
		IList<PlayersGroupStorage> SelectByTournament ( Tournament tournament );

        /// <summary>
        /// Gets the number of PlayersGroupStorage with the given tournament
        /// </summary>
        /// <param name="id">The tournament</param>
        /// <returns>The count</returns>
        long CountByTournament ( Tournament tournament );
        
		/// <summary>
        /// Selects all PlayersGroupStorage based on the tournament field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayersGroupStorage collection</returns>
		IList<PlayersGroupStorage> SelectByTournament ( int start, int count, Tournament tournament );
		
 		#endregion ExtendedMethods

	};
}
