using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using Institutional.Core;

namespace Institutional.DataAccessLayer {
	
	internal class PrincipalPersistance : 
			NHibernatePersistance<Principal>, IPrincipalPersistance {
	
		#region Static Access
		
		internal static PrincipalPersistance CreateSession()
		{
			return new PrincipalPersistance ( NHibernateUtilities.OpenSession, typeof(SpecializedPrincipal) );
		}
				
		internal static PrincipalPersistance AttachSession( IPersistanceSession owner )
		{
			PrincipalPersistance persistance = new PrincipalPersistance ( owner.Session as ISession, typeof(SpecializedPrincipal) );
			persistance.Attached = owner;
			return persistance;
		}
		
		private static PrincipalPersistance globalSession = null;
        internal static PrincipalPersistance GlobalSession {
            get {
                if (globalSession == null || !NHibernateUtilities.IsSessionOpen(globalSession.NHibernateSession)) {
                    globalSession = CreateSession();
                }
                return globalSession;
            }
        }
		
		internal static PrincipalPersistance GetSession()
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
		
		internal static PrincipalPersistance GetValidatedSession()
        {
            PrincipalPersistance persistance = GetSession();
            AddValidation(persistance);
            return persistance;
        }
		
		#endregion
		
		#region Ctor and Fields
		
		private PrincipalPersistance ( ISession currSession, Type type ) 
			: base(currSession, type) 
		{
		}
		
		#endregion Ctor and Fields
		
		#region IPersistance
		
		public override Principal Create()
		{	
			SpecializedPrincipal entity = new SpecializedPrincipal ();
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
		
 		public IList<Principal> SelectById ( int id )
		{
			return SelectById (-1, -1, id );
		}
		
		public long CountById ( int id )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Id = '{0}'", id);
		}

		public IList<Principal> SelectById ( int start, int count, int id )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Id = {0}", id);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByName ( string name )
		{
			return SelectByName (-1, -1, name );
		}
		
		public long CountByName ( string name )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Name = '{0}'", name);
		}

		public IList<Principal> SelectByName ( int start, int count, string name )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Name like '{0}'", name);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByPassword ( string password )
		{
			return SelectByPassword (-1, -1, password );
		}
		
