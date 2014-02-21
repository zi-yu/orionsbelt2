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
	internal class MemorySectorStoragePersistance : 
			MemoryPersistance<SectorStorage>, ISectorStoragePersistance {
		
		#region IPersistance
		
		public override SectorStorage Create()
		{
			return new SpecializedMemorySectorStorage ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<SectorStorage> SelectById ( int id )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
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

		public IList<SectorStorage> SelectById ( int start, int count, int id )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectByIsStatic ( bool isStatic )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.IsStatic == isStatic ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsStatic ( bool isStatic )
		{
			return (long) SelectByIsStatic ( isStatic ).Count;
		}

		public IList<SectorStorage> SelectByIsStatic ( int start, int count, bool isStatic )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.IsStatic == isStatic ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectByType ( string type )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
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

		public IList<SectorStorage> SelectByType ( int start, int count, string type )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectBySubType ( string subType )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.SubType == subType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySubType ( string subType )
		{
			return (long) SelectBySubType ( subType ).Count;
		}

		public IList<SectorStorage> SelectBySubType ( int start, int count, string subType )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.SubType == subType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectBySystemX ( int systemX )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
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

		public IList<SectorStorage> SelectBySystemX ( int start, int count, int systemX )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.SystemX == systemX ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectBySystemY ( int systemY )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
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

		public IList<SectorStorage> SelectBySystemY ( int start, int count, int systemY )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.SystemY == systemY ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectBySectorX ( int sectorX )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.SectorX == sectorX ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySectorX ( int sectorX )
		{
			return (long) SelectBySectorX ( sectorX ).Count;
		}

		public IList<SectorStorage> SelectBySectorX ( int start, int count, int sectorX )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.SectorX == sectorX ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectBySectorY ( int sectorY )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.SectorY == sectorY ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySectorY ( int sectorY )
		{
			return (long) SelectBySectorY ( sectorY ).Count;
		}

		public IList<SectorStorage> SelectBySectorY ( int start, int count, int sectorY )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.SectorY == sectorY ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectByAdditionalInformation ( string additionalInformation )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.AdditionalInformation == additionalInformation ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAdditionalInformation ( string additionalInformation )
		{
			return (long) SelectByAdditionalInformation ( additionalInformation ).Count;
		}

		public IList<SectorStorage> SelectByAdditionalInformation ( int start, int count, string additionalInformation )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.AdditionalInformation == additionalInformation ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectByIsInBattle ( bool isInBattle )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.IsInBattle == isInBattle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsInBattle ( bool isInBattle )
		{
			return (long) SelectByIsInBattle ( isInBattle ).Count;
		}

		public IList<SectorStorage> SelectByIsInBattle ( int start, int count, bool isInBattle )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.IsInBattle == isInBattle ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectByIsConstructing ( bool isConstructing )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.IsConstructing == isConstructing ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsConstructing ( bool isConstructing )
		{
			return (long) SelectByIsConstructing ( isConstructing ).Count;
		}

		public IList<SectorStorage> SelectByIsConstructing ( int start, int count, bool isConstructing )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.IsConstructing == isConstructing ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectByLevel ( int level )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
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

		public IList<SectorStorage> SelectByLevel ( int start, int count, int level )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.Level == level ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectByIsMoving ( bool isMoving )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.IsMoving == isMoving ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsMoving ( bool isMoving )
		{
			return (long) SelectByIsMoving ( isMoving ).Count;
		}

		public IList<SectorStorage> SelectByIsMoving ( int start, int count, bool isMoving )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.IsMoving == isMoving ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectByOwner ( PlayerStorage owner )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
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

		public IList<SectorStorage> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.Owner == owner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectByAlliance ( AllianceStorage alliance )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
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

		public IList<SectorStorage> SelectByAlliance ( int start, int count, AllianceStorage alliance )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.Alliance == alliance ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectByCreatedDate ( DateTime createdDate )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
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

		public IList<SectorStorage> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
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

		public IList<SectorStorage> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<SectorStorage> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
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

		public IList<SectorStorage> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<SectorStorage> container = new List<SectorStorage>();
 			
			foreach( SectorStorage obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
