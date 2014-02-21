using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class ForumThreadPersistance : 
			NHibernatePersistance<ForumThread>, IForumThreadPersistance {
	
		#region Static Access
		
		internal static ForumThreadPersistance CreateSession()
		{
			return new ForumThreadPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedForumThread) );
		}
				
		internal static ForumThreadPersistance AttachSession( IPersistanceSession owner )
		{
			ForumThreadPersistance persistance = new ForumThreadPersistance ( owner.Session as ISession, typeof(SpecializedForumThread) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static ForumThreadPersistance globalSession = null;
        internal static ForumThreadPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static ForumThreadPersistance GetSession()
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
		
		internal static ForumThreadPersistance GetValidatedSession()
        {
            ForumThreadPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private ForumThreadPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override ForumThread Create()
		{	
			SpecializedForumThread entity = new SpecializedForumThread ();
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
		
 		public IList<ForumThread> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedForumThread e where e.Id = '{0}'", id);
		}

		public IList<ForumThread> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedForumThread e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumThread> SelectByTitle ( string title )
		{
			return SelectByTitle (-1, -1, title );
		}
		
		public long CountByTitle ( string title )
		{
			return ExecuteScalar("select count(*) from SpecializedForumThread e where e.Title = '{0}'", title);
		}

		public IList<ForumThread> SelectByTitle ( int start, int count, string title )
		{
			IList list = Query(start, count, "from SpecializedForumThread e where e.Title like '{0}'", title);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumThread> SelectByTotalViews ( int totalViews )
		{
			return SelectByTotalViews (-1, -1, totalViews );
		}
		
		public long CountByTotalViews ( int totalViews )
		{
			return ExecuteScalar("select count(*) from SpecializedForumThread e where e.TotalViews = '{0}'", totalViews);
		}

		public IList<ForumThread> SelectByTotalViews ( int start, int count, int totalViews )
		{
			IList list = Query(start, count, "from SpecializedForumThread e where e.TotalViews = {0}", totalViews);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumThread> SelectByTotalReplies ( int totalReplies )
		{
			return SelectByTotalReplies (-1, -1, totalReplies );
		}
		
		public long CountByTotalReplies ( int totalReplies )
		{
			return ExecuteScalar("select count(*) from SpecializedForumThread e where e.TotalReplies = '{0}'", totalReplies);
		}

		public IList<ForumThread> SelectByTotalReplies ( int start, int count, int totalReplies )
		{
			IList list = Query(start, count, "from SpecializedForumThread e where e.TotalReplies = {0}", totalReplies);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumThread> SelectByTopic ( ForumTopic topic )
		{
			return SelectByTopic (-1, -1, topic );
		}
		
		public long CountByTopic ( ForumTopic topic )
		{
			return ExecuteScalar("select count(*) from SpecializedForumThread e where e.Topic = '{0}'", topic);
		}

		public IList<ForumThread> SelectByTopic ( int start, int count, ForumTopic topic )
		{
			IList list = Query(start, count, "from SpecializedForumThread e where e.TopicNHibernate.Id = {0}", topic.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumThread> SelectByOwner ( PlayerStorage owner )
		{
			return SelectByOwner (-1, -1, owner );
		}
		
		public long CountByOwner ( PlayerStorage owner )
		{
			return ExecuteScalar("select count(*) from SpecializedForumThread e where e.Owner = '{0}'", owner);
		}

		public IList<ForumThread> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			IList list = Query(start, count, "from SpecializedForumThread e where e.OwnerNHibernate.Id = {0}", owner.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : ForumThread
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfTitle );
        }
		public static LifecyleVeto ValidateMaxSizeOfTitle ( ForumThread e ) 
        {
			return ValidateStringMaxSize( "ForumThread", "Title", e.Title, 100 );
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
