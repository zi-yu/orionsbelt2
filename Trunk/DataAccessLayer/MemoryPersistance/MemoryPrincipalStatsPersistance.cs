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
	internal class MemoryPrincipalStatsPersistance : 
			MemoryPersistance<PrincipalStats>, IPrincipalStatsPersistance {
		
		#region IPersistance
		
		public override PrincipalStats Create()
		{
			return new SpecializedMemoryPrincipalStats ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<PrincipalStats> SelectById ( int id )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
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

		public IList<PrincipalStats> SelectById ( int start, int count, int id )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalStats> SelectByMaxElo ( int maxElo )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
 				if( obj.MaxElo == maxElo ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMaxElo ( int maxElo )
		{
			return (long) SelectByMaxElo ( maxElo ).Count;
		}

		public IList<PrincipalStats> SelectByMaxElo ( int start, int count, int maxElo )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
 				if( obj.MaxElo == maxElo ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalStats> SelectByMinElo ( int minElo )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
 				if( obj.MinElo == minElo ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMinElo ( int minElo )
		{
			return (long) SelectByMinElo ( minElo ).Count;
		}

		public IList<PrincipalStats> SelectByMinElo ( int start, int count, int minElo )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
 				if( obj.MinElo == minElo ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalStats> SelectByNumberPlayedBattles ( int numberPlayedBattles )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
 				if( obj.NumberPlayedBattles == numberPlayedBattles ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByNumberPlayedBattles ( int numberPlayedBattles )
		{
			return (long) SelectByNumberPlayedBattles ( numberPlayedBattles ).Count;
		}

		public IList<PrincipalStats> SelectByNumberPlayedBattles ( int start, int count, int numberPlayedBattles )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
 				if( obj.NumberPlayedBattles == numberPlayedBattles ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalStats> SelectByMaxLadder ( int maxLadder )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
 				if( obj.MaxLadder == maxLadder ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMaxLadder ( int maxLadder )
		{
			return (long) SelectByMaxLadder ( maxLadder ).Count;
		}

		public IList<PrincipalStats> SelectByMaxLadder ( int start, int count, int maxLadder )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
 				if( obj.MaxLadder == maxLadder ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalStats> SelectByMinLadder ( int minLadder )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
 				if( obj.MinLadder == minLadder ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMinLadder ( int minLadder )
		{
			return (long) SelectByMinLadder ( minLadder ).Count;
		}

		public IList<PrincipalStats> SelectByMinLadder ( int start, int count, int minLadder )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
 				if( obj.MinLadder == minLadder ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalStats> SelectByCreatedDate ( DateTime createdDate )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
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

		public IList<PrincipalStats> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalStats> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
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

		public IList<PrincipalStats> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalStats> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
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

		public IList<PrincipalStats> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<PrincipalStats> container = new List<PrincipalStats>();
 			
			foreach( PrincipalStats obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
