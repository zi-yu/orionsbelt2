﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class PlayerStatsPersistance : 
			NHibernatePersistance<PlayerStats>, IPlayerStatsPersistance {
	
		#region Static Access
		
		internal static PlayerStatsPersistance CreateSession()
		{
			return new PlayerStatsPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedPlayerStats) );
		}
				
		internal static PlayerStatsPersistance AttachSession( IPersistanceSession owner )
		{
			PlayerStatsPersistance persistance = new PlayerStatsPersistance ( owner.Session as ISession, typeof(SpecializedPlayerStats) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static PlayerStatsPersistance globalSession = null;
        internal static PlayerStatsPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static PlayerStatsPersistance GetSession()
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
		
		internal static PlayerStatsPersistance GetValidatedSession()
        {
            PlayerStatsPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private PlayerStatsPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override PlayerStats Create()
		{	
			SpecializedPlayerStats entity = new SpecializedPlayerStats ();
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
		
 		public IList<PlayerStats> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStats e where e.Id = '{0}'", id);
		}

		public IList<PlayerStats> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedPlayerStats e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStats> SelectByNumberOfPlayedBattles ( int numberOfPlayedBattles )
		{
			return SelectByNumberOfPlayedBattles (-1, -1, numberOfPlayedBattles );
		}
		
		public long CountByNumberOfPlayedBattles ( int numberOfPlayedBattles )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStats e where e.NumberOfPlayedBattles = '{0}'", numberOfPlayedBattles);
		}

		public IList<PlayerStats> SelectByNumberOfPlayedBattles ( int start, int count, int numberOfPlayedBattles )
		{
			IList list = Query(start, count, "from SpecializedPlayerStats e where e.NumberOfPlayedBattles = {0}", numberOfPlayedBattles);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStats> SelectByNumberPirateQuest ( int numberPirateQuest )
		{
			return SelectByNumberPirateQuest (-1, -1, numberPirateQuest );
		}
		
		public long CountByNumberPirateQuest ( int numberPirateQuest )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStats e where e.NumberPirateQuest = '{0}'", numberPirateQuest);
		}

		public IList<PlayerStats> SelectByNumberPirateQuest ( int start, int count, int numberPirateQuest )
		{
			IList list = Query(start, count, "from SpecializedPlayerStats e where e.NumberPirateQuest = {0}", numberPirateQuest);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStats> SelectByNumberBountyQuests ( int numberBountyQuests )
		{
			return SelectByNumberBountyQuests (-1, -1, numberBountyQuests );
		}
		
		public long CountByNumberBountyQuests ( int numberBountyQuests )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStats e where e.NumberBountyQuests = '{0}'", numberBountyQuests);
		}

		public IList<PlayerStats> SelectByNumberBountyQuests ( int start, int count, int numberBountyQuests )
		{
			IList list = Query(start, count, "from SpecializedPlayerStats e where e.NumberBountyQuests = {0}", numberBountyQuests);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStats> SelectByNumberMerchantQuests ( int numberMerchantQuests )
		{
			return SelectByNumberMerchantQuests (-1, -1, numberMerchantQuests );
		}
		
		public long CountByNumberMerchantQuests ( int numberMerchantQuests )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStats e where e.NumberMerchantQuests = '{0}'", numberMerchantQuests);
		}

		public IList<PlayerStats> SelectByNumberMerchantQuests ( int start, int count, int numberMerchantQuests )
		{
			IList list = Query(start, count, "from SpecializedPlayerStats e where e.NumberMerchantQuests = {0}", numberMerchantQuests);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStats> SelectByNumberGladiatorQuests ( int numberGladiatorQuests )
		{
			return SelectByNumberGladiatorQuests (-1, -1, numberGladiatorQuests );
		}
		
		public long CountByNumberGladiatorQuests ( int numberGladiatorQuests )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStats e where e.NumberGladiatorQuests = '{0}'", numberGladiatorQuests);
		}

		public IList<PlayerStats> SelectByNumberGladiatorQuests ( int start, int count, int numberGladiatorQuests )
		{
			IList list = Query(start, count, "from SpecializedPlayerStats e where e.NumberGladiatorQuests = {0}", numberGladiatorQuests);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStats> SelectByNumberColonizerQuests ( int numberColonizerQuests )
		{
			return SelectByNumberColonizerQuests (-1, -1, numberColonizerQuests );
		}
		
		public long CountByNumberColonizerQuests ( int numberColonizerQuests )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStats e where e.NumberColonizerQuests = '{0}'", numberColonizerQuests);
		}

		public IList<PlayerStats> SelectByNumberColonizerQuests ( int start, int count, int numberColonizerQuests )
		{
			IList list = Query(start, count, "from SpecializedPlayerStats e where e.NumberColonizerQuests = {0}", numberColonizerQuests);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : PlayerStats
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
