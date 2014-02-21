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
	internal class MemoryFogOfWarStoragePersistance : 
			MemoryPersistance<FogOfWarStorage>, IFogOfWarStoragePersistance {
		
		#region IPersistance
		
		public override FogOfWarStorage Create()
		{
			return new SpecializedMemoryFogOfWarStorage ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<FogOfWarStorage> SelectById ( int id )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
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

		public IList<FogOfWarStorage> SelectById ( int start, int count, int id )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<FogOfWarStorage> SelectBySystemX ( int systemX )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.SystemX == systemX ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySystemX ( int systemX )
		{
			return (long) SelectBySystemX ( systemX ).Count;
		}

		public IList<FogOfWarStorage> SelectBySystemX ( int start, int count, int systemX )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.SystemX == systemX ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<FogOfWarStorage> SelectBySystemY ( int systemY )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.SystemY == systemY ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySystemY ( int systemY )
		{
			return (long) SelectBySystemY ( systemY ).Count;
		}

		public IList<FogOfWarStorage> SelectBySystemY ( int start, int count, int systemY )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.SystemY == systemY ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<FogOfWarStorage> SelectBySectors ( string sectors )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.Sectors == sectors ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySectors ( string sectors )
		{
			return (long) SelectBySectors ( sectors ).Count;
		}

		public IList<FogOfWarStorage> SelectBySectors ( int start, int count, string sectors )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.Sectors == sectors ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<FogOfWarStorage> SelectByHasDiscoveredAll ( bool hasDiscoveredAll )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.HasDiscoveredAll == hasDiscoveredAll ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByHasDiscoveredAll ( bool hasDiscoveredAll )
		{
			return (long) SelectByHasDiscoveredAll ( hasDiscoveredAll ).Count;
		}

		public IList<FogOfWarStorage> SelectByHasDiscoveredAll ( int start, int count, bool hasDiscoveredAll )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.HasDiscoveredAll == hasDiscoveredAll ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<FogOfWarStorage> SelectByHasDiscoveredHalf ( bool hasDiscoveredHalf )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.HasDiscoveredHalf == hasDiscoveredHalf ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByHasDiscoveredHalf ( bool hasDiscoveredHalf )
		{
			return (long) SelectByHasDiscoveredHalf ( hasDiscoveredHalf ).Count;
		}

		public IList<FogOfWarStorage> SelectByHasDiscoveredHalf ( int start, int count, bool hasDiscoveredHalf )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.HasDiscoveredHalf == hasDiscoveredHalf ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<FogOfWarStorage> SelectByOwner ( PlayerStorage owner )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.Owner == owner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByOwner ( PlayerStorage owner )
		{
			return (long) SelectByOwner ( owner ).Count;
		}

		public IList<FogOfWarStorage> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.Owner == owner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<FogOfWarStorage> SelectByCreatedDate ( DateTime createdDate )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
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

		public IList<FogOfWarStorage> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<FogOfWarStorage> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
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

		public IList<FogOfWarStorage> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<FogOfWarStorage> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
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

		public IList<FogOfWarStorage> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<FogOfWarStorage> container = new List<FogOfWarStorage>();
 			
			foreach( FogOfWarStorage obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
