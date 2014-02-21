using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class MedalPersistanceStateless : 
			NHibernatePersistanceStateless<Medal>, IMedalPersistance {
	
		#region Static Access
		
		internal static MedalPersistanceStateless CreateSession()
		{
			return new MedalPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedMedal) );
		}
				
		internal static MedalPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			MedalPersistanceStateless persistance = new MedalPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedMedal) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static MedalPersistanceStateless globalSession = null;
        internal static MedalPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static MedalPersistanceStateless GetSession()
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
		
		internal static MedalPersistanceStateless GetValidatedSession()
        {
            MedalPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private MedalPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Medal Create()
		{	
			SpecializedMedal entity = new SpecializedMedal ();
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
		
 		public IList<Medal> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedMedal e where e.Id = '{0}'", id);
		}

		public IList<Medal> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedMedal e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Medal> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedMedal e where e.Name = '{0}'", name);
		}

		public IList<Medal> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedMedal e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<Medal> SelectByIsAuto ( bool isAuto )
		{
			return SelectByIsAuto (-1, -1, isAuto );
		}
		
		public long CountByIsAuto ( bool isAuto )
		{
			return ExecuteScalar("select count(*) from SpecializedMedal e where e.IsAuto = '{0}'", isAuto);
		}

		public IList<Medal> SelectByIsAuto ( int start, int count, bool isAuto )
		{
			IList list = Query(start, count, "from SpecializedMedal e where e.IsAuto = {0}", isAuto);
			return ToTypedCollection(list);
		}
		
 		public IList<Medal> SelectByPlayer ( PlayerStorage player )
		{
			return SelectByPlayer (-1, -1, player );
		}
		
		public long CountByPlayer ( PlayerStorage player )
		{
			return ExecuteScalar("select count(*) from SpecializedMedal e where e.Player = '{0}'", player);
		}

		public IList<Medal> SelectByPlayer ( int start, int count, PlayerStorage player )
		{
			IList list = Query(start, count, "from SpecializedMedal e where e.PlayerNHibernate.Id = {0}", player.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<Medal> SelectByPrincipal ( Principal principal )
		{
			return SelectByPrincipal (-1, -1, principal );
		}
		
		public long CountByPrincipal ( Principal principal )
		{
			return ExecuteScalar("select count(*) from SpecializedMedal e where e.Principal = '{0}'", principal);
		}

		public IList<Medal> SelectByPrincipal ( int start, int count, Principal principal )
		{
			IList list = Query(start, count, "from SpecializedMedal e where e.PrincipalNHibernate.Id = {0}", principal.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : Medal
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( Medal e ) 
        {
			return ValidateStringMaxSize( "Medal", "Name", e.Name, 100 );
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
