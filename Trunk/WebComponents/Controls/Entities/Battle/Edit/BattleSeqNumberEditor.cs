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
    /// Edits the SeqNumber of the Battle entity
    /// </summary>
	public class BattleSeqNumberEditor : 
				DoubleEditor<Battle>, INamingContainer {
		
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
        /// Gets the value of the property to edit
        /// </summary>
        /// <param name="entity">The Battle</param>
        /// <returns>The value</returns>
		protected override double GetNumber( Battle entity )
		{
			return entity.SeqNumber;
		}


		/// <summary>
        /// Updates an Battle
        /// </summary>
        /// <param name="entity">An instance of Battle</param>
		public override void Update( Battle entity )
		{
			string val = text.Text;
			if(string.IsNullOrEmpty(val))
			{
				val= "0";
			}
			entity.SeqNumber = double.Parse(val);
		}
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected override string TargetName { 
			get { return string.Format("Mid_DoubleEditor_{0}_seqNumber", ID); }
		}
		
		#endregion

		#region Validation

		protected virtual void AddValidators()
		{
			RegularExpressionValidator maxSize = new RegularExpressionValidator();
            Controls.Add(maxSize);
            maxSize.ControlToValidate = TargetName;
			maxSize.Display = ValidatorDisplay.Dynamic;
            maxSize.ValidationExpression = "^-?\\d*.\\d*$";
            maxSize.ErrorMessage = "format: number.number";
		}
		
		#endregion
	};

}
