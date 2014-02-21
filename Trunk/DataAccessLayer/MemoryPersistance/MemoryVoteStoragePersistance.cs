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
	internal class MemoryVoteStoragePersistance : 
			MemoryPersistance<VoteStorage>, IVoteStoragePersistance {
		
		#region IPersistance
		
		public override VoteStorage Create()
		{
			return new SpecializedMemoryVoteStorage ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<VoteStorage> SelectById ( int id )
		{
			List<VoteStorage> container = new List<VoteStorage>();
 			
			foreach( VoteStorage obj in Database.Values) {
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

		public IList<VoteStorage> SelectById ( int start, int count, int id )
		{
			List<VoteStorage> container = new List<VoteStorage>();
 			
			foreach( VoteStorage obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<VoteStorage> SelectByData ( string data )
		{
			List<VoteStorage> container = new List<VoteStorage>();
 			
			foreach( VoteStorage obj in Database.Values) {
 				if( obj.Data == data ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByData ( string data )
		{
			return (long) SelectByData ( data ).Count;
		}

		public IList<VoteStorage> SelectByData ( int start, int count, string data )
		{
			List<VoteStorage> container = new List<VoteStorage>();
 			
			foreach( VoteStorage obj in Database.Values) {
 				if( obj.Data == data ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<VoteStorage> SelectByOwnerId ( int ownerId )
		{
			List<VoteStorage> container = new List<VoteStorage>();
 			
			foreach( VoteStorage obj in Database.Values) {
 				if( obj.OwnerId == ownerId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByOwnerId ( int ownerId )
		{
			return (long) SelectByOwnerId ( ownerId ).Count;
		}

		public IList<VoteStorage> SelectByOwnerId ( int start, int count, int ownerId )
		{
			List<VoteStorage> container = new List<VoteStorage>();
 			
			foreach( VoteStorage obj in Database.Values) {
 				if( obj.OwnerId == ownerId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<VoteStorage> SelectByCreatedDate ( DateTime createdDate )
		{
			List<VoteStorage> container = new List<VoteStorage>();
 			
			foreach( VoteStorage obj in Database.Values) {
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

		public IList<VoteStorage> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<VoteStorage> container = new List<VoteStorage>();
 			
			foreach( VoteStorage obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<VoteStorage> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<VoteStorage> container = new List<VoteStorage>();
 			
			foreach( VoteStorage obj in Database.Values) {
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

		public IList<VoteStorage> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<VoteStorage> container = new List<VoteStorage>();
 			
			foreach( VoteStorage obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<VoteStorage> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<VoteStorage> container = new List<VoteStorage>();
 			
			foreach( VoteStorage obj in Database.Values) {
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

		public IList<VoteStorage> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<VoteStorage> container = new List<VoteStorage>();
 			
			foreach( VoteStorage obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
