using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class GlobalStatsPersistance : 
			NHibernatePersistance<GlobalStats>, IGlobalStatsPersistance {
	
		#region Static Access
		
		internal static GlobalStatsPersistance CreateSession()
		{
			return new GlobalStatsPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedGlobalStats) );
		}
				
		internal static GlobalStatsPersistance AttachSession( IPersistanceSession owner )
		{
			GlobalStatsPersistance persistance = new GlobalStatsPersistance ( owner.Session as ISession, typeof(SpecializedGlobalStats) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static GlobalStatsPersistance globalSession = null;
        internal static GlobalStatsPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static GlobalStatsPersistance GetSession()
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
		
		internal static GlobalStatsPersistance GetValidatedSession()
        {
            GlobalStatsPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private GlobalStatsPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override GlobalStats Create()
		{	
			SpecializedGlobalStats entity = new SpecializedGlobalStats ();
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
		
 		public IList<GlobalStats> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedGlobalStats e where e.Id = '{0}'", id);
		}

		public IList<GlobalStats> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedGlobalStats e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<GlobalStats> SelectByType ( string type )
		{
			return SelectByType (-1, -1, type );
		}
		
		public long CountByType ( string type )
		{
			return ExecuteScalar("select count(*) from SpecializedGlobalStats e where e.Type = '{0}'", type);
		}

		public IList<GlobalStats> SelectByType ( int start, int count, string type )
		{
			IList list = Query(start, count, "from SpecializedGlobalStats e where e.Type like '{0}'", type);
			return ToTypedCollection(list);
		}
		
 		public IList<GlobalStats> SelectByTick ( int tick )
		{
			return SelectByTick (-1, -1, tick );
		}
		
		public long CountByTick ( int tick )
		{
			return ExecuteScalar("select count(*) from SpecializedGlobalStats e where e.Tick = '{0}'", tick);
		}

		public IList<GlobalStats> SelectByTick ( int start, int count, int tick )
		{
			IList list = Query(start, count, "from SpecializedGlobalStats e where e.Tick = {0}", tick);
			return ToTypedCollection(list);
		}
		
 		public IList<GlobalStats> SelectByText ( string text )
		{
			return SelectByText (-1, -1, text );
		}
		
		public long CountByText ( string text )
		{
			return ExecuteScalar("select count(*) from SpecializedGlobalStats e where e.Text = '{0}'", text);
		}

		public IList<GlobalStats> SelectByText ( int start, int count, string text )
		{
			IList list = Query(start, count, "from SpecializedGlobalStats e where e.Text like '{0}'", text);
			return ToTypedCollection(list);
		}
		
 		public IList<GlobalStats> SelectByNumber ( double number )
		{
			return SelectByNumber (-1, -1, number );
		}
		
		public long CountByNumber ( double number )
		{
			return ExecuteScalar("select count(*) from SpecializedGlobalStats e where e.Number = '{0}'", number);
		}

		public IList<GlobalStats> SelectByNumber ( int start, int count, double number )
		{
			throw new NotImplementedException();
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : GlobalStats
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfText );
        }
		public static LifecyleVeto ValidateMaxSizeOfType ( GlobalStats e ) 
        {
			return ValidateStringMaxSize( "GlobalStats", "Type", e.Type, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfText ( GlobalStats e ) 
        {
			return ValidateStringMaxSize( "GlobalStats", "Text", e.Text, 100 );
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
