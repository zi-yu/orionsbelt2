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
    /// Handles persistance for Battle objects
    /// </summary>
	public interface IBattlePersistance : IPersistance<Battle> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Battle based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectById ( int id );

        /// <summary>
        /// Gets the number of Battle with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Battle based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Battle based on the currentTurn field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByCurrentTurn ( int currentTurn );

        /// <summary>
        /// Gets the number of Battle with the given currentTurn
        /// </summary>
        /// <param name="id">The currentTurn</param>
        /// <returns>The count</returns>
        long CountByCurrentTurn ( int currentTurn );
        
		/// <summary>
        /// Selects all Battle based on the currentTurn field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByCurrentTurn ( int start, int count, int currentTurn );
		
 		/// <summary>
        /// Selects all Battle based on the hasEnded field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByHasEnded ( bool hasEnded );

        /// <summary>
        /// Gets the number of Battle with the given hasEnded
        /// </summary>
        /// <param name="id">The hasEnded</param>
        /// <returns>The count</returns>
        long CountByHasEnded ( bool hasEnded );
        
		/// <summary>
        /// Selects all Battle based on the hasEnded field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByHasEnded ( int start, int count, bool hasEnded );
		
 		/// <summary>
        /// Selects all Battle based on the battleType field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByBattleType ( string battleType );

        /// <summary>
        /// Gets the number of Battle with the given battleType
        /// </summary>
        /// <param name="id">The battleType</param>
        /// <returns>The count</returns>
        long CountByBattleType ( string battleType );
        
		/// <summary>
        /// Selects all Battle based on the battleType field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByBattleType ( int start, int count, string battleType );
		
 		/// <summary>
        /// Selects all Battle based on the battleMode field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByBattleMode ( string battleMode );

        /// <summary>
        /// Gets the number of Battle with the given battleMode
        /// </summary>
        /// <param name="id">The battleMode</param>
        /// <returns>The count</returns>
        long CountByBattleMode ( string battleMode );
        
		/// <summary>
        /// Selects all Battle based on the battleMode field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByBattleMode ( int start, int count, string battleMode );
		
 		/// <summary>
        /// Selects all Battle based on the unitsDestroyed field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByUnitsDestroyed ( string unitsDestroyed );

        /// <summary>
        /// Gets the number of Battle with the given unitsDestroyed
        /// </summary>
        /// <param name="id">The unitsDestroyed</param>
        /// <returns>The count</returns>
        long CountByUnitsDestroyed ( string unitsDestroyed );
        
		/// <summary>
        /// Selects all Battle based on the unitsDestroyed field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByUnitsDestroyed ( int start, int count, string unitsDestroyed );
		
 		/// <summary>
        /// Selects all Battle based on the terrain field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByTerrain ( string terrain );

        /// <summary>
        /// Gets the number of Battle with the given terrain
        /// </summary>
        /// <param name="id">The terrain</param>
        /// <returns>The count</returns>
        long CountByTerrain ( string terrain );
        
		/// <summary>
        /// Selects all Battle based on the terrain field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByTerrain ( int start, int count, string terrain );
		
 		/// <summary>
        /// Selects all Battle based on the currentPlayer field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByCurrentPlayer ( int currentPlayer );

        /// <summary>
        /// Gets the number of Battle with the given currentPlayer
        /// </summary>
        /// <param name="id">The currentPlayer</param>
        /// <returns>The count</returns>
        long CountByCurrentPlayer ( int currentPlayer );
        
		/// <summary>
        /// Selects all Battle based on the currentPlayer field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByCurrentPlayer ( int start, int count, int currentPlayer );
		
 		/// <summary>
        /// Selects all Battle based on the timeoutsAllowed field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByTimeoutsAllowed ( int timeoutsAllowed );

        /// <summary>
        /// Gets the number of Battle with the given timeoutsAllowed
        /// </summary>
        /// <param name="id">The timeoutsAllowed</param>
        /// <returns>The count</returns>
        long CountByTimeoutsAllowed ( int timeoutsAllowed );
        
		/// <summary>
        /// Selects all Battle based on the timeoutsAllowed field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByTimeoutsAllowed ( int start, int count, int timeoutsAllowed );
		
 		/// <summary>
        /// Selects all Battle based on the tournamentMode field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByTournamentMode ( string tournamentMode );

        /// <summary>
        /// Gets the number of Battle with the given tournamentMode
        /// </summary>
        /// <param name="id">The tournamentMode</param>
        /// <returns>The count</returns>
        long CountByTournamentMode ( string tournamentMode );
        
		/// <summary>
        /// Selects all Battle based on the tournamentMode field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByTournamentMode ( int start, int count, string tournamentMode );
		
 		/// <summary>
        /// Selects all Battle based on the isDeployTime field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByIsDeployTime ( bool isDeployTime );

        /// <summary>
        /// Gets the number of Battle with the given isDeployTime
        /// </summary>
        /// <param name="id">The isDeployTime</param>
        /// <returns>The count</returns>
        long CountByIsDeployTime ( bool isDeployTime );
        
		/// <summary>
        /// Selects all Battle based on the isDeployTime field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByIsDeployTime ( int start, int count, bool isDeployTime );
		
 		/// <summary>
        /// Selects all Battle based on the isTeamBattle field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByIsTeamBattle ( bool isTeamBattle );

        /// <summary>
        /// Gets the number of Battle with the given isTeamBattle
        /// </summary>
        /// <param name="id">The isTeamBattle</param>
        /// <returns>The count</returns>
        long CountByIsTeamBattle ( bool isTeamBattle );
        
		/// <summary>
        /// Selects all Battle based on the isTeamBattle field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByIsTeamBattle ( int start, int count, bool isTeamBattle );
		
 		/// <summary>
        /// Selects all Battle based on the seqNumber field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectBySeqNumber ( double seqNumber );

        /// <summary>
        /// Gets the number of Battle with the given seqNumber
        /// </summary>
        /// <param name="id">The seqNumber</param>
        /// <returns>The count</returns>
        long CountBySeqNumber ( double seqNumber );
        
		/// <summary>
        /// Selects all Battle based on the seqNumber field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectBySeqNumber ( int start, int count, double seqNumber );
		
 		/// <summary>
        /// Selects all Battle based on the isToConquer field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByIsToConquer ( bool isToConquer );

        /// <summary>
        /// Gets the number of Battle with the given isToConquer
        /// </summary>
        /// <param name="id">The isToConquer</param>
        /// <returns>The count</returns>
        long CountByIsToConquer ( bool isToConquer );
        
		/// <summary>
        /// Selects all Battle based on the isToConquer field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByIsToConquer ( int start, int count, bool isToConquer );
		
 		/// <summary>
        /// Selects all Battle based on the isInPlanet field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByIsInPlanet ( bool isInPlanet );

        /// <summary>
        /// Gets the number of Battle with the given isInPlanet
        /// </summary>
        /// <param name="id">The isInPlanet</param>
        /// <returns>The count</returns>
        long CountByIsInPlanet ( bool isInPlanet );
        
		/// <summary>
        /// Selects all Battle based on the isInPlanet field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByIsInPlanet ( int start, int count, bool isInPlanet );
		
 		/// <summary>
        /// Selects all Battle based on the currentBot field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByCurrentBot ( int currentBot );

        /// <summary>
        /// Gets the number of Battle with the given currentBot
        /// </summary>
        /// <param name="id">The currentBot</param>
        /// <returns>The count</returns>
        long CountByCurrentBot ( int currentBot );
        
		/// <summary>
        /// Selects all Battle based on the currentBot field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByCurrentBot ( int start, int count, int currentBot );
		
 		/// <summary>
        /// Selects all Battle based on the tournament field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByTournament ( Tournament tournament );

        /// <summary>
        /// Gets the number of Battle with the given tournament
        /// </summary>
        /// <param name="id">The tournament</param>
        /// <returns>The count</returns>
        long CountByTournament ( Tournament tournament );
        
		/// <summary>
        /// Selects all Battle based on the tournament field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByTournament ( int start, int count, Tournament tournament );
		
 		/// <summary>
        /// Selects all Battle based on the group field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByGroup ( PlayersGroupStorage group );

        /// <summary>
        /// Gets the number of Battle with the given group
        /// </summary>
        /// <param name="id">The group</param>
        /// <returns>The count</returns>
        long CountByGroup ( PlayersGroupStorage group );
        
		/// <summary>
        /// Selects all Battle based on the group field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Battle collection</returns>
		IList<Battle> SelectByGroup ( int start, int count, PlayersGroupStorage group );
		
 		#endregion ExtendedMethods

	};
}
