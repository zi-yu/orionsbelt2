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
    /// Handles persistance for UniverseSpecialSector objects
    /// </summary>
	public interface IUniverseSpecialSectorPersistance : IPersistance<UniverseSpecialSector> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all UniverseSpecialSector based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectById ( int id );

        /// <summary>
        /// Gets the number of UniverseSpecialSector with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all UniverseSpecialSector based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all UniverseSpecialSector based on the systemX field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectBySystemX ( int systemX );

        /// <summary>
        /// Gets the number of UniverseSpecialSector with the given systemX
        /// </summary>
        /// <param name="id">The systemX</param>
        /// <returns>The count</returns>
        long CountBySystemX ( int systemX );
        
		/// <summary>
        /// Selects all UniverseSpecialSector based on the systemX field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectBySystemX ( int start, int count, int systemX );
		
 		/// <summary>
        /// Selects all UniverseSpecialSector based on the systemY field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectBySystemY ( int systemY );

        /// <summary>
        /// Gets the number of UniverseSpecialSector with the given systemY
        /// </summary>
        /// <param name="id">The systemY</param>
        /// <returns>The count</returns>
        long CountBySystemY ( int systemY );
        
		/// <summary>
        /// Selects all UniverseSpecialSector based on the systemY field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectBySystemY ( int start, int count, int systemY );
		
 		/// <summary>
        /// Selects all UniverseSpecialSector based on the sectorX field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectBySectorX ( int sectorX );

        /// <summary>
        /// Gets the number of UniverseSpecialSector with the given sectorX
        /// </summary>
        /// <param name="id">The sectorX</param>
        /// <returns>The count</returns>
        long CountBySectorX ( int sectorX );
        
		/// <summary>
        /// Selects all UniverseSpecialSector based on the sectorX field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectBySectorX ( int start, int count, int sectorX );
		
 		/// <summary>
        /// Selects all UniverseSpecialSector based on the sectorY field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectBySectorY ( int sectorY );

        /// <summary>
        /// Gets the number of UniverseSpecialSector with the given sectorY
        /// </summary>
        /// <param name="id">The sectorY</param>
        /// <returns>The count</returns>
        long CountBySectorY ( int sectorY );
        
		/// <summary>
        /// Selects all UniverseSpecialSector based on the sectorY field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectBySectorY ( int start, int count, int sectorY );
		
 		/// <summary>
        /// Selects all UniverseSpecialSector based on the type field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectByType ( string type );

        /// <summary>
        /// Gets the number of UniverseSpecialSector with the given type
        /// </summary>
        /// <param name="id">The type</param>
        /// <returns>The count</returns>
        long CountByType ( string type );
        
		/// <summary>
        /// Selects all UniverseSpecialSector based on the type field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectByType ( int start, int count, string type );
		
 		/// <summary>
        /// Selects all UniverseSpecialSector based on the owner field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectByOwner ( PlayerStorage owner );

        /// <summary>
        /// Gets the number of UniverseSpecialSector with the given owner
        /// </summary>
        /// <param name="id">The owner</param>
        /// <returns>The count</returns>
        long CountByOwner ( PlayerStorage owner );
        
		/// <summary>
        /// Selects all UniverseSpecialSector based on the owner field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectByOwner ( int start, int count, PlayerStorage owner );
		
 		/// <summary>
        /// Selects all UniverseSpecialSector based on the sector field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectBySector ( SectorStorage sector );

        /// <summary>
        /// Gets the number of UniverseSpecialSector with the given sector
        /// </summary>
        /// <param name="id">The sector</param>
        /// <returns>The count</returns>
        long CountBySector ( SectorStorage sector );
        
		/// <summary>
        /// Selects all UniverseSpecialSector based on the sector field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The UniverseSpecialSector collection</returns>
		IList<UniverseSpecialSector> SelectBySector ( int start, int count, SectorStorage sector );
		
 		#endregion ExtendedMethods

	};
}
