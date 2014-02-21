using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class ForumTopicPersistance : 
			NHibernatePersistance<ForumTopic>, IForumTopicPersistance {
	
		#region Static Access
		
		internal static ForumTopicPersistance CreateSession()
		{
			return new ForumTopicPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedForumTopic) );
		}
				
		internal static ForumTopicPersistance AttachSession( IPersistanceSession owner )
		{
			ForumTopicPersistance persistance = new ForumTopicPersistance ( owner.Session as ISession, typeof(SpecializedForumTopic) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static ForumTopicPersistance globalSession = null;
        internal static ForumTopicPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static ForumTopicPersistance GetSession()
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
		
		internal static ForumTopicPersistance GetValidatedSession()
        {
            ForumTopicPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private ForumTopicPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override ForumTopic Create()
		{	
			SpecializedForumTopic entity = new SpecializedForumTopic ();
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
		
 		public IList<ForumTopic> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedForumTopic e where e.Id = '{0}'", id);
		}

		public IList<ForumTopic> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedForumTopic e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumTopic> SelectByTitle ( string title )
		{
			return SelectByTitle (-1, -1, title );
		}
		
		public long CountByTitle ( string title )
		{
			return ExecuteScalar("select count(*) from SpecializedForumTopic e where e.Title = '{0}'", title);
		}

		public IList<ForumTopic> SelectByTitle ( int start, int count, string title )
		{
			IList list = Query(start, count, "from SpecializedForumTopic e where e.Title like '{0}'", title);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumTopic> SelectByLastPost ( DateTime lastPost )
		{
			return SelectByLastPost (-1, -1, lastPost );
		}
		
		public long CountByLastPost ( DateTime lastPost )
		{
			return ExecuteScalar("select count(*) from SpecializedForumTopic e where e.LastPost = '{0}'", lastPost);
		}

		public IList<ForumTopic> SelectByLastPost ( int start, int count, DateTime lastPost )
		{
			throw new NotImplementedException();
		}
		
 		public IList<ForumTopic> SelectByTotalPosts ( int totalPosts )
		{
			return SelectByTotalPosts (-1, -1, totalPosts );
		}
		
		public long CountByTotalPosts ( int totalPosts )
		{
			return ExecuteScalar("select count(*) from SpecializedForumTopic e where e.TotalPosts = '{0}'", totalPosts);
		}

		public IList<ForumTopic> SelectByTotalPosts ( int start, int count, int totalPosts )
		{
			IList list = Query(start, count, "from SpecializedForumTopic e where e.TotalPosts = {0}", totalPosts);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumTopic> SelectByTotalThreads ( int totalThreads )
		{
			return SelectByTotalThreads (-1, -1, totalThreads );
		}
		
		public long CountByTotalThreads ( int totalThreads )
		{
			return ExecuteScalar("select count(*) from SpecializedForumTopic e where e.TotalThreads = '{0}'", totalThreads);
		}

		public IList<ForumTopic> SelectByTotalThreads ( int start, int count, int totalThreads )
		{
			IList list = Query(start, count, "from SpecializedForumTopic e where e.TotalThreads = {0}", totalThreads);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumTopic> SelectByIsPrivate ( bool isPrivate )
		{
			return SelectByIsPrivate (-1, -1, isPrivate );
		}
		
		public long CountByIsPrivate ( bool isPrivate )
		{
			return ExecuteScalar("select count(*) from SpecializedForumTopic e where e.IsPrivate = '{0}'", isPrivate);
		}

		public IList<ForumTopic> SelectByIsPrivate ( int start, int count, bool isPrivate )
		{
			IList list = Query(start, count, "from SpecializedForumTopic e where e.IsPrivate = {0}", isPrivate);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumTopic> SelectByForumRoles ( string forumRoles )
		{
			return SelectByForumRoles (-1, -1, forumRoles );
		}
		
		public long CountByForumRoles ( string forumRoles )
		{
			return ExecuteScalar("select count(*) from SpecializedForumTopic e where e.ForumRoles = '{0}'", forumRoles);
		}

		public IList<ForumTopic> SelectByForumRoles ( int start, int count, string forumRoles )
		{
			IList list = Query(start, count, "from SpecializedForumTopic e where e.ForumRoles like '{0}'", forumRoles);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumTopic> SelectByDescription ( string description )
		{
			return SelectByDescription (-1, -1, description );
		}
		
		public long CountByDescription ( string description )
		{
			return ExecuteScalar("select count(*) from SpecializedForumTopic e where e.Description = '{0}'", description);
		}

		public IList<ForumTopic> SelectByDescription ( int start, int count, string description )
		{
			IList list = Query(start, count, "from SpecializedForumTopic e where e.Description like '{0}'", description);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : ForumTopic
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfTitle );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfForumRoles );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfDescription );
        }
		public static LifecyleVeto ValidateMaxSizeOfTitle ( ForumTopic e ) 
        {
			return ValidateStringMaxSize( "ForumTopic", "Title", e.Title, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfForumRoles ( ForumTopic e ) 
        {
			return ValidateStringMaxSize( "ForumTopic", "ForumRoles", e.ForumRoles, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfDescription ( ForumTopic e ) 
        {
			return ValidateStringMaxSize( "ForumTopic", "Description", e.Description, 100 );
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
