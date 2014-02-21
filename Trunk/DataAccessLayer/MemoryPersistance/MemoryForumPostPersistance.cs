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
	internal class MemoryForumPostPersistance : 
			MemoryPersistance<ForumPost>, IForumPostPersistance {
		
		#region IPersistance
		
		public override ForumPost Create()
		{
			return new SpecializedMemoryForumPost ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<ForumPost> SelectById ( int id )
		{
			List<ForumPost> container = new List<ForumPost>();
 			
			foreach( ForumPost obj in Database.Values) {
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

		public IList<ForumPost> SelectById ( int start, int count, int id )
		{
			List<ForumPost> container = new List<ForumPost>();
 			
			foreach( ForumPost obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumPost> SelectByText ( string text )
		{
			List<ForumPost> container = new List<ForumPost>();
 			
			foreach( ForumPost obj in Database.Values) {
 				if( obj.Text == text ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByText ( string text )
		{
			return (long) SelectByText ( text ).Count;
		}

		public IList<ForumPost> SelectByText ( int start, int count, string text )
		{
			List<ForumPost> container = new List<ForumPost>();
 			
			foreach( ForumPost obj in Database.Values) {
 				if( obj.Text == text ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumPost> SelectByThread ( ForumThread thread )
		{
			List<ForumPost> container = new List<ForumPost>();
 			
			foreach( ForumPost obj in Database.Values) {
 				if( obj.Thread == thread ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByThread ( ForumThread thread )
		{
			return (long) SelectByThread ( thread ).Count;
		}

		public IList<ForumPost> SelectByThread ( int start, int count, ForumThread thread )
		{
			List<ForumPost> container = new List<ForumPost>();
 			
			foreach( ForumPost obj in Database.Values) {
 				if( obj.Thread == thread ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumPost> SelectByOwner ( PlayerStorage owner )
		{
			List<ForumPost> container = new List<ForumPost>();
 			
			foreach( ForumPost obj in Database.Values) {
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

		public IList<ForumPost> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			List<ForumPost> container = new List<ForumPost>();
 			
			foreach( ForumPost obj in Database.Values) {
 				if( obj.Owner == owner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumPost> SelectByCreatedDate ( DateTime createdDate )
		{
			List<ForumPost> container = new List<ForumPost>();
 			
			foreach( ForumPost obj in Database.Values) {
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

		public IList<ForumPost> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<ForumPost> container = new List<ForumPost>();
 			
			foreach( ForumPost obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumPost> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<ForumPost> container = new List<ForumPost>();
 			
			foreach( ForumPost obj in Database.Values) {
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

		public IList<ForumPost> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<ForumPost> container = new List<ForumPost>();
 			
			foreach( ForumPost obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumPost> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<ForumPost> container = new List<ForumPost>();
 			
			foreach( ForumPost obj in Database.Values) {
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

		public IList<ForumPost> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<ForumPost> container = new List<ForumPost>();
 			
			foreach( ForumPost obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
