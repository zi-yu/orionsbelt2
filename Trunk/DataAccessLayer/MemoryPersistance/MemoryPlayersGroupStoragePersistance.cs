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
	internal class MemoryPlayersGroupStoragePersistance : 
			MemoryPersistance<PlayersGroupStorage>, IPlayersGroupStoragePersistance {
		
		#region IPersistance
		
		public override PlayersGroupStorage Create()
		{
			return new SpecializedMemoryPlayersGroupStorage ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<PlayersGroupStorage> SelectById ( int id )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
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

		public IList<PlayersGroupStorage> SelectById ( int start, int count, int id )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayersGroupStorage> SelectByEliminatoryNumber ( int eliminatoryNumber )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
 				if( obj.EliminatoryNumber == eliminatoryNumber ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByEliminatoryNumber ( int eliminatoryNumber )
		{
			return (long) SelectByEliminatoryNumber ( eliminatoryNumber ).Count;
		}

		public IList<PlayersGroupStorage> SelectByEliminatoryNumber ( int start, int count, int eliminatoryNumber )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
 				if( obj.EliminatoryNumber == eliminatoryNumber ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayersGroupStorage> SelectByPlayersIds ( string playersIds )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
 				if( obj.PlayersIds == playersIds ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByPlayersIds ( string playersIds )
		{
			return (long) SelectByPlayersIds ( playersIds ).Count;
		}

		public IList<PlayersGroupStorage> SelectByPlayersIds ( int start, int count, string playersIds )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
 				if( obj.PlayersIds == playersIds ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayersGroupStorage> SelectByGroupNumber ( int groupNumber )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
 				if( obj.GroupNumber == groupNumber ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByGroupNumber ( int groupNumber )
		{
			return (long) SelectByGroupNumber ( groupNumber ).Count;
		}

		public IList<PlayersGroupStorage> SelectByGroupNumber ( int start, int count, int groupNumber )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
 				if( obj.GroupNumber == groupNumber ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayersGroupStorage> SelectByTournament ( Tournament tournament )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
 				if( obj.Tournament == tournament ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTournament ( Tournament tournament )
		{
			return (long) SelectByTournament ( tournament ).Count;
		}

		public IList<PlayersGroupStorage> SelectByTournament ( int start, int count, Tournament tournament )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
 				if( obj.Tournament == tournament ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayersGroupStorage> SelectByCreatedDate ( DateTime createdDate )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
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

		public IList<PlayersGroupStorage> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayersGroupStorage> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
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

		public IList<PlayersGroupStorage> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PlayersGroupStorage> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
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

		public IList<PlayersGroupStorage> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<PlayersGroupStorage> container = new List<PlayersGroupStorage>();
 			
			foreach( PlayersGroupStorage obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
