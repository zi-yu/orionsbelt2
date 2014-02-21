using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class FriendOrFoePersistanceStateless : 
			NHibernatePersistanceStateless<FriendOrFoe>, IFriendOrFoePersistance {
	
		#region Static Access
		
		internal static FriendOrFoePersistanceStateless CreateSession()
		{
			return new FriendOrFoePersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedFriendOrFoe) );
		}
				
		internal static FriendOrFoePersistanceStateless AttachSession( IPersistanceSession owner )
		{
			FriendOrFoePersistanceStateless persistance = new FriendOrFoePersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedFriendOrFoe) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static FriendOrFoePersistanceStateless globalSession = null;
        internal static FriendOrFoePersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static FriendOrFoePersistanceStateless GetSession()
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
		
		internal static FriendOrFoePersistanceStateless GetValidatedSession()
        {
            FriendOrFoePersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private FriendOrFoePersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override FriendOrFoe Create()
		{	
			SpecializedFriendOrFoe entity = new SpecializedFriendOrFoe ();
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
		
 		public IList<FriendOrFoe> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedFriendOrFoe e where e.Id = '{0}'", id);
		}

		public IList<FriendOrFoe> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedFriendOrFoe e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<FriendOrFoe> SelectByIsFriend ( bool isFriend )
		{
			return SelectByIsFriend (-1, -1, isFriend );
		}
		
		public long CountByIsFriend ( bool isFriend )
		{
			return ExecuteScalar("select count(*) from SpecializedFriendOrFoe e where e.IsFriend = '{0}'", isFriend);
		}

		public IList<FriendOrFoe> SelectByIsFriend ( int start, int count, bool isFriend )
		{
			IList list = Query(start, count, "from SpecializedFriendOrFoe e where e.IsFriend = {0}", isFriend);
			return ToTypedCollection(list);
		}
		
 		public IList<FriendOrFoe> SelectBySource ( PlayerStorage source )
		{
			return SelectBySource (-1, -1, source );
		}
		
		public long CountBySource ( PlayerStorage source )
		{
			return ExecuteScalar("select count(*) from SpecializedFriendOrFoe e where e.Source = '{0}'", source);
		}

		public IList<FriendOrFoe> SelectBySource ( int start, int count, PlayerStorage source )
		{
			IList list = Query(start, count, "from SpecializedFriendOrFoe e where e.SourceNHibernate.Id = {0}", source.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<FriendOrFoe> SelectByTarget ( PlayerStorage target )
		{
			return SelectByTarget (-1, -1, target );
		}
		
		public long CountByTarget ( PlayerStorage target )
		{
			return ExecuteScalar("select count(*) from SpecializedFriendOrFoe e where e.Target = '{0}'", target);
		}

		public IList<FriendOrFoe> SelectByTarget ( int start, int count, PlayerStorage target )
		{
			IList list = Query(start, count, "from SpecializedFriendOrFoe e where e.TargetNHibernate.Id = {0}", target.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : FriendOrFoe
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
