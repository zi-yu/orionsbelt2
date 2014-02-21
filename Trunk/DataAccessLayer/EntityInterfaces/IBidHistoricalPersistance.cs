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
    /// Handles persistance for BidHistorical objects
    /// </summary>
	public interface IBidHistoricalPersistance : IPersistance<BidHistorical> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all BidHistorical based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BidHistorical collection</returns>
		IList<BidHistorical> SelectById ( int id );

        /// <summary>
        /// Gets the number of BidHistorical with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all BidHistorical based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BidHistorical collection</returns>
		IList<BidHistorical> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all BidHistorical based on the value field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BidHistorical collection</returns>
		IList<BidHistorical> SelectByValue ( int value );

        /// <summary>
        /// Gets the number of BidHistorical with the given value
        /// </summary>
        /// <param name="id">The value</param>
        /// <returns>The count</returns>
        long CountByValue ( int value );
        
		/// <summary>
        /// Selects all BidHistorical based on the value field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BidHistorical collection</returns>
		IList<BidHistorical> SelectByValue ( int start, int count, int value );
		
 		/// <summary>
        /// Selects all BidHistorical based on the date field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BidHistorical collection</returns>
		IList<BidHistorical> SelectByDate ( DateTime date );

        /// <summary>
        /// Gets the number of BidHistorical with the given date
        /// </summary>
        /// <param name="id">The date</param>
        /// <returns>The count</returns>
        long CountByDate ( DateTime date );
        
		/// <summary>
        /// Selects all BidHistorical based on the date field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BidHistorical collection</returns>
		IList<BidHistorical> SelectByDate ( int start, int count, DateTime date );
		
 		/// <summary>
        /// Selects all BidHistorical based on the resource field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BidHistorical collection</returns>
		IList<BidHistorical> SelectByResource ( AuctionHouse resource );

        /// <summary>
        /// Gets the number of BidHistorical with the given resource
        /// </summary>
        /// <param name="id">The resource</param>
        /// <returns>The count</returns>
        long CountByResource ( AuctionHouse resource );
        
		/// <summary>
        /// Selects all BidHistorical based on the resource field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BidHistorical collection</returns>
		IList<BidHistorical> SelectByResource ( int start, int count, AuctionHouse resource );
		
 		/// <summary>
        /// Selects all BidHistorical based on the madeBy field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BidHistorical collection</returns>
		IList<BidHistorical> SelectByMadeBy ( PlayerStorage madeBy );

        /// <summary>
        /// Gets the number of BidHistorical with the given madeBy
        /// </summary>
        /// <param name="id">The madeBy</param>
        /// <returns>The count</returns>
        long CountByMadeBy ( PlayerStorage madeBy );
        
		/// <summary>
        /// Selects all BidHistorical based on the madeBy field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BidHistorical collection</returns>
		IList<BidHistorical> SelectByMadeBy ( int start, int count, PlayerStorage madeBy );
		
 		#endregion ExtendedMethods

	};
}
