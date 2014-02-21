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
    /// Handles persistance for QuestStorage objects
    /// </summary>
	public interface IQuestStoragePersistance : IPersistance<QuestStorage> {
		
		#region ExtendedMethods
		
 		/// <summary>
        /// Selects all QuestStorage based on the id field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectById ( int id );

        /// <summary>
        /// Gets the number of QuestStorage with the given id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The count</returns>
        long CountById ( int id );
        
		/// <summary>
        /// Selects all QuestStorage based on the id field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectById ( int start, int count, int id );
		
 		/// <summary>
        /// Selects all QuestStorage based on the percentage field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByPercentage ( double percentage );

        /// <summary>
        /// Gets the number of QuestStorage with the given percentage
        /// </summary>
        /// <param name="id">The percentage</param>
        /// <returns>The count</returns>
        long CountByPercentage ( double percentage );
        
		/// <summary>
        /// Selects all QuestStorage based on the percentage field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByPercentage ( int start, int count, double percentage );
		
 		/// <summary>
        /// Selects all QuestStorage based on the isTemplate field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByIsTemplate ( bool isTemplate );

        /// <summary>
        /// Gets the number of QuestStorage with the given isTemplate
        /// </summary>
        /// <param name="id">The isTemplate</param>
        /// <returns>The count</returns>
        long CountByIsTemplate ( bool isTemplate );
        
		/// <summary>
        /// Selects all QuestStorage based on the isTemplate field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByIsTemplate ( int start, int count, bool isTemplate );
		
 		/// <summary>
        /// Selects all QuestStorage based on the name field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByName ( string name );

        /// <summary>
        /// Gets the number of QuestStorage with the given name
        /// </summary>
        /// <param name="id">The name</param>
        /// <returns>The count</returns>
        long CountByName ( string name );
        
		/// <summary>
        /// Selects all QuestStorage based on the name field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByName ( int start, int count, string name );
		
 		/// <summary>
        /// Selects all QuestStorage based on the type field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByType ( string type );

        /// <summary>
        /// Gets the number of QuestStorage with the given type
        /// </summary>
        /// <param name="id">The type</param>
        /// <returns>The count</returns>
        long CountByType ( string type );
        
		/// <summary>
        /// Selects all QuestStorage based on the type field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByType ( int start, int count, string type );
		
 		/// <summary>
        /// Selects all QuestStorage based on the deadlineTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByDeadlineTick ( int deadlineTick );

        /// <summary>
        /// Gets the number of QuestStorage with the given deadlineTick
        /// </summary>
        /// <param name="id">The deadlineTick</param>
        /// <returns>The count</returns>
        long CountByDeadlineTick ( int deadlineTick );
        
		/// <summary>
        /// Selects all QuestStorage based on the deadlineTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByDeadlineTick ( int start, int count, int deadlineTick );
		
 		/// <summary>
        /// Selects all QuestStorage based on the startTick field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByStartTick ( int startTick );

        /// <summary>
        /// Gets the number of QuestStorage with the given startTick
        /// </summary>
        /// <param name="id">The startTick</param>
        /// <returns>The count</returns>
        long CountByStartTick ( int startTick );
        
		/// <summary>
        /// Selects all QuestStorage based on the startTick field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByStartTick ( int start, int count, int startTick );
		
 		/// <summary>
        /// Selects all QuestStorage based on the reward field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByReward ( string reward );

        /// <summary>
        /// Gets the number of QuestStorage with the given reward
        /// </summary>
        /// <param name="id">The reward</param>
        /// <returns>The count</returns>
        long CountByReward ( string reward );
        
		/// <summary>
        /// Selects all QuestStorage based on the reward field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByReward ( int start, int count, string reward );
		
 		/// <summary>
        /// Selects all QuestStorage based on the questStringConfig field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByQuestStringConfig ( string questStringConfig );

        /// <summary>
        /// Gets the number of QuestStorage with the given questStringConfig
        /// </summary>
        /// <param name="id">The questStringConfig</param>
        /// <returns>The count</returns>
        long CountByQuestStringConfig ( string questStringConfig );
        
		/// <summary>
        /// Selects all QuestStorage based on the questStringConfig field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByQuestStringConfig ( int start, int count, string questStringConfig );
		
 		/// <summary>
        /// Selects all QuestStorage based on the questIntConfig field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByQuestIntConfig ( string questIntConfig );

        /// <summary>
        /// Gets the number of QuestStorage with the given questIntConfig
        /// </summary>
        /// <param name="id">The questIntConfig</param>
        /// <returns>The count</returns>
        long CountByQuestIntConfig ( string questIntConfig );
        
		/// <summary>
        /// Selects all QuestStorage based on the questIntConfig field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByQuestIntConfig ( int start, int count, string questIntConfig );
		
 		/// <summary>
        /// Selects all QuestStorage based on the questIntProgress field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByQuestIntProgress ( string questIntProgress );

        /// <summary>
        /// Gets the number of QuestStorage with the given questIntProgress
        /// </summary>
        /// <param name="id">The questIntProgress</param>
        /// <returns>The count</returns>
        long CountByQuestIntProgress ( string questIntProgress );
        
		/// <summary>
        /// Selects all QuestStorage based on the questIntProgress field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByQuestIntProgress ( int start, int count, string questIntProgress );
		
 		/// <summary>
        /// Selects all QuestStorage based on the questStringProgress field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByQuestStringProgress ( string questStringProgress );

        /// <summary>
        /// Gets the number of QuestStorage with the given questStringProgress
        /// </summary>
        /// <param name="id">The questStringProgress</param>
        /// <returns>The count</returns>
        long CountByQuestStringProgress ( string questStringProgress );
        
		/// <summary>
        /// Selects all QuestStorage based on the questStringProgress field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByQuestStringProgress ( int start, int count, string questStringProgress );
		
 		/// <summary>
        /// Selects all QuestStorage based on the completed field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByCompleted ( bool completed );

        /// <summary>
        /// Gets the number of QuestStorage with the given completed
        /// </summary>
        /// <param name="id">The completed</param>
        /// <returns>The count</returns>
        long CountByCompleted ( bool completed );
        
		/// <summary>
        /// Selects all QuestStorage based on the completed field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByCompleted ( int start, int count, bool completed );
		
 		/// <summary>
        /// Selects all QuestStorage based on the isProgressive field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByIsProgressive ( bool isProgressive );

        /// <summary>
        /// Gets the number of QuestStorage with the given isProgressive
        /// </summary>
        /// <param name="id">The isProgressive</param>
        /// <returns>The count</returns>
        long CountByIsProgressive ( bool isProgressive );
        
		/// <summary>
        /// Selects all QuestStorage based on the isProgressive field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByIsProgressive ( int start, int count, bool isProgressive );
		
 		/// <summary>
        /// Selects all QuestStorage based on the player field
        /// </summary>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByPlayer ( PlayerStorage player );

        /// <summary>
        /// Gets the number of QuestStorage with the given player
        /// </summary>
        /// <param name="id">The player</param>
        /// <returns>The count</returns>
        long CountByPlayer ( PlayerStorage player );
        
		/// <summary>
        /// Selects all QuestStorage based on the player field
        /// </summary>
        /// <param name="start">The first element</param>
        /// <param name="count">The number of elements</param>
        /// <param name="text">The field</param>
        /// <returns>The QuestStorage collection</returns>
		IList<QuestStorage> SelectByPlayer ( int start, int count, PlayerStorage player );
		
 		#endregion ExtendedMethods

	};
}
