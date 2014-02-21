using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Edits the Code of the Referral entity
    /// </summary>
	public class ReferralCodeEditor : 
				IntEditor<Referral>, INamingContainer {
		
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
        /// Gets the value of the property do edit
        /// </summary>
        /// <param name="entity">The Referral</param>
        /// <returns>The value</returns>
		protected override int GetNumber( Referral entity )
		{
			return entity.Code;
		}


		/// <summary>
        /// Updates an Referral
        /// </summary>
        /// <param name="entity">An instance of Referral</param>
		public override void Update( Referral entity )
		{
			string val = text.Text;
			if(string.IsNullOrEmpty(val))
			{
				val= "0";
			}
			entity.Code = int.Parse(val);
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return string.Format("Mid_IntEditor_{0}_code", ID); }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
