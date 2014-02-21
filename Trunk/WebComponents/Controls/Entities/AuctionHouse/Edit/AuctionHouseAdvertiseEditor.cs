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
    /// Edits the Advertise of the AuctionHouse entity
    /// </summary>
	public class AuctionHouseAdvertiseEditor : 
				BoolEditor<AuctionHouse>, INamingContainer {
		
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
        /// <param name="entity">The AuctionHouse instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( AuctionHouse entity )
		{
			return entity.Advertise;
		}
		
		/// <summary>
        /// Updates an AuctionHouse
        /// </summary>
        /// <param name="entity">An instance of AuctionHouse</param>
		public override void Update( AuctionHouse entity )
		{
			entity.Advertise = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "advertise"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
