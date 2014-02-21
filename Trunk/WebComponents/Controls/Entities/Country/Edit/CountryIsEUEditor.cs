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
    /// Edits the IsEU of the Country entity
    /// </summary>
	public class CountryIsEUEditor : 
				BoolEditor<Country>, INamingContainer {
		
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
        /// <param name="entity">The Country instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( Country entity )
		{
			return entity.IsEU;
		}
		
		/// <summary>
        /// Updates an Country
        /// </summary>
        /// <param name="entity">An instance of Country</param>
		public override void Update( Country entity )
		{
			entity.IsEU = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "isEU"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
