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
    /// Memory persistance for entity.Name
    /// </summary>
	internal class MemoryTransactionPersistance : 
			MemoryPersistance<Transaction>, ITransactionPersistance {
		
		#region IPersistance
		
		public override Transaction Create()
		{
			return new SpecializedMemoryTransaction ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Transaction> SelectById ( int id )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountById ( int id )
		{
			return (long) SelectById ( id ).Count;
		}

		public IList<Transaction> SelectById ( int start, int count, int id )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Transaction> SelectByTransactionContext ( string transactionContext )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.TransactionContext == transactionContext ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTransactionContext ( string transactionContext )
		{
			return (long) SelectByTransactionContext ( transactionContext ).Count;
		}

		public IList<Transaction> SelectByTransactionContext ( int start, int count, string transactionContext )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.TransactionContext == transactionContext ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Transaction> SelectByPrincipalIdSpend ( int principalIdSpend )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.PrincipalIdSpend == principalIdSpend ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPrincipalIdSpend ( int principalIdSpend )
		{
			return (long) SelectByPrincipalIdSpend ( principalIdSpend ).Count;
		}

		public IList<Transaction> SelectByPrincipalIdSpend ( int start, int count, int principalIdSpend )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.PrincipalIdSpend == principalIdSpend ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Transaction> SelectByIdentityTypeSpend ( string identityTypeSpend )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.IdentityTypeSpend == identityTypeSpend ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIdentityTypeSpend ( string identityTypeSpend )
		{
			return (long) SelectByIdentityTypeSpend ( identityTypeSpend ).Count;
		}

		public IList<Transaction> SelectByIdentityTypeSpend ( int start, int count, string identityTypeSpend )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.IdentityTypeSpend == identityTypeSpend ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Transaction> SelectByIdentifierSpend ( int identifierSpend )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.IdentifierSpend == identifierSpend ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIdentifierSpend ( int identifierSpend )
		{
			return (long) SelectByIdentifierSpend ( identifierSpend ).Count;
		}

		public IList<Transaction> SelectByIdentifierSpend ( int start, int count, int identifierSpend )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.IdentifierSpend == identifierSpend ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Transaction> SelectByCreditsSpend ( int creditsSpend )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.CreditsSpend == creditsSpend ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCreditsSpend ( int creditsSpend )
		{
			return (long) SelectByCreditsSpend ( creditsSpend ).Count;
		}

		public IList<Transaction> SelectByCreditsSpend ( int start, int count, int creditsSpend )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.CreditsSpend == creditsSpend ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Transaction> SelectBySpendCurrentCredits ( int spendCurrentCredits )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.SpendCurrentCredits == spendCurrentCredits ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySpendCurrentCredits ( int spendCurrentCredits )
		{
			return (long) SelectBySpendCurrentCredits ( spendCurrentCredits ).Count;
		}

		public IList<Transaction> SelectBySpendCurrentCredits ( int start, int count, int spendCurrentCredits )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.SpendCurrentCredits == spendCurrentCredits ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Transaction> SelectByIdentityTypeGain ( string identityTypeGain )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.IdentityTypeGain == identityTypeGain ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIdentityTypeGain ( string identityTypeGain )
		{
			return (long) SelectByIdentityTypeGain ( identityTypeGain ).Count;
		}

		public IList<Transaction> SelectByIdentityTypeGain ( int start, int count, string identityTypeGain )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.IdentityTypeGain == identityTypeGain ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Transaction> SelectByIdentifierGain ( int identifierGain )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.IdentifierGain == identifierGain ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIdentifierGain ( int identifierGain )
		{
			return (long) SelectByIdentifierGain ( identifierGain ).Count;
		}

		public IList<Transaction> SelectByIdentifierGain ( int start, int count, int identifierGain )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.IdentifierGain == identifierGain ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Transaction> SelectByCreditsGain ( int creditsGain )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.CreditsGain == creditsGain ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCreditsGain ( int creditsGain )
		{
			return (long) SelectByCreditsGain ( creditsGain ).Count;
		}

		public IList<Transaction> SelectByCreditsGain ( int start, int count, int creditsGain )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.CreditsGain == creditsGain ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Transaction> SelectByGainCurrentCredits ( int gainCurrentCredits )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.GainCurrentCredits == gainCurrentCredits ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByGainCurrentCredits ( int gainCurrentCredits )
		{
			return (long) SelectByGainCurrentCredits ( gainCurrentCredits ).Count;
		}

		public IList<Transaction> SelectByGainCurrentCredits ( int start, int count, int gainCurrentCredits )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.GainCurrentCredits == gainCurrentCredits ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Transaction> SelectByTick ( int tick )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.Tick == tick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTick ( int tick )
		{
			return (long) SelectByTick ( tick ).Count;
		}

		public IList<Transaction> SelectByTick ( int start, int count, int tick )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.Tick == tick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Transaction> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCreatedDate ( DateTime createdDate )
		{
			return (long) SelectByCreatedDate ( createdDate ).Count;
		}

		public IList<Transaction> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Transaction> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUpdatedDate ( DateTime updatedDate )
		{
			return (long) SelectByUpdatedDate ( updatedDate ).Count;
		}

		public IList<Transaction> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Transaction> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLastActionUserId ( int lastActionUserId )
		{
			return (long) SelectByLastActionUserId ( lastActionUserId ).Count;
		}

		public IList<Transaction> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Transaction> container = new List<Transaction>();
 			
			foreach( Transaction obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
