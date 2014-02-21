using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using Institutional.Core;

namespace Institutional.DataAccessLayer {
	
	internal class MediaArticlePersistance : 
			NHibernatePersistance<MediaArticle>, IMediaArticlePersistance {
	
		#region Static Access
		
		internal static MediaArticlePersistance CreateSession()
		{
			return new MediaArticlePersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedMediaArticle) );
		}
				
		internal static MediaArticlePersistance AttachSession( IPersistanceSession owner )
		{
			MediaArticlePersistance persistance = new MediaArticlePersistance ( owner.Session as ISession, typeof(SpecializedMediaArticle) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static MediaArticlePersistance globalSession = null;
        internal static MediaArticlePersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static MediaArticlePersistance GetSession()
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
		
		internal static MediaArticlePersistance GetValidatedSession()
        {
            MediaArticlePersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private MediaArticlePersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override MediaArticle Create()
		{	
			SpecializedMediaArticle entity = new SpecializedMediaArticle ();
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
		
 		public IList<MediaArticle> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedMediaArticle e where e.Id = '{0}'", id);
		}

		public IList<MediaArticle> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedMediaArticle e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<MediaArticle> SelectByUrl ( string url )
		{
			return SelectByUrl (-1, -1, url );
		}
		
		public long CountByUrl ( string url )
		{
			return ExecuteScalar("select count(*) from SpecializedMediaArticle e where e.Url = '{0}'", url);
		}

		public IList<MediaArticle> SelectByUrl ( int start, int count, string url )
		{
			IList list = Query(start, count, "from SpecializedMediaArticle e where e.Url like '{0}'", url);
			return ToTypedCollection(list);
		}
		
 		public IList<MediaArticle> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedMediaArticle e where e.Name = '{0}'", name);
		}

		public IList<MediaArticle> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedMediaArticle e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<MediaArticle> SelectByLocale ( string locale )
		{
			return SelectByLocale (-1, -1, locale );
		}
		
		public long CountByLocale ( string locale )
		{
			return ExecuteScalar("select count(*) from SpecializedMediaArticle e where e.Locale = '{0}'", locale);
		}

		public IList<MediaArticle> SelectByLocale ( int start, int count, string locale )
		{
			IList list = Query(start, count, "from SpecializedMediaArticle e where e.Locale like '{0}'", locale);
			return ToTypedCollection(list);
		}
		
 		public IList<MediaArticle> SelectByExceprt ( string exceprt )
		{
			return SelectByExceprt (-1, -1, exceprt );
		}
		
		public long CountByExceprt ( string exceprt )
		{
			return ExecuteScalar("select count(*) from SpecializedMediaArticle e where e.Exceprt = '{0}'", exceprt);
		}

		public IList<MediaArticle> SelectByExceprt ( int start, int count, string exceprt )
		{
			IList list = Query(start, count, "from SpecializedMediaArticle e where e.Exceprt like '{0}'", exceprt);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : MediaArticle
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfUrl );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfLocale );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfExceprt );
        }
		public static LifecyleVeto ValidateMaxSizeOfUrl ( MediaArticle e ) 
        {
			return ValidateStringMaxSize( "MediaArticle", "Url", e.Url, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfName ( MediaArticle e ) 
        {
			return ValidateStringMaxSize( "MediaArticle", "Name", e.Name, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfLocale ( MediaArticle e ) 
        {
			return ValidateStringMaxSize( "MediaArticle", "Locale", e.Locale, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfExceprt ( MediaArticle e ) 
        {
			return ValidateStringMaxSize( "MediaArticle", "Exceprt", e.Exceprt, 100 );
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
