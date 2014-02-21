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
	internal class MemoryAssetPersistance : 
			MemoryPersistance<Asset>, IAssetPersistance {
		
		#region IPersistance
		
		public override Asset Create()
		{
			return new SpecializedMemoryAsset ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Asset> SelectById ( int id )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
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

		public IList<Asset> SelectById ( int start, int count, int id )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Asset> SelectByType ( string type )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
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

		public IList<Asset> SelectByType ( int start, int count, string type )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Asset> SelectByDescription ( string description )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
 				if( obj.Description == description ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByDescription ( string description )
		{
			return (long) SelectByDescription ( description ).Count;
		}

		public IList<Asset> SelectByDescription ( int start, int count, string description )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
 				if( obj.Description == description ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Asset> SelectByCoordinate ( string coordinate )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
 				if( obj.Coordinate == coordinate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCoordinate ( string coordinate )
		{
			return (long) SelectByCoordinate ( coordinate ).Count;
		}

		public IList<Asset> SelectByCoordinate ( int start, int count, string coordinate )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
 				if( obj.Coordinate == coordinate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Asset> SelectByOwner ( PlayerStorage owner )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
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

		public IList<Asset> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
 				if( obj.Owner == owner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Asset> SelectByTask ( Task task )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
 				if( obj.Task == task ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTask ( Task task )
		{
			return (long) SelectByTask ( task ).Count;
		}

		public IList<Asset> SelectByTask ( int start, int count, Task task )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
 				if( obj.Task == task ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Asset> SelectByAlliance ( AllianceStorage alliance )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
 				if( obj.Alliance == alliance ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAlliance ( AllianceStorage alliance )
		{
			return (long) SelectByAlliance ( alliance ).Count;
		}

		public IList<Asset> SelectByAlliance ( int start, int count, AllianceStorage alliance )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
 				if( obj.Alliance == alliance ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Asset> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
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

		public IList<Asset> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Asset> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
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

		public IList<Asset> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Asset> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
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

		public IList<Asset> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Asset> container = new List<Asset>();
 			
			foreach( Asset obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
