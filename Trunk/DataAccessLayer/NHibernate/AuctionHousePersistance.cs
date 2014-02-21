using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class AuctionHousePersistance : 
			NHibernatePersistance<AuctionHouse>, IAuctionHousePersistance {
	
		#region Static Access
		
		internal static AuctionHousePersistance CreateSession()
		{
			return new AuctionHousePersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedAuctionHouse) );
		}
				
		internal static AuctionHousePersistance AttachSession( IPersistanceSession owner )
		{
			AuctionHousePersistance persistance = new AuctionHousePersistance ( owner.Session as ISession, typeof(SpecializedAuctionHouse) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static AuctionHousePersistance globalSession = null;
        internal static AuctionHousePersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static AuctionHousePersistance GetSession()
		{
			System.Web.HttpContext context = System.Web.HttpContext.Current;
			
			if (context == null) {
                return CreateSession();
            }

			if( context.Items == null ) {
				return CreateSession();
			}

            object persistance = context.Items["Persistance"];
			NHibernatePersistance<Principal> session = null;
			
			if( persistance != null ) {
				session = (NHibernatePersistance<Principal>) persistance;
			} else {
                session = PrincipalPersistance.CreateSession();
				context.Items["Persistance"] = session;
			}
			
			ISession nhSession = session.Session as ISession;
            if (nhSession != null && !NHibernateUtilities.IsSessionOpen(nhSession) ) {
				nhSession.Dispose();
                session.NHibernateSession = NHibernateUtilities.OpenSession;
            }
			
			return AttachSession( session );
		}
		
		internal static AuctionHousePersistance GetValidatedSession()
        {
            AuctionHousePersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private AuctionHousePersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override AuctionHouse Create()
		{	
			SpecializedAuctionHouse entity = new SpecializedAuctionHouse ();
            entity.NHibernateSession = NHibernateSession;
            return entity;
		}

		/// <summary>
        /// Adds logic validation to the entities
        /// </summary>
        public override void AddValidators()
        {
			AddValidation(this);
        }
        
		#endregion IPersistance
		
		#region ExtendedMethods		
		
 		public IList<AuctionHouse> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedAuctionHouse e where e.Id = '{0}'", id);
		}

		public IList<AuctionHouse> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedAuctionHouse e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<AuctionHouse> SelectByPrice ( int price )
		{
			return SelectByPrice (-1, -1, price );
		}
		
		public long CountByPrice ( int price )
		{
			return ExecuteScalar("select count(*) from SpecializedAuctionHouse e where e.Price = '{0}'", price);
		}

		public IList<AuctionHouse> SelectByPrice ( int start, int count, int price )
		{
			IList list = Query(start, count, "from SpecializedAuctionHouse e where e.Price = {0}", price);
			return ToTypedCollection(list);
		}
		
 		public IList<AuctionHouse> SelectByCurrentBid ( int currentBid )
		{
			return SelectByCurrentBid (-1, -1, currentBid );
		}
		
		public long CountByCurrentBid ( int currentBid )
		{
			return ExecuteScalar("select count(*) from SpecializedAuctionHouse e where e.CurrentBid = '{0}'", currentBid);
		}

		public IList<AuctionHouse> SelectByCurrentBid ( int start, int count, int currentBid )
		{
			IList list = Query(start, count, "from SpecializedAuctionHouse e where e.CurrentBid = {0}", currentBid);
			return ToTypedCollection(list);
		}
		
 		public IList<AuctionHouse> SelectByBuyout ( int buyout )
		{
			return SelectByBuyout (-1, -1, buyout );
		}
		
		public long CountByBuyout ( int buyout )
		{
			return ExecuteScalar("select count(*) from SpecializedAuctionHouse e where e.Buyout = '{0}'", buyout);
		}

		public IList<AuctionHouse> SelectByBuyout ( int start, int count, int buyout )
		{
			IList list = Query(start, count, "from SpecializedAuctionHouse e where e.Buyout = {0}", buyout);
			return ToTypedCollection(list);
		}
		
 		public IList<AuctionHouse> SelectByBegin ( int begin )
		{
			return SelectByBegin (-1, -1, begin );
		}
		
		public long CountByBegin ( int begin )
		{
			return ExecuteScalar("select count(*) from SpecializedAuctionHouse e where e.Begin = '{0}'", begin);
		}

		public IList<AuctionHouse> SelectByBegin ( int start, int count, int begin )
		{
			IList list = Query(start, count, "from SpecializedAuctionHouse e where e.Begin = {0}", begin);
			return ToTypedCollection(list);
		}
		
 		public IList<AuctionHouse> SelectByTimeout ( int timeout )
		{
			return SelectByTimeout (-1, -1, timeout );
		}
		
		public long CountByTimeout ( int timeout )
		{
			return ExecuteScalar("select count(*) from SpecializedAuctionHouse e where e.Timeout = '{0}'", timeout);
		}

		public IList<AuctionHouse> SelectByTimeout ( int start, int count, int timeout )
		{
			IList list = Query(start, count, "from SpecializedAuctionHouse e where e.Timeout = {0}", timeout);
			return ToTypedCollection(list);
		}
		
 		public IList<AuctionHouse> SelectByQuantity ( int quantity )
		{
			return SelectByQuantity (-1, -1, quantity );
		}
		
		public long CountByQuantity ( int quantity )
		{
			return ExecuteScalar("select count(*) from SpecializedAuctionHouse e where e.Quantity = '{0}'", quantity);
		}

		public IList<AuctionHouse> SelectByQuantity ( int start, int count, int quantity )
		{
			IList list = Query(start, count, "from SpecializedAuctionHouse e where e.Quantity = {0}", quantity);
			return ToTypedCollection(list);
		}
		
 		public IList<AuctionHouse> SelectByDetails ( string details )
		{
			return SelectByDetails (-1, -1, details );
		}
		
		public long CountByDetails ( string details )
		{
			return ExecuteScalar("select count(*) from SpecializedAuctionHouse e where e.Details = '{0}'", details);
		}

		public IList<AuctionHouse> SelectByDetails ( int start, int count, string details )
		{
			IList list = Query(start, count, "from SpecializedAuctionHouse e where e.Details like '{0}'", details);
			return ToTypedCollection(list);
		}
		
 		public IList<AuctionHouse> SelectByComplexNumber ( int complexNumber )
		{
			return SelectByComplexNumber (-1, -1, complexNumber );
		}
		
		public long CountByComplexNumber ( int complexNumber )
		{
			return ExecuteScalar("select count(*) from SpecializedAuctionHouse e where e.ComplexNumber = '{0}'", complexNumber);
		}

		public IList<AuctionHouse> SelectByComplexNumber ( int start, int count, int complexNumber )
		{
			IList list = Query(start, count, "from SpecializedAuctionHouse e where e.ComplexNumber = {0}", complexNumber);
			return ToTypedCollection(list);
		}
		
 		public IList<AuctionHouse> SelectByHigherBidOwner ( int higherBidOwner )
		{
			return SelectByHigherBidOwner (-1, -1, higherBidOwner );
		}
		
		public long CountByHigherBidOwner ( int higherBidOwner )
		{
			return ExecuteScalar("select count(*) from SpecializedAuctionHouse e where e.HigherBidOwner = '{0}'", higherBidOwner);
		}

		public IList<AuctionHouse> SelectByHigherBidOwner ( int start, int count, int higherBidOwner )
		{
			IList list = Query(start, count, "from SpecializedAuctionHouse e where e.HigherBidOwner = {0}", higherBidOwner);
			return ToTypedCollection(list);
		}
		
 		public IList<AuctionHouse> SelectByBuyedInTick ( int buyedInTick )
		{
			return SelectByBuyedInTick (-1, -1, buyedInTick );
		}
		
		public long CountByBuyedInTick ( int buyedInTick )
		{
			return ExecuteScalar("select count(*) from SpecializedAuctionHouse e where e.BuyedInTick = '{0}'", buyedInTick);
		}

		public IList<AuctionHouse> SelectByBuyedInTick ( int start, int count, int buyedInTick )
		{
			IList list = Query(start, count, "from SpecializedAuctionHouse e where e.BuyedInTick = {0}", buyedInTick);
			return ToTypedCollection(list);
		}
		
 		public IList<AuctionHouse> SelectByOrionsPaid ( int orionsPaid )
		{
			return SelectByOrionsPaid (-1, -1, orionsPaid );
		}
		
		public long CountByOrionsPaid ( int orionsPaid )
		{
			return ExecuteScalar("select count(*) from SpecializedAuctionHouse e where e.OrionsPaid = '{0}'", orionsPaid);
		}

		public IList<AuctionHouse> SelectByOrionsPaid ( int start, int count, int orionsPaid )
		{
			IList list = Query(start, count, "from SpecializedAuctionHouse e where e.OrionsPaid = {0}", orionsPaid);
			return ToTypedCollection(list);
		}
		
 		public IList<AuctionHouse> SelectByAdvertise ( bool advertise )
		{
			return SelectByAdvertise (-1, -1, advertise );
		}
		
		public long CountByAdvertise ( bool advertise )
		{
			return ExecuteScalar("select count(*) from SpecializedAuctionHouse e where e.Advertise = '{0}'", advertise);
		}

		public IList<AuctionHouse> SelectByAdvertise ( int start, int count, bool advertise )
		{
			IList list = Query(start, count, "from SpecializedAuctionHouse e where e.Advertise = {0}", advertise);
			return ToTypedCollection(list);
		}
		
 		public IList<AuctionHouse> SelectByOwner ( PlayerStorage owner )
		{
			return SelectByOwner (-1, -1, owner );
		}
		
		public long CountByOwner ( PlayerStorage owner )
		{
			return ExecuteScalar("select count(*) from SpecializedAuctionHouse e where e.Owner = '{0}'", owner);
		}

		public IList<AuctionHouse> SelectByOwner ( int start, int count, PlayerStorage owner )
		{
			IList list = Query(start, count, "from SpecializedAuctionHouse e where e.OwnerNHibernate.Id = {0}", owner.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : AuctionHouse
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfDetails );
        }
		public static LifecyleVeto ValidateMaxSizeOfDetails ( AuctionHouse e ) 
        {
			return ValidateStringMaxSize( "AuctionHouse", "Details", e.Details, 200 );
		}

		public static LifecyleVeto ValidateStringMaxSize( string entityName, string propertyName, string val, int maxSize ) 
        {
			if( string.IsNullOrEmpty( val ) ) {
				return LifecyleVeto.Continue;
			}
			
			if( val.Length > maxSize ) {
				throw new DALException("The `{4}' property of `{0}' has too many chars (max: {1}, found:{2}, text:{3})", entityName, maxSize, val.Length, val, propertyName);
			}
			
			return LifecyleVeto.Continue;
		}

		#endregion Validation
		
	};
}
