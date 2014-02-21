using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.WebUserInterface.Controls;
using System.IO;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Universe;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class Relics : System.Web.UI.Page {

        #region Fields

        protected Literal relicInfo;
        protected Literal membersShare;

        #endregion Fields

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AllianceWebUtils.AssertCurrentPlayerBelongsToCurrentAlliance();

            WriteRelicInfo();
            WriteMembersShare();
        }

        #endregion Events

        #region Rendering

        private void WriteMembersShare()
        {
            string title = string.Format("<h2>{0}</h2>", LanguageManager.Localize("Income"));

            using(TextWriter writer = new StringWriter()) {
                writer.Write("<table class='newtable'>");

                writer.Write("<tr>");
                writer.Write("<th>{0}</th>", LanguageManager.Localize("Member"));
                writer.Write("<th>{0}</th>", LanguageManager.Localize("AllianceRank"));
                writer.Write("<th>{0}</th>", LanguageManager.Localize("Percentage"));
                writer.Write("<th>{0}</th>", LanguageManager.Localize("Income"));
                writer.Write("</tr>");

                Dictionary<AllianceRank, double> shares = RelicsManager.GetRelicShare(AllianceWebUtils.Current.Storage);

                foreach( PlayerStorage player in GetSortedMembers(AllianceWebUtils.Current.Storage.Players) ) {
                    AllianceRank rank = (AllianceRank)Enum.Parse(typeof(AllianceRank), player.AllianceRank);
                    double share = GetShare(shares, rank);
                    writer.Write("<tr>");
                    writer.Write("<td>{0}</td>", WebUtilities.WritePlayerWithAvatar(player));
                    writer.Write("<td>{0}</td>", LanguageManager.Localize(player.AllianceRank.ToString()));
                    writer.Write("<td>{0:##0.00}%</td>", share * 100);
                    writer.Write("<td>{0}</td>", Math.Round( share * AllianceWebUtils.Current.Storage.TotalRelicsIncome));
                    writer.Write("</tr>");
                }

                writer.Write("</table>");

                using (StringWriter border = new StringWriter()) {
                    Border.RenderMedium("allianceIncome", border, title, writer.ToString());
                    membersShare.Text = border.ToString();
                }
            }
        }

        private double GetShare(Dictionary<AllianceRank, double> shares, AllianceRank rank)
        {
            if (shares.ContainsKey(rank)) {
                return shares[rank];
            }
            return 0;
        }

        public static IList<PlayerStorage> GetSortedMembers(IList<PlayerStorage> list)
        {
            ((List<PlayerStorage>)list).Sort(delegate(PlayerStorage p1, PlayerStorage p2) {
                return GetPower(p1.AllianceRank).CompareTo(GetPower(p2.AllianceRank)) * -1;
            });

            return list;
        }

        private static int GetPower(string rawrank)
        {
            AllianceRank rank = (AllianceRank)Enum.Parse(typeof(AllianceRank), rawrank);
            switch (rank) {
                case AllianceRank.Admiral: return 50;
                case AllianceRank.ViceAdmiral: return 40;
                case AllianceRank.Corporal: return 30;
                case AllianceRank.Member: return 20;
                default: return 0;
            }
        }

        private void WriteRelicInfo()
        {
            using(TextWriter writer = new StringWriter()) {

                string title = string.Format("<h2>{0}</h2>", LanguageManager.Localize("Relics"));
                writer.Write("<p>{0}</p>", GetRelicInfo(AllianceWebUtils.Current.Storage) );

                if (AllianceWebUtils.Current.Storage.TotalRelics > 0) {

                    IList<SectorStorage> list = Hql.StatelessQuery<SectorStorage>("select s from SpecializedSectorStorage s left join fetch s.OwnerNHibernate player where (s.Type = 'RelicSector' or s.Type = 'RelicBattleSector') and s.OwnerNHibernate.AllianceNHibernate.Id = :allianceId order by s.Level asc", Hql.Param("allianceId", AllianceWebUtils.Current.Storage.Id));

                    writer.Write("<table class='newtable'>");
                    writer.Write("<tr>");
                    writer.Write("<th>{0}</th>", LanguageManager.Localize("Coordinate"));
                    writer.Write("<th>{0}</th>", LanguageManager.Localize("Protector"));
                    writer.Write("<th>{0}</th>", LanguageManager.Localize("IsInBattle"));
                    writer.Write("<th>{0}</th>", LanguageManager.Localize("Level"));
                    writer.Write("</tr>");

                    foreach (SectorStorage storage in list) {
                        ISector sector = SectorUtils.LoadSector(storage);
                        writer.Write("<tr>");
                        writer.Write("<td>{0}</td>", sector.Coordinate);
                        writer.Write("<td>{0}</td>", WebUtilities.WritePlayerWithAvatar(sector.Owner.Storage));
                        writer.Write("<td>{0}</td>", LanguageManager.Localize(sector.IsInBattle.ToString()));
                        writer.Write("<td>{0}</td>", sector.Level);
                        writer.Write("</tr>");
                    }

                    writer.Write("</table>");
                }

                using (StringWriter border = new StringWriter()) {
                    Border.RenderMedium("allianceRelics", border, title, writer.ToString());
                    relicInfo.Text = border.ToString();
                }
            }
        }

        public static string GetRelicInfo(AllianceStorage storage )
        {
            if (storage.TotalRelics == 0) {
                return LanguageManager.Localize("NoRelicsAllianceInfo");
            }

            return string.Format(LanguageManager.Localize("RelicsAllianceInfo"),
                    storage.TotalRelics,
                    storage.TotalRelicsIncome
                );
        }

        #endregion Rendering

    };
}
