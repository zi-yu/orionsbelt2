using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Universe;
using OrionsBelt.WebUserInterface.Controls;
using System.Web;

namespace OrionsBelt.WebUserInterface {

    public class PrincipalInfo : Page {

        #region Fields

        protected Button impersonate, unblock;
        private Principal principal;
        protected PlayerInfoReader reader;

        #endregion Fields

        #region Events

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (!string.IsNullOrEmpty(Request.QueryString["Account"])) {
                this.MasterPageFile = "~/Account/Account.Master";
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        	
			string account = Request.QueryString["Account"];
            if (!string.IsNullOrEmpty(account)) {
                principal = Utils.Principal;
            } else {
                principal = EntityUtils.GetFromQueryString<Principal>();
            }
			
			if(principal.IsBot) {
				Response.Redirect(string.Format("~/MobInfo.aspx?Principal={0}", account));
			}else{
				State.SetItems<Principal>(principal);
				impersonate.Enabled = false;
				impersonate.Visible = false;
				unblock.Enabled = false;
				unblock.Visible = false;

				if (HttpContext.Current.User.IsInRole("admin")) {
					impersonate.Text = "Impersonate";
					impersonate.Click += Impersonate_Click;
					impersonate.Enabled = true;
					impersonate.Visible = true;
				}

				if (HttpContext.Current.User.IsInRole("gameMaster") && principal.Locked)
				{
					unblock.Text = LanguageManager.Instance.Get("UnBlock");
					unblock.Click += Unblock_Click;
					unblock.Enabled = true;
					unblock.Visible = true;
				}
				if (!principal.IsBot && principal.Player != null && principal.Player.Count > 0) {
                    foreach (PlayerStorage storage in principal.Player)
				    {
				        if(reader.Player == null || reader.Player.CreatedDate > storage.CreatedDate)
				        {
				            reader.Player = storage;
				        }
				    }
					
				}
			}
        }

        void Impersonate_Click(object sender, EventArgs e)
        {
            Response.Cookies.Add(new HttpCookie("Impersonate", principal.Name));
            Response.Redirect("Default.aspx");
        }

        void Unblock_Click(object sender, EventArgs e)
        {
            PlayerUtils.UnblockPrincipal(principal);
            Page.Response.Redirect(Page.Request.Url.PathAndQuery);
        }

        #endregion Events

    };
}
