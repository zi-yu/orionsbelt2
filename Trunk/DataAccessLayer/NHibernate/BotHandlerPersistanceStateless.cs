using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class BotHandlerPersistanceStateless : 
			NHibernatePersistanceStateless<BotHandler>, IBotHandlerPersistance {
	
		#region Static Access
		
		internal static BotHandlerPersistanceStateless CreateSession()
		{
			return new BotHandlerPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedBotHandler) );
		}
				
		internal static BotHandlerPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			BotHandlerPersistanceStateless persistance = new BotHandlerPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedBotHandler) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static BotHandlerPersistanceStateless globalSession = null;
        internal static BotHandlerPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static BotHandlerPersistanceStateless GetSession()
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
		
		internal static BotHandlerPersistanceStateless GetValidatedSession()
        {
            BotHandlerPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private BotHandlerPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override BotHandler Create()
		{	
			SpecializedBotHandler entity = new SpecializedBotHandler ();
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
		
 		public IList<BotHandler> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedBotHandler e where e.Id = '{0}'", id);
		}

		public IList<BotHandler> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedBotHandler e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<BotHandler> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedBotHandler e where e.Name = '{0}'", name);
		}

		public IList<BotHandler> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedBotHandler e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<BotHandler> SelectByCode ( int code )
		{
			return SelectByCode (-1, -1, code );
		}
		
		public long CountByCode ( int code )
		{
			return ExecuteScalar("select count(*) from SpecializedBotHandler e where e.Code = '{0}'", code);
		}

		public IList<BotHandler> SelectByCode ( int start, int count, int code )
		{
			IList list = Query(start, count, "from SpecializedBotHandler e where e.Code = {0}", code);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : BotHandler
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( BotHandler e ) 
        {
			return ValidateStringMaxSize( "BotHandler", "Name", e.Name, 100 );
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
