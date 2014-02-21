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
    /// Handles persistance for Principal objects
    /// </summary>
	public interface IPrincipalPersistance : IPersistance<Principal> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Principal based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectById ( int id );

        /// <summary>
        /// Gets the number of Principal with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Principal based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Principal based on the isBot field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByIsBot ( bool isBot );

        /// <summary>
        /// Gets the number of Principal with the given isBot
        /// </summary>
        /// <param name="id">The isBot</param>
        /// <returns>The count</returns>
        long CountByIsBot ( bool isBot );
        
		/// <summary>
        /// Selects all Principal based on the isBot field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByIsBot ( int start, int count, bool isBot );
		
 		/// <summary>
        /// Selects all Principal based on the myStatsId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByMyStatsId ( int myStatsId );

        /// <summary>
        /// Gets the number of Principal with the given myStatsId
        /// </summary>
        /// <param name="id">The myStatsId</param>
        /// <returns>The count</returns>
        long CountByMyStatsId ( int myStatsId );
        
		/// <summary>
        /// Selects all Principal based on the myStatsId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByMyStatsId ( int start, int count, int myStatsId );
		
 		/// <summary>
        /// Selects all Principal based on the eloRanking field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByEloRanking ( int eloRanking );

        /// <summary>
        /// Gets the number of Principal with the given eloRanking
        /// </summary>
        /// <param name="id">The eloRanking</param>
        /// <returns>The count</returns>
        long CountByEloRanking ( int eloRanking );
        
		/// <summary>
        /// Selects all Principal based on the eloRanking field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByEloRanking ( int start, int count, int eloRanking );
		
 		/// <summary>
        /// Selects all Principal based on the receiveMail field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByReceiveMail ( bool receiveMail );

        /// <summary>
        /// Gets the number of Principal with the given receiveMail
        /// </summary>
        /// <param name="id">The receiveMail</param>
        /// <returns>The count</returns>
        long CountByReceiveMail ( bool receiveMail );
        
		/// <summary>
        /// Selects all Principal based on the receiveMail field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByReceiveMail ( int start, int count, bool receiveMail );
		
 		/// <summary>
        /// Selects all Principal based on the credits field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByCredits ( int credits );

        /// <summary>
        /// Gets the number of Principal with the given credits
        /// </summary>
        /// <param name="id">The credits</param>
        /// <returns>The count</returns>
        long CountByCredits ( int credits );
        
		/// <summary>
        /// Selects all Principal based on the credits field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByCredits ( int start, int count, int credits );
		
 		/// <summary>
        /// Selects all Principal based on the ladderActive field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLadderActive ( bool ladderActive );

        /// <summary>
        /// Gets the number of Principal with the given ladderActive
        /// </summary>
        /// <param name="id">The ladderActive</param>
        /// <returns>The count</returns>
        long CountByLadderActive ( bool ladderActive );
        
		/// <summary>
        /// Selects all Principal based on the ladderActive field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLadderActive ( int start, int count, bool ladderActive );
		
 		/// <summary>
        /// Selects all Principal based on the ladderPosition field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLadderPosition ( int ladderPosition );

        /// <summary>
        /// Gets the number of Principal with the given ladderPosition
        /// </summary>
        /// <param name="id">The ladderPosition</param>
        /// <returns>The count</returns>
        long CountByLadderPosition ( int ladderPosition );
        
		/// <summary>
        /// Selects all Principal based on the ladderPosition field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLadderPosition ( int start, int count, int ladderPosition );
		
 		/// <summary>
        /// Selects all Principal based on the isInBattle field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByIsInBattle ( int isInBattle );

        /// <summary>
        /// Gets the number of Principal with the given isInBattle
        /// </summary>
        /// <param name="id">The isInBattle</param>
        /// <returns>The count</returns>
        long CountByIsInBattle ( int isInBattle );
        
		/// <summary>
        /// Selects all Principal based on the isInBattle field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByIsInBattle ( int start, int count, int isInBattle );
		
 		/// <summary>
        /// Selects all Principal based on the restUntil field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByRestUntil ( int restUntil );

        /// <summary>
        /// Gets the number of Principal with the given restUntil
        /// </summary>
        /// <param name="id">The restUntil</param>
        /// <returns>The count</returns>
        long CountByRestUntil ( int restUntil );
        
		/// <summary>
        /// Selects all Principal based on the restUntil field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByRestUntil ( int start, int count, int restUntil );
		
 		/// <summary>
        /// Selects all Principal based on the stoppedUntil field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByStoppedUntil ( int stoppedUntil );

        /// <summary>
        /// Gets the number of Principal with the given stoppedUntil
        /// </summary>
        /// <param name="id">The stoppedUntil</param>
        /// <returns>The count</returns>
        long CountByStoppedUntil ( int stoppedUntil );
        
		/// <summary>
        /// Selects all Principal based on the stoppedUntil field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByStoppedUntil ( int start, int count, int stoppedUntil );
		
 		/// <summary>
        /// Selects all Principal based on the availableVacationTicks field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByAvailableVacationTicks ( int availableVacationTicks );

        /// <summary>
        /// Gets the number of Principal with the given availableVacationTicks
        /// </summary>
        /// <param name="id">The availableVacationTicks</param>
        /// <returns>The count</returns>
        long CountByAvailableVacationTicks ( int availableVacationTicks );
        
		/// <summary>
        /// Selects all Principal based on the availableVacationTicks field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByAvailableVacationTicks ( int start, int count, int availableVacationTicks );
		
 		/// <summary>
        /// Selects all Principal based on the vacationStartTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByVacationStartTick ( int vacationStartTick );

        /// <summary>
        /// Gets the number of Principal with the given vacationStartTick
        /// </summary>
        /// <param name="id">The vacationStartTick</param>
        /// <returns>The count</returns>
        long CountByVacationStartTick ( int vacationStartTick );
        
		/// <summary>
        /// Selects all Principal based on the vacationStartTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByVacationStartTick ( int start, int count, int vacationStartTick );
		
 		/// <summary>
        /// Selects all Principal based on the vacationEndtick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByVacationEndtick ( int vacationEndtick );

        /// <summary>
        /// Gets the number of Principal with the given vacationEndtick
        /// </summary>
        /// <param name="id">The vacationEndtick</param>
        /// <returns>The count</returns>
        long CountByVacationEndtick ( int vacationEndtick );
        
		/// <summary>
        /// Selects all Principal based on the vacationEndtick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByVacationEndtick ( int start, int count, int vacationEndtick );
		
 		/// <summary>
        /// Selects all Principal based on the autoStartVacations field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByAutoStartVacations ( bool autoStartVacations );

        /// <summary>
        /// Gets the number of Principal with the given autoStartVacations
        /// </summary>
        /// <param name="id">The autoStartVacations</param>
        /// <returns>The count</returns>
        long CountByAutoStartVacations ( bool autoStartVacations );
        
		/// <summary>
        /// Selects all Principal based on the autoStartVacations field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByAutoStartVacations ( int start, int count, bool autoStartVacations );
		
 		/// <summary>
        /// Selects all Principal based on the referrerId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByReferrerId ( int referrerId );

        /// <summary>
        /// Gets the number of Principal with the given referrerId
        /// </summary>
        /// <param name="id">The referrerId</param>
        /// <returns>The count</returns>
        long CountByReferrerId ( int referrerId );
        
		/// <summary>
        /// Selects all Principal based on the referrerId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByReferrerId ( int start, int count, int referrerId );
		
 		/// <summary>
        /// Selects all Principal based on the canChangeName field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByCanChangeName ( bool canChangeName );

        /// <summary>
        /// Gets the number of Principal with the given canChangeName
        /// </summary>
        /// <param name="id">The canChangeName</param>
        /// <returns>The count</returns>
        long CountByCanChangeName ( bool canChangeName );
        
		/// <summary>
        /// Selects all Principal based on the canChangeName field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByCanChangeName ( int start, int count, bool canChangeName );
		
 		/// <summary>
        /// Selects all Principal based on the avatar field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByAvatar ( string avatar );

        /// <summary>
        /// Gets the number of Principal with the given avatar
        /// </summary>
        /// <param name="id">The avatar</param>
        /// <returns>The count</returns>
        long CountByAvatar ( string avatar );
        
		/// <summary>
        /// Selects all Principal based on the avatar field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByAvatar ( int start, int count, string avatar );
		
 		/// <summary>
        /// Selects all Principal based on the webSite field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByWebSite ( string webSite );

        /// <summary>
        /// Gets the number of Principal with the given webSite
        /// </summary>
        /// <param name="id">The webSite</param>
        /// <returns>The count</returns>
        long CountByWebSite ( string webSite );
        
		/// <summary>
        /// Selects all Principal based on the webSite field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByWebSite ( int start, int count, string webSite );
		
 		/// <summary>
        /// Selects all Principal based on the tutorialState field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByTutorialState ( int tutorialState );

        /// <summary>
        /// Gets the number of Principal with the given tutorialState
        /// </summary>
        /// <param name="id">The tutorialState</param>
        /// <returns>The count</returns>
        long CountByTutorialState ( int tutorialState );
        
		/// <summary>
        /// Selects all Principal based on the tutorialState field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByTutorialState ( int start, int count, int tutorialState );
		
 		/// <summary>
        /// Selects all Principal based on the duplicatedIds field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByDuplicatedIds ( string duplicatedIds );

        /// <summary>
        /// Gets the number of Principal with the given duplicatedIds
        /// </summary>
        /// <param name="id">The duplicatedIds</param>
        /// <returns>The count</returns>
        long CountByDuplicatedIds ( string duplicatedIds );
        
		/// <summary>
        /// Selects all Principal based on the duplicatedIds field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByDuplicatedIds ( int start, int count, string duplicatedIds );
		
 		/// <summary>
        /// Selects all Principal based on the numberOfWarnings field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByNumberOfWarnings ( int numberOfWarnings );

        /// <summary>
        /// Gets the number of Principal with the given numberOfWarnings
        /// </summary>
        /// <param name="id">The numberOfWarnings</param>
        /// <returns>The count</returns>
        long CountByNumberOfWarnings ( int numberOfWarnings );
        
		/// <summary>
        /// Selects all Principal based on the numberOfWarnings field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByNumberOfWarnings ( int start, int count, int numberOfWarnings );
		
 		/// <summary>
        /// Selects all Principal based on the acceptedTerms field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByAcceptedTerms ( bool acceptedTerms );

        /// <summary>
        /// Gets the number of Principal with the given acceptedTerms
        /// </summary>
        /// <param name="id">The acceptedTerms</param>
        /// <returns>The count</returns>
        long CountByAcceptedTerms ( bool acceptedTerms );
        
		/// <summary>
        /// Selects all Principal based on the acceptedTerms field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByAcceptedTerms ( int start, int count, bool acceptedTerms );
		
 		/// <summary>
        /// Selects all Principal based on the warningPoints field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByWarningPoints ( int warningPoints );

        /// <summary>
        /// Gets the number of Principal with the given warningPoints
        /// </summary>
        /// <param name="id">The warningPoints</param>
        /// <returns>The count</returns>
        long CountByWarningPoints ( int warningPoints );
        
		/// <summary>
        /// Selects all Principal based on the warningPoints field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByWarningPoints ( int start, int count, int warningPoints );
		
 		/// <summary>
        /// Selects all Principal based on the lastWarningDate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLastWarningDate ( DateTime lastWarningDate );

        /// <summary>
        /// Gets the number of Principal with the given lastWarningDate
        /// </summary>
        /// <param name="id">The lastWarningDate</param>
        /// <returns>The count</returns>
        long CountByLastWarningDate ( DateTime lastWarningDate );
        
		/// <summary>
        /// Selects all Principal based on the lastWarningDate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLastWarningDate ( int start, int count, DateTime lastWarningDate );
		
 		/// <summary>
        /// Selects all Principal based on the botUrl field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByBotUrl ( string botUrl );

        /// <summary>
        /// Gets the number of Principal with the given botUrl
        /// </summary>
        /// <param name="id">The botUrl</param>
        /// <returns>The count</returns>
        long CountByBotUrl ( string botUrl );
        
		/// <summary>
        /// Selects all Principal based on the botUrl field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByBotUrl ( int start, int count, string botUrl );
		
 		/// <summary>
        /// Selects all Principal based on the referrerPriceCount field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByReferrerPriceCount ( int referrerPriceCount );

        /// <summary>
        /// Gets the number of Principal with the given referrerPriceCount
        /// </summary>
        /// <param name="id">The referrerPriceCount</param>
        /// <returns>The count</returns>
        long CountByReferrerPriceCount ( int referrerPriceCount );
        
		/// <summary>
        /// Selects all Principal based on the referrerPriceCount field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByReferrerPriceCount ( int start, int count, int referrerPriceCount );
		
 		/// <summary>
        /// Selects all Principal based on the isOnVacations field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByIsOnVacations ( bool isOnVacations );

        /// <summary>
        /// Gets the number of Principal with the given isOnVacations
        /// </summary>
        /// <param name="id">The isOnVacations</param>
        /// <returns>The count</returns>
        long CountByIsOnVacations ( bool isOnVacations );
        
		/// <summary>
        /// Selects all Principal based on the isOnVacations field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByIsOnVacations ( int start, int count, bool isOnVacations );
		
 		/// <summary>
        /// Selects all Principal based on the team field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByTeam ( TeamStorage team );

        /// <summary>
        /// Gets the number of Principal with the given team
        /// </summary>
        /// <param name="id">The team</param>
        /// <returns>The count</returns>
        long CountByTeam ( TeamStorage team );
        
		/// <summary>
        /// Selects all Principal based on the team field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByTeam ( int start, int count, TeamStorage team );
		
 		/// <summary>
        /// Selects all Principal based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByName ( string name );

        /// <summary>
        /// Gets the number of Principal with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all Principal based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all Principal based on the password field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByPassword ( string password );

        /// <summary>
        /// Gets the number of Principal with the given password
        /// </summary>
        /// <param name="id">The password</param>
        /// <returns>The count</returns>
        long CountByPassword ( string password );
        
		/// <summary>
        /// Selects all Principal based on the password field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByPassword ( int start, int count, string password );
		
 		/// <summary>
        /// Selects all Principal based on the email field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByEmail ( string email );

        /// <summary>
        /// Gets the number of Principal with the given email
        /// </summary>
        /// <param name="id">The email</param>
        /// <returns>The count</returns>
        long CountByEmail ( string email );
        
		/// <summary>
        /// Selects all Principal based on the email field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByEmail ( int start, int count, string email );
		
 		/// <summary>
        /// Selects all Principal based on the ip field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByIp ( string ip );

        /// <summary>
        /// Gets the number of Principal with the given ip
        /// </summary>
        /// <param name="id">The ip</param>
        /// <returns>The count</returns>
        long CountByIp ( string ip );
        
		/// <summary>
        /// Selects all Principal based on the ip field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByIp ( int start, int count, string ip );
		
 		/// <summary>
        /// Selects all Principal based on the registDate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByRegistDate ( DateTime registDate );

        /// <summary>
        /// Gets the number of Principal with the given registDate
        /// </summary>
        /// <param name="id">The registDate</param>
        /// <returns>The count</returns>
        long CountByRegistDate ( DateTime registDate );
        
		/// <summary>
        /// Selects all Principal based on the registDate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByRegistDate ( int start, int count, DateTime registDate );
		
 		/// <summary>
        /// Selects all Principal based on the lastLogin field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLastLogin ( DateTime lastLogin );

        /// <summary>
        /// Gets the number of Principal with the given lastLogin
        /// </summary>
        /// <param name="id">The lastLogin</param>
        /// <returns>The count</returns>
        long CountByLastLogin ( DateTime lastLogin );
        
		/// <summary>
        /// Selects all Principal based on the lastLogin field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLastLogin ( int start, int count, DateTime lastLogin );
		
 		/// <summary>
        /// Selects all Principal based on the approved field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByApproved ( bool approved );

        /// <summary>
        /// Gets the number of Principal with the given approved
        /// </summary>
        /// <param name="id">The approved</param>
        /// <returns>The count</returns>
        long CountByApproved ( bool approved );
        
		/// <summary>
        /// Selects all Principal based on the approved field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByApproved ( int start, int count, bool approved );
		
 		/// <summary>
        /// Selects all Principal based on the isOnline field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByIsOnline ( bool isOnline );

        /// <summary>
        /// Gets the number of Principal with the given isOnline
        /// </summary>
        /// <param name="id">The isOnline</param>
        /// <returns>The count</returns>
        long CountByIsOnline ( bool isOnline );
        
		/// <summary>
        /// Selects all Principal based on the isOnline field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByIsOnline ( int start, int count, bool isOnline );
		
 		/// <summary>
        /// Selects all Principal based on the locked field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLocked ( bool locked );

        /// <summary>
        /// Gets the number of Principal with the given locked
        /// </summary>
        /// <param name="id">The locked</param>
        /// <returns>The count</returns>
        long CountByLocked ( bool locked );
        
		/// <summary>
        /// Selects all Principal based on the locked field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLocked ( int start, int count, bool locked );
		
 		/// <summary>
        /// Selects all Principal based on the locale field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLocale ( string locale );

        /// <summary>
        /// Gets the number of Principal with the given locale
        /// </summary>
        /// <param name="id">The locale</param>
        /// <returns>The count</returns>
        long CountByLocale ( string locale );
        
		/// <summary>
        /// Selects all Principal based on the locale field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLocale ( int start, int count, string locale );
		
 		/// <summary>
        /// Selects all Principal based on the confirmationCode field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByConfirmationCode ( string confirmationCode );

        /// <summary>
        /// Gets the number of Principal with the given confirmationCode
        /// </summary>
        /// <param name="id">The confirmationCode</param>
        /// <returns>The count</returns>
        long CountByConfirmationCode ( string confirmationCode );
        
		/// <summary>
        /// Selects all Principal based on the confirmationCode field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByConfirmationCode ( int start, int count, string confirmationCode );
		
 		/// <summary>
        /// Selects all Principal based on the rawRoles field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByRawRoles ( string rawRoles );

        /// <summary>
        /// Gets the number of Principal with the given rawRoles
        /// </summary>
        /// <param name="id">The rawRoles</param>
        /// <returns>The count</returns>
        long CountByRawRoles ( string rawRoles );
        
		/// <summary>
        /// Selects all Principal based on the rawRoles field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByRawRoles ( int start, int count, string rawRoles );
		
 		#endregion ExtendedMethods

	};
}
