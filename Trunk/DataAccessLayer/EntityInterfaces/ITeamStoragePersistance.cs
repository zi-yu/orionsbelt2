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
    /// Handles persistance for TeamStorage objects
    /// </summary>
	public interface ITeamStoragePersistance : IPersistance<TeamStorage> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all TeamStorage based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectById ( int id );

        /// <summary>
        /// Gets the number of TeamStorage with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all TeamStorage based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all TeamStorage based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByName ( string name );

        /// <summary>
        /// Gets the number of TeamStorage with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all TeamStorage based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all TeamStorage based on the eloRanking field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByEloRanking ( int eloRanking );

        /// <summary>
        /// Gets the number of TeamStorage with the given eloRanking
        /// </summary>
        /// <param name="id">The eloRanking</param>
        /// <returns>The count</returns>
        long CountByEloRanking ( int eloRanking );
        
		/// <summary>
        /// Selects all TeamStorage based on the eloRanking field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByEloRanking ( int start, int count, int eloRanking );
		
 		/// <summary>
        /// Selects all TeamStorage based on the numberPlayedBattles field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByNumberPlayedBattles ( int numberPlayedBattles );

        /// <summary>
        /// Gets the number of TeamStorage with the given numberPlayedBattles
        /// </summary>
        /// <param name="id">The numberPlayedBattles</param>
        /// <returns>The count</returns>
        long CountByNumberPlayedBattles ( int numberPlayedBattles );
        
		/// <summary>
        /// Selects all TeamStorage based on the numberPlayedBattles field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByNumberPlayedBattles ( int start, int count, int numberPlayedBattles );
		
 		/// <summary>
        /// Selects all TeamStorage based on the ladderActive field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByLadderActive ( bool ladderActive );

        /// <summary>
        /// Gets the number of TeamStorage with the given ladderActive
        /// </summary>
        /// <param name="id">The ladderActive</param>
        /// <returns>The count</returns>
        long CountByLadderActive ( bool ladderActive );
        
		/// <summary>
        /// Selects all TeamStorage based on the ladderActive field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByLadderActive ( int start, int count, bool ladderActive );
		
 		/// <summary>
        /// Selects all TeamStorage based on the ladderPosition field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByLadderPosition ( int ladderPosition );

        /// <summary>
        /// Gets the number of TeamStorage with the given ladderPosition
        /// </summary>
        /// <param name="id">The ladderPosition</param>
        /// <returns>The count</returns>
        long CountByLadderPosition ( int ladderPosition );
        
		/// <summary>
        /// Selects all TeamStorage based on the ladderPosition field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByLadderPosition ( int start, int count, int ladderPosition );
		
 		/// <summary>
        /// Selects all TeamStorage based on the isInBattle field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByIsInBattle ( int isInBattle );

        /// <summary>
        /// Gets the number of TeamStorage with the given isInBattle
        /// </summary>
        /// <param name="id">The isInBattle</param>
        /// <returns>The count</returns>
        long CountByIsInBattle ( int isInBattle );
        
		/// <summary>
        /// Selects all TeamStorage based on the isInBattle field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByIsInBattle ( int start, int count, int isInBattle );
		
 		/// <summary>
        /// Selects all TeamStorage based on the restUntil field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByRestUntil ( int restUntil );

        /// <summary>
        /// Gets the number of TeamStorage with the given restUntil
        /// </summary>
        /// <param name="id">The restUntil</param>
        /// <returns>The count</returns>
        long CountByRestUntil ( int restUntil );
        
		/// <summary>
        /// Selects all TeamStorage based on the restUntil field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByRestUntil ( int start, int count, int restUntil );
		
 		/// <summary>
        /// Selects all TeamStorage based on the stoppedUntil field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByStoppedUntil ( int stoppedUntil );

        /// <summary>
        /// Gets the number of TeamStorage with the given stoppedUntil
        /// </summary>
        /// <param name="id">The stoppedUntil</param>
        /// <returns>The count</returns>
        long CountByStoppedUntil ( int stoppedUntil );
        
		/// <summary>
        /// Selects all TeamStorage based on the stoppedUntil field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByStoppedUntil ( int start, int count, int stoppedUntil );
		
 		/// <summary>
        /// Selects all TeamStorage based on the myStatsId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByMyStatsId ( int myStatsId );

        /// <summary>
        /// Gets the number of TeamStorage with the given myStatsId
        /// </summary>
        /// <param name="id">The myStatsId</param>
        /// <returns>The count</returns>
        long CountByMyStatsId ( int myStatsId );
        
		/// <summary>
        /// Selects all TeamStorage based on the myStatsId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByMyStatsId ( int start, int count, int myStatsId );
		
 		/// <summary>
        /// Selects all TeamStorage based on the isComplete field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByIsComplete ( bool isComplete );

        /// <summary>
        /// Gets the number of TeamStorage with the given isComplete
        /// </summary>
        /// <param name="id">The isComplete</param>
        /// <returns>The count</returns>
        long CountByIsComplete ( bool isComplete );
        
		/// <summary>
        /// Selects all TeamStorage based on the isComplete field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TeamStorage collection</returns>
		IList<TeamStorage> SelectByIsComplete ( int start, int count, bool isComplete );
		
 		#endregion ExtendedMethods

	};
}
