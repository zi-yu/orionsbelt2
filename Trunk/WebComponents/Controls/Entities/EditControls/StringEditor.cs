using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;

namespace OrionsBelt.WebComponents.Controls {

	public abstract class StringEditor<T> : BaseEntityFieldEditor<T> where T : IDescriptable {
	
		#region Fields & Properties
		
		protected TextBox text = new TextBox();
		
		public string Text
        {
            get { return text.Text; }
            set { text.Text = value; }
        }
		
		public bool Enabled {
            get { return text.Enabled; }
            set { text.Enabled = value; }
        }
        
        public int Length {
            get { return text.MaxLength; }
            set { text.MaxLength = value; }
        }
        
        public bool ReadOnly {
            get { return text.ReadOnly; }
            set { text.ReadOnly = value; }
        }
        
		public TextBox TextBox {
            get { return text; }
        }
		
		#endregion Fields & Properties
		
		#region Events
		
		protected override void OnInit( EventArgs args )
		{
			base.OnInit(args);
			text.ID = TargetName;
			Controls.Add(text);
		}
		
		protected override void Render( HtmlTextWriter writer, T t, int renderCount, bool flipFlop )
		{
			if( !Utils.IsMono ) {
				text.CssClass = CssClass;
			}
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
            text.Text = GetCaption(t);
        }
		
		#endregion Events
		
		#region Abstract Members
		
		protected abstract string GetCaption( T t );
		
		protected abstract string TargetName { get; }
		
		#endregion
		
	};

}