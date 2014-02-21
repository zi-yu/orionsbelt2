using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class BotCredentialPersistance : 
			NHibernatePersistance<BotCredential>, IBotCredentialPersistance {
	
		#region Static Access
		
		internal static BotCredentialPersistance CreateSession()
		{
			return new BotCredentialPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedBotCredential) );
		}
				
		internal static BotCredentialPersistance AttachSession( IPersistanceSession owner )
		{
			BotCredentialPersistance persistance = new BotCredentialPersistance ( owner.Session as ISession, typeof(SpecializedBotCredential) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static BotCredentialPersistance globalSession = null;
        internal static BotCredentialPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static BotCredentialPersistance GetSession()
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
		
		internal static BotCredentialPersistance GetValidatedSession()
        {
            BotCredentialPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private BotCredentialPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override BotCredential Create()
		{	
			SpecializedBotCredential entity = new SpecializedBotCredential ();
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
		
 		public IList<BotCredential> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedBotCredential e where e.Id = '{0}'", id);
		}

		public IList<BotCredential> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedBotCredential e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<BotCredential> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedBotCredential e where e.Name = '{0}'", name);
		}

		public IList<BotCredential> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedBotCredential e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<BotCredential> SelectByServer ( string server )
		{
			return SelectByServer (-1, -1, server );
		}
		
		public long CountByServer ( string server )
		{
			return ExecuteScalar("select count(*) from SpecializedBotCredential e where e.Server = '{0}'", server);
		}

		public IList<BotCredential> SelectByServer ( int start, int count, string server )
		{
			IList list = Query(start, count, "from SpecializedBotCredential e where e.Server like '{0}'", server);
			return ToTypedCollection(list);
		}
		
 		public IList<BotCredential> SelectByVerificationCode ( string verificationCode )
		{
			return SelectByVerificationCode (-1, -1, verificationCode );
		}
		
		public long CountByVerificationCode ( string verificationCode )
		{
			return ExecuteScalar("select count(*) from SpecializedBotCredential e where e.VerificationCode = '{0}'", verificationCode);
		}

		public IList<BotCredential> SelectByVerificationCode ( int start, int count, string verificationCode )
		{
			IList list = Query(start, count, "from SpecializedBotCredential e where e.VerificationCode like '{0}'", verificationCode);
			return ToTypedCollection(list);
		}
		
 		public IList<BotCredential> SelectByBotId ( int botId )
		{
			return SelectByBotId (-1, -1, botId );
		}
		
		public long CountByBotId ( int botId )
		{
			return ExecuteScalar("select count(*) from SpecializedBotCredential e where e.BotId = '{0}'", botId);
		}

		public IList<BotCredential> SelectByBotId ( int start, int count, int botId )
		{
			IList list = Query(start, count, "from SpecializedBotCredential e where e.BotId = {0}", botId);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : BotCredential
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfServer );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfVerificationCode );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( BotCredential e ) 
        {
			return ValidateStringMaxSize( "BotCredential", "Name", e.Name, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfServer ( BotCredential e ) 
        {
			return ValidateStringMaxSize( "BotCredential", "Server", e.Server, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfVerificationCode ( BotCredential e ) 
        {
			return ValidateStringMaxSize( "BotCredential", "VerificationCode", e.VerificationCode, 100 );
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
