using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class ExceptionInfoPersistanceStateless : 
			NHibernatePersistanceStateless<ExceptionInfo>, IExceptionInfoPersistance {
	
		#region Static Access
		
		internal static ExceptionInfoPersistanceStateless CreateSession()
		{
			return new ExceptionInfoPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedExceptionInfo) );
		}
				
		internal static ExceptionInfoPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			ExceptionInfoPersistanceStateless persistance = new ExceptionInfoPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedExceptionInfo) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static ExceptionInfoPersistanceStateless globalSession = null;
        internal static ExceptionInfoPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static ExceptionInfoPersistanceStateless GetSession()
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
		
		internal static ExceptionInfoPersistanceStateless GetValidatedSession()
        {
            ExceptionInfoPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private ExceptionInfoPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override ExceptionInfo Create()
		{	
			SpecializedExceptionInfo entity = new SpecializedExceptionInfo ();
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
		
 		public IList<ExceptionInfo> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedExceptionInfo e where e.Id = '{0}'", id);
		}

		public IList<ExceptionInfo> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedExceptionInfo e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<ExceptionInfo> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedExceptionInfo e where e.Name = '{0}'", name);
		}

		public IList<ExceptionInfo> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedExceptionInfo e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<ExceptionInfo> SelectByMessage ( string message )
		{
			return SelectByMessage (-1, -1, message );
		}
		
		public long CountByMessage ( string message )
		{
			return ExecuteScalar("select count(*) from SpecializedExceptionInfo e where e.Message = '{0}'", message);
		}

		public IList<ExceptionInfo> SelectByMessage ( int start, int count, string message )
		{
			IList list = Query(start, count, "from SpecializedExceptionInfo e where e.Message like '{0}'", message);
			return ToTypedCollection(list);
		}
		
 		public IList<ExceptionInfo> SelectByDate ( DateTime date )
		{
			return SelectByDate (-1, -1, date );
		}
		
		public long CountByDate ( DateTime date )
		{
			return ExecuteScalar("select count(*) from SpecializedExceptionInfo e where e.Date = '{0}'", date);
		}

		public IList<ExceptionInfo> SelectByDate ( int start, int count, DateTime date )
		{
			throw new NotImplementedException();
		}
		
 		public IList<ExceptionInfo> SelectByPrincipal ( Principal principal )
		{
			return SelectByPrincipal (-1, -1, principal );
		}
		
		public long CountByPrincipal ( Principal principal )
		{
			return ExecuteScalar("select count(*) from SpecializedExceptionInfo e where e.Principal = '{0}'", principal);
		}

		public IList<ExceptionInfo> SelectByPrincipal ( int start, int count, Principal principal )
		{
			IList list = Query(start, count, "from SpecializedExceptionInfo e where e.PrincipalNHibernate.Id = {0}", principal.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<ExceptionInfo> SelectByUrl ( string url )
		{
			return SelectByUrl (-1, -1, url );
		}
		
		public long CountByUrl ( string url )
		{
			return ExecuteScalar("select count(*) from SpecializedExceptionInfo e where e.Url = '{0}'", url);
		}

		public IList<ExceptionInfo> SelectByUrl ( int start, int count, string url )
		{
			IList list = Query(start, count, "from SpecializedExceptionInfo e where e.Url like '{0}'", url);
			return ToTypedCollection(list);
		}
		
 		public IList<ExceptionInfo> SelectByStackTrace ( string stackTrace )
		{
			return SelectByStackTrace (-1, -1, stackTrace );
		}
		
		public long CountByStackTrace ( string stackTrace )
		{
			return ExecuteScalar("select count(*) from SpecializedExceptionInfo e where e.StackTrace = '{0}'", stackTrace);
		}

		public IList<ExceptionInfo> SelectByStackTrace ( int start, int count, string stackTrace )
		{
			IList list = Query(start, count, "from SpecializedExceptionInfo e where e.StackTrace like '{0}'", stackTrace);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : ExceptionInfo
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfMessage );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfStackTrace );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateRegexOfUrl );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfMessage );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfUrl );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfStackTrace );
        }
		public static LifecyleVeto ValidateExistenceOfName ( ExceptionInfo e ) 
        {
            if( string.IsNullOrEmpty( e.Name ) ) {
				throw new DALException("Entity `{0}' must have a value for property `Name'", e.TypeName);
            }
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfMessage ( ExceptionInfo e ) 
        {
            if( string.IsNullOrEmpty( e.Message ) ) {
				throw new DALException("Entity `{0}' must have a value for property `Message'", e.TypeName);
            }
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfStackTrace ( ExceptionInfo e ) 
        {
            if( string.IsNullOrEmpty( e.StackTrace ) ) {
				throw new DALException("Entity `{0}' must have a value for property `StackTrace'", e.TypeName);
            }
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateRegexOfUrl ( ExceptionInfo e ) 
        {
			if( !Regex.IsMatch(e.Url, "$http://") ) {
				throw new DALException("Entity `{0}' property `Url' with value `{1}' doesn't match regex {2}", e.TypeName, e.Url);
			}
			return LifecyleVeto.Continue;
		}
		public static LifecyleVeto ValidateMaxSizeOfName ( ExceptionInfo e ) 
        {
			return ValidateStringMaxSize( "ExceptionInfo", "Name", e.Name, 15000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfMessage ( ExceptionInfo e ) 
        {
			return ValidateStringMaxSize( "ExceptionInfo", "Message", e.Message, 15000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfUrl ( ExceptionInfo e ) 
        {
			return ValidateStringMaxSize( "ExceptionInfo", "Url", e.Url, 15000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfStackTrace ( ExceptionInfo e ) 
        {
			return ValidateStringMaxSize( "ExceptionInfo", "StackTrace", e.StackTrace, 15000 );
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
