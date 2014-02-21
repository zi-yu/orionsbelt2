using System;
using System.Data;
using System.Configuration;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.WebComponents;
using System.Collections.Generic;
using OrionsBelt.Engine.Tournament;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class ProcessTournament : Control
    {
        protected Button process = new Button();
        #region Control Events

        protected override void  OnLoad(EventArgs e)
        {
 	        base.OnLoad(e);
            if (Utils.Principal.IsInRole("admin"))
            {
                process.Click += ProcessClick;
                process.OnClientClick = string.Format("javascript:var resp = confirm('{0}');if( !resp )return false;",
                            LanguageManager.Instance.Get("Continue"));
                process.Text = LanguageManager.Instance.Get("ProcessTournament");
                Controls.Add(process);
            }
        }

        protected void ProcessClick(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(ThreadProc, Int32.Parse(HttpContext.Current.Request.QueryString["Tournament"]));
        }

        static void ThreadProc(Object stateInfo)
        {
            TournamentManager.ProcessTournament((int)stateInfo);
        }

        #endregion Control Events
    }
}
