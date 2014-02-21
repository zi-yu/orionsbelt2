using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class TransactionPersistanceStateless : 
			NHibernatePersistanceStateless<Transaction>, ITransactionPersistance {
	
		#region Static Access
		
		internal static TransactionPersistanceStateless CreateSession()
		{
			return new TransactionPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedTransaction) );
		}
				
		internal static TransactionPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			TransactionPersistanceStateless persistance = new TransactionPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedTransaction) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static TransactionPersistanceStateless globalSession = null;
        internal static TransactionPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static TransactionPersistanceStateless GetSession()
		{
			System.Web.HttpContext context = System.Web.HttpContext.Current;
			
			if (context == null) {
                return CreateSession();
            }

			if( context.Items == null ) {
				return CreateSession();
			}

            object persistance = context.Items["PersistanceStateless"];
			NHibernatePersistanceStateless<Principal> session = null;
			
			if( persistance != null ) {
				session = (NHibernatePersistanceStateless<Principal>) persistance;
			} else {
                session = PrincipalPersistanceStateless.CreateSession();
				context.Items["PersistanceStateless"] = session;
			}
			
			IStatelessSession nhSession = session.Session as IStatelessSession;
            if (nhSession != null && !NHibernateUtilities.IsSessionOpen(nhSession) ) {
				nhSession.Dispose();
                session.NHibernateSession = NHibernateUtilities.OpenStatelessSession;
            }
			
			return AttachSession( session );
		}
		
		internal static TransactionPersistanceStateless GetValidatedSession()
        {
            TransactionPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private TransactionPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Transaction Create()
		{	
			SpecializedTransaction entity = new SpecializedTransaction ();
            return entity;
		}

		/// <summary>
        /// Adds logic validation to the entities
        /// </summary>
        public override void AddValidators()
        {
			AddValidation(this);
        }
        
		#endregion IPersistance
		
		#region ExtendedMethods		
		
 		public IList<Transaction> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedTransaction e where e.Id = '{0}'", id);
		}

		public IList<Transaction> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedTransaction e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Transaction> SelectByTransactionContext ( string transactionContext )
		{
			return SelectByTransactionContext (-1, -1, transactionContext );
		}
		
		public long CountByTransactionContext ( string transactionContext )
		{
			return ExecuteScalar("select count(*) from SpecializedTransaction e where e.TransactionContext = '{0}'", transactionContext);
		}

		public IList<Transaction> SelectByTransactionContext ( int start, int count, string transactionContext )
		{
			IList list = Query(start, count, "from SpecializedTransaction e where e.TransactionContext like '{0}'", transactionContext);
			return ToTypedCollection(list);
		}
		
 		public IList<Transaction> SelectByPrincipalIdSpend ( int principalIdSpend )
		{
			return SelectByPrincipalIdSpend (-1, -1, principalIdSpend );
		}
		
		public long CountByPrincipalIdSpend ( int principalIdSpend )
		{
			return ExecuteScalar("select count(*) from SpecializedTransaction e where e.PrincipalIdSpend = '{0}'", principalIdSpend);
		}

		public IList<Transaction> SelectByPrincipalIdSpend ( int start, int count, int principalIdSpend )
		{
			IList list = Query(start, count, "from SpecializedTransaction e where e.PrincipalIdSpend = {0}", principalIdSpend);
			return ToTypedCollection(list);
		}
		
 		public IList<Transaction> SelectByIdentityTypeSpend ( string identityTypeSpend )
		{
			return SelectByIdentityTypeSpend (-1, -1, identityTypeSpend );
		}
		
		public long CountByIdentityTypeSpend ( string identityTypeSpend )
		{
			return ExecuteScalar("select count(*) from SpecializedTransaction e where e.IdentityTypeSpend = '{0}'", identityTypeSpend);
		}

		public IList<Transaction> SelectByIdentityTypeSpend ( int start, int count, string identityTypeSpend )
		{
			IList list = Query(start, count, "from SpecializedTransaction e where e.IdentityTypeSpend like '{0}'", identityTypeSpend);
			return ToTypedCollection(list);
		}
		
 		public IList<Transaction> SelectByIdentifierSpend ( int identifierSpend )
		{
			return SelectByIdentifierSpend (-1, -1, identifierSpend );
		}
		
		public long CountByIdentifierSpend ( int identifierSpend )
		{
			return ExecuteScalar("select count(*) from SpecializedTransaction e where e.IdentifierSpend = '{0}'", identifierSpend);
		}

		public IList<Transaction> SelectByIdentifierSpend ( int start, int count, int identifierSpend )
		{
			IList list = Query(start, count, "from SpecializedTransaction e where e.IdentifierSpend = {0}", identifierSpend);
			return ToTypedCollection(list);
		}
		
 		public IList<Transaction> SelectByCreditsSpend ( int creditsSpend )
		{
			return SelectByCreditsSpend (-1, -1, creditsSpend );
		}
		
		public long CountByCreditsSpend ( int creditsSpend )
		{
			return ExecuteScalar("select count(*) from SpecializedTransaction e where e.CreditsSpend = '{0}'", creditsSpend);
		}

		public IList<Transaction> SelectByCreditsSpend ( int start, int count, int creditsSpend )
		{
			IList list = Query(start, count, "from SpecializedTransaction e where e.CreditsSpend = {0}", creditsSpend);
			return ToTypedCollection(list);
		}
		
 		public IList<Transaction> SelectBySpendCurrentCredits ( int spendCurrentCredits )
		{
			return SelectBySpendCurrentCredits (-1, -1, spendCurrentCredits );
		}
		
		public long CountBySpendCurrentCredits ( int spendCurrentCredits )
		{
			return ExecuteScalar("select count(*) from SpecializedTransaction e where e.SpendCurrentCredits = '{0}'", spendCurrentCredits);
		}

		public IList<Transaction> SelectBySpendCurrentCredits ( int start, int count, int spendCurrentCredits )
		{
			IList list = Query(start, count, "from SpecializedTransaction e where e.SpendCurrentCredits = {0}", spendCurrentCredits);
			return ToTypedCollection(list);
		}
		
 		public IList<Transaction> SelectByIdentityTypeGain ( string identityTypeGain )
		{
			return SelectByIdentityTypeGain (-1, -1, identityTypeGain );
		}
		
		public long CountByIdentityTypeGain ( string identityTypeGain )
		{
			return ExecuteScalar("select count(*) from SpecializedTransaction e where e.IdentityTypeGain = '{0}'", identityTypeGain);
		}

		public IList<Transaction> SelectByIdentityTypeGain ( int start, int count, string identityTypeGain )
		{
			IList list = Query(start, count, "from SpecializedTransaction e where e.IdentityTypeGain like '{0}'", identityTypeGain);
			return ToTypedCollection(list);
		}
		
 		public IList<Transaction> SelectByIdentifierGain ( int identifierGain )
		{
			return SelectByIdentifierGain (-1, -1, identifierGain );
		}
		
		public long CountByIdentifierGain ( int identifierGain )
		{
			return ExecuteScalar("select count(*) from SpecializedTransaction e where e.IdentifierGain = '{0}'", identifierGain);
		}

		public IList<Transaction> SelectByIdentifierGain ( int start, int count, int identifierGain )
		{
			IList list = Query(start, count, "from SpecializedTransaction e where e.IdentifierGain = {0}", identifierGain);
			return ToTypedCollection(list);
		}
		
 		public IList<Transaction> SelectByCreditsGain ( int creditsGain )
		{
			return SelectByCreditsGain (-1, -1, creditsGain );
		}
		
		public long CountByCreditsGain ( int creditsGain )
		{
			return ExecuteScalar("select count(*) from SpecializedTransaction e where e.CreditsGain = '{0}'", creditsGain);
		}

		public IList<Transaction> SelectByCreditsGain ( int start, int count, int creditsGain )
		{
			IList list = Query(start, count, "from SpecializedTransaction e where e.CreditsGain = {0}", creditsGain);
			return ToTypedCollection(list);
		}
		
 		public IList<Transaction> SelectByGainCurrentCredits ( int gainCurrentCredits )
		{
			return SelectByGainCurrentCredits (-1, -1, gainCurrentCredits );
		}
		
		public long CountByGainCurrentCredits ( int gainCurrentCredits )
		{
			return ExecuteScalar("select count(*) from SpecializedTransaction e where e.GainCurrentCredits = '{0}'", gainCurrentCredits);
		}

		public IList<Transaction> SelectByGainCurrentCredits ( int start, int count, int gainCurrentCredits )
		{
			IList list = Query(start, count, "from SpecializedTransaction e where e.GainCurrentCredits = {0}", gainCurrentCredits);
			return ToTypedCollection(list);
		}
		
 		public IList<Transaction> SelectByTick ( int tick )
		{
			return SelectByTick (-1, -1, tick );
		}
		
		public long CountByTick ( int tick )
		{
			return ExecuteScalar("select count(*) from SpecializedTransaction e where e.Tick = '{0}'", tick);
		}

		public IList<Transaction> SelectByTick ( int start, int count, int tick )
		{
			IList list = Query(start, count, "from SpecializedTransaction e where e.Tick = {0}", tick);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : Transaction
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfTransactionContext );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfIdentityTypeSpend );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfIdentityTypeGain );
        }
		public static LifecyleVeto ValidateMaxSizeOfTransactionContext ( Transaction e ) 
        {
			return ValidateStringMaxSize( "Transaction", "TransactionContext", e.TransactionContext, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfIdentityTypeSpend ( Transaction e ) 
        {
			return ValidateStringMaxSize( "Transaction", "IdentityTypeSpend", e.IdentityTypeSpend, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfIdentityTypeGain ( Transaction e ) 
        {
			return ValidateStringMaxSize( "Transaction", "IdentityTypeGain", e.IdentityTypeGain, 100 );
		}

		public static LifecyleVeto ValidateStringMaxSize( string entityName, string propertyName, string val, int maxSize ) 
        {
			if( string.IsNullOrEmpty( val ) ) {
				return LifecyleVeto.Continue;
			}
			
			if( val.Length > maxSize ) {
				throw new DALException("The `{4}' property of `{0}' has too many chars (max: {1}, found:{2}, text:{3})", entityName, maxSize, val.Length, val, propertyName);
			}
			
			return LifecyleVeto.Continue;
		}

		#endregion Validation
		
	};
}
