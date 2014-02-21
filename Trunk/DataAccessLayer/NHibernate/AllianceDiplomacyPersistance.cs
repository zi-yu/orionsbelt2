using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class AllianceDiplomacyPersistance : 
			NHibernatePersistance<AllianceDiplomacy>, IAllianceDiplomacyPersistance {
	
		#region Static Access
		
		internal static AllianceDiplomacyPersistance CreateSession()
		{
			return new AllianceDiplomacyPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedAllianceDiplomacy) );
		}
				
		internal static AllianceDiplomacyPersistance AttachSession( IPersistanceSession owner )
		{
			AllianceDiplomacyPersistance persistance = new AllianceDiplomacyPersistance ( owner.Session as ISession, typeof(SpecializedAllianceDiplomacy) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static AllianceDiplomacyPersistance globalSession = null;
        internal static AllianceDiplomacyPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static AllianceDiplomacyPersistance GetSession()
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
		
		internal static AllianceDiplomacyPersistance GetValidatedSession()
        {
            AllianceDiplomacyPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private AllianceDiplomacyPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override AllianceDiplomacy Create()
		{	
			SpecializedAllianceDiplomacy entity = new SpecializedAllianceDiplomacy ();
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
		
 		public IList<AllianceDiplomacy> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceDiplomacy e where e.Id = '{0}'", id);
		}

		public IList<AllianceDiplomacy> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedAllianceDiplomacy e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<AllianceDiplomacy> SelectByLevel ( string level )
		{
			return SelectByLevel (-1, -1, level );
		}
		
		public long CountByLevel ( string level )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceDiplomacy e where e.Level = '{0}'", level);
		}

		public IList<AllianceDiplomacy> SelectByLevel ( int start, int count, string level )
		{
			IList list = Query(start, count, "from SpecializedAllianceDiplomacy e where e.Level like '{0}'", level);
			return ToTypedCollection(list);
		}
		
 		public IList<AllianceDiplomacy> SelectByAllianceA ( AllianceStorage allianceA )
		{
			return SelectByAllianceA (-1, -1, allianceA );
		}
		
		public long CountByAllianceA ( AllianceStorage allianceA )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceDiplomacy e where e.AllianceA = '{0}'", allianceA);
		}

		public IList<AllianceDiplomacy> SelectByAllianceA ( int start, int count, AllianceStorage allianceA )
		{
			IList list = Query(start, count, "from SpecializedAllianceDiplomacy e where e.AllianceANHibernate.Id = {0}", allianceA.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<AllianceDiplomacy> SelectByAllianceB ( AllianceStorage allianceB )
		{
			return SelectByAllianceB (-1, -1, allianceB );
		}
		
		public long CountByAllianceB ( AllianceStorage allianceB )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceDiplomacy e where e.AllianceB = '{0}'", allianceB);
		}

		public IList<AllianceDiplomacy> SelectByAllianceB ( int start, int count, AllianceStorage allianceB )
		{
			IList list = Query(start, count, "from SpecializedAllianceDiplomacy e where e.AllianceBNHibernate.Id = {0}", allianceB.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : AllianceDiplomacy
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfLevel );
        }
		public static LifecyleVeto ValidateMaxSizeOfLevel ( AllianceDiplomacy e ) 
        {
			return ValidateStringMaxSize( "AllianceDiplomacy", "Level", e.Level, 100 );
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
