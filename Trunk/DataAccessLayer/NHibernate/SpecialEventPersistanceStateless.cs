using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class SpecialEventPersistanceStateless : 
			NHibernatePersistanceStateless<SpecialEvent>, ISpecialEventPersistance {
	
		#region Static Access
		
		internal static SpecialEventPersistanceStateless CreateSession()
		{
			return new SpecialEventPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedSpecialEvent) );
		}
				
		internal static SpecialEventPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			SpecialEventPersistanceStateless persistance = new SpecialEventPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedSpecialEvent) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static SpecialEventPersistanceStateless globalSession = null;
        internal static SpecialEventPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static SpecialEventPersistanceStateless GetSession()
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
		
		internal static SpecialEventPersistanceStateless GetValidatedSession()
        {
            SpecialEventPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private SpecialEventPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override SpecialEvent Create()
		{	
			SpecializedSpecialEvent entity = new SpecializedSpecialEvent ();
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
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : SpecialEvent
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
