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
	internal class MemoryCountryPersistance : 
			MemoryPersistance<Country>, ICountryPersistance {
		
		#region IPersistance
		
		public override Country Create()
		{
			return new SpecializedMemoryCountry ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Country> SelectById ( int id )
		{
			List<Country> container = new List<Country>();
 			
			foreach( Country obj in Database.Values) {
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

		public IList<Country> SelectById ( int start, int count, int id )
		{
			List<Country> container = new List<Country>();
 			
			foreach( Country obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Country> SelectByName ( string name )
		{
			List<Country> container = new List<Country>();
 			
			foreach( Country obj in Database.Values) {
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

		public IList<Country> SelectByName ( int start, int count, string name )
		{
			List<Country> container = new List<Country>();
 			
			foreach( Country obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Country> SelectByAbbreviation ( string abbreviation )
		{
			List<Country> container = new List<Country>();
 			
			foreach( Country obj in Database.Values) {
 				if( obj.Abbreviation == abbreviation ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAbbreviation ( string abbreviation )
		{
			return (long) SelectByAbbreviation ( abbreviation ).Count;
		}

		public IList<Country> SelectByAbbreviation ( int start, int count, string abbreviation )
		{
			List<Country> container = new List<Country>();
 			
			foreach( Country obj in Database.Values) {
 				if( obj.Abbreviation == abbreviation ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Country> SelectByIsEU ( bool isEU )
		{
			List<Country> container = new List<Country>();
 			
			foreach( Country obj in Database.Values) {
 				if( obj.IsEU == isEU ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByIsEU ( bool isEU )
		{
			return (long) SelectByIsEU ( isEU ).Count;
		}

		public IList<Country> SelectByIsEU ( int start, int count, bool isEU )
		{
			List<Country> container = new List<Country>();
 			
			foreach( Country obj in Database.Values) {
 				if( obj.IsEU == isEU ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Country> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Country> container = new List<Country>();
 			
			foreach( Country obj in Database.Values) {
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

		public IList<Country> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Country> container = new List<Country>();
 			
			foreach( Country obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Country> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Country> container = new List<Country>();
 			
			foreach( Country obj in Database.Values) {
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

		public IList<Country> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Country> container = new List<Country>();
 			
			foreach( Country obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Country> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Country> container = new List<Country>();
 			
			foreach( Country obj in Database.Values) {
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

		public IList<Country> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Country> container = new List<Country>();
 			
			foreach( Country obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
