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
    /// Handles persistance for CampaignStatus objects
    /// </summary>
	public interface ICampaignStatusPersistance : IPersistance<CampaignStatus> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all CampaignStatus based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectById ( int id );

        /// <summary>
        /// Gets the number of CampaignStatus with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all CampaignStatus based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all CampaignStatus based on the level field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectByLevel ( int level );

        /// <summary>
        /// Gets the number of CampaignStatus with the given level
        /// </summary>
        /// <param name="id">The level</param>
        /// <returns>The count</returns>
        long CountByLevel ( int level );
        
		/// <summary>
        /// Selects all CampaignStatus based on the level field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectByLevel ( int start, int count, int level );
		
 		/// <summary>
        /// Selects all CampaignStatus based on the moves field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectByMoves ( int moves );

        /// <summary>
        /// Gets the number of CampaignStatus with the given moves
        /// </summary>
        /// <param name="id">The moves</param>
        /// <returns>The count</returns>
        long CountByMoves ( int moves );
        
		/// <summary>
        /// Selects all CampaignStatus based on the moves field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectByMoves ( int start, int count, int moves );
		
 		/// <summary>
        /// Selects all CampaignStatus based on the completed field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectByCompleted ( bool completed );

        /// <summary>
        /// Gets the number of CampaignStatus with the given completed
        /// </summary>
        /// <param name="id">The completed</param>
        /// <returns>The count</returns>
        long CountByCompleted ( bool completed );
        
		/// <summary>
        /// Selects all CampaignStatus based on the completed field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectByCompleted ( int start, int count, bool completed );
		
 		/// <summary>
        /// Selects all CampaignStatus based on the campaign field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectByCampaign ( Campaign campaign );

        /// <summary>
        /// Gets the number of CampaignStatus with the given campaign
        /// </summary>
        /// <param name="id">The campaign</param>
        /// <returns>The count</returns>
        long CountByCampaign ( Campaign campaign );
        
		/// <summary>
        /// Selects all CampaignStatus based on the campaign field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectByCampaign ( int start, int count, Campaign campaign );
		
 		/// <summary>
        /// Selects all CampaignStatus based on the principal field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectByPrincipal ( Principal principal );

        /// <summary>
        /// Gets the number of CampaignStatus with the given principal
        /// </summary>
        /// <param name="id">The principal</param>
        /// <returns>The count</returns>
        long CountByPrincipal ( Principal principal );
        
		/// <summary>
        /// Selects all CampaignStatus based on the principal field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectByPrincipal ( int start, int count, Principal principal );
		
 		/// <summary>
        /// Selects all CampaignStatus based on the battle field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectByBattle ( Battle battle );

        /// <summary>
        /// Gets the number of CampaignStatus with the given battle
        /// </summary>
        /// <param name="id">The battle</param>
        /// <returns>The count</returns>
        long CountByBattle ( Battle battle );
        
		/// <summary>
        /// Selects all CampaignStatus based on the battle field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectByBattle ( int start, int count, Battle battle );
		
 		/// <summary>
        /// Selects all CampaignStatus based on the levelTemplate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectByLevelTemplate ( CampaignLevel levelTemplate );

        /// <summary>
        /// Gets the number of CampaignStatus with the given levelTemplate
        /// </summary>
        /// <param name="id">The levelTemplate</param>
        /// <returns>The count</returns>
        long CountByLevelTemplate ( CampaignLevel levelTemplate );
        
		/// <summary>
        /// Selects all CampaignStatus based on the levelTemplate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The CampaignStatus collection</returns>
		IList<CampaignStatus> SelectByLevelTemplate ( int start, int count, CampaignLevel levelTemplate );
		
 		#endregion ExtendedMethods

	};
}
