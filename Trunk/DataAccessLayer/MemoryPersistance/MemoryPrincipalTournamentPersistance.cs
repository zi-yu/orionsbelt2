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
	internal class MemoryPrincipalTournamentPersistance : 
			MemoryPersistance<PrincipalTournament>, IPrincipalTournamentPersistance {
		
		#region IPersistance
		
		public override PrincipalTournament Create()
		{
			return new SpecializedMemoryPrincipalTournament ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<PrincipalTournament> SelectById ( int id )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
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

		public IList<PrincipalTournament> SelectById ( int start, int count, int id )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalTournament> SelectByHasEliminated ( bool hasEliminated )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
 				if( obj.HasEliminated == hasEliminated ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByHasEliminated ( bool hasEliminated )
		{
			return (long) SelectByHasEliminated ( hasEliminated ).Count;
		}

		public IList<PrincipalTournament> SelectByHasEliminated ( int start, int count, bool hasEliminated )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
 				if( obj.HasEliminated == hasEliminated ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalTournament> SelectByEliminatedInFase ( string eliminatedInFase )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
 				if( obj.EliminatedInFase == eliminatedInFase ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByEliminatedInFase ( string eliminatedInFase )
		{
			return (long) SelectByEliminatedInFase ( eliminatedInFase ).Count;
		}

		public IList<PrincipalTournament> SelectByEliminatedInFase ( int start, int count, string eliminatedInFase )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
 				if( obj.EliminatedInFase == eliminatedInFase ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalTournament> SelectByEliminatedInBattleId ( int eliminatedInBattleId )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
 				if( obj.EliminatedInBattleId == eliminatedInBattleId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByEliminatedInBattleId ( int eliminatedInBattleId )
		{
			return (long) SelectByEliminatedInBattleId ( eliminatedInBattleId ).Count;
		}

		public IList<PrincipalTournament> SelectByEliminatedInBattleId ( int start, int count, int eliminatedInBattleId )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
 				if( obj.EliminatedInBattleId == eliminatedInBattleId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalTournament> SelectByPrincipal ( Principal principal )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
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

		public IList<PrincipalTournament> SelectByPrincipal ( int start, int count, Principal principal )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
 				if( obj.Principal == principal ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalTournament> SelectByTournament ( Tournament tournament )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
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

		public IList<PrincipalTournament> SelectByTournament ( int start, int count, Tournament tournament )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
 				if( obj.Tournament == tournament ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalTournament> SelectByTeam ( TeamStorage team )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
 				if( obj.Team == team ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTeam ( TeamStorage team )
		{
			return (long) SelectByTeam ( team ).Count;
		}

		public IList<PrincipalTournament> SelectByTeam ( int start, int count, TeamStorage team )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
 				if( obj.Team == team ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalTournament> SelectByCreatedDate ( DateTime createdDate )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
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

		public IList<PrincipalTournament> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalTournament> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
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

		public IList<PrincipalTournament> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<PrincipalTournament> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
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

		public IList<PrincipalTournament> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<PrincipalTournament> container = new List<PrincipalTournament>();
 			
			foreach( PrincipalTournament obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
