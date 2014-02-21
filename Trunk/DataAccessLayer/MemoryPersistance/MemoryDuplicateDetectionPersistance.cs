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
	internal class MemoryDuplicateDetectionPersistance : 
			MemoryPersistance<DuplicateDetection>, IDuplicateDetectionPersistance {
		
		#region IPersistance
		
		public override DuplicateDetection Create()
		{
			return new SpecializedMemoryDuplicateDetection ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<DuplicateDetection> SelectById ( int id )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
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

		public IList<DuplicateDetection> SelectById ( int start, int count, int id )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<DuplicateDetection> SelectByCheater ( int cheater )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
 				if( obj.Cheater == cheater ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCheater ( int cheater )
		{
			return (long) SelectByCheater ( cheater ).Count;
		}

		public IList<DuplicateDetection> SelectByCheater ( int start, int count, int cheater )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
 				if( obj.Cheater == cheater ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<DuplicateDetection> SelectByDuplicate ( int duplicate )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
 				if( obj.Duplicate == duplicate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByDuplicate ( int duplicate )
		{
			return (long) SelectByDuplicate ( duplicate ).Count;
		}

		public IList<DuplicateDetection> SelectByDuplicate ( int start, int count, int duplicate )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
 				if( obj.Duplicate == duplicate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<DuplicateDetection> SelectByFindType ( string findType )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
 				if( obj.FindType == findType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByFindType ( string findType )
		{
			return (long) SelectByFindType ( findType ).Count;
		}

		public IList<DuplicateDetection> SelectByFindType ( int start, int count, string findType )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
 				if( obj.FindType == findType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<DuplicateDetection> SelectByExtraInfo ( string extraInfo )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
 				if( obj.ExtraInfo == extraInfo ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByExtraInfo ( string extraInfo )
		{
			return (long) SelectByExtraInfo ( extraInfo ).Count;
		}

		public IList<DuplicateDetection> SelectByExtraInfo ( int start, int count, string extraInfo )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
 				if( obj.ExtraInfo == extraInfo ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<DuplicateDetection> SelectByVerified ( bool verified )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
 				if( obj.Verified == verified ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByVerified ( bool verified )
		{
			return (long) SelectByVerified ( verified ).Count;
		}

		public IList<DuplicateDetection> SelectByVerified ( int start, int count, bool verified )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
 				if( obj.Verified == verified ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<DuplicateDetection> SelectByCreatedDate ( DateTime createdDate )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
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

		public IList<DuplicateDetection> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<DuplicateDetection> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
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

		public IList<DuplicateDetection> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<DuplicateDetection> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
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

		public IList<DuplicateDetection> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<DuplicateDetection> container = new List<DuplicateDetection>();
 			
			foreach( DuplicateDetection obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
