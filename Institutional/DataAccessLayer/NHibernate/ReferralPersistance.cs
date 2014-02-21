using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using Institutional.Core;

namespace Institutional.DataAccessLayer {
	
	internal class ReferralPersistance : 
			NHibernatePersistance<Referral>, IReferralPersistance {
	
		#region Static Access
		
		internal static ReferralPersistance CreateSession()
		{
			return new ReferralPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedReferral) );
		}
				
		internal static ReferralPersistance AttachSession( IPersistanceSession owner )
		{
			ReferralPersistance persistance = new ReferralPersistance ( owner.Session as ISession, typeof(SpecializedReferral) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static ReferralPersistance globalSession = null;
        internal static ReferralPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static ReferralPersistance GetSession()
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
		
		internal static ReferralPersistance GetValidatedSession()
        {
            ReferralPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private ReferralPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Referral Create()
		{	
			SpecializedReferral entity = new SpecializedReferral ();
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
		
 		public IList<Referral> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedReferral e where e.Id = '{0}'", id);
		}

		public IList<Referral> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedReferral e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Referral> SelectByCode ( int code )
		{
			return SelectByCode (-1, -1, code );
		}
		
		public long CountByCode ( int code )
		{
			return ExecuteScalar("select count(*) from SpecializedReferral e where e.Code = '{0}'", code);
		}

		public IList<Referral> SelectByCode ( int start, int count, int code )
		{
			IList list = Query(start, count, "from SpecializedReferral e where e.Code = {0}", code);
			return ToTypedCollection(list);
		}
		
 		public IList<Referral> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedReferral e where e.Name = '{0}'", name);
		}

		public IList<Referral> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedReferral e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<Referral> SelectBySourceUrl ( string sourceUrl )
		{
			return SelectBySourceUrl (-1, -1, sourceUrl );
		}
		
		public long CountBySourceUrl ( string sourceUrl )
		{
			return ExecuteScalar("select count(*) from SpecializedReferral e where e.SourceUrl = '{0}'", sourceUrl);
		}

		public IList<Referral> SelectBySourceUrl ( int start, int count, string sourceUrl )
		{
			IList list = Query(start, count, "from SpecializedReferral e where e.SourceUrl like '{0}'", sourceUrl);
			return ToTypedCollection(list);
		}
		
 		public IList<Referral> SelectByFilters ( string filters )
		{
			return SelectByFilters (-1, -1, filters );
		}
		
		public long CountByFilters ( string filters )
		{
			return ExecuteScalar("select count(*) from SpecializedReferral e where e.Filters = '{0}'", filters);
		}

		public IList<Referral> SelectByFilters ( int start, int count, string filters )
		{
			IList list = Query(start, count, "from SpecializedReferral e where e.Filters like '{0}'", filters);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : Referral
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfSourceUrl );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfFilters );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( Referral e ) 
        {
			return ValidateStringMaxSize( "Referral", "Name", e.Name, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfSourceUrl ( Referral e ) 
        {
			return ValidateStringMaxSize( "Referral", "SourceUrl", e.SourceUrl, 500 );
		}
		public static LifecyleVeto ValidateMaxSizeOfFilters ( Referral e ) 
        {
			return ValidateStringMaxSize( "Referral", "Filters", e.Filters, 500 );
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
