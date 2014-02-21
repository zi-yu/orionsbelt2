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
    /// Handles persistance for PlanetStorage objects
    /// </summary>
	public interface IPlanetStoragePersistance : IPersistance<PlanetStorage> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all PlanetStorage based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectById ( int id );

        /// <summary>
        /// Gets the number of PlanetStorage with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all PlanetStorage based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByName ( string name );

        /// <summary>
        /// Gets the number of PlanetStorage with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all PlanetStorage based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the productionFactor field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByProductionFactor ( double productionFactor );

        /// <summary>
        /// Gets the number of PlanetStorage with the given productionFactor
        /// </summary>
        /// <param name="id">The productionFactor</param>
        /// <returns>The count</returns>
        long CountByProductionFactor ( double productionFactor );
        
		/// <summary>
        /// Selects all PlanetStorage based on the productionFactor field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByProductionFactor ( int start, int count, double productionFactor );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the modifiers field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByModifiers ( string modifiers );

        /// <summary>
        /// Gets the number of PlanetStorage with the given modifiers
        /// </summary>
        /// <param name="id">The modifiers</param>
        /// <returns>The count</returns>
        long CountByModifiers ( string modifiers );
        
		/// <summary>
        /// Selects all PlanetStorage based on the modifiers field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByModifiers ( int start, int count, string modifiers );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the richness field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByRichness ( string richness );

        /// <summary>
        /// Gets the number of PlanetStorage with the given richness
        /// </summary>
        /// <param name="id">The richness</param>
        /// <returns>The count</returns>
        long CountByRichness ( string richness );
        
		/// <summary>
        /// Selects all PlanetStorage based on the richness field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByRichness ( int start, int count, string richness );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the info field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByInfo ( string info );

        /// <summary>
        /// Gets the number of PlanetStorage with the given info
        /// </summary>
        /// <param name="id">The info</param>
        /// <returns>The count</returns>
        long CountByInfo ( string info );
        
		/// <summary>
        /// Selects all PlanetStorage based on the info field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByInfo ( int start, int count, string info );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the terrain field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByTerrain ( string terrain );

        /// <summary>
        /// Gets the number of PlanetStorage with the given terrain
        /// </summary>
        /// <param name="id">The terrain</param>
        /// <returns>The count</returns>
        long CountByTerrain ( string terrain );
        
		/// <summary>
        /// Selects all PlanetStorage based on the terrain field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByTerrain ( int start, int count, string terrain );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the isPrivate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByIsPrivate ( bool isPrivate );

        /// <summary>
        /// Gets the number of PlanetStorage with the given isPrivate
        /// </summary>
        /// <param name="id">The isPrivate</param>
        /// <returns>The count</returns>
        long CountByIsPrivate ( bool isPrivate );
        
		/// <summary>
        /// Selects all PlanetStorage based on the isPrivate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByIsPrivate ( int start, int count, bool isPrivate );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the systemX field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectBySystemX ( int systemX );

        /// <summary>
        /// Gets the number of PlanetStorage with the given systemX
        /// </summary>
        /// <param name="id">The systemX</param>
        /// <returns>The count</returns>
        long CountBySystemX ( int systemX );
        
		/// <summary>
        /// Selects all PlanetStorage based on the systemX field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectBySystemX ( int start, int count, int systemX );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the systemY field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectBySystemY ( int systemY );

        /// <summary>
        /// Gets the number of PlanetStorage with the given systemY
        /// </summary>
        /// <param name="id">The systemY</param>
        /// <returns>The count</returns>
        long CountBySystemY ( int systemY );
        
		/// <summary>
        /// Selects all PlanetStorage based on the systemY field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectBySystemY ( int start, int count, int systemY );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the sectorX field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectBySectorX ( int sectorX );

        /// <summary>
        /// Gets the number of PlanetStorage with the given sectorX
        /// </summary>
        /// <param name="id">The sectorX</param>
        /// <returns>The count</returns>
        long CountBySectorX ( int sectorX );
        
		/// <summary>
        /// Selects all PlanetStorage based on the sectorX field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectBySectorX ( int start, int count, int sectorX );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the sectorY field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectBySectorY ( int sectorY );

        /// <summary>
        /// Gets the number of PlanetStorage with the given sectorY
        /// </summary>
        /// <param name="id">The sectorY</param>
        /// <returns>The count</returns>
        long CountBySectorY ( int sectorY );
        
		/// <summary>
        /// Selects all PlanetStorage based on the sectorY field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectBySectorY ( int start, int count, int sectorY );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the score field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByScore ( int score );

        /// <summary>
        /// Gets the number of PlanetStorage with the given score
        /// </summary>
        /// <param name="id">The score</param>
        /// <returns>The count</returns>
        long CountByScore ( int score );
        
		/// <summary>
        /// Selects all PlanetStorage based on the score field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByScore ( int start, int count, int score );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the level field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByLevel ( int level );

        /// <summary>
        /// Gets the number of PlanetStorage with the given level
        /// </summary>
        /// <param name="id">The level</param>
        /// <returns>The count</returns>
        long CountByLevel ( int level );
        
		/// <summary>
        /// Selects all PlanetStorage based on the level field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByLevel ( int start, int count, int level );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the lastPillageTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByLastPillageTick ( int lastPillageTick );

        /// <summary>
        /// Gets the number of PlanetStorage with the given lastPillageTick
        /// </summary>
        /// <param name="id">The lastPillageTick</param>
        /// <returns>The count</returns>
        long CountByLastPillageTick ( int lastPillageTick );
        
		/// <summary>
        /// Selects all PlanetStorage based on the lastPillageTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByLastPillageTick ( int start, int count, int lastPillageTick );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the lastConquerTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByLastConquerTick ( int lastConquerTick );

        /// <summary>
        /// Gets the number of PlanetStorage with the given lastConquerTick
        /// </summary>
        /// <param name="id">The lastConquerTick</param>
        /// <returns>The count</returns>
        long CountByLastConquerTick ( int lastConquerTick );
        
		/// <summary>
        /// Selects all PlanetStorage based on the lastConquerTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByLastConquerTick ( int start, int count, int lastConquerTick );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the facilityLevel field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByFacilityLevel ( int facilityLevel );

        /// <summary>
        /// Gets the number of PlanetStorage with the given facilityLevel
        /// </summary>
        /// <param name="id">The facilityLevel</param>
        /// <returns>The count</returns>
        long CountByFacilityLevel ( int facilityLevel );
        
		/// <summary>
        /// Selects all PlanetStorage based on the facilityLevel field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByFacilityLevel ( int start, int count, int facilityLevel );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the player field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByPlayer ( PlayerStorage player );

        /// <summary>
        /// Gets the number of PlanetStorage with the given player
        /// </summary>
        /// <param name="id">The player</param>
        /// <returns>The count</returns>
        long CountByPlayer ( PlayerStorage player );
        
		/// <summary>
        /// Selects all PlanetStorage based on the player field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectByPlayer ( int start, int count, PlayerStorage player );
		
 		/// <summary>
        /// Selects all PlanetStorage based on the sector field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectBySector ( SectorStorage sector );

        /// <summary>
        /// Gets the number of PlanetStorage with the given sector
        /// </summary>
        /// <param name="id">The sector</param>
        /// <returns>The count</returns>
        long CountBySector ( SectorStorage sector );
        
		/// <summary>
        /// Selects all PlanetStorage based on the sector field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetStorage collection</returns>
		IList<PlanetStorage> SelectBySector ( int start, int count, SectorStorage sector );
		
 		#endregion ExtendedMethods

	};
}
