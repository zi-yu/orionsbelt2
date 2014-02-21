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
    /// Handles persistance for Product objects
    /// </summary>
	public interface IProductPersistance : IPersistance<Product> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Product based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Product collection</returns>
		IList<Product> SelectById ( int id );

        /// <summary>
        /// Gets the number of Product with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Product based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Product collection</returns>
		IList<Product> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Product based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Product collection</returns>
		IList<Product> SelectByName ( string name );

        /// <summary>
        /// Gets the number of Product with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all Product based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Product collection</returns>
		IList<Product> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all Product based on the price field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Product collection</returns>
		IList<Product> SelectByPrice ( int price );

        /// <summary>
        /// Gets the number of Product with the given price
        /// </summary>
        /// <param name="id">The price</param>
        /// <returns>The count</returns>
        long CountByPrice ( int price );
        
		/// <summary>
        /// Selects all Product based on the price field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Product collection</returns>
		IList<Product> SelectByPrice ( int start, int count, int price );
		
 		/// <summary>
        /// Selects all Product based on the type field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Product collection</returns>
		IList<Product> SelectByType ( string type );

        /// <summary>
        /// Gets the number of Product with the given type
        /// </summary>
        /// <param name="id">The type</param>
        /// <returns>The count</returns>
        long CountByType ( string type );
        
		/// <summary>
        /// Selects all Product based on the type field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Product collection</returns>
		IList<Product> SelectByType ( int start, int count, string type );
		
 		/// <summary>
        /// Selects all Product based on the quantity field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Product collection</returns>
		IList<Product> SelectByQuantity ( int quantity );

        /// <summary>
        /// Gets the number of Product with the given quantity
        /// </summary>
        /// <param name="id">The quantity</param>
        /// <returns>The count</returns>
        long CountByQuantity ( int quantity );
        
		/// <summary>
        /// Selects all Product based on the quantity field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Product collection</returns>
		IList<Product> SelectByQuantity ( int start, int count, int quantity );
		
 		/// <summary>
        /// Selects all Product based on the market field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Product collection</returns>
		IList<Product> SelectByMarket ( Market market );

        /// <summary>
        /// Gets the number of Product with the given market
        /// </summary>
        /// <param name="id">The market</param>
        /// <returns>The count</returns>
        long CountByMarket ( Market market );
        
		/// <summary>
        /// Selects all Product based on the market field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Product collection</returns>
		IList<Product> SelectByMarket ( int start, int count, Market market );
		
 		#endregion ExtendedMethods

	};
}
