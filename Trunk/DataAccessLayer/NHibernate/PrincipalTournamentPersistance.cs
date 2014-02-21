using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class PrincipalTournamentPersistance : 
			NHibernatePersistance<PrincipalTournament>, IPrincipalTournamentPersistance {
	
		#region Static Access
		
		internal static PrincipalTournamentPersistance CreateSession()
		{
			return new PrincipalTournamentPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedPrincipalTournament) );
		}
				
		internal static PrincipalTournamentPersistance AttachSession( IPersistanceSession owner )
		{
			PrincipalTournamentPersistance persistance = new PrincipalTournamentPersistance ( owner.Session as ISession, typeof(SpecializedPrincipalTournament) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static PrincipalTournamentPersistance globalSession = null;
        internal static PrincipalTournamentPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static PrincipalTournamentPersistance GetSession()
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
		
		internal static PrincipalTournamentPersistance GetValidatedSession()
        {
            PrincipalTournamentPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private PrincipalTournamentPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override PrincipalTournament Create()
		{	
			SpecializedPrincipalTournament entity = new SpecializedPrincipalTournament ();
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
		
 		public IList<PrincipalTournament> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipalTournament e where e.Id = '{0}'", id);
		}

		public IList<PrincipalTournament> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedPrincipalTournament e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<PrincipalTournament> SelectByHasEliminated ( bool hasEliminated )
		{
			return SelectByHasEliminated (-1, -1, hasEliminated );
		}
		
		public long CountByHasEliminated ( bool hasEliminated )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipalTournament e where e.HasEliminated = '{0}'", hasEliminated);
		}

		public IList<PrincipalTournament> SelectByHasEliminated ( int start, int count, bool hasEliminated )
		{
			IList list = Query(start, count, "from SpecializedPrincipalTournament e where e.HasEliminated = {0}", hasEliminated);
			return ToTypedCollection(list);
		}
		
 		public IList<PrincipalTournament> SelectByEliminatedInFase ( string eliminatedInFase )
		{
			return SelectByEliminatedInFase (-1, -1, eliminatedInFase );
		}
		
		public long CountByEliminatedInFase ( string eliminatedInFase )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipalTournament e where e.EliminatedInFase = '{0}'", eliminatedInFase);
		}

		public IList<PrincipalTournament> SelectByEliminatedInFase ( int start, int count, string eliminatedInFase )
		{
			IList list = Query(start, count, "from SpecializedPrincipalTournament e where e.EliminatedInFase like '{0}'", eliminatedInFase);
			return ToTypedCollection(list);
		}
		
 		public IList<PrincipalTournament> SelectByEliminatedInBattleId ( int eliminatedInBattleId )
		{
			return SelectByEliminatedInBattleId (-1, -1, eliminatedInBattleId );
		}
		
		public long CountByEliminatedInBattleId ( int eliminatedInBattleId )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipalTournament e where e.EliminatedInBattleId = '{0}'", eliminatedInBattleId);
		}

		public IList<PrincipalTournament> SelectByEliminatedInBattleId ( int start, int count, int eliminatedInBattleId )
		{
			IList list = Query(start, count, "from SpecializedPrincipalTournament e where e.EliminatedInBattleId = {0}", eliminatedInBattleId);
			return ToTypedCollection(list);
		}
		
 		public IList<PrincipalTournament> SelectByPrincipal ( Principal principal )
		{
			return SelectByPrincipal (-1, -1, principal );
		}
		
		public long CountByPrincipal ( Principal principal )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipalTournament e where e.Principal = '{0}'", principal);
		}

		public IList<PrincipalTournament> SelectByPrincipal ( int start, int count, Principal principal )
		{
			IList list = Query(start, count, "from SpecializedPrincipalTournament e where e.PrincipalNHibernate.Id = {0}", principal.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<PrincipalTournament> SelectByTournament ( Tournament tournament )
		{
			return SelectByTournament (-1, -1, tournament );
		}
		
		public long CountByTournament ( Tournament tournament )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipalTournament e where e.Tournament = '{0}'", tournament);
		}

		public IList<PrincipalTournament> SelectByTournament ( int start, int count, Tournament tournament )
		{
			IList list = Query(start, count, "from SpecializedPrincipalTournament e where e.TournamentNHibernate.Id = {0}", tournament.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<PrincipalTournament> SelectByTeam ( TeamStorage team )
		{
			return SelectByTeam (-1, -1, team );
		}
		
		public long CountByTeam ( TeamStorage team )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipalTournament e where e.Team = '{0}'", team);
		}

		public IList<PrincipalTournament> SelectByTeam ( int start, int count, TeamStorage team )
		{
			IList list = Query(start, count, "from SpecializedPrincipalTournament e where e.TeamNHibernate.Id = {0}", team.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : PrincipalTournament
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfEliminatedInFase );
        }
		public static LifecyleVeto ValidateMaxSizeOfEliminatedInFase ( PrincipalTournament e ) 
        {
			return ValidateStringMaxSize( "PrincipalTournament", "EliminatedInFase", e.EliminatedInFase, 100 );
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
