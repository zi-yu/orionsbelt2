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
	internal class MemoryBidHistoricalPersistance : 
			MemoryPersistance<BidHistorical>, IBidHistoricalPersistance {
		
		#region IPersistance
		
		public override BidHistorical Create()
		{
			return new SpecializedMemoryBidHistorical ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<BidHistorical> SelectById ( int id )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
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

		public IList<BidHistorical> SelectById ( int start, int count, int id )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BidHistorical> SelectByValue ( int value )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
 				if( obj.Value == value ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByValue ( int value )
		{
			return (long) SelectByValue ( value ).Count;
		}

		public IList<BidHistorical> SelectByValue ( int start, int count, int value )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
 				if( obj.Value == value ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BidHistorical> SelectByDate ( DateTime date )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
 				if( obj.Date == date ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByDate ( DateTime date )
		{
			return (long) SelectByDate ( date ).Count;
		}

		public IList<BidHistorical> SelectByDate ( int start, int count, DateTime date )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
 				if( obj.Date == date ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BidHistorical> SelectByResource ( AuctionHouse resource )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
 				if( obj.Resource == resource ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByResource ( AuctionHouse resource )
		{
			return (long) SelectByResource ( resource ).Count;
		}

		public IList<BidHistorical> SelectByResource ( int start, int count, AuctionHouse resource )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
 				if( obj.Resource == resource ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BidHistorical> SelectByMadeBy ( PlayerStorage madeBy )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
 				if( obj.MadeBy == madeBy ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMadeBy ( PlayerStorage madeBy )
		{
			return (long) SelectByMadeBy ( madeBy ).Count;
		}

		public IList<BidHistorical> SelectByMadeBy ( int start, int count, PlayerStorage madeBy )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
 				if( obj.MadeBy == madeBy ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BidHistorical> SelectByCreatedDate ( DateTime createdDate )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
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

		public IList<BidHistorical> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BidHistorical> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
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

		public IList<BidHistorical> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BidHistorical> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
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

		public IList<BidHistorical> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<BidHistorical> container = new List<BidHistorical>();
 			
			foreach( BidHistorical obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
