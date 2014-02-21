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
    /// Edits the GiveUps of the BattleStats entity
    /// </summary>
	public class BattleStatsGiveUpsEditor : 
				IntEditor<BattleStats>, INamingContainer {
		
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
        /// <param name="entity">The BattleStats</param>
        /// <returns>The value</returns>
		protected override int GetNumber( BattleStats entity )
		{
			return entity.GiveUps;
		}


		/// <summary>
        /// Updates an BattleStats
        /// </summary>
        /// <param name="entity">An instance of BattleStats</param>
		public override void Update( BattleStats entity )
		{
			string val = text.Text;
			if(string.IsNullOrEmpty(val))
			{
				val= "0";
			}
			entity.GiveUps = int.Parse(val);
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return string.Format("Mid_IntEditor_{0}_giveUps", ID); }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
