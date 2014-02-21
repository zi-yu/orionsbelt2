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
	internal class MemoryAllianceDiplomacyPersistance : 
			MemoryPersistance<AllianceDiplomacy>, IAllianceDiplomacyPersistance {
		
		#region IPersistance
		
		public override AllianceDiplomacy Create()
		{
			return new SpecializedMemoryAllianceDiplomacy ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<AllianceDiplomacy> SelectById ( int id )
		{
			List<AllianceDiplomacy> container = new List<AllianceDiplomacy>();
 			
			foreach( AllianceDiplomacy obj in Database.Values) {
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

		public IList<AllianceDiplomacy> SelectById ( int start, int count, int id )
		{
			List<AllianceDiplomacy> container = new List<AllianceDiplomacy>();
 			
			foreach( AllianceDiplomacy obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceDiplomacy> SelectByLevel ( string level )
		{
			List<AllianceDiplomacy> container = new List<AllianceDiplomacy>();
 			
			foreach( AllianceDiplomacy obj in Database.Values) {
 				if( obj.Level == level ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLevel ( string level )
		{
			return (long) SelectByLevel ( level ).Count;
		}

		public IList<AllianceDiplomacy> SelectByLevel ( int start, int count, string level )
		{
			List<AllianceDiplomacy> container = new List<AllianceDiplomacy>();
 			
			foreach( AllianceDiplomacy obj in Database.Values) {
 				if( obj.Level == level ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceDiplomacy> SelectByAllianceA ( AllianceStorage allianceA )
		{
			List<AllianceDiplomacy> container = new List<AllianceDiplomacy>();
 			
			foreach( AllianceDiplomacy obj in Database.Values) {
 				if( obj.AllianceA == allianceA ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAllianceA ( AllianceStorage allianceA )
		{
			return (long) SelectByAllianceA ( allianceA ).Count;
		}

		public IList<AllianceDiplomacy> SelectByAllianceA ( int start, int count, AllianceStorage allianceA )
		{
			List<AllianceDiplomacy> container = new List<AllianceDiplomacy>();
 			
			foreach( AllianceDiplomacy obj in Database.Values) {
 				if( obj.AllianceA == allianceA ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceDiplomacy> SelectByAllianceB ( AllianceStorage allianceB )
		{
			List<AllianceDiplomacy> container = new List<AllianceDiplomacy>();
 			
			foreach( AllianceDiplomacy obj in Database.Values) {
 				if( obj.AllianceB == allianceB ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAllianceB ( AllianceStorage allianceB )
		{
			return (long) SelectByAllianceB ( allianceB ).Count;
		}

		public IList<AllianceDiplomacy> SelectByAllianceB ( int start, int count, AllianceStorage allianceB )
		{
			List<AllianceDiplomacy> container = new List<AllianceDiplomacy>();
 			
			foreach( AllianceDiplomacy obj in Database.Values) {
 				if( obj.AllianceB == allianceB ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceDiplomacy> SelectByCreatedDate ( DateTime createdDate )
		{
			List<AllianceDiplomacy> container = new List<AllianceDiplomacy>();
 			
			foreach( AllianceDiplomacy obj in Database.Values) {
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

		public IList<AllianceDiplomacy> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<AllianceDiplomacy> container = new List<AllianceDiplomacy>();
 			
			foreach( AllianceDiplomacy obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceDiplomacy> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<AllianceDiplomacy> container = new List<AllianceDiplomacy>();
 			
			foreach( AllianceDiplomacy obj in Database.Values) {
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

		public IList<AllianceDiplomacy> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<AllianceDiplomacy> container = new List<AllianceDiplomacy>();
 			
			foreach( AllianceDiplomacy obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<AllianceDiplomacy> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<AllianceDiplomacy> container = new List<AllianceDiplomacy>();
 			
			foreach( AllianceDiplomacy obj in Database.Values) {
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

		public IList<AllianceDiplomacy> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<AllianceDiplomacy> container = new List<AllianceDiplomacy>();
 			
			foreach( AllianceDiplomacy obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
