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
    /// Edits the Used of the ActivatedPromotion entity
    /// </summary>
	public class ActivatedPromotionUsedEditor : 
				BoolEditor<ActivatedPromotion>, INamingContainer {
		
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
        /// <param name="entity">The ActivatedPromotion instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( ActivatedPromotion entity )
		{
			return entity.Used;
		}
		
		/// <summary>
        /// Updates an ActivatedPromotion
        /// </summary>
        /// <param name="entity">An instance of ActivatedPromotion</param>
		public override void Update( ActivatedPromotion entity )
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
