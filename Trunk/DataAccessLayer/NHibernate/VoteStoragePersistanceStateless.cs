﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class VoteStoragePersistanceStateless : 
			NHibernatePersistanceStateless<VoteStorage>, IVoteStoragePersistance {
	
		#region Static Access
		
		internal static VoteStoragePersistanceStateless CreateSession()
		{
			return new VoteStoragePersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedVoteStorage) );
		}
				
		internal static VoteStoragePersistanceStateless AttachSession( IPersistanceSession owner )
		{
			VoteStoragePersistanceStateless persistance = new VoteStoragePersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedVoteStorage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static VoteStoragePersistanceStateless globalSession = null;
        internal static VoteStoragePersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static VoteStoragePersistanceStateless GetSession()
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
		
		internal static VoteStoragePersistanceStateless GetValidatedSession()
        {
            VoteStoragePersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private VoteStoragePersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override VoteStorage Create()
		{	
			SpecializedVoteStorage entity = new SpecializedVoteStorage ();
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
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : VoteStorage
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
