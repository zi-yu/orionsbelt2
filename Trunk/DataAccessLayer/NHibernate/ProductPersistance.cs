using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class ProductPersistance : 
			NHibernatePersistance<Product>, IProductPersistance {
	
		#region Static Access
		
		internal static ProductPersistance CreateSession()
		{
			return new ProductPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedProduct) );
		}
				
		internal static ProductPersistance AttachSession( IPersistanceSession owner )
		{
			ProductPersistance persistance = new ProductPersistance ( owner.Session as ISession, typeof(SpecializedProduct) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static ProductPersistance globalSession = null;
        internal static ProductPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static ProductPersistance GetSession()
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
		
		internal static ProductPersistance GetValidatedSession()
        {
            ProductPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private ProductPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Product Create()
		{	
			SpecializedProduct entity = new SpecializedProduct ();
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
		
 		public IList<Product> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedProduct e where e.Id = '{0}'", id);
		}

		public IList<Product> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedProduct e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Product> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedProduct e where e.Name = '{0}'", name);
		}

		public IList<Product> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedProduct e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<Product> SelectByPrice ( int price )
		{
			return SelectByPrice (-1, -1, price );
		}
		
		public long CountByPrice ( int price )
		{
			return ExecuteScalar("select count(*) from SpecializedProduct e where e.Price = '{0}'", price);
		}

		public IList<Product> SelectByPrice ( int start, int count, int price )
		{
			IList list = Query(start, count, "from SpecializedProduct e where e.Price = {0}", price);
			return ToTypedCollection(list);
		}
		
 		public IList<Product> SelectByType ( string type )
		{
			return SelectByType (-1, -1, type );
		}
		
		public long CountByType ( string type )
		{
			return ExecuteScalar("select count(*) from SpecializedProduct e where e.Type = '{0}'", type);
		}

		public IList<Product> SelectByType ( int start, int count, string type )
		{
			IList list = Query(start, count, "from SpecializedProduct e where e.Type like '{0}'", type);
			return ToTypedCollection(list);
		}
		
 		public IList<Product> SelectByQuantity ( int quantity )
		{
			return SelectByQuantity (-1, -1, quantity );
		}
		
		public long CountByQuantity ( int quantity )
		{
			return ExecuteScalar("select count(*) from SpecializedProduct e where e.Quantity = '{0}'", quantity);
		}

		public IList<Product> SelectByQuantity ( int start, int count, int quantity )
		{
			IList list = Query(start, count, "from SpecializedProduct e where e.Quantity = {0}", quantity);
			return ToTypedCollection(list);
		}
		
 		public IList<Product> SelectByMarket ( Market market )
		{
			return SelectByMarket (-1, -1, market );
		}
		
		public long CountByMarket ( Market market )
		{
			return ExecuteScalar("select count(*) from SpecializedProduct e where e.Market = '{0}'", market);
		}

		public IList<Product> SelectByMarket ( int start, int count, Market market )
		{
			IList list = Query(start, count, "from SpecializedProduct e where e.MarketNHibernate.Id = {0}", market.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : Product
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfType );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( Product e ) 
        {
			return ValidateStringMaxSize( "Product", "Name", e.Name, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfType ( Product e ) 
        {
			return ValidateStringMaxSize( "Product", "Type", e.Type, 100 );
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
