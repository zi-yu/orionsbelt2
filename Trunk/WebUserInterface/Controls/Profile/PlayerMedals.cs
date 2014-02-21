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
using OrionsBelt.Core;
using System.Collections.Generic;

namespace OrionsBelt.WebUserInterface.Controls {

    public class PlayerMedals : Control {

        #region Options

        protected virtual bool ShowIfEmpty {
            get { return true; }
        }

        #endregion Options

        #region Events

        protected override void Render(HtmlTextWriter writer)
        {
            IPlayer player = State.GetItems<IPlayer>();

            writer.Write("<div id='playerMedals'>");

            string title = string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get("PlayerMedals"));

            StringWriter content = new StringWriter();
            WriteMedals(content, player.Storage.Medals);
            Border.RenderNormal(writer, title, content.ToString());

            writer.Write("</div>");
        }

        protected void WriteMedals(TextWriter writer, IList<Medal> medals)
        {
            if (medals.Count == 0 && !ShowIfEmpty) {
                return;
            }

            Dictionary<string, int> groupedMedals = GroupMedals(medals);

            writer.Write("<dl class='{0}'>", GetListCss());
            foreach (KeyValuePair<string, int> pair in groupedMedals) {
                writer.Write("<dd>");
                WriteMedal(writer, pair);
                writer.Write("</dd>");
            }
            writer.Write("</dl>");
        }

        protected virtual string GetListCss()
        {
            return "medals";
        }

        private Dictionary<string, int> GroupMedals(IList<Medal> iList)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            foreach (Medal medal in iList) {
                if (dic.ContainsKey(medal.Name)) {
                    ++dic[medal.Name];
                } else {
                    dic.Add(medal.Name, 1);
                }
            }

            return dic;
        }

        private void WriteMedal(TextWriter writer, KeyValuePair<string, int> pair)
        {
            writer.Write("<img src='{0}' />", ResourcesManager.GetMedalImage(pair.Key));
            writer.Write("<div>{1}", string.Empty, LanguageManager.Instance.Get(pair.Key));
            writer.Write("<br/>({0} ",pair.Value);
            if (pair.Value == 1) {
                writer.Write("{1})</div>", pair.Value, LanguageManager.Localize("Medal"));
            } else {
                writer.Write("{1})</div>", pair.Value, LanguageManager.Localize("Medals"));
            }
        }

        #endregion Events

    };

}
