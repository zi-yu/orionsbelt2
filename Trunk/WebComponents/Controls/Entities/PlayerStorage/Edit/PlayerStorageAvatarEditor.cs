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
    /// Edits the Avatar of the PlayerStorage entity
    /// </summary>
	public class PlayerStorageAvatarEditor : 
					StringEditor<PlayerStorage>, INamingContainer {
        
		#region Base Implementation
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit( EventArgs args )
		{
			base.OnInit(args);
			AddValidators();
			AdjustTextBox();
		}
		
		/// <summary>
        /// Gets the text to be rendered
        /// </summary>
        /// <param name="entity">The PlayerStorage instance</param>
        /// <returns>The string value</returns>
		protected override string GetCaption( PlayerStorage entity )
		{
			return entity.Avatar;
		}
		
		/// <summary>
        /// Updates an PlayerStorage
        /// </summary>
        /// <param name="entity">An instance of PlayerStorage</param>
		public override void Update( PlayerStorage entity )
		{
			if( !Secret ) {
				entity.Avatar = text.Text;
			}else{
				if( !string.IsNullOrEmpty(text.Text) ) {
					entity.Avatar = FormsAuthentication.HashPasswordForStoringInConfigFile( text.Text, "sha1" );
				}
			}
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return string.Format("Mid_StringEditor_{0}_avatar", ID); }
		}
		
		#endregion
		
		#region Utilities
		
		/// <summary>
        /// Adjust the text box properties
        /// </summary>
		private void AdjustTextBox()
		{
			text.MaxLength = 1000;
						if(isMultiline) {
				text.TextMode = TextBoxMode.MultiLine;
			}
			if( Secret ) {
				text.TextMode = TextBoxMode.Password;
			}
		}
		
		/// <summary>
        /// Indicated if the target property is secret (eg: password)
        /// </summary>
		private bool Secret {
			get { return false; }
		}
		
		private bool isMultiline = false;
		
		/// <summary>
        /// True if this control allows more than one line
        /// </summary>
		public bool IsMultiline {
            get { return isMultiline; }
            set { isMultiline = value; }
        }
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
			RegularExpressionValidator maxSize = new RegularExpressionValidator();
            Controls.Add(maxSize);
            maxSize.ControlToValidate = TargetName;
			maxSize.Display = ValidatorDisplay.Dynamic;
            maxSize.ValidationExpression = "(.|\\s){1,1000}";
            //maxSize.ErrorMessage = string.Format(Resources.LengthValidatorToken, 1000);
		}
		
		#endregion
	};

}
