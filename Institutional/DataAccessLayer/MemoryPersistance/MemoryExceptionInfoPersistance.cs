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
	internal class MemoryExceptionInfoPersistance : 
			MemoryPersistance<ExceptionInfo>, IExceptionInfoPersistance {
		
		#region IPersistance
		
		public override ExceptionInfo Create()
		{
			return new SpecializedMemoryExceptionInfo ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<ExceptionInfo> SelectById ( int id )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
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

		public IList<ExceptionInfo> SelectById ( int start, int count, int id )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ExceptionInfo> SelectByName ( string name )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
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

		public IList<ExceptionInfo> SelectByName ( int start, int count, string name )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ExceptionInfo> SelectByMessage ( string message )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
 				if( obj.Message == message ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByMessage ( string message )
		{
			return (long) SelectByMessage ( message ).Count;
		}

		public IList<ExceptionInfo> SelectByMessage ( int start, int count, string message )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
 				if( obj.Message == message ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ExceptionInfo> SelectByDate ( DateTime date )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
 				if( obj.Date == date ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByDate ( DateTime date )
		{
			return (long) SelectByDate ( date ).Count;
		}

		public IList<ExceptionInfo> SelectByDate ( int start, int count, DateTime date )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
 				if( obj.Date == date ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ExceptionInfo> SelectByPrincipal ( Principal principal )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
 				if( obj.Principal == principal ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPrincipal ( Principal principal )
		{
			return (long) SelectByPrincipal ( principal ).Count;
		}

		public IList<ExceptionInfo> SelectByPrincipal ( int start, int count, Principal principal )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
 				if( obj.Principal == principal ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ExceptionInfo> SelectByUrl ( string url )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
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

		public IList<ExceptionInfo> SelectByUrl ( int start, int count, string url )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
 				if( obj.Url == url ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ExceptionInfo> SelectByStackTrace ( string stackTrace )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
 				if( obj.StackTrace == stackTrace ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByStackTrace ( string stackTrace )
		{
			return (long) SelectByStackTrace ( stackTrace ).Count;
		}

		public IList<ExceptionInfo> SelectByStackTrace ( int start, int count, string stackTrace )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
 				if( obj.StackTrace == stackTrace ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ExceptionInfo> SelectByCreatedDate ( DateTime createdDate )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
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

		public IList<ExceptionInfo> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ExceptionInfo> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
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

		public IList<ExceptionInfo> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<ExceptionInfo> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
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

		public IList<ExceptionInfo> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<ExceptionInfo> container = new List<ExceptionInfo>();
 			
			foreach( ExceptionInfo obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
