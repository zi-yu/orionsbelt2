using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	internal class AllianceStoragePersistanceStateless : 
			NHibernatePersistanceStateless<AllianceStorage>, IAllianceStoragePersistance {
	
		#region Static Access
		
		internal static AllianceStoragePersistanceStateless CreateSession()
		{
			return new AllianceStoragePersistanceStateless ( NHibernateUtilities.OpenStatelessSession, typeof(SpecializedAllianceStorage) );
		}
				
		internal static AllianceStoragePersistanceStateless AttachSession( IPersistanceSession owner )
		{
			AllianceStoragePersistanceStateless persistance = new AllianceStoragePersistanceStateless ( owner.Session as IStatelessSession, typeof(SpecializedAllianceStorage) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static AllianceStoragePersistanceStateless globalSession = null;
        internal static AllianceStoragePersistanceStateless GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static AllianceStoragePersistanceStateless GetSession()
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
		
		internal static AllianceStoragePersistanceStateless GetValidatedSession()
        {
            AllianceStoragePersistanceStateless persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private AllianceStoragePersistanceStateless ( IStatelessSession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override AllianceStorage Create()
		{	
			SpecializedAllianceStorage entity = new SpecializedAllianceStorage ();
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
		
 		public IList<AllianceStorage> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceStorage e where e.Id = '{0}'", id);
		}

		public IList<AllianceStorage> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedAllianceStorage e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<AllianceStorage> SelectByScore ( int score )
		{
			return SelectByScore (-1, -1, score );
		}
		
		public long CountByScore ( int score )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceStorage e where e.Score = '{0}'", score);
		}

		public IList<AllianceStorage> SelectByScore ( int start, int count, int score )
		{
			IList list = Query(start, count, "from SpecializedAllianceStorage e where e.Score = {0}", score);
			return ToTypedCollection(list);
		}
		
 		public IList<AllianceStorage> SelectByKarma ( double karma )
		{
			return SelectByKarma (-1, -1, karma );
		}
		
		public long CountByKarma ( double karma )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceStorage e where e.Karma = '{0}'", karma);
		}

		public IList<AllianceStorage> SelectByKarma ( int start, int count, double karma )
		{
			throw new NotImplementedException();
		}
		
 		public IList<AllianceStorage> SelectByTotalMembers ( int totalMembers )
		{
			return SelectByTotalMembers (-1, -1, totalMembers );
		}
		
		public long CountByTotalMembers ( int totalMembers )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceStorage e where e.TotalMembers = '{0}'", totalMembers);
		}

		public IList<AllianceStorage> SelectByTotalMembers ( int start, int count, int totalMembers )
		{
			IList list = Query(start, count, "from SpecializedAllianceStorage e where e.TotalMembers = {0}", totalMembers);
			return ToTypedCollection(list);
		}
		
 		public IList<AllianceStorage> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceStorage e where e.Name = '{0}'", name);
		}

		public IList<AllianceStorage> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedAllianceStorage e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<AllianceStorage> SelectByTag ( string tag )
		{
			return SelectByTag (-1, -1, tag );
		}
		
		public long CountByTag ( string tag )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceStorage e where e.Tag = '{0}'", tag);
		}

		public IList<AllianceStorage> SelectByTag ( int start, int count, string tag )
		{
			IList list = Query(start, count, "from SpecializedAllianceStorage e where e.Tag like '{0}'", tag);
			return ToTypedCollection(list);
		}
		
 		public IList<AllianceStorage> SelectByDescription ( string description )
		{
			return SelectByDescription (-1, -1, description );
		}
		
		public long CountByDescription ( string description )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceStorage e where e.Description = '{0}'", description);
		}

		public IList<AllianceStorage> SelectByDescription ( int start, int count, string description )
		{
			IList list = Query(start, count, "from SpecializedAllianceStorage e where e.Description like '{0}'", description);
			return ToTypedCollection(list);
		}
		
 		public IList<AllianceStorage> SelectByLanguage ( string language )
		{
			return SelectByLanguage (-1, -1, language );
		}
		
		public long CountByLanguage ( string language )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceStorage e where e.Language = '{0}'", language);
		}

		public IList<AllianceStorage> SelectByLanguage ( int start, int count, string language )
		{
			IList list = Query(start, count, "from SpecializedAllianceStorage e where e.Language like '{0}'", language);
			return ToTypedCollection(list);
		}
		
 		public IList<AllianceStorage> SelectByOrions ( int orions )
		{
			return SelectByOrions (-1, -1, orions );
		}
		
		public long CountByOrions ( int orions )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceStorage e where e.Orions = '{0}'", orions);
		}

		public IList<AllianceStorage> SelectByOrions ( int start, int count, int orions )
		{
			IList list = Query(start, count, "from SpecializedAllianceStorage e where e.Orions = {0}", orions);
			return ToTypedCollection(list);
		}
		
 		public IList<AllianceStorage> SelectByOpenToNewMembers ( bool openToNewMembers )
		{
			return SelectByOpenToNewMembers (-1, -1, openToNewMembers );
		}
		
		public long CountByOpenToNewMembers ( bool openToNewMembers )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceStorage e where e.OpenToNewMembers = '{0}'", openToNewMembers);
		}

		public IList<AllianceStorage> SelectByOpenToNewMembers ( int start, int count, bool openToNewMembers )
		{
			IList list = Query(start, count, "from SpecializedAllianceStorage e where e.OpenToNewMembers = {0}", openToNewMembers);
			return ToTypedCollection(list);
		}
		
 		public IList<AllianceStorage> SelectByTotalRelics ( int totalRelics )
		{
			return SelectByTotalRelics (-1, -1, totalRelics );
		}
		
		public long CountByTotalRelics ( int totalRelics )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceStorage e where e.TotalRelics = '{0}'", totalRelics);
		}

		public IList<AllianceStorage> SelectByTotalRelics ( int start, int count, int totalRelics )
		{
			IList list = Query(start, count, "from SpecializedAllianceStorage e where e.TotalRelics = {0}", totalRelics);
			return ToTypedCollection(list);
		}
		
 		public IList<AllianceStorage> SelectByTotalRelicsIncome ( int totalRelicsIncome )
		{
			return SelectByTotalRelicsIncome (-1, -1, totalRelicsIncome );
		}
		
		public long CountByTotalRelicsIncome ( int totalRelicsIncome )
		{
			return ExecuteScalar("select count(*) from SpecializedAllianceStorage e where e.TotalRelicsIncome = '{0}'", totalRelicsIncome);
		}

		public IList<AllianceStorage> SelectByTotalRelicsIncome ( int start, int count, int totalRelicsIncome )
		{
			IList list = Query(start, count, "from SpecializedAllianceStorage e where e.TotalRelicsIncome = {0}", totalRelicsIncome);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistanceStateless<T> owner ) where T : AllianceStorage
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfTag );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfDescription );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfLanguage );
        }
		public static LifecyleVeto ValidateMaxSizeOfName ( AllianceStorage e ) 
        {
			return ValidateStringMaxSize( "AllianceStorage", "Name", e.Name, 200 );
		}
		public static LifecyleVeto ValidateMaxSizeOfTag ( AllianceStorage e ) 
        {
			return ValidateStringMaxSize( "AllianceStorage", "Tag", e.Tag, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfDescription ( AllianceStorage e ) 
        {
			return ValidateStringMaxSize( "AllianceStorage", "Description", e.Description, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfLanguage ( AllianceStorage e ) 
        {
			return ValidateStringMaxSize( "AllianceStorage", "Language", e.Language, 100 );
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
