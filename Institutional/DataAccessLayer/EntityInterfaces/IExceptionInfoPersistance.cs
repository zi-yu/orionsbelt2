using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using Institutional.Core;

namespace Institutional.DataAccessLayer {
	
	/// <summary>
    /// Handles persistance for ExceptionInfo objects
    /// </summary>
	public interface IExceptionInfoPersistance : IPersistance<ExceptionInfo> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all ExceptionInfo based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ExceptionInfo collection</returns>
		IList<ExceptionInfo> SelectById ( int id );

        /// <summary>
        /// Gets the number of ExceptionInfo with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all ExceptionInfo based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ExceptionInfo collection</returns>
		IList<ExceptionInfo> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all ExceptionInfo based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ExceptionInfo collection</returns>
		IList<ExceptionInfo> SelectByName ( string name );

        /// <summary>
        /// Gets the number of ExceptionInfo with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all ExceptionInfo based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ExceptionInfo collection</returns>
		IList<ExceptionInfo> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all ExceptionInfo based on the message field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ExceptionInfo collection</returns>
		IList<ExceptionInfo> SelectByMessage ( string message );

        /// <summary>
        /// Gets the number of ExceptionInfo with the given message
        /// </summary>
        /// <param name="id">The message</param>
        /// <returns>The count</returns>
        long CountByMessage ( string message );
        
		/// <summary>
        /// Selects all ExceptionInfo based on the message field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ExceptionInfo collection</returns>
		IList<ExceptionInfo> SelectByMessage ( int start, int count, string message );
		
 		/// <summary>
        /// Selects all ExceptionInfo based on the date field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ExceptionInfo collection</returns>
		IList<ExceptionInfo> SelectByDate ( DateTime date );

        /// <summary>
        /// Gets the number of ExceptionInfo with the given date
        /// </summary>
        /// <param name="id">The date</param>
        /// <returns>The count</returns>
        long CountByDate ( DateTime date );
        
		/// <summary>
        /// Selects all ExceptionInfo based on the date field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ExceptionInfo collection</returns>
		IList<ExceptionInfo> SelectByDate ( int start, int count, DateTime date );
		
 		/// <summary>
        /// Selects all ExceptionInfo based on the principal field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ExceptionInfo collection</returns>
		IList<ExceptionInfo> SelectByPrincipal ( Principal principal );

        /// <summary>
        /// Gets the number of ExceptionInfo with the given principal
        /// </summary>
        /// <param name="id">The principal</param>
        /// <returns>The count</returns>
        long CountByPrincipal ( Principal principal );
        
		/// <summary>
        /// Selects all ExceptionInfo based on the principal field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ExceptionInfo collection</returns>
		IList<ExceptionInfo> SelectByPrincipal ( int start, int count, Principal principal );
		
 		/// <summary>
        /// Selects all ExceptionInfo based on the url field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ExceptionInfo collection</returns>
		IList<ExceptionInfo> SelectByUrl ( string url );

        /// <summary>
        /// Gets the number of ExceptionInfo with the given url
        /// </summary>
        /// <param name="id">The url</param>
        /// <returns>The count</returns>
        long CountByUrl ( string url );
        
		/// <summary>
        /// Selects all ExceptionInfo based on the url field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ExceptionInfo collection</returns>
		IList<ExceptionInfo> SelectByUrl ( int start, int count, string url );
		
 		/// <summary>
        /// Selects all ExceptionInfo based on the stackTrace field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ExceptionInfo collection</returns>
		IList<ExceptionInfo> SelectByStackTrace ( string stackTrace );

        /// <summary>
        /// Gets the number of ExceptionInfo with the given stackTrace
        /// </summary>
        /// <param name="id">The stackTrace</param>
        /// <returns>The count</returns>
        long CountByStackTrace ( string stackTrace );
        
		/// <summary>
        /// Selects all ExceptionInfo based on the stackTrace field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ExceptionInfo collection</returns>
		IList<ExceptionInfo> SelectByStackTrace ( int start, int count, string stackTrace );
		
 		#endregion ExtendedMethods

	};
}
