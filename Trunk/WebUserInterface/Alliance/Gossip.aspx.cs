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
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class Gossip : System.Web.UI.Page {

        #region Fields

        protected MessageList messageList;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            messageList.MessagesWriter = new GenericMessages(Category.Alliance);
        }

        #endregion Events
    };
}
