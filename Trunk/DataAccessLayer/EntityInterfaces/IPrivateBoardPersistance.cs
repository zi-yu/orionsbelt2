using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NHibernate;
using NHibernate.Cfg;
using Loki.DataRepresentation;
using OrionsBelt.Core;

namespace OrionsBelt.DataAccessLayer {
	
	/// <summary>
    /// Handles persistance for PrivateBoard objects
    /// </summary>
	public interface IPrivateBoardPersistance : IPersistance<PrivateBoard> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all PrivateBoard based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrivateBoard collection</returns>
		IList<PrivateBoard> SelectById ( int id );

        /// <summary>
        /// Gets the number of PrivateBoard with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all PrivateBoard based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrivateBoard collection</returns>
		IList<PrivateBoard> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all PrivateBoard based on the receiver field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrivateBoard collection</returns>
		IList<PrivateBoard> SelectByReceiver ( int receiver );

        /// <summary>
        /// Gets the number of PrivateBoard with the given receiver
        /// </summary>
        /// <param name="id">The receiver</param>
        /// <returns>The count</returns>
        long CountByReceiver ( int receiver );
        
		/// <summary>
        /// Selects all PrivateBoard based on the receiver field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrivateBoard collection</returns>
		IList<PrivateBoard> SelectByReceiver ( int start, int count, int receiver );
		
 		/// <summary>
        /// Selects all PrivateBoard based on the type field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrivateBoard collection</returns>
		IList<PrivateBoard> SelectByType ( string type );

        /// <summary>
        /// Gets the number of PrivateBoard with the given type
        /// </summary>
        /// <param name="id">The type</param>
        /// <returns>The count</returns>
        long CountByType ( string type );
        
		/// <summary>
        /// Selects all PrivateBoard based on the type field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrivateBoard collection</returns>
		IList<PrivateBoard> SelectByType ( int start, int count, string type );
		
 		/// <summary>
        /// Selects all PrivateBoard based on the message field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrivateBoard collection</returns>
		IList<PrivateBoard> SelectByMessage ( string message );

        /// <summary>
        /// Gets the number of PrivateBoard with the given message
        /// </summary>
        /// <param name="id">The message</param>
        /// <returns>The count</returns>
        long CountByMessage ( string message );
        
		/// <summary>
        /// Selects all PrivateBoard based on the message field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrivateBoard collection</returns>
		IList<PrivateBoard> SelectByMessage ( int start, int count, string message );
		
 		/// <summary>
        /// Selects all PrivateBoard based on the wasRead field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrivateBoard collection</returns>
		IList<PrivateBoard> SelectByWasRead ( bool wasRead );

        /// <summary>
        /// Gets the number of PrivateBoard with the given wasRead
        /// </summary>
        /// <param name="id">The wasRead</param>
        /// <returns>The count</returns>
        long CountByWasRead ( bool wasRead );
        
		/// <summary>
        /// Selects all PrivateBoard based on the wasRead field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrivateBoard collection</returns>
		IList<PrivateBoard> SelectByWasRead ( int start, int count, bool wasRead );
		
 		/// <summary>
        /// Selects all PrivateBoard based on the sender field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The PrivateBoard collection</returns>
		IList<PrivateBoard> SelectBySender ( PlayerStorage sender );

        /// <summary>
        /// Gets the number of PrivateBoard with the given sender
        /// </summary>
        /// <param name="id">The sender</param>
        /// <returns>The count</returns>
        long CountBySender ( PlayerStorage sender );
        
		/// <summary>
        /// Selects all PrivateBoard based on the sender field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The PrivateBoard collection</returns>
		IList<PrivateBoard> SelectBySender ( int start, int count, PlayerStorage sender );
		
 		#endregion ExtendedMethods

	};
}
