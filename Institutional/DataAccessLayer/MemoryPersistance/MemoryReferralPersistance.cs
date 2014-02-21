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
	internal class MemoryReferralPersistance : 
			MemoryPersistance<Referral>, IReferralPersistance {
		
		#region IPersistance
		
		public override Referral Create()
		{
			return new SpecializedMemoryReferral ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Referral> SelectById ( int id )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
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

		public IList<Referral> SelectById ( int start, int count, int id )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Referral> SelectByCode ( int code )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
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

		public IList<Referral> SelectByCode ( int start, int count, int code )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
 				if( obj.Code == code ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Referral> SelectByName ( string name )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
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

		public IList<Referral> SelectByName ( int start, int count, string name )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Referral> SelectBySourceUrl ( string sourceUrl )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
 				if( obj.SourceUrl == sourceUrl ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySourceUrl ( string sourceUrl )
		{
			return (long) SelectBySourceUrl ( sourceUrl ).Count;
		}

		public IList<Referral> SelectBySourceUrl ( int start, int count, string sourceUrl )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
 				if( obj.SourceUrl == sourceUrl ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Referral> SelectByFilters ( string filters )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
 				if( obj.Filters == filters ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByFilters ( string filters )
		{
			return (long) SelectByFilters ( filters ).Count;
		}

		public IList<Referral> SelectByFilters ( int start, int count, string filters )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
 				if( obj.Filters == filters ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Referral> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
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

		public IList<Referral> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Referral> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
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

		public IList<Referral> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Referral> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
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

		public IList<Referral> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Referral> container = new List<Referral>();
 			
			foreach( Referral obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
