using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using Institutional.Core;

namespace Institutional.DataAccessLayer {
	
	/// <summary>
    /// Handles persistance for Principal objects
    /// </summary>
	public interface IPrincipalPersistance : IPersistance<Principal> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Principal based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectById ( int id );

        /// <summary>
        /// Gets the number of Principal with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Principal based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Principal based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByName ( string name );

        /// <summary>
        /// Gets the number of Principal with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all Principal based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all Principal based on the password field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByPassword ( string password );

        /// <summary>
        /// Gets the number of Principal with the given password
        /// </summary>
        /// <param name="id">The password</param>
        /// <returns>The count</returns>
        long CountByPassword ( string password );
        
		/// <summary>
        /// Selects all Principal based on the password field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByPassword ( int start, int count, string password );
		
 		/// <summary>
        /// Selects all Principal based on the email field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByEmail ( string email );

        /// <summary>
        /// Gets the number of Principal with the given email
        /// </summary>
        /// <param name="id">The email</param>
        /// <returns>The count</returns>
        long CountByEmail ( string email );
        
		/// <summary>
        /// Selects all Principal based on the email field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByEmail ( int start, int count, string email );
		
 		/// <summary>
        /// Selects all Principal based on the ip field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByIp ( string ip );

        /// <summary>
        /// Gets the number of Principal with the given ip
        /// </summary>
        /// <param name="id">The ip</param>
        /// <returns>The count</returns>
        long CountByIp ( string ip );
        
		/// <summary>
        /// Selects all Principal based on the ip field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByIp ( int start, int count, string ip );
		
 		/// <summary>
        /// Selects all Principal based on the registDate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByRegistDate ( DateTime registDate );

        /// <summary>
        /// Gets the number of Principal with the given registDate
        /// </summary>
        /// <param name="id">The registDate</param>
        /// <returns>The count</returns>
        long CountByRegistDate ( DateTime registDate );
        
		/// <summary>
        /// Selects all Principal based on the registDate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByRegistDate ( int start, int count, DateTime registDate );
		
 		/// <summary>
        /// Selects all Principal based on the lastLogin field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLastLogin ( DateTime lastLogin );

        /// <summary>
        /// Gets the number of Principal with the given lastLogin
        /// </summary>
        /// <param name="id">The lastLogin</param>
        /// <returns>The count</returns>
        long CountByLastLogin ( DateTime lastLogin );
        
		/// <summary>
        /// Selects all Principal based on the lastLogin field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLastLogin ( int start, int count, DateTime lastLogin );
		
 		/// <summary>
        /// Selects all Principal based on the approved field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByApproved ( bool approved );

        /// <summary>
        /// Gets the number of Principal with the given approved
        /// </summary>
        /// <param name="id">The approved</param>
        /// <returns>The count</returns>
        long CountByApproved ( bool approved );
        
		/// <summary>
        /// Selects all Principal based on the approved field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByApproved ( int start, int count, bool approved );
		
 		/// <summary>
        /// Selects all Principal based on the isOnline field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByIsOnline ( bool isOnline );

        /// <summary>
        /// Gets the number of Principal with the given isOnline
        /// </summary>
        /// <param name="id">The isOnline</param>
        /// <returns>The count</returns>
        long CountByIsOnline ( bool isOnline );
        
		/// <summary>
        /// Selects all Principal based on the isOnline field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByIsOnline ( int start, int count, bool isOnline );
		
 		/// <summary>
        /// Selects all Principal based on the locked field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLocked ( bool locked );

        /// <summary>
        /// Gets the number of Principal with the given locked
        /// </summary>
        /// <param name="id">The locked</param>
        /// <returns>The count</returns>
        long CountByLocked ( bool locked );
        
		/// <summary>
        /// Selects all Principal based on the locked field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLocked ( int start, int count, bool locked );
		
 		/// <summary>
        /// Selects all Principal based on the locale field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLocale ( string locale );

        /// <summary>
        /// Gets the number of Principal with the given locale
        /// </summary>
        /// <param name="id">The locale</param>
        /// <returns>The count</returns>
        long CountByLocale ( string locale );
        
		/// <summary>
        /// Selects all Principal based on the locale field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByLocale ( int start, int count, string locale );
		
 		/// <summary>
        /// Selects all Principal based on the confirmationCode field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByConfirmationCode ( string confirmationCode );

        /// <summary>
        /// Gets the number of Principal with the given confirmationCode
        /// </summary>
        /// <param name="id">The confirmationCode</param>
        /// <returns>The count</returns>
        long CountByConfirmationCode ( string confirmationCode );
        
		/// <summary>
        /// Selects all Principal based on the confirmationCode field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByConfirmationCode ( int start, int count, string confirmationCode );
		
 		/// <summary>
        /// Selects all Principal based on the rawRoles field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByRawRoles ( string rawRoles );

        /// <summary>
        /// Gets the number of Principal with the given rawRoles
        /// </summary>
        /// <param name="id">The rawRoles</param>
        /// <returns>The count</returns>
        long CountByRawRoles ( string rawRoles );
        
		/// <summary>
        /// Selects all Principal based on the rawRoles field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Principal collection</returns>
		IList<Principal> SelectByRawRoles ( int start, int count, string rawRoles );
		
 		#endregion ExtendedMethods

	};
}
