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
    /// Edits the HasDiscoveredAll of the FogOfWarStorage entity
    /// </summary>
	public class FogOfWarStorageHasDiscoveredAllEditor : 
				BoolEditor<FogOfWarStorage>, INamingContainer {
		
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
        /// <param name="entity">The FogOfWarStorage instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( FogOfWarStorage entity )
		{
			return entity.HasDiscoveredAll;
		}
		
		/// <summary>
        /// Updates an FogOfWarStorage
        /// </summary>
        /// <param name="entity">An instance of FogOfWarStorage</param>
		public override void Update( FogOfWarStorage entity )
		{
			entity.HasDiscoveredAll = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "hasDiscoveredAll"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
