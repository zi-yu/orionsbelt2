using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class LogStoragePersistance : 
			NHibernatePersistance<LogStorage>, ILogStoragePersistance {
	
		#region Static Access
		
		internal static LogStoragePersistance CreateSession()
		{
			return new LogStoragePersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedLogStorage) );
		}
				
		internal static LogStoragePersistance AttachSession( IPersistanceSession owner )
		{
			LogStoragePersistance persistance = new LogStoragePersistance ( owner.Session as ISession, typeof(SpecializedLogStorage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static LogStoragePersistance globalSession = null;
        internal static LogStoragePersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static LogStoragePersistance GetSession()
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
		
		internal static LogStoragePersistance GetValidatedSession()
        {
            LogStoragePersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private LogStoragePersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override LogStorage Create()
		{	
			SpecializedLogStorage entity = new SpecializedLogStorage ();
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
		
 		public IList<LogStorage> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedLogStorage e where e.Id = '{0}'", id);
		}

		public IList<LogStorage> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedLogStorage e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<LogStorage> SelectByDate ( DateTime date )
		{
			return SelectByDate (-1, -1, date );
		}
		
		public long CountByDate ( DateTime date )
		{
			return ExecuteScalar("select count(*) from SpecializedLogStorage e where e.Date = '{0}'", date);
		}

		public IList<LogStorage> SelectByDate ( int start, int count, DateTime date )
		{
			throw new NotImplementedException();
		}
		
 		public IList<LogStorage> SelectByUsername1 ( string username1 )
		{
			return SelectByUsername1 (-1, -1, username1 );
		}
		
		public long CountByUsername1 ( string username1 )
		{
			return ExecuteScalar("select count(*) from SpecializedLogStorage e where e.Username1 = '{0}'", username1);
		}

		public IList<LogStorage> SelectByUsername1 ( int start, int count, string username1 )
		{
			IList list = Query(start, count, "from SpecializedLogStorage e where e.Username1 like '{0}'", username1);
			return ToTypedCollection(list);
		}
		
 		public IList<LogStorage> SelectByLevel ( string level )
		{
			return SelectByLevel (-1, -1, level );
		}
		
		public long CountByLevel ( string level )
		{
			return ExecuteScalar("select count(*) from SpecializedLogStorage e where e.Level = '{0}'", level);
		}

		public IList<LogStorage> SelectByLevel ( int start, int count, string level )
		{
			IList list = Query(start, count, "from SpecializedLogStorage e where e.Level like '{0}'", level);
			return ToTypedCollection(list);
		}
		
 		public IList<LogStorage> SelectByUrl ( string url )
		{
			return SelectByUrl (-1, -1, url );
		}
		
		public long CountByUrl ( string url )
		{
			return ExecuteScalar("select count(*) from SpecializedLogStorage e where e.Url = '{0}'", url);
		}

		public IList<LogStorage> SelectByUrl ( int start, int count, string url )
		{
			IList list = Query(start, count, "from SpecializedLogStorage e where e.Url like '{0}'", url);
			return ToTypedCollection(list);
		}
		
 		public IList<LogStorage> SelectByContent ( string content )
		{
			return SelectByContent (-1, -1, content );
		}
		
		public long CountByContent ( string content )
		{
			return ExecuteScalar("select count(*) from SpecializedLogStorage e where e.Content = '{0}'", content);
		}

		public IList<LogStorage> SelectByContent ( int start, int count, string content )
		{
			IList list = Query(start, count, "from SpecializedLogStorage e where e.Content like '{0}'", content);
			return ToTypedCollection(list);
		}
		
 		public IList<LogStorage> SelectByExceptionInformation ( string exceptionInformation )
		{
			return SelectByExceptionInformation (-1, -1, exceptionInformation );
		}
		
		public long CountByExceptionInformation ( string exceptionInformation )
		{
			return ExecuteScalar("select count(*) from SpecializedLogStorage e where e.ExceptionInformation = '{0}'", exceptionInformation);
		}

		public IList<LogStorage> SelectByExceptionInformation ( int start, int count, string exceptionInformation )
		{
			IList list = Query(start, count, "from SpecializedLogStorage e where e.ExceptionInformation like '{0}'", exceptionInformation);
			return ToTypedCollection(list);
		}
		
 		public IList<LogStorage> SelectByIp ( string ip )
		{
			return SelectByIp (-1, -1, ip );
		}
		
		public long CountByIp ( string ip )
		{
			return ExecuteScalar("select count(*) from SpecializedLogStorage e where e.Ip = '{0}'", ip);
		}

		public IList<LogStorage> SelectByIp ( int start, int count, string ip )
		{
			IList list = Query(start, count, "from SpecializedLogStorage e where e.Ip like '{0}'", ip);
			return ToTypedCollection(list);
		}
		
 		public IList<LogStorage> SelectByType ( string type )
		{
			return SelectByType (-1, -1, type );
		}
		
		public long CountByType ( string type )
		{
			return ExecuteScalar("select count(*) from SpecializedLogStorage e where e.Type = '{0}'", type);
		}

		public IList<LogStorage> SelectByType ( int start, int count, string type )
		{
			IList list = Query(start, count, "from SpecializedLogStorage e where e.Type like '{0}'", type);
			return ToTypedCollection(list);
		}
		
 		public IList<LogStorage> SelectByUsername2 ( string username2 )
		{
			return SelectByUsername2 (-1, -1, username2 );
		}
		
		public long CountByUsername2 ( string username2 )
		{
			return ExecuteScalar("select count(*) from SpecializedLogStorage e where e.Username2 = '{0}'", username2);
		}

		public IList<LogStorage> SelectByUsername2 ( int start, int count, string username2 )
		{
			IList list = Query(start, count, "from SpecializedLogStorage e where e.Username2 like '{0}'", username2);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : LogStorage
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfUsername1 );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfLevel );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfUrl );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfContent );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfExceptionInformation );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfIp );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfUsername2 );
        }
		public static LifecyleVeto ValidateMaxSizeOfUsername1 ( LogStorage e ) 
        {
			return ValidateStringMaxSize( "LogStorage", "Username1", e.Username1, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfLevel ( LogStorage e ) 
        {
			return ValidateStringMaxSize( "LogStorage", "Level", e.Level, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfUrl ( LogStorage e ) 
        {
			return ValidateStringMaxSize( "LogStorage", "Url", e.Url, 6000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfContent ( LogStorage e ) 
        {
			return ValidateStringMaxSize( "LogStorage", "Content", e.Content, 6000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfExceptionInformation ( LogStorage e ) 
        {
			return ValidateStringMaxSize( "LogStorage", "ExceptionInformation", e.ExceptionInformation, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfIp ( LogStorage e ) 
        {
			return ValidateStringMaxSize( "LogStorage", "Ip", e.Ip, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfType ( LogStorage e ) 
        {
			return ValidateStringMaxSize( "LogStorage", "Type", e.Type, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfUsername2 ( LogStorage e ) 
        {
			return ValidateStringMaxSize( "LogStorage", "Username2", e.Username2, 100 );
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
