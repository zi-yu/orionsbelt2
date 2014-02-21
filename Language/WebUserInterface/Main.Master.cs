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
using Language.DataAccessLayer;
using Language.Core;
using Language.WebComponents;
using System.Collections.Generic;

namespace WebUserInterface
{
    public partial class Main : System.Web.UI.MasterPage
    {

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (State.HasCache("ProjectList")) {
                projectList.Collection = (IList<LanguageProject>)State.GetCache("ProjectList");
            } else {
                projectList.Collection = Hql.StatelessQuery<LanguageProject>("from SpecializedLanguageProject");
                State.SetCache("ProjectList", projectList.Collection);
            }
        }
    }
}
