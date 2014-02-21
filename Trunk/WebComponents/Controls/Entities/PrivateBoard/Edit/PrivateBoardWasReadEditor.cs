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
    /// Edits the WasRead of the PrivateBoard entity
    /// </summary>
	public class PrivateBoardWasReadEditor : 
				BoolEditor<PrivateBoard>, INamingContainer {
		
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
        /// <param name="entity">The PrivateBoard instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( PrivateBoard entity )
		{
			return entity.WasRead;
		}
		
		/// <summary>
        /// Updates an PrivateBoard
        /// </summary>
        /// <param name="entity">An instance of PrivateBoard</param>
		public override void Update( PrivateBoard entity )
		{
			entity.WasRead = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "wasRead"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
