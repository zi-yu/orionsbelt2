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
	internal class MemoryArenaStoragePersistance : 
			MemoryPersistance<ArenaStorage>, IArenaStoragePersistance {
		
		#region IPersistance
		
		public override ArenaStorage Create()
		{
			return new SpecializedMemoryArenaStorage ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<ArenaStorage> SelectById ( int id )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
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

		public IList<ArenaStorage> SelectById ( int start, int count, int id )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaStorage> SelectByName ( string name )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
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

		public IList<ArenaStorage> SelectByName ( int start, int count, string name )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaStorage> SelectByIsInBattle ( int isInBattle )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.IsInBattle == isInBattle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsInBattle ( int isInBattle )
		{
			return (long) SelectByIsInBattle ( isInBattle ).Count;
		}

		public IList<ArenaStorage> SelectByIsInBattle ( int start, int count, int isInBattle )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.IsInBattle == isInBattle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaStorage> SelectByConquestTick ( int conquestTick )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.ConquestTick == conquestTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByConquestTick ( int conquestTick )
		{
			return (long) SelectByConquestTick ( conquestTick ).Count;
		}

		public IList<ArenaStorage> SelectByConquestTick ( int start, int count, int conquestTick )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.ConquestTick == conquestTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaStorage> SelectByBattleType ( string battleType )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.BattleType == battleType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBattleType ( string battleType )
		{
			return (long) SelectByBattleType ( battleType ).Count;
		}

		public IList<ArenaStorage> SelectByBattleType ( int start, int count, string battleType )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.BattleType == battleType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaStorage> SelectByCoordinate ( string coordinate )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.Coordinate == coordinate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCoordinate ( string coordinate )
		{
			return (long) SelectByCoordinate ( coordinate ).Count;
		}

		public IList<ArenaStorage> SelectByCoordinate ( int start, int count, string coordinate )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.Coordinate == coordinate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaStorage> SelectByPayment ( int payment )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.Payment == payment ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPayment ( int payment )
		{
			return (long) SelectByPayment ( payment ).Count;
		}

		public IList<ArenaStorage> SelectByPayment ( int start, int count, int payment )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.Payment == payment ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaStorage> SelectByLevel ( int level )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
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

		public IList<ArenaStorage> SelectByLevel ( int start, int count, int level )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.Level == level ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaStorage> SelectByFleet ( Fleet fleet )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.Fleet == fleet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByFleet ( Fleet fleet )
		{
			return (long) SelectByFleet ( fleet ).Count;
		}

		public IList<ArenaStorage> SelectByFleet ( int start, int count, Fleet fleet )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.Fleet == fleet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaStorage> SelectByOwner ( PlayerStorage owner )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
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

		public IList<ArenaStorage> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.Owner == owner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaStorage> SelectBySector ( SectorStorage sector )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.Sector == sector ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySector ( SectorStorage sector )
		{
			return (long) SelectBySector ( sector ).Count;
		}

		public IList<ArenaStorage> SelectBySector ( int start, int count, SectorStorage sector )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.Sector == sector ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaStorage> SelectByCreatedDate ( DateTime createdDate )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
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

		public IList<ArenaStorage> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaStorage> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
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

		public IList<ArenaStorage> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaStorage> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
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

		public IList<ArenaStorage> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<ArenaStorage> container = new List<ArenaStorage>();
 			
			foreach( ArenaStorage obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
