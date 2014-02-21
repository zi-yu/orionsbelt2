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
    /// Handles persistance for Invoice objects
    /// </summary>
	public interface IInvoicePersistance : IPersistance<Invoice> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Invoice based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectById ( int id );

        /// <summary>
        /// Gets the number of Invoice with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Invoice based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Invoice based on the identifier field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectByIdentifier ( string identifier );

        /// <summary>
        /// Gets the number of Invoice with the given identifier
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns>The count</returns>
        long CountByIdentifier ( string identifier );
        
		/// <summary>
        /// Selects all Invoice based on the identifier field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectByIdentifier ( int start, int count, string identifier );
		
 		/// <summary>
        /// Selects all Invoice based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectByName ( string name );

        /// <summary>
        /// Gets the number of Invoice with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all Invoice based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all Invoice based on the nif field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectByNif ( string nif );

        /// <summary>
        /// Gets the number of Invoice with the given nif
        /// </summary>
        /// <param name="id">The nif</param>
        /// <returns>The count</returns>
        long CountByNif ( string nif );
        
		/// <summary>
        /// Selects all Invoice based on the nif field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectByNif ( int start, int count, string nif );
		
 		/// <summary>
        /// Selects all Invoice based on the money field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectByMoney ( double money );

        /// <summary>
        /// Gets the number of Invoice with the given money
        /// </summary>
        /// <param name="id">The money</param>
        /// <returns>The count</returns>
        long CountByMoney ( double money );
        
		/// <summary>
        /// Selects all Invoice based on the money field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectByMoney ( int start, int count, double money );
		
 		/// <summary>
        /// Selects all Invoice based on the country field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectByCountry ( string country );

        /// <summary>
        /// Gets the number of Invoice with the given country
        /// </summary>
        /// <param name="id">The country</param>
        /// <returns>The count</returns>
        long CountByCountry ( string country );
        
		/// <summary>
        /// Selects all Invoice based on the country field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectByCountry ( int start, int count, string country );
		
 		/// <summary>
        /// Selects all Invoice based on the transaction field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectByTransaction ( Transaction transaction );

        /// <summary>
        /// Gets the number of Invoice with the given transaction
        /// </summary>
        /// <param name="id">The transaction</param>
        /// <returns>The count</returns>
        long CountByTransaction ( Transaction transaction );
        
		/// <summary>
        /// Selects all Invoice based on the transaction field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectByTransaction ( int start, int count, Transaction transaction );
		
 		/// <summary>
        /// Selects all Invoice based on the payment field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectByPayment ( Payment payment );

        /// <summary>
        /// Gets the number of Invoice with the given payment
        /// </summary>
        /// <param name="id">The payment</param>
        /// <returns>The count</returns>
        long CountByPayment ( Payment payment );
        
		/// <summary>
        /// Selects all Invoice based on the payment field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Invoice collection</returns>
		IList<Invoice> SelectByPayment ( int start, int count, Payment payment );
		
 		#endregion ExtendedMethods

	};
}
