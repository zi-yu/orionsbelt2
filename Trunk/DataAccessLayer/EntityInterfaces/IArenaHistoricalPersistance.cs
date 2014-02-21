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
    /// Handles persistance for ArenaHistorical objects
    /// </summary>
	public interface IArenaHistoricalPersistance : IPersistance<ArenaHistorical> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all ArenaHistorical based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectById ( int id );

        /// <summary>
        /// Gets the number of ArenaHistorical with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all ArenaHistorical based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all ArenaHistorical based on the championId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByChampionId ( int championId );

        /// <summary>
        /// Gets the number of ArenaHistorical with the given championId
        /// </summary>
        /// <param name="id">The championId</param>
        /// <returns>The count</returns>
        long CountByChampionId ( int championId );
        
		/// <summary>
        /// Selects all ArenaHistorical based on the championId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByChampionId ( int start, int count, int championId );
		
 		/// <summary>
        /// Selects all ArenaHistorical based on the challengerId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByChallengerId ( int challengerId );

        /// <summary>
        /// Gets the number of ArenaHistorical with the given challengerId
        /// </summary>
        /// <param name="id">The challengerId</param>
        /// <returns>The count</returns>
        long CountByChallengerId ( int challengerId );
        
		/// <summary>
        /// Selects all ArenaHistorical based on the challengerId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByChallengerId ( int start, int count, int challengerId );
		
 		/// <summary>
        /// Selects all ArenaHistorical based on the winner field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByWinner ( int winner );

        /// <summary>
        /// Gets the number of ArenaHistorical with the given winner
        /// </summary>
        /// <param name="id">The winner</param>
        /// <returns>The count</returns>
        long CountByWinner ( int winner );
        
		/// <summary>
        /// Selects all ArenaHistorical based on the winner field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByWinner ( int start, int count, int winner );
		
 		/// <summary>
        /// Selects all ArenaHistorical based on the winningSequence field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByWinningSequence ( int winningSequence );

        /// <summary>
        /// Gets the number of ArenaHistorical with the given winningSequence
        /// </summary>
        /// <param name="id">The winningSequence</param>
        /// <returns>The count</returns>
        long CountByWinningSequence ( int winningSequence );
        
		/// <summary>
        /// Selects all ArenaHistorical based on the winningSequence field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByWinningSequence ( int start, int count, int winningSequence );
		
 		/// <summary>
        /// Selects all ArenaHistorical based on the battleId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByBattleId ( int battleId );

        /// <summary>
        /// Gets the number of ArenaHistorical with the given battleId
        /// </summary>
        /// <param name="id">The battleId</param>
        /// <returns>The count</returns>
        long CountByBattleId ( int battleId );
        
		/// <summary>
        /// Selects all ArenaHistorical based on the battleId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByBattleId ( int start, int count, int battleId );
		
 		/// <summary>
        /// Selects all ArenaHistorical based on the startTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByStartTick ( int startTick );

        /// <summary>
        /// Gets the number of ArenaHistorical with the given startTick
        /// </summary>
        /// <param name="id">The startTick</param>
        /// <returns>The count</returns>
        long CountByStartTick ( int startTick );
        
		/// <summary>
        /// Selects all ArenaHistorical based on the startTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByStartTick ( int start, int count, int startTick );
		
 		/// <summary>
        /// Selects all ArenaHistorical based on the endTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByEndTick ( int endTick );

        /// <summary>
        /// Gets the number of ArenaHistorical with the given endTick
        /// </summary>
        /// <param name="id">The endTick</param>
        /// <returns>The count</returns>
        long CountByEndTick ( int endTick );
        
		/// <summary>
        /// Selects all ArenaHistorical based on the endTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByEndTick ( int start, int count, int endTick );
		
 		/// <summary>
        /// Selects all ArenaHistorical based on the arena field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByArena ( ArenaStorage arena );

        /// <summary>
        /// Gets the number of ArenaHistorical with the given arena
        /// </summary>
        /// <param name="id">The arena</param>
        /// <returns>The count</returns>
        long CountByArena ( ArenaStorage arena );
        
		/// <summary>
        /// Selects all ArenaHistorical based on the arena field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ArenaHistorical collection</returns>
		IList<ArenaHistorical> SelectByArena ( int start, int count, ArenaStorage arena );
		
 		#endregion ExtendedMethods

	};
}
