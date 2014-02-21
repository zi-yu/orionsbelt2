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
    /// Edits the Fleets of the Principal entity
    /// </summary>
	public class PrincipalFleetsEditor : 
			FleetItem, IEntityFieldEditor<Principal>, INamingContainer {

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

		#region IEntityFieldEditor<Fleet> Implementation
		
		/// <summary>
        /// Updates an Principal
        /// </summary>
        /// <param name="entity">An instance of Principal</param>
		public void Update( Principal entity )
		{
			// OneToMany
			System.Collections.Generic.IList<Fleet> list = entity.Fleets;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<Fleet> Implementation
		
	};

}
