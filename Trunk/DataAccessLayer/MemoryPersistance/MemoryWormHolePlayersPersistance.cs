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
	internal class MemoryWormHolePlayersPersistance : 
			MemoryPersistance<WormHolePlayers>, IWormHolePlayersPersistance {
		
		#region IPersistance
		
		public override WormHolePlayers Create()
		{
			return new SpecializedMemoryWormHolePlayers ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<WormHolePlayers> SelectById ( int id )
		{
			List<WormHolePlayers> container = new List<WormHolePlayers>();
 			
			foreach( WormHolePlayers obj in Database.Values) {
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

		public IList<WormHolePlayers> SelectById ( int start, int count, int id )
		{
			List<WormHolePlayers> container = new List<WormHolePlayers>();
 			
			foreach( WormHolePlayers obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<WormHolePlayers> SelectByPlayerCount ( int playerCount )
		{
			List<WormHolePlayers> container = new List<WormHolePlayers>();
 			
			foreach( WormHolePlayers obj in Database.Values) {
 				if( obj.PlayerCount == playerCount ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPlayerCount ( int playerCount )
		{
			return (long) SelectByPlayerCount ( playerCount ).Count;
		}

		public IList<WormHolePlayers> SelectByPlayerCount ( int start, int count, int playerCount )
		{
			List<WormHolePlayers> container = new List<WormHolePlayers>();
 			
			foreach( WormHolePlayers obj in Database.Values) {
 				if( obj.PlayerCount == playerCount ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<WormHolePlayers> SelectByCreatedDate ( DateTime createdDate )
		{
			List<WormHolePlayers> container = new List<WormHolePlayers>();
 			
			foreach( WormHolePlayers obj in Database.Values) {
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

		public IList<WormHolePlayers> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<WormHolePlayers> container = new List<WormHolePlayers>();
 			
			foreach( WormHolePlayers obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<WormHolePlayers> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<WormHolePlayers> container = new List<WormHolePlayers>();
 			
			foreach( WormHolePlayers obj in Database.Values) {
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

		public IList<WormHolePlayers> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<WormHolePlayers> container = new List<WormHolePlayers>();
 			
			foreach( WormHolePlayers obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<WormHolePlayers> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<WormHolePlayers> container = new List<WormHolePlayers>();
 			
			foreach( WormHolePlayers obj in Database.Values) {
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

		public IList<WormHolePlayers> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<WormHolePlayers> container = new List<WormHolePlayers>();
 			
			foreach( WormHolePlayers obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
