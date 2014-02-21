using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class CountryPersistanceStateless : 
			NHibernatePersistanceStateless<Country>, ICountryPersistance {
	
		#region Static Access
		
		internal static CountryPersistanceStateless CreateSession()
		{
			return new CountryPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedCountry) );
		}
				
		internal static CountryPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			CountryPersistanceStateless persistance = new CountryPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedCountry) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static CountryPersistanceStateless globalSession = null;
        internal static CountryPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static CountryPersistanceStateless GetSession()
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
		
		internal static CountryPersistanceStateless GetValidatedSession()
        {
            CountryPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private CountryPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Country Create()
		{	
			SpecializedCountry entity = new SpecializedCountry ();
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
		
 		public IList<Country> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedCountry e where e.Id = '{0}'", id);
		}

		public IList<Country> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedCountry e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Country> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedCountry e where e.Name = '{0}'", name);
		}

		public IList<Country> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedCountry e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<Country> SelectByAbbreviation ( string abbreviation )
		{
			return SelectByAbbreviation (-1, -1, abbreviation );
		}
		
		public long CountByAbbreviation ( string abbreviation )
		{
			return ExecuteScalar("select count(*) from SpecializedCountry e where e.Abbreviation = '{0}'", abbreviation);
		}

		public IList<Country> SelectByAbbreviation ( int start, int count, string abbreviation )
		{
			IList list = Query(start, count, "from SpecializedCountry e where e.Abbreviation like '{0}'", abbreviation);
			return ToTypedCollection(list);
		}
		
 		public IList<Country> SelectByIsEU ( bool isEU )
		{
			return SelectByIsEU (-1, -1, isEU );
		}
		
		public long CountByIsEU ( bool isEU )
		{
			return ExecuteScalar("select count(*) from SpecializedCountry e where e.IsEU = '{0}'", isEU);
		}

		public IList<Country> SelectByIsEU ( int start, int count, bool isEU )
		{
			IList list = Query(start, count, "from SpecializedCountry e where e.IsEU = {0}", isEU);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : Country
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfAbbreviation );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( Country e ) 
        {
			return ValidateStringMaxSize( "Country", "Name", e.Name, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfAbbreviation ( Country e ) 
        {
			return ValidateStringMaxSize( "Country", "Abbreviation", e.Abbreviation, 100 );
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
