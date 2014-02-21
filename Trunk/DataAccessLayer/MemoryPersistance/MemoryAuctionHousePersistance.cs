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
    /// Memory persistance for entity.Name
    /// </summary>
	internal class MemoryAuctionHousePersistance : 
			MemoryPersistance<AuctionHouse>, IAuctionHousePersistance {
		
		#region IPersistance
		
		public override AuctionHouse Create()
		{
			return new SpecializedMemoryAuctionHouse ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<AuctionHouse> SelectById ( int id )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountById ( int id )
		{
			return (long) SelectById ( id ).Count;
		}

		public IList<AuctionHouse> SelectById ( int start, int count, int id )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByPrice ( int price )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Price == price ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPrice ( int price )
		{
			return (long) SelectByPrice ( price ).Count;
		}

		public IList<AuctionHouse> SelectByPrice ( int start, int count, int price )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Price == price ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByCurrentBid ( int currentBid )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.CurrentBid == currentBid ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCurrentBid ( int currentBid )
		{
			return (long) SelectByCurrentBid ( currentBid ).Count;
		}

		public IList<AuctionHouse> SelectByCurrentBid ( int start, int count, int currentBid )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.CurrentBid == currentBid ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByBuyout ( int buyout )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Buyout == buyout ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBuyout ( int buyout )
		{
			return (long) SelectByBuyout ( buyout ).Count;
		}

		public IList<AuctionHouse> SelectByBuyout ( int start, int count, int buyout )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Buyout == buyout ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByBegin ( int begin )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Begin == begin ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBegin ( int begin )
		{
			return (long) SelectByBegin ( begin ).Count;
		}

		public IList<AuctionHouse> SelectByBegin ( int start, int count, int begin )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Begin == begin ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByTimeout ( int timeout )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Timeout == timeout ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTimeout ( int timeout )
		{
			return (long) SelectByTimeout ( timeout ).Count;
		}

		public IList<AuctionHouse> SelectByTimeout ( int start, int count, int timeout )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Timeout == timeout ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByQuantity ( int quantity )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Quantity == quantity ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByQuantity ( int quantity )
		{
			return (long) SelectByQuantity ( quantity ).Count;
		}

		public IList<AuctionHouse> SelectByQuantity ( int start, int count, int quantity )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Quantity == quantity ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByDetails ( string details )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Details == details ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByDetails ( string details )
		{
			return (long) SelectByDetails ( details ).Count;
		}

		public IList<AuctionHouse> SelectByDetails ( int start, int count, string details )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Details == details ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByComplexNumber ( int complexNumber )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.ComplexNumber == complexNumber ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByComplexNumber ( int complexNumber )
		{
			return (long) SelectByComplexNumber ( complexNumber ).Count;
		}

		public IList<AuctionHouse> SelectByComplexNumber ( int start, int count, int complexNumber )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.ComplexNumber == complexNumber ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByHigherBidOwner ( int higherBidOwner )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.HigherBidOwner == higherBidOwner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByHigherBidOwner ( int higherBidOwner )
		{
			return (long) SelectByHigherBidOwner ( higherBidOwner ).Count;
		}

		public IList<AuctionHouse> SelectByHigherBidOwner ( int start, int count, int higherBidOwner )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.HigherBidOwner == higherBidOwner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByBuyedInTick ( int buyedInTick )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.BuyedInTick == buyedInTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBuyedInTick ( int buyedInTick )
		{
			return (long) SelectByBuyedInTick ( buyedInTick ).Count;
		}

		public IList<AuctionHouse> SelectByBuyedInTick ( int start, int count, int buyedInTick )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.BuyedInTick == buyedInTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByOrionsPaid ( int orionsPaid )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.OrionsPaid == orionsPaid ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByOrionsPaid ( int orionsPaid )
		{
			return (long) SelectByOrionsPaid ( orionsPaid ).Count;
		}

		public IList<AuctionHouse> SelectByOrionsPaid ( int start, int count, int orionsPaid )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.OrionsPaid == orionsPaid ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByAdvertise ( bool advertise )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Advertise == advertise ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAdvertise ( bool advertise )
		{
			return (long) SelectByAdvertise ( advertise ).Count;
		}

		public IList<AuctionHouse> SelectByAdvertise ( int start, int count, bool advertise )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Advertise == advertise ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByOwner ( PlayerStorage owner )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Owner == owner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByOwner ( PlayerStorage owner )
		{
			return (long) SelectByOwner ( owner ).Count;
		}

		public IList<AuctionHouse> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.Owner == owner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByCreatedDate ( DateTime createdDate )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCreatedDate ( DateTime createdDate )
		{
			return (long) SelectByCreatedDate ( createdDate ).Count;
		}

		public IList<AuctionHouse> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUpdatedDate ( DateTime updatedDate )
		{
			return (long) SelectByUpdatedDate ( updatedDate ).Count;
		}

		public IList<AuctionHouse> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AuctionHouse> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLastActionUserId ( int lastActionUserId )
		{
			return (long) SelectByLastActionUserId ( lastActionUserId ).Count;
		}

		public IList<AuctionHouse> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<AuctionHouse> container = new List<AuctionHouse>();
 			
			foreach( AuctionHouse obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
