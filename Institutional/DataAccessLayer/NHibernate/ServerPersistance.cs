using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using Institutional.Core;

namespace Institutional.DataAccessLayer {
	
	internal class ServerPersistance : 
			NHibernatePersistance<Server>, IServerPersistance {
	
		#region Static Access
		
		internal static ServerPersistance CreateSession()
		{
			return new ServerPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedServer) );
		}
				
		internal static ServerPersistance AttachSession( IPersistanceSession owner )
		{
			ServerPersistance persistance = new ServerPersistance ( owner.Session as ISession, typeof(SpecializedServer) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static ServerPersistance globalSession = null;
        internal static ServerPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static ServerPersistance GetSession()
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
		
		internal static ServerPersistance GetValidatedSession()
        {
            ServerPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private ServerPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Server Create()
		{	
			SpecializedServer entity = new SpecializedServer ();
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
		
 		public IList<Server> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedServer e where e.Id = '{0}'", id);
		}

		public IList<Server> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedServer e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Server> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedServer e where e.Name = '{0}'", name);
		}

		public IList<Server> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedServer e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<Server> SelectByUrl ( string url )
		{
			return SelectByUrl (-1, -1, url );
		}
		
		public long CountByUrl ( string url )
		{
			return ExecuteScalar("select count(*) from SpecializedServer e where e.Url = '{0}'", url);
		}

		public IList<Server> SelectByUrl ( int start, int count, string url )
		{
			IList list = Query(start, count, "from SpecializedServer e where e.Url like '{0}'", url);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : Server
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfUrl );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( Server e ) 
        {
			return ValidateStringMaxSize( "Server", "Name", e.Name, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfUrl ( Server e ) 
        {
			return ValidateStringMaxSize( "Server", "Url", e.Url, 100 );
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
