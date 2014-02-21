using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class PromotionPersistanceStateless : 
			NHibernatePersistanceStateless<Promotion>, IPromotionPersistance {
	
		#region Static Access
		
		internal static PromotionPersistanceStateless CreateSession()
		{
			return new PromotionPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedPromotion) );
		}
				
		internal static PromotionPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			PromotionPersistanceStateless persistance = new PromotionPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedPromotion) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static PromotionPersistanceStateless globalSession = null;
        internal static PromotionPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static PromotionPersistanceStateless GetSession()
		{
			System.Web.HttpContext context = System.Web.HttpContext.Current;
			
			if (context == null) {
                return CreateSession();
            }

			if( context.Items == null ) {
				return CreateSession();
			}

            object persistance = context.Items["PersistanceStateless"];
			NHibernatePersistanceStateless<Principal> session = null;
			
			if( persistance != null ) {
				session = (NHibernatePersistanceStateless<Principal>) persistance;
			} else {
                session = PrincipalPersistanceStateless.CreateSession();
				context.Items["PersistanceStateless"] = session;
			}
			
			IStatelessSession nhSession = session.Session as IStatelessSession;
            if (nhSession != null && !NHibernateUtilities.IsSessionOpen(nhSession) ) {
				nhSession.Dispose();
                session.NHibernateSession = NHibernateUtilities.OpenStatelessSession;
            }
			
			return AttachSession( session );
		}
		
		internal static PromotionPersistanceStateless GetValidatedSession()
        {
            PromotionPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private PromotionPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Promotion Create()
		{	
			SpecializedPromotion entity = new SpecializedPromotion ();
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
		
 		public IList<Promotion> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.Id = '{0}'", id);
		}

		public IList<Promotion> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedPromotion e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Promotion> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.Name = '{0}'", name);
		}

		public IList<Promotion> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedPromotion e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<Promotion> SelectByBeginDate ( DateTime beginDate )
		{
			return SelectByBeginDate (-1, -1, beginDate );
		}
		
		public long CountByBeginDate ( DateTime beginDate )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.BeginDate = '{0}'", beginDate);
		}

		public IList<Promotion> SelectByBeginDate ( int start, int count, DateTime beginDate )
		{
			throw new NotImplementedException();
		}
		
 		public IList<Promotion> SelectByEndDate ( DateTime endDate )
		{
			return SelectByEndDate (-1, -1, endDate );
		}
		
		public long CountByEndDate ( DateTime endDate )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.EndDate = '{0}'", endDate);
		}

		public IList<Promotion> SelectByEndDate ( int start, int count, DateTime endDate )
		{
			throw new NotImplementedException();
		}
		
 		public IList<Promotion> SelectByRevenueType ( string revenueType )
		{
			return SelectByRevenueType (-1, -1, revenueType );
		}
		
		public long CountByRevenueType ( string revenueType )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.RevenueType = '{0}'", revenueType);
		}

		public IList<Promotion> SelectByRevenueType ( int start, int count, string revenueType )
		{
			IList list = Query(start, count, "from SpecializedPromotion e where e.RevenueType like '{0}'", revenueType);
			return ToTypedCollection(list);
		}
		
 		public IList<Promotion> SelectByRevenue ( double revenue )
		{
			return SelectByRevenue (-1, -1, revenue );
		}
		
		public long CountByRevenue ( double revenue )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.Revenue = '{0}'", revenue);
		}

		public IList<Promotion> SelectByRevenue ( int start, int count, double revenue )
		{
			throw new NotImplementedException();
		}
		
 		public IList<Promotion> SelectByPromotionType ( string promotionType )
		{
			return SelectByPromotionType (-1, -1, promotionType );
		}
		
		public long CountByPromotionType ( string promotionType )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.PromotionType = '{0}'", promotionType);
		}

		public IList<Promotion> SelectByPromotionType ( int start, int count, string promotionType )
		{
			IList list = Query(start, count, "from SpecializedPromotion e where e.PromotionType like '{0}'", promotionType);
			return ToTypedCollection(list);
		}
		
 		public IList<Promotion> SelectByRangeBegin ( int rangeBegin )
		{
			return SelectByRangeBegin (-1, -1, rangeBegin );
		}
		
		public long CountByRangeBegin ( int rangeBegin )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.RangeBegin = '{0}'", rangeBegin);
		}

		public IList<Promotion> SelectByRangeBegin ( int start, int count, int rangeBegin )
		{
			IList list = Query(start, count, "from SpecializedPromotion e where e.RangeBegin = {0}", rangeBegin);
			return ToTypedCollection(list);
		}
		
 		public IList<Promotion> SelectByRangeEnd ( int rangeEnd )
		{
			return SelectByRangeEnd (-1, -1, rangeEnd );
		}
		
		public long CountByRangeEnd ( int rangeEnd )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.RangeEnd = '{0}'", rangeEnd);
		}

		public IList<Promotion> SelectByRangeEnd ( int start, int count, int rangeEnd )
		{
			IList list = Query(start, count, "from SpecializedPromotion e where e.RangeEnd = {0}", rangeEnd);
			return ToTypedCollection(list);
		}
		
 		public IList<Promotion> SelectByPromotionCode ( int promotionCode )
		{
			return SelectByPromotionCode (-1, -1, promotionCode );
		}
		
		public long CountByPromotionCode ( int promotionCode )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.PromotionCode = '{0}'", promotionCode);
		}

		public IList<Promotion> SelectByPromotionCode ( int start, int count, int promotionCode )
		{
			IList list = Query(start, count, "from SpecializedPromotion e where e.PromotionCode = {0}", promotionCode);
			return ToTypedCollection(list);
		}
		
 		public IList<Promotion> SelectByBonusType ( string bonusType )
		{
			return SelectByBonusType (-1, -1, bonusType );
		}
		
		public long CountByBonusType ( string bonusType )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.BonusType = '{0}'", bonusType);
		}

		public IList<Promotion> SelectByBonusType ( int start, int count, string bonusType )
		{
			IList list = Query(start, count, "from SpecializedPromotion e where e.BonusType like '{0}'", bonusType);
			return ToTypedCollection(list);
		}
		
 		public IList<Promotion> SelectByBonus ( int bonus )
		{
			return SelectByBonus (-1, -1, bonus );
		}
		
		public long CountByBonus ( int bonus )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.Bonus = '{0}'", bonus);
		}

		public IList<Promotion> SelectByBonus ( int start, int count, int bonus )
		{
			IList list = Query(start, count, "from SpecializedPromotion e where e.Bonus = {0}", bonus);
			return ToTypedCollection(list);
		}
		
 		public IList<Promotion> SelectByStatus ( string status )
		{
			return SelectByStatus (-1, -1, status );
		}
		
		public long CountByStatus ( string status )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.Status = '{0}'", status);
		}

		public IList<Promotion> SelectByStatus ( int start, int count, string status )
		{
			IList list = Query(start, count, "from SpecializedPromotion e where e.Status like '{0}'", status);
			return ToTypedCollection(list);
		}
		
 		public IList<Promotion> SelectByDescription ( string description )
		{
			return SelectByDescription (-1, -1, description );
		}
		
		public long CountByDescription ( string description )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.Description = '{0}'", description);
		}

		public IList<Promotion> SelectByDescription ( int start, int count, string description )
		{
			IList list = Query(start, count, "from SpecializedPromotion e where e.Description like '{0}'", description);
			return ToTypedCollection(list);
		}
		
 		public IList<Promotion> SelectByUses ( int uses )
		{
			return SelectByUses (-1, -1, uses );
		}
		
		public long CountByUses ( int uses )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.Uses = '{0}'", uses);
		}

		public IList<Promotion> SelectByUses ( int start, int count, int uses )
		{
			IList list = Query(start, count, "from SpecializedPromotion e where e.Uses = {0}", uses);
			return ToTypedCollection(list);
		}
		
 		public IList<Promotion> SelectByOwner ( Principal owner )
		{
			return SelectByOwner (-1, -1, owner );
		}
		
		public long CountByOwner ( Principal owner )
		{
			return ExecuteScalar("select count(*) from SpecializedPromotion e where e.Owner = '{0}'", owner);
		}

		public IList<Promotion> SelectByOwner ( int start, int count, Principal owner )
		{
			IList list = Query(start, count, "from SpecializedPromotion e where e.OwnerNHibernate.Id = {0}", owner.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : Promotion
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfRevenueType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfPromotionType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfBonusType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfStatus );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfDescription );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( Promotion e ) 
        {
			return ValidateStringMaxSize( "Promotion", "Name", e.Name, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfRevenueType ( Promotion e ) 
        {
			return ValidateStringMaxSize( "Promotion", "RevenueType", e.RevenueType, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfPromotionType ( Promotion e ) 
        {
			return ValidateStringMaxSize( "Promotion", "PromotionType", e.PromotionType, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfBonusType ( Promotion e ) 
        {
			return ValidateStringMaxSize( "Promotion", "BonusType", e.BonusType, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfStatus ( Promotion e ) 
        {
			return ValidateStringMaxSize( "Promotion", "Status", e.Status, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfDescription ( Promotion e ) 
        {
			return ValidateStringMaxSize( "Promotion", "Description", e.Description, 500 );
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
