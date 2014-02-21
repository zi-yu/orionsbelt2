using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class PlayerStoragePersistance : 
			NHibernatePersistance<PlayerStorage>, IPlayerStoragePersistance {
	
		#region Static Access
		
		internal static PlayerStoragePersistance CreateSession()
		{
			return new PlayerStoragePersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedPlayerStorage) );
		}
				
		internal static PlayerStoragePersistance AttachSession( IPersistanceSession owner )
		{
			PlayerStoragePersistance persistance = new PlayerStoragePersistance ( owner.Session as ISession, typeof(SpecializedPlayerStorage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static PlayerStoragePersistance globalSession = null;
        internal static PlayerStoragePersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static PlayerStoragePersistance GetSession()
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
		
		internal static PlayerStoragePersistance GetValidatedSession()
        {
            PlayerStoragePersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private PlayerStoragePersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override PlayerStorage Create()
		{	
			SpecializedPlayerStorage entity = new SpecializedPlayerStorage ();
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
		
 		public IList<PlayerStorage> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.Id = '{0}'", id);
		}

		public IList<PlayerStorage> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.Name = '{0}'", name);
		}

		public IList<PlayerStorage> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByLastProcessedTick ( int lastProcessedTick )
		{
			return SelectByLastProcessedTick (-1, -1, lastProcessedTick );
		}
		
		public long CountByLastProcessedTick ( int lastProcessedTick )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.LastProcessedTick = '{0}'", lastProcessedTick);
		}

		public IList<PlayerStorage> SelectByLastProcessedTick ( int start, int count, int lastProcessedTick )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.LastProcessedTick = {0}", lastProcessedTick);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByIntrinsicLimits ( string intrinsicLimits )
		{
			return SelectByIntrinsicLimits (-1, -1, intrinsicLimits );
		}
		
		public long CountByIntrinsicLimits ( string intrinsicLimits )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.IntrinsicLimits = '{0}'", intrinsicLimits);
		}

		public IList<PlayerStorage> SelectByIntrinsicLimits ( int start, int count, string intrinsicLimits )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.IntrinsicLimits like '{0}'", intrinsicLimits);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByScore ( int score )
		{
			return SelectByScore (-1, -1, score );
		}
		
		public long CountByScore ( int score )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.Score = '{0}'", score);
		}

		public IList<PlayerStorage> SelectByScore ( int start, int count, int score )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.Score = {0}", score);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByAllianceRank ( string allianceRank )
		{
			return SelectByAllianceRank (-1, -1, allianceRank );
		}
		
		public long CountByAllianceRank ( string allianceRank )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.AllianceRank = '{0}'", allianceRank);
		}

		public IList<PlayerStorage> SelectByAllianceRank ( int start, int count, string allianceRank )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.AllianceRank like '{0}'", allianceRank);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByRace ( string race )
		{
			return SelectByRace (-1, -1, race );
		}
		
		public long CountByRace ( string race )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.Race = '{0}'", race);
		}

		public IList<PlayerStorage> SelectByRace ( int start, int count, string race )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.Race like '{0}'", race);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByHomePlanetId ( int homePlanetId )
		{
			return SelectByHomePlanetId (-1, -1, homePlanetId );
		}
		
		public long CountByHomePlanetId ( int homePlanetId )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.HomePlanetId = '{0}'", homePlanetId);
		}

		public IList<PlayerStorage> SelectByHomePlanetId ( int start, int count, int homePlanetId )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.HomePlanetId = {0}", homePlanetId);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByPirateRanking ( int pirateRanking )
		{
			return SelectByPirateRanking (-1, -1, pirateRanking );
		}
		
		public long CountByPirateRanking ( int pirateRanking )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.PirateRanking = '{0}'", pirateRanking);
		}

		public IList<PlayerStorage> SelectByPirateRanking ( int start, int count, int pirateRanking )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.PirateRanking = {0}", pirateRanking);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByBountyRanking ( int bountyRanking )
		{
			return SelectByBountyRanking (-1, -1, bountyRanking );
		}
		
		public long CountByBountyRanking ( int bountyRanking )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.BountyRanking = '{0}'", bountyRanking);
		}

		public IList<PlayerStorage> SelectByBountyRanking ( int start, int count, int bountyRanking )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.BountyRanking = {0}", bountyRanking);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByMerchantRanking ( int merchantRanking )
		{
			return SelectByMerchantRanking (-1, -1, merchantRanking );
		}
		
		public long CountByMerchantRanking ( int merchantRanking )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.MerchantRanking = '{0}'", merchantRanking);
		}

		public IList<PlayerStorage> SelectByMerchantRanking ( int start, int count, int merchantRanking )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.MerchantRanking = {0}", merchantRanking);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByGladiatorRanking ( int gladiatorRanking )
		{
			return SelectByGladiatorRanking (-1, -1, gladiatorRanking );
		}
		
		public long CountByGladiatorRanking ( int gladiatorRanking )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.GladiatorRanking = '{0}'", gladiatorRanking);
		}

		public IList<PlayerStorage> SelectByGladiatorRanking ( int start, int count, int gladiatorRanking )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.GladiatorRanking = {0}", gladiatorRanking);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByColonizerRanking ( int colonizerRanking )
		{
			return SelectByColonizerRanking (-1, -1, colonizerRanking );
		}
		
		public long CountByColonizerRanking ( int colonizerRanking )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.ColonizerRanking = '{0}'", colonizerRanking);
		}

		public IList<PlayerStorage> SelectByColonizerRanking ( int start, int count, int colonizerRanking )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.ColonizerRanking = {0}", colonizerRanking);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByIntrinsicQuantities ( string intrinsicQuantities )
		{
			return SelectByIntrinsicQuantities (-1, -1, intrinsicQuantities );
		}
		
		public long CountByIntrinsicQuantities ( string intrinsicQuantities )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.IntrinsicQuantities = '{0}'", intrinsicQuantities);
		}

		public IList<PlayerStorage> SelectByIntrinsicQuantities ( int start, int count, string intrinsicQuantities )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.IntrinsicQuantities like '{0}'", intrinsicQuantities);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByPlanetLevel ( int planetLevel )
		{
			return SelectByPlanetLevel (-1, -1, planetLevel );
		}
		
		public long CountByPlanetLevel ( int planetLevel )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.PlanetLevel = '{0}'", planetLevel);
		}

		public IList<PlayerStorage> SelectByPlanetLevel ( int start, int count, int planetLevel )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.PlanetLevel = {0}", planetLevel);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByQuestContextLevel ( string questContextLevel )
		{
			return SelectByQuestContextLevel (-1, -1, questContextLevel );
		}
		
		public long CountByQuestContextLevel ( string questContextLevel )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.QuestContextLevel = '{0}'", questContextLevel);
		}

		public IList<PlayerStorage> SelectByQuestContextLevel ( int start, int count, string questContextLevel )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.QuestContextLevel like '{0}'", questContextLevel);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByActive ( bool active )
		{
			return SelectByActive (-1, -1, active );
		}
		
		public long CountByActive ( bool active )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.Active = '{0}'", active);
		}

		public IList<PlayerStorage> SelectByActive ( int start, int count, bool active )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.Active = {0}", active);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByAvatar ( string avatar )
		{
			return SelectByAvatar (-1, -1, avatar );
		}
		
		public long CountByAvatar ( string avatar )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.Avatar = '{0}'", avatar);
		}

		public IList<PlayerStorage> SelectByAvatar ( int start, int count, string avatar )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.Avatar like '{0}'", avatar);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByUltimateWeaponLevel ( int ultimateWeaponLevel )
		{
			return SelectByUltimateWeaponLevel (-1, -1, ultimateWeaponLevel );
		}
		
		public long CountByUltimateWeaponLevel ( int ultimateWeaponLevel )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.UltimateWeaponLevel = '{0}'", ultimateWeaponLevel);
		}

		public IList<PlayerStorage> SelectByUltimateWeaponLevel ( int start, int count, int ultimateWeaponLevel )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.UltimateWeaponLevel = {0}", ultimateWeaponLevel);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByServices ( string services )
		{
			return SelectByServices (-1, -1, services );
		}
		
		public long CountByServices ( string services )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.Services = '{0}'", services);
		}

		public IList<PlayerStorage> SelectByServices ( int start, int count, string services )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.Services like '{0}'", services);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByUltimateWeaponCooldown ( int ultimateWeaponCooldown )
		{
			return SelectByUltimateWeaponCooldown (-1, -1, ultimateWeaponCooldown );
		}
		
		public long CountByUltimateWeaponCooldown ( int ultimateWeaponCooldown )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.UltimateWeaponCooldown = '{0}'", ultimateWeaponCooldown);
		}

		public IList<PlayerStorage> SelectByUltimateWeaponCooldown ( int start, int count, int ultimateWeaponCooldown )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.UltimateWeaponCooldown = {0}", ultimateWeaponCooldown);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByActivatedInTick ( int activatedInTick )
		{
			return SelectByActivatedInTick (-1, -1, activatedInTick );
		}
		
		public long CountByActivatedInTick ( int activatedInTick )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.ActivatedInTick = '{0}'", activatedInTick);
		}

		public IList<PlayerStorage> SelectByActivatedInTick ( int start, int count, int activatedInTick )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.ActivatedInTick = {0}", activatedInTick);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByIsGeneralActive ( bool isGeneralActive )
		{
			return SelectByIsGeneralActive (-1, -1, isGeneralActive );
		}
		
		public long CountByIsGeneralActive ( bool isGeneralActive )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.IsGeneralActive = '{0}'", isGeneralActive);
		}

		public IList<PlayerStorage> SelectByIsGeneralActive ( int start, int count, bool isGeneralActive )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.IsGeneralActive = {0}", isGeneralActive);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByGeneralId ( int generalId )
		{
			return SelectByGeneralId (-1, -1, generalId );
		}
		
		public long CountByGeneralId ( int generalId )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.GeneralId = '{0}'", generalId);
		}

		public IList<PlayerStorage> SelectByGeneralId ( int start, int count, int generalId )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.GeneralId = {0}", generalId);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByGeneralName ( string generalName )
		{
			return SelectByGeneralName (-1, -1, generalName );
		}
		
		public long CountByGeneralName ( string generalName )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.GeneralName = '{0}'", generalName);
		}

		public IList<PlayerStorage> SelectByGeneralName ( int start, int count, string generalName )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.GeneralName like '{0}'", generalName);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByGeneralFriendlyName ( string generalFriendlyName )
		{
			return SelectByGeneralFriendlyName (-1, -1, generalFriendlyName );
		}
		
		public long CountByGeneralFriendlyName ( string generalFriendlyName )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.GeneralFriendlyName = '{0}'", generalFriendlyName);
		}

		public IList<PlayerStorage> SelectByGeneralFriendlyName ( int start, int count, string generalFriendlyName )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.GeneralFriendlyName like '{0}'", generalFriendlyName);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByIsPrimary ( bool isPrimary )
		{
			return SelectByIsPrimary (-1, -1, isPrimary );
		}
		
		public long CountByIsPrimary ( bool isPrimary )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.IsPrimary = '{0}'", isPrimary);
		}

		public IList<PlayerStorage> SelectByIsPrimary ( int start, int count, bool isPrimary )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.IsPrimary = {0}", isPrimary);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByIsOnVacations ( bool isOnVacations )
		{
			return SelectByIsOnVacations (-1, -1, isOnVacations );
		}
		
		public long CountByIsOnVacations ( bool isOnVacations )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.IsOnVacations = '{0}'", isOnVacations);
		}

		public IList<PlayerStorage> SelectByIsOnVacations ( int start, int count, bool isOnVacations )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.IsOnVacations = {0}", isOnVacations);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByTotalPosts ( int totalPosts )
		{
			return SelectByTotalPosts (-1, -1, totalPosts );
		}
		
		public long CountByTotalPosts ( int totalPosts )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.TotalPosts = '{0}'", totalPosts);
		}

		public IList<PlayerStorage> SelectByTotalPosts ( int start, int count, int totalPosts )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.TotalPosts = {0}", totalPosts);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectBySignature ( string signature )
		{
			return SelectBySignature (-1, -1, signature );
		}
		
		public long CountBySignature ( string signature )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.Signature = '{0}'", signature);
		}

		public IList<PlayerStorage> SelectBySignature ( int start, int count, string signature )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.Signature like '{0}'", signature);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByForumRole ( string forumRole )
		{
			return SelectByForumRole (-1, -1, forumRole );
		}
		
		public long CountByForumRole ( string forumRole )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.ForumRole = '{0}'", forumRole);
		}

		public IList<PlayerStorage> SelectByForumRole ( int start, int count, string forumRole )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.ForumRole like '{0}'", forumRole);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByPrincipal ( Principal principal )
		{
			return SelectByPrincipal (-1, -1, principal );
		}
		
		public long CountByPrincipal ( Principal principal )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.Principal = '{0}'", principal);
		}

		public IList<PlayerStorage> SelectByPrincipal ( int start, int count, Principal principal )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.PrincipalNHibernate.Id = {0}", principal.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByAlliance ( AllianceStorage alliance )
		{
			return SelectByAlliance (-1, -1, alliance );
		}
		
		public long CountByAlliance ( AllianceStorage alliance )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.Alliance = '{0}'", alliance);
		}

		public IList<PlayerStorage> SelectByAlliance ( int start, int count, AllianceStorage alliance )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.AllianceNHibernate.Id = {0}", alliance.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<PlayerStorage> SelectByStats ( PlayerStats stats )
		{
			return SelectByStats (-1, -1, stats );
		}
		
		public long CountByStats ( PlayerStats stats )
		{
			return ExecuteScalar("select count(*) from SpecializedPlayerStorage e where e.Stats = '{0}'", stats);
		}

		public IList<PlayerStorage> SelectByStats ( int start, int count, PlayerStats stats )
		{
			IList list = Query(start, count, "from SpecializedPlayerStorage e where e.StatsNHibernate.Id = {0}", stats.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : PlayerStorage
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfIntrinsicLimits );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfAllianceRank );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfRace );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfIntrinsicQuantities );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfQuestContextLevel );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfAvatar );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfServices );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfGeneralName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfGeneralFriendlyName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfSignature );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfForumRole );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( PlayerStorage e ) 
        {
			return ValidateStringMaxSize( "PlayerStorage", "Name", e.Name, 200 );
		}
		public static LifecyleVeto ValidateMaxSizeOfIntrinsicLimits ( PlayerStorage e ) 
        {
			return ValidateStringMaxSize( "PlayerStorage", "IntrinsicLimits", e.IntrinsicLimits, 2048 );
		}
		public static LifecyleVeto ValidateMaxSizeOfAllianceRank ( PlayerStorage e ) 
        {
			return ValidateStringMaxSize( "PlayerStorage", "AllianceRank", e.AllianceRank, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfRace ( PlayerStorage e ) 
        {
			return ValidateStringMaxSize( "PlayerStorage", "Race", e.Race, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfIntrinsicQuantities ( PlayerStorage e ) 
        {
			return ValidateStringMaxSize( "PlayerStorage", "IntrinsicQuantities", e.IntrinsicQuantities, 2048 );
		}
		public static LifecyleVeto ValidateMaxSizeOfQuestContextLevel ( PlayerStorage e ) 
        {
			return ValidateStringMaxSize( "PlayerStorage", "QuestContextLevel", e.QuestContextLevel, 2000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfAvatar ( PlayerStorage e ) 
        {
			return ValidateStringMaxSize( "PlayerStorage", "Avatar", e.Avatar, 1000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfServices ( PlayerStorage e ) 
        {
			return ValidateStringMaxSize( "PlayerStorage", "Services", e.Services, 2000 );
		}
		public static LifecyleVeto ValidateMaxSizeOfGeneralName ( PlayerStorage e ) 
        {
			return ValidateStringMaxSize( "PlayerStorage", "GeneralName", e.GeneralName, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfGeneralFriendlyName ( PlayerStorage e ) 
        {
			return ValidateStringMaxSize( "PlayerStorage", "GeneralFriendlyName", e.GeneralFriendlyName, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfSignature ( PlayerStorage e ) 
        {
			return ValidateStringMaxSize( "PlayerStorage", "Signature", e.Signature, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfForumRole ( PlayerStorage e ) 
        {
			return ValidateStringMaxSize( "PlayerStorage", "ForumRole", e.ForumRole, 100 );
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
