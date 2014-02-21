
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Edits a boolean field
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
	public abstract class BoolEditor<T> : BaseEntityFieldEditor<T> where T : IDescriptable {
	
		#region Fields
		
		protected CheckBox check = new CheckBox();
		
		#endregion Fields
		
		#region Events
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit( EventArgs args )
		{
			base.OnInit(args);
			check.ID = TargetName;
			Controls.Add(check );
		}
		
		/// <summary>
        /// Sets the check box state based on the current element
        /// </summary>
        /// <param name="current">The entity</param>
        public override void OnCurrentUpdated(T current)
        {
            base.OnCurrentUpdated(current);
            SetCheck(current);
        }
		
		/// <summary>
        /// Renders a boolean editor
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="t">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
		protected override void Render( HtmlTextWriter writer, T t, int renderCount, bool flipFlop )
		{
			Utils.SetCssClass(check, CssClass);
			foreach (Control control in Controls) {
                control.RenderControl(writer);
            }
		}
		
		private void SetCheck(T t)
        {
            if (Page.IsPostBack ) {
                // let's just use the post back value
                return;
            }
            check.Checked = Checked(t);
        }
		
		#endregion Events
		
		#region Abstract Members
		
		/// <summary>
        /// Indicates if the boolean is true or false
        /// </summary>
        /// <param name="t">The object</param>
        /// <returns>The boolean value</returns>
		protected abstract bool Checked( T t );
		
		/// <summary>
        /// Field to be edited
        /// </summary>
		protected abstract string TargetName { get; }
		
		#endregion
		
	};

}