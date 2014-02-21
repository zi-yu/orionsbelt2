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
    /// Edits the IsDeployTime of the Battle entity
    /// </summary>
	public class BattleIsDeployTimeEditor : 
				BoolEditor<Battle>, INamingContainer {
		
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
        /// <param name="entity">The Battle instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( Battle entity )
		{
			return entity.IsDeployTime;
		}
		
		/// <summary>
        /// Updates an Battle
        /// </summary>
        /// <param name="entity">An instance of Battle</param>
		public override void Update( Battle entity )
		{
			entity.IsDeployTime = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "isDeployTime"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
