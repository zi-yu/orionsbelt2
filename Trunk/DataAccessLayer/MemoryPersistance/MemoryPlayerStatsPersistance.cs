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
	internal class MemoryPlayerStatsPersistance : 
			MemoryPersistance<PlayerStats>, IPlayerStatsPersistance {
		
		#region IPersistance
		
		public override PlayerStats Create()
		{
			return new SpecializedMemoryPlayerStats ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<PlayerStats> SelectById ( int id )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
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

		public IList<PlayerStats> SelectById ( int start, int count, int id )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStats> SelectByNumberOfPlayedBattles ( int numberOfPlayedBattles )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.NumberOfPlayedBattles == numberOfPlayedBattles ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByNumberOfPlayedBattles ( int numberOfPlayedBattles )
		{
			return (long) SelectByNumberOfPlayedBattles ( numberOfPlayedBattles ).Count;
		}

		public IList<PlayerStats> SelectByNumberOfPlayedBattles ( int start, int count, int numberOfPlayedBattles )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.NumberOfPlayedBattles == numberOfPlayedBattles ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStats> SelectByNumberPirateQuest ( int numberPirateQuest )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.NumberPirateQuest == numberPirateQuest ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByNumberPirateQuest ( int numberPirateQuest )
		{
			return (long) SelectByNumberPirateQuest ( numberPirateQuest ).Count;
		}

		public IList<PlayerStats> SelectByNumberPirateQuest ( int start, int count, int numberPirateQuest )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.NumberPirateQuest == numberPirateQuest ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStats> SelectByNumberBountyQuests ( int numberBountyQuests )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.NumberBountyQuests == numberBountyQuests ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByNumberBountyQuests ( int numberBountyQuests )
		{
			return (long) SelectByNumberBountyQuests ( numberBountyQuests ).Count;
		}

		public IList<PlayerStats> SelectByNumberBountyQuests ( int start, int count, int numberBountyQuests )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.NumberBountyQuests == numberBountyQuests ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStats> SelectByNumberMerchantQuests ( int numberMerchantQuests )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.NumberMerchantQuests == numberMerchantQuests ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByNumberMerchantQuests ( int numberMerchantQuests )
		{
			return (long) SelectByNumberMerchantQuests ( numberMerchantQuests ).Count;
		}

		public IList<PlayerStats> SelectByNumberMerchantQuests ( int start, int count, int numberMerchantQuests )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.NumberMerchantQuests == numberMerchantQuests ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStats> SelectByNumberGladiatorQuests ( int numberGladiatorQuests )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.NumberGladiatorQuests == numberGladiatorQuests ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByNumberGladiatorQuests ( int numberGladiatorQuests )
		{
			return (long) SelectByNumberGladiatorQuests ( numberGladiatorQuests ).Count;
		}

		public IList<PlayerStats> SelectByNumberGladiatorQuests ( int start, int count, int numberGladiatorQuests )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.NumberGladiatorQuests == numberGladiatorQuests ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStats> SelectByNumberColonizerQuests ( int numberColonizerQuests )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.NumberColonizerQuests == numberColonizerQuests ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByNumberColonizerQuests ( int numberColonizerQuests )
		{
			return (long) SelectByNumberColonizerQuests ( numberColonizerQuests ).Count;
		}

		public IList<PlayerStats> SelectByNumberColonizerQuests ( int start, int count, int numberColonizerQuests )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.NumberColonizerQuests == numberColonizerQuests ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStats> SelectByCreatedDate ( DateTime createdDate )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
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

		public IList<PlayerStats> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStats> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
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

		public IList<PlayerStats> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayerStats> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
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

		public IList<PlayerStats> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<PlayerStats> container = new List<PlayerStats>();
 			
			foreach( PlayerStats obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
