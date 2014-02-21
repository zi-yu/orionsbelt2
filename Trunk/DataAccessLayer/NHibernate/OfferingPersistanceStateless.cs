using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class OfferingPersistanceStateless : 
			NHibernatePersistanceStateless<Offering>, IOfferingPersistance {
	
		#region Static Access
		
		internal static OfferingPersistanceStateless CreateSession()
		{
			return new OfferingPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedOffering) );
		}
				
		internal static OfferingPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			OfferingPersistanceStateless persistance = new OfferingPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedOffering) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static OfferingPersistanceStateless globalSession = null;
        internal static OfferingPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static OfferingPersistanceStateless GetSession()
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
		
		internal static OfferingPersistanceStateless GetValidatedSession()
        {
            OfferingPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private OfferingPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Offering Create()
		{	
			SpecializedOffering entity = new SpecializedOffering ();
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
		
 		public IList<Offering> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedOffering e where e.Id = '{0}'", id);
		}

		public IList<Offering> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedOffering e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Offering> SelectByInitialValue ( int initialValue )
		{
			return SelectByInitialValue (-1, -1, initialValue );
		}
		
		public long CountByInitialValue ( int initialValue )
		{
			return ExecuteScalar("select count(*) from SpecializedOffering e where e.InitialValue = '{0}'", initialValue);
		}

		public IList<Offering> SelectByInitialValue ( int start, int count, int initialValue )
		{
			IList list = Query(start, count, "from SpecializedOffering e where e.InitialValue = {0}", initialValue);
			return ToTypedCollection(list);
		}
		
 		public IList<Offering> SelectByCurrentValue ( int currentValue )
		{
			return SelectByCurrentValue (-1, -1, currentValue );
		}
		
		public long CountByCurrentValue ( int currentValue )
		{
			return ExecuteScalar("select count(*) from SpecializedOffering e where e.CurrentValue = '{0}'", currentValue);
		}

		public IList<Offering> SelectByCurrentValue ( int start, int count, int currentValue )
		{
			IList list = Query(start, count, "from SpecializedOffering e where e.CurrentValue = {0}", currentValue);
			return ToTypedCollection(list);
		}
		
 		public IList<Offering> SelectByProduct ( string product )
		{
			return SelectByProduct (-1, -1, product );
		}
		
		public long CountByProduct ( string product )
		{
			return ExecuteScalar("select count(*) from SpecializedOffering e where e.Product = '{0}'", product);
		}

		public IList<Offering> SelectByProduct ( int start, int count, string product )
		{
			IList list = Query(start, count, "from SpecializedOffering e where e.Product like '{0}'", product);
			return ToTypedCollection(list);
		}
		
 		public IList<Offering> SelectByDonor ( PlayerStorage donor )
		{
			return SelectByDonor (-1, -1, donor );
		}
		
		public long CountByDonor ( PlayerStorage donor )
		{
			return ExecuteScalar("select count(*) from SpecializedOffering e where e.Donor = '{0}'", donor);
		}

		public IList<Offering> SelectByDonor ( int start, int count, PlayerStorage donor )
		{
			IList list = Query(start, count, "from SpecializedOffering e where e.DonorNHibernate.Id = {0}", donor.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<Offering> SelectByReceiver ( PlayerStorage receiver )
		{
			return SelectByReceiver (-1, -1, receiver );
		}
		
		public long CountByReceiver ( PlayerStorage receiver )
		{
			return ExecuteScalar("select count(*) from SpecializedOffering e where e.Receiver = '{0}'", receiver);
		}

		public IList<Offering> SelectByReceiver ( int start, int count, PlayerStorage receiver )
		{
			IList list = Query(start, count, "from SpecializedOffering e where e.ReceiverNHibernate.Id = {0}", receiver.Id);
			return ToTypedCollection(list);
		}
		
 		public IList<Offering> SelectByAlliance ( AllianceStorage alliance )
		{
			return SelectByAlliance (-1, -1, alliance );
		}
		
		public long CountByAlliance ( AllianceStorage alliance )
		{
			return ExecuteScalar("select count(*) from SpecializedOffering e where e.Alliance = '{0}'", alliance);
		}

		public IList<Offering> SelectByAlliance ( int start, int count, AllianceStorage alliance )
		{
			IList list = Query(start, count, "from SpecializedOffering e where e.AllianceNHibernate.Id = {0}", alliance.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : Offering
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfProduct );
        }
		public static LifecyleVeto ValidateMaxSizeOfProduct ( Offering e ) 
        {
			return ValidateStringMaxSize( "Offering", "Product", e.Product, 100 );
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
