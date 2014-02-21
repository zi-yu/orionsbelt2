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
    /// Handles persistance for PrincipalTournament objects
    /// </summary>
	public interface IPrincipalTournamentPersistance : IPersistance<PrincipalTournament> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all PrincipalTournament based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalTournament collection</returns>
		IList<PrincipalTournament> SelectById ( int id );

        /// <summary>
        /// Gets the number of PrincipalTournament with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all PrincipalTournament based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalTournament collection</returns>
		IList<PrincipalTournament> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all PrincipalTournament based on the hasEliminated field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalTournament collection</returns>
		IList<PrincipalTournament> SelectByHasEliminated ( bool hasEliminated );

        /// <summary>
        /// Gets the number of PrincipalTournament with the given hasEliminated
        /// </summary>
        /// <param name="id">The hasEliminated</param>
        /// <returns>The count</returns>
        long CountByHasEliminated ( bool hasEliminated );
        
		/// <summary>
        /// Selects all PrincipalTournament based on the hasEliminated field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalTournament collection</returns>
		IList<PrincipalTournament> SelectByHasEliminated ( int start, int count, bool hasEliminated );
		
 		/// <summary>
        /// Selects all PrincipalTournament based on the eliminatedInFase field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalTournament collection</returns>
		IList<PrincipalTournament> SelectByEliminatedInFase ( string eliminatedInFase );

        /// <summary>
        /// Gets the number of PrincipalTournament with the given eliminatedInFase
        /// </summary>
        /// <param name="id">The eliminatedInFase</param>
        /// <returns>The count</returns>
        long CountByEliminatedInFase ( string eliminatedInFase );
        
		/// <summary>
        /// Selects all PrincipalTournament based on the eliminatedInFase field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalTournament collection</returns>
		IList<PrincipalTournament> SelectByEliminatedInFase ( int start, int count, string eliminatedInFase );
		
 		/// <summary>
        /// Selects all PrincipalTournament based on the eliminatedInBattleId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalTournament collection</returns>
		IList<PrincipalTournament> SelectByEliminatedInBattleId ( int eliminatedInBattleId );

        /// <summary>
        /// Gets the number of PrincipalTournament with the given eliminatedInBattleId
        /// </summary>
        /// <param name="id">The eliminatedInBattleId</param>
        /// <returns>The count</returns>
        long CountByEliminatedInBattleId ( int eliminatedInBattleId );
        
		/// <summary>
        /// Selects all PrincipalTournament based on the eliminatedInBattleId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalTournament collection</returns>
		IList<PrincipalTournament> SelectByEliminatedInBattleId ( int start, int count, int eliminatedInBattleId );
		
 		/// <summary>
        /// Selects all PrincipalTournament based on the principal field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalTournament collection</returns>
		IList<PrincipalTournament> SelectByPrincipal ( Principal principal );

        /// <summary>
        /// Gets the number of PrincipalTournament with the given principal
        /// </summary>
        /// <param name="id">The principal</param>
        /// <returns>The count</returns>
        long CountByPrincipal ( Principal principal );
        
		/// <summary>
        /// Selects all PrincipalTournament based on the principal field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalTournament collection</returns>
		IList<PrincipalTournament> SelectByPrincipal ( int start, int count, Principal principal );
		
 		/// <summary>
        /// Selects all PrincipalTournament based on the tournament field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalTournament collection</returns>
		IList<PrincipalTournament> SelectByTournament ( Tournament tournament );

        /// <summary>
        /// Gets the number of PrincipalTournament with the given tournament
        /// </summary>
        /// <param name="id">The tournament</param>
        /// <returns>The count</returns>
        long CountByTournament ( Tournament tournament );
        
		/// <summary>
        /// Selects all PrincipalTournament based on the tournament field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalTournament collection</returns>
		IList<PrincipalTournament> SelectByTournament ( int start, int count, Tournament tournament );
		
 		/// <summary>
        /// Selects all PrincipalTournament based on the team field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalTournament collection</returns>
		IList<PrincipalTournament> SelectByTeam ( TeamStorage team );

        /// <summary>
        /// Gets the number of PrincipalTournament with the given team
        /// </summary>
        /// <param name="id">The team</param>
        /// <returns>The count</returns>
        long CountByTeam ( TeamStorage team );
        
		/// <summary>
        /// Selects all PrincipalTournament based on the team field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrincipalTournament collection</returns>
		IList<PrincipalTournament> SelectByTeam ( int start, int count, TeamStorage team );
		
 		#endregion ExtendedMethods

	};
}
