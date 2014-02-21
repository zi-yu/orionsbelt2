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
    /// Handles persistance for AuctionHouse objects
    /// </summary>
	public interface IAuctionHousePersistance : IPersistance<AuctionHouse> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all AuctionHouse based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectById ( int id );

        /// <summary>
        /// Gets the number of AuctionHouse with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all AuctionHouse based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all AuctionHouse based on the price field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByPrice ( int price );

        /// <summary>
        /// Gets the number of AuctionHouse with the given price
        /// </summary>
        /// <param name="id">The price</param>
        /// <returns>The count</returns>
        long CountByPrice ( int price );
        
		/// <summary>
        /// Selects all AuctionHouse based on the price field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByPrice ( int start, int count, int price );
		
 		/// <summary>
        /// Selects all AuctionHouse based on the currentBid field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByCurrentBid ( int currentBid );

        /// <summary>
        /// Gets the number of AuctionHouse with the given currentBid
        /// </summary>
        /// <param name="id">The currentBid</param>
        /// <returns>The count</returns>
        long CountByCurrentBid ( int currentBid );
        
		/// <summary>
        /// Selects all AuctionHouse based on the currentBid field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByCurrentBid ( int start, int count, int currentBid );
		
 		/// <summary>
        /// Selects all AuctionHouse based on the buyout field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByBuyout ( int buyout );

        /// <summary>
        /// Gets the number of AuctionHouse with the given buyout
        /// </summary>
        /// <param name="id">The buyout</param>
        /// <returns>The count</returns>
        long CountByBuyout ( int buyout );
        
		/// <summary>
        /// Selects all AuctionHouse based on the buyout field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByBuyout ( int start, int count, int buyout );
		
 		/// <summary>
        /// Selects all AuctionHouse based on the begin field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByBegin ( int begin );

        /// <summary>
        /// Gets the number of AuctionHouse with the given begin
        /// </summary>
        /// <param name="id">The begin</param>
        /// <returns>The count</returns>
        long CountByBegin ( int begin );
        
		/// <summary>
        /// Selects all AuctionHouse based on the begin field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByBegin ( int start, int count, int begin );
		
 		/// <summary>
        /// Selects all AuctionHouse based on the timeout field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByTimeout ( int timeout );

        /// <summary>
        /// Gets the number of AuctionHouse with the given timeout
        /// </summary>
        /// <param name="id">The timeout</param>
        /// <returns>The count</returns>
        long CountByTimeout ( int timeout );
        
		/// <summary>
        /// Selects all AuctionHouse based on the timeout field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByTimeout ( int start, int count, int timeout );
		
 		/// <summary>
        /// Selects all AuctionHouse based on the quantity field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByQuantity ( int quantity );

        /// <summary>
        /// Gets the number of AuctionHouse with the given quantity
        /// </summary>
        /// <param name="id">The quantity</param>
        /// <returns>The count</returns>
        long CountByQuantity ( int quantity );
        
		/// <summary>
        /// Selects all AuctionHouse based on the quantity field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByQuantity ( int start, int count, int quantity );
		
 		/// <summary>
        /// Selects all AuctionHouse based on the details field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByDetails ( string details );

        /// <summary>
        /// Gets the number of AuctionHouse with the given details
        /// </summary>
        /// <param name="id">The details</param>
        /// <returns>The count</returns>
        long CountByDetails ( string details );
        
		/// <summary>
        /// Selects all AuctionHouse based on the details field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByDetails ( int start, int count, string details );
		
 		/// <summary>
        /// Selects all AuctionHouse based on the complexNumber field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByComplexNumber ( int complexNumber );

        /// <summary>
        /// Gets the number of AuctionHouse with the given complexNumber
        /// </summary>
        /// <param name="id">The complexNumber</param>
        /// <returns>The count</returns>
        long CountByComplexNumber ( int complexNumber );
        
		/// <summary>
        /// Selects all AuctionHouse based on the complexNumber field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByComplexNumber ( int start, int count, int complexNumber );
		
 		/// <summary>
        /// Selects all AuctionHouse based on the higherBidOwner field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByHigherBidOwner ( int higherBidOwner );

        /// <summary>
        /// Gets the number of AuctionHouse with the given higherBidOwner
        /// </summary>
        /// <param name="id">The higherBidOwner</param>
        /// <returns>The count</returns>
        long CountByHigherBidOwner ( int higherBidOwner );
        
		/// <summary>
        /// Selects all AuctionHouse based on the higherBidOwner field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByHigherBidOwner ( int start, int count, int higherBidOwner );
		
 		/// <summary>
        /// Selects all AuctionHouse based on the buyedInTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByBuyedInTick ( int buyedInTick );

        /// <summary>
        /// Gets the number of AuctionHouse with the given buyedInTick
        /// </summary>
        /// <param name="id">The buyedInTick</param>
        /// <returns>The count</returns>
        long CountByBuyedInTick ( int buyedInTick );
        
		/// <summary>
        /// Selects all AuctionHouse based on the buyedInTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByBuyedInTick ( int start, int count, int buyedInTick );
		
 		/// <summary>
        /// Selects all AuctionHouse based on the orionsPaid field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByOrionsPaid ( int orionsPaid );

        /// <summary>
        /// Gets the number of AuctionHouse with the given orionsPaid
        /// </summary>
        /// <param name="id">The orionsPaid</param>
        /// <returns>The count</returns>
        long CountByOrionsPaid ( int orionsPaid );
        
		/// <summary>
        /// Selects all AuctionHouse based on the orionsPaid field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByOrionsPaid ( int start, int count, int orionsPaid );
		
 		/// <summary>
        /// Selects all AuctionHouse based on the advertise field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByAdvertise ( bool advertise );

        /// <summary>
        /// Gets the number of AuctionHouse with the given advertise
        /// </summary>
        /// <param name="id">The advertise</param>
        /// <returns>The count</returns>
        long CountByAdvertise ( bool advertise );
        
		/// <summary>
        /// Selects all AuctionHouse based on the advertise field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByAdvertise ( int start, int count, bool advertise );
		
 		/// <summary>
        /// Selects all AuctionHouse based on the owner field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByOwner ( PlayerStorage owner );

        /// <summary>
        /// Gets the number of AuctionHouse with the given owner
        /// </summary>
        /// <param name="id">The owner</param>
        /// <returns>The count</returns>
        long CountByOwner ( PlayerStorage owner );
        
		/// <summary>
        /// Selects all AuctionHouse based on the owner field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AuctionHouse collection</returns>
		IList<AuctionHouse> SelectByOwner ( int start, int count, PlayerStorage owner );
		
 		#endregion ExtendedMethods

	};
}
