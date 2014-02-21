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
    /// Handles persistance for BotCredential objects
    /// </summary>
	public interface IBotCredentialPersistance : IPersistance<BotCredential> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all BotCredential based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BotCredential collection</returns>
		IList<BotCredential> SelectById ( int id );

        /// <summary>
        /// Gets the number of BotCredential with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all BotCredential based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BotCredential collection</returns>
		IList<BotCredential> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all BotCredential based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BotCredential collection</returns>
		IList<BotCredential> SelectByName ( string name );

        /// <summary>
        /// Gets the number of BotCredential with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all BotCredential based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BotCredential collection</returns>
		IList<BotCredential> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all BotCredential based on the server field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BotCredential collection</returns>
		IList<BotCredential> SelectByServer ( string server );

        /// <summary>
        /// Gets the number of BotCredential with the given server
        /// </summary>
        /// <param name="id">The server</param>
        /// <returns>The count</returns>
        long CountByServer ( string server );
        
		/// <summary>
        /// Selects all BotCredential based on the server field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BotCredential collection</returns>
		IList<BotCredential> SelectByServer ( int start, int count, string server );
		
 		/// <summary>
        /// Selects all BotCredential based on the verificationCode field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BotCredential collection</returns>
		IList<BotCredential> SelectByVerificationCode ( string verificationCode );

        /// <summary>
        /// Gets the number of BotCredential with the given verificationCode
        /// </summary>
        /// <param name="id">The verificationCode</param>
        /// <returns>The count</returns>
        long CountByVerificationCode ( string verificationCode );
        
		/// <summary>
        /// Selects all BotCredential based on the verificationCode field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BotCredential collection</returns>
		IList<BotCredential> SelectByVerificationCode ( int start, int count, string verificationCode );
		
 		/// <summary>
        /// Selects all BotCredential based on the botId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BotCredential collection</returns>
		IList<BotCredential> SelectByBotId ( int botId );

        /// <summary>
        /// Gets the number of BotCredential with the given botId
        /// </summary>
        /// <param name="id">The botId</param>
        /// <returns>The count</returns>
        long CountByBotId ( int botId );
        
		/// <summary>
        /// Selects all BotCredential based on the botId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BotCredential collection</returns>
		IList<BotCredential> SelectByBotId ( int start, int count, int botId );
		
 		#endregion ExtendedMethods

	};
}
