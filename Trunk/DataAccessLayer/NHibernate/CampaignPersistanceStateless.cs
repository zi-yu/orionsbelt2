using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class CampaignPersistanceStateless : 
			NHibernatePersistanceStateless<Campaign>, ICampaignPersistance {
	
		#region Static Access
		
		internal static CampaignPersistanceStateless CreateSession()
		{
			return new CampaignPersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedCampaign) );
		}
				
		internal static CampaignPersistanceStateless AttachSession( IPersistanceSession owner )
		{
			CampaignPersistanceStateless persistance = new CampaignPersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedCampaign) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static CampaignPersistanceStateless globalSession = null;
        internal static CampaignPersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static CampaignPersistanceStateless GetSession()
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
		
		internal static CampaignPersistanceStateless GetValidatedSession()
        {
            CampaignPersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private CampaignPersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Campaign Create()
		{	
			SpecializedCampaign entity = new SpecializedCampaign ();
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
		
 		public IList<Campaign> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaign e where e.Id = '{0}'", id);
		}

		public IList<Campaign> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedCampaign e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Campaign> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaign e where e.Name = '{0}'", name);
		}

		public IList<Campaign> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedCampaign e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<Campaign> SelectByPrincipal ( Principal principal )
		{
			return SelectByPrincipal (-1, -1, principal );
		}
		
		public long CountByPrincipal ( Principal principal )
		{
			return ExecuteScalar("select count(*) from SpecializedCampaign e where e.Principal = '{0}'", principal);
		}

		public IList<Campaign> SelectByPrincipal ( int start, int count, Principal principal )
		{
			IList list = Query(start, count, "from SpecializedCampaign e where e.PrincipalNHibernate.Id = {0}", principal.Id);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : Campaign
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( Campaign e ) 
        {
			return ValidateStringMaxSize( "Campaign", "Name", e.Name, 100 );
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
