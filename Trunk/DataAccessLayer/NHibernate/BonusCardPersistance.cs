using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class BonusCardPersistance : 
			NHibernatePersistance<BonusCard>, IBonusCardPersistance {
	
		#region Static Access
		
		internal static BonusCardPersistance CreateSession()
		{
			return new BonusCardPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedBonusCard) );
		}
				
		internal static BonusCardPersistance AttachSession( IPersistanceSession owner )
		{
			BonusCardPersistance persistance = new BonusCardPersistance ( owner.Session as ISession, typeof(SpecializedBonusCard) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static BonusCardPersistance globalSession = null;
        internal static BonusCardPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static BonusCardPersistance GetSession()
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
		
		internal static BonusCardPersistance GetValidatedSession()
        {
            BonusCardPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private BonusCardPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override BonusCard Create()
		{	
			SpecializedBonusCard entity = new SpecializedBonusCard ();
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
		
 		public IList<BonusCard> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedBonusCard e where e.Id = '{0}'", id);
		}

		public IList<BonusCard> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedBonusCard e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<BonusCard> SelectByType ( string type )
		{
			return SelectByType (-1, -1, type );
		}
		
		public long CountByType ( string type )
		{
			return ExecuteScalar("select count(*) from SpecializedBonusCard e where e.Type = '{0}'", type);
		}

		public IList<BonusCard> SelectByType ( int start, int count, string type )
		{
			IList list = Query(start, count, "from SpecializedBonusCard e where e.Type like '{0}'", type);
			return ToTypedCollection(list);
		}
		
 		public IList<BonusCard> SelectByCode ( string code )
		{
			return SelectByCode (-1, -1, code );
		}
		
		public long CountByCode ( string code )
		{
			return ExecuteScalar("select count(*) from SpecializedBonusCard e where e.Code = '{0}'", code);
		}

		public IList<BonusCard> SelectByCode ( int start, int count, string code )
		{
			IList list = Query(start, count, "from SpecializedBonusCard e where e.Code like '{0}'", code);
			return ToTypedCollection(list);
		}
		
 		public IList<BonusCard> SelectByOrions ( int orions )
		{
			return SelectByOrions (-1, -1, orions );
		}
		
		public long CountByOrions ( int orions )
		{
			return ExecuteScalar("select count(*) from SpecializedBonusCard e where e.Orions = '{0}'", orions);
		}

		public IList<BonusCard> SelectByOrions ( int start, int count, int orions )
		{
			IList list = Query(start, count, "from SpecializedBonusCard e where e.Orions = {0}", orions);
			return ToTypedCollection(list);
		}
		
 		public IList<BonusCard> SelectByUsed ( bool used )
		{
			return SelectByUsed (-1, -1, used );
		}
		
		public long CountByUsed ( bool used )
		{
			return ExecuteScalar("select count(*) from SpecializedBonusCard e where e.Used = '{0}'", used);
		}

		public IList<BonusCard> SelectByUsed ( int start, int count, bool used )
		{
			IList list = Query(start, count, "from SpecializedBonusCard e where e.Used = {0}", used);
			return ToTypedCollection(list);
		}
		
 		public IList<BonusCard> SelectByUsedBy ( Principal usedBy )
		{
			return SelectByUsedBy (-1, -1, usedBy );
		}
		
		public long CountByUsedBy ( Principal usedBy )
		{
			return ExecuteScalar("select count(*) from SpecializedBonusCard e where e.UsedBy = '{0}'", usedBy);
		}

		public IList<BonusCard> SelectByUsedBy ( int start, int count, Principal usedBy )
		{
			IList list = Query(start, count, "from SpecializedBonusCard e where e.UsedByNHibernate.Id = {0}", usedBy.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : BonusCard
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfType );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfCode );
        }
		public static LifecyleVeto ValidateMaxSizeOfType ( BonusCard e ) 
        {
			return ValidateStringMaxSize( "BonusCard", "Type", e.Type, 200 );
		}
		public static LifecyleVeto ValidateMaxSizeOfCode ( BonusCard e ) 
        {
			return ValidateStringMaxSize( "BonusCard", "Code", e.Code, 100 );
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
