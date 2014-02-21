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
    /// Edits the Task of the Asset entity
    /// </summary>
	public class AssetTaskEditor : 
			TaskItem, IEntityFieldEditor<Asset>, INamingContainer {

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

		#region TaskItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override Task GetSourceFromParent( IDescriptable descriptable )
        {
            Asset entity = descriptable as Asset;
            if (entity == null) {
                return null;
            }
            return entity.Task;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "AssetTask";
		}
		
		#endregion Control unique identifier
		
		#endregion TaskItem Implementation
		

		#region IEntityFieldEditor<Task> Implementation
		
		/// <summary>
        /// Updates an Asset
        /// </summary>
        /// <param name="entity">An instance of Asset</param>
		public void Update( Asset entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Task = Current;
		}
		
		#endregion IEntityFieldEditor<Task> Implementation
		
	};

}
