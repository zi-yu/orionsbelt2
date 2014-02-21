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
    /// Edits the IsPrivate of the PlanetStorage entity
    /// </summary>
	public class PlanetStorageIsPrivateEditor : 
				BoolEditor<PlanetStorage>, INamingContainer {
		
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
        /// <param name="entity">The PlanetStorage instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( PlanetStorage entity )
		{
			return entity.IsPrivate;
		}
		
		/// <summary>
        /// Updates an PlanetStorage
        /// </summary>
        /// <param name="entity">An instance of PlanetStorage</param>
		public override void Update( PlanetStorage entity )
		{
			entity.IsPrivate = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "isPrivate"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
