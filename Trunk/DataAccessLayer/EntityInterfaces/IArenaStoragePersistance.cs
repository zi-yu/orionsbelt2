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
    /// Handles persistance for ArenaStorage objects
    /// </summary>
	public interface IArenaStoragePersistance : IPersistance<ArenaStorage> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all ArenaStorage based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectById ( int id );

        /// <summary>
        /// Gets the number of ArenaStorage with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all ArenaStorage based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all ArenaStorage based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByName ( string name );

        /// <summary>
        /// Gets the number of ArenaStorage with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all ArenaStorage based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all ArenaStorage based on the isInBattle field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByIsInBattle ( int isInBattle );

        /// <summary>
        /// Gets the number of ArenaStorage with the given isInBattle
        /// </summary>
        /// <param name="id">The isInBattle</param>
        /// <returns>The count</returns>
        long CountByIsInBattle ( int isInBattle );
        
		/// <summary>
        /// Selects all ArenaStorage based on the isInBattle field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByIsInBattle ( int start, int count, int isInBattle );
		
 		/// <summary>
        /// Selects all ArenaStorage based on the conquestTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByConquestTick ( int conquestTick );

        /// <summary>
        /// Gets the number of ArenaStorage with the given conquestTick
        /// </summary>
        /// <param name="id">The conquestTick</param>
        /// <returns>The count</returns>
        long CountByConquestTick ( int conquestTick );
        
		/// <summary>
        /// Selects all ArenaStorage based on the conquestTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByConquestTick ( int start, int count, int conquestTick );
		
 		/// <summary>
        /// Selects all ArenaStorage based on the battleType field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByBattleType ( string battleType );

        /// <summary>
        /// Gets the number of ArenaStorage with the given battleType
        /// </summary>
        /// <param name="id">The battleType</param>
        /// <returns>The count</returns>
        long CountByBattleType ( string battleType );
        
		/// <summary>
        /// Selects all ArenaStorage based on the battleType field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByBattleType ( int start, int count, string battleType );
		
 		/// <summary>
        /// Selects all ArenaStorage based on the coordinate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByCoordinate ( string coordinate );

        /// <summary>
        /// Gets the number of ArenaStorage with the given coordinate
        /// </summary>
        /// <param name="id">The coordinate</param>
        /// <returns>The count</returns>
        long CountByCoordinate ( string coordinate );
        
		/// <summary>
        /// Selects all ArenaStorage based on the coordinate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByCoordinate ( int start, int count, string coordinate );
		
 		/// <summary>
        /// Selects all ArenaStorage based on the payment field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByPayment ( int payment );

        /// <summary>
        /// Gets the number of ArenaStorage with the given payment
        /// </summary>
        /// <param name="id">The payment</param>
        /// <returns>The count</returns>
        long CountByPayment ( int payment );
        
		/// <summary>
        /// Selects all ArenaStorage based on the payment field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByPayment ( int start, int count, int payment );
		
 		/// <summary>
        /// Selects all ArenaStorage based on the level field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByLevel ( int level );

        /// <summary>
        /// Gets the number of ArenaStorage with the given level
        /// </summary>
        /// <param name="id">The level</param>
        /// <returns>The count</returns>
        long CountByLevel ( int level );
        
		/// <summary>
        /// Selects all ArenaStorage based on the level field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByLevel ( int start, int count, int level );
		
 		/// <summary>
        /// Selects all ArenaStorage based on the fleet field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByFleet ( Fleet fleet );

        /// <summary>
        /// Gets the number of ArenaStorage with the given fleet
        /// </summary>
        /// <param name="id">The fleet</param>
        /// <returns>The count</returns>
        long CountByFleet ( Fleet fleet );
        
		/// <summary>
        /// Selects all ArenaStorage based on the fleet field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByFleet ( int start, int count, Fleet fleet );
		
 		/// <summary>
        /// Selects all ArenaStorage based on the owner field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByOwner ( PlayerStorage owner );

        /// <summary>
        /// Gets the number of ArenaStorage with the given owner
        /// </summary>
        /// <param name="id">The owner</param>
        /// <returns>The count</returns>
        long CountByOwner ( PlayerStorage owner );
        
		/// <summary>
        /// Selects all ArenaStorage based on the owner field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectByOwner ( int start, int count, PlayerStorage owner );
		
 		/// <summary>
        /// Selects all ArenaStorage based on the sector field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectBySector ( SectorStorage sector );

        /// <summary>
        /// Gets the number of ArenaStorage with the given sector
        /// </summary>
        /// <param name="id">The sector</param>
        /// <returns>The count</returns>
        long CountBySector ( SectorStorage sector );
        
		/// <summary>
        /// Selects all ArenaStorage based on the sector field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaStorage collection</returns>
		IList<ArenaStorage> SelectBySector ( int start, int count, SectorStorage sector );
		
 		#endregion ExtendedMethods

	};
}
