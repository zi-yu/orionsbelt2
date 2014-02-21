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
	internal class MemoryCampaignStatusPersistance : 
			MemoryPersistance<CampaignStatus>, ICampaignStatusPersistance {
		
		#region IPersistance
		
		public override CampaignStatus Create()
		{
			return new SpecializedMemoryCampaignStatus ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<CampaignStatus> SelectById ( int id )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
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

		public IList<CampaignStatus> SelectById ( int start, int count, int id )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignStatus> SelectByLevel ( int level )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.Level == level ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLevel ( int level )
		{
			return (long) SelectByLevel ( level ).Count;
		}

		public IList<CampaignStatus> SelectByLevel ( int start, int count, int level )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.Level == level ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignStatus> SelectByMoves ( int moves )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.Moves == moves ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMoves ( int moves )
		{
			return (long) SelectByMoves ( moves ).Count;
		}

		public IList<CampaignStatus> SelectByMoves ( int start, int count, int moves )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.Moves == moves ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignStatus> SelectByCompleted ( bool completed )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.Completed == completed ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCompleted ( bool completed )
		{
			return (long) SelectByCompleted ( completed ).Count;
		}

		public IList<CampaignStatus> SelectByCompleted ( int start, int count, bool completed )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.Completed == completed ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignStatus> SelectByCampaign ( Campaign campaign )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.Campaign == campaign ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCampaign ( Campaign campaign )
		{
			return (long) SelectByCampaign ( campaign ).Count;
		}

		public IList<CampaignStatus> SelectByCampaign ( int start, int count, Campaign campaign )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.Campaign == campaign ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignStatus> SelectByPrincipal ( Principal principal )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
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

		public IList<CampaignStatus> SelectByPrincipal ( int start, int count, Principal principal )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.Principal == principal ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignStatus> SelectByBattle ( Battle battle )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.Battle == battle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBattle ( Battle battle )
		{
			return (long) SelectByBattle ( battle ).Count;
		}

		public IList<CampaignStatus> SelectByBattle ( int start, int count, Battle battle )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.Battle == battle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignStatus> SelectByLevelTemplate ( CampaignLevel levelTemplate )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.LevelTemplate == levelTemplate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLevelTemplate ( CampaignLevel levelTemplate )
		{
			return (long) SelectByLevelTemplate ( levelTemplate ).Count;
		}

		public IList<CampaignStatus> SelectByLevelTemplate ( int start, int count, CampaignLevel levelTemplate )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.LevelTemplate == levelTemplate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignStatus> SelectByCreatedDate ( DateTime createdDate )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
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

		public IList<CampaignStatus> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignStatus> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
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

		public IList<CampaignStatus> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignStatus> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
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

		public IList<CampaignStatus> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<CampaignStatus> container = new List<CampaignStatus>();
 			
			foreach( CampaignStatus obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
