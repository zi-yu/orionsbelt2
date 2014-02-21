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
    /// Edits the FleetId of the PlayerBattleInformation entity
    /// </summary>
	public class PlayerBattleInformationFleetIdEditor : 
				IntEditor<PlayerBattleInformation>, INamingContainer {
		
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
        /// <param name="entity">The PlayerBattleInformation</param>
        /// <returns>The value</returns>
		protected override int GetNumber( PlayerBattleInformation entity )
		{
			return entity.FleetId;
		}


		/// <summary>
        /// Updates an PlayerBattleInformation
        /// </summary>
        /// <param name="entity">An instance of PlayerBattleInformation</param>
		public override void Update( PlayerBattleInformation entity )
		{
			string val = text.Text;
			if(string.IsNullOrEmpty(val))
			{
				val= "0";
			}
			entity.FleetId = int.Parse(val);
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return string.Format("Mid_IntEditor_{0}_fleetId", ID); }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
