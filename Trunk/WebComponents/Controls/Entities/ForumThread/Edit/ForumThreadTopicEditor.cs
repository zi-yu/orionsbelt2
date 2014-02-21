using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Edits the Topic of the ForumThread entity
    /// </summary>
	public class ForumThreadTopicEditor : 
			ForumTopicItem, IEntityFieldEditor<ForumThread>, INamingContainer {

		#region Events
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit(EventArgs args)
        {
			if( Source == SourceType.None ) {
				Source = SourceType.Choice;
			}
            base.OnInit(args);
        }
		
		#endregion Events

		#region ForumTopicItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override ForumTopic GetSourceFromParent( IDescriptable descriptable )
        {
            ForumThread entity = descriptable as ForumThread;
            if (entity == null) {
                return null;
            }
            return entity.Topic;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "ForumThreadTopic";
		}
		
		#endregion Control unique identifier
		
		#endregion ForumTopicItem Implementation
		

		#region IEntityFieldEditor<ForumTopic> Implementation
		
		/// <summary>
        /// Updates an ForumThread
        /// </summary>
        /// <param name="entity">An instance of ForumThread</param>
		public void Update( ForumThread entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Topic = Current;
		}
		
		#endregion IEntityFieldEditor<ForumTopic> Implementation
		
	};

}
