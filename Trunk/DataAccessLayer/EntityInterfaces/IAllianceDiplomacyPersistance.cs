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
    /// Handles persistance for AllianceDiplomacy objects
    /// </summary>
	public interface IAllianceDiplomacyPersistance : IPersistance<AllianceDiplomacy> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all AllianceDiplomacy based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceDiplomacy collection</returns>
		IList<AllianceDiplomacy> SelectById ( int id );

        /// <summary>
        /// Gets the number of AllianceDiplomacy with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all AllianceDiplomacy based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceDiplomacy collection</returns>
		IList<AllianceDiplomacy> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all AllianceDiplomacy based on the level field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceDiplomacy collection</returns>
		IList<AllianceDiplomacy> SelectByLevel ( string level );

        /// <summary>
        /// Gets the number of AllianceDiplomacy with the given level
        /// </summary>
        /// <param name="id">The level</param>
        /// <returns>The count</returns>
        long CountByLevel ( string level );
        
		/// <summary>
        /// Selects all AllianceDiplomacy based on the level field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceDiplomacy collection</returns>
		IList<AllianceDiplomacy> SelectByLevel ( int start, int count, string level );
		
 		/// <summary>
        /// Selects all AllianceDiplomacy based on the allianceA field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceDiplomacy collection</returns>
		IList<AllianceDiplomacy> SelectByAllianceA ( AllianceStorage allianceA );

        /// <summary>
        /// Gets the number of AllianceDiplomacy with the given allianceA
        /// </summary>
        /// <param name="id">The allianceA</param>
        /// <returns>The count</returns>
        long CountByAllianceA ( AllianceStorage allianceA );
        
		/// <summary>
        /// Selects all AllianceDiplomacy based on the allianceA field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceDiplomacy collection</returns>
		IList<AllianceDiplomacy> SelectByAllianceA ( int start, int count, AllianceStorage allianceA );
		
 		/// <summary>
        /// Selects all AllianceDiplomacy based on the allianceB field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceDiplomacy collection</returns>
		IList<AllianceDiplomacy> SelectByAllianceB ( AllianceStorage allianceB );

        /// <summary>
        /// Gets the number of AllianceDiplomacy with the given allianceB
        /// </summary>
        /// <param name="id">The allianceB</param>
        /// <returns>The count</returns>
        long CountByAllianceB ( AllianceStorage allianceB );
        
		/// <summary>
        /// Selects all AllianceDiplomacy based on the allianceB field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceDiplomacy collection</returns>
		IList<AllianceDiplomacy> SelectByAllianceB ( int start, int count, AllianceStorage allianceB );
		
 		#endregion ExtendedMethods

	};
}
