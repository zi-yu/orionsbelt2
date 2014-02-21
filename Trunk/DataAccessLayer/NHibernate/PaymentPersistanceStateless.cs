using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class PaymentPersistanceStateless : 
			NHibernatePersistanceStateless<Payment>, IPaymentPersistance {
	
		#region Static Access
		
		internal static PaymentPersistanceStateless CreateSession()
		{
			return new PaymentPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedPayment) );
		}
				
		internal static PaymentPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			PaymentPersistanceStateless persistance = new PaymentPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedPayment) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static PaymentPersistanceStateless globalSession = null;
        internal static PaymentPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static PaymentPersistanceStateless GetSession()
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
		
		internal static PaymentPersistanceStateless GetValidatedSession()
        {
            PaymentPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private PaymentPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Payment Create()
		{	
			SpecializedPayment entity = new SpecializedPayment ();
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
		
 		public IList<Payment> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedPayment e where e.Id = '{0}'", id);
		}

		public IList<Payment> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedPayment e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Payment> SelectByPrincipalId ( int principalId )
		{
			return SelectByPrincipalId (-1, -1, principalId );
		}
		
		public long CountByPrincipalId ( int principalId )
		{
			return ExecuteScalar("select count(*) from SpecializedPayment e where e.PrincipalId = '{0}'", principalId);
		}

		public IList<Payment> SelectByPrincipalId ( int start, int count, int principalId )
		{
			IList list = Query(start, count, "from SpecializedPayment e where e.PrincipalId = {0}", principalId);
			return ToTypedCollection(list);
		}
		
 		public IList<Payment> SelectByMethod ( string method )
		{
			return SelectByMethod (-1, -1, method );
		}
		
		public long CountByMethod ( string method )
		{
			return ExecuteScalar("select count(*) from SpecializedPayment e where e.Method = '{0}'", method);
		}

		public IList<Payment> SelectByMethod ( int start, int count, string method )
		{
			IList list = Query(start, count, "from SpecializedPayment e where e.Method like '{0}'", method);
			return ToTypedCollection(list);
		}
		
 		public IList<Payment> SelectByRequest ( string request )
		{
			return SelectByRequest (-1, -1, request );
		}
		
		public long CountByRequest ( string request )
		{
			return ExecuteScalar("select count(*) from SpecializedPayment e where e.Request = '{0}'", request);
		}

		public IList<Payment> SelectByRequest ( int start, int count, string request )
		{
			IList list = Query(start, count, "from SpecializedPayment e where e.Request like '{0}'", request);
			return ToTypedCollection(list);
		}
		
 		public IList<Payment> SelectByResponse ( string response )
		{
			return SelectByResponse (-1, -1, response );
		}
		
		public long CountByResponse ( string response )
		{
			return ExecuteScalar("select count(*) from SpecializedPayment e where e.Response = '{0}'", response);
		}

		public IList<Payment> SelectByResponse ( int start, int count, string response )
		{
			IList list = Query(start, count, "from SpecializedPayment e where e.Response like '{0}'", response);
			return ToTypedCollection(list);
		}
		
 		public IList<Payment> SelectByRequestId ( string requestId )
		{
			return SelectByRequestId (-1, -1, requestId );
		}
		
		public long CountByRequestId ( string requestId )
		{
			return ExecuteScalar("select count(*) from SpecializedPayment e where e.RequestId = '{0}'", requestId);
		}

		public IList<Payment> SelectByRequestId ( int start, int count, string requestId )
		{
			IList list = Query(start, count, "from SpecializedPayment e where e.RequestId like '{0}'", requestId);
			return ToTypedCollection(list);
		}
		
 		public IList<Payment> SelectByVerifyState ( string verifyState )
		{
			return SelectByVerifyState (-1, -1, verifyState );
		}
		
		public long CountByVerifyState ( string verifyState )
		{
			return ExecuteScalar("select count(*) from SpecializedPayment e where e.VerifyState = '{0}'", verifyState);
		}

		public IList<Payment> SelectByVerifyState ( int start, int count, string verifyState )
		{
			IList list = Query(start, count, "from SpecializedPayment e where e.VerifyState like '{0}'", verifyState);
			return ToTypedCollection(list);
		}
		
 		public IList<Payment> SelectByParameters ( string parameters )
		{
			return SelectByParameters (-1, -1, parameters );
		}
		
		public long CountByParameters ( string parameters )
		{
			return ExecuteScalar("select count(*) from SpecializedPayment e where e.Parameters = '{0}'", parameters);
		}

		public IList<Payment> SelectByParameters ( int start, int count, string parameters )
		{
			IList list = Query(start, count, "from SpecializedPayment e where e.Parameters like '{0}'", parameters);
			return ToTypedCollection(list);
		}
		
 		public IList<Payment> SelectByParentPayment ( int parentPayment )
		{
			return SelectByParentPayment (-1, -1, parentPayment );
		}
		
		public long CountByParentPayment ( int parentPayment )
		{
			return ExecuteScalar("select count(*) from SpecializedPayment e where e.ParentPayment = '{0}'", parentPayment);
		}

		public IList<Payment> SelectByParentPayment ( int start, int count, int parentPayment )
		{
			IList list = Query(start, count, "from SpecializedPayment e where e.ParentPayment = {0}", parentPayment);
			return ToTypedCollection(list);
		}
		
 		public IList<Payment> SelectByAmmount ( string ammount )
		{
			return SelectByAmmount (-1, -1, ammount );
		}
		
		public long CountByAmmount ( string ammount )
		{
			return ExecuteScalar("select count(*) from SpecializedPayment e where e.Ammount = '{0}'", ammount);
		}

		public IList<Payment> SelectByAmmount ( int start, int count, string ammount )
		{
			IList list = Query(start, count, "from SpecializedPayment e where e.Ammount like '{0}'", ammount);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : Payment
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfMethod );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfRequest );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfResponse );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfRequestId );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfVerifyState );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfParameters );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfAmmount );
        }
		public static LifecyleVeto ValidateMaxSizeOfMethod ( Payment e ) 
        {
			return ValidateStringMaxSize( "Payment", "Method", e.Method, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfRequest ( Payment e ) 
        {
			return ValidateStringMaxSize( "Payment", "Request", e.Request, 2000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfResponse ( Payment e ) 
        {
			return ValidateStringMaxSize( "Payment", "Response", e.Response, 2000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfRequestId ( Payment e ) 
        {
			return ValidateStringMaxSize( "Payment", "RequestId", e.RequestId, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfVerifyState ( Payment e ) 
        {
			return ValidateStringMaxSize( "Payment", "VerifyState", e.VerifyState, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfParameters ( Payment e ) 
        {
			return ValidateStringMaxSize( "Payment", "Parameters", e.Parameters, 2000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfAmmount ( Payment e ) 
        {
			return ValidateStringMaxSize( "Payment", "Ammount", e.Ammount, 100 );
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
