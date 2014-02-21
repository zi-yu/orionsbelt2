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
	internal class MemoryBattlePersistance : 
			MemoryPersistance<Battle>, IBattlePersistance {
		
		#region IPersistance
		
		public override Battle Create()
		{
			return new SpecializedMemoryBattle ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Battle> SelectById ( int id )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
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

		public IList<Battle> SelectById ( int start, int count, int id )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByCurrentTurn ( int currentTurn )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.CurrentTurn == currentTurn ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCurrentTurn ( int currentTurn )
		{
			return (long) SelectByCurrentTurn ( currentTurn ).Count;
		}

		public IList<Battle> SelectByCurrentTurn ( int start, int count, int currentTurn )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.CurrentTurn == currentTurn ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByHasEnded ( bool hasEnded )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.HasEnded == hasEnded ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByHasEnded ( bool hasEnded )
		{
			return (long) SelectByHasEnded ( hasEnded ).Count;
		}

		public IList<Battle> SelectByHasEnded ( int start, int count, bool hasEnded )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.HasEnded == hasEnded ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByBattleType ( string battleType )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
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

		public IList<Battle> SelectByBattleType ( int start, int count, string battleType )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.BattleType == battleType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByBattleMode ( string battleMode )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.BattleMode == battleMode ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBattleMode ( string battleMode )
		{
			return (long) SelectByBattleMode ( battleMode ).Count;
		}

		public IList<Battle> SelectByBattleMode ( int start, int count, string battleMode )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.BattleMode == battleMode ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByUnitsDestroyed ( string unitsDestroyed )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.UnitsDestroyed == unitsDestroyed ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUnitsDestroyed ( string unitsDestroyed )
		{
			return (long) SelectByUnitsDestroyed ( unitsDestroyed ).Count;
		}

		public IList<Battle> SelectByUnitsDestroyed ( int start, int count, string unitsDestroyed )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.UnitsDestroyed == unitsDestroyed ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByTerrain ( string terrain )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.Terrain == terrain ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTerrain ( string terrain )
		{
			return (long) SelectByTerrain ( terrain ).Count;
		}

		public IList<Battle> SelectByTerrain ( int start, int count, string terrain )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.Terrain == terrain ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByCurrentPlayer ( int currentPlayer )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.CurrentPlayer == currentPlayer ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCurrentPlayer ( int currentPlayer )
		{
			return (long) SelectByCurrentPlayer ( currentPlayer ).Count;
		}

		public IList<Battle> SelectByCurrentPlayer ( int start, int count, int currentPlayer )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.CurrentPlayer == currentPlayer ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByTimeoutsAllowed ( int timeoutsAllowed )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.TimeoutsAllowed == timeoutsAllowed ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTimeoutsAllowed ( int timeoutsAllowed )
		{
			return (long) SelectByTimeoutsAllowed ( timeoutsAllowed ).Count;
		}

		public IList<Battle> SelectByTimeoutsAllowed ( int start, int count, int timeoutsAllowed )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.TimeoutsAllowed == timeoutsAllowed ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByTournamentMode ( string tournamentMode )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.TournamentMode == tournamentMode ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTournamentMode ( string tournamentMode )
		{
			return (long) SelectByTournamentMode ( tournamentMode ).Count;
		}

		public IList<Battle> SelectByTournamentMode ( int start, int count, string tournamentMode )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.TournamentMode == tournamentMode ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByIsDeployTime ( bool isDeployTime )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.IsDeployTime == isDeployTime ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsDeployTime ( bool isDeployTime )
		{
			return (long) SelectByIsDeployTime ( isDeployTime ).Count;
		}

		public IList<Battle> SelectByIsDeployTime ( int start, int count, bool isDeployTime )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.IsDeployTime == isDeployTime ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByIsTeamBattle ( bool isTeamBattle )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.IsTeamBattle == isTeamBattle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsTeamBattle ( bool isTeamBattle )
		{
			return (long) SelectByIsTeamBattle ( isTeamBattle ).Count;
		}

		public IList<Battle> SelectByIsTeamBattle ( int start, int count, bool isTeamBattle )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.IsTeamBattle == isTeamBattle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectBySeqNumber ( double seqNumber )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.SeqNumber == seqNumber ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySeqNumber ( double seqNumber )
		{
			return (long) SelectBySeqNumber ( seqNumber ).Count;
		}

		public IList<Battle> SelectBySeqNumber ( int start, int count, double seqNumber )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.SeqNumber == seqNumber ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByIsToConquer ( bool isToConquer )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.IsToConquer == isToConquer ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsToConquer ( bool isToConquer )
		{
			return (long) SelectByIsToConquer ( isToConquer ).Count;
		}

		public IList<Battle> SelectByIsToConquer ( int start, int count, bool isToConquer )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.IsToConquer == isToConquer ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByIsInPlanet ( bool isInPlanet )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.IsInPlanet == isInPlanet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsInPlanet ( bool isInPlanet )
		{
			return (long) SelectByIsInPlanet ( isInPlanet ).Count;
		}

		public IList<Battle> SelectByIsInPlanet ( int start, int count, bool isInPlanet )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.IsInPlanet == isInPlanet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByCurrentBot ( int currentBot )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.CurrentBot == currentBot ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCurrentBot ( int currentBot )
		{
			return (long) SelectByCurrentBot ( currentBot ).Count;
		}

		public IList<Battle> SelectByCurrentBot ( int start, int count, int currentBot )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.CurrentBot == currentBot ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByTournament ( Tournament tournament )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.Tournament == tournament ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTournament ( Tournament tournament )
		{
			return (long) SelectByTournament ( tournament ).Count;
		}

		public IList<Battle> SelectByTournament ( int start, int count, Tournament tournament )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.Tournament == tournament ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByGroup ( PlayersGroupStorage group )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.Group == group ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByGroup ( PlayersGroupStorage group )
		{
			return (long) SelectByGroup ( group ).Count;
		}

		public IList<Battle> SelectByGroup ( int start, int count, PlayersGroupStorage group )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.Group == group ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
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

		public IList<Battle> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
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

		public IList<Battle> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Battle> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
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

		public IList<Battle> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Battle> container = new List<Battle>();
 			
			foreach( Battle obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
