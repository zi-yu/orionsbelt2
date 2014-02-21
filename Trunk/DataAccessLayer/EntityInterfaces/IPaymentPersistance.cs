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
    /// Handles persistance for Payment objects
    /// </summary>
	public interface IPaymentPersistance : IPersistance<Payment> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Payment based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectById ( int id );

        /// <summary>
        /// Gets the number of Payment with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Payment based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Payment based on the principalId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByPrincipalId ( int principalId );

        /// <summary>
        /// Gets the number of Payment with the given principalId
        /// </summary>
        /// <param name="id">The principalId</param>
        /// <returns>The count</returns>
        long CountByPrincipalId ( int principalId );
        
		/// <summary>
        /// Selects all Payment based on the principalId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByPrincipalId ( int start, int count, int principalId );
		
 		/// <summary>
        /// Selects all Payment based on the method field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByMethod ( string method );

        /// <summary>
        /// Gets the number of Payment with the given method
        /// </summary>
        /// <param name="id">The method</param>
        /// <returns>The count</returns>
        long CountByMethod ( string method );
        
		/// <summary>
        /// Selects all Payment based on the method field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByMethod ( int start, int count, string method );
		
 		/// <summary>
        /// Selects all Payment based on the request field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByRequest ( string request );

        /// <summary>
        /// Gets the number of Payment with the given request
        /// </summary>
        /// <param name="id">The request</param>
        /// <returns>The count</returns>
        long CountByRequest ( string request );
        
		/// <summary>
        /// Selects all Payment based on the request field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByRequest ( int start, int count, string request );
		
 		/// <summary>
        /// Selects all Payment based on the response field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByResponse ( string response );

        /// <summary>
        /// Gets the number of Payment with the given response
        /// </summary>
        /// <param name="id">The response</param>
        /// <returns>The count</returns>
        long CountByResponse ( string response );
        
		/// <summary>
        /// Selects all Payment based on the response field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByResponse ( int start, int count, string response );
		
 		/// <summary>
        /// Selects all Payment based on the requestId field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByRequestId ( string requestId );

        /// <summary>
        /// Gets the number of Payment with the given requestId
        /// </summary>
        /// <param name="id">The requestId</param>
        /// <returns>The count</returns>
        long CountByRequestId ( string requestId );
        
		/// <summary>
        /// Selects all Payment based on the requestId field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByRequestId ( int start, int count, string requestId );
		
 		/// <summary>
        /// Selects all Payment based on the verifyState field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByVerifyState ( string verifyState );

        /// <summary>
        /// Gets the number of Payment with the given verifyState
        /// </summary>
        /// <param name="id">The verifyState</param>
        /// <returns>The count</returns>
        long CountByVerifyState ( string verifyState );
        
		/// <summary>
        /// Selects all Payment based on the verifyState field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByVerifyState ( int start, int count, string verifyState );
		
 		/// <summary>
        /// Selects all Payment based on the parameters field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByParameters ( string parameters );

        /// <summary>
        /// Gets the number of Payment with the given parameters
        /// </summary>
        /// <param name="id">The parameters</param>
        /// <returns>The count</returns>
        long CountByParameters ( string parameters );
        
		/// <summary>
        /// Selects all Payment based on the parameters field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByParameters ( int start, int count, string parameters );
		
 		/// <summary>
        /// Selects all Payment based on the parentPayment field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByParentPayment ( int parentPayment );

        /// <summary>
        /// Gets the number of Payment with the given parentPayment
        /// </summary>
        /// <param name="id">The parentPayment</param>
        /// <returns>The count</returns>
        long CountByParentPayment ( int parentPayment );
        
		/// <summary>
        /// Selects all Payment based on the parentPayment field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByParentPayment ( int start, int count, int parentPayment );
		
 		/// <summary>
        /// Selects all Payment based on the ammount field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByAmmount ( string ammount );

        /// <summary>
        /// Gets the number of Payment with the given ammount
        /// </summary>
        /// <param name="id">The ammount</param>
        /// <returns>The count</returns>
        long CountByAmmount ( string ammount );
        
		/// <summary>
        /// Selects all Payment based on the ammount field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Payment collection</returns>
		IList<Payment> SelectByAmmount ( int start, int count, string ammount );
		
 		#endregion ExtendedMethods

	};
}
