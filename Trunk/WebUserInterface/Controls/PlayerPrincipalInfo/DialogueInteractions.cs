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
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic.Messages;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Controls {

    public class DialogueInteractions : Control  {

        #region Fields & Properties

        private IPlayer sourcePlayer;

        public IPlayer SourcePlayer
        {
            get { return sourcePlayer; }
            set { sourcePlayer = value; }
        }

        private IPlayer targetPlayer;

        public IPlayer TargetPlayer
        {
            get { return targetPlayer; }
            set { targetPlayer = value; }
        }

        private string notification;

        public string Notification
        {
            get { return notification; }
            set { notification = value; }
        }
	
        #endregion Fields & Properties

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            WebUtilities.PreparePostBackActions(this.Page);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            WebUtilities.ProcessPostBackAction(this.Page, ProcessSendDialogue, "Dialogue");
        }

        public void ProcessSendDialogue(string type, string action, string data)
        {
            Message message = Persistance.Create<Message>();
            message.Category = "Player";
            message.Date = DateTime.Now;
            message.SubCategory = data;
            message.OwnerId = TargetPlayer.Id;
            message.Parameters = string.Format("{0};{1};", SourcePlayer.Id, SourcePlayer.Name);
            IMessage msg = Messenger.ConvertMessage(message);
            Messenger.Add(msg);
            Persistance.Flush();

            SuccessBoard.AddLocalizedMessage("DiagogueSent");
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (SourcePlayer == null || TargetPlayer == null) {
                return;
            }
            if (SourcePlayer.Id == TargetPlayer.Id) {
                return;
            }
            writer.Write("<div id='autoInteraction'><h3>{0}</h3>", LanguageManager.Instance.Get("Interact"));

            writer.Write("<table class='newtable'>");

            WriteDialogues(writer, DialogueMessageType.Introduction);
            WriteDialogues(writer, DialogueMessageType.AfterBattle);
            WriteDialogues(writer, DialogueMessageType.Hostile);
            WriteDialogues(writer, DialogueMessageType.Generic);

            writer.Write("</table></div>");
        }

        private static void WriteDialogues(HtmlTextWriter writer, DialogueMessageType type)
        {
            writer.Write("<tr>");
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get(type.ToString()));
            writer.Write("<th></th>");
            writer.Write("</tr>");
            foreach (IMessage message in Messenger.AllMessages) {
                DialogueMessage dialogue = message as DialogueMessage;
                if (dialogue != null && dialogue.DialogueType == type) {
                    dialogue.LanguageTranslator = LanguageParameterTranslator.Instance;
                    writer.Write("<tr>");
                    writer.Write("<td style='padding:10px;'>{0}</td>", dialogue.Translate());
                    writer.Write("<td style='width:50px;'>");
                    GenericRenderer.WriteSmallCenterLinkButton(writer,WebUtilities.GetActionJs("Dialogue", "Send", message.GetType().Name),LanguageManager.Instance.Get("Send"));
                    writer.Write("</td>");
                    writer.Write("</tr>");
                }
            }
        }

        #endregion Events

    };

}
