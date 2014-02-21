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
    /// Handles persistance for CampaignLevel objects
    /// </summary>
	public interface ICampaignLevelPersistance : IPersistance<CampaignLevel> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all CampaignLevel based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The CampaignLevel collection</returns>
		IList<CampaignLevel> SelectById ( int id );

        /// <summary>
        /// Gets the number of CampaignLevel with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all CampaignLevel based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The CampaignLevel collection</returns>
		IList<CampaignLevel> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all CampaignLevel based on the botFleet field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The CampaignLevel collection</returns>
		IList<CampaignLevel> SelectByBotFleet ( string botFleet );

        /// <summary>
        /// Gets the number of CampaignLevel with the given botFleet
        /// </summary>
        /// <param name="id">The botFleet</param>
        /// <returns>The count</returns>
        long CountByBotFleet ( string botFleet );
        
		/// <summary>
        /// Selects all CampaignLevel based on the botFleet field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The CampaignLevel collection</returns>
		IList<CampaignLevel> SelectByBotFleet ( int start, int count, string botFleet );
		
 		/// <summary>
        /// Selects all CampaignLevel based on the playerFleet field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The CampaignLevel collection</returns>
		IList<CampaignLevel> SelectByPlayerFleet ( string playerFleet );

        /// <summary>
        /// Gets the number of CampaignLevel with the given playerFleet
        /// </summary>
        /// <param name="id">The playerFleet</param>
        /// <returns>The count</returns>
        long CountByPlayerFleet ( string playerFleet );
        
		/// <summary>
        /// Selects all CampaignLevel based on the playerFleet field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The CampaignLevel collection</returns>
		IList<CampaignLevel> SelectByPlayerFleet ( int start, int count, string playerFleet );
		
 		/// <summary>
        /// Selects all CampaignLevel based on the level field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The CampaignLevel collection</returns>
		IList<CampaignLevel> SelectByLevel ( int level );

        /// <summary>
        /// Gets the number of CampaignLevel with the given level
        /// </summary>
        /// <param name="id">The level</param>
        /// <returns>The count</returns>
        long CountByLevel ( int level );
        
		/// <summary>
        /// Selects all CampaignLevel based on the level field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The CampaignLevel collection</returns>
		IList<CampaignLevel> SelectByLevel ( int start, int count, int level );
		
 		/// <summary>
        /// Selects all CampaignLevel based on the botName field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The CampaignLevel collection</returns>
		IList<CampaignLevel> SelectByBotName ( string botName );

        /// <summary>
        /// Gets the number of CampaignLevel with the given botName
        /// </summary>
        /// <param name="id">The botName</param>
        /// <returns>The count</returns>
        long CountByBotName ( string botName );
        
		/// <summary>
        /// Selects all CampaignLevel based on the botName field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The CampaignLevel collection</returns>
		IList<CampaignLevel> SelectByBotName ( int start, int count, string botName );
		
 		/// <summary>
        /// Selects all CampaignLevel based on the campaign field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The CampaignLevel collection</returns>
		IList<CampaignLevel> SelectByCampaign ( Campaign campaign );

        /// <summary>
        /// Gets the number of CampaignLevel with the given campaign
        /// </summary>
        /// <param name="id">The campaign</param>
        /// <returns>The count</returns>
        long CountByCampaign ( Campaign campaign );
        
		/// <summary>
        /// Selects all CampaignLevel based on the campaign field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The CampaignLevel collection</returns>
		IList<CampaignLevel> SelectByCampaign ( int start, int count, Campaign campaign );
		
 		#endregion ExtendedMethods

	};
}
