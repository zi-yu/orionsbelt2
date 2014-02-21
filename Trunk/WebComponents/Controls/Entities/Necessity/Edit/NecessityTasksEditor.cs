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
    /// Edits the Tasks of the Necessity entity
    /// </summary>
	public class NecessityTasksEditor : 
			TaskItem, IEntityFieldEditor<Necessity>, INamingContainer {

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

		#region IEntityFieldEditor<Task> Implementation
		
		/// <summary>
        /// Updates an Necessity
        /// </summary>
        /// <param name="entity">An instance of Necessity</param>
		public void Update( Necessity entity )
		{
			// OneToMany
			System.Collections.Generic.IList<Task> list = entity.Tasks;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<Task> Implementation
		
	};

}
