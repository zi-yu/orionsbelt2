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
    /// Edits the Thread of the ForumPost entity
    /// </summary>
	public class ForumPostThreadEditor : 
			ForumThreadItem, IEntityFieldEditor<ForumPost>, INamingContainer {

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

		#region ForumThreadItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override ForumThread GetSourceFromParent( IDescriptable descriptable )
        {
            ForumPost entity = descriptable as ForumPost;
            if (entity == null) {
                return null;
            }
            return entity.Thread;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "ForumPostThread";
		}
		
		#endregion Control unique identifier
		
		#endregion ForumThreadItem Implementation
		

		#region IEntityFieldEditor<ForumThread> Implementation
		
		/// <summary>
        /// Updates an ForumPost
        /// </summary>
        /// <param name="entity">An instance of ForumPost</param>
		public void Update( ForumPost entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Thread = Current;
		}
		
		#endregion IEntityFieldEditor<ForumThread> Implementation
		
	};

}
