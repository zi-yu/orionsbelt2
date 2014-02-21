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
	internal class MemoryPlayerBattleInformationPersistance : 
			MemoryPersistance<PlayerBattleInformation>, IPlayerBattleInformationPersistance {
		
		#region IPersistance
		
		public override PlayerBattleInformation Create()
		{
			return new SpecializedMemoryPlayerBattleInformation ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<PlayerBattleInformation> SelectById ( int id )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
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

		public IList<PlayerBattleInformation> SelectById ( int start, int count, int id )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByInitialContainer ( string initialContainer )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.InitialContainer == initialContainer ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByInitialContainer ( string initialContainer )
		{
			return (long) SelectByInitialContainer ( initialContainer ).Count;
		}

		public IList<PlayerBattleInformation> SelectByInitialContainer ( int start, int count, string initialContainer )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.InitialContainer == initialContainer ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByHasPositioned ( bool hasPositioned )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.HasPositioned == hasPositioned ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByHasPositioned ( bool hasPositioned )
		{
			return (long) SelectByHasPositioned ( hasPositioned ).Count;
		}

		public IList<PlayerBattleInformation> SelectByHasPositioned ( int start, int count, bool hasPositioned )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.HasPositioned == hasPositioned ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByTeamNumber ( int teamNumber )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.TeamNumber == teamNumber ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTeamNumber ( int teamNumber )
		{
			return (long) SelectByTeamNumber ( teamNumber ).Count;
		}

		public IList<PlayerBattleInformation> SelectByTeamNumber ( int start, int count, int teamNumber )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.TeamNumber == teamNumber ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByHasLost ( bool hasLost )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.HasLost == hasLost ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByHasLost ( bool hasLost )
		{
			return (long) SelectByHasLost ( hasLost ).Count;
		}

		public IList<PlayerBattleInformation> SelectByHasLost ( int start, int count, bool hasLost )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.HasLost == hasLost ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByWinScore ( int winScore )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.WinScore == winScore ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByWinScore ( int winScore )
		{
			return (long) SelectByWinScore ( winScore ).Count;
		}

		public IList<PlayerBattleInformation> SelectByWinScore ( int start, int count, int winScore )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.WinScore == winScore ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByFleetId ( int fleetId )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.FleetId == fleetId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByFleetId ( int fleetId )
		{
			return (long) SelectByFleetId ( fleetId ).Count;
		}

		public IList<PlayerBattleInformation> SelectByFleetId ( int start, int count, int fleetId )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.FleetId == fleetId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByUpdateFleet ( bool updateFleet )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.UpdateFleet == updateFleet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUpdateFleet ( bool updateFleet )
		{
			return (long) SelectByUpdateFleet ( updateFleet ).Count;
		}

		public IList<PlayerBattleInformation> SelectByUpdateFleet ( int start, int count, bool updateFleet )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.UpdateFleet == updateFleet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByHasGaveUp ( bool hasGaveUp )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.HasGaveUp == hasGaveUp ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByHasGaveUp ( bool hasGaveUp )
		{
			return (long) SelectByHasGaveUp ( hasGaveUp ).Count;
		}

		public IList<PlayerBattleInformation> SelectByHasGaveUp ( int start, int count, bool hasGaveUp )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.HasGaveUp == hasGaveUp ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByLoseScore ( int loseScore )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.LoseScore == loseScore ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLoseScore ( int loseScore )
		{
			return (long) SelectByLoseScore ( loseScore ).Count;
		}

		public IList<PlayerBattleInformation> SelectByLoseScore ( int start, int count, int loseScore )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.LoseScore == loseScore ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByVictoryPercentage ( int victoryPercentage )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.VictoryPercentage == victoryPercentage ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByVictoryPercentage ( int victoryPercentage )
		{
			return (long) SelectByVictoryPercentage ( victoryPercentage ).Count;
		}

		public IList<PlayerBattleInformation> SelectByVictoryPercentage ( int start, int count, int victoryPercentage )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.VictoryPercentage == victoryPercentage ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByDominationPoints ( int dominationPoints )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.DominationPoints == dominationPoints ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByDominationPoints ( int dominationPoints )
		{
			return (long) SelectByDominationPoints ( dominationPoints ).Count;
		}

		public IList<PlayerBattleInformation> SelectByDominationPoints ( int start, int count, int dominationPoints )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.DominationPoints == dominationPoints ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByTimeouts ( int timeouts )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.Timeouts == timeouts ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTimeouts ( int timeouts )
		{
			return (long) SelectByTimeouts ( timeouts ).Count;
		}

		public IList<PlayerBattleInformation> SelectByTimeouts ( int start, int count, int timeouts )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.Timeouts == timeouts ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByOwner ( int owner )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.Owner == owner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByOwner ( int owner )
		{
			return (long) SelectByOwner ( owner ).Count;
		}

		public IList<PlayerBattleInformation> SelectByOwner ( int start, int count, int owner )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.Owner == owner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByName ( string name )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
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

		public IList<PlayerBattleInformation> SelectByName ( int start, int count, string name )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByTeamName ( string teamName )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.TeamName == teamName ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTeamName ( string teamName )
		{
			return (long) SelectByTeamName ( teamName ).Count;
		}

		public IList<PlayerBattleInformation> SelectByTeamName ( int start, int count, string teamName )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.TeamName == teamName ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByUltimateUnit ( string ultimateUnit )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.UltimateUnit == ultimateUnit ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUltimateUnit ( string ultimateUnit )
		{
			return (long) SelectByUltimateUnit ( ultimateUnit ).Count;
		}

		public IList<PlayerBattleInformation> SelectByUltimateUnit ( int start, int count, string ultimateUnit )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.UltimateUnit == ultimateUnit ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByBotId ( int botId )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.BotId == botId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBotId ( int botId )
		{
			return (long) SelectByBotId ( botId ).Count;
		}

		public IList<PlayerBattleInformation> SelectByBotId ( int start, int count, int botId )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.BotId == botId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByBattle ( Battle battle )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
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

		public IList<PlayerBattleInformation> SelectByBattle ( int start, int count, Battle battle )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.Battle == battle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByCreatedDate ( DateTime createdDate )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
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

		public IList<PlayerBattleInformation> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
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

		public IList<PlayerBattleInformation> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerBattleInformation> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
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

		public IList<PlayerBattleInformation> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<PlayerBattleInformation> container = new List<PlayerBattleInformation>();
 			
			foreach( PlayerBattleInformation obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
