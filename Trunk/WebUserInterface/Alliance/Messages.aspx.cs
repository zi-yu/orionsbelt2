using System;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebUserInterface.Controls.Generic;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class Messages : System.Web.UI.Page {

        protected PrivateBoardViewer board;
        protected PrivateBoardSender sender;

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AllianceWebUtils.AssertCurrentPlayerBelongsToCurrentAlliance();
            board.ReceiverId = AllianceWebUtils.Current.Storage.Id;
            sender.ReceiverType = "Alliance";
            sender.Receiver = board.ReceiverId;

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

        #endregion Events

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


    };
}
