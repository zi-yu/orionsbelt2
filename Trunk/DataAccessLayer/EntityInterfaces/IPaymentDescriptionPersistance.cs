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
    /// Handles persistance for PaymentDescription objects
    /// </summary>
	public interface IPaymentDescriptionPersistance : IPersistance<PaymentDescription> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all PaymentDescription based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectById ( int id );

        /// <summary>
        /// Gets the number of PaymentDescription with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all PaymentDescription based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all PaymentDescription based on the type field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectByType ( string type );

        /// <summary>
        /// Gets the number of PaymentDescription with the given type
        /// </summary>
        /// <param name="id">The type</param>
        /// <returns>The count</returns>
        long CountByType ( string type );
        
		/// <summary>
        /// Selects all PaymentDescription based on the type field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectByType ( int start, int count, string type );
		
 		/// <summary>
        /// Selects all PaymentDescription based on the amount field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectByAmount ( int amount );

        /// <summary>
        /// Gets the number of PaymentDescription with the given amount
        /// </summary>
        /// <param name="id">The amount</param>
        /// <returns>The count</returns>
        long CountByAmount ( int amount );
        
		/// <summary>
        /// Selects all PaymentDescription based on the amount field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectByAmount ( int start, int count, int amount );
		
 		/// <summary>
        /// Selects all PaymentDescription based on the bonus field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectByBonus ( int bonus );

        /// <summary>
        /// Gets the number of PaymentDescription with the given bonus
        /// </summary>
        /// <param name="id">The bonus</param>
        /// <returns>The count</returns>
        long CountByBonus ( int bonus );
        
		/// <summary>
        /// Selects all PaymentDescription based on the bonus field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectByBonus ( int start, int count, int bonus );
		
 		/// <summary>
        /// Selects all PaymentDescription based on the cost field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectByCost ( double cost );

        /// <summary>
        /// Gets the number of PaymentDescription with the given cost
        /// </summary>
        /// <param name="id">The cost</param>
        /// <returns>The count</returns>
        long CountByCost ( double cost );
        
		/// <summary>
        /// Selects all PaymentDescription based on the cost field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectByCost ( int start, int count, double cost );
		
 		/// <summary>
        /// Selects all PaymentDescription based on the locale field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectByLocale ( string locale );

        /// <summary>
        /// Gets the number of PaymentDescription with the given locale
        /// </summary>
        /// <param name="id">The locale</param>
        /// <returns>The count</returns>
        long CountByLocale ( string locale );
        
		/// <summary>
        /// Selects all PaymentDescription based on the locale field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectByLocale ( int start, int count, string locale );
		
 		/// <summary>
        /// Selects all PaymentDescription based on the data field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectByData ( string data );

        /// <summary>
        /// Gets the number of PaymentDescription with the given data
        /// </summary>
        /// <param name="id">The data</param>
        /// <returns>The count</returns>
        long CountByData ( string data );
        
		/// <summary>
        /// Selects all PaymentDescription based on the data field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectByData ( int start, int count, string data );
		
 		/// <summary>
        /// Selects all PaymentDescription based on the currency field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectByCurrency ( string currency );

        /// <summary>
        /// Gets the number of PaymentDescription with the given currency
        /// </summary>
        /// <param name="id">The currency</param>
        /// <returns>The count</returns>
        long CountByCurrency ( string currency );
        
		/// <summary>
        /// Selects all PaymentDescription based on the currency field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PaymentDescription collection</returns>
		IList<PaymentDescription> SelectByCurrency ( int start, int count, string currency );
		
 		#endregion ExtendedMethods

	};
}
