using System;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls.Generic
{
    public partial class PrivateBoardSender : UserControl
    {
        private int receiver;
        private string type;
        protected UpdateButton updateButton;

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

        protected override void  OnInit(EventArgs e)
        {
 	        base.OnInit(e);
            updateButton.Text = LanguageManager.Instance.Get("Send");
            updateButton.Success += new EventHandler(updateButton_Success);
        }

        void updateButton_Success(object sender, EventArgs e)
        {
            string key = string.Format("PrivateBoard-{0}-{1}-{2}", ReceiverType, Receiver, LanguageManager.CurrentLanguage);
            State.RemoveFileCache(key);
            InformationBoard.AddLocalizedMessage("MessageSent");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            defaults.Receiver = receiver;
            defaults.ReceiverType = type;
        }

    }
}