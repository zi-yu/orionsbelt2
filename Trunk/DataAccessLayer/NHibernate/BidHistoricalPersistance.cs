using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class BidHistoricalPersistance : 
			NHibernatePersistance<BidHistorical>, IBidHistoricalPersistance {
	
		#region Static Access
		
		internal static BidHistoricalPersistance CreateSession()
		{
			return new BidHistoricalPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedBidHistorical) );
		}
				
		internal static BidHistoricalPersistance AttachSession( IPersistanceSession owner )
		{
			BidHistoricalPersistance persistance = new BidHistoricalPersistance ( owner.Session as ISession, typeof(SpecializedBidHistorical) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static BidHistoricalPersistance globalSession = null;
        internal static BidHistoricalPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static BidHistoricalPersistance GetSession()
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
		
		internal static BidHistoricalPersistance GetValidatedSession()
        {
            BidHistoricalPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private BidHistoricalPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override BidHistorical Create()
		{	
			SpecializedBidHistorical entity = new SpecializedBidHistorical ();
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
		
 		public IList<BidHistorical> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedBidHistorical e where e.Id = '{0}'", id);
		}

		public IList<BidHistorical> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedBidHistorical e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<BidHistorical> SelectByValue ( int value )
		{
			return SelectByValue (-1, -1, value );
		}
		
		public long CountByValue ( int value )
		{
			return ExecuteScalar("select count(*) from SpecializedBidHistorical e where e.Value = '{0}'", value);
		}

		public IList<BidHistorical> SelectByValue ( int start, int count, int value )
		{
			IList list = Query(start, count, "from SpecializedBidHistorical e where e.Value = {0}", value);
			return ToTypedCollection(list);
		}
		
 		public IList<BidHistorical> SelectByDate ( DateTime date )
		{
			return SelectByDate (-1, -1, date );
		}
		
		public long CountByDate ( DateTime date )
		{
			return ExecuteScalar("select count(*) from SpecializedBidHistorical e where e.Date = '{0}'", date);
		}

		public IList<BidHistorical> SelectByDate ( int start, int count, DateTime date )
		{
			throw new NotImplementedException();
		}
		
 		public IList<BidHistorical> SelectByResource ( AuctionHouse resource )
		{
			return SelectByResource (-1, -1, resource );
		}
		
		public long CountByResource ( AuctionHouse resource )
		{
			return ExecuteScalar("select count(*) from SpecializedBidHistorical e where e.Resource = '{0}'", resource);
		}

		public IList<BidHistorical> SelectByResource ( int start, int count, AuctionHouse resource )
		{
			IList list = Query(start, count, "from SpecializedBidHistorical e where e.ResourceNHibernate.Id = {0}", resource.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<BidHistorical> SelectByMadeBy ( PlayerStorage madeBy )
		{
			return SelectByMadeBy (-1, -1, madeBy );
		}
		
		public long CountByMadeBy ( PlayerStorage madeBy )
		{
			return ExecuteScalar("select count(*) from SpecializedBidHistorical e where e.MadeBy = '{0}'", madeBy);
		}

		public IList<BidHistorical> SelectByMadeBy ( int start, int count, PlayerStorage madeBy )
		{
			IList list = Query(start, count, "from SpecializedBidHistorical e where e.MadeByNHibernate.Id = {0}", madeBy.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : BidHistorical
        {
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
