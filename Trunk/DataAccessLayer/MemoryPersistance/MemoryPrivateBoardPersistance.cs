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
	internal class MemoryPrivateBoardPersistance : 
			MemoryPersistance<PrivateBoard>, IPrivateBoardPersistance {
		
		#region IPersistance
		
		public override PrivateBoard Create()
		{
			return new SpecializedMemoryPrivateBoard ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<PrivateBoard> SelectById ( int id )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
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

		public IList<PrivateBoard> SelectById ( int start, int count, int id )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrivateBoard> SelectByReceiver ( int receiver )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
 				if( obj.Receiver == receiver ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByReceiver ( int receiver )
		{
			return (long) SelectByReceiver ( receiver ).Count;
		}

		public IList<PrivateBoard> SelectByReceiver ( int start, int count, int receiver )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
 				if( obj.Receiver == receiver ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrivateBoard> SelectByType ( string type )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
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

		public IList<PrivateBoard> SelectByType ( int start, int count, string type )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrivateBoard> SelectByMessage ( string message )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
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

		public IList<PrivateBoard> SelectByMessage ( int start, int count, string message )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
 				if( obj.Message == message ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrivateBoard> SelectByWasRead ( bool wasRead )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
 				if( obj.WasRead == wasRead ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByWasRead ( bool wasRead )
		{
			return (long) SelectByWasRead ( wasRead ).Count;
		}

		public IList<PrivateBoard> SelectByWasRead ( int start, int count, bool wasRead )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
 				if( obj.WasRead == wasRead ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrivateBoard> SelectBySender ( PlayerStorage sender )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
 				if( obj.Sender == sender ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySender ( PlayerStorage sender )
		{
			return (long) SelectBySender ( sender ).Count;
		}

		public IList<PrivateBoard> SelectBySender ( int start, int count, PlayerStorage sender )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
 				if( obj.Sender == sender ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrivateBoard> SelectByCreatedDate ( DateTime createdDate )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
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

		public IList<PrivateBoard> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrivateBoard> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
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

		public IList<PrivateBoard> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrivateBoard> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
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

		public IList<PrivateBoard> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<PrivateBoard> container = new List<PrivateBoard>();
 			
			foreach( PrivateBoard obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
