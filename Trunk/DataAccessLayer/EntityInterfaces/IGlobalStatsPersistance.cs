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
    /// Handles persistance for GlobalStats objects
    /// </summary>
	public interface IGlobalStatsPersistance : IPersistance<GlobalStats> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all GlobalStats based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The GlobalStats collection</returns>
		IList<GlobalStats> SelectById ( int id );

        /// <summary>
        /// Gets the number of GlobalStats with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all GlobalStats based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The GlobalStats collection</returns>
		IList<GlobalStats> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all GlobalStats based on the type field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The GlobalStats collection</returns>
		IList<GlobalStats> SelectByType ( string type );

        /// <summary>
        /// Gets the number of GlobalStats with the given type
        /// </summary>
        /// <param name="id">The type</param>
        /// <returns>The count</returns>
        long CountByType ( string type );
        
		/// <summary>
        /// Selects all GlobalStats based on the type field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The GlobalStats collection</returns>
		IList<GlobalStats> SelectByType ( int start, int count, string type );
		
 		/// <summary>
        /// Selects all GlobalStats based on the tick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The GlobalStats collection</returns>
		IList<GlobalStats> SelectByTick ( int tick );

        /// <summary>
        /// Gets the number of GlobalStats with the given tick
        /// </summary>
        /// <param name="id">The tick</param>
        /// <returns>The count</returns>
        long CountByTick ( int tick );
        
		/// <summary>
        /// Selects all GlobalStats based on the tick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The GlobalStats collection</returns>
		IList<GlobalStats> SelectByTick ( int start, int count, int tick );
		
 		/// <summary>
        /// Selects all GlobalStats based on the text field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The GlobalStats collection</returns>
		IList<GlobalStats> SelectByText ( string text );

        /// <summary>
        /// Gets the number of GlobalStats with the given text
        /// </summary>
        /// <param name="id">The text</param>
        /// <returns>The count</returns>
        long CountByText ( string text );
        
		/// <summary>
        /// Selects all GlobalStats based on the text field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The GlobalStats collection</returns>
		IList<GlobalStats> SelectByText ( int start, int count, string text );
		
 		/// <summary>
        /// Selects all GlobalStats based on the number field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The GlobalStats collection</returns>
		IList<GlobalStats> SelectByNumber ( double number );

        /// <summary>
        /// Gets the number of GlobalStats with the given number
        /// </summary>
        /// <param name="id">The number</param>
        /// <returns>The count</returns>
        long CountByNumber ( double number );
        
		/// <summary>
        /// Selects all GlobalStats based on the number field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The GlobalStats collection</returns>
		IList<GlobalStats> SelectByNumber ( int start, int count, double number );
		
 		#endregion ExtendedMethods

	};
}
