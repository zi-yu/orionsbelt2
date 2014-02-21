using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class CampaignStatusPersistance : 
			NHibernatePersistance<CampaignStatus>, ICampaignStatusPersistance {
	
		#region Static Access
		
		internal static CampaignStatusPersistance CreateSession()
		{
			return new CampaignStatusPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedCampaignStatus) );
		}
				
		internal static CampaignStatusPersistance AttachSession( IPersistanceSession owner )
		{
			CampaignStatusPersistance persistance = new CampaignStatusPersistance ( owner.Session as ISession, typeof(SpecializedCampaignStatus) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static CampaignStatusPersistance globalSession = null;
        internal static CampaignStatusPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static CampaignStatusPersistance GetSession()
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
		
		internal static CampaignStatusPersistance GetValidatedSession()
        {
            CampaignStatusPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private CampaignStatusPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override CampaignStatus Create()
		{	
			SpecializedCampaignStatus entity = new SpecializedCampaignStatus ();
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
		
 		public IList<CampaignStatus> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaignStatus e where e.Id = '{0}'", id);
		}

		public IList<CampaignStatus> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedCampaignStatus e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<CampaignStatus> SelectByLevel ( int level )
		{
			return SelectByLevel (-1, -1, level );
		}
		
		public long CountByLevel ( int level )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaignStatus e where e.Level = '{0}'", level);
		}

		public IList<CampaignStatus> SelectByLevel ( int start, int count, int level )
		{
			IList list = Query(start, count, "from SpecializedCampaignStatus e where e.Level = {0}", level);
			return ToTypedCollection(list);
		}
		
 		public IList<CampaignStatus> SelectByMoves ( int moves )
		{
			return SelectByMoves (-1, -1, moves );
		}
		
		public long CountByMoves ( int moves )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaignStatus e where e.Moves = '{0}'", moves);
		}

		public IList<CampaignStatus> SelectByMoves ( int start, int count, int moves )
		{
			IList list = Query(start, count, "from SpecializedCampaignStatus e where e.Moves = {0}", moves);
			return ToTypedCollection(list);
		}
		
 		public IList<CampaignStatus> SelectByCompleted ( bool completed )
		{
			return SelectByCompleted (-1, -1, completed );
		}
		
		public long CountByCompleted ( bool completed )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaignStatus e where e.Completed = '{0}'", completed);
		}

		public IList<CampaignStatus> SelectByCompleted ( int start, int count, bool completed )
		{
			IList list = Query(start, count, "from SpecializedCampaignStatus e where e.Completed = {0}", completed);
			return ToTypedCollection(list);
		}
		
 		public IList<CampaignStatus> SelectByCampaign ( Campaign campaign )
		{
			return SelectByCampaign (-1, -1, campaign );
		}
		
		public long CountByCampaign ( Campaign campaign )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaignStatus e where e.Campaign = '{0}'", campaign);
		}

		public IList<CampaignStatus> SelectByCampaign ( int start, int count, Campaign campaign )
		{
			IList list = Query(start, count, "from SpecializedCampaignStatus e where e.CampaignNHibernate.Id = {0}", campaign.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<CampaignStatus> SelectByPrincipal ( Principal principal )
		{
			return SelectByPrincipal (-1, -1, principal );
		}
		
		public long CountByPrincipal ( Principal principal )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaignStatus e where e.Principal = '{0}'", principal);
		}

		public IList<CampaignStatus> SelectByPrincipal ( int start, int count, Principal principal )
		{
			IList list = Query(start, count, "from SpecializedCampaignStatus e where e.PrincipalNHibernate.Id = {0}", principal.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<CampaignStatus> SelectByBattle ( Battle battle )
		{
			return SelectByBattle (-1, -1, battle );
		}
		
		public long CountByBattle ( Battle battle )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaignStatus e where e.Battle = '{0}'", battle);
		}

		public IList<CampaignStatus> SelectByBattle ( int start, int count, Battle battle )
		{
			IList list = Query(start, count, "from SpecializedCampaignStatus e where e.BattleNHibernate.Id = {0}", battle.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<CampaignStatus> SelectByLevelTemplate ( CampaignLevel levelTemplate )
		{
			return SelectByLevelTemplate (-1, -1, levelTemplate );
		}
		
		public long CountByLevelTemplate ( CampaignLevel levelTemplate )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaignStatus e where e.LevelTemplate = '{0}'", levelTemplate);
		}

		public IList<CampaignStatus> SelectByLevelTemplate ( int start, int count, CampaignLevel levelTemplate )
		{
			IList list = Query(start, count, "from SpecializedCampaignStatus e where e.LevelTemplateNHibernate.Id = {0}", levelTemplate.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : CampaignStatus
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
