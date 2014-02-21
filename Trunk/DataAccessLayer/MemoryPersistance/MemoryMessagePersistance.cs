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
	internal class MemoryMessagePersistance : 
			MemoryPersistance<Message>, IMessagePersistance {
		
		#region IPersistance
		
		public override Message Create()
		{
			return new SpecializedMemoryMessage ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Message> SelectById ( int id )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
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

		public IList<Message> SelectById ( int start, int count, int id )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Message> SelectByParameters ( string parameters )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.Parameters == parameters ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByParameters ( string parameters )
		{
			return (long) SelectByParameters ( parameters ).Count;
		}

		public IList<Message> SelectByParameters ( int start, int count, string parameters )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.Parameters == parameters ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Message> SelectByCategory ( string category )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.Category == category ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCategory ( string category )
		{
			return (long) SelectByCategory ( category ).Count;
		}

		public IList<Message> SelectByCategory ( int start, int count, string category )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.Category == category ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Message> SelectBySubCategory ( string subCategory )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.SubCategory == subCategory ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySubCategory ( string subCategory )
		{
			return (long) SelectBySubCategory ( subCategory ).Count;
		}

		public IList<Message> SelectBySubCategory ( int start, int count, string subCategory )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.SubCategory == subCategory ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Message> SelectByOwnerId ( int ownerId )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
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

		public IList<Message> SelectByOwnerId ( int start, int count, int ownerId )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.OwnerId == ownerId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Message> SelectByDate ( DateTime date )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
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

		public IList<Message> SelectByDate ( int start, int count, DateTime date )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.Date == date ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Message> SelectByExtended ( string extended )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.Extended == extended ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByExtended ( string extended )
		{
			return (long) SelectByExtended ( extended ).Count;
		}

		public IList<Message> SelectByExtended ( int start, int count, string extended )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.Extended == extended ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Message> SelectByTickDeadline ( int tickDeadline )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.TickDeadline == tickDeadline ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTickDeadline ( int tickDeadline )
		{
			return (long) SelectByTickDeadline ( tickDeadline ).Count;
		}

		public IList<Message> SelectByTickDeadline ( int start, int count, int tickDeadline )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.TickDeadline == tickDeadline ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Message> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
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

		public IList<Message> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Message> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
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

		public IList<Message> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Message> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
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

		public IList<Message> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Message> container = new List<Message>();
 			
			foreach( Message obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
