using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;
using System.Web.UI.WebControls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface {

    public class PlayerInfo : Page {

        #region Fields

        protected DialogueInteractions dialogueInteractions;
        protected Controls.Generic.PrivateBoardSender sender;
        protected PrivateBoardViewer board;
        protected Literal header;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            IPlayer iplayer = State.GetItems<IPlayer>();
        	if( iplayer.Principal.IsBot ) {
				Response.Redirect(string.Format("~/MobInfo.aspx?Principal={0}", iplayer.Principal.Id));
			} else {
				dialogueInteractions.SourcePlayer = PlayerUtils.Current;
				dialogueInteractions.TargetPlayer = iplayer;

				sender.ReceiverType = "Player";
				sender.Receiver = iplayer.Id;
				board.ReceiverId = iplayer.Id;


				if (iplayer.Id == PlayerUtils.Current.Id)
				{
					header.Text = LanguageManager.Instance.Get("ReceivedMessages");
					sender.Visible = false;
					WebUtilities.ForceHasMessages(false);

					using (IPrivateBoardPersistance persistance = Persistance.Instance.GetPrivateBoardPersistance())
					{
						IList<PrivateBoard> msgs = persistance.TypedQuery("select b from SpecializedPrivateBoard b where b.Type='Player' and b.Receiver={0} and b.WasRead=0", PlayerUtils.Current.Id);
						foreach (PrivateBoard msg in msgs)
						{
							msg.WasRead = true;
							persistance.Update(msg);
						}
						if(msgs.Count > 0)
						{
							persistance.Flush();
						}
					}
					return;
				}
				else
				{
					header.Text = LanguageManager.Instance.Get("SendPM");
					board.Visible = false;
				}
			}
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Page.IsPostBack)
            {
                string toRemove = Page.Request.Form["toDelete"];
                if (!string.IsNullOrEmpty(toRemove) && HttpContext.Current.Items["toDelete"] == null)
                {
                    HttpContext.Current.Items["toDelete"] = string.Empty;
                    WebUtilities.DeletePM(int.Parse(toRemove));
                }
            }

            RegisterDeleteJS();
        }

        private void RegisterDeleteJS()
        {
            string script = @"<script type='text/javascript'>
	        var theForm = document.forms['" + Page.Form.ClientID + @"'];
            if (!theForm) {
                theForm = document.form;
            }
            function DeletePM ( id )
            {
                if (Message.raiseConfirm('ReallyDelete')) {
		                theForm.toDelete.value = id;
		                theForm.submit();
		            }
	        }
	        </script>";

            Page.ClientScript.RegisterClientScriptBlock(typeof(PrivateBoard), "DeletePM", script);
            Page.ClientScript.RegisterHiddenField("toDelete", "");
        }

        #endregion Events

    };
}
