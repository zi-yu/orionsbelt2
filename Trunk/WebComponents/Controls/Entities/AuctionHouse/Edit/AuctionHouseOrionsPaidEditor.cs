﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Edits the OrionsPaid of the AuctionHouse entity
    /// </summary>
	public class AuctionHouseOrionsPaidEditor : 
				IntEditor<AuctionHouse>, INamingContainer {
		
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
        /// <param name="entity">The AuctionHouse</param>
        /// <returns>The value</returns>
		protected override int GetNumber( AuctionHouse entity )
		{
			return entity.OrionsPaid;
		}


		/// <summary>
        /// Updates an AuctionHouse
        /// </summary>
        /// <param name="entity">An instance of AuctionHouse</param>
		public override void Update( AuctionHouse entity )
		{
			string val = text.Text;
			if(string.IsNullOrEmpty(val))
			{
				val= "0";
			}
			entity.OrionsPaid = int.Parse(val);
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return string.Format("Mid_IntEditor_{0}_orionsPaid", ID); }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
