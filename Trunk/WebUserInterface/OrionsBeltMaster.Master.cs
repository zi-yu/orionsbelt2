using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebComponents;
using System.Web;
using System;

namespace WebUserInterface {
	public class OrionsBeltMaster: System.Web.UI.MasterPage {
	    protected MainForm mainForm;

	    public MainForm FormProp
	    {
	        get { return mainForm; }
	        set { mainForm = value; }
	    }

        protected override void OnInit(System.EventArgs e)
        {
            if (!State.Items.Contains("MainForm")){
                State.Items.Add("MainForm", mainForm);
            }
        }

	    protected override void OnLoad(EventArgs e) {
			Page.ClientScript.RegisterHiddenField("path", WebUtilities.ApplicationPath);
            Page.ClientScript.RegisterHiddenField("imagePath", ResourcesManager.ImagesCommonPath);
            Page.ClientScript.RegisterHiddenField("millisPerTick", OrionsBelt.Generic.Server.Properties.MillisPerTick.ToString());
            
            if (Utils.PrincipalExists && !Utils.Principal.AcceptedTerms){
                if ( !WebUtilities.IsInTerms){
                    HttpContext.Current.Response.Redirect(WebUtilities.ApplicationPath + "Terms.aspx");
                } 
				
			}
		}
	}
}
