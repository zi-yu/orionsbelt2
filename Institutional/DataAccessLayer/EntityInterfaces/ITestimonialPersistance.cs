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
    /// Handles persistance for Testimonial objects
    /// </summary>
	public interface ITestimonialPersistance : IPersistance<Testimonial> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Testimonial based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Testimonial collection</returns>
		IList<Testimonial> SelectById ( int id );

        /// <summary>
        /// Gets the number of Testimonial with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Testimonial based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Testimonial collection</returns>
		IList<Testimonial> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Testimonial based on the locale field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Testimonial collection</returns>
		IList<Testimonial> SelectByLocale ( string locale );

        /// <summary>
        /// Gets the number of Testimonial with the given locale
        /// </summary>
        /// <param name="id">The locale</param>
        /// <returns>The count</returns>
        long CountByLocale ( string locale );
        
		/// <summary>
        /// Selects all Testimonial based on the locale field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Testimonial collection</returns>
		IList<Testimonial> SelectByLocale ( int start, int count, string locale );
		
 		/// <summary>
        /// Selects all Testimonial based on the content field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Testimonial collection</returns>
		IList<Testimonial> SelectByContent ( string content );

        /// <summary>
        /// Gets the number of Testimonial with the given content
        /// </summary>
        /// <param name="id">The content</param>
        /// <returns>The count</returns>
        long CountByContent ( string content );
        
		/// <summary>
        /// Selects all Testimonial based on the content field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Testimonial collection</returns>
		IList<Testimonial> SelectByContent ( int start, int count, string content );
		
 		/// <summary>
        /// Selects all Testimonial based on the author field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Testimonial collection</returns>
		IList<Testimonial> SelectByAuthor ( string author );

        /// <summary>
        /// Gets the number of Testimonial with the given author
        /// </summary>
        /// <param name="id">The author</param>
        /// <returns>The count</returns>
        long CountByAuthor ( string author );
        
		/// <summary>
        /// Selects all Testimonial based on the author field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Testimonial collection</returns>
		IList<Testimonial> SelectByAuthor ( int start, int count, string author );
		
 		#endregion ExtendedMethods

	};
}
