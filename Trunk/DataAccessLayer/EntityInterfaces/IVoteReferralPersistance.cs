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
    /// Handles persistance for VoteReferral objects
    /// </summary>
	public interface IVoteReferralPersistance : IPersistance<VoteReferral> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all VoteReferral based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectById ( int id );

        /// <summary>
        /// Gets the number of VoteReferral with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all VoteReferral based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all VoteReferral based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectByName ( string name );

        /// <summary>
        /// Gets the number of VoteReferral with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all VoteReferral based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all VoteReferral based on the shortName field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectByShortName ( string shortName );

        /// <summary>
        /// Gets the number of VoteReferral with the given shortName
        /// </summary>
        /// <param name="id">The shortName</param>
        /// <returns>The count</returns>
        long CountByShortName ( string shortName );
        
		/// <summary>
        /// Selects all VoteReferral based on the shortName field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectByShortName ( int start, int count, string shortName );
		
 		/// <summary>
        /// Selects all VoteReferral based on the url field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectByUrl ( string url );

        /// <summary>
        /// Gets the number of VoteReferral with the given url
        /// </summary>
        /// <param name="id">The url</param>
        /// <returns>The count</returns>
        long CountByUrl ( string url );
        
		/// <summary>
        /// Selects all VoteReferral based on the url field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectByUrl ( int start, int count, string url );
		
 		/// <summary>
        /// Selects all VoteReferral based on the imageUrl field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectByImageUrl ( string imageUrl );

        /// <summary>
        /// Gets the number of VoteReferral with the given imageUrl
        /// </summary>
        /// <param name="id">The imageUrl</param>
        /// <returns>The count</returns>
        long CountByImageUrl ( string imageUrl );
        
		/// <summary>
        /// Selects all VoteReferral based on the imageUrl field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectByImageUrl ( int start, int count, string imageUrl );
		
 		/// <summary>
        /// Selects all VoteReferral based on the reward field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectByReward ( string reward );

        /// <summary>
        /// Gets the number of VoteReferral with the given reward
        /// </summary>
        /// <param name="id">The reward</param>
        /// <returns>The count</returns>
        long CountByReward ( string reward );
        
		/// <summary>
        /// Selects all VoteReferral based on the reward field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectByReward ( int start, int count, string reward );
		
 		/// <summary>
        /// Selects all VoteReferral based on the clickCount field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectByClickCount ( int clickCount );

        /// <summary>
        /// Gets the number of VoteReferral with the given clickCount
        /// </summary>
        /// <param name="id">The clickCount</param>
        /// <returns>The count</returns>
        long CountByClickCount ( int clickCount );
        
		/// <summary>
        /// Selects all VoteReferral based on the clickCount field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectByClickCount ( int start, int count, int clickCount );
		
 		/// <summary>
        /// Selects all VoteReferral based on the voteOrder field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectByVoteOrder ( int voteOrder );

        /// <summary>
        /// Gets the number of VoteReferral with the given voteOrder
        /// </summary>
        /// <param name="id">The voteOrder</param>
        /// <returns>The count</returns>
        long CountByVoteOrder ( int voteOrder );
        
		/// <summary>
        /// Selects all VoteReferral based on the voteOrder field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The VoteReferral collection</returns>
		IList<VoteReferral> SelectByVoteOrder ( int start, int count, int voteOrder );
		
 		#endregion ExtendedMethods

	};
}
