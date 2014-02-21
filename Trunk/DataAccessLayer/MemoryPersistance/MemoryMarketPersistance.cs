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
	internal class MemoryMarketPersistance : 
			MemoryPersistance<Market>, IMarketPersistance {
		
		#region IPersistance
		
		public override Market Create()
		{
			return new SpecializedMemoryMarket ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Market> SelectById ( int id )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
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

		public IList<Market> SelectById ( int start, int count, int id )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Market> SelectByName ( string name )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
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

		public IList<Market> SelectByName ( int start, int count, string name )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Market> SelectByLevel ( int level )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
 				if( obj.Level == level ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLevel ( int level )
		{
			return (long) SelectByLevel ( level ).Count;
		}

		public IList<Market> SelectByLevel ( int start, int count, int level )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
 				if( obj.Level == level ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Market> SelectByCoordinates ( string coordinates )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
 				if( obj.Coordinates == coordinates ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCoordinates ( string coordinates )
		{
			return (long) SelectByCoordinates ( coordinates ).Count;
		}

		public IList<Market> SelectByCoordinates ( int start, int count, string coordinates )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
 				if( obj.Coordinates == coordinates ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Market> SelectBySector ( SectorStorage sector )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
 				if( obj.Sector == sector ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySector ( SectorStorage sector )
		{
			return (long) SelectBySector ( sector ).Count;
		}

		public IList<Market> SelectBySector ( int start, int count, SectorStorage sector )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
 				if( obj.Sector == sector ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Market> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
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

		public IList<Market> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Market> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
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

		public IList<Market> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Market> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
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

		public IList<Market> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Market> container = new List<Market>();
 			
			foreach( Market obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
