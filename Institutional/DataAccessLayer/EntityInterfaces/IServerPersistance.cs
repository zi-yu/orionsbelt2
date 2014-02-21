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
    /// Handles persistance for Server objects
    /// </summary>
	public interface IServerPersistance : IPersistance<Server> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Server based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Server collection</returns>
		IList<Server> SelectById ( int id );

        /// <summary>
        /// Gets the number of Server with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Server based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Server collection</returns>
		IList<Server> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Server based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Server collection</returns>
		IList<Server> SelectByName ( string name );

        /// <summary>
        /// Gets the number of Server with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all Server based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Server collection</returns>
		IList<Server> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all Server based on the url field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Server collection</returns>
		IList<Server> SelectByUrl ( string url );

        /// <summary>
        /// Gets the number of Server with the given url
        /// </summary>
        /// <param name="id">The url</param>
        /// <returns>The count</returns>
        long CountByUrl ( string url );
        
		/// <summary>
        /// Selects all Server based on the url field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Server collection</returns>
		IList<Server> SelectByUrl ( int start, int count, string url );
		
 		#endregion ExtendedMethods

	};
}
