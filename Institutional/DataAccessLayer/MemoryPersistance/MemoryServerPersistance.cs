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
    /// Memory persistance for entity.Name
    /// </summary>
	internal class MemoryServerPersistance : 
			MemoryPersistance<Server>, IServerPersistance {
		
		#region IPersistance
		
		public override Server Create()
		{
			return new SpecializedMemoryServer ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Server> SelectById ( int id )
		{
			List<Server> container = new List<Server>();
 			
			foreach( Server obj in Database.Values) {
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

		public IList<Server> SelectById ( int start, int count, int id )
		{
			List<Server> container = new List<Server>();
 			
			foreach( Server obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Server> SelectByName ( string name )
		{
			List<Server> container = new List<Server>();
 			
			foreach( Server obj in Database.Values) {
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

		public IList<Server> SelectByName ( int start, int count, string name )
		{
			List<Server> container = new List<Server>();
 			
			foreach( Server obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Server> SelectByUrl ( string url )
		{
			List<Server> container = new List<Server>();
 			
			foreach( Server obj in Database.Values) {
 				if( obj.Url == url ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUrl ( string url )
		{
			return (long) SelectByUrl ( url ).Count;
		}

		public IList<Server> SelectByUrl ( int start, int count, string url )
		{
			List<Server> container = new List<Server>();
 			
			foreach( Server obj in Database.Values) {
 				if( obj.Url == url ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Server> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Server> container = new List<Server>();
 			
			foreach( Server obj in Database.Values) {
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

		public IList<Server> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Server> container = new List<Server>();
 			
			foreach( Server obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Server> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Server> container = new List<Server>();
 			
			foreach( Server obj in Database.Values) {
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

		public IList<Server> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Server> container = new List<Server>();
 			
			foreach( Server obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Server> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Server> container = new List<Server>();
 			
			foreach( Server obj in Database.Values) {
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

		public IList<Server> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Server> container = new List<Server>();
 			
			foreach( Server obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
