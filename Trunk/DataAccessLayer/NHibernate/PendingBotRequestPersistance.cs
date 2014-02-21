using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class PendingBotRequestPersistance : 
			NHibernatePersistance<PendingBotRequest>, IPendingBotRequestPersistance {
	
		#region Static Access
		
		internal static PendingBotRequestPersistance CreateSession()
		{
			return new PendingBotRequestPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedPendingBotRequest) );
		}
				
		internal static PendingBotRequestPersistance AttachSession( IPersistanceSession owner )
		{
			PendingBotRequestPersistance persistance = new PendingBotRequestPersistance ( owner.Session as ISession, typeof(SpecializedPendingBotRequest) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static PendingBotRequestPersistance globalSession = null;
        internal static PendingBotRequestPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static PendingBotRequestPersistance GetSession()
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
		
		internal static PendingBotRequestPersistance GetValidatedSession()
        {
            PendingBotRequestPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private PendingBotRequestPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override PendingBotRequest Create()
		{	
			SpecializedPendingBotRequest entity = new SpecializedPendingBotRequest ();
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
		
 		public IList<PendingBotRequest> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedPendingBotRequest e where e.Id = '{0}'", id);
		}

		public IList<PendingBotRequest> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedPendingBotRequest e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<PendingBotRequest> SelectByBotName ( string botName )
		{
			return SelectByBotName (-1, -1, botName );
		}
		
		public long CountByBotName ( string botName )
		{
			return ExecuteScalar("select count(*) from SpecializedPendingBotRequest e where e.BotName = '{0}'", botName);
		}

		public IList<PendingBotRequest> SelectByBotName ( int start, int count, string botName )
		{
			IList list = Query(start, count, "from SpecializedPendingBotRequest e where e.BotName like '{0}'", botName);
			return ToTypedCollection(list);
		}
		
 		public IList<PendingBotRequest> SelectByXml ( string xml )
		{
			return SelectByXml (-1, -1, xml );
		}
		
		public long CountByXml ( string xml )
		{
			return ExecuteScalar("select count(*) from SpecializedPendingBotRequest e where e.Xml = '{0}'", xml);
		}

		public IList<PendingBotRequest> SelectByXml ( int start, int count, string xml )
		{
			IList list = Query(start, count, "from SpecializedPendingBotRequest e where e.Xml like '{0}'", xml);
			return ToTypedCollection(list);
		}
		
 		public IList<PendingBotRequest> SelectByBattleId ( int battleId )
		{
			return SelectByBattleId (-1, -1, battleId );
		}
		
		public long CountByBattleId ( int battleId )
		{
			return ExecuteScalar("select count(*) from SpecializedPendingBotRequest e where e.BattleId = '{0}'", battleId);
		}

		public IList<PendingBotRequest> SelectByBattleId ( int start, int count, int battleId )
		{
			IList list = Query(start, count, "from SpecializedPendingBotRequest e where e.BattleId = {0}", battleId);
			return ToTypedCollection(list);
		}
		
 		public IList<PendingBotRequest> SelectByBotId ( int botId )
		{
			return SelectByBotId (-1, -1, botId );
		}
		
		public long CountByBotId ( int botId )
		{
			return ExecuteScalar("select count(*) from SpecializedPendingBotRequest e where e.BotId = '{0}'", botId);
		}

		public IList<PendingBotRequest> SelectByBotId ( int start, int count, int botId )
		{
			IList list = Query(start, count, "from SpecializedPendingBotRequest e where e.BotId = {0}", botId);
			return ToTypedCollection(list);
		}
		
 		public IList<PendingBotRequest> SelectByCode ( int code )
		{
			return SelectByCode (-1, -1, code );
		}
		
		public long CountByCode ( int code )
		{
			return ExecuteScalar("select count(*) from SpecializedPendingBotRequest e where e.Code = '{0}'", code);
		}

		public IList<PendingBotRequest> SelectByCode ( int start, int count, int code )
		{
			IList list = Query(start, count, "from SpecializedPendingBotRequest e where e.Code = {0}", code);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : PendingBotRequest
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfBotName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfXml );
        }
		public static LifecyleVeto ValidateMaxSizeOfBotName ( PendingBotRequest e ) 
        {
			return ValidateStringMaxSize( "PendingBotRequest", "BotName", e.BotName, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfXml ( PendingBotRequest e ) 
        {
			return ValidateStringMaxSize( "PendingBotRequest", "Xml", e.Xml, 8000 );
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
