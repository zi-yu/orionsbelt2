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
	internal class MemoryFleetPersistance : 
			MemoryPersistance<Fleet>, IFleetPersistance {
		
		#region IPersistance
		
		public override Fleet Create()
		{
			return new SpecializedMemoryFleet ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Fleet> SelectById ( int id )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
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

		public IList<Fleet> SelectById ( int start, int count, int id )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByName ( string name )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
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

		public IList<Fleet> SelectByName ( int start, int count, string name )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByUnits ( string units )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.Units == units ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUnits ( string units )
		{
			return (long) SelectByUnits ( units ).Count;
		}

		public IList<Fleet> SelectByUnits ( int start, int count, string units )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.Units == units ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByTournamentFleet ( bool tournamentFleet )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.TournamentFleet == tournamentFleet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTournamentFleet ( bool tournamentFleet )
		{
			return (long) SelectByTournamentFleet ( tournamentFleet ).Count;
		}

		public IList<Fleet> SelectByTournamentFleet ( int start, int count, bool tournamentFleet )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.TournamentFleet == tournamentFleet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByIsMovable ( bool isMovable )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.IsMovable == isMovable ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsMovable ( bool isMovable )
		{
			return (long) SelectByIsMovable ( isMovable ).Count;
		}

		public IList<Fleet> SelectByIsMovable ( int start, int count, bool isMovable )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.IsMovable == isMovable ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByUltimateUnit ( string ultimateUnit )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
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

		public IList<Fleet> SelectByUltimateUnit ( int start, int count, string ultimateUnit )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.UltimateUnit == ultimateUnit ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByIsInBattle ( bool isInBattle )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.IsInBattle == isInBattle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsInBattle ( bool isInBattle )
		{
			return (long) SelectByIsInBattle ( isInBattle ).Count;
		}

		public IList<Fleet> SelectByIsInBattle ( int start, int count, bool isInBattle )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.IsInBattle == isInBattle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByIsPlanetDefenseFleet ( bool isPlanetDefenseFleet )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.IsPlanetDefenseFleet == isPlanetDefenseFleet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsPlanetDefenseFleet ( bool isPlanetDefenseFleet )
		{
			return (long) SelectByIsPlanetDefenseFleet ( isPlanetDefenseFleet ).Count;
		}

		public IList<Fleet> SelectByIsPlanetDefenseFleet ( int start, int count, bool isPlanetDefenseFleet )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.IsPlanetDefenseFleet == isPlanetDefenseFleet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectBySystemX ( int systemX )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.SystemX == systemX ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySystemX ( int systemX )
		{
			return (long) SelectBySystemX ( systemX ).Count;
		}

		public IList<Fleet> SelectBySystemX ( int start, int count, int systemX )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.SystemX == systemX ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectBySystemY ( int systemY )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.SystemY == systemY ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySystemY ( int systemY )
		{
			return (long) SelectBySystemY ( systemY ).Count;
		}

		public IList<Fleet> SelectBySystemY ( int start, int count, int systemY )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.SystemY == systemY ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectBySectorX ( int sectorX )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.SectorX == sectorX ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySectorX ( int sectorX )
		{
			return (long) SelectBySectorX ( sectorX ).Count;
		}

		public IList<Fleet> SelectBySectorX ( int start, int count, int sectorX )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.SectorX == sectorX ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectBySectorY ( int sectorY )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.SectorY == sectorY ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySectorY ( int sectorY )
		{
			return (long) SelectBySectorY ( sectorY ).Count;
		}

		public IList<Fleet> SelectBySectorY ( int start, int count, int sectorY )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.SectorY == sectorY ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByCargo ( string cargo )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.Cargo == cargo ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCargo ( string cargo )
		{
			return (long) SelectByCargo ( cargo ).Count;
		}

		public IList<Fleet> SelectByCargo ( int start, int count, string cargo )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.Cargo == cargo ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByIsBot ( bool isBot )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.IsBot == isBot ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsBot ( bool isBot )
		{
			return (long) SelectByIsBot ( isBot ).Count;
		}

		public IList<Fleet> SelectByIsBot ( int start, int count, bool isBot )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.IsBot == isBot ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByWayPoints ( string wayPoints )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.WayPoints == wayPoints ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByWayPoints ( string wayPoints )
		{
			return (long) SelectByWayPoints ( wayPoints ).Count;
		}

		public IList<Fleet> SelectByWayPoints ( int start, int count, string wayPoints )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.WayPoints == wayPoints ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByImmunityStartTick ( int immunityStartTick )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.ImmunityStartTick == immunityStartTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByImmunityStartTick ( int immunityStartTick )
		{
			return (long) SelectByImmunityStartTick ( immunityStartTick ).Count;
		}

		public IList<Fleet> SelectByImmunityStartTick ( int start, int count, int immunityStartTick )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.ImmunityStartTick == immunityStartTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByCurrentPlanet ( PlanetStorage currentPlanet )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.CurrentPlanet == currentPlanet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCurrentPlanet ( PlanetStorage currentPlanet )
		{
			return (long) SelectByCurrentPlanet ( currentPlanet ).Count;
		}

		public IList<Fleet> SelectByCurrentPlanet ( int start, int count, PlanetStorage currentPlanet )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.CurrentPlanet == currentPlanet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByPrincipalOwner ( Principal principalOwner )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.PrincipalOwner == principalOwner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPrincipalOwner ( Principal principalOwner )
		{
			return (long) SelectByPrincipalOwner ( principalOwner ).Count;
		}

		public IList<Fleet> SelectByPrincipalOwner ( int start, int count, Principal principalOwner )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.PrincipalOwner == principalOwner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectBySector ( SectorStorage sector )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
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

		public IList<Fleet> SelectBySector ( int start, int count, SectorStorage sector )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.Sector == sector ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByPlayerOwner ( PlayerStorage playerOwner )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.PlayerOwner == playerOwner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPlayerOwner ( PlayerStorage playerOwner )
		{
			return (long) SelectByPlayerOwner ( playerOwner ).Count;
		}

		public IList<Fleet> SelectByPlayerOwner ( int start, int count, PlayerStorage playerOwner )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.PlayerOwner == playerOwner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
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

		public IList<Fleet> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
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

		public IList<Fleet> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Fleet> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
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

		public IList<Fleet> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Fleet> container = new List<Fleet>();
 			
			foreach( Fleet obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
