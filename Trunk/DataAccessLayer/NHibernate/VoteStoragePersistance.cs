using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class VoteStoragePersistance : 
			NHibernatePersistance<VoteStorage>, IVoteStoragePersistance {
	
		#region Static Access
		
		internal static VoteStoragePersistance CreateSession()
		{
			return new VoteStoragePersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedVoteStorage) );
		}
				
		internal static VoteStoragePersistance AttachSession( IPersistanceSession owner )
		{
			VoteStoragePersistance persistance = new VoteStoragePersistance ( owner.Session as ISession, typeof(SpecializedVoteStorage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static VoteStoragePersistance globalSession = null;
        internal static VoteStoragePersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static VoteStoragePersistance GetSession()
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
		
		internal static VoteStoragePersistance GetValidatedSession()
        {
            VoteStoragePersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private VoteStoragePersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override VoteStorage Create()
		{	
			SpecializedVoteStorage entity = new SpecializedVoteStorage ();
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
		
 		public IList<VoteStorage> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedVoteStorage e where e.Id = '{0}'", id);
		}

		public IList<VoteStorage> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedVoteStorage e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<VoteStorage> SelectByData ( string data )
		{
			return SelectByData (-1, -1, data );
		}
		
		public long CountByData ( string data )
		{
			return ExecuteScalar("select count(*) from SpecializedVoteStorage e where e.Data = '{0}'", data);
		}

		public IList<VoteStorage> SelectByData ( int start, int count, string data )
		{
			IList list = Query(start, count, "from SpecializedVoteStorage e where e.Data like '{0}'", data);
			return ToTypedCollection(list);
		}
		
 		public IList<VoteStorage> SelectByOwnerId ( int ownerId )
		{
			return SelectByOwnerId (-1, -1, ownerId );
		}
		
		public long CountByOwnerId ( int ownerId )
		{
			return ExecuteScalar("select count(*) from SpecializedVoteStorage e where e.OwnerId = '{0}'", ownerId);
		}

		public IList<VoteStorage> SelectByOwnerId ( int start, int count, int ownerId )
		{
			IList list = Query(start, count, "from SpecializedVoteStorage e where e.OwnerId = {0}", ownerId);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : VoteStorage
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfData );
        }
		public static LifecyleVeto ValidateMaxSizeOfData ( VoteStorage e ) 
        {
			return ValidateStringMaxSize( "VoteStorage", "Data", e.Data, 8000 );
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
