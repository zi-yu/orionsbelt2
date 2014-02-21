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
	internal class MemoryInvoicePersistance : 
			MemoryPersistance<Invoice>, IInvoicePersistance {
		
		#region IPersistance
		
		public override Invoice Create()
		{
			return new SpecializedMemoryInvoice ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Invoice> SelectById ( int id )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
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

		public IList<Invoice> SelectById ( int start, int count, int id )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Invoice> SelectByIdentifier ( string identifier )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.Identifier == identifier ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIdentifier ( string identifier )
		{
			return (long) SelectByIdentifier ( identifier ).Count;
		}

		public IList<Invoice> SelectByIdentifier ( int start, int count, string identifier )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.Identifier == identifier ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Invoice> SelectByName ( string name )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
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

		public IList<Invoice> SelectByName ( int start, int count, string name )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Invoice> SelectByNif ( string nif )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.Nif == nif ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByNif ( string nif )
		{
			return (long) SelectByNif ( nif ).Count;
		}

		public IList<Invoice> SelectByNif ( int start, int count, string nif )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.Nif == nif ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Invoice> SelectByMoney ( double money )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.Money == money ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMoney ( double money )
		{
			return (long) SelectByMoney ( money ).Count;
		}

		public IList<Invoice> SelectByMoney ( int start, int count, double money )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.Money == money ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Invoice> SelectByCountry ( string country )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.Country == country ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCountry ( string country )
		{
			return (long) SelectByCountry ( country ).Count;
		}

		public IList<Invoice> SelectByCountry ( int start, int count, string country )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.Country == country ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Invoice> SelectByTransaction ( Transaction transaction )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.Transaction == transaction ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTransaction ( Transaction transaction )
		{
			return (long) SelectByTransaction ( transaction ).Count;
		}

		public IList<Invoice> SelectByTransaction ( int start, int count, Transaction transaction )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.Transaction == transaction ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Invoice> SelectByPayment ( Payment payment )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.Payment == payment ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPayment ( Payment payment )
		{
			return (long) SelectByPayment ( payment ).Count;
		}

		public IList<Invoice> SelectByPayment ( int start, int count, Payment payment )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.Payment == payment ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Invoice> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
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

		public IList<Invoice> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Invoice> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
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

		public IList<Invoice> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Invoice> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
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

		public IList<Invoice> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Invoice> container = new List<Invoice>();
 			
			foreach( Invoice obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
