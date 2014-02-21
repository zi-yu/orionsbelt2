using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine.Forum;

namespace OrionsBelt.WebUserInterface.Controls {
    public class CreateTopics : Control {

        #region Control Events

        protected override void Render(HtmlTextWriter writer) {
            if (Utils.Principal.IsInRole("admin")) {
                CreateTopicRenderer.RenderButton(writer);
            }
        }

        #endregion Control Events

    }
}
