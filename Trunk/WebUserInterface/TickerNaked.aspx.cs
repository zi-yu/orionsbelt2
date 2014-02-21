using System;
using System.Web;
using System.Web.UI;
using OrionsBelt.WebUserInterface.WebBattle;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Generic.Messages;
using OrionsBelt.Engine;
using OrionsBelt.Core;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface {
    public class TickerNaked : Page
    {

        protected override void OnLoad(System.EventArgs e)
        {
            Page.ClientScript.RegisterHiddenField("path", WebUtilities.ApplicationPath);
            Page.ClientScript.RegisterHiddenField("imagePath", ResourcesManager.ImagesCommonPath);
        }
    };
}

