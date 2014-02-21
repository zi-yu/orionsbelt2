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
    /// Handles persistance for SectorStorage objects
    /// </summary>
	public interface ISectorStoragePersistance : IPersistance<SectorStorage> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all SectorStorage based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectById ( int id );

        /// <summary>
        /// Gets the number of SectorStorage with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all SectorStorage based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all SectorStorage based on the isStatic field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByIsStatic ( bool isStatic );

        /// <summary>
        /// Gets the number of SectorStorage with the given isStatic
        /// </summary>
        /// <param name="id">The isStatic</param>
        /// <returns>The count</returns>
        long CountByIsStatic ( bool isStatic );
        
		/// <summary>
        /// Selects all SectorStorage based on the isStatic field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByIsStatic ( int start, int count, bool isStatic );
		
 		/// <summary>
        /// Selects all SectorStorage based on the type field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByType ( string type );

        /// <summary>
        /// Gets the number of SectorStorage with the given type
        /// </summary>
        /// <param name="id">The type</param>
        /// <returns>The count</returns>
        long CountByType ( string type );
        
		/// <summary>
        /// Selects all SectorStorage based on the type field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByType ( int start, int count, string type );
		
 		/// <summary>
        /// Selects all SectorStorage based on the subType field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectBySubType ( string subType );

        /// <summary>
        /// Gets the number of SectorStorage with the given subType
        /// </summary>
        /// <param name="id">The subType</param>
        /// <returns>The count</returns>
        long CountBySubType ( string subType );
        
		/// <summary>
        /// Selects all SectorStorage based on the subType field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectBySubType ( int start, int count, string subType );
		
 		/// <summary>
        /// Selects all SectorStorage based on the systemX field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectBySystemX ( int systemX );

        /// <summary>
        /// Gets the number of SectorStorage with the given systemX
        /// </summary>
        /// <param name="id">The systemX</param>
        /// <returns>The count</returns>
        long CountBySystemX ( int systemX );
        
		/// <summary>
        /// Selects all SectorStorage based on the systemX field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectBySystemX ( int start, int count, int systemX );
		
 		/// <summary>
        /// Selects all SectorStorage based on the systemY field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectBySystemY ( int systemY );

        /// <summary>
        /// Gets the number of SectorStorage with the given systemY
        /// </summary>
        /// <param name="id">The systemY</param>
        /// <returns>The count</returns>
        long CountBySystemY ( int systemY );
        
		/// <summary>
        /// Selects all SectorStorage based on the systemY field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectBySystemY ( int start, int count, int systemY );
		
 		/// <summary>
        /// Selects all SectorStorage based on the sectorX field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectBySectorX ( int sectorX );

        /// <summary>
        /// Gets the number of SectorStorage with the given sectorX
        /// </summary>
        /// <param name="id">The sectorX</param>
        /// <returns>The count</returns>
        long CountBySectorX ( int sectorX );
        
		/// <summary>
        /// Selects all SectorStorage based on the sectorX field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectBySectorX ( int start, int count, int sectorX );
		
 		/// <summary>
        /// Selects all SectorStorage based on the sectorY field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectBySectorY ( int sectorY );

        /// <summary>
        /// Gets the number of SectorStorage with the given sectorY
        /// </summary>
        /// <param name="id">The sectorY</param>
        /// <returns>The count</returns>
        long CountBySectorY ( int sectorY );
        
		/// <summary>
        /// Selects all SectorStorage based on the sectorY field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectBySectorY ( int start, int count, int sectorY );
		
 		/// <summary>
        /// Selects all SectorStorage based on the additionalInformation field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByAdditionalInformation ( string additionalInformation );

        /// <summary>
        /// Gets the number of SectorStorage with the given additionalInformation
        /// </summary>
        /// <param name="id">The additionalInformation</param>
        /// <returns>The count</returns>
        long CountByAdditionalInformation ( string additionalInformation );
        
		/// <summary>
        /// Selects all SectorStorage based on the additionalInformation field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByAdditionalInformation ( int start, int count, string additionalInformation );
		
 		/// <summary>
        /// Selects all SectorStorage based on the isInBattle field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByIsInBattle ( bool isInBattle );

        /// <summary>
        /// Gets the number of SectorStorage with the given isInBattle
        /// </summary>
        /// <param name="id">The isInBattle</param>
        /// <returns>The count</returns>
        long CountByIsInBattle ( bool isInBattle );
        
		/// <summary>
        /// Selects all SectorStorage based on the isInBattle field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByIsInBattle ( int start, int count, bool isInBattle );
		
 		/// <summary>
        /// Selects all SectorStorage based on the isConstructing field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByIsConstructing ( bool isConstructing );

        /// <summary>
        /// Gets the number of SectorStorage with the given isConstructing
        /// </summary>
        /// <param name="id">The isConstructing</param>
        /// <returns>The count</returns>
        long CountByIsConstructing ( bool isConstructing );
        
		/// <summary>
        /// Selects all SectorStorage based on the isConstructing field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByIsConstructing ( int start, int count, bool isConstructing );
		
 		/// <summary>
        /// Selects all SectorStorage based on the level field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByLevel ( int level );

        /// <summary>
        /// Gets the number of SectorStorage with the given level
        /// </summary>
        /// <param name="id">The level</param>
        /// <returns>The count</returns>
        long CountByLevel ( int level );
        
		/// <summary>
        /// Selects all SectorStorage based on the level field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByLevel ( int start, int count, int level );
		
 		/// <summary>
        /// Selects all SectorStorage based on the isMoving field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByIsMoving ( bool isMoving );

        /// <summary>
        /// Gets the number of SectorStorage with the given isMoving
        /// </summary>
        /// <param name="id">The isMoving</param>
        /// <returns>The count</returns>
        long CountByIsMoving ( bool isMoving );
        
		/// <summary>
        /// Selects all SectorStorage based on the isMoving field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByIsMoving ( int start, int count, bool isMoving );
		
 		/// <summary>
        /// Selects all SectorStorage based on the owner field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByOwner ( PlayerStorage owner );

        /// <summary>
        /// Gets the number of SectorStorage with the given owner
        /// </summary>
        /// <param name="id">The owner</param>
        /// <returns>The count</returns>
        long CountByOwner ( PlayerStorage owner );
        
		/// <summary>
        /// Selects all SectorStorage based on the owner field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByOwner ( int start, int count, PlayerStorage owner );
		
 		/// <summary>
        /// Selects all SectorStorage based on the alliance field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByAlliance ( AllianceStorage alliance );

        /// <summary>
        /// Gets the number of SectorStorage with the given alliance
        /// </summary>
        /// <param name="id">The alliance</param>
        /// <returns>The count</returns>
        long CountByAlliance ( AllianceStorage alliance );
        
		/// <summary>
        /// Selects all SectorStorage based on the alliance field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The SectorStorage collection</returns>
		IList<SectorStorage> SelectByAlliance ( int start, int count, AllianceStorage alliance );
		
 		#endregion ExtendedMethods

	};
}
