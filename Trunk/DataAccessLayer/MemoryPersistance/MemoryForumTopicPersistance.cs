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
	internal class MemoryForumTopicPersistance : 
			MemoryPersistance<ForumTopic>, IForumTopicPersistance {
		
		#region IPersistance
		
		public override ForumTopic Create()
		{
			return new SpecializedMemoryForumTopic ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<ForumTopic> SelectById ( int id )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
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

		public IList<ForumTopic> SelectById ( int start, int count, int id )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumTopic> SelectByTitle ( string title )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
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

		public IList<ForumTopic> SelectByTitle ( int start, int count, string title )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.Title == title ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumTopic> SelectByLastPost ( DateTime lastPost )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.LastPost == lastPost ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLastPost ( DateTime lastPost )
		{
			return (long) SelectByLastPost ( lastPost ).Count;
		}

		public IList<ForumTopic> SelectByLastPost ( int start, int count, DateTime lastPost )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.LastPost == lastPost ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumTopic> SelectByTotalPosts ( int totalPosts )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.TotalPosts == totalPosts ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTotalPosts ( int totalPosts )
		{
			return (long) SelectByTotalPosts ( totalPosts ).Count;
		}

		public IList<ForumTopic> SelectByTotalPosts ( int start, int count, int totalPosts )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.TotalPosts == totalPosts ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumTopic> SelectByTotalThreads ( int totalThreads )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.TotalThreads == totalThreads ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTotalThreads ( int totalThreads )
		{
			return (long) SelectByTotalThreads ( totalThreads ).Count;
		}

		public IList<ForumTopic> SelectByTotalThreads ( int start, int count, int totalThreads )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.TotalThreads == totalThreads ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumTopic> SelectByIsPrivate ( bool isPrivate )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.IsPrivate == isPrivate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsPrivate ( bool isPrivate )
		{
			return (long) SelectByIsPrivate ( isPrivate ).Count;
		}

		public IList<ForumTopic> SelectByIsPrivate ( int start, int count, bool isPrivate )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.IsPrivate == isPrivate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumTopic> SelectByForumRoles ( string forumRoles )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.ForumRoles == forumRoles ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByForumRoles ( string forumRoles )
		{
			return (long) SelectByForumRoles ( forumRoles ).Count;
		}

		public IList<ForumTopic> SelectByForumRoles ( int start, int count, string forumRoles )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.ForumRoles == forumRoles ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumTopic> SelectByDescription ( string description )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.Description == description ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByDescription ( string description )
		{
			return (long) SelectByDescription ( description ).Count;
		}

		public IList<ForumTopic> SelectByDescription ( int start, int count, string description )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.Description == description ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumTopic> SelectByCreatedDate ( DateTime createdDate )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
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

		public IList<ForumTopic> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumTopic> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
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

		public IList<ForumTopic> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumTopic> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
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

		public IList<ForumTopic> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<ForumTopic> container = new List<ForumTopic>();
 			
			foreach( ForumTopic obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
