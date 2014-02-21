using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using Institutional.Core;

namespace Institutional.DataAccessLayer {
	
	/// <summary>
    /// Memory persistance for entity.Name
    /// </summary>
	internal class MemoryMediaArticlePersistance : 
			MemoryPersistance<MediaArticle>, IMediaArticlePersistance {
		
		#region IPersistance
		
		public override MediaArticle Create()
		{
			return new SpecializedMemoryMediaArticle ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<MediaArticle> SelectById ( int id )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
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

		public IList<MediaArticle> SelectById ( int start, int count, int id )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<MediaArticle> SelectByUrl ( string url )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
 				if( obj.Url == url ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUrl ( string url )
		{
			return (long) SelectByUrl ( url ).Count;
		}

		public IList<MediaArticle> SelectByUrl ( int start, int count, string url )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
 				if( obj.Url == url ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<MediaArticle> SelectByName ( string name )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
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

		public IList<MediaArticle> SelectByName ( int start, int count, string name )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<MediaArticle> SelectByLocale ( string locale )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
 				if( obj.Locale == locale ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByLocale ( string locale )
		{
			return (long) SelectByLocale ( locale ).Count;
		}

		public IList<MediaArticle> SelectByLocale ( int start, int count, string locale )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
 				if( obj.Locale == locale ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<MediaArticle> SelectByExceprt ( string exceprt )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
 				if( obj.Exceprt == exceprt ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByExceprt ( string exceprt )
		{
			return (long) SelectByExceprt ( exceprt ).Count;
		}

		public IList<MediaArticle> SelectByExceprt ( int start, int count, string exceprt )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
 				if( obj.Exceprt == exceprt ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<MediaArticle> SelectByCreatedDate ( DateTime createdDate )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
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

		public IList<MediaArticle> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<MediaArticle> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
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

		public IList<MediaArticle> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<MediaArticle> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
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

		public IList<MediaArticle> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<MediaArticle> container = new List<MediaArticle>();
 			
			foreach( MediaArticle obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
