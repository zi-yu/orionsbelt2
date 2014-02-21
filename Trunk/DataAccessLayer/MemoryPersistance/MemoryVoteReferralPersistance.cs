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
	internal class MemoryVoteReferralPersistance : 
			MemoryPersistance<VoteReferral>, IVoteReferralPersistance {
		
		#region IPersistance
		
		public override VoteReferral Create()
		{
			return new SpecializedMemoryVoteReferral ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<VoteReferral> SelectById ( int id )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
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

		public IList<VoteReferral> SelectById ( int start, int count, int id )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<VoteReferral> SelectByName ( string name )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
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

		public IList<VoteReferral> SelectByName ( int start, int count, string name )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
 				if( obj.Name == name ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<VoteReferral> SelectByShortName ( string shortName )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
 				if( obj.ShortName == shortName ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByShortName ( string shortName )
		{
			return (long) SelectByShortName ( shortName ).Count;
		}

		public IList<VoteReferral> SelectByShortName ( int start, int count, string shortName )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
 				if( obj.ShortName == shortName ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<VoteReferral> SelectByUrl ( string url )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
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

		public IList<VoteReferral> SelectByUrl ( int start, int count, string url )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
 				if( obj.Url == url ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<VoteReferral> SelectByImageUrl ( string imageUrl )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
 				if( obj.ImageUrl == imageUrl ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByImageUrl ( string imageUrl )
		{
			return (long) SelectByImageUrl ( imageUrl ).Count;
		}

		public IList<VoteReferral> SelectByImageUrl ( int start, int count, string imageUrl )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
 				if( obj.ImageUrl == imageUrl ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<VoteReferral> SelectByReward ( string reward )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
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

		public IList<VoteReferral> SelectByReward ( int start, int count, string reward )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
 				if( obj.Reward == reward ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<VoteReferral> SelectByClickCount ( int clickCount )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
 				if( obj.ClickCount == clickCount ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByClickCount ( int clickCount )
		{
			return (long) SelectByClickCount ( clickCount ).Count;
		}

		public IList<VoteReferral> SelectByClickCount ( int start, int count, int clickCount )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
 				if( obj.ClickCount == clickCount ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<VoteReferral> SelectByVoteOrder ( int voteOrder )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
 				if( obj.VoteOrder == voteOrder ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByVoteOrder ( int voteOrder )
		{
			return (long) SelectByVoteOrder ( voteOrder ).Count;
		}

		public IList<VoteReferral> SelectByVoteOrder ( int start, int count, int voteOrder )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
 				if( obj.VoteOrder == voteOrder ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<VoteReferral> SelectByCreatedDate ( DateTime createdDate )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
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

		public IList<VoteReferral> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<VoteReferral> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
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

		public IList<VoteReferral> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<VoteReferral> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
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

		public IList<VoteReferral> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<VoteReferral> container = new List<VoteReferral>();
 			
			foreach( VoteReferral obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
