using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class PaymentDescriptionPersistance : 
			NHibernatePersistance<PaymentDescription>, IPaymentDescriptionPersistance {
	
		#region Static Access
		
		internal static PaymentDescriptionPersistance CreateSession()
		{
			return new PaymentDescriptionPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedPaymentDescription) );
		}
				
		internal static PaymentDescriptionPersistance AttachSession( IPersistanceSession owner )
		{
			PaymentDescriptionPersistance persistance = new PaymentDescriptionPersistance ( owner.Session as ISession, typeof(SpecializedPaymentDescription) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static PaymentDescriptionPersistance globalSession = null;
        internal static PaymentDescriptionPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static PaymentDescriptionPersistance GetSession()
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
		
		internal static PaymentDescriptionPersistance GetValidatedSession()
        {
            PaymentDescriptionPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private PaymentDescriptionPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override PaymentDescription Create()
		{	
			SpecializedPaymentDescription entity = new SpecializedPaymentDescription ();
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
		
 		public IList<PaymentDescription> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedPaymentDescription e where e.Id = '{0}'", id);
		}

		public IList<PaymentDescription> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedPaymentDescription e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<PaymentDescription> SelectByType ( string type )
		{
			return SelectByType (-1, -1, type );
		}
		
		public long CountByType ( string type )
		{
			return ExecuteScalar("select count(*) from SpecializedPaymentDescription e where e.Type = '{0}'", type);
		}

		public IList<PaymentDescription> SelectByType ( int start, int count, string type )
		{
			IList list = Query(start, count, "from SpecializedPaymentDescription e where e.Type like '{0}'", type);
			return ToTypedCollection(list);
		}
		
 		public IList<PaymentDescription> SelectByAmount ( int amount )
		{
			return SelectByAmount (-1, -1, amount );
		}
		
		public long CountByAmount ( int amount )
		{
			return ExecuteScalar("select count(*) from SpecializedPaymentDescription e where e.Amount = '{0}'", amount);
		}

		public IList<PaymentDescription> SelectByAmount ( int start, int count, int amount )
		{
			IList list = Query(start, count, "from SpecializedPaymentDescription e where e.Amount = {0}", amount);
			return ToTypedCollection(list);
		}
		
 		public IList<PaymentDescription> SelectByBonus ( int bonus )
		{
			return SelectByBonus (-1, -1, bonus );
		}
		
		public long CountByBonus ( int bonus )
		{
			return ExecuteScalar("select count(*) from SpecializedPaymentDescription e where e.Bonus = '{0}'", bonus);
		}

		public IList<PaymentDescription> SelectByBonus ( int start, int count, int bonus )
		{
			IList list = Query(start, count, "from SpecializedPaymentDescription e where e.Bonus = {0}", bonus);
			return ToTypedCollection(list);
		}
		
 		public IList<PaymentDescription> SelectByCost ( double cost )
		{
			return SelectByCost (-1, -1, cost );
		}
		
		public long CountByCost ( double cost )
		{
			return ExecuteScalar("select count(*) from SpecializedPaymentDescription e where e.Cost = '{0}'", cost);
		}

		public IList<PaymentDescription> SelectByCost ( int start, int count, double cost )
		{
			throw new NotImplementedException();
		}
		
 		public IList<PaymentDescription> SelectByLocale ( string locale )
		{
			return SelectByLocale (-1, -1, locale );
		}
		
		public long CountByLocale ( string locale )
		{
			return ExecuteScalar("select count(*) from SpecializedPaymentDescription e where e.Locale = '{0}'", locale);
		}

		public IList<PaymentDescription> SelectByLocale ( int start, int count, string locale )
		{
			IList list = Query(start, count, "from SpecializedPaymentDescription e where e.Locale like '{0}'", locale);
			return ToTypedCollection(list);
		}
		
 		public IList<PaymentDescription> SelectByData ( string data )
		{
			return SelectByData (-1, -1, data );
		}
		
		public long CountByData ( string data )
		{
			return ExecuteScalar("select count(*) from SpecializedPaymentDescription e where e.Data = '{0}'", data);
		}

		public IList<PaymentDescription> SelectByData ( int start, int count, string data )
		{
			IList list = Query(start, count, "from SpecializedPaymentDescription e where e.Data like '{0}'", data);
			return ToTypedCollection(list);
		}
		
 		public IList<PaymentDescription> SelectByCurrency ( string currency )
		{
			return SelectByCurrency (-1, -1, currency );
		}
		
		public long CountByCurrency ( string currency )
		{
			return ExecuteScalar("select count(*) from SpecializedPaymentDescription e where e.Currency = '{0}'", currency);
		}

		public IList<PaymentDescription> SelectByCurrency ( int start, int count, string currency )
		{
			IList list = Query(start, count, "from SpecializedPaymentDescription e where e.Currency like '{0}'", currency);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : PaymentDescription
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfLocale );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfData );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfCurrency );
        }
		public static LifecyleVeto ValidateMaxSizeOfType ( PaymentDescription e ) 
        {
			return ValidateStringMaxSize( "PaymentDescription", "Type", e.Type, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfLocale ( PaymentDescription e ) 
        {
			return ValidateStringMaxSize( "PaymentDescription", "Locale", e.Locale, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfData ( PaymentDescription e ) 
        {
			return ValidateStringMaxSize( "PaymentDescription", "Data", e.Data, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfCurrency ( PaymentDescription e ) 
        {
			return ValidateStringMaxSize( "PaymentDescription", "Currency", e.Currency, 100 );
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
