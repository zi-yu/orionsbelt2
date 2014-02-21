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
	internal class MemoryGroupPointsStoragePersistance : 
			MemoryPersistance<GroupPointsStorage>, IGroupPointsStoragePersistance {
		
		#region IPersistance
		
		public override GroupPointsStorage Create()
		{
			return new SpecializedMemoryGroupPointsStorage ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<GroupPointsStorage> SelectById ( int id )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
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

		public IList<GroupPointsStorage> SelectById ( int start, int count, int id )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<GroupPointsStorage> SelectByStage ( int stage )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
 				if( obj.Stage == stage ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByStage ( int stage )
		{
			return (long) SelectByStage ( stage ).Count;
		}

		public IList<GroupPointsStorage> SelectByStage ( int start, int count, int stage )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
 				if( obj.Stage == stage ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<GroupPointsStorage> SelectByPontuation ( int pontuation )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
 				if( obj.Pontuation == pontuation ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPontuation ( int pontuation )
		{
			return (long) SelectByPontuation ( pontuation ).Count;
		}

		public IList<GroupPointsStorage> SelectByPontuation ( int start, int count, int pontuation )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
 				if( obj.Pontuation == pontuation ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<GroupPointsStorage> SelectByWins ( int wins )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
 				if( obj.Wins == wins ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByWins ( int wins )
		{
			return (long) SelectByWins ( wins ).Count;
		}

		public IList<GroupPointsStorage> SelectByWins ( int start, int count, int wins )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
 				if( obj.Wins == wins ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<GroupPointsStorage> SelectByLosses ( int losses )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
 				if( obj.Losses == losses ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLosses ( int losses )
		{
			return (long) SelectByLosses ( losses ).Count;
		}

		public IList<GroupPointsStorage> SelectByLosses ( int start, int count, int losses )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
 				if( obj.Losses == losses ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<GroupPointsStorage> SelectByRegist ( PrincipalTournament regist )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
 				if( obj.Regist == regist ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByRegist ( PrincipalTournament regist )
		{
			return (long) SelectByRegist ( regist ).Count;
		}

		public IList<GroupPointsStorage> SelectByRegist ( int start, int count, PrincipalTournament regist )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
 				if( obj.Regist == regist ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<GroupPointsStorage> SelectByCreatedDate ( DateTime createdDate )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
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

		public IList<GroupPointsStorage> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<GroupPointsStorage> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
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

		public IList<GroupPointsStorage> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<GroupPointsStorage> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
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

		public IList<GroupPointsStorage> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<GroupPointsStorage> container = new List<GroupPointsStorage>();
 			
			foreach( GroupPointsStorage obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
