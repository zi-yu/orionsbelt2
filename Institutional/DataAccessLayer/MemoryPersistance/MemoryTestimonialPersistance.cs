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
	internal class MemoryTestimonialPersistance : 
			MemoryPersistance<Testimonial>, ITestimonialPersistance {
		
		#region IPersistance
		
		public override Testimonial Create()
		{
			return new SpecializedMemoryTestimonial ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Testimonial> SelectById ( int id )
		{
			List<Testimonial> container = new List<Testimonial>();
 			
			foreach( Testimonial obj in Database.Values) {
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

		public IList<Testimonial> SelectById ( int start, int count, int id )
		{
			List<Testimonial> container = new List<Testimonial>();
 			
			foreach( Testimonial obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Testimonial> SelectByLocale ( string locale )
		{
			List<Testimonial> container = new List<Testimonial>();
 			
			foreach( Testimonial obj in Database.Values) {
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

		public IList<Testimonial> SelectByLocale ( int start, int count, string locale )
		{
			List<Testimonial> container = new List<Testimonial>();
 			
			foreach( Testimonial obj in Database.Values) {
 				if( obj.Locale == locale ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Testimonial> SelectByContent ( string content )
		{
			List<Testimonial> container = new List<Testimonial>();
 			
			foreach( Testimonial obj in Database.Values) {
 				if( obj.Content == content ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByContent ( string content )
		{
			return (long) SelectByContent ( content ).Count;
		}

		public IList<Testimonial> SelectByContent ( int start, int count, string content )
		{
			List<Testimonial> container = new List<Testimonial>();
 			
			foreach( Testimonial obj in Database.Values) {
 				if( obj.Content == content ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Testimonial> SelectByAuthor ( string author )
		{
			List<Testimonial> container = new List<Testimonial>();
 			
			foreach( Testimonial obj in Database.Values) {
 				if( obj.Author == author ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAuthor ( string author )
		{
			return (long) SelectByAuthor ( author ).Count;
		}

		public IList<Testimonial> SelectByAuthor ( int start, int count, string author )
		{
			List<Testimonial> container = new List<Testimonial>();
 			
			foreach( Testimonial obj in Database.Values) {
 				if( obj.Author == author ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Testimonial> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Testimonial> container = new List<Testimonial>();
 			
			foreach( Testimonial obj in Database.Values) {
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

		public IList<Testimonial> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Testimonial> container = new List<Testimonial>();
 			
			foreach( Testimonial obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Testimonial> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Testimonial> container = new List<Testimonial>();
 			
			foreach( Testimonial obj in Database.Values) {
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

		public IList<Testimonial> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Testimonial> container = new List<Testimonial>();
 			
			foreach( Testimonial obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Testimonial> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Testimonial> container = new List<Testimonial>();
 			
			foreach( Testimonial obj in Database.Values) {
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

		public IList<Testimonial> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Testimonial> container = new List<Testimonial>();
 			
			foreach( Testimonial obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
