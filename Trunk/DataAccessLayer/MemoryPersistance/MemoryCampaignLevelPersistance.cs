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
	internal class MemoryCampaignLevelPersistance : 
			MemoryPersistance<CampaignLevel>, ICampaignLevelPersistance {
		
		#region IPersistance
		
		public override CampaignLevel Create()
		{
			return new SpecializedMemoryCampaignLevel ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<CampaignLevel> SelectById ( int id )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
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

		public IList<CampaignLevel> SelectById ( int start, int count, int id )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignLevel> SelectByBotFleet ( string botFleet )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
 				if( obj.BotFleet == botFleet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBotFleet ( string botFleet )
		{
			return (long) SelectByBotFleet ( botFleet ).Count;
		}

		public IList<CampaignLevel> SelectByBotFleet ( int start, int count, string botFleet )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
 				if( obj.BotFleet == botFleet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignLevel> SelectByPlayerFleet ( string playerFleet )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
 				if( obj.PlayerFleet == playerFleet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPlayerFleet ( string playerFleet )
		{
			return (long) SelectByPlayerFleet ( playerFleet ).Count;
		}

		public IList<CampaignLevel> SelectByPlayerFleet ( int start, int count, string playerFleet )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
 				if( obj.PlayerFleet == playerFleet ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignLevel> SelectByLevel ( int level )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
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

		public IList<CampaignLevel> SelectByLevel ( int start, int count, int level )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
 				if( obj.Level == level ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignLevel> SelectByBotName ( string botName )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
 				if( obj.BotName == botName ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBotName ( string botName )
		{
			return (long) SelectByBotName ( botName ).Count;
		}

		public IList<CampaignLevel> SelectByBotName ( int start, int count, string botName )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
 				if( obj.BotName == botName ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignLevel> SelectByCampaign ( Campaign campaign )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
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

		public IList<CampaignLevel> SelectByCampaign ( int start, int count, Campaign campaign )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
 				if( obj.Campaign == campaign ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignLevel> SelectByCreatedDate ( DateTime createdDate )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
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

		public IList<CampaignLevel> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignLevel> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
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

		public IList<CampaignLevel> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<CampaignLevel> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
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

		public IList<CampaignLevel> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<CampaignLevel> container = new List<CampaignLevel>();
 			
			foreach( CampaignLevel obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
