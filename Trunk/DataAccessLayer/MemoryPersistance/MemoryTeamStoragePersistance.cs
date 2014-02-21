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
	internal class MemoryTeamStoragePersistance : 
			MemoryPersistance<TeamStorage>, ITeamStoragePersistance {
		
		#region IPersistance
		
		public override TeamStorage Create()
		{
			return new SpecializedMemoryTeamStorage ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<TeamStorage> SelectById ( int id )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
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

		public IList<TeamStorage> SelectById ( int start, int count, int id )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TeamStorage> SelectByName ( string name )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
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

		public IList<TeamStorage> SelectByName ( int start, int count, string name )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TeamStorage> SelectByEloRanking ( int eloRanking )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.EloRanking == eloRanking ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByEloRanking ( int eloRanking )
		{
			return (long) SelectByEloRanking ( eloRanking ).Count;
		}

		public IList<TeamStorage> SelectByEloRanking ( int start, int count, int eloRanking )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.EloRanking == eloRanking ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TeamStorage> SelectByNumberPlayedBattles ( int numberPlayedBattles )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.NumberPlayedBattles == numberPlayedBattles ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByNumberPlayedBattles ( int numberPlayedBattles )
		{
			return (long) SelectByNumberPlayedBattles ( numberPlayedBattles ).Count;
		}

		public IList<TeamStorage> SelectByNumberPlayedBattles ( int start, int count, int numberPlayedBattles )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.NumberPlayedBattles == numberPlayedBattles ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TeamStorage> SelectByLadderActive ( bool ladderActive )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.LadderActive == ladderActive ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLadderActive ( bool ladderActive )
		{
			return (long) SelectByLadderActive ( ladderActive ).Count;
		}

		public IList<TeamStorage> SelectByLadderActive ( int start, int count, bool ladderActive )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.LadderActive == ladderActive ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TeamStorage> SelectByLadderPosition ( int ladderPosition )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.LadderPosition == ladderPosition ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLadderPosition ( int ladderPosition )
		{
			return (long) SelectByLadderPosition ( ladderPosition ).Count;
		}

		public IList<TeamStorage> SelectByLadderPosition ( int start, int count, int ladderPosition )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.LadderPosition == ladderPosition ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TeamStorage> SelectByIsInBattle ( int isInBattle )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
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

		public IList<TeamStorage> SelectByIsInBattle ( int start, int count, int isInBattle )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.IsInBattle == isInBattle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TeamStorage> SelectByRestUntil ( int restUntil )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.RestUntil == restUntil ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRestUntil ( int restUntil )
		{
			return (long) SelectByRestUntil ( restUntil ).Count;
		}

		public IList<TeamStorage> SelectByRestUntil ( int start, int count, int restUntil )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.RestUntil == restUntil ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TeamStorage> SelectByStoppedUntil ( int stoppedUntil )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.StoppedUntil == stoppedUntil ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByStoppedUntil ( int stoppedUntil )
		{
			return (long) SelectByStoppedUntil ( stoppedUntil ).Count;
		}

		public IList<TeamStorage> SelectByStoppedUntil ( int start, int count, int stoppedUntil )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.StoppedUntil == stoppedUntil ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TeamStorage> SelectByMyStatsId ( int myStatsId )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.MyStatsId == myStatsId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMyStatsId ( int myStatsId )
		{
			return (long) SelectByMyStatsId ( myStatsId ).Count;
		}

		public IList<TeamStorage> SelectByMyStatsId ( int start, int count, int myStatsId )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.MyStatsId == myStatsId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TeamStorage> SelectByIsComplete ( bool isComplete )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.IsComplete == isComplete ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsComplete ( bool isComplete )
		{
			return (long) SelectByIsComplete ( isComplete ).Count;
		}

		public IList<TeamStorage> SelectByIsComplete ( int start, int count, bool isComplete )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.IsComplete == isComplete ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TeamStorage> SelectByCreatedDate ( DateTime createdDate )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
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

		public IList<TeamStorage> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TeamStorage> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
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

		public IList<TeamStorage> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<TeamStorage> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
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

		public IList<TeamStorage> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<TeamStorage> container = new List<TeamStorage>();
 			
			foreach( TeamStorage obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
