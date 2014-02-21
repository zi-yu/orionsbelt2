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
	internal class MemoryForumThreadPersistance : 
			MemoryPersistance<ForumThread>, IForumThreadPersistance {
		
		#region IPersistance
		
		public override ForumThread Create()
		{
			return new SpecializedMemoryForumThread ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<ForumThread> SelectById ( int id )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
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

		public IList<ForumThread> SelectById ( int start, int count, int id )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumThread> SelectByTitle ( string title )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
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

		public IList<ForumThread> SelectByTitle ( int start, int count, string title )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
 				if( obj.Title == title ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumThread> SelectByTotalViews ( int totalViews )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
 				if( obj.TotalViews == totalViews ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTotalViews ( int totalViews )
		{
			return (long) SelectByTotalViews ( totalViews ).Count;
		}

		public IList<ForumThread> SelectByTotalViews ( int start, int count, int totalViews )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
 				if( obj.TotalViews == totalViews ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumThread> SelectByTotalReplies ( int totalReplies )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
 				if( obj.TotalReplies == totalReplies ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTotalReplies ( int totalReplies )
		{
			return (long) SelectByTotalReplies ( totalReplies ).Count;
		}

		public IList<ForumThread> SelectByTotalReplies ( int start, int count, int totalReplies )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
 				if( obj.TotalReplies == totalReplies ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumThread> SelectByTopic ( ForumTopic topic )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
 				if( obj.Topic == topic ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTopic ( ForumTopic topic )
		{
			return (long) SelectByTopic ( topic ).Count;
		}

		public IList<ForumThread> SelectByTopic ( int start, int count, ForumTopic topic )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
 				if( obj.Topic == topic ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumThread> SelectByOwner ( PlayerStorage owner )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
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

		public IList<ForumThread> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
 				if( obj.Owner == owner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumThread> SelectByCreatedDate ( DateTime createdDate )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
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

		public IList<ForumThread> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumThread> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
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

		public IList<ForumThread> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumThread> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
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

		public IList<ForumThread> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<ForumThread> container = new List<ForumThread>();
 			
			foreach( ForumThread obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
