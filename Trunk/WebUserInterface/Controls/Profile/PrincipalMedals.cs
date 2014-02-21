using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.WebComponents;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebUserInterface.Engine;
using System.IO;
using OrionsBelt.Core;
using System.Collections.Generic;

namespace OrionsBelt.WebUserInterface.Controls {

    public class PrincipalMedals : PlayerMedals {

        #region Options

        protected override bool ShowIfEmpty {
            get { return false; }
        }

        protected override string GetListCss()
        {
            return "principalMedals";
        }

        #endregion Options

        #region Events

        protected override void Render(HtmlTextWriter writer)
        {
            Principal principal = State.GetItems<Principal>();

            writer.Write("<div id='principalMedals'>");           
            
            string title = string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get("PlayerMedals"));

            StringWriter content = new StringWriter();
            WriteMedals(content, principal.Medals);
            Border.RenderSmall(writer,title,content.ToString());

            writer.Write("</div>");
        }

        #endregion Events

    };

}
