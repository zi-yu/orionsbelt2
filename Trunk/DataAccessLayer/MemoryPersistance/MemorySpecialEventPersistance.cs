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
	internal class MemorySpecialEventPersistance : 
			MemoryPersistance<SpecialEvent>, ISpecialEventPersistance {
		
		#region IPersistance
		
		public override SpecialEvent Create()
		{
			return new SpecializedMemorySpecialEvent ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<SpecialEvent> SelectById ( int id )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
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

		public IList<SpecialEvent> SelectById ( int start, int count, int id )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SpecialEvent> SelectByCost ( int cost )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
 				if( obj.Cost == cost ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCost ( int cost )
		{
			return (long) SelectByCost ( cost ).Count;
		}

		public IList<SpecialEvent> SelectByCost ( int start, int count, int cost )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
 				if( obj.Cost == cost ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SpecialEvent> SelectByToken ( string token )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
 				if( obj.Token == token ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByToken ( string token )
		{
			return (long) SelectByToken ( token ).Count;
		}

		public IList<SpecialEvent> SelectByToken ( int start, int count, string token )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
 				if( obj.Token == token ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SpecialEvent> SelectByResorces ( string resorces )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
 				if( obj.Resorces == resorces ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByResorces ( string resorces )
		{
			return (long) SelectByResorces ( resorces ).Count;
		}

		public IList<SpecialEvent> SelectByResorces ( int start, int count, string resorces )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
 				if( obj.Resorces == resorces ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SpecialEvent> SelectByBeginDate ( DateTime beginDate )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
 				if( obj.BeginDate == beginDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBeginDate ( DateTime beginDate )
		{
			return (long) SelectByBeginDate ( beginDate ).Count;
		}

		public IList<SpecialEvent> SelectByBeginDate ( int start, int count, DateTime beginDate )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
 				if( obj.BeginDate == beginDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SpecialEvent> SelectByEndDate ( DateTime endDate )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
 				if( obj.EndDate == endDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByEndDate ( DateTime endDate )
		{
			return (long) SelectByEndDate ( endDate ).Count;
		}

		public IList<SpecialEvent> SelectByEndDate ( int start, int count, DateTime endDate )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
 				if( obj.EndDate == endDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SpecialEvent> SelectByCreatedDate ( DateTime createdDate )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
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

		public IList<SpecialEvent> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SpecialEvent> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
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

		public IList<SpecialEvent> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SpecialEvent> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
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

		public IList<SpecialEvent> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<SpecialEvent> container = new List<SpecialEvent>();
 			
			foreach( SpecialEvent obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
