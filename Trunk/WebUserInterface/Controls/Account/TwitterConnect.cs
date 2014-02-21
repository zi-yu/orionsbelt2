using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using System.Collections.Generic;
using OrionsBelt.Core;
using System.IO;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Controls {

	public class TwitterConnect : Control {

        #region Events

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<a href='{1}Auth/TwitterLogin.ashx'><img src='{0}/Community/Sign-in-with-Twitter-lighter.png' /></a>", ResourcesManager.ImagesCommonPath, WebUtilities.ApplicationPath);
        }

        #endregion Events

    };
}

