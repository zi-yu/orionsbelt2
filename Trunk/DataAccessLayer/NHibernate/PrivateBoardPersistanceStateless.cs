using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class PrivateBoardPersistanceStateless : 
			NHibernatePersistanceStateless<PrivateBoard>, IPrivateBoardPersistance {
	
		#region Static Access
		
		internal static PrivateBoardPersistanceStateless CreateSession()
		{
			return new PrivateBoardPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedPrivateBoard) );
		}
				
		internal static PrivateBoardPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			PrivateBoardPersistanceStateless persistance = new PrivateBoardPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedPrivateBoard) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static PrivateBoardPersistanceStateless globalSession = null;
        internal static PrivateBoardPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static PrivateBoardPersistanceStateless GetSession()
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
		
		internal static PrivateBoardPersistanceStateless GetValidatedSession()
        {
            PrivateBoardPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private PrivateBoardPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override PrivateBoard Create()
		{	
			SpecializedPrivateBoard entity = new SpecializedPrivateBoard ();
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
		
 		public IList<PrivateBoard> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedPrivateBoard e where e.Id = '{0}'", id);
		}

		public IList<PrivateBoard> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedPrivateBoard e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<PrivateBoard> SelectByReceiver ( int receiver )
		{
			return SelectByReceiver (-1, -1, receiver );
		}
		
		public long CountByReceiver ( int receiver )
		{
			return ExecuteScalar("select count(*) from SpecializedPrivateBoard e where e.Receiver = '{0}'", receiver);
		}

		public IList<PrivateBoard> SelectByReceiver ( int start, int count, int receiver )
		{
			IList list = Query(start, count, "from SpecializedPrivateBoard e where e.Receiver = {0}", receiver);
			return ToTypedCollection(list);
		}
		
 		public IList<PrivateBoard> SelectByType ( string type )
		{
			return SelectByType (-1, -1, type );
		}
		
		public long CountByType ( string type )
		{
			return ExecuteScalar("select count(*) from SpecializedPrivateBoard e where e.Type = '{0}'", type);
		}

		public IList<PrivateBoard> SelectByType ( int start, int count, string type )
		{
			IList list = Query(start, count, "from SpecializedPrivateBoard e where e.Type like '{0}'", type);
			return ToTypedCollection(list);
		}
		
 		public IList<PrivateBoard> SelectByMessage ( string message )
		{
			return SelectByMessage (-1, -1, message );
		}
		
		public long CountByMessage ( string message )
		{
			return ExecuteScalar("select count(*) from SpecializedPrivateBoard e where e.Message = '{0}'", message);
		}

		public IList<PrivateBoard> SelectByMessage ( int start, int count, string message )
		{
			IList list = Query(start, count, "from SpecializedPrivateBoard e where e.Message like '{0}'", message);
			return ToTypedCollection(list);
		}
		
 		public IList<PrivateBoard> SelectByWasRead ( bool wasRead )
		{
			return SelectByWasRead (-1, -1, wasRead );
		}
		
		public long CountByWasRead ( bool wasRead )
		{
			return ExecuteScalar("select count(*) from SpecializedPrivateBoard e where e.WasRead = '{0}'", wasRead);
		}

		public IList<PrivateBoard> SelectByWasRead ( int start, int count, bool wasRead )
		{
			IList list = Query(start, count, "from SpecializedPrivateBoard e where e.WasRead = {0}", wasRead);
			return ToTypedCollection(list);
		}
		
 		public IList<PrivateBoard> SelectBySender ( PlayerStorage sender )
		{
			return SelectBySender (-1, -1, sender );
		}
		
		public long CountBySender ( PlayerStorage sender )
		{
			return ExecuteScalar("select count(*) from SpecializedPrivateBoard e where e.Sender = '{0}'", sender);
		}

		public IList<PrivateBoard> SelectBySender ( int start, int count, PlayerStorage sender )
		{
			IList list = Query(start, count, "from SpecializedPrivateBoard e where e.SenderNHibernate.Id = {0}", sender.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : PrivateBoard
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfMessage );
        }
		public static LifecyleVeto ValidateMaxSizeOfType ( PrivateBoard e ) 
        {
			return ValidateStringMaxSize( "PrivateBoard", "Type", e.Type, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfMessage ( PrivateBoard e ) 
        {
			return ValidateStringMaxSize( "PrivateBoard", "Message", e.Message, 8000 );
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
