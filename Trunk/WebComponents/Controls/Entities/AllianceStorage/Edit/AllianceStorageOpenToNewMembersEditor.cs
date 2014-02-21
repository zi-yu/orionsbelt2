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
    /// Edits the OpenToNewMembers of the AllianceStorage entity
    /// </summary>
	public class AllianceStorageOpenToNewMembersEditor : 
				BoolEditor<AllianceStorage>, INamingContainer {
		
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
        /// <param name="entity">The AllianceStorage instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( AllianceStorage entity )
		{
			return entity.OpenToNewMembers;
		}
		
		/// <summary>
        /// Updates an AllianceStorage
        /// </summary>
        /// <param name="entity">An instance of AllianceStorage</param>
		public override void Update( AllianceStorage entity )
		{
			entity.OpenToNewMembers = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "openToNewMembers"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
