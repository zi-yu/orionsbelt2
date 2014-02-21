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
	internal class MemoryServerPropertiesPersistance : 
			MemoryPersistance<ServerProperties>, IServerPropertiesPersistance {
		
		#region IPersistance
		
		public override ServerProperties Create()
		{
			return new SpecializedMemoryServerProperties ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<ServerProperties> SelectById ( int id )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
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

		public IList<ServerProperties> SelectById ( int start, int count, int id )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ServerProperties> SelectByCurrentTick ( int currentTick )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.CurrentTick == currentTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCurrentTick ( int currentTick )
		{
			return (long) SelectByCurrentTick ( currentTick ).Count;
		}

		public IList<ServerProperties> SelectByCurrentTick ( int start, int count, int currentTick )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.CurrentTick == currentTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ServerProperties> SelectByLastTickDate ( DateTime lastTickDate )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.LastTickDate == lastTickDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLastTickDate ( DateTime lastTickDate )
		{
			return (long) SelectByLastTickDate ( lastTickDate ).Count;
		}

		public IList<ServerProperties> SelectByLastTickDate ( int start, int count, DateTime lastTickDate )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.LastTickDate == lastTickDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ServerProperties> SelectByRunning ( bool running )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.Running == running ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRunning ( bool running )
		{
			return (long) SelectByRunning ( running ).Count;
		}

		public IList<ServerProperties> SelectByRunning ( int start, int count, bool running )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.Running == running ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ServerProperties> SelectByMillisPerTick ( int millisPerTick )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.MillisPerTick == millisPerTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMillisPerTick ( int millisPerTick )
		{
			return (long) SelectByMillisPerTick ( millisPerTick ).Count;
		}

		public IList<ServerProperties> SelectByMillisPerTick ( int start, int count, int millisPerTick )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.MillisPerTick == millisPerTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ServerProperties> SelectByUseWebClock ( bool useWebClock )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.UseWebClock == useWebClock ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUseWebClock ( bool useWebClock )
		{
			return (long) SelectByUseWebClock ( useWebClock ).Count;
		}

		public IList<ServerProperties> SelectByUseWebClock ( int start, int count, bool useWebClock )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.UseWebClock == useWebClock ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ServerProperties> SelectByMaxPlayers ( int maxPlayers )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.MaxPlayers == maxPlayers ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMaxPlayers ( int maxPlayers )
		{
			return (long) SelectByMaxPlayers ( maxPlayers ).Count;
		}

		public IList<ServerProperties> SelectByMaxPlayers ( int start, int count, int maxPlayers )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.MaxPlayers == maxPlayers ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ServerProperties> SelectByVacationTicksPerWeek ( int vacationTicksPerWeek )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.VacationTicksPerWeek == vacationTicksPerWeek ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByVacationTicksPerWeek ( int vacationTicksPerWeek )
		{
			return (long) SelectByVacationTicksPerWeek ( vacationTicksPerWeek ).Count;
		}

		public IList<ServerProperties> SelectByVacationTicksPerWeek ( int start, int count, int vacationTicksPerWeek )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.VacationTicksPerWeek == vacationTicksPerWeek ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ServerProperties> SelectByName ( string name )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
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

		public IList<ServerProperties> SelectByName ( int start, int count, string name )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ServerProperties> SelectByBaseUrl ( string baseUrl )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.BaseUrl == baseUrl ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByBaseUrl ( string baseUrl )
		{
			return (long) SelectByBaseUrl ( baseUrl ).Count;
		}

		public IList<ServerProperties> SelectByBaseUrl ( int start, int count, string baseUrl )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.BaseUrl == baseUrl ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ServerProperties> SelectByCreatedDate ( DateTime createdDate )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
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

		public IList<ServerProperties> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ServerProperties> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
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

		public IList<ServerProperties> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ServerProperties> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
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

		public IList<ServerProperties> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<ServerProperties> container = new List<ServerProperties>();
 			
			foreach( ServerProperties obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
