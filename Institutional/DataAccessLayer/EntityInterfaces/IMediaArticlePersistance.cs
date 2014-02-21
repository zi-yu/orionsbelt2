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
    /// Handles persistance for MediaArticle objects
    /// </summary>
	public interface IMediaArticlePersistance : IPersistance<MediaArticle> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all MediaArticle based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The MediaArticle collection</returns>
		IList<MediaArticle> SelectById ( int id );

        /// <summary>
        /// Gets the number of MediaArticle with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all MediaArticle based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The MediaArticle collection</returns>
		IList<MediaArticle> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all MediaArticle based on the url field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The MediaArticle collection</returns>
		IList<MediaArticle> SelectByUrl ( string url );

        /// <summary>
        /// Gets the number of MediaArticle with the given url
        /// </summary>
        /// <param name="id">The url</param>
        /// <returns>The count</returns>
        long CountByUrl ( string url );
        
		/// <summary>
        /// Selects all MediaArticle based on the url field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The MediaArticle collection</returns>
		IList<MediaArticle> SelectByUrl ( int start, int count, string url );
		
 		/// <summary>
        /// Selects all MediaArticle based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The MediaArticle collection</returns>
		IList<MediaArticle> SelectByName ( string name );

        /// <summary>
        /// Gets the number of MediaArticle with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all MediaArticle based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The MediaArticle collection</returns>
		IList<MediaArticle> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all MediaArticle based on the locale field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The MediaArticle collection</returns>
		IList<MediaArticle> SelectByLocale ( string locale );

        /// <summary>
        /// Gets the number of MediaArticle with the given locale
        /// </summary>
        /// <param name="id">The locale</param>
        /// <returns>The count</returns>
        long CountByLocale ( string locale );
        
		/// <summary>
        /// Selects all MediaArticle based on the locale field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The MediaArticle collection</returns>
		IList<MediaArticle> SelectByLocale ( int start, int count, string locale );
		
 		/// <summary>
        /// Selects all MediaArticle based on the exceprt field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The MediaArticle collection</returns>
		IList<MediaArticle> SelectByExceprt ( string exceprt );

        /// <summary>
        /// Gets the number of MediaArticle with the given exceprt
        /// </summary>
        /// <param name="id">The exceprt</param>
        /// <returns>The count</returns>
        long CountByExceprt ( string exceprt );
        
		/// <summary>
        /// Selects all MediaArticle based on the exceprt field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The MediaArticle collection</returns>
		IList<MediaArticle> SelectByExceprt ( int start, int count, string exceprt );
		
 		#endregion ExtendedMethods

	};
}
