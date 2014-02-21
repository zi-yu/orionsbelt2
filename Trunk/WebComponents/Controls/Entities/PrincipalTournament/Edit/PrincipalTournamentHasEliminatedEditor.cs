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
    /// Edits the HasEliminated of the PrincipalTournament entity
    /// </summary>
	public class PrincipalTournamentHasEliminatedEditor : 
				BoolEditor<PrincipalTournament>, INamingContainer {
		
		#region Base Implementation
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit( EventArgs args )
		{
			base.OnInit(args);
			AddValidators();
		}
		
		/// <summary>
        /// Indicates if the boolean is true or false
        /// </summary>
        /// <param name="entity">The PrincipalTournament instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( PrincipalTournament entity )
		{
			return entity.HasEliminated;
		}
		
		/// <summary>
        /// Updates an PrincipalTournament
        /// </summary>
        /// <param name="entity">An instance of PrincipalTournament</param>
		public override void Update( PrincipalTournament entity )
		{
			entity.HasEliminated = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "hasEliminated"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
