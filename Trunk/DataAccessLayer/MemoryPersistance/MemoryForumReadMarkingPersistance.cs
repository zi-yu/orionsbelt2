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
	internal class MemoryForumReadMarkingPersistance : 
			MemoryPersistance<ForumReadMarking>, IForumReadMarkingPersistance {
		
		#region IPersistance
		
		public override ForumReadMarking Create()
		{
			return new SpecializedMemoryForumReadMarking ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<ForumReadMarking> SelectById ( int id )
		{
			List<ForumReadMarking> container = new List<ForumReadMarking>();
 			
			foreach( ForumReadMarking obj in Database.Values) {
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

		public IList<ForumReadMarking> SelectById ( int start, int count, int id )
		{
			List<ForumReadMarking> container = new List<ForumReadMarking>();
 			
			foreach( ForumReadMarking obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumReadMarking> SelectByLastRead ( DateTime lastRead )
		{
			List<ForumReadMarking> container = new List<ForumReadMarking>();
 			
			foreach( ForumReadMarking obj in Database.Values) {
 				if( obj.LastRead == lastRead ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLastRead ( DateTime lastRead )
		{
			return (long) SelectByLastRead ( lastRead ).Count;
		}

		public IList<ForumReadMarking> SelectByLastRead ( int start, int count, DateTime lastRead )
		{
			List<ForumReadMarking> container = new List<ForumReadMarking>();
 			
			foreach( ForumReadMarking obj in Database.Values) {
 				if( obj.LastRead == lastRead ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumReadMarking> SelectByPlayer ( PlayerStorage player )
		{
			List<ForumReadMarking> container = new List<ForumReadMarking>();
 			
			foreach( ForumReadMarking obj in Database.Values) {
 				if( obj.Player == player ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPlayer ( PlayerStorage player )
		{
			return (long) SelectByPlayer ( player ).Count;
		}

		public IList<ForumReadMarking> SelectByPlayer ( int start, int count, PlayerStorage player )
		{
			List<ForumReadMarking> container = new List<ForumReadMarking>();
 			
			foreach( ForumReadMarking obj in Database.Values) {
 				if( obj.Player == player ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumReadMarking> SelectByThread ( ForumThread thread )
		{
			List<ForumReadMarking> container = new List<ForumReadMarking>();
 			
			foreach( ForumReadMarking obj in Database.Values) {
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

		public IList<ForumReadMarking> SelectByThread ( int start, int count, ForumThread thread )
		{
			List<ForumReadMarking> container = new List<ForumReadMarking>();
 			
			foreach( ForumReadMarking obj in Database.Values) {
 				if( obj.Thread == thread ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumReadMarking> SelectByCreatedDate ( DateTime createdDate )
		{
			List<ForumReadMarking> container = new List<ForumReadMarking>();
 			
			foreach( ForumReadMarking obj in Database.Values) {
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

		public IList<ForumReadMarking> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<ForumReadMarking> container = new List<ForumReadMarking>();
 			
			foreach( ForumReadMarking obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumReadMarking> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<ForumReadMarking> container = new List<ForumReadMarking>();
 			
			foreach( ForumReadMarking obj in Database.Values) {
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

		public IList<ForumReadMarking> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<ForumReadMarking> container = new List<ForumReadMarking>();
 			
			foreach( ForumReadMarking obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ForumReadMarking> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<ForumReadMarking> container = new List<ForumReadMarking>();
 			
			foreach( ForumReadMarking obj in Database.Values) {
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

		public IList<ForumReadMarking> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<ForumReadMarking> container = new List<ForumReadMarking>();
 			
			foreach( ForumReadMarking obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
