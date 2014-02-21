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
    /// Handles persistance for SpecialEvent objects
    /// </summary>
	public interface ISpecialEventPersistance : IPersistance<SpecialEvent> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all SpecialEvent based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SpecialEvent collection</returns>
		IList<SpecialEvent> SelectById ( int id );

        /// <summary>
        /// Gets the number of SpecialEvent with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all SpecialEvent based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SpecialEvent collection</returns>
		IList<SpecialEvent> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all SpecialEvent based on the cost field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SpecialEvent collection</returns>
		IList<SpecialEvent> SelectByCost ( int cost );

        /// <summary>
        /// Gets the number of SpecialEvent with the given cost
        /// </summary>
        /// <param name="id">The cost</param>
        /// <returns>The count</returns>
        long CountByCost ( int cost );
        
		/// <summary>
        /// Selects all SpecialEvent based on the cost field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SpecialEvent collection</returns>
		IList<SpecialEvent> SelectByCost ( int start, int count, int cost );
		
 		/// <summary>
        /// Selects all SpecialEvent based on the token field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SpecialEvent collection</returns>
		IList<SpecialEvent> SelectByToken ( string token );

        /// <summary>
        /// Gets the number of SpecialEvent with the given token
        /// </summary>
        /// <param name="id">The token</param>
        /// <returns>The count</returns>
        long CountByToken ( string token );
        
		/// <summary>
        /// Selects all SpecialEvent based on the token field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SpecialEvent collection</returns>
		IList<SpecialEvent> SelectByToken ( int start, int count, string token );
		
 		/// <summary>
        /// Selects all SpecialEvent based on the resorces field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SpecialEvent collection</returns>
		IList<SpecialEvent> SelectByResorces ( string resorces );

        /// <summary>
        /// Gets the number of SpecialEvent with the given resorces
        /// </summary>
        /// <param name="id">The resorces</param>
        /// <returns>The count</returns>
        long CountByResorces ( string resorces );
        
		/// <summary>
        /// Selects all SpecialEvent based on the resorces field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SpecialEvent collection</returns>
		IList<SpecialEvent> SelectByResorces ( int start, int count, string resorces );
		
 		/// <summary>
        /// Selects all SpecialEvent based on the beginDate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SpecialEvent collection</returns>
		IList<SpecialEvent> SelectByBeginDate ( DateTime beginDate );

        /// <summary>
        /// Gets the number of SpecialEvent with the given beginDate
        /// </summary>
        /// <param name="id">The beginDate</param>
        /// <returns>The count</returns>
        long CountByBeginDate ( DateTime beginDate );
        
		/// <summary>
        /// Selects all SpecialEvent based on the beginDate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SpecialEvent collection</returns>
		IList<SpecialEvent> SelectByBeginDate ( int start, int count, DateTime beginDate );
		
 		/// <summary>
        /// Selects all SpecialEvent based on the endDate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SpecialEvent collection</returns>
		IList<SpecialEvent> SelectByEndDate ( DateTime endDate );

        /// <summary>
        /// Gets the number of SpecialEvent with the given endDate
        /// </summary>
        /// <param name="id">The endDate</param>
        /// <returns>The count</returns>
        long CountByEndDate ( DateTime endDate );
        
		/// <summary>
        /// Selects all SpecialEvent based on the endDate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SpecialEvent collection</returns>
		IList<SpecialEvent> SelectByEndDate ( int start, int count, DateTime endDate );
		
 		#endregion ExtendedMethods

	};
}
