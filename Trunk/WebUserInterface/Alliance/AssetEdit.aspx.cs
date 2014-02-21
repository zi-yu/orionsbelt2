using System;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.Core;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class AssetEdit : System.Web.UI.Page {

        protected UpdateButton update;


        #region Events

        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);
            update.Text = LanguageManager.Instance.Get("Update");
            update.Success += update_Success;
            //PrivateBoard pm = EntityUtils.GetFromQueryString<PrivateBoard>();
            //update.PostBackUrl = string.Format("Messages.aspx?Id={0}", pm.Receiver);
        }

        void update_Success(object sender, EventArgs e)
        {
            Page.Response.Redirect(string.Format("Tasks.aspx?Id={0}", PlayerUtils.Current.Alliance.Storage.Id));
        }

        #endregion Events


    };
}
