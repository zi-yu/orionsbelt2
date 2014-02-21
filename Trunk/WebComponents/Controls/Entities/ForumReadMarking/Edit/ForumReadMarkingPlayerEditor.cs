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
    /// Edits the Player of the ForumReadMarking entity
    /// </summary>
	public class ForumReadMarkingPlayerEditor : 
			PlayerStorageItem, IEntityFieldEditor<ForumReadMarking>, INamingContainer {

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

		#region PlayerStorageItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override PlayerStorage GetSourceFromParent( IDescriptable descriptable )
        {
            ForumReadMarking entity = descriptable as ForumReadMarking;
            if (entity == null) {
                return null;
            }
            return entity.Player;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "ForumReadMarkingPlayer";
		}
		
		#endregion Control unique identifier
		
		#endregion PlayerStorageItem Implementation
		

		#region IEntityFieldEditor<PlayerStorage> Implementation
		
		/// <summary>
        /// Updates an ForumReadMarking
        /// </summary>
        /// <param name="entity">An instance of ForumReadMarking</param>
		public void Update( ForumReadMarking entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Player = Current;
		}
		
		#endregion IEntityFieldEditor<PlayerStorage> Implementation
		
	};

}
