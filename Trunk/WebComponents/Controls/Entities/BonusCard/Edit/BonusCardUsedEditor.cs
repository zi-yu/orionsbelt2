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
    /// Edits the Used of the BonusCard entity
    /// </summary>
	public class BonusCardUsedEditor : 
				BoolEditor<BonusCard>, INamingContainer {
		
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
        /// <param name="entity">The BonusCard instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( BonusCard entity )
		{
			return entity.Used;
		}
		
		/// <summary>
        /// Updates an BonusCard
        /// </summary>
        /// <param name="entity">An instance of BonusCard</param>
		public override void Update( BonusCard entity )
		{
			entity.Used = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "used"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
