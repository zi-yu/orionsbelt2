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
	internal class MemoryQuestStoragePersistance : 
			MemoryPersistance<QuestStorage>, IQuestStoragePersistance {
		
		#region IPersistance
		
		public override QuestStorage Create()
		{
			return new SpecializedMemoryQuestStorage ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<QuestStorage> SelectById ( int id )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
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

		public IList<QuestStorage> SelectById ( int start, int count, int id )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByPercentage ( double percentage )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.Percentage == percentage ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPercentage ( double percentage )
		{
			return (long) SelectByPercentage ( percentage ).Count;
		}

		public IList<QuestStorage> SelectByPercentage ( int start, int count, double percentage )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.Percentage == percentage ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByIsTemplate ( bool isTemplate )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.IsTemplate == isTemplate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsTemplate ( bool isTemplate )
		{
			return (long) SelectByIsTemplate ( isTemplate ).Count;
		}

		public IList<QuestStorage> SelectByIsTemplate ( int start, int count, bool isTemplate )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.IsTemplate == isTemplate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByName ( string name )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
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

		public IList<QuestStorage> SelectByName ( int start, int count, string name )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByType ( string type )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
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

		public IList<QuestStorage> SelectByType ( int start, int count, string type )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByDeadlineTick ( int deadlineTick )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.DeadlineTick == deadlineTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByDeadlineTick ( int deadlineTick )
		{
			return (long) SelectByDeadlineTick ( deadlineTick ).Count;
		}

		public IList<QuestStorage> SelectByDeadlineTick ( int start, int count, int deadlineTick )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.DeadlineTick == deadlineTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByStartTick ( int startTick )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.StartTick == startTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByStartTick ( int startTick )
		{
			return (long) SelectByStartTick ( startTick ).Count;
		}

		public IList<QuestStorage> SelectByStartTick ( int start, int count, int startTick )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.StartTick == startTick ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByReward ( string reward )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.Reward == reward ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByReward ( string reward )
		{
			return (long) SelectByReward ( reward ).Count;
		}

		public IList<QuestStorage> SelectByReward ( int start, int count, string reward )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.Reward == reward ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByQuestStringConfig ( string questStringConfig )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.QuestStringConfig == questStringConfig ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByQuestStringConfig ( string questStringConfig )
		{
			return (long) SelectByQuestStringConfig ( questStringConfig ).Count;
		}

		public IList<QuestStorage> SelectByQuestStringConfig ( int start, int count, string questStringConfig )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.QuestStringConfig == questStringConfig ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByQuestIntConfig ( string questIntConfig )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.QuestIntConfig == questIntConfig ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByQuestIntConfig ( string questIntConfig )
		{
			return (long) SelectByQuestIntConfig ( questIntConfig ).Count;
		}

		public IList<QuestStorage> SelectByQuestIntConfig ( int start, int count, string questIntConfig )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.QuestIntConfig == questIntConfig ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByQuestIntProgress ( string questIntProgress )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.QuestIntProgress == questIntProgress ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByQuestIntProgress ( string questIntProgress )
		{
			return (long) SelectByQuestIntProgress ( questIntProgress ).Count;
		}

		public IList<QuestStorage> SelectByQuestIntProgress ( int start, int count, string questIntProgress )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.QuestIntProgress == questIntProgress ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByQuestStringProgress ( string questStringProgress )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.QuestStringProgress == questStringProgress ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByQuestStringProgress ( string questStringProgress )
		{
			return (long) SelectByQuestStringProgress ( questStringProgress ).Count;
		}

		public IList<QuestStorage> SelectByQuestStringProgress ( int start, int count, string questStringProgress )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.QuestStringProgress == questStringProgress ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByCompleted ( bool completed )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.Completed == completed ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCompleted ( bool completed )
		{
			return (long) SelectByCompleted ( completed ).Count;
		}

		public IList<QuestStorage> SelectByCompleted ( int start, int count, bool completed )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.Completed == completed ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByIsProgressive ( bool isProgressive )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.IsProgressive == isProgressive ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsProgressive ( bool isProgressive )
		{
			return (long) SelectByIsProgressive ( isProgressive ).Count;
		}

		public IList<QuestStorage> SelectByIsProgressive ( int start, int count, bool isProgressive )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.IsProgressive == isProgressive ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByPlayer ( PlayerStorage player )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
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

		public IList<QuestStorage> SelectByPlayer ( int start, int count, PlayerStorage player )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.Player == player ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByCreatedDate ( DateTime createdDate )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
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

		public IList<QuestStorage> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
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

		public IList<QuestStorage> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<QuestStorage> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
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

		public IList<QuestStorage> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<QuestStorage> container = new List<QuestStorage>();
 			
			foreach( QuestStorage obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
