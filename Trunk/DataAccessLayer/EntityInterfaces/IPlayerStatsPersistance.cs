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
    /// Handles persistance for PlayerStats objects
    /// </summary>
	public interface IPlayerStatsPersistance : IPersistance<PlayerStats> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all PlayerStats based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStats collection</returns>
		IList<PlayerStats> SelectById ( int id );

        /// <summary>
        /// Gets the number of PlayerStats with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all PlayerStats based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStats collection</returns>
		IList<PlayerStats> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all PlayerStats based on the numberOfPlayedBattles field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStats collection</returns>
		IList<PlayerStats> SelectByNumberOfPlayedBattles ( int numberOfPlayedBattles );

        /// <summary>
        /// Gets the number of PlayerStats with the given numberOfPlayedBattles
        /// </summary>
        /// <param name="id">The numberOfPlayedBattles</param>
        /// <returns>The count</returns>
        long CountByNumberOfPlayedBattles ( int numberOfPlayedBattles );
        
		/// <summary>
        /// Selects all PlayerStats based on the numberOfPlayedBattles field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStats collection</returns>
		IList<PlayerStats> SelectByNumberOfPlayedBattles ( int start, int count, int numberOfPlayedBattles );
		
 		/// <summary>
        /// Selects all PlayerStats based on the numberPirateQuest field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStats collection</returns>
		IList<PlayerStats> SelectByNumberPirateQuest ( int numberPirateQuest );

        /// <summary>
        /// Gets the number of PlayerStats with the given numberPirateQuest
        /// </summary>
        /// <param name="id">The numberPirateQuest</param>
        /// <returns>The count</returns>
        long CountByNumberPirateQuest ( int numberPirateQuest );
        
		/// <summary>
        /// Selects all PlayerStats based on the numberPirateQuest field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStats collection</returns>
		IList<PlayerStats> SelectByNumberPirateQuest ( int start, int count, int numberPirateQuest );
		
 		/// <summary>
        /// Selects all PlayerStats based on the numberBountyQuests field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStats collection</returns>
		IList<PlayerStats> SelectByNumberBountyQuests ( int numberBountyQuests );

        /// <summary>
        /// Gets the number of PlayerStats with the given numberBountyQuests
        /// </summary>
        /// <param name="id">The numberBountyQuests</param>
        /// <returns>The count</returns>
        long CountByNumberBountyQuests ( int numberBountyQuests );
        
		/// <summary>
        /// Selects all PlayerStats based on the numberBountyQuests field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStats collection</returns>
		IList<PlayerStats> SelectByNumberBountyQuests ( int start, int count, int numberBountyQuests );
		
 		/// <summary>
        /// Selects all PlayerStats based on the numberMerchantQuests field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStats collection</returns>
		IList<PlayerStats> SelectByNumberMerchantQuests ( int numberMerchantQuests );

        /// <summary>
        /// Gets the number of PlayerStats with the given numberMerchantQuests
        /// </summary>
        /// <param name="id">The numberMerchantQuests</param>
        /// <returns>The count</returns>
        long CountByNumberMerchantQuests ( int numberMerchantQuests );
        
		/// <summary>
        /// Selects all PlayerStats based on the numberMerchantQuests field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStats collection</returns>
		IList<PlayerStats> SelectByNumberMerchantQuests ( int start, int count, int numberMerchantQuests );
		
 		/// <summary>
        /// Selects all PlayerStats based on the numberGladiatorQuests field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStats collection</returns>
		IList<PlayerStats> SelectByNumberGladiatorQuests ( int numberGladiatorQuests );

        /// <summary>
        /// Gets the number of PlayerStats with the given numberGladiatorQuests
        /// </summary>
        /// <param name="id">The numberGladiatorQuests</param>
        /// <returns>The count</returns>
        long CountByNumberGladiatorQuests ( int numberGladiatorQuests );
        
		/// <summary>
        /// Selects all PlayerStats based on the numberGladiatorQuests field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStats collection</returns>
		IList<PlayerStats> SelectByNumberGladiatorQuests ( int start, int count, int numberGladiatorQuests );
		
 		/// <summary>
        /// Selects all PlayerStats based on the numberColonizerQuests field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStats collection</returns>
		IList<PlayerStats> SelectByNumberColonizerQuests ( int numberColonizerQuests );

        /// <summary>
        /// Gets the number of PlayerStats with the given numberColonizerQuests
        /// </summary>
        /// <param name="id">The numberColonizerQuests</param>
        /// <returns>The count</returns>
        long CountByNumberColonizerQuests ( int numberColonizerQuests );
        
		/// <summary>
        /// Selects all PlayerStats based on the numberColonizerQuests field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlayerStats collection</returns>
		IList<PlayerStats> SelectByNumberColonizerQuests ( int start, int count, int numberColonizerQuests );
		
 		#endregion ExtendedMethods

	};
}
