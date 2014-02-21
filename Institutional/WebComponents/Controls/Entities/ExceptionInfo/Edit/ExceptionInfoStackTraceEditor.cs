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
    /// Edits the StackTrace of the ExceptionInfo entity
    /// </summary>
	public class ExceptionInfoStackTraceEditor : 
					StringEditor<ExceptionInfo>, INamingContainer {
        
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
        /// <param name="entity">The ExceptionInfo instance</param>
        /// <returns>The string value</returns>
		protected override string GetCaption( ExceptionInfo entity )
		{
			return entity.StackTrace;
		}
		
		/// <summary>
        /// Updates an ExceptionInfo
        /// </summary>
        /// <param name="entity">An instance of ExceptionInfo</param>
		public override void Update( ExceptionInfo entity )
		{
			if( !Secret ) {
				entity.StackTrace = text.Text;
			}else{
				if( !string.IsNullOrEmpty(text.Text) ) {
					entity.StackTrace = FormsAuthentication.HashPasswordForStoringInConfigFile( text.Text, "sha1" );
				}
			}
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return string.Format("Mid_StringEditor_{0}_stackTrace", ID); }
		}
		
		#endregion
		
		#region Utilities
		
		/// <summary>
        /// Adjust the text box properties
        /// </summary>
		private void AdjustTextBox()
		{
			text.MaxLength = 15000;
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
			RequiredFieldValidator req = new RequiredFieldValidator();
			Controls.Add(req);
			req.ControlToValidate = TargetName;
			req.Display = ValidatorDisplay.Dynamic;
			//req.ErrorMessage = string.Format(Resources.RequiredFieldValidatorToken, Resources.ExceptionInfoStackTraceToken);
			RegularExpressionValidator maxSize = new RegularExpressionValidator();
            Controls.Add(maxSize);
            maxSize.ControlToValidate = TargetName;
			maxSize.Display = ValidatorDisplay.Dynamic;
            maxSize.ValidationExpression = "(.|\\s){1,15000}";
            //maxSize.ErrorMessage = string.Format(Resources.LengthValidatorToken, 15000);
		}
		
		#endregion
	};

}
