using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.Engine;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls {

    public class PrivateMessages : Control
    {

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string val = HttpContext.Current.Request.QueryString["PlayerStorage"];
            
            if (string.IsNullOrEmpty(val))
            {
                return;
            }
            int pId = Convert.ToInt32(val);
            if (pId == PlayerUtils.Current.Id)
            {
                return;
            }else
            {
                Literal header = new Literal();
                header.Text = string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get("SendPM"));
                Controls.Add(header);
                Generic.PrivateBoardSender sender = new Generic.PrivateBoardSender();
                sender.Receiver = pId;
                sender.ReceiverType = "Player";
                Controls.Add(sender);
            }

        }

  
        #endregion Events

    };

}
