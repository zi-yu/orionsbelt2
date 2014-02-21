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
    /// Handles persistance for Fleet objects
    /// </summary>
	public interface IFleetPersistance : IPersistance<Fleet> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Fleet based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectById ( int id );

        /// <summary>
        /// Gets the number of Fleet with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Fleet based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Fleet based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByName ( string name );

        /// <summary>
        /// Gets the number of Fleet with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all Fleet based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all Fleet based on the units field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByUnits ( string units );

        /// <summary>
        /// Gets the number of Fleet with the given units
        /// </summary>
        /// <param name="id">The units</param>
        /// <returns>The count</returns>
        long CountByUnits ( string units );
        
		/// <summary>
        /// Selects all Fleet based on the units field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByUnits ( int start, int count, string units );
		
 		/// <summary>
        /// Selects all Fleet based on the tournamentFleet field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByTournamentFleet ( bool tournamentFleet );

        /// <summary>
        /// Gets the number of Fleet with the given tournamentFleet
        /// </summary>
        /// <param name="id">The tournamentFleet</param>
        /// <returns>The count</returns>
        long CountByTournamentFleet ( bool tournamentFleet );
        
		/// <summary>
        /// Selects all Fleet based on the tournamentFleet field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByTournamentFleet ( int start, int count, bool tournamentFleet );
		
 		/// <summary>
        /// Selects all Fleet based on the isMovable field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByIsMovable ( bool isMovable );

        /// <summary>
        /// Gets the number of Fleet with the given isMovable
        /// </summary>
        /// <param name="id">The isMovable</param>
        /// <returns>The count</returns>
        long CountByIsMovable ( bool isMovable );
        
		/// <summary>
        /// Selects all Fleet based on the isMovable field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByIsMovable ( int start, int count, bool isMovable );
		
 		/// <summary>
        /// Selects all Fleet based on the ultimateUnit field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByUltimateUnit ( string ultimateUnit );

        /// <summary>
        /// Gets the number of Fleet with the given ultimateUnit
        /// </summary>
        /// <param name="id">The ultimateUnit</param>
        /// <returns>The count</returns>
        long CountByUltimateUnit ( string ultimateUnit );
        
		/// <summary>
        /// Selects all Fleet based on the ultimateUnit field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByUltimateUnit ( int start, int count, string ultimateUnit );
		
 		/// <summary>
        /// Selects all Fleet based on the isInBattle field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByIsInBattle ( bool isInBattle );

        /// <summary>
        /// Gets the number of Fleet with the given isInBattle
        /// </summary>
        /// <param name="id">The isInBattle</param>
        /// <returns>The count</returns>
        long CountByIsInBattle ( bool isInBattle );
        
		/// <summary>
        /// Selects all Fleet based on the isInBattle field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByIsInBattle ( int start, int count, bool isInBattle );
		
 		/// <summary>
        /// Selects all Fleet based on the isPlanetDefenseFleet field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByIsPlanetDefenseFleet ( bool isPlanetDefenseFleet );

        /// <summary>
        /// Gets the number of Fleet with the given isPlanetDefenseFleet
        /// </summary>
        /// <param name="id">The isPlanetDefenseFleet</param>
        /// <returns>The count</returns>
        long CountByIsPlanetDefenseFleet ( bool isPlanetDefenseFleet );
        
		/// <summary>
        /// Selects all Fleet based on the isPlanetDefenseFleet field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByIsPlanetDefenseFleet ( int start, int count, bool isPlanetDefenseFleet );
		
 		/// <summary>
        /// Selects all Fleet based on the systemX field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectBySystemX ( int systemX );

        /// <summary>
        /// Gets the number of Fleet with the given systemX
        /// </summary>
        /// <param name="id">The systemX</param>
        /// <returns>The count</returns>
        long CountBySystemX ( int systemX );
        
		/// <summary>
        /// Selects all Fleet based on the systemX field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectBySystemX ( int start, int count, int systemX );
		
 		/// <summary>
        /// Selects all Fleet based on the systemY field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectBySystemY ( int systemY );

        /// <summary>
        /// Gets the number of Fleet with the given systemY
        /// </summary>
        /// <param name="id">The systemY</param>
        /// <returns>The count</returns>
        long CountBySystemY ( int systemY );
        
		/// <summary>
        /// Selects all Fleet based on the systemY field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectBySystemY ( int start, int count, int systemY );
		
 		/// <summary>
        /// Selects all Fleet based on the sectorX field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectBySectorX ( int sectorX );

        /// <summary>
        /// Gets the number of Fleet with the given sectorX
        /// </summary>
        /// <param name="id">The sectorX</param>
        /// <returns>The count</returns>
        long CountBySectorX ( int sectorX );
        
		/// <summary>
        /// Selects all Fleet based on the sectorX field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectBySectorX ( int start, int count, int sectorX );
		
 		/// <summary>
        /// Selects all Fleet based on the sectorY field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectBySectorY ( int sectorY );

        /// <summary>
        /// Gets the number of Fleet with the given sectorY
        /// </summary>
        /// <param name="id">The sectorY</param>
        /// <returns>The count</returns>
        long CountBySectorY ( int sectorY );
        
		/// <summary>
        /// Selects all Fleet based on the sectorY field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectBySectorY ( int start, int count, int sectorY );
		
 		/// <summary>
        /// Selects all Fleet based on the cargo field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByCargo ( string cargo );

        /// <summary>
        /// Gets the number of Fleet with the given cargo
        /// </summary>
        /// <param name="id">The cargo</param>
        /// <returns>The count</returns>
        long CountByCargo ( string cargo );
        
		/// <summary>
        /// Selects all Fleet based on the cargo field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByCargo ( int start, int count, string cargo );
		
 		/// <summary>
        /// Selects all Fleet based on the isBot field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByIsBot ( bool isBot );

        /// <summary>
        /// Gets the number of Fleet with the given isBot
        /// </summary>
        /// <param name="id">The isBot</param>
        /// <returns>The count</returns>
        long CountByIsBot ( bool isBot );
        
		/// <summary>
        /// Selects all Fleet based on the isBot field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByIsBot ( int start, int count, bool isBot );
		
 		/// <summary>
        /// Selects all Fleet based on the wayPoints field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByWayPoints ( string wayPoints );

        /// <summary>
        /// Gets the number of Fleet with the given wayPoints
        /// </summary>
        /// <param name="id">The wayPoints</param>
        /// <returns>The count</returns>
        long CountByWayPoints ( string wayPoints );
        
		/// <summary>
        /// Selects all Fleet based on the wayPoints field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByWayPoints ( int start, int count, string wayPoints );
		
 		/// <summary>
        /// Selects all Fleet based on the immunityStartTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByImmunityStartTick ( int immunityStartTick );

        /// <summary>
        /// Gets the number of Fleet with the given immunityStartTick
        /// </summary>
        /// <param name="id">The immunityStartTick</param>
        /// <returns>The count</returns>
        long CountByImmunityStartTick ( int immunityStartTick );
        
		/// <summary>
        /// Selects all Fleet based on the immunityStartTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByImmunityStartTick ( int start, int count, int immunityStartTick );
		
 		/// <summary>
        /// Selects all Fleet based on the currentPlanet field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByCurrentPlanet ( PlanetStorage currentPlanet );

        /// <summary>
        /// Gets the number of Fleet with the given currentPlanet
        /// </summary>
        /// <param name="id">The currentPlanet</param>
        /// <returns>The count</returns>
        long CountByCurrentPlanet ( PlanetStorage currentPlanet );
        
		/// <summary>
        /// Selects all Fleet based on the currentPlanet field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByCurrentPlanet ( int start, int count, PlanetStorage currentPlanet );
		
 		/// <summary>
        /// Selects all Fleet based on the principalOwner field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByPrincipalOwner ( Principal principalOwner );

        /// <summary>
        /// Gets the number of Fleet with the given principalOwner
        /// </summary>
        /// <param name="id">The principalOwner</param>
        /// <returns>The count</returns>
        long CountByPrincipalOwner ( Principal principalOwner );
        
		/// <summary>
        /// Selects all Fleet based on the principalOwner field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByPrincipalOwner ( int start, int count, Principal principalOwner );
		
 		/// <summary>
        /// Selects all Fleet based on the sector field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectBySector ( SectorStorage sector );

        /// <summary>
        /// Gets the number of Fleet with the given sector
        /// </summary>
        /// <param name="id">The sector</param>
        /// <returns>The count</returns>
        long CountBySector ( SectorStorage sector );
        
		/// <summary>
        /// Selects all Fleet based on the sector field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectBySector ( int start, int count, SectorStorage sector );
		
 		/// <summary>
        /// Selects all Fleet based on the playerOwner field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByPlayerOwner ( PlayerStorage playerOwner );

        /// <summary>
        /// Gets the number of Fleet with the given playerOwner
        /// </summary>
        /// <param name="id">The playerOwner</param>
        /// <returns>The count</returns>
        long CountByPlayerOwner ( PlayerStorage playerOwner );
        
		/// <summary>
        /// Selects all Fleet based on the playerOwner field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Fleet collection</returns>
		IList<Fleet> SelectByPlayerOwner ( int start, int count, PlayerStorage playerOwner );
		
 		#endregion ExtendedMethods

	};
}
