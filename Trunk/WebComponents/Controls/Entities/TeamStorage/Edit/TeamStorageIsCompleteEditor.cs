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
    /// Edits the IsComplete of the TeamStorage entity
    /// </summary>
	public class TeamStorageIsCompleteEditor : 
				BoolEditor<TeamStorage>, INamingContainer {
		
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
        /// <param name="entity">The TeamStorage instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( TeamStorage entity )
		{
			return entity.IsComplete;
		}
		
		/// <summary>
        /// Updates an TeamStorage
        /// </summary>
        /// <param name="entity">An instance of TeamStorage</param>
		public override void Update( TeamStorage entity )
		{
			entity.IsComplete = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "isComplete"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
