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
    /// Edits the IsAuto of the Medal entity
    /// </summary>
	public class MedalIsAutoEditor : 
				BoolEditor<Medal>, INamingContainer {
		
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
        /// <param name="entity">The Medal instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( Medal entity )
		{
			return entity.IsAuto;
		}
		
		/// <summary>
        /// Updates an Medal
        /// </summary>
        /// <param name="entity">An instance of Medal</param>
		public override void Update( Medal entity )
		{
			entity.IsAuto = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "isAuto"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
