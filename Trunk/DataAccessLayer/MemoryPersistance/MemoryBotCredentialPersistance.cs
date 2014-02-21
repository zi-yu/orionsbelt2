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
	internal class MemoryBotCredentialPersistance : 
			MemoryPersistance<BotCredential>, IBotCredentialPersistance {
		
		#region IPersistance
		
		public override BotCredential Create()
		{
			return new SpecializedMemoryBotCredential ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<BotCredential> SelectById ( int id )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
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

		public IList<BotCredential> SelectById ( int start, int count, int id )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BotCredential> SelectByName ( string name )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
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

		public IList<BotCredential> SelectByName ( int start, int count, string name )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BotCredential> SelectByServer ( string server )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
 				if( obj.Server == server ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByServer ( string server )
		{
			return (long) SelectByServer ( server ).Count;
		}

		public IList<BotCredential> SelectByServer ( int start, int count, string server )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
 				if( obj.Server == server ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BotCredential> SelectByVerificationCode ( string verificationCode )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
 				if( obj.VerificationCode == verificationCode ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByVerificationCode ( string verificationCode )
		{
			return (long) SelectByVerificationCode ( verificationCode ).Count;
		}

		public IList<BotCredential> SelectByVerificationCode ( int start, int count, string verificationCode )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
 				if( obj.VerificationCode == verificationCode ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BotCredential> SelectByBotId ( int botId )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
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

		public IList<BotCredential> SelectByBotId ( int start, int count, int botId )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
 				if( obj.BotId == botId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BotCredential> SelectByCreatedDate ( DateTime createdDate )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
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

		public IList<BotCredential> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BotCredential> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
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

		public IList<BotCredential> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BotCredential> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
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

		public IList<BotCredential> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<BotCredential> container = new List<BotCredential>();
 			
			foreach( BotCredential obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
