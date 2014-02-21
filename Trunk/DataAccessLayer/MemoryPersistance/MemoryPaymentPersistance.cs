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
	internal class MemoryPaymentPersistance : 
			MemoryPersistance<Payment>, IPaymentPersistance {
		
		#region IPersistance
		
		public override Payment Create()
		{
			return new SpecializedMemoryPayment ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Payment> SelectById ( int id )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
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

		public IList<Payment> SelectById ( int start, int count, int id )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Payment> SelectByPrincipalId ( int principalId )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.PrincipalId == principalId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPrincipalId ( int principalId )
		{
			return (long) SelectByPrincipalId ( principalId ).Count;
		}

		public IList<Payment> SelectByPrincipalId ( int start, int count, int principalId )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.PrincipalId == principalId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Payment> SelectByMethod ( string method )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.Method == method ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMethod ( string method )
		{
			return (long) SelectByMethod ( method ).Count;
		}

		public IList<Payment> SelectByMethod ( int start, int count, string method )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.Method == method ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Payment> SelectByRequest ( string request )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.Request == request ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRequest ( string request )
		{
			return (long) SelectByRequest ( request ).Count;
		}

		public IList<Payment> SelectByRequest ( int start, int count, string request )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.Request == request ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Payment> SelectByResponse ( string response )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.Response == response ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByResponse ( string response )
		{
			return (long) SelectByResponse ( response ).Count;
		}

		public IList<Payment> SelectByResponse ( int start, int count, string response )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.Response == response ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Payment> SelectByRequestId ( string requestId )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.RequestId == requestId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRequestId ( string requestId )
		{
			return (long) SelectByRequestId ( requestId ).Count;
		}

		public IList<Payment> SelectByRequestId ( int start, int count, string requestId )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.RequestId == requestId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Payment> SelectByVerifyState ( string verifyState )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.VerifyState == verifyState ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByVerifyState ( string verifyState )
		{
			return (long) SelectByVerifyState ( verifyState ).Count;
		}

		public IList<Payment> SelectByVerifyState ( int start, int count, string verifyState )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.VerifyState == verifyState ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Payment> SelectByParameters ( string parameters )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.Parameters == parameters ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByParameters ( string parameters )
		{
			return (long) SelectByParameters ( parameters ).Count;
		}

		public IList<Payment> SelectByParameters ( int start, int count, string parameters )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.Parameters == parameters ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Payment> SelectByParentPayment ( int parentPayment )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.ParentPayment == parentPayment ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByParentPayment ( int parentPayment )
		{
			return (long) SelectByParentPayment ( parentPayment ).Count;
		}

		public IList<Payment> SelectByParentPayment ( int start, int count, int parentPayment )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.ParentPayment == parentPayment ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Payment> SelectByAmmount ( string ammount )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.Ammount == ammount ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAmmount ( string ammount )
		{
			return (long) SelectByAmmount ( ammount ).Count;
		}

		public IList<Payment> SelectByAmmount ( int start, int count, string ammount )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.Ammount == ammount ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Payment> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
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

		public IList<Payment> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Payment> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
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

		public IList<Payment> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Payment> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
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

		public IList<Payment> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Payment> container = new List<Payment>();
 			
			foreach( Payment obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
