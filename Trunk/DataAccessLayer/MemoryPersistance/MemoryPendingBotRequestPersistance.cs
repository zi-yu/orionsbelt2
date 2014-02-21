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
	internal class MemoryPendingBotRequestPersistance : 
			MemoryPersistance<PendingBotRequest>, IPendingBotRequestPersistance {
		
		#region IPersistance
		
		public override PendingBotRequest Create()
		{
			return new SpecializedMemoryPendingBotRequest ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<PendingBotRequest> SelectById ( int id )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
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

		public IList<PendingBotRequest> SelectById ( int start, int count, int id )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PendingBotRequest> SelectByBotName ( string botName )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
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

		public IList<PendingBotRequest> SelectByBotName ( int start, int count, string botName )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
 				if( obj.BotName == botName ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PendingBotRequest> SelectByXml ( string xml )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
 				if( obj.Xml == xml ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByXml ( string xml )
		{
			return (long) SelectByXml ( xml ).Count;
		}

		public IList<PendingBotRequest> SelectByXml ( int start, int count, string xml )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
 				if( obj.Xml == xml ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PendingBotRequest> SelectByBattleId ( int battleId )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
 				if( obj.BattleId == battleId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBattleId ( int battleId )
		{
			return (long) SelectByBattleId ( battleId ).Count;
		}

		public IList<PendingBotRequest> SelectByBattleId ( int start, int count, int battleId )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
 				if( obj.BattleId == battleId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PendingBotRequest> SelectByBotId ( int botId )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
 				if( obj.BotId == botId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBotId ( int botId )
		{
			return (long) SelectByBotId ( botId ).Count;
		}

		public IList<PendingBotRequest> SelectByBotId ( int start, int count, int botId )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
 				if( obj.BotId == botId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PendingBotRequest> SelectByCode ( int code )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
 				if( obj.Code == code ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCode ( int code )
		{
			return (long) SelectByCode ( code ).Count;
		}

		public IList<PendingBotRequest> SelectByCode ( int start, int count, int code )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
 				if( obj.Code == code ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PendingBotRequest> SelectByCreatedDate ( DateTime createdDate )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
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

		public IList<PendingBotRequest> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PendingBotRequest> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
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

		public IList<PendingBotRequest> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PendingBotRequest> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
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

		public IList<PendingBotRequest> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<PendingBotRequest> container = new List<PendingBotRequest>();
 			
			foreach( PendingBotRequest obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
