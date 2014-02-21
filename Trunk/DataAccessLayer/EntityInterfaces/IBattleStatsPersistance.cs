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
    /// Handles persistance for BattleStats objects
    /// </summary>
	public interface IBattleStatsPersistance : IPersistance<BattleStats> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all BattleStats based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectById ( int id );

        /// <summary>
        /// Gets the number of BattleStats with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all BattleStats based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all BattleStats based on the wins field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectByWins ( int wins );

        /// <summary>
        /// Gets the number of BattleStats with the given wins
        /// </summary>
        /// <param name="id">The wins</param>
        /// <returns>The count</returns>
        long CountByWins ( int wins );
        
		/// <summary>
        /// Selects all BattleStats based on the wins field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectByWins ( int start, int count, int wins );
		
 		/// <summary>
        /// Selects all BattleStats based on the defeats field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectByDefeats ( int defeats );

        /// <summary>
        /// Gets the number of BattleStats with the given defeats
        /// </summary>
        /// <param name="id">The defeats</param>
        /// <returns>The count</returns>
        long CountByDefeats ( int defeats );
        
		/// <summary>
        /// Selects all BattleStats based on the defeats field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectByDefeats ( int start, int count, int defeats );
		
 		/// <summary>
        /// Selects all BattleStats based on the type field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectByType ( string type );

        /// <summary>
        /// Gets the number of BattleStats with the given type
        /// </summary>
        /// <param name="id">The type</param>
        /// <returns>The count</returns>
        long CountByType ( string type );
        
		/// <summary>
        /// Selects all BattleStats based on the type field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectByType ( int start, int count, string type );
		
 		/// <summary>
        /// Selects all BattleStats based on the detail field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectByDetail ( string detail );

        /// <summary>
        /// Gets the number of BattleStats with the given detail
        /// </summary>
        /// <param name="id">The detail</param>
        /// <returns>The count</returns>
        long CountByDetail ( string detail );
        
		/// <summary>
        /// Selects all BattleStats based on the detail field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectByDetail ( int start, int count, string detail );
		
 		/// <summary>
        /// Selects all BattleStats based on the giveUps field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectByGiveUps ( int giveUps );

        /// <summary>
        /// Gets the number of BattleStats with the given giveUps
        /// </summary>
        /// <param name="id">The giveUps</param>
        /// <returns>The count</returns>
        long CountByGiveUps ( int giveUps );
        
		/// <summary>
        /// Selects all BattleStats based on the giveUps field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectByGiveUps ( int start, int count, int giveUps );
		
 		/// <summary>
        /// Selects all BattleStats based on the stats field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectByStats ( PrincipalStats stats );

        /// <summary>
        /// Gets the number of BattleStats with the given stats
        /// </summary>
        /// <param name="id">The stats</param>
        /// <returns>The count</returns>
        long CountByStats ( PrincipalStats stats );
        
		/// <summary>
        /// Selects all BattleStats based on the stats field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectByStats ( int start, int count, PrincipalStats stats );
		
 		/// <summary>
        /// Selects all BattleStats based on the playerStats field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectByPlayerStats ( PlayerStats playerStats );

        /// <summary>
        /// Gets the number of BattleStats with the given playerStats
        /// </summary>
        /// <param name="id">The playerStats</param>
        /// <returns>The count</returns>
        long CountByPlayerStats ( PlayerStats playerStats );
        
		/// <summary>
        /// Selects all BattleStats based on the playerStats field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BattleStats collection</returns>
		IList<BattleStats> SelectByPlayerStats ( int start, int count, PlayerStats playerStats );
		
 		#endregion ExtendedMethods

	};
}
