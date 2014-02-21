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
    /// Handles persistance for BattleExtention objects
    /// </summary>
	public interface IBattleExtentionPersistance : IPersistance<BattleExtention> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all BattleExtention based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BattleExtention collection</returns>
		IList<BattleExtention> SelectById ( int id );

        /// <summary>
        /// Gets the number of BattleExtention with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all BattleExtention based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BattleExtention collection</returns>
		IList<BattleExtention> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all BattleExtention based on the battleFinalStates field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BattleExtention collection</returns>
		IList<BattleExtention> SelectByBattleFinalStates ( string battleFinalStates );

        /// <summary>
        /// Gets the number of BattleExtention with the given battleFinalStates
        /// </summary>
        /// <param name="id">The battleFinalStates</param>
        /// <returns>The count</returns>
        long CountByBattleFinalStates ( string battleFinalStates );
        
		/// <summary>
        /// Selects all BattleExtention based on the battleFinalStates field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BattleExtention collection</returns>
		IList<BattleExtention> SelectByBattleFinalStates ( int start, int count, string battleFinalStates );
		
 		/// <summary>
        /// Selects all BattleExtention based on the battleMovements field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BattleExtention collection</returns>
		IList<BattleExtention> SelectByBattleMovements ( string battleMovements );

        /// <summary>
        /// Gets the number of BattleExtention with the given battleMovements
        /// </summary>
        /// <param name="id">The battleMovements</param>
        /// <returns>The count</returns>
        long CountByBattleMovements ( string battleMovements );
        
		/// <summary>
        /// Selects all BattleExtention based on the battleMovements field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BattleExtention collection</returns>
		IList<BattleExtention> SelectByBattleMovements ( int start, int count, string battleMovements );
		
 		/// <summary>
        /// Selects all BattleExtention based on the battle field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BattleExtention collection</returns>
		IList<BattleExtention> SelectByBattle ( Battle battle );

        /// <summary>
        /// Gets the number of BattleExtention with the given battle
        /// </summary>
        /// <param name="id">The battle</param>
        /// <returns>The count</returns>
        long CountByBattle ( Battle battle );
        
		/// <summary>
        /// Selects all BattleExtention based on the battle field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BattleExtention collection</returns>
		IList<BattleExtention> SelectByBattle ( int start, int count, Battle battle );
		
 		#endregion ExtendedMethods

	};
}
