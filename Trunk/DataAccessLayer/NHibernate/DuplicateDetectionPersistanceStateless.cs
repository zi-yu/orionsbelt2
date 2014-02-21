using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class DuplicateDetectionPersistanceStateless : 
			NHibernatePersistanceStateless<DuplicateDetection>, IDuplicateDetectionPersistance {
	
		#region Static Access
		
		internal static DuplicateDetectionPersistanceStateless CreateSession()
		{
			return new DuplicateDetectionPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedDuplicateDetection) );
		}
				
		internal static DuplicateDetectionPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			DuplicateDetectionPersistanceStateless persistance = new DuplicateDetectionPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedDuplicateDetection) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static DuplicateDetectionPersistanceStateless globalSession = null;
        internal static DuplicateDetectionPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static DuplicateDetectionPersistanceStateless GetSession()
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
		
		internal static DuplicateDetectionPersistanceStateless GetValidatedSession()
        {
            DuplicateDetectionPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private DuplicateDetectionPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override DuplicateDetection Create()
		{	
			SpecializedDuplicateDetection entity = new SpecializedDuplicateDetection ();
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
		
 		public IList<DuplicateDetection> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedDuplicateDetection e where e.Id = '{0}'", id);
		}

		public IList<DuplicateDetection> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedDuplicateDetection e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<DuplicateDetection> SelectByCheater ( int cheater )
		{
			return SelectByCheater (-1, -1, cheater );
		}
		
		public long CountByCheater ( int cheater )
		{
			return ExecuteScalar("select count(*) from SpecializedDuplicateDetection e where e.Cheater = '{0}'", cheater);
		}

		public IList<DuplicateDetection> SelectByCheater ( int start, int count, int cheater )
		{
			IList list = Query(start, count, "from SpecializedDuplicateDetection e where e.Cheater = {0}", cheater);
			return ToTypedCollection(list);
		}
		
 		public IList<DuplicateDetection> SelectByDuplicate ( int duplicate )
		{
			return SelectByDuplicate (-1, -1, duplicate );
		}
		
		public long CountByDuplicate ( int duplicate )
		{
			return ExecuteScalar("select count(*) from SpecializedDuplicateDetection e where e.Duplicate = '{0}'", duplicate);
		}

		public IList<DuplicateDetection> SelectByDuplicate ( int start, int count, int duplicate )
		{
			IList list = Query(start, count, "from SpecializedDuplicateDetection e where e.Duplicate = {0}", duplicate);
			return ToTypedCollection(list);
		}
		
 		public IList<DuplicateDetection> SelectByFindType ( string findType )
		{
			return SelectByFindType (-1, -1, findType );
		}
		
		public long CountByFindType ( string findType )
		{
			return ExecuteScalar("select count(*) from SpecializedDuplicateDetection e where e.FindType = '{0}'", findType);
		}

		public IList<DuplicateDetection> SelectByFindType ( int start, int count, string findType )
		{
			IList list = Query(start, count, "from SpecializedDuplicateDetection e where e.FindType like '{0}'", findType);
			return ToTypedCollection(list);
		}
		
 		public IList<DuplicateDetection> SelectByExtraInfo ( string extraInfo )
		{
			return SelectByExtraInfo (-1, -1, extraInfo );
		}
		
		public long CountByExtraInfo ( string extraInfo )
		{
			return ExecuteScalar("select count(*) from SpecializedDuplicateDetection e where e.ExtraInfo = '{0}'", extraInfo);
		}

		public IList<DuplicateDetection> SelectByExtraInfo ( int start, int count, string extraInfo )
		{
			IList list = Query(start, count, "from SpecializedDuplicateDetection e where e.ExtraInfo like '{0}'", extraInfo);
			return ToTypedCollection(list);
		}
		
 		public IList<DuplicateDetection> SelectByVerified ( bool verified )
		{
			return SelectByVerified (-1, -1, verified );
		}
		
		public long CountByVerified ( bool verified )
		{
			return ExecuteScalar("select count(*) from SpecializedDuplicateDetection e where e.Verified = '{0}'", verified);
		}

		public IList<DuplicateDetection> SelectByVerified ( int start, int count, bool verified )
		{
			IList list = Query(start, count, "from SpecializedDuplicateDetection e where e.Verified = {0}", verified);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : DuplicateDetection
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfFindType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfExtraInfo );
        }
		public static LifecyleVeto ValidateMaxSizeOfFindType ( DuplicateDetection e ) 
        {
			return ValidateStringMaxSize( "DuplicateDetection", "FindType", e.FindType, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfExtraInfo ( DuplicateDetection e ) 
        {
			return ValidateStringMaxSize( "DuplicateDetection", "ExtraInfo", e.ExtraInfo, 100 );
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
