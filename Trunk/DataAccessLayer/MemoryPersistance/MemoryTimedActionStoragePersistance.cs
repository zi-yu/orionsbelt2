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
	internal class MemoryTimedActionStoragePersistance : 
			MemoryPersistance<TimedActionStorage>, ITimedActionStoragePersistance {
		
		#region IPersistance
		
		public override TimedActionStorage Create()
		{
			return new SpecializedMemoryTimedActionStorage ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<TimedActionStorage> SelectById ( int id )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
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

		public IList<TimedActionStorage> SelectById ( int start, int count, int id )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TimedActionStorage> SelectByStartTick ( int startTick )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
 				if( obj.StartTick == startTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByStartTick ( int startTick )
		{
			return (long) SelectByStartTick ( startTick ).Count;
		}

		public IList<TimedActionStorage> SelectByStartTick ( int start, int count, int startTick )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
 				if( obj.StartTick == startTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TimedActionStorage> SelectByEndTick ( int endTick )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
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

		public IList<TimedActionStorage> SelectByEndTick ( int start, int count, int endTick )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
 				if( obj.EndTick == endTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TimedActionStorage> SelectByData ( string data )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
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

		public IList<TimedActionStorage> SelectByData ( int start, int count, string data )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
 				if( obj.Data == data ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TimedActionStorage> SelectByName ( string name )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByName ( string name )
		{
			return (long) SelectByName ( name ).Count;
		}

		public IList<TimedActionStorage> SelectByName ( int start, int count, string name )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TimedActionStorage> SelectByPlayer ( PlayerStorage player )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
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

		public IList<TimedActionStorage> SelectByPlayer ( int start, int count, PlayerStorage player )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
 				if( obj.Player == player ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TimedActionStorage> SelectByBattle ( Battle battle )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
 				if( obj.Battle == battle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBattle ( Battle battle )
		{
			return (long) SelectByBattle ( battle ).Count;
		}

		public IList<TimedActionStorage> SelectByBattle ( int start, int count, Battle battle )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
 				if( obj.Battle == battle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TimedActionStorage> SelectByCreatedDate ( DateTime createdDate )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
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

		public IList<TimedActionStorage> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TimedActionStorage> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
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

		public IList<TimedActionStorage> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TimedActionStorage> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
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

		public IList<TimedActionStorage> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<TimedActionStorage> container = new List<TimedActionStorage>();
 			
			foreach( TimedActionStorage obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
