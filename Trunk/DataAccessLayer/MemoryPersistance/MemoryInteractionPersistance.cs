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
	internal class MemoryInteractionPersistance : 
			MemoryPersistance<Interaction>, IInteractionPersistance {
		
		#region IPersistance
		
		public override Interaction Create()
		{
			return new SpecializedMemoryInteraction ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Interaction> SelectById ( int id )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
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

		public IList<Interaction> SelectById ( int start, int count, int id )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Interaction> SelectBySource ( int source )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.Source == source ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySource ( int source )
		{
			return (long) SelectBySource ( source ).Count;
		}

		public IList<Interaction> SelectBySource ( int start, int count, int source )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.Source == source ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Interaction> SelectByTarget ( int target )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.Target == target ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTarget ( int target )
		{
			return (long) SelectByTarget ( target ).Count;
		}

		public IList<Interaction> SelectByTarget ( int start, int count, int target )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.Target == target ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Interaction> SelectByType ( string type )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
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

		public IList<Interaction> SelectByType ( int start, int count, string type )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Interaction> SelectByResponse ( bool response )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.Response == response ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByResponse ( bool response )
		{
			return (long) SelectByResponse ( response ).Count;
		}

		public IList<Interaction> SelectByResponse ( int start, int count, bool response )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.Response == response ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Interaction> SelectByResponseExtension ( string responseExtension )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.ResponseExtension == responseExtension ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByResponseExtension ( string responseExtension )
		{
			return (long) SelectByResponseExtension ( responseExtension ).Count;
		}

		public IList<Interaction> SelectByResponseExtension ( int start, int count, string responseExtension )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.ResponseExtension == responseExtension ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Interaction> SelectByInteractionContext ( string interactionContext )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.InteractionContext == interactionContext ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByInteractionContext ( string interactionContext )
		{
			return (long) SelectByInteractionContext ( interactionContext ).Count;
		}

		public IList<Interaction> SelectByInteractionContext ( int start, int count, string interactionContext )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.InteractionContext == interactionContext ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Interaction> SelectByResolved ( bool resolved )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.Resolved == resolved ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByResolved ( bool resolved )
		{
			return (long) SelectByResolved ( resolved ).Count;
		}

		public IList<Interaction> SelectByResolved ( int start, int count, bool resolved )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.Resolved == resolved ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Interaction> SelectBySourceAditionalData ( string sourceAditionalData )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.SourceAditionalData == sourceAditionalData ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySourceAditionalData ( string sourceAditionalData )
		{
			return (long) SelectBySourceAditionalData ( sourceAditionalData ).Count;
		}

		public IList<Interaction> SelectBySourceAditionalData ( int start, int count, string sourceAditionalData )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.SourceAditionalData == sourceAditionalData ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Interaction> SelectByTargetAditionalData ( string targetAditionalData )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.TargetAditionalData == targetAditionalData ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTargetAditionalData ( string targetAditionalData )
		{
			return (long) SelectByTargetAditionalData ( targetAditionalData ).Count;
		}

		public IList<Interaction> SelectByTargetAditionalData ( int start, int count, string targetAditionalData )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.TargetAditionalData == targetAditionalData ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Interaction> SelectBySourceType ( string sourceType )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.SourceType == sourceType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountBySourceType ( string sourceType )
		{
			return (long) SelectBySourceType ( sourceType ).Count;
		}

		public IList<Interaction> SelectBySourceType ( int start, int count, string sourceType )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.SourceType == sourceType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Interaction> SelectByTargetType ( string targetType )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.TargetType == targetType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByTargetType ( string targetType )
		{
			return (long) SelectByTargetType ( targetType ).Count;
		}

		public IList<Interaction> SelectByTargetType ( int start, int count, string targetType )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.TargetType == targetType ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Interaction> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
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

		public IList<Interaction> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Interaction> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
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

		public IList<Interaction> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Interaction> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
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

		public IList<Interaction> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Interaction> container = new List<Interaction>();
 			
			foreach( Interaction obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
