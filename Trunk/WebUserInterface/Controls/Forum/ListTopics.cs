using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.WebUserInterface.Engine.Forum;

namespace OrionsBelt.WebUserInterface.Controls {
    public class ListTopics : Control {

        #region Control Events

        protected override void Render(HtmlTextWriter writer) {
            ListTopicsRenderer.Render(writer, false);
        }

        #endregion Control Events

    }
}
