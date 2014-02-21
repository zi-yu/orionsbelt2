using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Edits a Double field
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
	public abstract class DoubleEditor<T> : BaseEntityFieldEditor<T> where T : IDescriptable {
	
		#region Fields
		
		protected TextBox text = new TextBox();
		
		#endregion Fields
		
		#region Properties
		
		public TextBox TextBox
        {
            get { return text; }
        }
		
		#endregion Properties
		
		#region Events
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit( EventArgs args )
		{
			base.OnInit(args);
			text.ID = TargetName;
			Controls.Add(text);
		}
		
		/// <summary>
        /// Renders a double editor
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="t">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, T t, int renderCount, bool flipFlop )
		{
			Utils.SetCssClass(text, CssClass);
			SetCaption(t);
			foreach (Control control in Controls) {
                control.RenderControl(writer);
            }
		}
		
		private void SetCaption(T t)
        {
            if (Page.IsPostBack && !string.IsNullOrEmpty(text.Text)) {
                // let's just use the post back value
                return;
            }
            text.Text = GetNumber(t).ToString();
        }
		
		#endregion Events
		
		#region Abstract Members
		
		/// <summary>
        /// Get's the field value
        /// </summary>
        /// <param name="t">The object</param>
        /// <returns>The value</returns>
		protected abstract Double GetNumber( T t );
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected abstract string TargetName { get; }
		
		#endregion
		
	};

}