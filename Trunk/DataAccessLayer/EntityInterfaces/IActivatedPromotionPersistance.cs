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
    /// Handles persistance for ActivatedPromotion objects
    /// </summary>
	public interface IActivatedPromotionPersistance : IPersistance<ActivatedPromotion> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all ActivatedPromotion based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ActivatedPromotion collection</returns>
		IList<ActivatedPromotion> SelectById ( int id );

        /// <summary>
        /// Gets the number of ActivatedPromotion with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all ActivatedPromotion based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ActivatedPromotion collection</returns>
		IList<ActivatedPromotion> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all ActivatedPromotion based on the used field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ActivatedPromotion collection</returns>
		IList<ActivatedPromotion> SelectByUsed ( bool used );

        /// <summary>
        /// Gets the number of ActivatedPromotion with the given used
        /// </summary>
        /// <param name="id">The used</param>
        /// <returns>The count</returns>
        long CountByUsed ( bool used );
        
		/// <summary>
        /// Selects all ActivatedPromotion based on the used field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ActivatedPromotion collection</returns>
		IList<ActivatedPromotion> SelectByUsed ( int start, int count, bool used );
		
 		/// <summary>
        /// Selects all ActivatedPromotion based on the code field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ActivatedPromotion collection</returns>
		IList<ActivatedPromotion> SelectByCode ( string code );

        /// <summary>
        /// Gets the number of ActivatedPromotion with the given code
        /// </summary>
        /// <param name="id">The code</param>
        /// <returns>The count</returns>
        long CountByCode ( string code );
        
		/// <summary>
        /// Selects all ActivatedPromotion based on the code field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ActivatedPromotion collection</returns>
		IList<ActivatedPromotion> SelectByCode ( int start, int count, string code );
		
 		/// <summary>
        /// Selects all ActivatedPromotion based on the promotion field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ActivatedPromotion collection</returns>
		IList<ActivatedPromotion> SelectByPromotion ( Promotion promotion );

        /// <summary>
        /// Gets the number of ActivatedPromotion with the given promotion
        /// </summary>
        /// <param name="id">The promotion</param>
        /// <returns>The count</returns>
        long CountByPromotion ( Promotion promotion );
        
		/// <summary>
        /// Selects all ActivatedPromotion based on the promotion field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ActivatedPromotion collection</returns>
		IList<ActivatedPromotion> SelectByPromotion ( int start, int count, Promotion promotion );
		
 		/// <summary>
        /// Selects all ActivatedPromotion based on the principal field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The ActivatedPromotion collection</returns>
		IList<ActivatedPromotion> SelectByPrincipal ( Principal principal );

        /// <summary>
        /// Gets the number of ActivatedPromotion with the given principal
        /// </summary>
        /// <param name="id">The principal</param>
        /// <returns>The count</returns>
        long CountByPrincipal ( Principal principal );
        
		/// <summary>
        /// Selects all ActivatedPromotion based on the principal field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The ActivatedPromotion collection</returns>
		IList<ActivatedPromotion> SelectByPrincipal ( int start, int count, Principal principal );
		
 		#endregion ExtendedMethods

	};
}
