using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class BotHandlerPersistance : 
			NHibernatePersistance<BotHandler>, IBotHandlerPersistance {
	
		#region Static Access
		
		internal static BotHandlerPersistance CreateSession()
		{
			return new BotHandlerPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedBotHandler) );
		}
				
		internal static BotHandlerPersistance AttachSession( IPersistanceSession owner )
		{
			BotHandlerPersistance persistance = new BotHandlerPersistance ( owner.Session as ISession, typeof(SpecializedBotHandler) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static BotHandlerPersistance globalSession = null;
        internal static BotHandlerPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static BotHandlerPersistance GetSession()
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
		
		internal static BotHandlerPersistance GetValidatedSession()
        {
            BotHandlerPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private BotHandlerPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override BotHandler Create()
		{	
			SpecializedBotHandler entity = new SpecializedBotHandler ();
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
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : BotHandler
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
