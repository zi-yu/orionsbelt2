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
    /// Edits the Points of the PrincipalTournament entity
    /// </summary>
	public class PrincipalTournamentPointsEditor : 
			GroupPointsStorageItem, IEntityFieldEditor<PrincipalTournament>, INamingContainer {

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

		#region IEntityFieldEditor<GroupPointsStorage> Implementation
		
		/// <summary>
        /// Updates an PrincipalTournament
        /// </summary>
        /// <param name="entity">An instance of PrincipalTournament</param>
		public void Update( PrincipalTournament entity )
		{
			// OneToMany
			System.Collections.Generic.IList<GroupPointsStorage> list = entity.Points;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<GroupPointsStorage> Implementation
		
	};

}
