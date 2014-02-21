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
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface
{
    public partial class ForumPage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            if(!WebUtilities.IsForumAvailable){
                HttpContext.Current.Response.Redirect("Default.aspx");
            }
        }
    };
}
