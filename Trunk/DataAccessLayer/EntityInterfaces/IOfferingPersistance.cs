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
    /// Handles persistance for Offering objects
    /// </summary>
	public interface IOfferingPersistance : IPersistance<Offering> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Offering based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Offering collection</returns>
		IList<Offering> SelectById ( int id );

        /// <summary>
        /// Gets the number of Offering with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Offering based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Offering collection</returns>
		IList<Offering> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Offering based on the initialValue field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Offering collection</returns>
		IList<Offering> SelectByInitialValue ( int initialValue );

        /// <summary>
        /// Gets the number of Offering with the given initialValue
        /// </summary>
        /// <param name="id">The initialValue</param>
        /// <returns>The count</returns>
        long CountByInitialValue ( int initialValue );
        
		/// <summary>
        /// Selects all Offering based on the initialValue field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Offering collection</returns>
		IList<Offering> SelectByInitialValue ( int start, int count, int initialValue );
		
 		/// <summary>
        /// Selects all Offering based on the currentValue field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Offering collection</returns>
		IList<Offering> SelectByCurrentValue ( int currentValue );

        /// <summary>
        /// Gets the number of Offering with the given currentValue
        /// </summary>
        /// <param name="id">The currentValue</param>
        /// <returns>The count</returns>
        long CountByCurrentValue ( int currentValue );
        
		/// <summary>
        /// Selects all Offering based on the currentValue field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Offering collection</returns>
		IList<Offering> SelectByCurrentValue ( int start, int count, int currentValue );
		
 		/// <summary>
        /// Selects all Offering based on the product field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Offering collection</returns>
		IList<Offering> SelectByProduct ( string product );

        /// <summary>
        /// Gets the number of Offering with the given product
        /// </summary>
        /// <param name="id">The product</param>
        /// <returns>The count</returns>
        long CountByProduct ( string product );
        
		/// <summary>
        /// Selects all Offering based on the product field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Offering collection</returns>
		IList<Offering> SelectByProduct ( int start, int count, string product );
		
 		/// <summary>
        /// Selects all Offering based on the donor field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Offering collection</returns>
		IList<Offering> SelectByDonor ( PlayerStorage donor );

        /// <summary>
        /// Gets the number of Offering with the given donor
        /// </summary>
        /// <param name="id">The donor</param>
        /// <returns>The count</returns>
        long CountByDonor ( PlayerStorage donor );
        
		/// <summary>
        /// Selects all Offering based on the donor field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Offering collection</returns>
		IList<Offering> SelectByDonor ( int start, int count, PlayerStorage donor );
		
 		/// <summary>
        /// Selects all Offering based on the receiver field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Offering collection</returns>
		IList<Offering> SelectByReceiver ( PlayerStorage receiver );

        /// <summary>
        /// Gets the number of Offering with the given receiver
        /// </summary>
        /// <param name="id">The receiver</param>
        /// <returns>The count</returns>
        long CountByReceiver ( PlayerStorage receiver );
        
		/// <summary>
        /// Selects all Offering based on the receiver field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Offering collection</returns>
		IList<Offering> SelectByReceiver ( int start, int count, PlayerStorage receiver );
		
 		/// <summary>
        /// Selects all Offering based on the alliance field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Offering collection</returns>
		IList<Offering> SelectByAlliance ( AllianceStorage alliance );

        /// <summary>
        /// Gets the number of Offering with the given alliance
        /// </summary>
        /// <param name="id">The alliance</param>
        /// <returns>The count</returns>
        long CountByAlliance ( AllianceStorage alliance );
        
		/// <summary>
        /// Selects all Offering based on the alliance field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Offering collection</returns>
		IList<Offering> SelectByAlliance ( int start, int count, AllianceStorage alliance );
		
 		#endregion ExtendedMethods

	};
}
