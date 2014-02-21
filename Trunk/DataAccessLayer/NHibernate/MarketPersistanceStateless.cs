﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class MarketPersistanceStateless : 
			NHibernatePersistanceStateless<Market>, IMarketPersistance {
	
		#region Static Access
		
		internal static MarketPersistanceStateless CreateSession()
		{
			return new MarketPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedMarket) );
		}
				
		internal static MarketPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			MarketPersistanceStateless persistance = new MarketPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedMarket) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static MarketPersistanceStateless globalSession = null;
        internal static MarketPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static MarketPersistanceStateless GetSession()
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
		
		internal static MarketPersistanceStateless GetValidatedSession()
        {
            MarketPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private MarketPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Market Create()
		{	
			SpecializedMarket entity = new SpecializedMarket ();
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
		
 		public IList<Market> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedMarket e where e.Id = '{0}'", id);
		}

		public IList<Market> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedMarket e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Market> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedMarket e where e.Name = '{0}'", name);
		}

		public IList<Market> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedMarket e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<Market> SelectByLevel ( int level )
		{
			return SelectByLevel (-1, -1, level );
		}
		
		public long CountByLevel ( int level )
		{
			return ExecuteScalar("select count(*) from SpecializedMarket e where e.Level = '{0}'", level);
		}

		public IList<Market> SelectByLevel ( int start, int count, int level )
		{
			IList list = Query(start, count, "from SpecializedMarket e where e.Level = {0}", level);
			return ToTypedCollection(list);
		}
		
 		public IList<Market> SelectByCoordinates ( string coordinates )
		{
			return SelectByCoordinates (-1, -1, coordinates );
		}
		
		public long CountByCoordinates ( string coordinates )
		{
			return ExecuteScalar("select count(*) from SpecializedMarket e where e.Coordinates = '{0}'", coordinates);
		}

		public IList<Market> SelectByCoordinates ( int start, int count, string coordinates )
		{
			IList list = Query(start, count, "from SpecializedMarket e where e.Coordinates like '{0}'", coordinates);
			return ToTypedCollection(list);
		}
		
 		public IList<Market> SelectBySector ( SectorStorage sector )
		{
			return SelectBySector (-1, -1, sector );
		}
		
		public long CountBySector ( SectorStorage sector )
		{
			return ExecuteScalar("select count(*) from SpecializedMarket e where e.Sector = '{0}'", sector);
		}

		public IList<Market> SelectBySector ( int start, int count, SectorStorage sector )
		{
			IList list = Query(start, count, "from SpecializedMarket e where e.SectorNHibernate.Id = {0}", sector.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : Market
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfCoordinates );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( Market e ) 
        {
			return ValidateStringMaxSize( "Market", "Name", e.Name, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfCoordinates ( Market e ) 
        {
			return ValidateStringMaxSize( "Market", "Coordinates", e.Coordinates, 100 );
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
