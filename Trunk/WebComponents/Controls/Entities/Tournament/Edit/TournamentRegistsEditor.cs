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
    /// Edits the Regists of the Tournament entity
    /// </summary>
	public class TournamentRegistsEditor : 
			PrincipalTournamentItem, IEntityFieldEditor<Tournament>, INamingContainer {

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

		#region IEntityFieldEditor<PrincipalTournament> Implementation
		
		/// <summary>
        /// Updates an Tournament
        /// </summary>
        /// <param name="entity">An instance of Tournament</param>
		public void Update( Tournament entity )
		{
			// OneToMany
			System.Collections.Generic.IList<PrincipalTournament> list = entity.Regists;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<PrincipalTournament> Implementation
		
	};

}
