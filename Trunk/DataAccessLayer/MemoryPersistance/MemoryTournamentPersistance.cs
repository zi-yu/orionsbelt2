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
	internal class MemoryTournamentPersistance : 
			MemoryPersistance<Tournament>, ITournamentPersistance {
		
		#region IPersistance
		
		public override Tournament Create()
		{
			return new SpecializedMemoryTournament ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Tournament> SelectById ( int id )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
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

		public IList<Tournament> SelectById ( int start, int count, int id )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByName ( string name )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
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

		public IList<Tournament> SelectByName ( int start, int count, string name )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByWarningTick ( int warningTick )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.WarningTick == warningTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByWarningTick ( int warningTick )
		{
			return (long) SelectByWarningTick ( warningTick ).Count;
		}

		public IList<Tournament> SelectByWarningTick ( int start, int count, int warningTick )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.WarningTick == warningTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByPrize ( string prize )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.Prize == prize ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPrize ( string prize )
		{
			return (long) SelectByPrize ( prize ).Count;
		}

		public IList<Tournament> SelectByPrize ( int start, int count, string prize )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.Prize == prize ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByCostCredits ( int costCredits )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.CostCredits == costCredits ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCostCredits ( int costCredits )
		{
			return (long) SelectByCostCredits ( costCredits ).Count;
		}

		public IList<Tournament> SelectByCostCredits ( int start, int count, int costCredits )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.CostCredits == costCredits ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByTournamentType ( string tournamentType )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.TournamentType == tournamentType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTournamentType ( string tournamentType )
		{
			return (long) SelectByTournamentType ( tournamentType ).Count;
		}

		public IList<Tournament> SelectByTournamentType ( int start, int count, string tournamentType )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.TournamentType == tournamentType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByFleetId ( int fleetId )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
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

		public IList<Tournament> SelectByFleetId ( int start, int count, int fleetId )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.FleetId == fleetId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByIsPublic ( bool isPublic )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.IsPublic == isPublic ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsPublic ( bool isPublic )
		{
			return (long) SelectByIsPublic ( isPublic ).Count;
		}

		public IList<Tournament> SelectByIsPublic ( int start, int count, bool isPublic )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.IsPublic == isPublic ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByIsSurvival ( bool isSurvival )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.IsSurvival == isSurvival ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsSurvival ( bool isSurvival )
		{
			return (long) SelectByIsSurvival ( isSurvival ).Count;
		}

		public IList<Tournament> SelectByIsSurvival ( int start, int count, bool isSurvival )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.IsSurvival == isSurvival ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByTurnTime ( int turnTime )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.TurnTime == turnTime ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTurnTime ( int turnTime )
		{
			return (long) SelectByTurnTime ( turnTime ).Count;
		}

		public IList<Tournament> SelectByTurnTime ( int start, int count, int turnTime )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.TurnTime == turnTime ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectBySubscriptionTime ( int subscriptionTime )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.SubscriptionTime == subscriptionTime ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySubscriptionTime ( int subscriptionTime )
		{
			return (long) SelectBySubscriptionTime ( subscriptionTime ).Count;
		}

		public IList<Tournament> SelectBySubscriptionTime ( int start, int count, int subscriptionTime )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.SubscriptionTime == subscriptionTime ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByMaxPlayers ( int maxPlayers )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.MaxPlayers == maxPlayers ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMaxPlayers ( int maxPlayers )
		{
			return (long) SelectByMaxPlayers ( maxPlayers ).Count;
		}

		public IList<Tournament> SelectByMaxPlayers ( int start, int count, int maxPlayers )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.MaxPlayers == maxPlayers ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByMinPlayers ( int minPlayers )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.MinPlayers == minPlayers ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMinPlayers ( int minPlayers )
		{
			return (long) SelectByMinPlayers ( minPlayers ).Count;
		}

		public IList<Tournament> SelectByMinPlayers ( int start, int count, int minPlayers )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.MinPlayers == minPlayers ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByNPlayersToPlayoff ( int nPlayersToPlayoff )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.NPlayersToPlayoff == nPlayersToPlayoff ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByNPlayersToPlayoff ( int nPlayersToPlayoff )
		{
			return (long) SelectByNPlayersToPlayoff ( nPlayersToPlayoff ).Count;
		}

		public IList<Tournament> SelectByNPlayersToPlayoff ( int start, int count, int nPlayersToPlayoff )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.NPlayersToPlayoff == nPlayersToPlayoff ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByMaxElo ( int maxElo )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.MaxElo == maxElo ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMaxElo ( int maxElo )
		{
			return (long) SelectByMaxElo ( maxElo ).Count;
		}

		public IList<Tournament> SelectByMaxElo ( int start, int count, int maxElo )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.MaxElo == maxElo ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByMinElo ( int minElo )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.MinElo == minElo ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMinElo ( int minElo )
		{
			return (long) SelectByMinElo ( minElo ).Count;
		}

		public IList<Tournament> SelectByMinElo ( int start, int count, int minElo )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.MinElo == minElo ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByStartTime ( DateTime startTime )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.StartTime == startTime ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByStartTime ( DateTime startTime )
		{
			return (long) SelectByStartTime ( startTime ).Count;
		}

		public IList<Tournament> SelectByStartTime ( int start, int count, DateTime startTime )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.StartTime == startTime ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByEndDate ( DateTime endDate )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.EndDate == endDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByEndDate ( DateTime endDate )
		{
			return (long) SelectByEndDate ( endDate ).Count;
		}

		public IList<Tournament> SelectByEndDate ( int start, int count, DateTime endDate )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.EndDate == endDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByToken ( string token )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.Token == token ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByToken ( string token )
		{
			return (long) SelectByToken ( token ).Count;
		}

		public IList<Tournament> SelectByToken ( int start, int count, string token )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.Token == token ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByTokenNumber ( int tokenNumber )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.TokenNumber == tokenNumber ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTokenNumber ( int tokenNumber )
		{
			return (long) SelectByTokenNumber ( tokenNumber ).Count;
		}

		public IList<Tournament> SelectByTokenNumber ( int start, int count, int tokenNumber )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.TokenNumber == tokenNumber ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByIsCustom ( bool isCustom )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.IsCustom == isCustom ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsCustom ( bool isCustom )
		{
			return (long) SelectByIsCustom ( isCustom ).Count;
		}

		public IList<Tournament> SelectByIsCustom ( int start, int count, bool isCustom )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.IsCustom == isCustom ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByPaymentsRequired ( int paymentsRequired )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.PaymentsRequired == paymentsRequired ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPaymentsRequired ( int paymentsRequired )
		{
			return (long) SelectByPaymentsRequired ( paymentsRequired ).Count;
		}

		public IList<Tournament> SelectByPaymentsRequired ( int start, int count, int paymentsRequired )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.PaymentsRequired == paymentsRequired ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByNumberPassGroup ( int numberPassGroup )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.NumberPassGroup == numberPassGroup ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByNumberPassGroup ( int numberPassGroup )
		{
			return (long) SelectByNumberPassGroup ( numberPassGroup ).Count;
		}

		public IList<Tournament> SelectByNumberPassGroup ( int start, int count, int numberPassGroup )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.NumberPassGroup == numberPassGroup ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByDescriptionToken ( string descriptionToken )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.DescriptionToken == descriptionToken ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByDescriptionToken ( string descriptionToken )
		{
			return (long) SelectByDescriptionToken ( descriptionToken ).Count;
		}

		public IList<Tournament> SelectByDescriptionToken ( int start, int count, string descriptionToken )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.DescriptionToken == descriptionToken ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
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

		public IList<Tournament> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
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

		public IList<Tournament> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Tournament> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
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

		public IList<Tournament> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Tournament> container = new List<Tournament>();
 			
			foreach( Tournament obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
