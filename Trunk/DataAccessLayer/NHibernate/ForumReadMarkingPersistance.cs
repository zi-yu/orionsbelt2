using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class ForumReadMarkingPersistance : 
			NHibernatePersistance<ForumReadMarking>, IForumReadMarkingPersistance {
	
		#region Static Access
		
		internal static ForumReadMarkingPersistance CreateSession()
		{
			return new ForumReadMarkingPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedForumReadMarking) );
		}
				
		internal static ForumReadMarkingPersistance AttachSession( IPersistanceSession owner )
		{
			ForumReadMarkingPersistance persistance = new ForumReadMarkingPersistance ( owner.Session as ISession, typeof(SpecializedForumReadMarking) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static ForumReadMarkingPersistance globalSession = null;
        internal static ForumReadMarkingPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static ForumReadMarkingPersistance GetSession()
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
		
		internal static ForumReadMarkingPersistance GetValidatedSession()
        {
            ForumReadMarkingPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private ForumReadMarkingPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override ForumReadMarking Create()
		{	
			SpecializedForumReadMarking entity = new SpecializedForumReadMarking ();
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
		
 		public IList<ForumReadMarking> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedForumReadMarking e where e.Id = '{0}'", id);
		}

		public IList<ForumReadMarking> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedForumReadMarking e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumReadMarking> SelectByLastRead ( DateTime lastRead )
		{
			return SelectByLastRead (-1, -1, lastRead );
		}
		
		public long CountByLastRead ( DateTime lastRead )
		{
			return ExecuteScalar("select count(*) from SpecializedForumReadMarking e where e.LastRead = '{0}'", lastRead);
		}

		public IList<ForumReadMarking> SelectByLastRead ( int start, int count, DateTime lastRead )
		{
			throw new NotImplementedException();
		}
		
 		public IList<ForumReadMarking> SelectByPlayer ( PlayerStorage player )
		{
			return SelectByPlayer (-1, -1, player );
		}
		
		public long CountByPlayer ( PlayerStorage player )
		{
			return ExecuteScalar("select count(*) from SpecializedForumReadMarking e where e.Player = '{0}'", player);
		}

		public IList<ForumReadMarking> SelectByPlayer ( int start, int count, PlayerStorage player )
		{
			IList list = Query(start, count, "from SpecializedForumReadMarking e where e.PlayerNHibernate.Id = {0}", player.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<ForumReadMarking> SelectByThread ( ForumThread thread )
		{
			return SelectByThread (-1, -1, thread );
		}
		
		public long CountByThread ( ForumThread thread )
		{
			return ExecuteScalar("select count(*) from SpecializedForumReadMarking e where e.Thread = '{0}'", thread);
		}

		public IList<ForumReadMarking> SelectByThread ( int start, int count, ForumThread thread )
		{
			IList list = Query(start, count, "from SpecializedForumReadMarking e where e.ThreadNHibernate.Id = {0}", thread.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : ForumReadMarking
        {
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
