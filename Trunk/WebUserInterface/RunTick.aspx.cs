using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.Engine.Actions;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.WebUserInterface
{
    public partial class RunTick : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e){
            run.Click += new EventHandler(Run_Click);
            
        }

        void Run_Click(object sender, EventArgs e){
            ActionManager.ProcessActions(Visibility.Public);
        }
    }
}
