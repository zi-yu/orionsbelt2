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
    /// Handles persistance for Transaction objects
    /// </summary>
	public interface ITransactionPersistance : IPersistance<Transaction> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Transaction based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectById ( int id );

        /// <summary>
        /// Gets the number of Transaction with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Transaction based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Transaction based on the transactionContext field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByTransactionContext ( string transactionContext );

        /// <summary>
        /// Gets the number of Transaction with the given transactionContext
        /// </summary>
        /// <param name="id">The transactionContext</param>
        /// <returns>The count</returns>
        long CountByTransactionContext ( string transactionContext );
        
		/// <summary>
        /// Selects all Transaction based on the transactionContext field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByTransactionContext ( int start, int count, string transactionContext );
		
 		/// <summary>
        /// Selects all Transaction based on the principalIdSpend field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByPrincipalIdSpend ( int principalIdSpend );

        /// <summary>
        /// Gets the number of Transaction with the given principalIdSpend
        /// </summary>
        /// <param name="id">The principalIdSpend</param>
        /// <returns>The count</returns>
        long CountByPrincipalIdSpend ( int principalIdSpend );
        
		/// <summary>
        /// Selects all Transaction based on the principalIdSpend field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByPrincipalIdSpend ( int start, int count, int principalIdSpend );
		
 		/// <summary>
        /// Selects all Transaction based on the identityTypeSpend field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByIdentityTypeSpend ( string identityTypeSpend );

        /// <summary>
        /// Gets the number of Transaction with the given identityTypeSpend
        /// </summary>
        /// <param name="id">The identityTypeSpend</param>
        /// <returns>The count</returns>
        long CountByIdentityTypeSpend ( string identityTypeSpend );
        
		/// <summary>
        /// Selects all Transaction based on the identityTypeSpend field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByIdentityTypeSpend ( int start, int count, string identityTypeSpend );
		
 		/// <summary>
        /// Selects all Transaction based on the identifierSpend field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByIdentifierSpend ( int identifierSpend );

        /// <summary>
        /// Gets the number of Transaction with the given identifierSpend
        /// </summary>
        /// <param name="id">The identifierSpend</param>
        /// <returns>The count</returns>
        long CountByIdentifierSpend ( int identifierSpend );
        
		/// <summary>
        /// Selects all Transaction based on the identifierSpend field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByIdentifierSpend ( int start, int count, int identifierSpend );
		
 		/// <summary>
        /// Selects all Transaction based on the creditsSpend field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByCreditsSpend ( int creditsSpend );

        /// <summary>
        /// Gets the number of Transaction with the given creditsSpend
        /// </summary>
        /// <param name="id">The creditsSpend</param>
        /// <returns>The count</returns>
        long CountByCreditsSpend ( int creditsSpend );
        
		/// <summary>
        /// Selects all Transaction based on the creditsSpend field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByCreditsSpend ( int start, int count, int creditsSpend );
		
 		/// <summary>
        /// Selects all Transaction based on the spendCurrentCredits field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectBySpendCurrentCredits ( int spendCurrentCredits );

        /// <summary>
        /// Gets the number of Transaction with the given spendCurrentCredits
        /// </summary>
        /// <param name="id">The spendCurrentCredits</param>
        /// <returns>The count</returns>
        long CountBySpendCurrentCredits ( int spendCurrentCredits );
        
		/// <summary>
        /// Selects all Transaction based on the spendCurrentCredits field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectBySpendCurrentCredits ( int start, int count, int spendCurrentCredits );
		
 		/// <summary>
        /// Selects all Transaction based on the identityTypeGain field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByIdentityTypeGain ( string identityTypeGain );

        /// <summary>
        /// Gets the number of Transaction with the given identityTypeGain
        /// </summary>
        /// <param name="id">The identityTypeGain</param>
        /// <returns>The count</returns>
        long CountByIdentityTypeGain ( string identityTypeGain );
        
		/// <summary>
        /// Selects all Transaction based on the identityTypeGain field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByIdentityTypeGain ( int start, int count, string identityTypeGain );
		
 		/// <summary>
        /// Selects all Transaction based on the identifierGain field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByIdentifierGain ( int identifierGain );

        /// <summary>
        /// Gets the number of Transaction with the given identifierGain
        /// </summary>
        /// <param name="id">The identifierGain</param>
        /// <returns>The count</returns>
        long CountByIdentifierGain ( int identifierGain );
        
		/// <summary>
        /// Selects all Transaction based on the identifierGain field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByIdentifierGain ( int start, int count, int identifierGain );
		
 		/// <summary>
        /// Selects all Transaction based on the creditsGain field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByCreditsGain ( int creditsGain );

        /// <summary>
        /// Gets the number of Transaction with the given creditsGain
        /// </summary>
        /// <param name="id">The creditsGain</param>
        /// <returns>The count</returns>
        long CountByCreditsGain ( int creditsGain );
        
		/// <summary>
        /// Selects all Transaction based on the creditsGain field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByCreditsGain ( int start, int count, int creditsGain );
		
 		/// <summary>
        /// Selects all Transaction based on the gainCurrentCredits field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByGainCurrentCredits ( int gainCurrentCredits );

        /// <summary>
        /// Gets the number of Transaction with the given gainCurrentCredits
        /// </summary>
        /// <param name="id">The gainCurrentCredits</param>
        /// <returns>The count</returns>
        long CountByGainCurrentCredits ( int gainCurrentCredits );
        
		/// <summary>
        /// Selects all Transaction based on the gainCurrentCredits field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByGainCurrentCredits ( int start, int count, int gainCurrentCredits );
		
 		/// <summary>
        /// Selects all Transaction based on the tick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByTick ( int tick );

        /// <summary>
        /// Gets the number of Transaction with the given tick
        /// </summary>
        /// <param name="id">The tick</param>
        /// <returns>The count</returns>
        long CountByTick ( int tick );
        
		/// <summary>
        /// Selects all Transaction based on the tick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Transaction collection</returns>
		IList<Transaction> SelectByTick ( int start, int count, int tick );
		
 		#endregion ExtendedMethods

	};
}
