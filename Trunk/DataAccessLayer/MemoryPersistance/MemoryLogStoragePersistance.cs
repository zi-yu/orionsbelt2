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
	internal class MemoryLogStoragePersistance : 
			MemoryPersistance<LogStorage>, ILogStoragePersistance {
		
		#region IPersistance
		
		public override LogStorage Create()
		{
			return new SpecializedMemoryLogStorage ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<LogStorage> SelectById ( int id )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
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

		public IList<LogStorage> SelectById ( int start, int count, int id )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<LogStorage> SelectByDate ( DateTime date )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Date == date ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByDate ( DateTime date )
		{
			return (long) SelectByDate ( date ).Count;
		}

		public IList<LogStorage> SelectByDate ( int start, int count, DateTime date )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Date == date ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<LogStorage> SelectByUsername1 ( string username1 )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Username1 == username1 ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUsername1 ( string username1 )
		{
			return (long) SelectByUsername1 ( username1 ).Count;
		}

		public IList<LogStorage> SelectByUsername1 ( int start, int count, string username1 )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Username1 == username1 ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<LogStorage> SelectByLevel ( string level )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Level == level ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLevel ( string level )
		{
			return (long) SelectByLevel ( level ).Count;
		}

		public IList<LogStorage> SelectByLevel ( int start, int count, string level )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Level == level ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<LogStorage> SelectByUrl ( string url )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Url == url ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUrl ( string url )
		{
			return (long) SelectByUrl ( url ).Count;
		}

		public IList<LogStorage> SelectByUrl ( int start, int count, string url )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Url == url ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<LogStorage> SelectByContent ( string content )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Content == content ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByContent ( string content )
		{
			return (long) SelectByContent ( content ).Count;
		}

		public IList<LogStorage> SelectByContent ( int start, int count, string content )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Content == content ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<LogStorage> SelectByExceptionInformation ( string exceptionInformation )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.ExceptionInformation == exceptionInformation ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByExceptionInformation ( string exceptionInformation )
		{
			return (long) SelectByExceptionInformation ( exceptionInformation ).Count;
		}

		public IList<LogStorage> SelectByExceptionInformation ( int start, int count, string exceptionInformation )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.ExceptionInformation == exceptionInformation ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<LogStorage> SelectByIp ( string ip )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Ip == ip ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIp ( string ip )
		{
			return (long) SelectByIp ( ip ).Count;
		}

		public IList<LogStorage> SelectByIp ( int start, int count, string ip )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Ip == ip ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<LogStorage> SelectByType ( string type )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByType ( string type )
		{
			return (long) SelectByType ( type ).Count;
		}

		public IList<LogStorage> SelectByType ( int start, int count, string type )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<LogStorage> SelectByUsername2 ( string username2 )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Username2 == username2 ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUsername2 ( string username2 )
		{
			return (long) SelectByUsername2 ( username2 ).Count;
		}

		public IList<LogStorage> SelectByUsername2 ( int start, int count, string username2 )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.Username2 == username2 ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<LogStorage> SelectByCreatedDate ( DateTime createdDate )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
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

		public IList<LogStorage> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<LogStorage> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
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

		public IList<LogStorage> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<LogStorage> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
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

		public IList<LogStorage> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<LogStorage> container = new List<LogStorage>();
 			
			foreach( LogStorage obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
