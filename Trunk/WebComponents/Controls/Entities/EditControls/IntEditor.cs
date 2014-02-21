using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;

namespace OrionsBelt.WebComponents.Controls {

	public abstract class IntEditor<T> : BaseEntityFieldEditor<T> where T : IDescriptable {
	
		#region Fields
		
		protected TextBox text = new TextBox();
		
		public TextBox TextBox
        {
            get { return text; }
        }
		
		public bool Enabled {
            get { return text.Enabled; }
            set { text.Enabled = value; }
        }
        
        public int Length {
            get { return text.MaxLength; }
            set { text.MaxLength = value; }
        }
		
		#endregion Fields
		
		#region Events
		
		protected override void OnInit( EventArgs args )
		{
			base.OnInit(args);
			text.ID = TargetName;
			Controls.Add(text);
		}
		
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
		
		protected abstract int GetNumber( T t );
		
		protected abstract string TargetName { get; }
		
		#endregion
		
	};

}