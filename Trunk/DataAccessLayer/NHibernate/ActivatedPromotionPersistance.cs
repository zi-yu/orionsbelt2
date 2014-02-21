using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class ActivatedPromotionPersistance : 
			NHibernatePersistance<ActivatedPromotion>, IActivatedPromotionPersistance {
	
		#region Static Access
		
		internal static ActivatedPromotionPersistance CreateSession()
		{
			return new ActivatedPromotionPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedActivatedPromotion) );
		}
				
		internal static ActivatedPromotionPersistance AttachSession( IPersistanceSession owner )
		{
			ActivatedPromotionPersistance persistance = new ActivatedPromotionPersistance ( owner.Session as ISession, typeof(SpecializedActivatedPromotion) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static ActivatedPromotionPersistance globalSession = null;
        internal static ActivatedPromotionPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static ActivatedPromotionPersistance GetSession()
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
		
		internal static ActivatedPromotionPersistance GetValidatedSession()
        {
            ActivatedPromotionPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private ActivatedPromotionPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override ActivatedPromotion Create()
		{	
			SpecializedActivatedPromotion entity = new SpecializedActivatedPromotion ();
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
		
 		public IList<ActivatedPromotion> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedActivatedPromotion e where e.Id = '{0}'", id);
		}

		public IList<ActivatedPromotion> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedActivatedPromotion e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<ActivatedPromotion> SelectByUsed ( bool used )
		{
			return SelectByUsed (-1, -1, used );
		}
		
		public long CountByUsed ( bool used )
		{
			return ExecuteScalar("select count(*) from SpecializedActivatedPromotion e where e.Used = '{0}'", used);
		}

		public IList<ActivatedPromotion> SelectByUsed ( int start, int count, bool used )
		{
			IList list = Query(start, count, "from SpecializedActivatedPromotion e where e.Used = {0}", used);
			return ToTypedCollection(list);
		}
		
 		public IList<ActivatedPromotion> SelectByCode ( string code )
		{
			return SelectByCode (-1, -1, code );
		}
		
		public long CountByCode ( string code )
		{
			return ExecuteScalar("select count(*) from SpecializedActivatedPromotion e where e.Code = '{0}'", code);
		}

		public IList<ActivatedPromotion> SelectByCode ( int start, int count, string code )
		{
			IList list = Query(start, count, "from SpecializedActivatedPromotion e where e.Code like '{0}'", code);
			return ToTypedCollection(list);
		}
		
 		public IList<ActivatedPromotion> SelectByPromotion ( Promotion promotion )
		{
			return SelectByPromotion (-1, -1, promotion );
		}
		
		public long CountByPromotion ( Promotion promotion )
		{
			return ExecuteScalar("select count(*) from SpecializedActivatedPromotion e where e.Promotion = '{0}'", promotion);
		}

		public IList<ActivatedPromotion> SelectByPromotion ( int start, int count, Promotion promotion )
		{
			IList list = Query(start, count, "from SpecializedActivatedPromotion e where e.PromotionNHibernate.Id = {0}", promotion.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<ActivatedPromotion> SelectByPrincipal ( Principal principal )
		{
			return SelectByPrincipal (-1, -1, principal );
		}
		
		public long CountByPrincipal ( Principal principal )
		{
			return ExecuteScalar("select count(*) from SpecializedActivatedPromotion e where e.Principal = '{0}'", principal);
		}

		public IList<ActivatedPromotion> SelectByPrincipal ( int start, int count, Principal principal )
		{
			IList list = Query(start, count, "from SpecializedActivatedPromotion e where e.PrincipalNHibernate.Id = {0}", principal.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : ActivatedPromotion
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfCode );
        }
		public static LifecyleVeto ValidateMaxSizeOfCode ( ActivatedPromotion e ) 
        {
			return ValidateStringMaxSize( "ActivatedPromotion", "Code", e.Code, 100 );
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
