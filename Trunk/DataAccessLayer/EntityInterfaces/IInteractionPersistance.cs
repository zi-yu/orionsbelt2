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
    /// Handles persistance for Interaction objects
    /// </summary>
	public interface IInteractionPersistance : IPersistance<Interaction> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all Interaction based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectById ( int id );

        /// <summary>
        /// Gets the number of Interaction with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all Interaction based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all Interaction based on the source field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectBySource ( int source );

        /// <summary>
        /// Gets the number of Interaction with the given source
        /// </summary>
        /// <param name="id">The source</param>
        /// <returns>The count</returns>
        long CountBySource ( int source );
        
		/// <summary>
        /// Selects all Interaction based on the source field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectBySource ( int start, int count, int source );
		
 		/// <summary>
        /// Selects all Interaction based on the target field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByTarget ( int target );

        /// <summary>
        /// Gets the number of Interaction with the given target
        /// </summary>
        /// <param name="id">The target</param>
        /// <returns>The count</returns>
        long CountByTarget ( int target );
        
		/// <summary>
        /// Selects all Interaction based on the target field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByTarget ( int start, int count, int target );
		
 		/// <summary>
        /// Selects all Interaction based on the type field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByType ( string type );

        /// <summary>
        /// Gets the number of Interaction with the given type
        /// </summary>
        /// <param name="id">The type</param>
        /// <returns>The count</returns>
        long CountByType ( string type );
        
		/// <summary>
        /// Selects all Interaction based on the type field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByType ( int start, int count, string type );
		
 		/// <summary>
        /// Selects all Interaction based on the response field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByResponse ( bool response );

        /// <summary>
        /// Gets the number of Interaction with the given response
        /// </summary>
        /// <param name="id">The response</param>
        /// <returns>The count</returns>
        long CountByResponse ( bool response );
        
		/// <summary>
        /// Selects all Interaction based on the response field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByResponse ( int start, int count, bool response );
		
 		/// <summary>
        /// Selects all Interaction based on the responseExtension field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByResponseExtension ( string responseExtension );

        /// <summary>
        /// Gets the number of Interaction with the given responseExtension
        /// </summary>
        /// <param name="id">The responseExtension</param>
        /// <returns>The count</returns>
        long CountByResponseExtension ( string responseExtension );
        
		/// <summary>
        /// Selects all Interaction based on the responseExtension field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByResponseExtension ( int start, int count, string responseExtension );
		
 		/// <summary>
        /// Selects all Interaction based on the interactionContext field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByInteractionContext ( string interactionContext );

        /// <summary>
        /// Gets the number of Interaction with the given interactionContext
        /// </summary>
        /// <param name="id">The interactionContext</param>
        /// <returns>The count</returns>
        long CountByInteractionContext ( string interactionContext );
        
		/// <summary>
        /// Selects all Interaction based on the interactionContext field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByInteractionContext ( int start, int count, string interactionContext );
		
 		/// <summary>
        /// Selects all Interaction based on the resolved field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByResolved ( bool resolved );

        /// <summary>
        /// Gets the number of Interaction with the given resolved
        /// </summary>
        /// <param name="id">The resolved</param>
        /// <returns>The count</returns>
        long CountByResolved ( bool resolved );
        
		/// <summary>
        /// Selects all Interaction based on the resolved field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByResolved ( int start, int count, bool resolved );
		
 		/// <summary>
        /// Selects all Interaction based on the sourceAditionalData field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectBySourceAditionalData ( string sourceAditionalData );

        /// <summary>
        /// Gets the number of Interaction with the given sourceAditionalData
        /// </summary>
        /// <param name="id">The sourceAditionalData</param>
        /// <returns>The count</returns>
        long CountBySourceAditionalData ( string sourceAditionalData );
        
		/// <summary>
        /// Selects all Interaction based on the sourceAditionalData field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectBySourceAditionalData ( int start, int count, string sourceAditionalData );
		
 		/// <summary>
        /// Selects all Interaction based on the targetAditionalData field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByTargetAditionalData ( string targetAditionalData );

        /// <summary>
        /// Gets the number of Interaction with the given targetAditionalData
        /// </summary>
        /// <param name="id">The targetAditionalData</param>
        /// <returns>The count</returns>
        long CountByTargetAditionalData ( string targetAditionalData );
        
		/// <summary>
        /// Selects all Interaction based on the targetAditionalData field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByTargetAditionalData ( int start, int count, string targetAditionalData );
		
 		/// <summary>
        /// Selects all Interaction based on the sourceType field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectBySourceType ( string sourceType );

        /// <summary>
        /// Gets the number of Interaction with the given sourceType
        /// </summary>
        /// <param name="id">The sourceType</param>
        /// <returns>The count</returns>
        long CountBySourceType ( string sourceType );
        
		/// <summary>
        /// Selects all Interaction based on the sourceType field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectBySourceType ( int start, int count, string sourceType );
		
 		/// <summary>
        /// Selects all Interaction based on the targetType field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByTargetType ( string targetType );

        /// <summary>
        /// Gets the number of Interaction with the given targetType
        /// </summary>
        /// <param name="id">The targetType</param>
        /// <returns>The count</returns>
        long CountByTargetType ( string targetType );
        
		/// <summary>
        /// Selects all Interaction based on the targetType field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The Interaction collection</returns>
		IList<Interaction> SelectByTargetType ( int start, int count, string targetType );
		
 		#endregion ExtendedMethods

	};
}
