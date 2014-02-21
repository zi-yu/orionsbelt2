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
    /// Edits the Necessity of the Task entity
    /// </summary>
	public class TaskNecessityEditor : 
			NecessityItem, IEntityFieldEditor<Task>, INamingContainer {

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

		#region NecessityItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override Necessity GetSourceFromParent( IDescriptable descriptable )
        {
            Task entity = descriptable as Task;
            if (entity == null) {
                return null;
            }
            return entity.Necessity;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "TaskNecessity";
		}
		
		#endregion Control unique identifier
		
		#endregion NecessityItem Implementation
		

		#region IEntityFieldEditor<Necessity> Implementation
		
		/// <summary>
        /// Updates an Task
        /// </summary>
        /// <param name="entity">An instance of Task</param>
		public void Update( Task entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Necessity = Current;
		}
		
		#endregion IEntityFieldEditor<Necessity> Implementation
		
	};

}
