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
    /// Handles persistance for PlayerStorage objects
    /// </summary>
	public interface IPlayerStoragePersistance : IPersistance<PlayerStorage> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all PlayerStorage based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectById ( int id );

        /// <summary>
        /// Gets the number of PlayerStorage with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all PlayerStorage based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByName ( string name );

        /// <summary>
        /// Gets the number of PlayerStorage with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all PlayerStorage based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the lastProcessedTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByLastProcessedTick ( int lastProcessedTick );

        /// <summary>
        /// Gets the number of PlayerStorage with the given lastProcessedTick
        /// </summary>
        /// <param name="id">The lastProcessedTick</param>
        /// <returns>The count</returns>
        long CountByLastProcessedTick ( int lastProcessedTick );
        
		/// <summary>
        /// Selects all PlayerStorage based on the lastProcessedTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByLastProcessedTick ( int start, int count, int lastProcessedTick );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the intrinsicLimits field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByIntrinsicLimits ( string intrinsicLimits );

        /// <summary>
        /// Gets the number of PlayerStorage with the given intrinsicLimits
        /// </summary>
        /// <param name="id">The intrinsicLimits</param>
        /// <returns>The count</returns>
        long CountByIntrinsicLimits ( string intrinsicLimits );
        
		/// <summary>
        /// Selects all PlayerStorage based on the intrinsicLimits field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByIntrinsicLimits ( int start, int count, string intrinsicLimits );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the score field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByScore ( int score );

        /// <summary>
        /// Gets the number of PlayerStorage with the given score
        /// </summary>
        /// <param name="id">The score</param>
        /// <returns>The count</returns>
        long CountByScore ( int score );
        
		/// <summary>
        /// Selects all PlayerStorage based on the score field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByScore ( int start, int count, int score );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the allianceRank field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByAllianceRank ( string allianceRank );

        /// <summary>
        /// Gets the number of PlayerStorage with the given allianceRank
        /// </summary>
        /// <param name="id">The allianceRank</param>
        /// <returns>The count</returns>
        long CountByAllianceRank ( string allianceRank );
        
		/// <summary>
        /// Selects all PlayerStorage based on the allianceRank field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByAllianceRank ( int start, int count, string allianceRank );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the race field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByRace ( string race );

        /// <summary>
        /// Gets the number of PlayerStorage with the given race
        /// </summary>
        /// <param name="id">The race</param>
        /// <returns>The count</returns>
        long CountByRace ( string race );
        
		/// <summary>
        /// Selects all PlayerStorage based on the race field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByRace ( int start, int count, string race );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the homePlanetId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByHomePlanetId ( int homePlanetId );

        /// <summary>
        /// Gets the number of PlayerStorage with the given homePlanetId
        /// </summary>
        /// <param name="id">The homePlanetId</param>
        /// <returns>The count</returns>
        long CountByHomePlanetId ( int homePlanetId );
        
		/// <summary>
        /// Selects all PlayerStorage based on the homePlanetId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByHomePlanetId ( int start, int count, int homePlanetId );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the pirateRanking field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByPirateRanking ( int pirateRanking );

        /// <summary>
        /// Gets the number of PlayerStorage with the given pirateRanking
        /// </summary>
        /// <param name="id">The pirateRanking</param>
        /// <returns>The count</returns>
        long CountByPirateRanking ( int pirateRanking );
        
		/// <summary>
        /// Selects all PlayerStorage based on the pirateRanking field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByPirateRanking ( int start, int count, int pirateRanking );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the bountyRanking field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByBountyRanking ( int bountyRanking );

        /// <summary>
        /// Gets the number of PlayerStorage with the given bountyRanking
        /// </summary>
        /// <param name="id">The bountyRanking</param>
        /// <returns>The count</returns>
        long CountByBountyRanking ( int bountyRanking );
        
		/// <summary>
        /// Selects all PlayerStorage based on the bountyRanking field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByBountyRanking ( int start, int count, int bountyRanking );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the merchantRanking field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByMerchantRanking ( int merchantRanking );

        /// <summary>
        /// Gets the number of PlayerStorage with the given merchantRanking
        /// </summary>
        /// <param name="id">The merchantRanking</param>
        /// <returns>The count</returns>
        long CountByMerchantRanking ( int merchantRanking );
        
		/// <summary>
        /// Selects all PlayerStorage based on the merchantRanking field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByMerchantRanking ( int start, int count, int merchantRanking );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the gladiatorRanking field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByGladiatorRanking ( int gladiatorRanking );

        /// <summary>
        /// Gets the number of PlayerStorage with the given gladiatorRanking
        /// </summary>
        /// <param name="id">The gladiatorRanking</param>
        /// <returns>The count</returns>
        long CountByGladiatorRanking ( int gladiatorRanking );
        
		/// <summary>
        /// Selects all PlayerStorage based on the gladiatorRanking field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByGladiatorRanking ( int start, int count, int gladiatorRanking );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the colonizerRanking field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByColonizerRanking ( int colonizerRanking );

        /// <summary>
        /// Gets the number of PlayerStorage with the given colonizerRanking
        /// </summary>
        /// <param name="id">The colonizerRanking</param>
        /// <returns>The count</returns>
        long CountByColonizerRanking ( int colonizerRanking );
        
		/// <summary>
        /// Selects all PlayerStorage based on the colonizerRanking field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByColonizerRanking ( int start, int count, int colonizerRanking );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the intrinsicQuantities field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByIntrinsicQuantities ( string intrinsicQuantities );

        /// <summary>
        /// Gets the number of PlayerStorage with the given intrinsicQuantities
        /// </summary>
        /// <param name="id">The intrinsicQuantities</param>
        /// <returns>The count</returns>
        long CountByIntrinsicQuantities ( string intrinsicQuantities );
        
		/// <summary>
        /// Selects all PlayerStorage based on the intrinsicQuantities field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByIntrinsicQuantities ( int start, int count, string intrinsicQuantities );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the planetLevel field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByPlanetLevel ( int planetLevel );

        /// <summary>
        /// Gets the number of PlayerStorage with the given planetLevel
        /// </summary>
        /// <param name="id">The planetLevel</param>
        /// <returns>The count</returns>
        long CountByPlanetLevel ( int planetLevel );
        
		/// <summary>
        /// Selects all PlayerStorage based on the planetLevel field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByPlanetLevel ( int start, int count, int planetLevel );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the questContextLevel field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByQuestContextLevel ( string questContextLevel );

        /// <summary>
        /// Gets the number of PlayerStorage with the given questContextLevel
        /// </summary>
        /// <param name="id">The questContextLevel</param>
        /// <returns>The count</returns>
        long CountByQuestContextLevel ( string questContextLevel );
        
		/// <summary>
        /// Selects all PlayerStorage based on the questContextLevel field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByQuestContextLevel ( int start, int count, string questContextLevel );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the active field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByActive ( bool active );

        /// <summary>
        /// Gets the number of PlayerStorage with the given active
        /// </summary>
        /// <param name="id">The active</param>
        /// <returns>The count</returns>
        long CountByActive ( bool active );
        
		/// <summary>
        /// Selects all PlayerStorage based on the active field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByActive ( int start, int count, bool active );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the avatar field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByAvatar ( string avatar );

        /// <summary>
        /// Gets the number of PlayerStorage with the given avatar
        /// </summary>
        /// <param name="id">The avatar</param>
        /// <returns>The count</returns>
        long CountByAvatar ( string avatar );
        
		/// <summary>
        /// Selects all PlayerStorage based on the avatar field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByAvatar ( int start, int count, string avatar );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the ultimateWeaponLevel field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByUltimateWeaponLevel ( int ultimateWeaponLevel );

        /// <summary>
        /// Gets the number of PlayerStorage with the given ultimateWeaponLevel
        /// </summary>
        /// <param name="id">The ultimateWeaponLevel</param>
        /// <returns>The count</returns>
        long CountByUltimateWeaponLevel ( int ultimateWeaponLevel );
        
		/// <summary>
        /// Selects all PlayerStorage based on the ultimateWeaponLevel field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByUltimateWeaponLevel ( int start, int count, int ultimateWeaponLevel );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the services field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByServices ( string services );

        /// <summary>
        /// Gets the number of PlayerStorage with the given services
        /// </summary>
        /// <param name="id">The services</param>
        /// <returns>The count</returns>
        long CountByServices ( string services );
        
		/// <summary>
        /// Selects all PlayerStorage based on the services field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByServices ( int start, int count, string services );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the ultimateWeaponCooldown field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByUltimateWeaponCooldown ( int ultimateWeaponCooldown );

        /// <summary>
        /// Gets the number of PlayerStorage with the given ultimateWeaponCooldown
        /// </summary>
        /// <param name="id">The ultimateWeaponCooldown</param>
        /// <returns>The count</returns>
        long CountByUltimateWeaponCooldown ( int ultimateWeaponCooldown );
        
		/// <summary>
        /// Selects all PlayerStorage based on the ultimateWeaponCooldown field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByUltimateWeaponCooldown ( int start, int count, int ultimateWeaponCooldown );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the activatedInTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByActivatedInTick ( int activatedInTick );

        /// <summary>
        /// Gets the number of PlayerStorage with the given activatedInTick
        /// </summary>
        /// <param name="id">The activatedInTick</param>
        /// <returns>The count</returns>
        long CountByActivatedInTick ( int activatedInTick );
        
		/// <summary>
        /// Selects all PlayerStorage based on the activatedInTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByActivatedInTick ( int start, int count, int activatedInTick );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the isGeneralActive field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByIsGeneralActive ( bool isGeneralActive );

        /// <summary>
        /// Gets the number of PlayerStorage with the given isGeneralActive
        /// </summary>
        /// <param name="id">The isGeneralActive</param>
        /// <returns>The count</returns>
        long CountByIsGeneralActive ( bool isGeneralActive );
        
		/// <summary>
        /// Selects all PlayerStorage based on the isGeneralActive field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByIsGeneralActive ( int start, int count, bool isGeneralActive );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the generalId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByGeneralId ( int generalId );

        /// <summary>
        /// Gets the number of PlayerStorage with the given generalId
        /// </summary>
        /// <param name="id">The generalId</param>
        /// <returns>The count</returns>
        long CountByGeneralId ( int generalId );
        
		/// <summary>
        /// Selects all PlayerStorage based on the generalId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByGeneralId ( int start, int count, int generalId );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the generalName field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByGeneralName ( string generalName );

        /// <summary>
        /// Gets the number of PlayerStorage with the given generalName
        /// </summary>
        /// <param name="id">The generalName</param>
        /// <returns>The count</returns>
        long CountByGeneralName ( string generalName );
        
		/// <summary>
        /// Selects all PlayerStorage based on the generalName field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByGeneralName ( int start, int count, string generalName );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the generalFriendlyName field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByGeneralFriendlyName ( string generalFriendlyName );

        /// <summary>
        /// Gets the number of PlayerStorage with the given generalFriendlyName
        /// </summary>
        /// <param name="id">The generalFriendlyName</param>
        /// <returns>The count</returns>
        long CountByGeneralFriendlyName ( string generalFriendlyName );
        
		/// <summary>
        /// Selects all PlayerStorage based on the generalFriendlyName field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByGeneralFriendlyName ( int start, int count, string generalFriendlyName );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the isPrimary field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByIsPrimary ( bool isPrimary );

        /// <summary>
        /// Gets the number of PlayerStorage with the given isPrimary
        /// </summary>
        /// <param name="id">The isPrimary</param>
        /// <returns>The count</returns>
        long CountByIsPrimary ( bool isPrimary );
        
		/// <summary>
        /// Selects all PlayerStorage based on the isPrimary field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByIsPrimary ( int start, int count, bool isPrimary );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the isOnVacations field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByIsOnVacations ( bool isOnVacations );

        /// <summary>
        /// Gets the number of PlayerStorage with the given isOnVacations
        /// </summary>
        /// <param name="id">The isOnVacations</param>
        /// <returns>The count</returns>
        long CountByIsOnVacations ( bool isOnVacations );
        
		/// <summary>
        /// Selects all PlayerStorage based on the isOnVacations field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByIsOnVacations ( int start, int count, bool isOnVacations );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the totalPosts field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByTotalPosts ( int totalPosts );

        /// <summary>
        /// Gets the number of PlayerStorage with the given totalPosts
        /// </summary>
        /// <param name="id">The totalPosts</param>
        /// <returns>The count</returns>
        long CountByTotalPosts ( int totalPosts );
        
		/// <summary>
        /// Selects all PlayerStorage based on the totalPosts field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByTotalPosts ( int start, int count, int totalPosts );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the signature field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectBySignature ( string signature );

        /// <summary>
        /// Gets the number of PlayerStorage with the given signature
        /// </summary>
        /// <param name="id">The signature</param>
        /// <returns>The count</returns>
        long CountBySignature ( string signature );
        
		/// <summary>
        /// Selects all PlayerStorage based on the signature field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectBySignature ( int start, int count, string signature );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the forumRole field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByForumRole ( string forumRole );

        /// <summary>
        /// Gets the number of PlayerStorage with the given forumRole
        /// </summary>
        /// <param name="id">The forumRole</param>
        /// <returns>The count</returns>
        long CountByForumRole ( string forumRole );
        
		/// <summary>
        /// Selects all PlayerStorage based on the forumRole field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByForumRole ( int start, int count, string forumRole );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the principal field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByPrincipal ( Principal principal );

        /// <summary>
        /// Gets the number of PlayerStorage with the given principal
        /// </summary>
        /// <param name="id">The principal</param>
        /// <returns>The count</returns>
        long CountByPrincipal ( Principal principal );
        
		/// <summary>
        /// Selects all PlayerStorage based on the principal field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByPrincipal ( int start, int count, Principal principal );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the alliance field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByAlliance ( AllianceStorage alliance );

        /// <summary>
        /// Gets the number of PlayerStorage with the given alliance
        /// </summary>
        /// <param name="id">The alliance</param>
        /// <returns>The count</returns>
        long CountByAlliance ( AllianceStorage alliance );
        
		/// <summary>
        /// Selects all PlayerStorage based on the alliance field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByAlliance ( int start, int count, AllianceStorage alliance );
		
 		/// <summary>
        /// Selects all PlayerStorage based on the stats field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByStats ( PlayerStats stats );

        /// <summary>
        /// Gets the number of PlayerStorage with the given stats
        /// </summary>
        /// <param name="id">The stats</param>
        /// <returns>The count</returns>
        long CountByStats ( PlayerStats stats );
        
		/// <summary>
        /// Selects all PlayerStorage based on the stats field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStorage collection</returns>
		IList<PlayerStorage> SelectByStats ( int start, int count, PlayerStats stats );
		
 		#endregion ExtendedMethods

	};
}
