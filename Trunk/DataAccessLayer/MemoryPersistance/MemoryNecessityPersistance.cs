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
	internal class MemoryNecessityPersistance : 
			MemoryPersistance<Necessity>, INecessityPersistance {
		
		#region IPersistance
		
		public override Necessity Create()
		{
			return new SpecializedMemoryNecessity ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Necessity> SelectById ( int id )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
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

		public IList<Necessity> SelectById ( int start, int count, int id )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Necessity> SelectByType ( string type )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
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

		public IList<Necessity> SelectByType ( int start, int count, string type )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Necessity> SelectByDescription ( string description )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
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

		public IList<Necessity> SelectByDescription ( int start, int count, string description )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
 				if( obj.Description == description ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Necessity> SelectByCoordinate ( string coordinate )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
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

		public IList<Necessity> SelectByCoordinate ( int start, int count, string coordinate )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
 				if( obj.Coordinate == coordinate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Necessity> SelectByStatus ( string status )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
 				if( obj.Status == status ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByStatus ( string status )
		{
			return (long) SelectByStatus ( status ).Count;
		}

		public IList<Necessity> SelectByStatus ( int start, int count, string status )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
 				if( obj.Status == status ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Necessity> SelectByCreator ( PlayerStorage creator )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
 				if( obj.Creator == creator ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCreator ( PlayerStorage creator )
		{
			return (long) SelectByCreator ( creator ).Count;
		}

		public IList<Necessity> SelectByCreator ( int start, int count, PlayerStorage creator )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
 				if( obj.Creator == creator ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Necessity> SelectByAlliance ( AllianceStorage alliance )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
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

		public IList<Necessity> SelectByAlliance ( int start, int count, AllianceStorage alliance )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
 				if( obj.Alliance == alliance ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Necessity> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
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

		public IList<Necessity> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Necessity> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
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

		public IList<Necessity> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Necessity> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
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

		public IList<Necessity> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Necessity> container = new List<Necessity>();
 			
			foreach( Necessity obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
