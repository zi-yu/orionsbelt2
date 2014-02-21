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
    /// Handles persistance for Tournament objects
    /// </summary>
	public interface ITournamentPersistance : IPersistance<Tournament> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Tournament based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectById ( int id );

        /// <summary>
        /// Gets the number of Tournament with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Tournament based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Tournament based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByName ( string name );

        /// <summary>
        /// Gets the number of Tournament with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all Tournament based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all Tournament based on the warningTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByWarningTick ( int warningTick );

        /// <summary>
        /// Gets the number of Tournament with the given warningTick
        /// </summary>
        /// <param name="id">The warningTick</param>
        /// <returns>The count</returns>
        long CountByWarningTick ( int warningTick );
        
		/// <summary>
        /// Selects all Tournament based on the warningTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByWarningTick ( int start, int count, int warningTick );
		
 		/// <summary>
        /// Selects all Tournament based on the prize field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByPrize ( string prize );

        /// <summary>
        /// Gets the number of Tournament with the given prize
        /// </summary>
        /// <param name="id">The prize</param>
        /// <returns>The count</returns>
        long CountByPrize ( string prize );
        
		/// <summary>
        /// Selects all Tournament based on the prize field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByPrize ( int start, int count, string prize );
		
 		/// <summary>
        /// Selects all Tournament based on the costCredits field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByCostCredits ( int costCredits );

        /// <summary>
        /// Gets the number of Tournament with the given costCredits
        /// </summary>
        /// <param name="id">The costCredits</param>
        /// <returns>The count</returns>
        long CountByCostCredits ( int costCredits );
        
		/// <summary>
        /// Selects all Tournament based on the costCredits field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByCostCredits ( int start, int count, int costCredits );
		
 		/// <summary>
        /// Selects all Tournament based on the tournamentType field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByTournamentType ( string tournamentType );

        /// <summary>
        /// Gets the number of Tournament with the given tournamentType
        /// </summary>
        /// <param name="id">The tournamentType</param>
        /// <returns>The count</returns>
        long CountByTournamentType ( string tournamentType );
        
		/// <summary>
        /// Selects all Tournament based on the tournamentType field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByTournamentType ( int start, int count, string tournamentType );
		
 		/// <summary>
        /// Selects all Tournament based on the fleetId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByFleetId ( int fleetId );

        /// <summary>
        /// Gets the number of Tournament with the given fleetId
        /// </summary>
        /// <param name="id">The fleetId</param>
        /// <returns>The count</returns>
        long CountByFleetId ( int fleetId );
        
		/// <summary>
        /// Selects all Tournament based on the fleetId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByFleetId ( int start, int count, int fleetId );
		
 		/// <summary>
        /// Selects all Tournament based on the isPublic field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByIsPublic ( bool isPublic );

        /// <summary>
        /// Gets the number of Tournament with the given isPublic
        /// </summary>
        /// <param name="id">The isPublic</param>
        /// <returns>The count</returns>
        long CountByIsPublic ( bool isPublic );
        
		/// <summary>
        /// Selects all Tournament based on the isPublic field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByIsPublic ( int start, int count, bool isPublic );
		
 		/// <summary>
        /// Selects all Tournament based on the isSurvival field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByIsSurvival ( bool isSurvival );

        /// <summary>
        /// Gets the number of Tournament with the given isSurvival
        /// </summary>
        /// <param name="id">The isSurvival</param>
        /// <returns>The count</returns>
        long CountByIsSurvival ( bool isSurvival );
        
		/// <summary>
        /// Selects all Tournament based on the isSurvival field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByIsSurvival ( int start, int count, bool isSurvival );
		
 		/// <summary>
        /// Selects all Tournament based on the turnTime field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByTurnTime ( int turnTime );

        /// <summary>
        /// Gets the number of Tournament with the given turnTime
        /// </summary>
        /// <param name="id">The turnTime</param>
        /// <returns>The count</returns>
        long CountByTurnTime ( int turnTime );
        
		/// <summary>
        /// Selects all Tournament based on the turnTime field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByTurnTime ( int start, int count, int turnTime );
		
 		/// <summary>
        /// Selects all Tournament based on the subscriptionTime field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectBySubscriptionTime ( int subscriptionTime );

        /// <summary>
        /// Gets the number of Tournament with the given subscriptionTime
        /// </summary>
        /// <param name="id">The subscriptionTime</param>
        /// <returns>The count</returns>
        long CountBySubscriptionTime ( int subscriptionTime );
        
		/// <summary>
        /// Selects all Tournament based on the subscriptionTime field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectBySubscriptionTime ( int start, int count, int subscriptionTime );
		
 		/// <summary>
        /// Selects all Tournament based on the maxPlayers field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByMaxPlayers ( int maxPlayers );

        /// <summary>
        /// Gets the number of Tournament with the given maxPlayers
        /// </summary>
        /// <param name="id">The maxPlayers</param>
        /// <returns>The count</returns>
        long CountByMaxPlayers ( int maxPlayers );
        
		/// <summary>
        /// Selects all Tournament based on the maxPlayers field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByMaxPlayers ( int start, int count, int maxPlayers );
		
 		/// <summary>
        /// Selects all Tournament based on the minPlayers field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByMinPlayers ( int minPlayers );

        /// <summary>
        /// Gets the number of Tournament with the given minPlayers
        /// </summary>
        /// <param name="id">The minPlayers</param>
        /// <returns>The count</returns>
        long CountByMinPlayers ( int minPlayers );
        
		/// <summary>
        /// Selects all Tournament based on the minPlayers field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByMinPlayers ( int start, int count, int minPlayers );
		
 		/// <summary>
        /// Selects all Tournament based on the nPlayersToPlayoff field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByNPlayersToPlayoff ( int nPlayersToPlayoff );

        /// <summary>
        /// Gets the number of Tournament with the given nPlayersToPlayoff
        /// </summary>
        /// <param name="id">The nPlayersToPlayoff</param>
        /// <returns>The count</returns>
        long CountByNPlayersToPlayoff ( int nPlayersToPlayoff );
        
		/// <summary>
        /// Selects all Tournament based on the nPlayersToPlayoff field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByNPlayersToPlayoff ( int start, int count, int nPlayersToPlayoff );
		
 		/// <summary>
        /// Selects all Tournament based on the maxElo field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByMaxElo ( int maxElo );

        /// <summary>
        /// Gets the number of Tournament with the given maxElo
        /// </summary>
        /// <param name="id">The maxElo</param>
        /// <returns>The count</returns>
        long CountByMaxElo ( int maxElo );
        
		/// <summary>
        /// Selects all Tournament based on the maxElo field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByMaxElo ( int start, int count, int maxElo );
		
 		/// <summary>
        /// Selects all Tournament based on the minElo field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByMinElo ( int minElo );

        /// <summary>
        /// Gets the number of Tournament with the given minElo
        /// </summary>
        /// <param name="id">The minElo</param>
        /// <returns>The count</returns>
        long CountByMinElo ( int minElo );
        
		/// <summary>
        /// Selects all Tournament based on the minElo field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByMinElo ( int start, int count, int minElo );
		
 		/// <summary>
        /// Selects all Tournament based on the startTime field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByStartTime ( DateTime startTime );

        /// <summary>
        /// Gets the number of Tournament with the given startTime
        /// </summary>
        /// <param name="id">The startTime</param>
        /// <returns>The count</returns>
        long CountByStartTime ( DateTime startTime );
        
		/// <summary>
        /// Selects all Tournament based on the startTime field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByStartTime ( int start, int count, DateTime startTime );
		
 		/// <summary>
        /// Selects all Tournament based on the endDate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByEndDate ( DateTime endDate );

        /// <summary>
        /// Gets the number of Tournament with the given endDate
        /// </summary>
        /// <param name="id">The endDate</param>
        /// <returns>The count</returns>
        long CountByEndDate ( DateTime endDate );
        
		/// <summary>
        /// Selects all Tournament based on the endDate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByEndDate ( int start, int count, DateTime endDate );
		
 		/// <summary>
        /// Selects all Tournament based on the token field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByToken ( string token );

        /// <summary>
        /// Gets the number of Tournament with the given token
        /// </summary>
        /// <param name="id">The token</param>
        /// <returns>The count</returns>
        long CountByToken ( string token );
        
		/// <summary>
        /// Selects all Tournament based on the token field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByToken ( int start, int count, string token );
		
 		/// <summary>
        /// Selects all Tournament based on the tokenNumber field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByTokenNumber ( int tokenNumber );

        /// <summary>
        /// Gets the number of Tournament with the given tokenNumber
        /// </summary>
        /// <param name="id">The tokenNumber</param>
        /// <returns>The count</returns>
        long CountByTokenNumber ( int tokenNumber );
        
		/// <summary>
        /// Selects all Tournament based on the tokenNumber field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByTokenNumber ( int start, int count, int tokenNumber );
		
 		/// <summary>
        /// Selects all Tournament based on the isCustom field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByIsCustom ( bool isCustom );

        /// <summary>
        /// Gets the number of Tournament with the given isCustom
        /// </summary>
        /// <param name="id">The isCustom</param>
        /// <returns>The count</returns>
        long CountByIsCustom ( bool isCustom );
        
		/// <summary>
        /// Selects all Tournament based on the isCustom field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByIsCustom ( int start, int count, bool isCustom );
		
 		/// <summary>
        /// Selects all Tournament based on the paymentsRequired field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByPaymentsRequired ( int paymentsRequired );

        /// <summary>
        /// Gets the number of Tournament with the given paymentsRequired
        /// </summary>
        /// <param name="id">The paymentsRequired</param>
        /// <returns>The count</returns>
        long CountByPaymentsRequired ( int paymentsRequired );
        
		/// <summary>
        /// Selects all Tournament based on the paymentsRequired field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByPaymentsRequired ( int start, int count, int paymentsRequired );
		
 		/// <summary>
        /// Selects all Tournament based on the numberPassGroup field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByNumberPassGroup ( int numberPassGroup );

        /// <summary>
        /// Gets the number of Tournament with the given numberPassGroup
        /// </summary>
        /// <param name="id">The numberPassGroup</param>
        /// <returns>The count</returns>
        long CountByNumberPassGroup ( int numberPassGroup );
        
		/// <summary>
        /// Selects all Tournament based on the numberPassGroup field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByNumberPassGroup ( int start, int count, int numberPassGroup );
		
 		/// <summary>
        /// Selects all Tournament based on the descriptionToken field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByDescriptionToken ( string descriptionToken );

        /// <summary>
        /// Gets the number of Tournament with the given descriptionToken
        /// </summary>
        /// <param name="id">The descriptionToken</param>
        /// <returns>The count</returns>
        long CountByDescriptionToken ( string descriptionToken );
        
		/// <summary>
        /// Selects all Tournament based on the descriptionToken field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Tournament collection</returns>
		IList<Tournament> SelectByDescriptionToken ( int start, int count, string descriptionToken );
		
 		#endregion ExtendedMethods

	};
}
