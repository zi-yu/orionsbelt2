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
	internal class MemoryPlanetStoragePersistance : 
			MemoryPersistance<PlanetStorage>, IPlanetStoragePersistance {
		
		#region IPersistance
		
		public override PlanetStorage Create()
		{
			return new SpecializedMemoryPlanetStorage ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<PlanetStorage> SelectById ( int id )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
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

		public IList<PlanetStorage> SelectById ( int start, int count, int id )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByName ( string name )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
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

		public IList<PlanetStorage> SelectByName ( int start, int count, string name )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByProductionFactor ( double productionFactor )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.ProductionFactor == productionFactor ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByProductionFactor ( double productionFactor )
		{
			return (long) SelectByProductionFactor ( productionFactor ).Count;
		}

		public IList<PlanetStorage> SelectByProductionFactor ( int start, int count, double productionFactor )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.ProductionFactor == productionFactor ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByModifiers ( string modifiers )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Modifiers == modifiers ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByModifiers ( string modifiers )
		{
			return (long) SelectByModifiers ( modifiers ).Count;
		}

		public IList<PlanetStorage> SelectByModifiers ( int start, int count, string modifiers )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Modifiers == modifiers ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByRichness ( string richness )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Richness == richness ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRichness ( string richness )
		{
			return (long) SelectByRichness ( richness ).Count;
		}

		public IList<PlanetStorage> SelectByRichness ( int start, int count, string richness )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Richness == richness ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByInfo ( string info )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Info == info ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByInfo ( string info )
		{
			return (long) SelectByInfo ( info ).Count;
		}

		public IList<PlanetStorage> SelectByInfo ( int start, int count, string info )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Info == info ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByTerrain ( string terrain )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Terrain == terrain ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTerrain ( string terrain )
		{
			return (long) SelectByTerrain ( terrain ).Count;
		}

		public IList<PlanetStorage> SelectByTerrain ( int start, int count, string terrain )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Terrain == terrain ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByIsPrivate ( bool isPrivate )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.IsPrivate == isPrivate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsPrivate ( bool isPrivate )
		{
			return (long) SelectByIsPrivate ( isPrivate ).Count;
		}

		public IList<PlanetStorage> SelectByIsPrivate ( int start, int count, bool isPrivate )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.IsPrivate == isPrivate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectBySystemX ( int systemX )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
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

		public IList<PlanetStorage> SelectBySystemX ( int start, int count, int systemX )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.SystemX == systemX ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectBySystemY ( int systemY )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
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

		public IList<PlanetStorage> SelectBySystemY ( int start, int count, int systemY )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.SystemY == systemY ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectBySectorX ( int sectorX )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
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

		public IList<PlanetStorage> SelectBySectorX ( int start, int count, int sectorX )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.SectorX == sectorX ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectBySectorY ( int sectorY )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
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

		public IList<PlanetStorage> SelectBySectorY ( int start, int count, int sectorY )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.SectorY == sectorY ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByScore ( int score )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Score == score ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByScore ( int score )
		{
			return (long) SelectByScore ( score ).Count;
		}

		public IList<PlanetStorage> SelectByScore ( int start, int count, int score )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Score == score ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByLevel ( int level )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
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

		public IList<PlanetStorage> SelectByLevel ( int start, int count, int level )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Level == level ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByLastPillageTick ( int lastPillageTick )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.LastPillageTick == lastPillageTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLastPillageTick ( int lastPillageTick )
		{
			return (long) SelectByLastPillageTick ( lastPillageTick ).Count;
		}

		public IList<PlanetStorage> SelectByLastPillageTick ( int start, int count, int lastPillageTick )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.LastPillageTick == lastPillageTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByLastConquerTick ( int lastConquerTick )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.LastConquerTick == lastConquerTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLastConquerTick ( int lastConquerTick )
		{
			return (long) SelectByLastConquerTick ( lastConquerTick ).Count;
		}

		public IList<PlanetStorage> SelectByLastConquerTick ( int start, int count, int lastConquerTick )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.LastConquerTick == lastConquerTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByFacilityLevel ( int facilityLevel )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.FacilityLevel == facilityLevel ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByFacilityLevel ( int facilityLevel )
		{
			return (long) SelectByFacilityLevel ( facilityLevel ).Count;
		}

		public IList<PlanetStorage> SelectByFacilityLevel ( int start, int count, int facilityLevel )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.FacilityLevel == facilityLevel ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByPlayer ( PlayerStorage player )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Player == player ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPlayer ( PlayerStorage player )
		{
			return (long) SelectByPlayer ( player ).Count;
		}

		public IList<PlanetStorage> SelectByPlayer ( int start, int count, PlayerStorage player )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Player == player ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectBySector ( SectorStorage sector )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
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

		public IList<PlanetStorage> SelectBySector ( int start, int count, SectorStorage sector )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.Sector == sector ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByCreatedDate ( DateTime createdDate )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
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

		public IList<PlanetStorage> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
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

		public IList<PlanetStorage> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlanetStorage> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
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

		public IList<PlanetStorage> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<PlanetStorage> container = new List<PlanetStorage>();
 			
			foreach( PlanetStorage obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
