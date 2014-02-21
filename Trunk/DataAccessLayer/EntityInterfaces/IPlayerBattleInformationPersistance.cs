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
    /// Handles persistance for PlayerBattleInformation objects
    /// </summary>
	public interface IPlayerBattleInformationPersistance : IPersistance<PlayerBattleInformation> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectById ( int id );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the initialContainer field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByInitialContainer ( string initialContainer );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given initialContainer
        /// </summary>
        /// <param name="id">The initialContainer</param>
        /// <returns>The count</returns>
        long CountByInitialContainer ( string initialContainer );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the initialContainer field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByInitialContainer ( int start, int count, string initialContainer );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the hasPositioned field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByHasPositioned ( bool hasPositioned );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given hasPositioned
        /// </summary>
        /// <param name="id">The hasPositioned</param>
        /// <returns>The count</returns>
        long CountByHasPositioned ( bool hasPositioned );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the hasPositioned field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByHasPositioned ( int start, int count, bool hasPositioned );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the teamNumber field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByTeamNumber ( int teamNumber );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given teamNumber
        /// </summary>
        /// <param name="id">The teamNumber</param>
        /// <returns>The count</returns>
        long CountByTeamNumber ( int teamNumber );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the teamNumber field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByTeamNumber ( int start, int count, int teamNumber );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the hasLost field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByHasLost ( bool hasLost );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given hasLost
        /// </summary>
        /// <param name="id">The hasLost</param>
        /// <returns>The count</returns>
        long CountByHasLost ( bool hasLost );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the hasLost field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByHasLost ( int start, int count, bool hasLost );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the winScore field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByWinScore ( int winScore );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given winScore
        /// </summary>
        /// <param name="id">The winScore</param>
        /// <returns>The count</returns>
        long CountByWinScore ( int winScore );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the winScore field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByWinScore ( int start, int count, int winScore );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the fleetId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByFleetId ( int fleetId );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given fleetId
        /// </summary>
        /// <param name="id">The fleetId</param>
        /// <returns>The count</returns>
        long CountByFleetId ( int fleetId );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the fleetId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByFleetId ( int start, int count, int fleetId );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the updateFleet field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByUpdateFleet ( bool updateFleet );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given updateFleet
        /// </summary>
        /// <param name="id">The updateFleet</param>
        /// <returns>The count</returns>
        long CountByUpdateFleet ( bool updateFleet );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the updateFleet field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByUpdateFleet ( int start, int count, bool updateFleet );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the hasGaveUp field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByHasGaveUp ( bool hasGaveUp );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given hasGaveUp
        /// </summary>
        /// <param name="id">The hasGaveUp</param>
        /// <returns>The count</returns>
        long CountByHasGaveUp ( bool hasGaveUp );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the hasGaveUp field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByHasGaveUp ( int start, int count, bool hasGaveUp );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the loseScore field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByLoseScore ( int loseScore );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given loseScore
        /// </summary>
        /// <param name="id">The loseScore</param>
        /// <returns>The count</returns>
        long CountByLoseScore ( int loseScore );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the loseScore field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByLoseScore ( int start, int count, int loseScore );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the victoryPercentage field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByVictoryPercentage ( int victoryPercentage );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given victoryPercentage
        /// </summary>
        /// <param name="id">The victoryPercentage</param>
        /// <returns>The count</returns>
        long CountByVictoryPercentage ( int victoryPercentage );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the victoryPercentage field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByVictoryPercentage ( int start, int count, int victoryPercentage );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the dominationPoints field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByDominationPoints ( int dominationPoints );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given dominationPoints
        /// </summary>
        /// <param name="id">The dominationPoints</param>
        /// <returns>The count</returns>
        long CountByDominationPoints ( int dominationPoints );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the dominationPoints field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByDominationPoints ( int start, int count, int dominationPoints );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the timeouts field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByTimeouts ( int timeouts );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given timeouts
        /// </summary>
        /// <param name="id">The timeouts</param>
        /// <returns>The count</returns>
        long CountByTimeouts ( int timeouts );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the timeouts field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByTimeouts ( int start, int count, int timeouts );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the owner field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByOwner ( int owner );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given owner
        /// </summary>
        /// <param name="id">The owner</param>
        /// <returns>The count</returns>
        long CountByOwner ( int owner );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the owner field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByOwner ( int start, int count, int owner );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByName ( string name );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the teamName field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByTeamName ( string teamName );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given teamName
        /// </summary>
        /// <param name="id">The teamName</param>
        /// <returns>The count</returns>
        long CountByTeamName ( string teamName );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the teamName field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByTeamName ( int start, int count, string teamName );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the ultimateUnit field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByUltimateUnit ( string ultimateUnit );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given ultimateUnit
        /// </summary>
        /// <param name="id">The ultimateUnit</param>
        /// <returns>The count</returns>
        long CountByUltimateUnit ( string ultimateUnit );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the ultimateUnit field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByUltimateUnit ( int start, int count, string ultimateUnit );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the botId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByBotId ( int botId );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given botId
        /// </summary>
        /// <param name="id">The botId</param>
        /// <returns>The count</returns>
        long CountByBotId ( int botId );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the botId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByBotId ( int start, int count, int botId );
		
 		/// <summary>
        /// Selects all PlayerBattleInformation based on the battle field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByBattle ( Battle battle );

        /// <summary>
        /// Gets the number of PlayerBattleInformation with the given battle
        /// </summary>
        /// <param name="id">The battle</param>
        /// <returns>The count</returns>
        long CountByBattle ( Battle battle );
        
		/// <summary>
        /// Selects all PlayerBattleInformation based on the battle field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerBattleInformation collection</returns>
		IList<PlayerBattleInformation> SelectByBattle ( int start, int count, Battle battle );
		
 		#endregion ExtendedMethods

	};
}
