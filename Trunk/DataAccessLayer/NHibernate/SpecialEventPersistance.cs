using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class SpecialEventPersistance : 
			NHibernatePersistance<SpecialEvent>, ISpecialEventPersistance {
	
		#region Static Access
		
		internal static SpecialEventPersistance CreateSession()
		{
			return new SpecialEventPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedSpecialEvent) );
		}
				
		internal static SpecialEventPersistance AttachSession( IPersistanceSession owner )
		{
			SpecialEventPersistance persistance = new SpecialEventPersistance ( owner.Session as ISession, typeof(SpecializedSpecialEvent) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static SpecialEventPersistance globalSession = null;
        internal static SpecialEventPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static SpecialEventPersistance GetSession()
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
		
		internal static SpecialEventPersistance GetValidatedSession()
        {
            SpecialEventPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private SpecialEventPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override SpecialEvent Create()
		{	
			SpecializedSpecialEvent entity = new SpecializedSpecialEvent ();
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
		
 		public IList<SpecialEvent> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedSpecialEvent e where e.Id = '{0}'", id);
		}

		public IList<SpecialEvent> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedSpecialEvent e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<SpecialEvent> SelectByCost ( int cost )
		{
			return SelectByCost (-1, -1, cost );
		}
		
		public long CountByCost ( int cost )
		{
			return ExecuteScalar("select count(*) from SpecializedSpecialEvent e where e.Cost = '{0}'", cost);
		}

		public IList<SpecialEvent> SelectByCost ( int start, int count, int cost )
		{
			IList list = Query(start, count, "from SpecializedSpecialEvent e where e.Cost = {0}", cost);
			return ToTypedCollection(list);
		}
		
 		public IList<SpecialEvent> SelectByToken ( string token )
		{
			return SelectByToken (-1, -1, token );
		}
		
		public long CountByToken ( string token )
		{
			return ExecuteScalar("select count(*) from SpecializedSpecialEvent e where e.Token = '{0}'", token);
		}

		public IList<SpecialEvent> SelectByToken ( int start, int count, string token )
		{
			IList list = Query(start, count, "from SpecializedSpecialEvent e where e.Token like '{0}'", token);
			return ToTypedCollection(list);
		}
		
 		public IList<SpecialEvent> SelectByResorces ( string resorces )
		{
			return SelectByResorces (-1, -1, resorces );
		}
		
		public long CountByResorces ( string resorces )
		{
			return ExecuteScalar("select count(*) from SpecializedSpecialEvent e where e.Resorces = '{0}'", resorces);
		}

		public IList<SpecialEvent> SelectByResorces ( int start, int count, string resorces )
		{
			IList list = Query(start, count, "from SpecializedSpecialEvent e where e.Resorces like '{0}'", resorces);
			return ToTypedCollection(list);
		}
		
 		public IList<SpecialEvent> SelectByBeginDate ( DateTime beginDate )
		{
			return SelectByBeginDate (-1, -1, beginDate );
		}
		
		public long CountByBeginDate ( DateTime beginDate )
		{
			return ExecuteScalar("select count(*) from SpecializedSpecialEvent e where e.BeginDate = '{0}'", beginDate);
		}

		public IList<SpecialEvent> SelectByBeginDate ( int start, int count, DateTime beginDate )
		{
			throw new NotImplementedException();
		}
		
 		public IList<SpecialEvent> SelectByEndDate ( DateTime endDate )
		{
			return SelectByEndDate (-1, -1, endDate );
		}
		
		public long CountByEndDate ( DateTime endDate )
		{
			return ExecuteScalar("select count(*) from SpecializedSpecialEvent e where e.EndDate = '{0}'", endDate);
		}

		public IList<SpecialEvent> SelectByEndDate ( int start, int count, DateTime endDate )
		{
			throw new NotImplementedException();
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : SpecialEvent
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfToken );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfResorces );
        }
		public static LifecyleVeto ValidateMaxSizeOfToken ( SpecialEvent e ) 
        {
			return ValidateStringMaxSize( "SpecialEvent", "Token", e.Token, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfResorces ( SpecialEvent e ) 
        {
			return ValidateStringMaxSize( "SpecialEvent", "Resorces", e.Resorces, 100 );
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
