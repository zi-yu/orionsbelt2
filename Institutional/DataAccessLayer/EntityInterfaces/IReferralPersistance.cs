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
    /// Handles persistance for Referral objects
    /// </summary>
	public interface IReferralPersistance : IPersistance<Referral> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Referral based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Referral collection</returns>
		IList<Referral> SelectById ( int id );

        /// <summary>
        /// Gets the number of Referral with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Referral based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Referral collection</returns>
		IList<Referral> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Referral based on the code field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Referral collection</returns>
		IList<Referral> SelectByCode ( int code );

        /// <summary>
        /// Gets the number of Referral with the given code
        /// </summary>
        /// <param name="id">The code</param>
        /// <returns>The count</returns>
        long CountByCode ( int code );
        
		/// <summary>
        /// Selects all Referral based on the code field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Referral collection</returns>
		IList<Referral> SelectByCode ( int start, int count, int code );
		
 		/// <summary>
        /// Selects all Referral based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Referral collection</returns>
		IList<Referral> SelectByName ( string name );

        /// <summary>
        /// Gets the number of Referral with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all Referral based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Referral collection</returns>
		IList<Referral> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all Referral based on the sourceUrl field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Referral collection</returns>
		IList<Referral> SelectBySourceUrl ( string sourceUrl );

        /// <summary>
        /// Gets the number of Referral with the given sourceUrl
        /// </summary>
        /// <param name="id">The sourceUrl</param>
        /// <returns>The count</returns>
        long CountBySourceUrl ( string sourceUrl );
        
		/// <summary>
        /// Selects all Referral based on the sourceUrl field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Referral collection</returns>
		IList<Referral> SelectBySourceUrl ( int start, int count, string sourceUrl );
		
 		/// <summary>
        /// Selects all Referral based on the filters field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Referral collection</returns>
		IList<Referral> SelectByFilters ( string filters );

        /// <summary>
        /// Gets the number of Referral with the given filters
        /// </summary>
        /// <param name="id">The filters</param>
        /// <returns>The count</returns>
        long CountByFilters ( string filters );
        
		/// <summary>
        /// Selects all Referral based on the filters field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Referral collection</returns>
		IList<Referral> SelectByFilters ( int start, int count, string filters );
		
 		#endregion ExtendedMethods

	};
}
