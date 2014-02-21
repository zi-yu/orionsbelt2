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
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore.Interfaces;
using System.IO;
using System.Collections;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface {

    public class FriendOrFoePage : Page {

        #region Fields

        protected Literal content;

        #endregion Fields

        #region Events

        protected override void Render(HtmlTextWriter w)
        {
            IPlayer curr = State.GetItems<IPlayer>();
            IList all = GetAll();
            ArrayList fromSource = (ArrayList)all[0];
            ArrayList fromTarget = (ArrayList)all[1];

            TextWriter writer = new StringWriter();

            if (fromSource.Count == 0 && fromTarget.Count == 0) {
                writer.Write("<ul><li>{0}</li></ul>", LanguageManager.Instance.Get("NoFriendOrFoe"));
            }

            writer.Write("<div class='friendsOrFoesList'>");
            WriteFriendOrFoe(writer, curr, fromTarget, true);
            writer.Write("<div class='clear'></div>");
            WriteFriendOrFoe(writer, curr, fromSource, false);
            writer.Write("</div>");

            content.Text = writer.ToString();
            base.Render(w);
        }

        private void WriteFriendOrFoe(TextWriter writer, IPlayer curr, ArrayList list, bool source)
        {
            if (list.Count == 0) {
                return;
            }
            bool added = false;

            writer.Write("<h3>{0}</h3>", string.Format(LanguageManager.Instance.Get(string.Format("FriendsMarked{0}", source)), curr.Name));
            writer.Write("<ul>");
            
            foreach (FriendOrFoe f in list) {
                if (f.IsFriend) {
                    added = true;
                    WritePlayer(writer, GetPlayer(f, source));
                }
            }
            if (!added) {
                writer.Write("<li>-</li>");
            }
            writer.Write("</ul>");

            added = false;

            writer.Write("<h3>{0}</h3>", string.Format(LanguageManager.Instance.Get(string.Format("EnemiesMarked{0}", source)), curr.Name));
            writer.Write("<ul>");
            foreach (FriendOrFoe f in list) {
                if (!f.IsFriend) {
                    added = true;
                    WritePlayer(writer, GetPlayer(f, source));
                }
            }
            if (!added) {
                writer.Write("<li>-</li>");
            }
            writer.Write("</ul>");
        }

        private void WritePlayer(TextWriter writer, PlayerStorage player)
        {
            writer.Write("<li>{0}</li>", WebUtilities.WritePlayerWithAvatar(player));
        }

        #endregion Events

        #region Utils

        private IList GetAll()
        {
            string[] hqls = { 
                "select f from SpecializedFriendOrFoe f inner join fetch f.SourceNHibernate where f.TargetNHibernate.Id = :id",
                "select f from SpecializedFriendOrFoe f inner join fetch f.TargetNHibernate where f.SourceNHibernate.Id = :id"
            };

            Dictionary<string, object> args = new Dictionary<string,object>();
            args.Add("id", State.GetItems<IPlayer>().Id);

            using (IFriendOrFoePersistance persistance = Persistance.Instance.GetFriendOrFoePersistance()) {
                return persistance.MultiQuery(hqls, args);
            }
        }

        private PlayerStorage GetPlayer(FriendOrFoe f, bool source)
        {
            if (!source) {
                return f.Source;
            }
            return f.Target;
        }

        #endregion Utils

    };
}
