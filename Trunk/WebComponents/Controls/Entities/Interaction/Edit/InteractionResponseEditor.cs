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
    /// Edits the Response of the Interaction entity
    /// </summary>
	public class InteractionResponseEditor : 
				BoolEditor<Interaction>, INamingContainer {
		
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
        /// <param name="entity">The Interaction instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( Interaction entity )
		{
			return entity.Response;
		}
		
		/// <summary>
        /// Updates an Interaction
        /// </summary>
        /// <param name="entity">An instance of Interaction</param>
		public override void Update( Interaction entity )
		{
			entity.Response = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "response"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
