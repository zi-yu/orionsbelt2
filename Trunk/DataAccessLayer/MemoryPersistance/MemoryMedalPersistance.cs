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
	internal class MemoryMedalPersistance : 
			MemoryPersistance<Medal>, IMedalPersistance {
		
		#region IPersistance
		
		public override Medal Create()
		{
			return new SpecializedMemoryMedal ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Medal> SelectById ( int id )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
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

		public IList<Medal> SelectById ( int start, int count, int id )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Medal> SelectByName ( string name )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
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

		public IList<Medal> SelectByName ( int start, int count, string name )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Medal> SelectByIsAuto ( bool isAuto )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
 				if( obj.IsAuto == isAuto ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsAuto ( bool isAuto )
		{
			return (long) SelectByIsAuto ( isAuto ).Count;
		}

		public IList<Medal> SelectByIsAuto ( int start, int count, bool isAuto )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
 				if( obj.IsAuto == isAuto ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Medal> SelectByPlayer ( PlayerStorage player )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
 				if( obj.Player == player ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPlayer ( PlayerStorage player )
		{
			return (long) SelectByPlayer ( player ).Count;
		}

		public IList<Medal> SelectByPlayer ( int start, int count, PlayerStorage player )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
 				if( obj.Player == player ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Medal> SelectByPrincipal ( Principal principal )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
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

		public IList<Medal> SelectByPrincipal ( int start, int count, Principal principal )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
 				if( obj.Principal == principal ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Medal> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
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

		public IList<Medal> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Medal> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
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

		public IList<Medal> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Medal> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
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

		public IList<Medal> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Medal> container = new List<Medal>();
 			
			foreach( Medal obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
