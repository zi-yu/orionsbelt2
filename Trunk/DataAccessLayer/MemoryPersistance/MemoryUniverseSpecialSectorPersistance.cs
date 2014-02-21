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
	internal class MemoryUniverseSpecialSectorPersistance : 
			MemoryPersistance<UniverseSpecialSector>, IUniverseSpecialSectorPersistance {
		
		#region IPersistance
		
		public override UniverseSpecialSector Create()
		{
			return new SpecializedMemoryUniverseSpecialSector ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<UniverseSpecialSector> SelectById ( int id )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
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

		public IList<UniverseSpecialSector> SelectById ( int start, int count, int id )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<UniverseSpecialSector> SelectBySystemX ( int systemX )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
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

		public IList<UniverseSpecialSector> SelectBySystemX ( int start, int count, int systemX )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
 				if( obj.SystemX == systemX ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<UniverseSpecialSector> SelectBySystemY ( int systemY )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
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

		public IList<UniverseSpecialSector> SelectBySystemY ( int start, int count, int systemY )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
 				if( obj.SystemY == systemY ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<UniverseSpecialSector> SelectBySectorX ( int sectorX )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
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

		public IList<UniverseSpecialSector> SelectBySectorX ( int start, int count, int sectorX )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
 				if( obj.SectorX == sectorX ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<UniverseSpecialSector> SelectBySectorY ( int sectorY )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
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

		public IList<UniverseSpecialSector> SelectBySectorY ( int start, int count, int sectorY )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
 				if( obj.SectorY == sectorY ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<UniverseSpecialSector> SelectByType ( string type )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
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

		public IList<UniverseSpecialSector> SelectByType ( int start, int count, string type )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<UniverseSpecialSector> SelectByOwner ( PlayerStorage owner )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
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

		public IList<UniverseSpecialSector> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
 				if( obj.Owner == owner ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<UniverseSpecialSector> SelectBySector ( SectorStorage sector )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
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

		public IList<UniverseSpecialSector> SelectBySector ( int start, int count, SectorStorage sector )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
 				if( obj.Sector == sector ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<UniverseSpecialSector> SelectByCreatedDate ( DateTime createdDate )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
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

		public IList<UniverseSpecialSector> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<UniverseSpecialSector> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
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

		public IList<UniverseSpecialSector> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<UniverseSpecialSector> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
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

		public IList<UniverseSpecialSector> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<UniverseSpecialSector> container = new List<UniverseSpecialSector>();
 			
			foreach( UniverseSpecialSector obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
