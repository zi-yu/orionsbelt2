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
    /// Edits the IsInBattle of the SectorStorage entity
    /// </summary>
	public class SectorStorageIsInBattleEditor : 
				BoolEditor<SectorStorage>, INamingContainer {
		
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
        /// <param name="entity">The SectorStorage instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( SectorStorage entity )
		{
			return entity.IsInBattle;
		}
		
		/// <summary>
        /// Updates an SectorStorage
        /// </summary>
        /// <param name="entity">An instance of SectorStorage</param>
		public override void Update( SectorStorage entity )
		{
			entity.IsInBattle = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "isInBattle"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
