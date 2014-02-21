using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class InvoicePersistance : 
			NHibernatePersistance<Invoice>, IInvoicePersistance {
	
		#region Static Access
		
		internal static InvoicePersistance CreateSession()
		{
			return new InvoicePersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedInvoice) );
		}
				
		internal static InvoicePersistance AttachSession( IPersistanceSession owner )
		{
			InvoicePersistance persistance = new InvoicePersistance ( owner.Session as ISession, typeof(SpecializedInvoice) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static InvoicePersistance globalSession = null;
        internal static InvoicePersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static InvoicePersistance GetSession()
		{
			System.Web.HttpContext context = System.Web.HttpContext.Current;
			
			if (context == null) {
                return CreateSession();
            }

			if( context.Items == null ) {
				return CreateSession();
			}

            object persistance = context.Items["Persistance"];
			NHibernatePersistance<Principal> session = null;
			
			if( persistance != null ) {
				session = (NHibernatePersistance<Principal>) persistance;
			} else {
                session = PrincipalPersistance.CreateSession();
				context.Items["Persistance"] = session;
			}
			
			ISession nhSession = session.Session as ISession;
            if (nhSession != null && !NHibernateUtilities.IsSessionOpen(nhSession) ) {
				nhSession.Dispose();
                session.NHibernateSession = NHibernateUtilities.OpenSession;
            }
			
			return AttachSession( session );
		}
		
		internal static InvoicePersistance GetValidatedSession()
        {
            InvoicePersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private InvoicePersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Invoice Create()
		{	
			SpecializedInvoice entity = new SpecializedInvoice ();
            entity.NHibernateSession = NHibernateSession;
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
		
 		public IList<Invoice> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedInvoice e where e.Id = '{0}'", id);
		}

		public IList<Invoice> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedInvoice e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Invoice> SelectByIdentifier ( string identifier )
		{
			return SelectByIdentifier (-1, -1, identifier );
		}
		
		public long CountByIdentifier ( string identifier )
		{
			return ExecuteScalar("select count(*) from SpecializedInvoice e where e.Identifier = '{0}'", identifier);
		}

		public IList<Invoice> SelectByIdentifier ( int start, int count, string identifier )
		{
			IList list = Query(start, count, "from SpecializedInvoice e where e.Identifier like '{0}'", identifier);
			return ToTypedCollection(list);
		}
		
 		public IList<Invoice> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedInvoice e where e.Name = '{0}'", name);
		}

		public IList<Invoice> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedInvoice e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<Invoice> SelectByNif ( string nif )
		{
			return SelectByNif (-1, -1, nif );
		}
		
		public long CountByNif ( string nif )
		{
			return ExecuteScalar("select count(*) from SpecializedInvoice e where e.Nif = '{0}'", nif);
		}

		public IList<Invoice> SelectByNif ( int start, int count, string nif )
		{
			IList list = Query(start, count, "from SpecializedInvoice e where e.Nif like '{0}'", nif);
			return ToTypedCollection(list);
		}
		
 		public IList<Invoice> SelectByMoney ( double money )
		{
			return SelectByMoney (-1, -1, money );
		}
		
		public long CountByMoney ( double money )
		{
			return ExecuteScalar("select count(*) from SpecializedInvoice e where e.Money = '{0}'", money);
		}

		public IList<Invoice> SelectByMoney ( int start, int count, double money )
		{
			throw new NotImplementedException();
		}
		
 		public IList<Invoice> SelectByCountry ( string country )
		{
			return SelectByCountry (-1, -1, country );
		}
		
		public long CountByCountry ( string country )
		{
			return ExecuteScalar("select count(*) from SpecializedInvoice e where e.Country = '{0}'", country);
		}

		public IList<Invoice> SelectByCountry ( int start, int count, string country )
		{
			IList list = Query(start, count, "from SpecializedInvoice e where e.Country like '{0}'", country);
			return ToTypedCollection(list);
		}
		
 		public IList<Invoice> SelectByTransaction ( Transaction transaction )
		{
			return SelectByTransaction (-1, -1, transaction );
		}
		
		public long CountByTransaction ( Transaction transaction )
		{
			return ExecuteScalar("select count(*) from SpecializedInvoice e where e.Transaction = '{0}'", transaction);
		}

		public IList<Invoice> SelectByTransaction ( int start, int count, Transaction transaction )
		{
			IList list = Query(start, count, "from SpecializedInvoice e where e.TransactionNHibernate.Id = {0}", transaction.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<Invoice> SelectByPayment ( Payment payment )
		{
			return SelectByPayment (-1, -1, payment );
		}
		
		public long CountByPayment ( Payment payment )
		{
			return ExecuteScalar("select count(*) from SpecializedInvoice e where e.Payment = '{0}'", payment);
		}

		public IList<Invoice> SelectByPayment ( int start, int count, Payment payment )
		{
			IList list = Query(start, count, "from SpecializedInvoice e where e.PaymentNHibernate.Id = {0}", payment.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : Invoice
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfIdentifier );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfNif );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfCountry );
        }
		public static LifecyleVeto ValidateMaxSizeOfIdentifier ( Invoice e ) 
        {
			return ValidateStringMaxSize( "Invoice", "Identifier", e.Identifier, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfName ( Invoice e ) 
        {
			return ValidateStringMaxSize( "Invoice", "Name", e.Name, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfNif ( Invoice e ) 
        {
			return ValidateStringMaxSize( "Invoice", "Nif", e.Nif, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfCountry ( Invoice e ) 
        {
			return ValidateStringMaxSize( "Invoice", "Country", e.Country, 100 );
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
