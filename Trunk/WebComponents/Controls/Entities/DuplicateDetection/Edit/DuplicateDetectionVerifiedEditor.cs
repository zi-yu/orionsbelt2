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
    /// Edits the Verified of the DuplicateDetection entity
    /// </summary>
	public class DuplicateDetectionVerifiedEditor : 
				BoolEditor<DuplicateDetection>, INamingContainer {
		
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
        /// <param name="entity">The DuplicateDetection instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( DuplicateDetection entity )
		{
			return entity.Verified;
		}
		
		/// <summary>
        /// Updates an DuplicateDetection
        /// </summary>
        /// <param name="entity">An instance of DuplicateDetection</param>
		public override void Update( DuplicateDetection entity )
		{
			entity.Verified = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "verified"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
