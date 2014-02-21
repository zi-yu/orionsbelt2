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
	internal class MemoryTaskPersistance : 
			MemoryPersistance<Task>, ITaskPersistance {
		
		#region IPersistance
		
		public override Task Create()
		{
			return new SpecializedMemoryTask ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Task> SelectById ( int id )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
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

		public IList<Task> SelectById ( int start, int count, int id )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Task> SelectByStatus ( string status )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
 				if( obj.Status == status ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByStatus ( string status )
		{
			return (long) SelectByStatus ( status ).Count;
		}

		public IList<Task> SelectByStatus ( int start, int count, string status )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
 				if( obj.Status == status ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Task> SelectByPriority ( string priority )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
 				if( obj.Priority == priority ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPriority ( string priority )
		{
			return (long) SelectByPriority ( priority ).Count;
		}

		public IList<Task> SelectByPriority ( int start, int count, string priority )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
 				if( obj.Priority == priority ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Task> SelectByTitle ( string title )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
 				if( obj.Title == title ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTitle ( string title )
		{
			return (long) SelectByTitle ( title ).Count;
		}

		public IList<Task> SelectByTitle ( int start, int count, string title )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
 				if( obj.Title == title ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Task> SelectByNecessity ( Necessity necessity )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
 				if( obj.Necessity == necessity ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByNecessity ( Necessity necessity )
		{
			return (long) SelectByNecessity ( necessity ).Count;
		}

		public IList<Task> SelectByNecessity ( int start, int count, Necessity necessity )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
 				if( obj.Necessity == necessity ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Task> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
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

		public IList<Task> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Task> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
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

		public IList<Task> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Task> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
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

		public IList<Task> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Task> container = new List<Task>();
 			
			foreach( Task obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
