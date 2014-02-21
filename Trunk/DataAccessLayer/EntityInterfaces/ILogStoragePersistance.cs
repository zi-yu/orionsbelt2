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
    /// Handles persistance for LogStorage objects
    /// </summary>
	public interface ILogStoragePersistance : IPersistance<LogStorage> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all LogStorage based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectById ( int id );

        /// <summary>
        /// Gets the number of LogStorage with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all LogStorage based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all LogStorage based on the date field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByDate ( DateTime date );

        /// <summary>
        /// Gets the number of LogStorage with the given date
        /// </summary>
        /// <param name="id">The date</param>
        /// <returns>The count</returns>
        long CountByDate ( DateTime date );
        
		/// <summary>
        /// Selects all LogStorage based on the date field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByDate ( int start, int count, DateTime date );
		
 		/// <summary>
        /// Selects all LogStorage based on the username1 field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByUsername1 ( string username1 );

        /// <summary>
        /// Gets the number of LogStorage with the given username1
        /// </summary>
        /// <param name="id">The username1</param>
        /// <returns>The count</returns>
        long CountByUsername1 ( string username1 );
        
		/// <summary>
        /// Selects all LogStorage based on the username1 field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByUsername1 ( int start, int count, string username1 );
		
 		/// <summary>
        /// Selects all LogStorage based on the level field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByLevel ( string level );

        /// <summary>
        /// Gets the number of LogStorage with the given level
        /// </summary>
        /// <param name="id">The level</param>
        /// <returns>The count</returns>
        long CountByLevel ( string level );
        
		/// <summary>
        /// Selects all LogStorage based on the level field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByLevel ( int start, int count, string level );
		
 		/// <summary>
        /// Selects all LogStorage based on the url field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByUrl ( string url );

        /// <summary>
        /// Gets the number of LogStorage with the given url
        /// </summary>
        /// <param name="id">The url</param>
        /// <returns>The count</returns>
        long CountByUrl ( string url );
        
		/// <summary>
        /// Selects all LogStorage based on the url field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByUrl ( int start, int count, string url );
		
 		/// <summary>
        /// Selects all LogStorage based on the content field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByContent ( string content );

        /// <summary>
        /// Gets the number of LogStorage with the given content
        /// </summary>
        /// <param name="id">The content</param>
        /// <returns>The count</returns>
        long CountByContent ( string content );
        
		/// <summary>
        /// Selects all LogStorage based on the content field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByContent ( int start, int count, string content );
		
 		/// <summary>
        /// Selects all LogStorage based on the exceptionInformation field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByExceptionInformation ( string exceptionInformation );

        /// <summary>
        /// Gets the number of LogStorage with the given exceptionInformation
        /// </summary>
        /// <param name="id">The exceptionInformation</param>
        /// <returns>The count</returns>
        long CountByExceptionInformation ( string exceptionInformation );
        
		/// <summary>
        /// Selects all LogStorage based on the exceptionInformation field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByExceptionInformation ( int start, int count, string exceptionInformation );
		
 		/// <summary>
        /// Selects all LogStorage based on the ip field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByIp ( string ip );

        /// <summary>
        /// Gets the number of LogStorage with the given ip
        /// </summary>
        /// <param name="id">The ip</param>
        /// <returns>The count</returns>
        long CountByIp ( string ip );
        
		/// <summary>
        /// Selects all LogStorage based on the ip field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByIp ( int start, int count, string ip );
		
 		/// <summary>
        /// Selects all LogStorage based on the type field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByType ( string type );

        /// <summary>
        /// Gets the number of LogStorage with the given type
        /// </summary>
        /// <param name="id">The type</param>
        /// <returns>The count</returns>
        long CountByType ( string type );
        
		/// <summary>
        /// Selects all LogStorage based on the type field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByType ( int start, int count, string type );
		
 		/// <summary>
        /// Selects all LogStorage based on the username2 field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByUsername2 ( string username2 );

        /// <summary>
        /// Gets the number of LogStorage with the given username2
        /// </summary>
        /// <param name="id">The username2</param>
        /// <returns>The count</returns>
        long CountByUsername2 ( string username2 );
        
		/// <summary>
        /// Selects all LogStorage based on the username2 field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The LogStorage collection</returns>
		IList<LogStorage> SelectByUsername2 ( int start, int count, string username2 );
		
 		#endregion ExtendedMethods

	};
}
