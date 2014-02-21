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
    /// Handles persistance for GroupPointsStorage objects
    /// </summary>
	public interface IGroupPointsStoragePersistance : IPersistance<GroupPointsStorage> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all GroupPointsStorage based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The GroupPointsStorage collection</returns>
		IList<GroupPointsStorage> SelectById ( int id );

        /// <summary>
        /// Gets the number of GroupPointsStorage with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all GroupPointsStorage based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The GroupPointsStorage collection</returns>
		IList<GroupPointsStorage> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all GroupPointsStorage based on the stage field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The GroupPointsStorage collection</returns>
		IList<GroupPointsStorage> SelectByStage ( int stage );

        /// <summary>
        /// Gets the number of GroupPointsStorage with the given stage
        /// </summary>
        /// <param name="id">The stage</param>
        /// <returns>The count</returns>
        long CountByStage ( int stage );
        
		/// <summary>
        /// Selects all GroupPointsStorage based on the stage field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The GroupPointsStorage collection</returns>
		IList<GroupPointsStorage> SelectByStage ( int start, int count, int stage );
		
 		/// <summary>
        /// Selects all GroupPointsStorage based on the pontuation field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The GroupPointsStorage collection</returns>
		IList<GroupPointsStorage> SelectByPontuation ( int pontuation );

        /// <summary>
        /// Gets the number of GroupPointsStorage with the given pontuation
        /// </summary>
        /// <param name="id">The pontuation</param>
        /// <returns>The count</returns>
        long CountByPontuation ( int pontuation );
        
		/// <summary>
        /// Selects all GroupPointsStorage based on the pontuation field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The GroupPointsStorage collection</returns>
		IList<GroupPointsStorage> SelectByPontuation ( int start, int count, int pontuation );
		
 		/// <summary>
        /// Selects all GroupPointsStorage based on the wins field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The GroupPointsStorage collection</returns>
		IList<GroupPointsStorage> SelectByWins ( int wins );

        /// <summary>
        /// Gets the number of GroupPointsStorage with the given wins
        /// </summary>
        /// <param name="id">The wins</param>
        /// <returns>The count</returns>
        long CountByWins ( int wins );
        
		/// <summary>
        /// Selects all GroupPointsStorage based on the wins field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The GroupPointsStorage collection</returns>
		IList<GroupPointsStorage> SelectByWins ( int start, int count, int wins );
		
 		/// <summary>
        /// Selects all GroupPointsStorage based on the losses field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The GroupPointsStorage collection</returns>
		IList<GroupPointsStorage> SelectByLosses ( int losses );

        /// <summary>
        /// Gets the number of GroupPointsStorage with the given losses
        /// </summary>
        /// <param name="id">The losses</param>
        /// <returns>The count</returns>
        long CountByLosses ( int losses );
        
		/// <summary>
        /// Selects all GroupPointsStorage based on the losses field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The GroupPointsStorage collection</returns>
		IList<GroupPointsStorage> SelectByLosses ( int start, int count, int losses );
		
 		/// <summary>
        /// Selects all GroupPointsStorage based on the regist field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The GroupPointsStorage collection</returns>
		IList<GroupPointsStorage> SelectByRegist ( PrincipalTournament regist );

        /// <summary>
        /// Gets the number of GroupPointsStorage with the given regist
        /// </summary>
        /// <param name="id">The regist</param>
        /// <returns>The count</returns>
        long CountByRegist ( PrincipalTournament regist );
        
		/// <summary>
        /// Selects all GroupPointsStorage based on the regist field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The GroupPointsStorage collection</returns>
		IList<GroupPointsStorage> SelectByRegist ( int start, int count, PrincipalTournament regist );
		
 		#endregion ExtendedMethods

	};
}
