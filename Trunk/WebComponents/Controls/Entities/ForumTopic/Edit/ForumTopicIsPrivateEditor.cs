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
    /// Edits the IsPrivate of the ForumTopic entity
    /// </summary>
	public class ForumTopicIsPrivateEditor : 
				BoolEditor<ForumTopic>, INamingContainer {
		
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
        /// <param name="entity">The ForumTopic instance</param>
        /// <returns>The boolean value</returns>
		protected override bool Checked( ForumTopic entity )
		{
			return entity.IsPrivate;
		}
		
		/// <summary>
        /// Updates an ForumTopic
        /// </summary>
        /// <param name="entity">An instance of ForumTopic</param>
		public override void Update( ForumTopic entity )
		{
			entity.IsPrivate = check.Checked;
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return "isPrivate"; }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
		}
		
		#endregion
	};

}
