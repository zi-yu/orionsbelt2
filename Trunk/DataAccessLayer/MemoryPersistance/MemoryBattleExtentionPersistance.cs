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
	internal class MemoryBattleExtentionPersistance : 
			MemoryPersistance<BattleExtention>, IBattleExtentionPersistance {
		
		#region IPersistance
		
		public override BattleExtention Create()
		{
			return new SpecializedMemoryBattleExtention ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<BattleExtention> SelectById ( int id )
		{
			List<BattleExtention> container = new List<BattleExtention>();
 			
			foreach( BattleExtention obj in Database.Values) {
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

		public IList<BattleExtention> SelectById ( int start, int count, int id )
		{
			List<BattleExtention> container = new List<BattleExtention>();
 			
			foreach( BattleExtention obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleExtention> SelectByBattleFinalStates ( string battleFinalStates )
		{
			List<BattleExtention> container = new List<BattleExtention>();
 			
			foreach( BattleExtention obj in Database.Values) {
 				if( obj.BattleFinalStates == battleFinalStates ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBattleFinalStates ( string battleFinalStates )
		{
			return (long) SelectByBattleFinalStates ( battleFinalStates ).Count;
		}

		public IList<BattleExtention> SelectByBattleFinalStates ( int start, int count, string battleFinalStates )
		{
			List<BattleExtention> container = new List<BattleExtention>();
 			
			foreach( BattleExtention obj in Database.Values) {
 				if( obj.BattleFinalStates == battleFinalStates ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleExtention> SelectByBattleMovements ( string battleMovements )
		{
			List<BattleExtention> container = new List<BattleExtention>();
 			
			foreach( BattleExtention obj in Database.Values) {
 				if( obj.BattleMovements == battleMovements ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBattleMovements ( string battleMovements )
		{
			return (long) SelectByBattleMovements ( battleMovements ).Count;
		}

		public IList<BattleExtention> SelectByBattleMovements ( int start, int count, string battleMovements )
		{
			List<BattleExtention> container = new List<BattleExtention>();
 			
			foreach( BattleExtention obj in Database.Values) {
 				if( obj.BattleMovements == battleMovements ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleExtention> SelectByBattle ( Battle battle )
		{
			List<BattleExtention> container = new List<BattleExtention>();
 			
			foreach( BattleExtention obj in Database.Values) {
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

		public IList<BattleExtention> SelectByBattle ( int start, int count, Battle battle )
		{
			List<BattleExtention> container = new List<BattleExtention>();
 			
			foreach( BattleExtention obj in Database.Values) {
 				if( obj.Battle == battle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleExtention> SelectByCreatedDate ( DateTime createdDate )
		{
			List<BattleExtention> container = new List<BattleExtention>();
 			
			foreach( BattleExtention obj in Database.Values) {
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

		public IList<BattleExtention> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<BattleExtention> container = new List<BattleExtention>();
 			
			foreach( BattleExtention obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleExtention> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<BattleExtention> container = new List<BattleExtention>();
 			
			foreach( BattleExtention obj in Database.Values) {
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

		public IList<BattleExtention> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<BattleExtention> container = new List<BattleExtention>();
 			
			foreach( BattleExtention obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleExtention> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<BattleExtention> container = new List<BattleExtention>();
 			
			foreach( BattleExtention obj in Database.Values) {
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

		public IList<BattleExtention> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<BattleExtention> container = new List<BattleExtention>();
 			
			foreach( BattleExtention obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
