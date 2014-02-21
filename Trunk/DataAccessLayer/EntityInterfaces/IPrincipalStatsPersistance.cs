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
    /// Handles persistance for PrincipalStats objects
    /// </summary>
	public interface IPrincipalStatsPersistance : IPersistance<PrincipalStats> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all PrincipalStats based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalStats collection</returns>
		IList<PrincipalStats> SelectById ( int id );

        /// <summary>
        /// Gets the number of PrincipalStats with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all PrincipalStats based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalStats collection</returns>
		IList<PrincipalStats> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all PrincipalStats based on the maxElo field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalStats collection</returns>
		IList<PrincipalStats> SelectByMaxElo ( int maxElo );

        /// <summary>
        /// Gets the number of PrincipalStats with the given maxElo
        /// </summary>
        /// <param name="id">The maxElo</param>
        /// <returns>The count</returns>
        long CountByMaxElo ( int maxElo );
        
		/// <summary>
        /// Selects all PrincipalStats based on the maxElo field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalStats collection</returns>
		IList<PrincipalStats> SelectByMaxElo ( int start, int count, int maxElo );
		
 		/// <summary>
        /// Selects all PrincipalStats based on the minElo field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalStats collection</returns>
		IList<PrincipalStats> SelectByMinElo ( int minElo );

        /// <summary>
        /// Gets the number of PrincipalStats with the given minElo
        /// </summary>
        /// <param name="id">The minElo</param>
        /// <returns>The count</returns>
        long CountByMinElo ( int minElo );
        
		/// <summary>
        /// Selects all PrincipalStats based on the minElo field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalStats collection</returns>
		IList<PrincipalStats> SelectByMinElo ( int start, int count, int minElo );
		
 		/// <summary>
        /// Selects all PrincipalStats based on the numberPlayedBattles field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalStats collection</returns>
		IList<PrincipalStats> SelectByNumberPlayedBattles ( int numberPlayedBattles );

        /// <summary>
        /// Gets the number of PrincipalStats with the given numberPlayedBattles
        /// </summary>
        /// <param name="id">The numberPlayedBattles</param>
        /// <returns>The count</returns>
        long CountByNumberPlayedBattles ( int numberPlayedBattles );
        
		/// <summary>
        /// Selects all PrincipalStats based on the numberPlayedBattles field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalStats collection</returns>
		IList<PrincipalStats> SelectByNumberPlayedBattles ( int start, int count, int numberPlayedBattles );
		
 		/// <summary>
        /// Selects all PrincipalStats based on the maxLadder field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalStats collection</returns>
		IList<PrincipalStats> SelectByMaxLadder ( int maxLadder );

        /// <summary>
        /// Gets the number of PrincipalStats with the given maxLadder
        /// </summary>
        /// <param name="id">The maxLadder</param>
        /// <returns>The count</returns>
        long CountByMaxLadder ( int maxLadder );
        
		/// <summary>
        /// Selects all PrincipalStats based on the maxLadder field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalStats collection</returns>
		IList<PrincipalStats> SelectByMaxLadder ( int start, int count, int maxLadder );
		
 		/// <summary>
        /// Selects all PrincipalStats based on the minLadder field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalStats collection</returns>
		IList<PrincipalStats> SelectByMinLadder ( int minLadder );

        /// <summary>
        /// Gets the number of PrincipalStats with the given minLadder
        /// </summary>
        /// <param name="id">The minLadder</param>
        /// <returns>The count</returns>
        long CountByMinLadder ( int minLadder );
        
		/// <summary>
        /// Selects all PrincipalStats based on the minLadder field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalStats collection</returns>
		IList<PrincipalStats> SelectByMinLadder ( int start, int count, int minLadder );
		
 		#endregion ExtendedMethods

	};
}
