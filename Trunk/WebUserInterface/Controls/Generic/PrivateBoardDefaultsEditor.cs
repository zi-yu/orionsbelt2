using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class PrivateBoardDefaultsEditor: PrivateBoardTypeEditor
    {
        private string type;
        private int receiver;

        public string ReceiverType
        {
            get { return type; }
            set { type = value; }
        }

        public int Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }

        public override void Update(PrivateBoard entity)
        {
            entity.Type = type;
            entity.Receiver = receiver;
            entity.Sender = PlayerUtils.Current.Storage;
            entity.WasRead = false;
        }
    }
}
