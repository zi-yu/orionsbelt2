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
    /// Handles persistance for FogOfWarStorage objects
    /// </summary>
	public interface IFogOfWarStoragePersistance : IPersistance<FogOfWarStorage> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all FogOfWarStorage based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The FogOfWarStorage collection</returns>
		IList<FogOfWarStorage> SelectById ( int id );

        /// <summary>
        /// Gets the number of FogOfWarStorage with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all FogOfWarStorage based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The FogOfWarStorage collection</returns>
		IList<FogOfWarStorage> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all FogOfWarStorage based on the systemX field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The FogOfWarStorage collection</returns>
		IList<FogOfWarStorage> SelectBySystemX ( int systemX );

        /// <summary>
        /// Gets the number of FogOfWarStorage with the given systemX
        /// </summary>
        /// <param name="id">The systemX</param>
        /// <returns>The count</returns>
        long CountBySystemX ( int systemX );
        
		/// <summary>
        /// Selects all FogOfWarStorage based on the systemX field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The FogOfWarStorage collection</returns>
		IList<FogOfWarStorage> SelectBySystemX ( int start, int count, int systemX );
		
 		/// <summary>
        /// Selects all FogOfWarStorage based on the systemY field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The FogOfWarStorage collection</returns>
		IList<FogOfWarStorage> SelectBySystemY ( int systemY );

        /// <summary>
        /// Gets the number of FogOfWarStorage with the given systemY
        /// </summary>
        /// <param name="id">The systemY</param>
        /// <returns>The count</returns>
        long CountBySystemY ( int systemY );
        
		/// <summary>
        /// Selects all FogOfWarStorage based on the systemY field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The FogOfWarStorage collection</returns>
		IList<FogOfWarStorage> SelectBySystemY ( int start, int count, int systemY );
		
 		/// <summary>
        /// Selects all FogOfWarStorage based on the sectors field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The FogOfWarStorage collection</returns>
		IList<FogOfWarStorage> SelectBySectors ( string sectors );

        /// <summary>
        /// Gets the number of FogOfWarStorage with the given sectors
        /// </summary>
        /// <param name="id">The sectors</param>
        /// <returns>The count</returns>
        long CountBySectors ( string sectors );
        
		/// <summary>
        /// Selects all FogOfWarStorage based on the sectors field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The FogOfWarStorage collection</returns>
		IList<FogOfWarStorage> SelectBySectors ( int start, int count, string sectors );
		
 		/// <summary>
        /// Selects all FogOfWarStorage based on the hasDiscoveredAll field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The FogOfWarStorage collection</returns>
		IList<FogOfWarStorage> SelectByHasDiscoveredAll ( bool hasDiscoveredAll );

        /// <summary>
        /// Gets the number of FogOfWarStorage with the given hasDiscoveredAll
        /// </summary>
        /// <param name="id">The hasDiscoveredAll</param>
        /// <returns>The count</returns>
        long CountByHasDiscoveredAll ( bool hasDiscoveredAll );
        
		/// <summary>
        /// Selects all FogOfWarStorage based on the hasDiscoveredAll field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The FogOfWarStorage collection</returns>
		IList<FogOfWarStorage> SelectByHasDiscoveredAll ( int start, int count, bool hasDiscoveredAll );
		
 		/// <summary>
        /// Selects all FogOfWarStorage based on the hasDiscoveredHalf field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The FogOfWarStorage collection</returns>
		IList<FogOfWarStorage> SelectByHasDiscoveredHalf ( bool hasDiscoveredHalf );

        /// <summary>
        /// Gets the number of FogOfWarStorage with the given hasDiscoveredHalf
        /// </summary>
        /// <param name="id">The hasDiscoveredHalf</param>
        /// <returns>The count</returns>
        long CountByHasDiscoveredHalf ( bool hasDiscoveredHalf );
        
		/// <summary>
        /// Selects all FogOfWarStorage based on the hasDiscoveredHalf field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The FogOfWarStorage collection</returns>
		IList<FogOfWarStorage> SelectByHasDiscoveredHalf ( int start, int count, bool hasDiscoveredHalf );
		
 		/// <summary>
        /// Selects all FogOfWarStorage based on the owner field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The FogOfWarStorage collection</returns>
		IList<FogOfWarStorage> SelectByOwner ( PlayerStorage owner );

        /// <summary>
        /// Gets the number of FogOfWarStorage with the given owner
        /// </summary>
        /// <param name="id">The owner</param>
        /// <returns>The count</returns>
        long CountByOwner ( PlayerStorage owner );
        
		/// <summary>
        /// Selects all FogOfWarStorage based on the owner field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The FogOfWarStorage collection</returns>
		IList<FogOfWarStorage> SelectByOwner ( int start, int count, PlayerStorage owner );
		
 		#endregion ExtendedMethods

	};
}
