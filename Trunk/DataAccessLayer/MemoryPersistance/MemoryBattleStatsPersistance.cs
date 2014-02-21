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
	internal class MemoryBattleStatsPersistance : 
			MemoryPersistance<BattleStats>, IBattleStatsPersistance {
		
		#region IPersistance
		
		public override BattleStats Create()
		{
			return new SpecializedMemoryBattleStats ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<BattleStats> SelectById ( int id )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
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

		public IList<BattleStats> SelectById ( int start, int count, int id )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleStats> SelectByWins ( int wins )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.Wins == wins ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByWins ( int wins )
		{
			return (long) SelectByWins ( wins ).Count;
		}

		public IList<BattleStats> SelectByWins ( int start, int count, int wins )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.Wins == wins ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleStats> SelectByDefeats ( int defeats )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.Defeats == defeats ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByDefeats ( int defeats )
		{
			return (long) SelectByDefeats ( defeats ).Count;
		}

		public IList<BattleStats> SelectByDefeats ( int start, int count, int defeats )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.Defeats == defeats ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleStats> SelectByType ( string type )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
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

		public IList<BattleStats> SelectByType ( int start, int count, string type )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleStats> SelectByDetail ( string detail )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.Detail == detail ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByDetail ( string detail )
		{
			return (long) SelectByDetail ( detail ).Count;
		}

		public IList<BattleStats> SelectByDetail ( int start, int count, string detail )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.Detail == detail ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleStats> SelectByGiveUps ( int giveUps )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.GiveUps == giveUps ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByGiveUps ( int giveUps )
		{
			return (long) SelectByGiveUps ( giveUps ).Count;
		}

		public IList<BattleStats> SelectByGiveUps ( int start, int count, int giveUps )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.GiveUps == giveUps ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleStats> SelectByStats ( PrincipalStats stats )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.Stats == stats ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByStats ( PrincipalStats stats )
		{
			return (long) SelectByStats ( stats ).Count;
		}

		public IList<BattleStats> SelectByStats ( int start, int count, PrincipalStats stats )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.Stats == stats ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleStats> SelectByPlayerStats ( PlayerStats playerStats )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.PlayerStats == playerStats ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPlayerStats ( PlayerStats playerStats )
		{
			return (long) SelectByPlayerStats ( playerStats ).Count;
		}

		public IList<BattleStats> SelectByPlayerStats ( int start, int count, PlayerStats playerStats )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.PlayerStats == playerStats ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleStats> SelectByCreatedDate ( DateTime createdDate )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
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

		public IList<BattleStats> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleStats> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
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

		public IList<BattleStats> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BattleStats> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
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

		public IList<BattleStats> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<BattleStats> container = new List<BattleStats>();
 			
			foreach( BattleStats obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
