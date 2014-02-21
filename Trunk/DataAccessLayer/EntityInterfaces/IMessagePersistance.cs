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
    /// Handles persistance for Message objects
    /// </summary>
	public interface IMessagePersistance : IPersistance<Message> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Message based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectById ( int id );

        /// <summary>
        /// Gets the number of Message with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Message based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Message based on the parameters field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectByParameters ( string parameters );

        /// <summary>
        /// Gets the number of Message with the given parameters
        /// </summary>
        /// <param name="id">The parameters</param>
        /// <returns>The count</returns>
        long CountByParameters ( string parameters );
        
		/// <summary>
        /// Selects all Message based on the parameters field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectByParameters ( int start, int count, string parameters );
		
 		/// <summary>
        /// Selects all Message based on the category field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectByCategory ( string category );

        /// <summary>
        /// Gets the number of Message with the given category
        /// </summary>
        /// <param name="id">The category</param>
        /// <returns>The count</returns>
        long CountByCategory ( string category );
        
		/// <summary>
        /// Selects all Message based on the category field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectByCategory ( int start, int count, string category );
		
 		/// <summary>
        /// Selects all Message based on the subCategory field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectBySubCategory ( string subCategory );

        /// <summary>
        /// Gets the number of Message with the given subCategory
        /// </summary>
        /// <param name="id">The subCategory</param>
        /// <returns>The count</returns>
        long CountBySubCategory ( string subCategory );
        
		/// <summary>
        /// Selects all Message based on the subCategory field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectBySubCategory ( int start, int count, string subCategory );
		
 		/// <summary>
        /// Selects all Message based on the ownerId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectByOwnerId ( int ownerId );

        /// <summary>
        /// Gets the number of Message with the given ownerId
        /// </summary>
        /// <param name="id">The ownerId</param>
        /// <returns>The count</returns>
        long CountByOwnerId ( int ownerId );
        
		/// <summary>
        /// Selects all Message based on the ownerId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectByOwnerId ( int start, int count, int ownerId );
		
 		/// <summary>
        /// Selects all Message based on the date field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectByDate ( DateTime date );

        /// <summary>
        /// Gets the number of Message with the given date
        /// </summary>
        /// <param name="id">The date</param>
        /// <returns>The count</returns>
        long CountByDate ( DateTime date );
        
		/// <summary>
        /// Selects all Message based on the date field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectByDate ( int start, int count, DateTime date );
		
 		/// <summary>
        /// Selects all Message based on the extended field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectByExtended ( string extended );

        /// <summary>
        /// Gets the number of Message with the given extended
        /// </summary>
        /// <param name="id">The extended</param>
        /// <returns>The count</returns>
        long CountByExtended ( string extended );
        
		/// <summary>
        /// Selects all Message based on the extended field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectByExtended ( int start, int count, string extended );
		
 		/// <summary>
        /// Selects all Message based on the tickDeadline field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectByTickDeadline ( int tickDeadline );

        /// <summary>
        /// Gets the number of Message with the given tickDeadline
        /// </summary>
        /// <param name="id">The tickDeadline</param>
        /// <returns>The count</returns>
        long CountByTickDeadline ( int tickDeadline );
        
		/// <summary>
        /// Selects all Message based on the tickDeadline field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Message collection</returns>
		IList<Message> SelectByTickDeadline ( int start, int count, int tickDeadline );
		
 		#endregion ExtendedMethods

	};
}
