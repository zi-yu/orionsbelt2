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
    /// Handles persistance for DuplicateDetection objects
    /// </summary>
	public interface IDuplicateDetectionPersistance : IPersistance<DuplicateDetection> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all DuplicateDetection based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The DuplicateDetection collection</returns>
		IList<DuplicateDetection> SelectById ( int id );

        /// <summary>
        /// Gets the number of DuplicateDetection with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all DuplicateDetection based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The DuplicateDetection collection</returns>
		IList<DuplicateDetection> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all DuplicateDetection based on the cheater field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The DuplicateDetection collection</returns>
		IList<DuplicateDetection> SelectByCheater ( int cheater );

        /// <summary>
        /// Gets the number of DuplicateDetection with the given cheater
        /// </summary>
        /// <param name="id">The cheater</param>
        /// <returns>The count</returns>
        long CountByCheater ( int cheater );
        
		/// <summary>
        /// Selects all DuplicateDetection based on the cheater field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The DuplicateDetection collection</returns>
		IList<DuplicateDetection> SelectByCheater ( int start, int count, int cheater );
		
 		/// <summary>
        /// Selects all DuplicateDetection based on the duplicate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The DuplicateDetection collection</returns>
		IList<DuplicateDetection> SelectByDuplicate ( int duplicate );

        /// <summary>
        /// Gets the number of DuplicateDetection with the given duplicate
        /// </summary>
        /// <param name="id">The duplicate</param>
        /// <returns>The count</returns>
        long CountByDuplicate ( int duplicate );
        
		/// <summary>
        /// Selects all DuplicateDetection based on the duplicate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The DuplicateDetection collection</returns>
		IList<DuplicateDetection> SelectByDuplicate ( int start, int count, int duplicate );
		
 		/// <summary>
        /// Selects all DuplicateDetection based on the findType field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The DuplicateDetection collection</returns>
		IList<DuplicateDetection> SelectByFindType ( string findType );

        /// <summary>
        /// Gets the number of DuplicateDetection with the given findType
        /// </summary>
        /// <param name="id">The findType</param>
        /// <returns>The count</returns>
        long CountByFindType ( string findType );
        
		/// <summary>
        /// Selects all DuplicateDetection based on the findType field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The DuplicateDetection collection</returns>
		IList<DuplicateDetection> SelectByFindType ( int start, int count, string findType );
		
 		/// <summary>
        /// Selects all DuplicateDetection based on the extraInfo field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The DuplicateDetection collection</returns>
		IList<DuplicateDetection> SelectByExtraInfo ( string extraInfo );

        /// <summary>
        /// Gets the number of DuplicateDetection with the given extraInfo
        /// </summary>
        /// <param name="id">The extraInfo</param>
        /// <returns>The count</returns>
        long CountByExtraInfo ( string extraInfo );
        
		/// <summary>
        /// Selects all DuplicateDetection based on the extraInfo field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The DuplicateDetection collection</returns>
		IList<DuplicateDetection> SelectByExtraInfo ( int start, int count, string extraInfo );
		
 		/// <summary>
        /// Selects all DuplicateDetection based on the verified field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The DuplicateDetection collection</returns>
		IList<DuplicateDetection> SelectByVerified ( bool verified );

        /// <summary>
        /// Gets the number of DuplicateDetection with the given verified
        /// </summary>
        /// <param name="id">The verified</param>
        /// <returns>The count</returns>
        long CountByVerified ( bool verified );
        
		/// <summary>
        /// Selects all DuplicateDetection based on the verified field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The DuplicateDetection collection</returns>
		IList<DuplicateDetection> SelectByVerified ( int start, int count, bool verified );
		
 		#endregion ExtendedMethods

	};
}
