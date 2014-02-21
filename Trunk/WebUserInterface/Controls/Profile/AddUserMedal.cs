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
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebUserInterface.Engine;
using System.IO;

namespace OrionsBelt.WebUserInterface.Controls {

    public class AddUserMedal : Control {

        #region Fields

        //private string message;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            WebUtilities.PreparePostBackActions(this.Page);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            WebUtilities.ProcessPostBackAction(this.Page, ProcessAdd, "AddMedal");
            if (!Utils.Principal.IsInRole("user")) {
                Visible = false;
            }
        }

        public void ProcessAdd(string type, string action, string data)
        {
            IPlayer target = State.GetItems<IPlayer>();
            bool added = MedalManager.Add(PlayerUtils.Current, target, (MedalType)Enum.Parse(typeof(MedalType), data));
            if (added) {
                SuccessBoard.AddLocalizedMessage("AddedMedal");
            } 
        }

        protected override void Render(HtmlTextWriter mainwriter)
        {
            IPlayer player = State.GetItems<IPlayer>();
            if (Utils.PrincipalExists && player.Principal.Id == Utils.Principal.Id) {
                return;
            }

            string title = string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get("AddMedal"));

            StringWriter writer = new StringWriter();
            writer.Write("<dl id='userMedals' class='medals'>");
            foreach (MedalType medal in GetUserMedals()) {
                writer.Write("<dd>");
                WriteMedal(writer, medal);
                writer.Write("</dd>");
            }
            writer.Write("</dl>");

            Border.RenderNormal("addMedals", mainwriter, title, writer.ToString());
        }

        private void WriteMedal(TextWriter writer, MedalType medal)
        {
            writer.Write("<img src='{0}' />", ResourcesManager.GetMedalImage(medal));
            writer.Write("<a href='{0}'>{1}</a>", WebUtilities.GetActionJs("AddMedal", "Medal", medal.ToString(), true), LanguageManager.Instance.Get(medal.ToString()));
        }

        private System.Collections.Generic.IEnumerable<MedalType> GetUserMedals()
        {
            foreach (MedalType medal in Enum.GetValues(typeof(MedalType))) {
                if (!medal.ToString().Contains("_")) {
                    yield return medal;
                }
                if (HttpContext.Current.User.IsInRole("admin") && medal.ToString().Contains("Admin_")) {
                    yield return medal;
                }
            }
        }

        #endregion Events

    };

}
