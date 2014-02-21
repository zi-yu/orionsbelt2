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
    /// Handles persistance for ServerProperties objects
    /// </summary>
	public interface IServerPropertiesPersistance : IPersistance<ServerProperties> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all ServerProperties based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectById ( int id );

        /// <summary>
        /// Gets the number of ServerProperties with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all ServerProperties based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all ServerProperties based on the currentTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByCurrentTick ( int currentTick );

        /// <summary>
        /// Gets the number of ServerProperties with the given currentTick
        /// </summary>
        /// <param name="id">The currentTick</param>
        /// <returns>The count</returns>
        long CountByCurrentTick ( int currentTick );
        
		/// <summary>
        /// Selects all ServerProperties based on the currentTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByCurrentTick ( int start, int count, int currentTick );
		
 		/// <summary>
        /// Selects all ServerProperties based on the lastTickDate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByLastTickDate ( DateTime lastTickDate );

        /// <summary>
        /// Gets the number of ServerProperties with the given lastTickDate
        /// </summary>
        /// <param name="id">The lastTickDate</param>
        /// <returns>The count</returns>
        long CountByLastTickDate ( DateTime lastTickDate );
        
		/// <summary>
        /// Selects all ServerProperties based on the lastTickDate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByLastTickDate ( int start, int count, DateTime lastTickDate );
		
 		/// <summary>
        /// Selects all ServerProperties based on the running field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByRunning ( bool running );

        /// <summary>
        /// Gets the number of ServerProperties with the given running
        /// </summary>
        /// <param name="id">The running</param>
        /// <returns>The count</returns>
        long CountByRunning ( bool running );
        
		/// <summary>
        /// Selects all ServerProperties based on the running field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByRunning ( int start, int count, bool running );
		
 		/// <summary>
        /// Selects all ServerProperties based on the millisPerTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByMillisPerTick ( int millisPerTick );

        /// <summary>
        /// Gets the number of ServerProperties with the given millisPerTick
        /// </summary>
        /// <param name="id">The millisPerTick</param>
        /// <returns>The count</returns>
        long CountByMillisPerTick ( int millisPerTick );
        
		/// <summary>
        /// Selects all ServerProperties based on the millisPerTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByMillisPerTick ( int start, int count, int millisPerTick );
		
 		/// <summary>
        /// Selects all ServerProperties based on the useWebClock field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByUseWebClock ( bool useWebClock );

        /// <summary>
        /// Gets the number of ServerProperties with the given useWebClock
        /// </summary>
        /// <param name="id">The useWebClock</param>
        /// <returns>The count</returns>
        long CountByUseWebClock ( bool useWebClock );
        
		/// <summary>
        /// Selects all ServerProperties based on the useWebClock field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByUseWebClock ( int start, int count, bool useWebClock );
		
 		/// <summary>
        /// Selects all ServerProperties based on the maxPlayers field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByMaxPlayers ( int maxPlayers );

        /// <summary>
        /// Gets the number of ServerProperties with the given maxPlayers
        /// </summary>
        /// <param name="id">The maxPlayers</param>
        /// <returns>The count</returns>
        long CountByMaxPlayers ( int maxPlayers );
        
		/// <summary>
        /// Selects all ServerProperties based on the maxPlayers field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByMaxPlayers ( int start, int count, int maxPlayers );
		
 		/// <summary>
        /// Selects all ServerProperties based on the vacationTicksPerWeek field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByVacationTicksPerWeek ( int vacationTicksPerWeek );

        /// <summary>
        /// Gets the number of ServerProperties with the given vacationTicksPerWeek
        /// </summary>
        /// <param name="id">The vacationTicksPerWeek</param>
        /// <returns>The count</returns>
        long CountByVacationTicksPerWeek ( int vacationTicksPerWeek );
        
		/// <summary>
        /// Selects all ServerProperties based on the vacationTicksPerWeek field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByVacationTicksPerWeek ( int start, int count, int vacationTicksPerWeek );
		
 		/// <summary>
        /// Selects all ServerProperties based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByName ( string name );

        /// <summary>
        /// Gets the number of ServerProperties with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all ServerProperties based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all ServerProperties based on the baseUrl field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByBaseUrl ( string baseUrl );

        /// <summary>
        /// Gets the number of ServerProperties with the given baseUrl
        /// </summary>
        /// <param name="id">The baseUrl</param>
        /// <returns>The count</returns>
        long CountByBaseUrl ( string baseUrl );
        
		/// <summary>
        /// Selects all ServerProperties based on the baseUrl field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ServerProperties collection</returns>
		IList<ServerProperties> SelectByBaseUrl ( int start, int count, string baseUrl );
		
 		#endregion ExtendedMethods

	};
}
