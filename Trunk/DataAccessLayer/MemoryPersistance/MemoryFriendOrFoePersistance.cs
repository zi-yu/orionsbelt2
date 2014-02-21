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
	internal class MemoryFriendOrFoePersistance : 
			MemoryPersistance<FriendOrFoe>, IFriendOrFoePersistance {
		
		#region IPersistance
		
		public override FriendOrFoe Create()
		{
			return new SpecializedMemoryFriendOrFoe ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<FriendOrFoe> SelectById ( int id )
		{
			List<FriendOrFoe> container = new List<FriendOrFoe>();
 			
			foreach( FriendOrFoe obj in Database.Values) {
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

		public IList<FriendOrFoe> SelectById ( int start, int count, int id )
		{
			List<FriendOrFoe> container = new List<FriendOrFoe>();
 			
			foreach( FriendOrFoe obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<FriendOrFoe> SelectByIsFriend ( bool isFriend )
		{
			List<FriendOrFoe> container = new List<FriendOrFoe>();
 			
			foreach( FriendOrFoe obj in Database.Values) {
 				if( obj.IsFriend == isFriend ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsFriend ( bool isFriend )
		{
			return (long) SelectByIsFriend ( isFriend ).Count;
		}

		public IList<FriendOrFoe> SelectByIsFriend ( int start, int count, bool isFriend )
		{
			List<FriendOrFoe> container = new List<FriendOrFoe>();
 			
			foreach( FriendOrFoe obj in Database.Values) {
 				if( obj.IsFriend == isFriend ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<FriendOrFoe> SelectBySource ( PlayerStorage source )
		{
			List<FriendOrFoe> container = new List<FriendOrFoe>();
 			
			foreach( FriendOrFoe obj in Database.Values) {
 				if( obj.Source == source ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySource ( PlayerStorage source )
		{
			return (long) SelectBySource ( source ).Count;
		}

		public IList<FriendOrFoe> SelectBySource ( int start, int count, PlayerStorage source )
		{
			List<FriendOrFoe> container = new List<FriendOrFoe>();
 			
			foreach( FriendOrFoe obj in Database.Values) {
 				if( obj.Source == source ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<FriendOrFoe> SelectByTarget ( PlayerStorage target )
		{
			List<FriendOrFoe> container = new List<FriendOrFoe>();
 			
			foreach( FriendOrFoe obj in Database.Values) {
 				if( obj.Target == target ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTarget ( PlayerStorage target )
		{
			return (long) SelectByTarget ( target ).Count;
		}

		public IList<FriendOrFoe> SelectByTarget ( int start, int count, PlayerStorage target )
		{
			List<FriendOrFoe> container = new List<FriendOrFoe>();
 			
			foreach( FriendOrFoe obj in Database.Values) {
 				if( obj.Target == target ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<FriendOrFoe> SelectByCreatedDate ( DateTime createdDate )
		{
			List<FriendOrFoe> container = new List<FriendOrFoe>();
 			
			foreach( FriendOrFoe obj in Database.Values) {
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

		public IList<FriendOrFoe> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<FriendOrFoe> container = new List<FriendOrFoe>();
 			
			foreach( FriendOrFoe obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<FriendOrFoe> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<FriendOrFoe> container = new List<FriendOrFoe>();
 			
			foreach( FriendOrFoe obj in Database.Values) {
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

		public IList<FriendOrFoe> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<FriendOrFoe> container = new List<FriendOrFoe>();
 			
			foreach( FriendOrFoe obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<FriendOrFoe> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<FriendOrFoe> container = new List<FriendOrFoe>();
 			
			foreach( FriendOrFoe obj in Database.Values) {
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

		public IList<FriendOrFoe> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<FriendOrFoe> container = new List<FriendOrFoe>();
 			
			foreach( FriendOrFoe obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
