using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using Institutional.Core;

namespace Institutional.DataAccessLayer {
	
	/// <summary>
    /// Memory persistance for entity.Name
    /// </summary>
	internal class MemoryPrincipalPersistance : 
			MemoryPersistance<Principal>, IPrincipalPersistance {
		
		#region IPersistance
		
		public override Principal Create()
		{
			return new SpecializedMemoryPrincipal ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Principal> SelectById ( int id )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
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

		public IList<Principal> SelectById ( int start, int count, int id )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByName ( string name )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
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

		public IList<Principal> SelectByName ( int start, int count, string name )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByPassword ( string password )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Password == password ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPassword ( string password )
		{
			return (long) SelectByPassword ( password ).Count;
		}

		public IList<Principal> SelectByPassword ( int start, int count, string password )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Password == password ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByEmail ( string email )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Email == email ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByEmail ( string email )
		{
			return (long) SelectByEmail ( email ).Count;
		}

		public IList<Principal> SelectByEmail ( int start, int count, string email )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Email == email ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByIp ( string ip )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
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

		public IList<Principal> SelectByIp ( int start, int count, string ip )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Ip == ip ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByRegistDate ( DateTime registDate )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.RegistDate == registDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRegistDate ( DateTime registDate )
		{
			return (long) SelectByRegistDate ( registDate ).Count;
		}

		public IList<Principal> SelectByRegistDate ( int start, int count, DateTime registDate )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.RegistDate == registDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByLastLogin ( DateTime lastLogin )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.LastLogin == lastLogin ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLastLogin ( DateTime lastLogin )
		{
			return (long) SelectByLastLogin ( lastLogin ).Count;
		}

		public IList<Principal> SelectByLastLogin ( int start, int count, DateTime lastLogin )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.LastLogin == lastLogin ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByApproved ( bool approved )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Approved == approved ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByApproved ( bool approved )
		{
			return (long) SelectByApproved ( approved ).Count;
		}

		public IList<Principal> SelectByApproved ( int start, int count, bool approved )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Approved == approved ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByIsOnline ( bool isOnline )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.IsOnline == isOnline ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsOnline ( bool isOnline )
		{
			return (long) SelectByIsOnline ( isOnline ).Count;
		}

		public IList<Principal> SelectByIsOnline ( int start, int count, bool isOnline )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.IsOnline == isOnline ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByLocked ( bool locked )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Locked == locked ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLocked ( bool locked )
		{
			return (long) SelectByLocked ( locked ).Count;
		}

		public IList<Principal> SelectByLocked ( int start, int count, bool locked )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Locked == locked ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByLocale ( string locale )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Locale == locale ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLocale ( string locale )
		{
			return (long) SelectByLocale ( locale ).Count;
		}

		public IList<Principal> SelectByLocale ( int start, int count, string locale )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.Locale == locale ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByConfirmationCode ( string confirmationCode )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.ConfirmationCode == confirmationCode ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByConfirmationCode ( string confirmationCode )
		{
			return (long) SelectByConfirmationCode ( confirmationCode ).Count;
		}

		public IList<Principal> SelectByConfirmationCode ( int start, int count, string confirmationCode )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.ConfirmationCode == confirmationCode ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByRawRoles ( string rawRoles )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.RawRoles == rawRoles ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRawRoles ( string rawRoles )
		{
			return (long) SelectByRawRoles ( rawRoles ).Count;
		}

		public IList<Principal> SelectByRawRoles ( int start, int count, string rawRoles )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.RawRoles == rawRoles ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
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

		public IList<Principal> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
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

		public IList<Principal> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Principal> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
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

		public IList<Principal> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Principal> container = new List<Principal>();
 			
			foreach( Principal obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
