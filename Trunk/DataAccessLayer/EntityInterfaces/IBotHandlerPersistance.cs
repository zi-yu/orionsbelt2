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
    /// Handles persistance for BotHandler objects
    /// </summary>
	public interface IBotHandlerPersistance : IPersistance<BotHandler> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all BotHandler based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BotHandler collection</returns>
		IList<BotHandler> SelectById ( int id );

        /// <summary>
        /// Gets the number of BotHandler with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all BotHandler based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BotHandler collection</returns>
		IList<BotHandler> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all BotHandler based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BotHandler collection</returns>
		IList<BotHandler> SelectByName ( string name );

        /// <summary>
        /// Gets the number of BotHandler with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all BotHandler based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BotHandler collection</returns>
		IList<BotHandler> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all BotHandler based on the code field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BotHandler collection</returns>
		IList<BotHandler> SelectByCode ( int code );

        /// <summary>
        /// Gets the number of BotHandler with the given code
        /// </summary>
        /// <param name="id">The code</param>
        /// <returns>The count</returns>
        long CountByCode ( int code );
        
		/// <summary>
        /// Selects all BotHandler based on the code field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BotHandler collection</returns>
		IList<BotHandler> SelectByCode ( int start, int count, int code );
		
 		#endregion ExtendedMethods

	};
}
