using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Loki.DataRepresentation;
using FreeTextBoxControls;

namespace Institutional.WebComponents.Controls {

	public abstract class FreeTextBoxEditor<T> : BaseEntityFieldEditor<T> where T : IDescriptable {
	
		#region Fields
		
		protected FreeTextBox text = new FreeTextBox();
		
		#endregion Fields
		
		#region Events
		
		protected override void OnInit( EventArgs args )
		{
			base.OnInit(args);
			text.ID = TargetName;
			Configure();
			Controls.Add(text);
		}
		
		protected override void Render( HtmlTextWriter writer, T t, int renderCount, bool flipFlop )
		{
			writer.Write("<div class='freeTextBox'>");
		
			text.Text = GetCaption(t);
			foreach (Control control in Controls) {
                control.RenderControl(writer);
            }
            
            writer.Write("</div>");
		}
		
		#endregion Events
		
		#region Private Members

		/// <summary>
		/// Configures the FreeTextBox
		/// </summary>
		private void Configure() {
			text.SupportFolder = "~/FreeTextBox";
			text.JavaScriptLocation = ResourceLocation.ExternalFile;
			text.ButtonImagesLocation = ResourceLocation.ExternalFile;
			text.ToolbarImagesLocation = ResourceLocation.ExternalFile;
		}
		
		#endregion Private Members
		
		#region Abstract Members
		
		protected abstract string GetCaption( T t );
		
		protected abstract string TargetName { get; }
		
		#endregion
		
	};

}