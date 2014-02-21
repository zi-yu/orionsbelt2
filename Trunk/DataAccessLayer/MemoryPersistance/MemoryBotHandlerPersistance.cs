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
	internal class MemoryBotHandlerPersistance : 
			MemoryPersistance<BotHandler>, IBotHandlerPersistance {
		
		#region IPersistance
		
		public override BotHandler Create()
		{
			return new SpecializedMemoryBotHandler ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<BotHandler> SelectById ( int id )
		{
			List<BotHandler> container = new List<BotHandler>();
 			
			foreach( BotHandler obj in Database.Values) {
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

		public IList<BotHandler> SelectById ( int start, int count, int id )
		{
			List<BotHandler> container = new List<BotHandler>();
 			
			foreach( BotHandler obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BotHandler> SelectByName ( string name )
		{
			List<BotHandler> container = new List<BotHandler>();
 			
			foreach( BotHandler obj in Database.Values) {
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

		public IList<BotHandler> SelectByName ( int start, int count, string name )
		{
			List<BotHandler> container = new List<BotHandler>();
 			
			foreach( BotHandler obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BotHandler> SelectByCode ( int code )
		{
			List<BotHandler> container = new List<BotHandler>();
 			
			foreach( BotHandler obj in Database.Values) {
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

		public IList<BotHandler> SelectByCode ( int start, int count, int code )
		{
			List<BotHandler> container = new List<BotHandler>();
 			
			foreach( BotHandler obj in Database.Values) {
 				if( obj.Code == code ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BotHandler> SelectByCreatedDate ( DateTime createdDate )
		{
			List<BotHandler> container = new List<BotHandler>();
 			
			foreach( BotHandler obj in Database.Values) {
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

		public IList<BotHandler> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<BotHandler> container = new List<BotHandler>();
 			
			foreach( BotHandler obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BotHandler> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<BotHandler> container = new List<BotHandler>();
 			
			foreach( BotHandler obj in Database.Values) {
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

		public IList<BotHandler> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<BotHandler> container = new List<BotHandler>();
 			
			foreach( BotHandler obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BotHandler> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<BotHandler> container = new List<BotHandler>();
 			
			foreach( BotHandler obj in Database.Values) {
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

		public IList<BotHandler> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<BotHandler> container = new List<BotHandler>();
 			
			foreach( BotHandler obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
