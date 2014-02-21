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
    /// Handles persistance for BonusCard objects
    /// </summary>
	public interface IBonusCardPersistance : IPersistance<BonusCard> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all BonusCard based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BonusCard collection</returns>
		IList<BonusCard> SelectById ( int id );

        /// <summary>
        /// Gets the number of BonusCard with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all BonusCard based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BonusCard collection</returns>
		IList<BonusCard> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all BonusCard based on the type field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BonusCard collection</returns>
		IList<BonusCard> SelectByType ( string type );

        /// <summary>
        /// Gets the number of BonusCard with the given type
        /// </summary>
        /// <param name="id">The type</param>
        /// <returns>The count</returns>
        long CountByType ( string type );
        
		/// <summary>
        /// Selects all BonusCard based on the type field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BonusCard collection</returns>
		IList<BonusCard> SelectByType ( int start, int count, string type );
		
 		/// <summary>
        /// Selects all BonusCard based on the code field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BonusCard collection</returns>
		IList<BonusCard> SelectByCode ( string code );

        /// <summary>
        /// Gets the number of BonusCard with the given code
        /// </summary>
        /// <param name="id">The code</param>
        /// <returns>The count</returns>
        long CountByCode ( string code );
        
		/// <summary>
        /// Selects all BonusCard based on the code field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BonusCard collection</returns>
		IList<BonusCard> SelectByCode ( int start, int count, string code );
		
 		/// <summary>
        /// Selects all BonusCard based on the orions field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BonusCard collection</returns>
		IList<BonusCard> SelectByOrions ( int orions );

        /// <summary>
        /// Gets the number of BonusCard with the given orions
        /// </summary>
        /// <param name="id">The orions</param>
        /// <returns>The count</returns>
        long CountByOrions ( int orions );
        
		/// <summary>
        /// Selects all BonusCard based on the orions field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BonusCard collection</returns>
		IList<BonusCard> SelectByOrions ( int start, int count, int orions );
		
 		/// <summary>
        /// Selects all BonusCard based on the used field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BonusCard collection</returns>
		IList<BonusCard> SelectByUsed ( bool used );

        /// <summary>
        /// Gets the number of BonusCard with the given used
        /// </summary>
        /// <param name="id">The used</param>
        /// <returns>The count</returns>
        long CountByUsed ( bool used );
        
		/// <summary>
        /// Selects all BonusCard based on the used field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BonusCard collection</returns>
		IList<BonusCard> SelectByUsed ( int start, int count, bool used );
		
 		/// <summary>
        /// Selects all BonusCard based on the usedBy field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The BonusCard collection</returns>
		IList<BonusCard> SelectByUsedBy ( Principal usedBy );

        /// <summary>
        /// Gets the number of BonusCard with the given usedBy
        /// </summary>
        /// <param name="id">The usedBy</param>
        /// <returns>The count</returns>
        long CountByUsedBy ( Principal usedBy );
        
		/// <summary>
        /// Selects all BonusCard based on the usedBy field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The BonusCard collection</returns>
		IList<BonusCard> SelectByUsedBy ( int start, int count, Principal usedBy );
		
 		#endregion ExtendedMethods

	};
}
