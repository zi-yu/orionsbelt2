using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class PlayersGroupStoragePersistance : 
			NHibernatePersistance<PlayersGroupStorage>, IPlayersGroupStoragePersistance {
	
		#region Static Access
		
		internal static PlayersGroupStoragePersistance CreateSession()
		{
			return new PlayersGroupStoragePersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedPlayersGroupStorage) );
		}
				
		internal static PlayersGroupStoragePersistance AttachSession( IPersistanceSession owner )
		{
			PlayersGroupStoragePersistance persistance = new PlayersGroupStoragePersistance ( owner.Session as ISession, typeof(SpecializedPlayersGroupStorage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static PlayersGroupStoragePersistance globalSession = null;
        internal static PlayersGroupStoragePersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static PlayersGroupStoragePersistance GetSession()
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
		
		internal static PlayersGroupStoragePersistance GetValidatedSession()
        {
            PlayersGroupStoragePersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private PlayersGroupStoragePersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override PlayersGroupStorage Create()
		{	
			SpecializedPlayersGroupStorage entity = new SpecializedPlayersGroupStorage ();
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
		
 		public IList<PlayersGroupStorage> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayersGroupStorage e where e.Id = '{0}'", id);
		}

		public IList<PlayersGroupStorage> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedPlayersGroupStorage e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayersGroupStorage> SelectByEliminatoryNumber ( int eliminatoryNumber )
		{
			return SelectByEliminatoryNumber (-1, -1, eliminatoryNumber );
		}
		
		public long CountByEliminatoryNumber ( int eliminatoryNumber )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayersGroupStorage e where e.EliminatoryNumber = '{0}'", eliminatoryNumber);
		}

		public IList<PlayersGroupStorage> SelectByEliminatoryNumber ( int start, int count, int eliminatoryNumber )
		{
			IList list = Query(start, count, "from SpecializedPlayersGroupStorage e where e.EliminatoryNumber = {0}", eliminatoryNumber);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayersGroupStorage> SelectByPlayersIds ( string playersIds )
		{
			return SelectByPlayersIds (-1, -1, playersIds );
		}
		
		public long CountByPlayersIds ( string playersIds )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayersGroupStorage e where e.PlayersIds = '{0}'", playersIds);
		}

		public IList<PlayersGroupStorage> SelectByPlayersIds ( int start, int count, string playersIds )
		{
			IList list = Query(start, count, "from SpecializedPlayersGroupStorage e where e.PlayersIds like '{0}'", playersIds);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayersGroupStorage> SelectByGroupNumber ( int groupNumber )
		{
			return SelectByGroupNumber (-1, -1, groupNumber );
		}
		
		public long CountByGroupNumber ( int groupNumber )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayersGroupStorage e where e.GroupNumber = '{0}'", groupNumber);
		}

		public IList<PlayersGroupStorage> SelectByGroupNumber ( int start, int count, int groupNumber )
		{
			IList list = Query(start, count, "from SpecializedPlayersGroupStorage e where e.GroupNumber = {0}", groupNumber);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayersGroupStorage> SelectByTournament ( Tournament tournament )
		{
			return SelectByTournament (-1, -1, tournament );
		}
		
		public long CountByTournament ( Tournament tournament )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayersGroupStorage e where e.Tournament = '{0}'", tournament);
		}

		public IList<PlayersGroupStorage> SelectByTournament ( int start, int count, Tournament tournament )
		{
			IList list = Query(start, count, "from SpecializedPlayersGroupStorage e where e.TournamentNHibernate.Id = {0}", tournament.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : PlayersGroupStorage
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfPlayersIds );
        }
		public static LifecyleVeto ValidateMaxSizeOfPlayersIds ( PlayersGroupStorage e ) 
        {
			return ValidateStringMaxSize( "PlayersGroupStorage", "PlayersIds", e.PlayersIds, 100 );
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
