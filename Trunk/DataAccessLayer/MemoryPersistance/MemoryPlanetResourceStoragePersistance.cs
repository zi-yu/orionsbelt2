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
	internal class MemoryPlanetResourceStoragePersistance : 
			MemoryPersistance<PlanetResourceStorage>, IPlanetResourceStoragePersistance {
		
		#region IPersistance
		
		public override PlanetResourceStorage Create()
		{
			return new SpecializedMemoryPlanetResourceStorage ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<PlanetResourceStorage> SelectById ( int id )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
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

		public IList<PlanetResourceStorage> SelectById ( int start, int count, int id )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetResourceStorage> SelectByQuantity ( int quantity )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.Quantity == quantity ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByQuantity ( int quantity )
		{
			return (long) SelectByQuantity ( quantity ).Count;
		}

		public IList<PlanetResourceStorage> SelectByQuantity ( int start, int count, int quantity )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.Quantity == quantity ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetResourceStorage> SelectByState ( string state )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.State == state ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByState ( string state )
		{
			return (long) SelectByState ( state ).Count;
		}

		public IList<PlanetResourceStorage> SelectByState ( int start, int count, string state )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.State == state ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetResourceStorage> SelectByLevel ( int level )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.Level == level ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLevel ( int level )
		{
			return (long) SelectByLevel ( level ).Count;
		}

		public IList<PlanetResourceStorage> SelectByLevel ( int start, int count, int level )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.Level == level ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetResourceStorage> SelectByType ( string type )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByType ( string type )
		{
			return (long) SelectByType ( type ).Count;
		}

		public IList<PlanetResourceStorage> SelectByType ( int start, int count, string type )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetResourceStorage> SelectByQueueOrder ( int queueOrder )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.QueueOrder == queueOrder ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByQueueOrder ( int queueOrder )
		{
			return (long) SelectByQueueOrder ( queueOrder ).Count;
		}

		public IList<PlanetResourceStorage> SelectByQueueOrder ( int start, int count, int queueOrder )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.QueueOrder == queueOrder ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetResourceStorage> SelectBySlot ( string slot )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.Slot == slot ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySlot ( string slot )
		{
			return (long) SelectBySlot ( slot ).Count;
		}

		public IList<PlanetResourceStorage> SelectBySlot ( int start, int count, string slot )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.Slot == slot ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetResourceStorage> SelectByEndTick ( int endTick )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.EndTick == endTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByEndTick ( int endTick )
		{
			return (long) SelectByEndTick ( endTick ).Count;
		}

		public IList<PlanetResourceStorage> SelectByEndTick ( int start, int count, int endTick )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.EndTick == endTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetResourceStorage> SelectByPlanet ( PlanetStorage planet )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.Planet == planet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPlanet ( PlanetStorage planet )
		{
			return (long) SelectByPlanet ( planet ).Count;
		}

		public IList<PlanetResourceStorage> SelectByPlanet ( int start, int count, PlanetStorage planet )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.Planet == planet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetResourceStorage> SelectByPlayer ( PlayerStorage player )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
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

		public IList<PlanetResourceStorage> SelectByPlayer ( int start, int count, PlayerStorage player )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.Player == player ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetResourceStorage> SelectByCreatedDate ( DateTime createdDate )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
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

		public IList<PlanetResourceStorage> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetResourceStorage> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
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

		public IList<PlanetResourceStorage> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetResourceStorage> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
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

		public IList<PlanetResourceStorage> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<PlanetResourceStorage> container = new List<PlanetResourceStorage>();
 			
			foreach( PlanetResourceStorage obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
