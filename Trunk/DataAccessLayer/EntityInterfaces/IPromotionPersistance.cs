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
    /// Handles persistance for Promotion objects
    /// </summary>
	public interface IPromotionPersistance : IPersistance<Promotion> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Promotion based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectById ( int id );

        /// <summary>
        /// Gets the number of Promotion with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Promotion based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Promotion based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByName ( string name );

        /// <summary>
        /// Gets the number of Promotion with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all Promotion based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all Promotion based on the beginDate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByBeginDate ( DateTime beginDate );

        /// <summary>
        /// Gets the number of Promotion with the given beginDate
        /// </summary>
        /// <param name="id">The beginDate</param>
        /// <returns>The count</returns>
        long CountByBeginDate ( DateTime beginDate );
        
		/// <summary>
        /// Selects all Promotion based on the beginDate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByBeginDate ( int start, int count, DateTime beginDate );
		
 		/// <summary>
        /// Selects all Promotion based on the endDate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByEndDate ( DateTime endDate );

        /// <summary>
        /// Gets the number of Promotion with the given endDate
        /// </summary>
        /// <param name="id">The endDate</param>
        /// <returns>The count</returns>
        long CountByEndDate ( DateTime endDate );
        
		/// <summary>
        /// Selects all Promotion based on the endDate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByEndDate ( int start, int count, DateTime endDate );
		
 		/// <summary>
        /// Selects all Promotion based on the revenueType field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByRevenueType ( string revenueType );

        /// <summary>
        /// Gets the number of Promotion with the given revenueType
        /// </summary>
        /// <param name="id">The revenueType</param>
        /// <returns>The count</returns>
        long CountByRevenueType ( string revenueType );
        
		/// <summary>
        /// Selects all Promotion based on the revenueType field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByRevenueType ( int start, int count, string revenueType );
		
 		/// <summary>
        /// Selects all Promotion based on the revenue field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByRevenue ( double revenue );

        /// <summary>
        /// Gets the number of Promotion with the given revenue
        /// </summary>
        /// <param name="id">The revenue</param>
        /// <returns>The count</returns>
        long CountByRevenue ( double revenue );
        
		/// <summary>
        /// Selects all Promotion based on the revenue field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByRevenue ( int start, int count, double revenue );
		
 		/// <summary>
        /// Selects all Promotion based on the promotionType field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByPromotionType ( string promotionType );

        /// <summary>
        /// Gets the number of Promotion with the given promotionType
        /// </summary>
        /// <param name="id">The promotionType</param>
        /// <returns>The count</returns>
        long CountByPromotionType ( string promotionType );
        
		/// <summary>
        /// Selects all Promotion based on the promotionType field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByPromotionType ( int start, int count, string promotionType );
		
 		/// <summary>
        /// Selects all Promotion based on the rangeBegin field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByRangeBegin ( int rangeBegin );

        /// <summary>
        /// Gets the number of Promotion with the given rangeBegin
        /// </summary>
        /// <param name="id">The rangeBegin</param>
        /// <returns>The count</returns>
        long CountByRangeBegin ( int rangeBegin );
        
		/// <summary>
        /// Selects all Promotion based on the rangeBegin field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByRangeBegin ( int start, int count, int rangeBegin );
		
 		/// <summary>
        /// Selects all Promotion based on the rangeEnd field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByRangeEnd ( int rangeEnd );

        /// <summary>
        /// Gets the number of Promotion with the given rangeEnd
        /// </summary>
        /// <param name="id">The rangeEnd</param>
        /// <returns>The count</returns>
        long CountByRangeEnd ( int rangeEnd );
        
		/// <summary>
        /// Selects all Promotion based on the rangeEnd field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByRangeEnd ( int start, int count, int rangeEnd );
		
 		/// <summary>
        /// Selects all Promotion based on the promotionCode field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByPromotionCode ( int promotionCode );

        /// <summary>
        /// Gets the number of Promotion with the given promotionCode
        /// </summary>
        /// <param name="id">The promotionCode</param>
        /// <returns>The count</returns>
        long CountByPromotionCode ( int promotionCode );
        
		/// <summary>
        /// Selects all Promotion based on the promotionCode field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByPromotionCode ( int start, int count, int promotionCode );
		
 		/// <summary>
        /// Selects all Promotion based on the bonusType field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByBonusType ( string bonusType );

        /// <summary>
        /// Gets the number of Promotion with the given bonusType
        /// </summary>
        /// <param name="id">The bonusType</param>
        /// <returns>The count</returns>
        long CountByBonusType ( string bonusType );
        
		/// <summary>
        /// Selects all Promotion based on the bonusType field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByBonusType ( int start, int count, string bonusType );
		
 		/// <summary>
        /// Selects all Promotion based on the bonus field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByBonus ( int bonus );

        /// <summary>
        /// Gets the number of Promotion with the given bonus
        /// </summary>
        /// <param name="id">The bonus</param>
        /// <returns>The count</returns>
        long CountByBonus ( int bonus );
        
		/// <summary>
        /// Selects all Promotion based on the bonus field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByBonus ( int start, int count, int bonus );
		
 		/// <summary>
        /// Selects all Promotion based on the status field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByStatus ( string status );

        /// <summary>
        /// Gets the number of Promotion with the given status
        /// </summary>
        /// <param name="id">The status</param>
        /// <returns>The count</returns>
        long CountByStatus ( string status );
        
		/// <summary>
        /// Selects all Promotion based on the status field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByStatus ( int start, int count, string status );
		
 		/// <summary>
        /// Selects all Promotion based on the description field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByDescription ( string description );

        /// <summary>
        /// Gets the number of Promotion with the given description
        /// </summary>
        /// <param name="id">The description</param>
        /// <returns>The count</returns>
        long CountByDescription ( string description );
        
		/// <summary>
        /// Selects all Promotion based on the description field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByDescription ( int start, int count, string description );
		
 		/// <summary>
        /// Selects all Promotion based on the uses field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByUses ( int uses );

        /// <summary>
        /// Gets the number of Promotion with the given uses
        /// </summary>
        /// <param name="id">The uses</param>
        /// <returns>The count</returns>
        long CountByUses ( int uses );
        
		/// <summary>
        /// Selects all Promotion based on the uses field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByUses ( int start, int count, int uses );
		
 		/// <summary>
        /// Selects all Promotion based on the owner field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByOwner ( Principal owner );

        /// <summary>
        /// Gets the number of Promotion with the given owner
        /// </summary>
        /// <param name="id">The owner</param>
        /// <returns>The count</returns>
        long CountByOwner ( Principal owner );
        
		/// <summary>
        /// Selects all Promotion based on the owner field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Promotion collection</returns>
		IList<Promotion> SelectByOwner ( int start, int count, Principal owner );
		
 		#endregion ExtendedMethods

	};
}
