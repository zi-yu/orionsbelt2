using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class NecessityPersistanceStateless : 
			NHibernatePersistanceStateless<Necessity>, INecessityPersistance {
	
		#region Static Access
		
		internal static NecessityPersistanceStateless CreateSession()
		{
			return new NecessityPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedNecessity) );
		}
				
		internal static NecessityPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			NecessityPersistanceStateless persistance = new NecessityPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedNecessity) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static NecessityPersistanceStateless globalSession = null;
        internal static NecessityPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static NecessityPersistanceStateless GetSession()
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
		
		internal static NecessityPersistanceStateless GetValidatedSession()
        {
            NecessityPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private NecessityPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Necessity Create()
		{	
			SpecializedNecessity entity = new SpecializedNecessity ();
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
		
 		public IList<Necessity> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedNecessity e where e.Id = '{0}'", id);
		}

		public IList<Necessity> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedNecessity e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Necessity> SelectByType ( string type )
		{
			return SelectByType (-1, -1, type );
		}
		
		public long CountByType ( string type )
		{
			return ExecuteScalar("select count(*) from SpecializedNecessity e where e.Type = '{0}'", type);
		}

		public IList<Necessity> SelectByType ( int start, int count, string type )
		{
			IList list = Query(start, count, "from SpecializedNecessity e where e.Type like '{0}'", type);
			return ToTypedCollection(list);
		}
		
 		public IList<Necessity> SelectByDescription ( string description )
		{
			return SelectByDescription (-1, -1, description );
		}
		
		public long CountByDescription ( string description )
		{
			return ExecuteScalar("select count(*) from SpecializedNecessity e where e.Description = '{0}'", description);
		}

		public IList<Necessity> SelectByDescription ( int start, int count, string description )
		{
			IList list = Query(start, count, "from SpecializedNecessity e where e.Description like '{0}'", description);
			return ToTypedCollection(list);
		}
		
 		public IList<Necessity> SelectByCoordinate ( string coordinate )
		{
			return SelectByCoordinate (-1, -1, coordinate );
		}
		
		public long CountByCoordinate ( string coordinate )
		{
			return ExecuteScalar("select count(*) from SpecializedNecessity e where e.Coordinate = '{0}'", coordinate);
		}

		public IList<Necessity> SelectByCoordinate ( int start, int count, string coordinate )
		{
			IList list = Query(start, count, "from SpecializedNecessity e where e.Coordinate like '{0}'", coordinate);
			return ToTypedCollection(list);
		}
		
 		public IList<Necessity> SelectByStatus ( string status )
		{
			return SelectByStatus (-1, -1, status );
		}
		
		public long CountByStatus ( string status )
		{
			return ExecuteScalar("select count(*) from SpecializedNecessity e where e.Status = '{0}'", status);
		}

		public IList<Necessity> SelectByStatus ( int start, int count, string status )
		{
			IList list = Query(start, count, "from SpecializedNecessity e where e.Status like '{0}'", status);
			return ToTypedCollection(list);
		}
		
 		public IList<Necessity> SelectByCreator ( PlayerStorage creator )
		{
			return SelectByCreator (-1, -1, creator );
		}
		
		public long CountByCreator ( PlayerStorage creator )
		{
			return ExecuteScalar("select count(*) from SpecializedNecessity e where e.Creator = '{0}'", creator);
		}

		public IList<Necessity> SelectByCreator ( int start, int count, PlayerStorage creator )
		{
			IList list = Query(start, count, "from SpecializedNecessity e where e.CreatorNHibernate.Id = {0}", creator.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<Necessity> SelectByAlliance ( AllianceStorage alliance )
		{
			return SelectByAlliance (-1, -1, alliance );
		}
		
		public long CountByAlliance ( AllianceStorage alliance )
		{
			return ExecuteScalar("select count(*) from SpecializedNecessity e where e.Alliance = '{0}'", alliance);
		}

		public IList<Necessity> SelectByAlliance ( int start, int count, AllianceStorage alliance )
		{
			IList list = Query(start, count, "from SpecializedNecessity e where e.AllianceNHibernate.Id = {0}", alliance.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : Necessity
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfDescription );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfCoordinate );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfStatus );
        }
		public static LifecyleVeto ValidateMaxSizeOfType ( Necessity e ) 
        {
			return ValidateStringMaxSize( "Necessity", "Type", e.Type, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfDescription ( Necessity e ) 
        {
			return ValidateStringMaxSize( "Necessity", "Description", e.Description, 1000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfCoordinate ( Necessity e ) 
        {
			return ValidateStringMaxSize( "Necessity", "Coordinate", e.Coordinate, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfStatus ( Necessity e ) 
        {
			return ValidateStringMaxSize( "Necessity", "Status", e.Status, 100 );
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
