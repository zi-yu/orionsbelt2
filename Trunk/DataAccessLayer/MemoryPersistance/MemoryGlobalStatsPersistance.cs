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
	internal class MemoryGlobalStatsPersistance : 
			MemoryPersistance<GlobalStats>, IGlobalStatsPersistance {
		
		#region IPersistance
		
		public override GlobalStats Create()
		{
			return new SpecializedMemoryGlobalStats ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<GlobalStats> SelectById ( int id )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
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

		public IList<GlobalStats> SelectById ( int start, int count, int id )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<GlobalStats> SelectByType ( string type )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
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

		public IList<GlobalStats> SelectByType ( int start, int count, string type )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<GlobalStats> SelectByTick ( int tick )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
 				if( obj.Tick == tick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTick ( int tick )
		{
			return (long) SelectByTick ( tick ).Count;
		}

		public IList<GlobalStats> SelectByTick ( int start, int count, int tick )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
 				if( obj.Tick == tick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<GlobalStats> SelectByText ( string text )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
 				if( obj.Text == text ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByText ( string text )
		{
			return (long) SelectByText ( text ).Count;
		}

		public IList<GlobalStats> SelectByText ( int start, int count, string text )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
 				if( obj.Text == text ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<GlobalStats> SelectByNumber ( double number )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
 				if( obj.Number == number ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByNumber ( double number )
		{
			return (long) SelectByNumber ( number ).Count;
		}

		public IList<GlobalStats> SelectByNumber ( int start, int count, double number )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
 				if( obj.Number == number ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<GlobalStats> SelectByCreatedDate ( DateTime createdDate )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
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

		public IList<GlobalStats> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<GlobalStats> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
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

		public IList<GlobalStats> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<GlobalStats> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
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

		public IList<GlobalStats> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<GlobalStats> container = new List<GlobalStats>();
 			
			foreach( GlobalStats obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
