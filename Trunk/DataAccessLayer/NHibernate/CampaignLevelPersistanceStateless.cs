using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class CampaignLevelPersistanceStateless : 
			NHibernatePersistanceStateless<CampaignLevel>, ICampaignLevelPersistance {
	
		#region Static Access
		
		internal static CampaignLevelPersistanceStateless CreateSession()
		{
			return new CampaignLevelPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedCampaignLevel) );
		}
				
		internal static CampaignLevelPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			CampaignLevelPersistanceStateless persistance = new CampaignLevelPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedCampaignLevel) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static CampaignLevelPersistanceStateless globalSession = null;
        internal static CampaignLevelPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static CampaignLevelPersistanceStateless GetSession()
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
		
		internal static CampaignLevelPersistanceStateless GetValidatedSession()
        {
            CampaignLevelPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private CampaignLevelPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override CampaignLevel Create()
		{	
			SpecializedCampaignLevel entity = new SpecializedCampaignLevel ();
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
		
 		public IList<CampaignLevel> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaignLevel e where e.Id = '{0}'", id);
		}

		public IList<CampaignLevel> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedCampaignLevel e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<CampaignLevel> SelectByBotFleet ( string botFleet )
		{
			return SelectByBotFleet (-1, -1, botFleet );
		}
		
		public long CountByBotFleet ( string botFleet )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaignLevel e where e.BotFleet = '{0}'", botFleet);
		}

		public IList<CampaignLevel> SelectByBotFleet ( int start, int count, string botFleet )
		{
			IList list = Query(start, count, "from SpecializedCampaignLevel e where e.BotFleet like '{0}'", botFleet);
			return ToTypedCollection(list);
		}
		
 		public IList<CampaignLevel> SelectByPlayerFleet ( string playerFleet )
		{
			return SelectByPlayerFleet (-1, -1, playerFleet );
		}
		
		public long CountByPlayerFleet ( string playerFleet )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaignLevel e where e.PlayerFleet = '{0}'", playerFleet);
		}

		public IList<CampaignLevel> SelectByPlayerFleet ( int start, int count, string playerFleet )
		{
			IList list = Query(start, count, "from SpecializedCampaignLevel e where e.PlayerFleet like '{0}'", playerFleet);
			return ToTypedCollection(list);
		}
		
 		public IList<CampaignLevel> SelectByLevel ( int level )
		{
			return SelectByLevel (-1, -1, level );
		}
		
		public long CountByLevel ( int level )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaignLevel e where e.Level = '{0}'", level);
		}

		public IList<CampaignLevel> SelectByLevel ( int start, int count, int level )
		{
			IList list = Query(start, count, "from SpecializedCampaignLevel e where e.Level = {0}", level);
			return ToTypedCollection(list);
		}
		
 		public IList<CampaignLevel> SelectByBotName ( string botName )
		{
			return SelectByBotName (-1, -1, botName );
		}
		
		public long CountByBotName ( string botName )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaignLevel e where e.BotName = '{0}'", botName);
		}

		public IList<CampaignLevel> SelectByBotName ( int start, int count, string botName )
		{
			IList list = Query(start, count, "from SpecializedCampaignLevel e where e.BotName like '{0}'", botName);
			return ToTypedCollection(list);
		}
		
 		public IList<CampaignLevel> SelectByCampaign ( Campaign campaign )
		{
			return SelectByCampaign (-1, -1, campaign );
		}
		
		public long CountByCampaign ( Campaign campaign )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaignLevel e where e.Campaign = '{0}'", campaign);
		}

		public IList<CampaignLevel> SelectByCampaign ( int start, int count, Campaign campaign )
		{
			IList list = Query(start, count, "from SpecializedCampaignLevel e where e.CampaignNHibernate.Id = {0}", campaign.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : CampaignLevel
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfBotFleet );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfPlayerFleet );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfBotName );
        }
		public static LifecyleVeto ValidateMaxSizeOfBotFleet ( CampaignLevel e ) 
        {
			return ValidateStringMaxSize( "CampaignLevel", "BotFleet", e.BotFleet, 1000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfPlayerFleet ( CampaignLevel e ) 
        {
			return ValidateStringMaxSize( "CampaignLevel", "PlayerFleet", e.PlayerFleet, 1000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfBotName ( CampaignLevel e ) 
        {
			return ValidateStringMaxSize( "CampaignLevel", "BotName", e.BotName, 100 );
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
