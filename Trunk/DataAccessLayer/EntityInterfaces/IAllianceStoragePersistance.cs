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
    /// Handles persistance for AllianceStorage objects
    /// </summary>
	public interface IAllianceStoragePersistance : IPersistance<AllianceStorage> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all AllianceStorage based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectById ( int id );

        /// <summary>
        /// Gets the number of AllianceStorage with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all AllianceStorage based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all AllianceStorage based on the score field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByScore ( int score );

        /// <summary>
        /// Gets the number of AllianceStorage with the given score
        /// </summary>
        /// <param name="id">The score</param>
        /// <returns>The count</returns>
        long CountByScore ( int score );
        
		/// <summary>
        /// Selects all AllianceStorage based on the score field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByScore ( int start, int count, int score );
		
 		/// <summary>
        /// Selects all AllianceStorage based on the karma field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByKarma ( double karma );

        /// <summary>
        /// Gets the number of AllianceStorage with the given karma
        /// </summary>
        /// <param name="id">The karma</param>
        /// <returns>The count</returns>
        long CountByKarma ( double karma );
        
		/// <summary>
        /// Selects all AllianceStorage based on the karma field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByKarma ( int start, int count, double karma );
		
 		/// <summary>
        /// Selects all AllianceStorage based on the totalMembers field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByTotalMembers ( int totalMembers );

        /// <summary>
        /// Gets the number of AllianceStorage with the given totalMembers
        /// </summary>
        /// <param name="id">The totalMembers</param>
        /// <returns>The count</returns>
        long CountByTotalMembers ( int totalMembers );
        
		/// <summary>
        /// Selects all AllianceStorage based on the totalMembers field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByTotalMembers ( int start, int count, int totalMembers );
		
 		/// <summary>
        /// Selects all AllianceStorage based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByName ( string name );

        /// <summary>
        /// Gets the number of AllianceStorage with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all AllianceStorage based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all AllianceStorage based on the tag field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByTag ( string tag );

        /// <summary>
        /// Gets the number of AllianceStorage with the given tag
        /// </summary>
        /// <param name="id">The tag</param>
        /// <returns>The count</returns>
        long CountByTag ( string tag );
        
		/// <summary>
        /// Selects all AllianceStorage based on the tag field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByTag ( int start, int count, string tag );
		
 		/// <summary>
        /// Selects all AllianceStorage based on the description field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByDescription ( string description );

        /// <summary>
        /// Gets the number of AllianceStorage with the given description
        /// </summary>
        /// <param name="id">The description</param>
        /// <returns>The count</returns>
        long CountByDescription ( string description );
        
		/// <summary>
        /// Selects all AllianceStorage based on the description field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByDescription ( int start, int count, string description );
		
 		/// <summary>
        /// Selects all AllianceStorage based on the language field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByLanguage ( string language );

        /// <summary>
        /// Gets the number of AllianceStorage with the given language
        /// </summary>
        /// <param name="id">The language</param>
        /// <returns>The count</returns>
        long CountByLanguage ( string language );
        
		/// <summary>
        /// Selects all AllianceStorage based on the language field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByLanguage ( int start, int count, string language );
		
 		/// <summary>
        /// Selects all AllianceStorage based on the orions field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByOrions ( int orions );

        /// <summary>
        /// Gets the number of AllianceStorage with the given orions
        /// </summary>
        /// <param name="id">The orions</param>
        /// <returns>The count</returns>
        long CountByOrions ( int orions );
        
		/// <summary>
        /// Selects all AllianceStorage based on the orions field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByOrions ( int start, int count, int orions );
		
 		/// <summary>
        /// Selects all AllianceStorage based on the openToNewMembers field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByOpenToNewMembers ( bool openToNewMembers );

        /// <summary>
        /// Gets the number of AllianceStorage with the given openToNewMembers
        /// </summary>
        /// <param name="id">The openToNewMembers</param>
        /// <returns>The count</returns>
        long CountByOpenToNewMembers ( bool openToNewMembers );
        
		/// <summary>
        /// Selects all AllianceStorage based on the openToNewMembers field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByOpenToNewMembers ( int start, int count, bool openToNewMembers );
		
 		/// <summary>
        /// Selects all AllianceStorage based on the totalRelics field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByTotalRelics ( int totalRelics );

        /// <summary>
        /// Gets the number of AllianceStorage with the given totalRelics
        /// </summary>
        /// <param name="id">The totalRelics</param>
        /// <returns>The count</returns>
        long CountByTotalRelics ( int totalRelics );
        
		/// <summary>
        /// Selects all AllianceStorage based on the totalRelics field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByTotalRelics ( int start, int count, int totalRelics );
		
 		/// <summary>
        /// Selects all AllianceStorage based on the totalRelicsIncome field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByTotalRelicsIncome ( int totalRelicsIncome );

        /// <summary>
        /// Gets the number of AllianceStorage with the given totalRelicsIncome
        /// </summary>
        /// <param name="id">The totalRelicsIncome</param>
        /// <returns>The count</returns>
        long CountByTotalRelicsIncome ( int totalRelicsIncome );
        
		/// <summary>
        /// Selects all AllianceStorage based on the totalRelicsIncome field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The AllianceStorage collection</returns>
		IList<AllianceStorage> SelectByTotalRelicsIncome ( int start, int count, int totalRelicsIncome );
		
 		#endregion ExtendedMethods

	};
}
