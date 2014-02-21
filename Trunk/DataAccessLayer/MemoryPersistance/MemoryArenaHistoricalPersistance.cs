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
	internal class MemoryArenaHistoricalPersistance : 
			MemoryPersistance<ArenaHistorical>, IArenaHistoricalPersistance {
		
		#region IPersistance
		
		public override ArenaHistorical Create()
		{
			return new SpecializedMemoryArenaHistorical ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<ArenaHistorical> SelectById ( int id )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
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

		public IList<ArenaHistorical> SelectById ( int start, int count, int id )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaHistorical> SelectByChampionId ( int championId )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.ChampionId == championId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByChampionId ( int championId )
		{
			return (long) SelectByChampionId ( championId ).Count;
		}

		public IList<ArenaHistorical> SelectByChampionId ( int start, int count, int championId )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.ChampionId == championId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaHistorical> SelectByChallengerId ( int challengerId )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.ChallengerId == challengerId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByChallengerId ( int challengerId )
		{
			return (long) SelectByChallengerId ( challengerId ).Count;
		}

		public IList<ArenaHistorical> SelectByChallengerId ( int start, int count, int challengerId )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.ChallengerId == challengerId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaHistorical> SelectByWinner ( int winner )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.Winner == winner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByWinner ( int winner )
		{
			return (long) SelectByWinner ( winner ).Count;
		}

		public IList<ArenaHistorical> SelectByWinner ( int start, int count, int winner )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.Winner == winner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaHistorical> SelectByWinningSequence ( int winningSequence )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.WinningSequence == winningSequence ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByWinningSequence ( int winningSequence )
		{
			return (long) SelectByWinningSequence ( winningSequence ).Count;
		}

		public IList<ArenaHistorical> SelectByWinningSequence ( int start, int count, int winningSequence )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.WinningSequence == winningSequence ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaHistorical> SelectByBattleId ( int battleId )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.BattleId == battleId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBattleId ( int battleId )
		{
			return (long) SelectByBattleId ( battleId ).Count;
		}

		public IList<ArenaHistorical> SelectByBattleId ( int start, int count, int battleId )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.BattleId == battleId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaHistorical> SelectByStartTick ( int startTick )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
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

		public IList<ArenaHistorical> SelectByStartTick ( int start, int count, int startTick )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.StartTick == startTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaHistorical> SelectByEndTick ( int endTick )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
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

		public IList<ArenaHistorical> SelectByEndTick ( int start, int count, int endTick )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.EndTick == endTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaHistorical> SelectByArena ( ArenaStorage arena )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.Arena == arena ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByArena ( ArenaStorage arena )
		{
			return (long) SelectByArena ( arena ).Count;
		}

		public IList<ArenaHistorical> SelectByArena ( int start, int count, ArenaStorage arena )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.Arena == arena ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaHistorical> SelectByCreatedDate ( DateTime createdDate )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
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

		public IList<ArenaHistorical> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaHistorical> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
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

		public IList<ArenaHistorical> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ArenaHistorical> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
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

		public IList<ArenaHistorical> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<ArenaHistorical> container = new List<ArenaHistorical>();
 			
			foreach( ArenaHistorical obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
