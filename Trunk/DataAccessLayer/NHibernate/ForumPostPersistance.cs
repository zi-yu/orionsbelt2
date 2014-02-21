using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class ForumPostPersistance : 
			NHibernatePersistance<ForumPost>, IForumPostPersistance {
	
		#region Static Access
		
		internal static ForumPostPersistance CreateSession()
		{
			return new ForumPostPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedForumPost) );
		}
				
		internal static ForumPostPersistance AttachSession( IPersistanceSession owner )
		{
			ForumPostPersistance persistance = new ForumPostPersistance ( owner.Session as ISession, typeof(SpecializedForumPost) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static ForumPostPersistance globalSession = null;
        internal static ForumPostPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static ForumPostPersistance GetSession()
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
		
		internal static ForumPostPersistance GetValidatedSession()
        {
            ForumPostPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private ForumPostPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override ForumPost Create()
		{	
			SpecializedForumPost entity = new SpecializedForumPost ();
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
		
 		public IList<ForumPost> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedForumPost e where e.Id = '{0}'", id);
		}

		public IList<ForumPost> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedForumPost e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumPost> SelectByText ( string text )
		{
			return SelectByText (-1, -1, text );
		}
		
		public long CountByText ( string text )
		{
			return ExecuteScalar("select count(*) from SpecializedForumPost e where e.Text = '{0}'", text);
		}

		public IList<ForumPost> SelectByText ( int start, int count, string text )
		{
			IList list = Query(start, count, "from SpecializedForumPost e where e.Text like '{0}'", text);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumPost> SelectByThread ( ForumThread thread )
		{
			return SelectByThread (-1, -1, thread );
		}
		
		public long CountByThread ( ForumThread thread )
		{
			return ExecuteScalar("select count(*) from SpecializedForumPost e where e.Thread = '{0}'", thread);
		}

		public IList<ForumPost> SelectByThread ( int start, int count, ForumThread thread )
		{
			IList list = Query(start, count, "from SpecializedForumPost e where e.ThreadNHibernate.Id = {0}", thread.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumPost> SelectByOwner ( PlayerStorage owner )
		{
			return SelectByOwner (-1, -1, owner );
		}
		
		public long CountByOwner ( PlayerStorage owner )
		{
			return ExecuteScalar("select count(*) from SpecializedForumPost e where e.Owner = '{0}'", owner);
		}

		public IList<ForumPost> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			IList list = Query(start, count, "from SpecializedForumPost e where e.OwnerNHibernate.Id = {0}", owner.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : ForumPost
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfText );
        }
		public static LifecyleVeto ValidateMaxSizeOfText ( ForumPost e ) 
        {
			return ValidateStringMaxSize( "ForumPost", "Text", e.Text, 100 );
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
