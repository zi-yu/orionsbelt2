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
	internal class MemoryPromotionPersistance : 
			MemoryPersistance<Promotion>, IPromotionPersistance {
		
		#region IPersistance
		
		public override Promotion Create()
		{
			return new SpecializedMemoryPromotion ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Promotion> SelectById ( int id )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
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

		public IList<Promotion> SelectById ( int start, int count, int id )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByName ( string name )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
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

		public IList<Promotion> SelectByName ( int start, int count, string name )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByBeginDate ( DateTime beginDate )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.BeginDate == beginDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBeginDate ( DateTime beginDate )
		{
			return (long) SelectByBeginDate ( beginDate ).Count;
		}

		public IList<Promotion> SelectByBeginDate ( int start, int count, DateTime beginDate )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.BeginDate == beginDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByEndDate ( DateTime endDate )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.EndDate == endDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByEndDate ( DateTime endDate )
		{
			return (long) SelectByEndDate ( endDate ).Count;
		}

		public IList<Promotion> SelectByEndDate ( int start, int count, DateTime endDate )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.EndDate == endDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByRevenueType ( string revenueType )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.RevenueType == revenueType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRevenueType ( string revenueType )
		{
			return (long) SelectByRevenueType ( revenueType ).Count;
		}

		public IList<Promotion> SelectByRevenueType ( int start, int count, string revenueType )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.RevenueType == revenueType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByRevenue ( double revenue )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.Revenue == revenue ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRevenue ( double revenue )
		{
			return (long) SelectByRevenue ( revenue ).Count;
		}

		public IList<Promotion> SelectByRevenue ( int start, int count, double revenue )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.Revenue == revenue ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByPromotionType ( string promotionType )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.PromotionType == promotionType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPromotionType ( string promotionType )
		{
			return (long) SelectByPromotionType ( promotionType ).Count;
		}

		public IList<Promotion> SelectByPromotionType ( int start, int count, string promotionType )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.PromotionType == promotionType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByRangeBegin ( int rangeBegin )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.RangeBegin == rangeBegin ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRangeBegin ( int rangeBegin )
		{
			return (long) SelectByRangeBegin ( rangeBegin ).Count;
		}

		public IList<Promotion> SelectByRangeBegin ( int start, int count, int rangeBegin )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.RangeBegin == rangeBegin ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByRangeEnd ( int rangeEnd )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.RangeEnd == rangeEnd ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRangeEnd ( int rangeEnd )
		{
			return (long) SelectByRangeEnd ( rangeEnd ).Count;
		}

		public IList<Promotion> SelectByRangeEnd ( int start, int count, int rangeEnd )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.RangeEnd == rangeEnd ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByPromotionCode ( int promotionCode )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.PromotionCode == promotionCode ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPromotionCode ( int promotionCode )
		{
			return (long) SelectByPromotionCode ( promotionCode ).Count;
		}

		public IList<Promotion> SelectByPromotionCode ( int start, int count, int promotionCode )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.PromotionCode == promotionCode ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByBonusType ( string bonusType )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.BonusType == bonusType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBonusType ( string bonusType )
		{
			return (long) SelectByBonusType ( bonusType ).Count;
		}

		public IList<Promotion> SelectByBonusType ( int start, int count, string bonusType )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.BonusType == bonusType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByBonus ( int bonus )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.Bonus == bonus ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBonus ( int bonus )
		{
			return (long) SelectByBonus ( bonus ).Count;
		}

		public IList<Promotion> SelectByBonus ( int start, int count, int bonus )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.Bonus == bonus ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByStatus ( string status )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.Status == status ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByStatus ( string status )
		{
			return (long) SelectByStatus ( status ).Count;
		}

		public IList<Promotion> SelectByStatus ( int start, int count, string status )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.Status == status ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByDescription ( string description )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.Description == description ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByDescription ( string description )
		{
			return (long) SelectByDescription ( description ).Count;
		}

		public IList<Promotion> SelectByDescription ( int start, int count, string description )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.Description == description ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByUses ( int uses )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.Uses == uses ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUses ( int uses )
		{
			return (long) SelectByUses ( uses ).Count;
		}

		public IList<Promotion> SelectByUses ( int start, int count, int uses )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.Uses == uses ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByOwner ( Principal owner )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.Owner == owner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByOwner ( Principal owner )
		{
			return (long) SelectByOwner ( owner ).Count;
		}

		public IList<Promotion> SelectByOwner ( int start, int count, Principal owner )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.Owner == owner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
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

		public IList<Promotion> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
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

		public IList<Promotion> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Promotion> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
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

		public IList<Promotion> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Promotion> container = new List<Promotion>();
 			
			foreach( Promotion obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
