using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	/// <summary>
    /// Memory persistance for entity.Name
    /// </summary>
	internal class MemoryPlayerStoragePersistance : 
			MemoryPersistance<PlayerStorage>, IPlayerStoragePersistance {
		
		#region IPersistance
		
		public override PlayerStorage Create()
		{
			return new SpecializedMemoryPlayerStorage ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<PlayerStorage> SelectById ( int id )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountById ( int id )
		{
			return (long) SelectById ( id ).Count;
		}

		public IList<PlayerStorage> SelectById ( int start, int count, int id )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByName ( string name )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByName ( string name )
		{
			return (long) SelectByName ( name ).Count;
		}

		public IList<PlayerStorage> SelectByName ( int start, int count, string name )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByLastProcessedTick ( int lastProcessedTick )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.LastProcessedTick == lastProcessedTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLastProcessedTick ( int lastProcessedTick )
		{
			return (long) SelectByLastProcessedTick ( lastProcessedTick ).Count;
		}

		public IList<PlayerStorage> SelectByLastProcessedTick ( int start, int count, int lastProcessedTick )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.LastProcessedTick == lastProcessedTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByIntrinsicLimits ( string intrinsicLimits )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.IntrinsicLimits == intrinsicLimits ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIntrinsicLimits ( string intrinsicLimits )
		{
			return (long) SelectByIntrinsicLimits ( intrinsicLimits ).Count;
		}

		public IList<PlayerStorage> SelectByIntrinsicLimits ( int start, int count, string intrinsicLimits )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.IntrinsicLimits == intrinsicLimits ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByScore ( int score )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Score == score ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByScore ( int score )
		{
			return (long) SelectByScore ( score ).Count;
		}

		public IList<PlayerStorage> SelectByScore ( int start, int count, int score )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Score == score ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByAllianceRank ( string allianceRank )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.AllianceRank == allianceRank ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAllianceRank ( string allianceRank )
		{
			return (long) SelectByAllianceRank ( allianceRank ).Count;
		}

		public IList<PlayerStorage> SelectByAllianceRank ( int start, int count, string allianceRank )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.AllianceRank == allianceRank ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByRace ( string race )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Race == race ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRace ( string race )
		{
			return (long) SelectByRace ( race ).Count;
		}

		public IList<PlayerStorage> SelectByRace ( int start, int count, string race )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Race == race ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByHomePlanetId ( int homePlanetId )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.HomePlanetId == homePlanetId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByHomePlanetId ( int homePlanetId )
		{
			return (long) SelectByHomePlanetId ( homePlanetId ).Count;
		}

		public IList<PlayerStorage> SelectByHomePlanetId ( int start, int count, int homePlanetId )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.HomePlanetId == homePlanetId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByPirateRanking ( int pirateRanking )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.PirateRanking == pirateRanking ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPirateRanking ( int pirateRanking )
		{
			return (long) SelectByPirateRanking ( pirateRanking ).Count;
		}

		public IList<PlayerStorage> SelectByPirateRanking ( int start, int count, int pirateRanking )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.PirateRanking == pirateRanking ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByBountyRanking ( int bountyRanking )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.BountyRanking == bountyRanking ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBountyRanking ( int bountyRanking )
		{
			return (long) SelectByBountyRanking ( bountyRanking ).Count;
		}

		public IList<PlayerStorage> SelectByBountyRanking ( int start, int count, int bountyRanking )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.BountyRanking == bountyRanking ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByMerchantRanking ( int merchantRanking )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.MerchantRanking == merchantRanking ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMerchantRanking ( int merchantRanking )
		{
			return (long) SelectByMerchantRanking ( merchantRanking ).Count;
		}

		public IList<PlayerStorage> SelectByMerchantRanking ( int start, int count, int merchantRanking )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.MerchantRanking == merchantRanking ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByGladiatorRanking ( int gladiatorRanking )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.GladiatorRanking == gladiatorRanking ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByGladiatorRanking ( int gladiatorRanking )
		{
			return (long) SelectByGladiatorRanking ( gladiatorRanking ).Count;
		}

		public IList<PlayerStorage> SelectByGladiatorRanking ( int start, int count, int gladiatorRanking )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.GladiatorRanking == gladiatorRanking ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByColonizerRanking ( int colonizerRanking )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.ColonizerRanking == colonizerRanking ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByColonizerRanking ( int colonizerRanking )
		{
			return (long) SelectByColonizerRanking ( colonizerRanking ).Count;
		}

		public IList<PlayerStorage> SelectByColonizerRanking ( int start, int count, int colonizerRanking )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.ColonizerRanking == colonizerRanking ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByIntrinsicQuantities ( string intrinsicQuantities )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.IntrinsicQuantities == intrinsicQuantities ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIntrinsicQuantities ( string intrinsicQuantities )
		{
			return (long) SelectByIntrinsicQuantities ( intrinsicQuantities ).Count;
		}

		public IList<PlayerStorage> SelectByIntrinsicQuantities ( int start, int count, string intrinsicQuantities )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.IntrinsicQuantities == intrinsicQuantities ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByPlanetLevel ( int planetLevel )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.PlanetLevel == planetLevel ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPlanetLevel ( int planetLevel )
		{
			return (long) SelectByPlanetLevel ( planetLevel ).Count;
		}

		public IList<PlayerStorage> SelectByPlanetLevel ( int start, int count, int planetLevel )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.PlanetLevel == planetLevel ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByQuestContextLevel ( string questContextLevel )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.QuestContextLevel == questContextLevel ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByQuestContextLevel ( string questContextLevel )
		{
			return (long) SelectByQuestContextLevel ( questContextLevel ).Count;
		}

		public IList<PlayerStorage> SelectByQuestContextLevel ( int start, int count, string questContextLevel )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.QuestContextLevel == questContextLevel ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByActive ( bool active )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Active == active ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByActive ( bool active )
		{
			return (long) SelectByActive ( active ).Count;
		}

		public IList<PlayerStorage> SelectByActive ( int start, int count, bool active )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Active == active ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByAvatar ( string avatar )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Avatar == avatar ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAvatar ( string avatar )
		{
			return (long) SelectByAvatar ( avatar ).Count;
		}

		public IList<PlayerStorage> SelectByAvatar ( int start, int count, string avatar )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Avatar == avatar ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByUltimateWeaponLevel ( int ultimateWeaponLevel )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.UltimateWeaponLevel == ultimateWeaponLevel ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUltimateWeaponLevel ( int ultimateWeaponLevel )
		{
			return (long) SelectByUltimateWeaponLevel ( ultimateWeaponLevel ).Count;
		}

		public IList<PlayerStorage> SelectByUltimateWeaponLevel ( int start, int count, int ultimateWeaponLevel )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.UltimateWeaponLevel == ultimateWeaponLevel ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByServices ( string services )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Services == services ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByServices ( string services )
		{
			return (long) SelectByServices ( services ).Count;
		}

		public IList<PlayerStorage> SelectByServices ( int start, int count, string services )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Services == services ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByUltimateWeaponCooldown ( int ultimateWeaponCooldown )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.UltimateWeaponCooldown == ultimateWeaponCooldown ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUltimateWeaponCooldown ( int ultimateWeaponCooldown )
		{
			return (long) SelectByUltimateWeaponCooldown ( ultimateWeaponCooldown ).Count;
		}

		public IList<PlayerStorage> SelectByUltimateWeaponCooldown ( int start, int count, int ultimateWeaponCooldown )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.UltimateWeaponCooldown == ultimateWeaponCooldown ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByActivatedInTick ( int activatedInTick )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.ActivatedInTick == activatedInTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByActivatedInTick ( int activatedInTick )
		{
			return (long) SelectByActivatedInTick ( activatedInTick ).Count;
		}

		public IList<PlayerStorage> SelectByActivatedInTick ( int start, int count, int activatedInTick )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.ActivatedInTick == activatedInTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByIsGeneralActive ( bool isGeneralActive )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.IsGeneralActive == isGeneralActive ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsGeneralActive ( bool isGeneralActive )
		{
			return (long) SelectByIsGeneralActive ( isGeneralActive ).Count;
		}

		public IList<PlayerStorage> SelectByIsGeneralActive ( int start, int count, bool isGeneralActive )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.IsGeneralActive == isGeneralActive ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByGeneralId ( int generalId )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.GeneralId == generalId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByGeneralId ( int generalId )
		{
			return (long) SelectByGeneralId ( generalId ).Count;
		}

		public IList<PlayerStorage> SelectByGeneralId ( int start, int count, int generalId )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.GeneralId == generalId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByGeneralName ( string generalName )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.GeneralName == generalName ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByGeneralName ( string generalName )
		{
			return (long) SelectByGeneralName ( generalName ).Count;
		}

		public IList<PlayerStorage> SelectByGeneralName ( int start, int count, string generalName )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.GeneralName == generalName ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByGeneralFriendlyName ( string generalFriendlyName )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.GeneralFriendlyName == generalFriendlyName ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByGeneralFriendlyName ( string generalFriendlyName )
		{
			return (long) SelectByGeneralFriendlyName ( generalFriendlyName ).Count;
		}

		public IList<PlayerStorage> SelectByGeneralFriendlyName ( int start, int count, string generalFriendlyName )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.GeneralFriendlyName == generalFriendlyName ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByIsPrimary ( bool isPrimary )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.IsPrimary == isPrimary ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsPrimary ( bool isPrimary )
		{
			return (long) SelectByIsPrimary ( isPrimary ).Count;
		}

		public IList<PlayerStorage> SelectByIsPrimary ( int start, int count, bool isPrimary )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.IsPrimary == isPrimary ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByIsOnVacations ( bool isOnVacations )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.IsOnVacations == isOnVacations ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsOnVacations ( bool isOnVacations )
		{
			return (long) SelectByIsOnVacations ( isOnVacations ).Count;
		}

		public IList<PlayerStorage> SelectByIsOnVacations ( int start, int count, bool isOnVacations )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.IsOnVacations == isOnVacations ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByTotalPosts ( int totalPosts )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.TotalPosts == totalPosts ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTotalPosts ( int totalPosts )
		{
			return (long) SelectByTotalPosts ( totalPosts ).Count;
		}

		public IList<PlayerStorage> SelectByTotalPosts ( int start, int count, int totalPosts )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.TotalPosts == totalPosts ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectBySignature ( string signature )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Signature == signature ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySignature ( string signature )
		{
			return (long) SelectBySignature ( signature ).Count;
		}

		public IList<PlayerStorage> SelectBySignature ( int start, int count, string signature )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Signature == signature ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByForumRole ( string forumRole )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.ForumRole == forumRole ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByForumRole ( string forumRole )
		{
			return (long) SelectByForumRole ( forumRole ).Count;
		}

		public IList<PlayerStorage> SelectByForumRole ( int start, int count, string forumRole )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.ForumRole == forumRole ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByPrincipal ( Principal principal )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Principal == principal ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPrincipal ( Principal principal )
		{
			return (long) SelectByPrincipal ( principal ).Count;
		}

		public IList<PlayerStorage> SelectByPrincipal ( int start, int count, Principal principal )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Principal == principal ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByAlliance ( AllianceStorage alliance )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Alliance == alliance ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAlliance ( AllianceStorage alliance )
		{
			return (long) SelectByAlliance ( alliance ).Count;
		}

		public IList<PlayerStorage> SelectByAlliance ( int start, int count, AllianceStorage alliance )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Alliance == alliance ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByStats ( PlayerStats stats )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Stats == stats ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByStats ( PlayerStats stats )
		{
			return (long) SelectByStats ( stats ).Count;
		}

		public IList<PlayerStorage> SelectByStats ( int start, int count, PlayerStats stats )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.Stats == stats ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByCreatedDate ( DateTime createdDate )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCreatedDate ( DateTime createdDate )
		{
			return (long) SelectByCreatedDate ( createdDate ).Count;
		}

		public IList<PlayerStorage> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUpdatedDate ( DateTime updatedDate )
		{
			return (long) SelectByUpdatedDate ( updatedDate ).Count;
		}

		public IList<PlayerStorage> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStorage> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLastActionUserId ( int lastActionUserId )
		{
			return (long) SelectByLastActionUserId ( lastActionUserId ).Count;
		}

		public IList<PlayerStorage> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<PlayerStorage> container = new List<PlayerStorage>();
 			
			foreach( PlayerStorage obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
