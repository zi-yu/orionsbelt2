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
	internal class MemoryPaymentDescriptionPersistance : 
			MemoryPersistance<PaymentDescription>, IPaymentDescriptionPersistance {
		
		#region IPersistance
		
		public override PaymentDescription Create()
		{
			return new SpecializedMemoryPaymentDescription ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<PaymentDescription> SelectById ( int id )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
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

		public IList<PaymentDescription> SelectById ( int start, int count, int id )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PaymentDescription> SelectByType ( string type )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
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

		public IList<PaymentDescription> SelectByType ( int start, int count, string type )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PaymentDescription> SelectByAmount ( int amount )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.Amount == amount ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAmount ( int amount )
		{
			return (long) SelectByAmount ( amount ).Count;
		}

		public IList<PaymentDescription> SelectByAmount ( int start, int count, int amount )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.Amount == amount ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PaymentDescription> SelectByBonus ( int bonus )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.Bonus == bonus ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBonus ( int bonus )
		{
			return (long) SelectByBonus ( bonus ).Count;
		}

		public IList<PaymentDescription> SelectByBonus ( int start, int count, int bonus )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.Bonus == bonus ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PaymentDescription> SelectByCost ( double cost )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.Cost == cost ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCost ( double cost )
		{
			return (long) SelectByCost ( cost ).Count;
		}

		public IList<PaymentDescription> SelectByCost ( int start, int count, double cost )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.Cost == cost ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PaymentDescription> SelectByLocale ( string locale )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
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

		public IList<PaymentDescription> SelectByLocale ( int start, int count, string locale )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.Locale == locale ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PaymentDescription> SelectByData ( string data )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.Data == data ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByData ( string data )
		{
			return (long) SelectByData ( data ).Count;
		}

		public IList<PaymentDescription> SelectByData ( int start, int count, string data )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.Data == data ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PaymentDescription> SelectByCurrency ( string currency )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.Currency == currency ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCurrency ( string currency )
		{
			return (long) SelectByCurrency ( currency ).Count;
		}

		public IList<PaymentDescription> SelectByCurrency ( int start, int count, string currency )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.Currency == currency ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PaymentDescription> SelectByCreatedDate ( DateTime createdDate )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
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

		public IList<PaymentDescription> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PaymentDescription> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
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

		public IList<PaymentDescription> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PaymentDescription> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
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

		public IList<PaymentDescription> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<PaymentDescription> container = new List<PaymentDescription>();
 			
			foreach( PaymentDescription obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
