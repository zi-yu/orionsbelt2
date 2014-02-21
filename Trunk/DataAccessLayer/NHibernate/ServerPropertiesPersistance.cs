using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class ServerPropertiesPersistance : 
			NHibernatePersistance<ServerProperties>, IServerPropertiesPersistance {
	
		#region Static Access
		
		internal static ServerPropertiesPersistance CreateSession()
		{
			return new ServerPropertiesPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedServerProperties) );
		}
				
		internal static ServerPropertiesPersistance AttachSession( IPersistanceSession owner )
		{
			ServerPropertiesPersistance persistance = new ServerPropertiesPersistance ( owner.Session as ISession, typeof(SpecializedServerProperties) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static ServerPropertiesPersistance globalSession = null;
        internal static ServerPropertiesPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static ServerPropertiesPersistance GetSession()
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
		
		internal static ServerPropertiesPersistance GetValidatedSession()
        {
            ServerPropertiesPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private ServerPropertiesPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override ServerProperties Create()
		{	
			SpecializedServerProperties entity = new SpecializedServerProperties ();
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
		
 		public IList<ServerProperties> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedServerProperties e where e.Id = '{0}'", id);
		}

		public IList<ServerProperties> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedServerProperties e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<ServerProperties> SelectByCurrentTick ( int currentTick )
		{
			return SelectByCurrentTick (-1, -1, currentTick );
		}
		
		public long CountByCurrentTick ( int currentTick )
		{
			return ExecuteScalar("select count(*) from SpecializedServerProperties e where e.CurrentTick = '{0}'", currentTick);
		}

		public IList<ServerProperties> SelectByCurrentTick ( int start, int count, int currentTick )
		{
			IList list = Query(start, count, "from SpecializedServerProperties e where e.CurrentTick = {0}", currentTick);
			return ToTypedCollection(list);
		}
		
 		public IList<ServerProperties> SelectByLastTickDate ( DateTime lastTickDate )
		{
			return SelectByLastTickDate (-1, -1, lastTickDate );
		}
		
		public long CountByLastTickDate ( DateTime lastTickDate )
		{
			return ExecuteScalar("select count(*) from SpecializedServerProperties e where e.LastTickDate = '{0}'", lastTickDate);
		}

		public IList<ServerProperties> SelectByLastTickDate ( int start, int count, DateTime lastTickDate )
		{
			throw new NotImplementedException();
		}
		
 		public IList<ServerProperties> SelectByRunning ( bool running )
		{
			return SelectByRunning (-1, -1, running );
		}
		
		public long CountByRunning ( bool running )
		{
			return ExecuteScalar("select count(*) from SpecializedServerProperties e where e.Running = '{0}'", running);
		}

		public IList<ServerProperties> SelectByRunning ( int start, int count, bool running )
		{
			IList list = Query(start, count, "from SpecializedServerProperties e where e.Running = {0}", running);
			return ToTypedCollection(list);
		}
		
 		public IList<ServerProperties> SelectByMillisPerTick ( int millisPerTick )
		{
			return SelectByMillisPerTick (-1, -1, millisPerTick );
		}
		
		public long CountByMillisPerTick ( int millisPerTick )
		{
			return ExecuteScalar("select count(*) from SpecializedServerProperties e where e.MillisPerTick = '{0}'", millisPerTick);
		}

		public IList<ServerProperties> SelectByMillisPerTick ( int start, int count, int millisPerTick )
		{
			IList list = Query(start, count, "from SpecializedServerProperties e where e.MillisPerTick = {0}", millisPerTick);
			return ToTypedCollection(list);
		}
		
 		public IList<ServerProperties> SelectByUseWebClock ( bool useWebClock )
		{
			return SelectByUseWebClock (-1, -1, useWebClock );
		}
		
		public long CountByUseWebClock ( bool useWebClock )
		{
			return ExecuteScalar("select count(*) from SpecializedServerProperties e where e.UseWebClock = '{0}'", useWebClock);
		}

		public IList<ServerProperties> SelectByUseWebClock ( int start, int count, bool useWebClock )
		{
			IList list = Query(start, count, "from SpecializedServerProperties e where e.UseWebClock = {0}", useWebClock);
			return ToTypedCollection(list);
		}
		
 		public IList<ServerProperties> SelectByMaxPlayers ( int maxPlayers )
		{
			return SelectByMaxPlayers (-1, -1, maxPlayers );
		}
		
		public long CountByMaxPlayers ( int maxPlayers )
		{
			return ExecuteScalar("select count(*) from SpecializedServerProperties e where e.MaxPlayers = '{0}'", maxPlayers);
		}

		public IList<ServerProperties> SelectByMaxPlayers ( int start, int count, int maxPlayers )
		{
			IList list = Query(start, count, "from SpecializedServerProperties e where e.MaxPlayers = {0}", maxPlayers);
			return ToTypedCollection(list);
		}
		
 		public IList<ServerProperties> SelectByVacationTicksPerWeek ( int vacationTicksPerWeek )
		{
			return SelectByVacationTicksPerWeek (-1, -1, vacationTicksPerWeek );
		}
		
		public long CountByVacationTicksPerWeek ( int vacationTicksPerWeek )
		{
			return ExecuteScalar("select count(*) from SpecializedServerProperties e where e.VacationTicksPerWeek = '{0}'", vacationTicksPerWeek);
		}

		public IList<ServerProperties> SelectByVacationTicksPerWeek ( int start, int count, int vacationTicksPerWeek )
		{
			IList list = Query(start, count, "from SpecializedServerProperties e where e.VacationTicksPerWeek = {0}", vacationTicksPerWeek);
			return ToTypedCollection(list);
		}
		
 		public IList<ServerProperties> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedServerProperties e where e.Name = '{0}'", name);
		}

		public IList<ServerProperties> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedServerProperties e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<ServerProperties> SelectByBaseUrl ( string baseUrl )
		{
			return SelectByBaseUrl (-1, -1, baseUrl );
		}
		
		public long CountByBaseUrl ( string baseUrl )
		{
			return ExecuteScalar("select count(*) from SpecializedServerProperties e where e.BaseUrl = '{0}'", baseUrl);
		}

		public IList<ServerProperties> SelectByBaseUrl ( int start, int count, string baseUrl )
		{
			IList list = Query(start, count, "from SpecializedServerProperties e where e.BaseUrl like '{0}'", baseUrl);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : ServerProperties
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfBaseUrl );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( ServerProperties e ) 
        {
			return ValidateStringMaxSize( "ServerProperties", "Name", e.Name, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfBaseUrl ( ServerProperties e ) 
        {
			return ValidateStringMaxSize( "ServerProperties", "BaseUrl", e.BaseUrl, 100 );
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
