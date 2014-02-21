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
	internal class MemoryActivatedPromotionPersistance : 
			MemoryPersistance<ActivatedPromotion>, IActivatedPromotionPersistance {
		
		#region IPersistance
		
		public override ActivatedPromotion Create()
		{
			return new SpecializedMemoryActivatedPromotion ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<ActivatedPromotion> SelectById ( int id )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
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

		public IList<ActivatedPromotion> SelectById ( int start, int count, int id )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ActivatedPromotion> SelectByUsed ( bool used )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
 				if( obj.Used == used ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUsed ( bool used )
		{
			return (long) SelectByUsed ( used ).Count;
		}

		public IList<ActivatedPromotion> SelectByUsed ( int start, int count, bool used )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
 				if( obj.Used == used ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ActivatedPromotion> SelectByCode ( string code )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
 				if( obj.Code == code ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCode ( string code )
		{
			return (long) SelectByCode ( code ).Count;
		}

		public IList<ActivatedPromotion> SelectByCode ( int start, int count, string code )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
 				if( obj.Code == code ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ActivatedPromotion> SelectByPromotion ( Promotion promotion )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
 				if( obj.Promotion == promotion ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPromotion ( Promotion promotion )
		{
			return (long) SelectByPromotion ( promotion ).Count;
		}

		public IList<ActivatedPromotion> SelectByPromotion ( int start, int count, Promotion promotion )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
 				if( obj.Promotion == promotion ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ActivatedPromotion> SelectByPrincipal ( Principal principal )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
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

		public IList<ActivatedPromotion> SelectByPrincipal ( int start, int count, Principal principal )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
 				if( obj.Principal == principal ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ActivatedPromotion> SelectByCreatedDate ( DateTime createdDate )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
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

		public IList<ActivatedPromotion> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ActivatedPromotion> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
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

		public IList<ActivatedPromotion> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ActivatedPromotion> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
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

		public IList<ActivatedPromotion> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<ActivatedPromotion> container = new List<ActivatedPromotion>();
 			
			foreach( ActivatedPromotion obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
