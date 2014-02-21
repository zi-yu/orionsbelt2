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
	internal class MemoryCampaignPersistance : 
			MemoryPersistance<Campaign>, ICampaignPersistance {
		
		#region IPersistance
		
		public override Campaign Create()
		{
			return new SpecializedMemoryCampaign ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Campaign> SelectById ( int id )
		{
			List<Campaign> container = new List<Campaign>();
 			
			foreach( Campaign obj in Database.Values) {
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

		public IList<Campaign> SelectById ( int start, int count, int id )
		{
			List<Campaign> container = new List<Campaign>();
 			
			foreach( Campaign obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Campaign> SelectByName ( string name )
		{
			List<Campaign> container = new List<Campaign>();
 			
			foreach( Campaign obj in Database.Values) {
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

		public IList<Campaign> SelectByName ( int start, int count, string name )
		{
			List<Campaign> container = new List<Campaign>();
 			
			foreach( Campaign obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Campaign> SelectByPrincipal ( Principal principal )
		{
			List<Campaign> container = new List<Campaign>();
 			
			foreach( Campaign obj in Database.Values) {
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

		public IList<Campaign> SelectByPrincipal ( int start, int count, Principal principal )
		{
			List<Campaign> container = new List<Campaign>();
 			
			foreach( Campaign obj in Database.Values) {
 				if( obj.Principal == principal ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Campaign> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Campaign> container = new List<Campaign>();
 			
			foreach( Campaign obj in Database.Values) {
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

		public IList<Campaign> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Campaign> container = new List<Campaign>();
 			
			foreach( Campaign obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Campaign> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Campaign> container = new List<Campaign>();
 			
			foreach( Campaign obj in Database.Values) {
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

		public IList<Campaign> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Campaign> container = new List<Campaign>();
 			
			foreach( Campaign obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Campaign> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Campaign> container = new List<Campaign>();
 			
			foreach( Campaign obj in Database.Values) {
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

		public IList<Campaign> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Campaign> container = new List<Campaign>();
 			
			foreach( Campaign obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
