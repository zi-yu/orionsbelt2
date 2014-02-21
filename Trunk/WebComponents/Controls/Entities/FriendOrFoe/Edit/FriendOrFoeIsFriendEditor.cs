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
    /// Edits the IsFriend of the FriendOrFoe entity
    /// </summary>
	public class FriendOrFoeIsFriendEditor : 
				BoolEditor<FriendOrFoe>, INamingContainer {
		
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
        /// <param name="entity">The FriendOrFoe instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( FriendOrFoe entity )
		{
			return entity.IsFriend;
		}
		
		/// <summary>
        /// Updates an FriendOrFoe
        /// </summary>
        /// <param name="entity">An instance of FriendOrFoe</param>
		public override void Update( FriendOrFoe entity )
		{
			entity.IsFriend = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "isFriend"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
