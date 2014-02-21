using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class GroupPointsStoragePersistance : 
			NHibernatePersistance<GroupPointsStorage>, IGroupPointsStoragePersistance {
	
		#region Static Access
		
		internal static GroupPointsStoragePersistance CreateSession()
		{
			return new GroupPointsStoragePersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedGroupPointsStorage) );
		}
				
		internal static GroupPointsStoragePersistance AttachSession( IPersistanceSession owner )
		{
			GroupPointsStoragePersistance persistance = new GroupPointsStoragePersistance ( owner.Session as ISession, typeof(SpecializedGroupPointsStorage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static GroupPointsStoragePersistance globalSession = null;
        internal static GroupPointsStoragePersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static GroupPointsStoragePersistance GetSession()
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
		
		internal static GroupPointsStoragePersistance GetValidatedSession()
        {
            GroupPointsStoragePersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private GroupPointsStoragePersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override GroupPointsStorage Create()
		{	
			SpecializedGroupPointsStorage entity = new SpecializedGroupPointsStorage ();
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
		
 		public IList<GroupPointsStorage> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedGroupPointsStorage e where e.Id = '{0}'", id);
		}

		public IList<GroupPointsStorage> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedGroupPointsStorage e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<GroupPointsStorage> SelectByStage ( int stage )
		{
			return SelectByStage (-1, -1, stage );
		}
		
		public long CountByStage ( int stage )
		{
			return ExecuteScalar("select count(*) from SpecializedGroupPointsStorage e where e.Stage = '{0}'", stage);
		}

		public IList<GroupPointsStorage> SelectByStage ( int start, int count, int stage )
		{
			IList list = Query(start, count, "from SpecializedGroupPointsStorage e where e.Stage = {0}", stage);
			return ToTypedCollection(list);
		}
		
 		public IList<GroupPointsStorage> SelectByPontuation ( int pontuation )
		{
			return SelectByPontuation (-1, -1, pontuation );
		}
		
		public long CountByPontuation ( int pontuation )
		{
			return ExecuteScalar("select count(*) from SpecializedGroupPointsStorage e where e.Pontuation = '{0}'", pontuation);
		}

		public IList<GroupPointsStorage> SelectByPontuation ( int start, int count, int pontuation )
		{
			IList list = Query(start, count, "from SpecializedGroupPointsStorage e where e.Pontuation = {0}", pontuation);
			return ToTypedCollection(list);
		}
		
 		public IList<GroupPointsStorage> SelectByWins ( int wins )
		{
			return SelectByWins (-1, -1, wins );
		}
		
		public long CountByWins ( int wins )
		{
			return ExecuteScalar("select count(*) from SpecializedGroupPointsStorage e where e.Wins = '{0}'", wins);
		}

		public IList<GroupPointsStorage> SelectByWins ( int start, int count, int wins )
		{
			IList list = Query(start, count, "from SpecializedGroupPointsStorage e where e.Wins = {0}", wins);
			return ToTypedCollection(list);
		}
		
 		public IList<GroupPointsStorage> SelectByLosses ( int losses )
		{
			return SelectByLosses (-1, -1, losses );
		}
		
		public long CountByLosses ( int losses )
		{
			return ExecuteScalar("select count(*) from SpecializedGroupPointsStorage e where e.Losses = '{0}'", losses);
		}

		public IList<GroupPointsStorage> SelectByLosses ( int start, int count, int losses )
		{
			IList list = Query(start, count, "from SpecializedGroupPointsStorage e where e.Losses = {0}", losses);
			return ToTypedCollection(list);
		}
		
 		public IList<GroupPointsStorage> SelectByRegist ( PrincipalTournament regist )
		{
			return SelectByRegist (-1, -1, regist );
		}
		
		public long CountByRegist ( PrincipalTournament regist )
		{
			return ExecuteScalar("select count(*) from SpecializedGroupPointsStorage e where e.Regist = '{0}'", regist);
		}

		public IList<GroupPointsStorage> SelectByRegist ( int start, int count, PrincipalTournament regist )
		{
			IList list = Query(start, count, "from SpecializedGroupPointsStorage e where e.RegistNHibernate.Id = {0}", regist.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : GroupPointsStorage
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
