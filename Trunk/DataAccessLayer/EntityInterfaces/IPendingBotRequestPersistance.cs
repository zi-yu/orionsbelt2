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
    /// Handles persistance for PendingBotRequest objects
    /// </summary>
	public interface IPendingBotRequestPersistance : IPersistance<PendingBotRequest> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all PendingBotRequest based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PendingBotRequest collection</returns>
		IList<PendingBotRequest> SelectById ( int id );

        /// <summary>
        /// Gets the number of PendingBotRequest with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all PendingBotRequest based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PendingBotRequest collection</returns>
		IList<PendingBotRequest> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all PendingBotRequest based on the botName field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PendingBotRequest collection</returns>
		IList<PendingBotRequest> SelectByBotName ( string botName );

        /// <summary>
        /// Gets the number of PendingBotRequest with the given botName
        /// </summary>
        /// <param name="id">The botName</param>
        /// <returns>The count</returns>
        long CountByBotName ( string botName );
        
		/// <summary>
        /// Selects all PendingBotRequest based on the botName field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PendingBotRequest collection</returns>
		IList<PendingBotRequest> SelectByBotName ( int start, int count, string botName );
		
 		/// <summary>
        /// Selects all PendingBotRequest based on the xml field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PendingBotRequest collection</returns>
		IList<PendingBotRequest> SelectByXml ( string xml );

        /// <summary>
        /// Gets the number of PendingBotRequest with the given xml
        /// </summary>
        /// <param name="id">The xml</param>
        /// <returns>The count</returns>
        long CountByXml ( string xml );
        
		/// <summary>
        /// Selects all PendingBotRequest based on the xml field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PendingBotRequest collection</returns>
		IList<PendingBotRequest> SelectByXml ( int start, int count, string xml );
		
 		/// <summary>
        /// Selects all PendingBotRequest based on the battleId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PendingBotRequest collection</returns>
		IList<PendingBotRequest> SelectByBattleId ( int battleId );

        /// <summary>
        /// Gets the number of PendingBotRequest with the given battleId
        /// </summary>
        /// <param name="id">The battleId</param>
        /// <returns>The count</returns>
        long CountByBattleId ( int battleId );
        
		/// <summary>
        /// Selects all PendingBotRequest based on the battleId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PendingBotRequest collection</returns>
		IList<PendingBotRequest> SelectByBattleId ( int start, int count, int battleId );
		
 		/// <summary>
        /// Selects all PendingBotRequest based on the botId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PendingBotRequest collection</returns>
		IList<PendingBotRequest> SelectByBotId ( int botId );

        /// <summary>
        /// Gets the number of PendingBotRequest with the given botId
        /// </summary>
        /// <param name="id">The botId</param>
        /// <returns>The count</returns>
        long CountByBotId ( int botId );
        
		/// <summary>
        /// Selects all PendingBotRequest based on the botId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PendingBotRequest collection</returns>
		IList<PendingBotRequest> SelectByBotId ( int start, int count, int botId );
		
 		/// <summary>
        /// Selects all PendingBotRequest based on the code field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PendingBotRequest collection</returns>
		IList<PendingBotRequest> SelectByCode ( int code );

        /// <summary>
        /// Gets the number of PendingBotRequest with the given code
        /// </summary>
        /// <param name="id">The code</param>
        /// <returns>The count</returns>
        long CountByCode ( int code );
        
		/// <summary>
        /// Selects all PendingBotRequest based on the code field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PendingBotRequest collection</returns>
		IList<PendingBotRequest> SelectByCode ( int start, int count, int code );
		
 		#endregion ExtendedMethods

	};
}