		public long CountByPassword ( string password )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Password = '{0}'", password);
		}

		public IList<Principal> SelectByPassword ( int start, int count, string password )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Password like '{0}'", password);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByEmail ( string email )
		{
			return SelectByEmail (-1, -1, email );
		}
		
		public long CountByEmail ( string email )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Email = '{0}'", email);
		}

		public IList<Principal> SelectByEmail ( int start, int count, string email )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Email like '{0}'", email);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByIp ( string ip )
		{
			return SelectByIp (-1, -1, ip );
		}
		
		public long CountByIp ( string ip )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Ip = '{0}'", ip);
		}

		public IList<Principal> SelectByIp ( int start, int count, string ip )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Ip like '{0}'", ip);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByRegistDate ( DateTime registDate )
		{
			return SelectByRegistDate (-1, -1, registDate );
		}
		
		public long CountByRegistDate ( DateTime registDate )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.RegistDate = '{0}'", registDate);
		}

		public IList<Principal> SelectByRegistDate ( int start, int count, DateTime registDate )
		{
			throw new NotImplementedException();
		}
		
 		public IList<Principal> SelectByLastLogin ( DateTime lastLogin )
		{
			return SelectByLastLogin (-1, -1, lastLogin );
		}
		
		public long CountByLastLogin ( DateTime lastLogin )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.LastLogin = '{0}'", lastLogin);
		}

		public IList<Principal> SelectByLastLogin ( int start, int count, DateTime lastLogin )
		{
			throw new NotImplementedException();
		}
		
 		public IList<Principal> SelectByApproved ( bool approved )
		{
			return SelectByApproved (-1, -1, approved );
		}
		
		public long CountByApproved ( bool approved )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Approved = '{0}'", approved);
		}

		public IList<Principal> SelectByApproved ( int start, int count, bool approved )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Approved = {0}", approved);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByIsOnline ( bool isOnline )
		{
			return SelectByIsOnline (-1, -1, isOnline );
		}
		
		public long CountByIsOnline ( bool isOnline )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.IsOnline = '{0}'", isOnline);
		}

		public IList<Principal> SelectByIsOnline ( int start, int count, bool isOnline )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.IsOnline = {0}", isOnline);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByLocked ( bool locked )
		{
			return SelectByLocked (-1, -1, locked );
		}
		
		public long CountByLocked ( bool locked )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Locked = '{0}'", locked);
		}

		public IList<Principal> SelectByLocked ( int start, int count, bool locked )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Locked = {0}", locked);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByLocale ( string locale )
		{
			return SelectByLocale (-1, -1, locale );
		}
		
		public long CountByLocale ( string locale )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.Locale = '{0}'", locale);
		}

		public IList<Principal> SelectByLocale ( int start, int count, string locale )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.Locale like '{0}'", locale);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByConfirmationCode ( string confirmationCode )
		{
			return SelectByConfirmationCode (-1, -1, confirmationCode );
		}
		
		public long CountByConfirmationCode ( string confirmationCode )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.ConfirmationCode = '{0}'", confirmationCode);
		}

		public IList<Principal> SelectByConfirmationCode ( int start, int count, string confirmationCode )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.ConfirmationCode like '{0}'", confirmationCode);
			return ToTypedCollection(list);
		}
		
 		public IList<Principal> SelectByRawRoles ( string rawRoles )
		{
			return SelectByRawRoles (-1, -1, rawRoles );
		}
		
		public long CountByRawRoles ( string rawRoles )
		{
			return ExecuteScalar("select count(*) from SpecializedPrincipal e where e.RawRoles = '{0}'", rawRoles);
		}

		public IList<Principal> SelectByRawRoles ( int start, int count, string rawRoles )
		{
			IList list = Query(start, count, "from SpecializedPrincipal e where e.RawRoles like '{0}'", rawRoles);
			return ToTypedCollection(list);
		}
		
 		#endregion ExtendedMethods
		
		#region Validation
		
        public static void AddValidation<T>( NHibernatePersistance<T> owner ) where T : Principal
        {
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfPassword );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfEmail );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfRegistDate );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfLastLogin );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfApproved );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfLocale );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateExistenceOfConfirmationCode );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfPassword );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfEmail );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfIp );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfLocale );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfConfirmationCode );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateMaxSizeOfRawRoles );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateUniquenessOfName );
			owner.UpdateEvent += new Lifecycle<T>.ActionEvent( ValidateUniquenessOfEmail );
        }
		public static LifecyleVeto ValidateExistenceOfName ( Principal e ) 
        {
            if( string.IsNullOrEmpty( e.Name ) ) {
				throw new DALException("Entity `{0}' must have a value for property `Name'", e.TypeName);
            }
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfPassword ( Principal e ) 
        {
            if( string.IsNullOrEmpty( e.Password ) ) {
				throw new DALException("Entity `{0}' must have a value for property `Password'", e.TypeName);
            }
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfEmail ( Principal e ) 
        {
            if( string.IsNullOrEmpty( e.Email ) ) {
				throw new DALException("Entity `{0}' must have a value for property `Email'", e.TypeName);
            }
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfRegistDate ( Principal e ) 
        {
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfLastLogin ( Principal e ) 
        {
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfApproved ( Principal e ) 
        {
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfLocale ( Principal e ) 
        {
            if( string.IsNullOrEmpty( e.Locale ) ) {
				throw new DALException("Entity `{0}' must have a value for property `Locale'", e.TypeName);
            }
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateExistenceOfConfirmationCode ( Principal e ) 
        {
            if( string.IsNullOrEmpty( e.ConfirmationCode ) ) {
				throw new DALException("Entity `{0}' must have a value for property `ConfirmationCode'", e.TypeName);
            }
            return LifecyleVeto.Continue;
        }
		
		public static LifecyleVeto ValidateMaxSizeOfName ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "Name", e.Name, 200 );
		}
		public static LifecyleVeto ValidateMaxSizeOfPassword ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "Password", e.Password, 50 );
		}
		public static LifecyleVeto ValidateMaxSizeOfEmail ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "Email", e.Email, 200 );
		}
		public static LifecyleVeto ValidateMaxSizeOfIp ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "Ip", e.Ip, 15 );
		}
		public static LifecyleVeto ValidateMaxSizeOfLocale ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "Locale", e.Locale, 6 );
		}
		public static LifecyleVeto ValidateMaxSizeOfConfirmationCode ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "ConfirmationCode", e.ConfirmationCode, 100 );
		}
		public static LifecyleVeto ValidateMaxSizeOfRawRoles ( Principal e ) 
        {
			return ValidateStringMaxSize( "Principal", "RawRoles", e.RawRoles, 250 );
		}
		public static LifecyleVeto ValidateUniquenessOfName ( Principal e ) 
        {
			PrincipalPersistance persistance = GetSession();
			if( persistance.SelectByName ( e.Name ).Count == 0 ) {
				return LifecyleVeto.Continue;
			}
			throw new DALException("There's already and entity `{0}' with property `Name' with the value `{1}' on the database (this property is marked as unique)", e.TypeName, e.Name);
		}
		public static LifecyleVeto ValidateUniquenessOfEmail ( Principal e ) 
        {
			PrincipalPersistance persistance = GetSession();
			if( persistance.SelectByEmail ( e.Email ).Count == 0 ) {
				return LifecyleVeto.Continue;
			}
			throw new DALException("There's already and entity `{0}' with property `Email' with the value `{1}' on the database (this property is marked as unique)", e.TypeName, e.Email);
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
