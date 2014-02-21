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
    /// Handles persistance for TimedActionStorage objects
    /// </summary>
	public interface ITimedActionStoragePersistance : IPersistance<TimedActionStorage> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all TimedActionStorage based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TimedActionStorage collection</returns>
		IList<TimedActionStorage> SelectById ( int id );

        /// <summary>
        /// Gets the number of TimedActionStorage with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all TimedActionStorage based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TimedActionStorage collection</returns>
		IList<TimedActionStorage> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all TimedActionStorage based on the startTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TimedActionStorage collection</returns>
		IList<TimedActionStorage> SelectByStartTick ( int startTick );

        /// <summary>
        /// Gets the number of TimedActionStorage with the given startTick
        /// </summary>
        /// <param name="id">The startTick</param>
        /// <returns>The count</returns>
        long CountByStartTick ( int startTick );
        
		/// <summary>
        /// Selects all TimedActionStorage based on the startTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TimedActionStorage collection</returns>
		IList<TimedActionStorage> SelectByStartTick ( int start, int count, int startTick );
		
 		/// <summary>
        /// Selects all TimedActionStorage based on the endTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TimedActionStorage collection</returns>
		IList<TimedActionStorage> SelectByEndTick ( int endTick );

        /// <summary>
        /// Gets the number of TimedActionStorage with the given endTick
        /// </summary>
        /// <param name="id">The endTick</param>
        /// <returns>The count</returns>
        long CountByEndTick ( int endTick );
        
		/// <summary>
        /// Selects all TimedActionStorage based on the endTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TimedActionStorage collection</returns>
		IList<TimedActionStorage> SelectByEndTick ( int start, int count, int endTick );
		
 		/// <summary>
        /// Selects all TimedActionStorage based on the data field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TimedActionStorage collection</returns>
		IList<TimedActionStorage> SelectByData ( string data );

        /// <summary>
        /// Gets the number of TimedActionStorage with the given data
        /// </summary>
        /// <param name="id">The data</param>
        /// <returns>The count</returns>
        long CountByData ( string data );
        
		/// <summary>
        /// Selects all TimedActionStorage based on the data field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TimedActionStorage collection</returns>
		IList<TimedActionStorage> SelectByData ( int start, int count, string data );
		
 		/// <summary>
        /// Selects all TimedActionStorage based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TimedActionStorage collection</returns>
		IList<TimedActionStorage> SelectByName ( string name );

        /// <summary>
        /// Gets the number of TimedActionStorage with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all TimedActionStorage based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TimedActionStorage collection</returns>
		IList<TimedActionStorage> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all TimedActionStorage based on the player field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TimedActionStorage collection</returns>
		IList<TimedActionStorage> SelectByPlayer ( PlayerStorage player );

        /// <summary>
        /// Gets the number of TimedActionStorage with the given player
        /// </summary>
        /// <param name="id">The player</param>
        /// <returns>The count</returns>
        long CountByPlayer ( PlayerStorage player );
        
		/// <summary>
        /// Selects all TimedActionStorage based on the player field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TimedActionStorage collection</returns>
		IList<TimedActionStorage> SelectByPlayer ( int start, int count, PlayerStorage player );
		
 		/// <summary>
        /// Selects all TimedActionStorage based on the battle field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The TimedActionStorage collection</returns>
		IList<TimedActionStorage> SelectByBattle ( Battle battle );

        /// <summary>
        /// Gets the number of TimedActionStorage with the given battle
        /// </summary>
        /// <param name="id">The battle</param>
        /// <returns>The count</returns>
        long CountByBattle ( Battle battle );
        
		/// <summary>
        /// Selects all TimedActionStorage based on the battle field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The TimedActionStorage collection</returns>
		IList<TimedActionStorage> SelectByBattle ( int start, int count, Battle battle );
		
 		#endregion ExtendedMethods

	};
}
