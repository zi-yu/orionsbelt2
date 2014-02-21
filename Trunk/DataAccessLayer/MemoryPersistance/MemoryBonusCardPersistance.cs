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
	internal class MemoryBonusCardPersistance : 
			MemoryPersistance<BonusCard>, IBonusCardPersistance {
		
		#region IPersistance
		
		public override BonusCard Create()
		{
			return new SpecializedMemoryBonusCard ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<BonusCard> SelectById ( int id )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
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

		public IList<BonusCard> SelectById ( int start, int count, int id )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BonusCard> SelectByType ( string type )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
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

		public IList<BonusCard> SelectByType ( int start, int count, string type )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
 				if( obj.Type == type ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BonusCard> SelectByCode ( string code )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
 				if( obj.Code == code ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCode ( string code )
		{
			return (long) SelectByCode ( code ).Count;
		}

		public IList<BonusCard> SelectByCode ( int start, int count, string code )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
 				if( obj.Code == code ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BonusCard> SelectByOrions ( int orions )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
 				if( obj.Orions == orions ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByOrions ( int orions )
		{
			return (long) SelectByOrions ( orions ).Count;
		}

		public IList<BonusCard> SelectByOrions ( int start, int count, int orions )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
 				if( obj.Orions == orions ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BonusCard> SelectByUsed ( bool used )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
 				if( obj.Used == used ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUsed ( bool used )
		{
			return (long) SelectByUsed ( used ).Count;
		}

		public IList<BonusCard> SelectByUsed ( int start, int count, bool used )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
 				if( obj.Used == used ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BonusCard> SelectByUsedBy ( Principal usedBy )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
 				if( obj.UsedBy == usedBy ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByUsedBy ( Principal usedBy )
		{
			return (long) SelectByUsedBy ( usedBy ).Count;
		}

		public IList<BonusCard> SelectByUsedBy ( int start, int count, Principal usedBy )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
 				if( obj.UsedBy == usedBy ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BonusCard> SelectByCreatedDate ( DateTime createdDate )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
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

		public IList<BonusCard> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BonusCard> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
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

		public IList<BonusCard> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<BonusCard> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
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

		public IList<BonusCard> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<BonusCard> container = new List<BonusCard>();
 			
			foreach( BonusCard obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
