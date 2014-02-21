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
    /// Edits the IsOnVacations of the Principal entity
    /// </summary>
	public class PrincipalIsOnVacationsEditor : 
				BoolEditor<Principal>, INamingContainer {
		
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
        /// <param name="entity">The Principal instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( Principal entity )
		{
			return entity.IsOnVacations;
		}
		
		/// <summary>
        /// Updates an Principal
        /// </summary>
        /// <param name="entity">An instance of Principal</param>
		public override void Update( Principal entity )
		{
			entity.IsOnVacations = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "isOnVacations"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
