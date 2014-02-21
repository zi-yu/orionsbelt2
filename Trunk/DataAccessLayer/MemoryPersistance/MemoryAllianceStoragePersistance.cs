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
	internal class MemoryAllianceStoragePersistance : 
			MemoryPersistance<AllianceStorage>, IAllianceStoragePersistance {
		
		#region IPersistance
		
		public override AllianceStorage Create()
		{
			return new SpecializedMemoryAllianceStorage ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<AllianceStorage> SelectById ( int id )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
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

		public IList<AllianceStorage> SelectById ( int start, int count, int id )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceStorage> SelectByScore ( int score )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
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

		public IList<AllianceStorage> SelectByScore ( int start, int count, int score )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.Score == score ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceStorage> SelectByKarma ( double karma )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.Karma == karma ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByKarma ( double karma )
		{
			return (long) SelectByKarma ( karma ).Count;
		}

		public IList<AllianceStorage> SelectByKarma ( int start, int count, double karma )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.Karma == karma ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceStorage> SelectByTotalMembers ( int totalMembers )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.TotalMembers == totalMembers ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTotalMembers ( int totalMembers )
		{
			return (long) SelectByTotalMembers ( totalMembers ).Count;
		}

		public IList<AllianceStorage> SelectByTotalMembers ( int start, int count, int totalMembers )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.TotalMembers == totalMembers ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceStorage> SelectByName ( string name )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
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

		public IList<AllianceStorage> SelectByName ( int start, int count, string name )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceStorage> SelectByTag ( string tag )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.Tag == tag ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTag ( string tag )
		{
			return (long) SelectByTag ( tag ).Count;
		}

		public IList<AllianceStorage> SelectByTag ( int start, int count, string tag )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.Tag == tag ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceStorage> SelectByDescription ( string description )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
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

		public IList<AllianceStorage> SelectByDescription ( int start, int count, string description )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.Description == description ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceStorage> SelectByLanguage ( string language )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.Language == language ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLanguage ( string language )
		{
			return (long) SelectByLanguage ( language ).Count;
		}

		public IList<AllianceStorage> SelectByLanguage ( int start, int count, string language )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.Language == language ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceStorage> SelectByOrions ( int orions )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.Orions == orions ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByOrions ( int orions )
		{
			return (long) SelectByOrions ( orions ).Count;
		}

		public IList<AllianceStorage> SelectByOrions ( int start, int count, int orions )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.Orions == orions ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceStorage> SelectByOpenToNewMembers ( bool openToNewMembers )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.OpenToNewMembers == openToNewMembers ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByOpenToNewMembers ( bool openToNewMembers )
		{
			return (long) SelectByOpenToNewMembers ( openToNewMembers ).Count;
		}

		public IList<AllianceStorage> SelectByOpenToNewMembers ( int start, int count, bool openToNewMembers )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.OpenToNewMembers == openToNewMembers ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceStorage> SelectByTotalRelics ( int totalRelics )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.TotalRelics == totalRelics ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTotalRelics ( int totalRelics )
		{
			return (long) SelectByTotalRelics ( totalRelics ).Count;
		}

		public IList<AllianceStorage> SelectByTotalRelics ( int start, int count, int totalRelics )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.TotalRelics == totalRelics ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceStorage> SelectByTotalRelicsIncome ( int totalRelicsIncome )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.TotalRelicsIncome == totalRelicsIncome ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTotalRelicsIncome ( int totalRelicsIncome )
		{
			return (long) SelectByTotalRelicsIncome ( totalRelicsIncome ).Count;
		}

		public IList<AllianceStorage> SelectByTotalRelicsIncome ( int start, int count, int totalRelicsIncome )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.TotalRelicsIncome == totalRelicsIncome ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceStorage> SelectByCreatedDate ( DateTime createdDate )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
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

		public IList<AllianceStorage> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceStorage> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
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

		public IList<AllianceStorage> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceStorage> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
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

		public IList<AllianceStorage> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<AllianceStorage> container = new List<AllianceStorage>();
 			
			foreach( AllianceStorage obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
