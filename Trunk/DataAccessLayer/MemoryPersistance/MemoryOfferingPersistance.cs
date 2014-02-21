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
	internal class MemoryOfferingPersistance : 
			MemoryPersistance<Offering>, IOfferingPersistance {
		
		#region IPersistance
		
		public override Offering Create()
		{
			return new SpecializedMemoryOffering ();
		}
		

		#endregion IPersistance
		
		#region ExtendedMethods
		
 		public IList<Offering> SelectById ( int id )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
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

		public IList<Offering> SelectById ( int start, int count, int id )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.Id == id ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Offering> SelectByInitialValue ( int initialValue )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.InitialValue == initialValue ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByInitialValue ( int initialValue )
		{
			return (long) SelectByInitialValue ( initialValue ).Count;
		}

		public IList<Offering> SelectByInitialValue ( int start, int count, int initialValue )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.InitialValue == initialValue ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Offering> SelectByCurrentValue ( int currentValue )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.CurrentValue == currentValue ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByCurrentValue ( int currentValue )
		{
			return (long) SelectByCurrentValue ( currentValue ).Count;
		}

		public IList<Offering> SelectByCurrentValue ( int start, int count, int currentValue )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.CurrentValue == currentValue ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Offering> SelectByProduct ( string product )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.Product == product ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByProduct ( string product )
		{
			return (long) SelectByProduct ( product ).Count;
		}

		public IList<Offering> SelectByProduct ( int start, int count, string product )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.Product == product ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Offering> SelectByDonor ( PlayerStorage donor )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.Donor == donor ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByDonor ( PlayerStorage donor )
		{
			return (long) SelectByDonor ( donor ).Count;
		}

		public IList<Offering> SelectByDonor ( int start, int count, PlayerStorage donor )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.Donor == donor ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Offering> SelectByReceiver ( PlayerStorage receiver )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.Receiver == receiver ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByReceiver ( PlayerStorage receiver )
		{
			return (long) SelectByReceiver ( receiver ).Count;
		}

		public IList<Offering> SelectByReceiver ( int start, int count, PlayerStorage receiver )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.Receiver == receiver ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Offering> SelectByAlliance ( AllianceStorage alliance )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.Alliance == alliance ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
		public long CountByAlliance ( AllianceStorage alliance )
		{
			return (long) SelectByAlliance ( alliance ).Count;
		}

		public IList<Offering> SelectByAlliance ( int start, int count, AllianceStorage alliance )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.Alliance == alliance ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Offering> SelectByCreatedDate ( DateTime createdDate )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
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

		public IList<Offering> SelectByCreatedDate ( int start, int count, DateTime createdDate )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.CreatedDate == createdDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Offering> SelectByUpdatedDate ( DateTime updatedDate )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
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

		public IList<Offering> SelectByUpdatedDate ( int start, int count, DateTime updatedDate )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.UpdatedDate == updatedDate ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		public IList<Offering> SelectByLastActionUserId ( int lastActionUserId )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
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

		public IList<Offering> SelectByLastActionUserId ( int start, int count, int lastActionUserId )
		{
			List<Offering> container = new List<Offering>();
 			
			foreach( Offering obj in Database.Values) {
 				if( obj.LastActionUserId == lastActionUserId ) {
					container.Add(obj);	
 				}
 			}
 			
			return container;
		}
		
 		#endregion ExtendedMethods
				
	};
}
