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
	internal class MemoryProductPersistance : 
			MemoryPersistance<Product>, IProductPersistance {
		
		#region IPersistance
		
		public override Product Create()
		{
			return new SpecializedMemoryProduct ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Product> SelectById ( int id )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
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

		public IList<Product> SelectById ( int start, int count, int id )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Product> SelectByName ( string name )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByName ( string name )
		{
			return (long) SelectByName ( name ).Count;
		}

		public IList<Product> SelectByName ( int start, int count, string name )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Product> SelectByPrice ( int price )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
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

		public IList<Product> SelectByPrice ( int start, int count, int price )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
 				if( obj.Price == price ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Product> SelectByType ( string type )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByType ( string type )
		{
			return (long) SelectByType ( type ).Count;
		}

		public IList<Product> SelectByType ( int start, int count, string type )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Product> SelectByQuantity ( int quantity )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
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

		public IList<Product> SelectByQuantity ( int start, int count, int quantity )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
 				if( obj.Quantity == quantity ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Product> SelectByMarket ( Market market )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
 				if( obj.Market == market ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMarket ( Market market )
		{
			return (long) SelectByMarket ( market ).Count;
		}

		public IList<Product> SelectByMarket ( int start, int count, Market market )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
 				if( obj.Market == market ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Product> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
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

		public IList<Product> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Product> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
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

		public IList<Product> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Product> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
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

		public IList<Product> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Product> container = new List<Product>();
 			
			foreach( Product obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
