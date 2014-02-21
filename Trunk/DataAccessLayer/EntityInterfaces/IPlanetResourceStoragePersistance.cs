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
    /// Handles persistance for PlanetResourceStorage objects
    /// </summary>
	public interface IPlanetResourceStoragePersistance : IPersistance<PlanetResourceStorage> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all PlanetResourceStorage based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectById ( int id );

        /// <summary>
        /// Gets the number of PlanetResourceStorage with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all PlanetResourceStorage based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all PlanetResourceStorage based on the quantity field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByQuantity ( int quantity );

        /// <summary>
        /// Gets the number of PlanetResourceStorage with the given quantity
        /// </summary>
        /// <param name="id">The quantity</param>
        /// <returns>The count</returns>
        long CountByQuantity ( int quantity );
        
		/// <summary>
        /// Selects all PlanetResourceStorage based on the quantity field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByQuantity ( int start, int count, int quantity );
		
 		/// <summary>
        /// Selects all PlanetResourceStorage based on the state field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByState ( string state );

        /// <summary>
        /// Gets the number of PlanetResourceStorage with the given state
        /// </summary>
        /// <param name="id">The state</param>
        /// <returns>The count</returns>
        long CountByState ( string state );
        
		/// <summary>
        /// Selects all PlanetResourceStorage based on the state field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByState ( int start, int count, string state );
		
 		/// <summary>
        /// Selects all PlanetResourceStorage based on the level field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByLevel ( int level );

        /// <summary>
        /// Gets the number of PlanetResourceStorage with the given level
        /// </summary>
        /// <param name="id">The level</param>
        /// <returns>The count</returns>
        long CountByLevel ( int level );
        
		/// <summary>
        /// Selects all PlanetResourceStorage based on the level field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByLevel ( int start, int count, int level );
		
 		/// <summary>
        /// Selects all PlanetResourceStorage based on the type field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByType ( string type );

        /// <summary>
        /// Gets the number of PlanetResourceStorage with the given type
        /// </summary>
        /// <param name="id">The type</param>
        /// <returns>The count</returns>
        long CountByType ( string type );
        
		/// <summary>
        /// Selects all PlanetResourceStorage based on the type field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByType ( int start, int count, string type );
		
 		/// <summary>
        /// Selects all PlanetResourceStorage based on the queueOrder field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByQueueOrder ( int queueOrder );

        /// <summary>
        /// Gets the number of PlanetResourceStorage with the given queueOrder
        /// </summary>
        /// <param name="id">The queueOrder</param>
        /// <returns>The count</returns>
        long CountByQueueOrder ( int queueOrder );
        
		/// <summary>
        /// Selects all PlanetResourceStorage based on the queueOrder field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByQueueOrder ( int start, int count, int queueOrder );
		
 		/// <summary>
        /// Selects all PlanetResourceStorage based on the slot field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectBySlot ( string slot );

        /// <summary>
        /// Gets the number of PlanetResourceStorage with the given slot
        /// </summary>
        /// <param name="id">The slot</param>
        /// <returns>The count</returns>
        long CountBySlot ( string slot );
        
		/// <summary>
        /// Selects all PlanetResourceStorage based on the slot field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectBySlot ( int start, int count, string slot );
		
 		/// <summary>
        /// Selects all PlanetResourceStorage based on the endTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByEndTick ( int endTick );

        /// <summary>
        /// Gets the number of PlanetResourceStorage with the given endTick
        /// </summary>
        /// <param name="id">The endTick</param>
        /// <returns>The count</returns>
        long CountByEndTick ( int endTick );
        
		/// <summary>
        /// Selects all PlanetResourceStorage based on the endTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByEndTick ( int start, int count, int endTick );
		
 		/// <summary>
        /// Selects all PlanetResourceStorage based on the planet field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByPlanet ( PlanetStorage planet );

        /// <summary>
        /// Gets the number of PlanetResourceStorage with the given planet
        /// </summary>
        /// <param name="id">The planet</param>
        /// <returns>The count</returns>
        long CountByPlanet ( PlanetStorage planet );
        
		/// <summary>
        /// Selects all PlanetResourceStorage based on the planet field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByPlanet ( int start, int count, PlanetStorage planet );
		
 		/// <summary>
        /// Selects all PlanetResourceStorage based on the player field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByPlayer ( PlayerStorage player );

        /// <summary>
        /// Gets the number of PlanetResourceStorage with the given player
        /// </summary>
        /// <param name="id">The player</param>
        /// <returns>The count</returns>
        long CountByPlayer ( PlayerStorage player );
        
		/// <summary>
        /// Selects all PlanetResourceStorage based on the player field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PlanetResourceStorage collection</returns>
		IList<PlanetResourceStorage> SelectByPlayer ( int start, int count, PlayerStorage player );
		
 		#endregion ExtendedMethods

	};
}
