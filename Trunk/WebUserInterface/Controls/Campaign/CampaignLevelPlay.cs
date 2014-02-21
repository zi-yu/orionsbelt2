using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class CampaignLevelPlay : BaseFieldControl<CampaignLevel> {

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            WebUtilities.PreparePostBackActions(this.Page);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            WebUtilities.ProcessPostBackAction(this.Page, ProcessStart, "Campaign");
        }

        public void ProcessStart(string type, string action, string data)
        {
            int levelNumber = int.Parse(data);
            IList<CampaignLevel> levels = (IList<CampaignLevel>)State.GetItems("Levels");
            
            CampaignLevel targetLevel = null;
            foreach (CampaignLevel level in levels) {
                if (level.Level == levelNumber) {
                    targetLevel = level;
                    break;
                }
            }

            if (targetLevel == null) {
                throw new UIException("TargetLevel is null");
            }

            if (targetLevel.Level > GetAllowedLevel()) {
                throw new UIException("targetLevel.Level > GetAllowedLevel()");
            }

            bool restart = levelNumber != targetLevel.Level;

            CampaignStatus status;
            if( restart ) {
                status = CampaignManager.CreateStatusForLevel(Utils.Principal, targetLevel);
            } else {
                status = CampaignManager.RestartLevel(Utils.Principal, targetLevel);
            }

            HttpContext.Current.Response.Redirect(string.Format("{0}Battle/Battle.aspx?Id={1}",
                    WebUtilities.ApplicationPath, status.Battle.Id
                ));
        }

        protected override void Render(HtmlTextWriter writer, CampaignLevel t, int renderCount, bool flipFlop)
        {
            if (!State.HasItems("CurrCampaignLevel")) {
                if (t.Level == 1) {
                    WritePlay(writer, t);
                } else {
                    WriteEmpty(writer, t);
                }
                return;
            }

            CampaignLevel curr = (CampaignLevel)State.GetItems("CurrCampaignLevel");
            CampaignStatus status = curr.CampaignStatus[0];

            if (curr.Level == t.Level && status.Completed) {    
                WriteCompleted(writer, t);
                return;
            }

            if (curr.Level == t.Level-1 && status.Completed) {    
                WritePlay(writer, t);
                return;
            }

            if (curr.Level < t.Level) {
                if (t.CampaignStatus == null || t.CampaignStatus.Count == 0) {
                    WriteEmpty(writer, t);
                } else {
                    WriteCompleted(writer, t);
                }
            } else if( curr.Level == t.Level ) {
                WritePlaying(writer, t);
            } else {
                WriteCompleted(writer, t);
            }
        }

        private void WriteCompleted(HtmlTextWriter writer, CampaignLevel t)
        {
            writer.Write("<a href='{1}Battle/Battle.aspx?Id={2}'>{0}</a>",
                   LanguageManager.Localize("Completed"), WebUtilities.ApplicationPath, t.CampaignStatus[0].Battle.Id
                );
            if (!State.HasItems("CurrCampaignStatus")) {
                return;
            }
            CampaignStatus status = (CampaignStatus)State.GetItems("CurrCampaignStatus");

            if (!status.Completed) {
                return;
            }

            writer.Write("<br/>");
            GenericRenderer.WriteLeftLinkButton(writer, WebUtilities.GetActionJs("Campaign", "Restart", t.Level, true).ToString(), LanguageManager.Instance.Get("CampaignRestart"));
        }

        private void WritePlaying(HtmlTextWriter writer, CampaignLevel t)
        {
            writer.Write("<a href='{1}Battle/Battle.aspx?Id={2}'>{0}</a>",
                   LanguageManager.Localize("Playing"), WebUtilities.ApplicationPath, t.CampaignStatus[0].Battle.Id
                );
        }

        private void WriteEmpty(HtmlTextWriter writer, CampaignLevel t)
        {
        }

        private void WritePlay(HtmlTextWriter writer, CampaignLevel t)
        {
            GenericRenderer.WriteLeftLinkButton(writer, WebUtilities.GetActionJs("Campaign", "Start", t.Level, false).ToString(), LanguageManager.Instance.Get("CampaignPlay"));
        }

        #endregion Events

        #region Utils

        private int GetAllowedLevel()
        {
            if (!State.HasItems("CurrCampaignLevel")) {
                return 1;
            }

            CampaignLevel level = (CampaignLevel) State.GetItems("CurrCampaignLevel");
            if (level.CampaignStatus[0].Completed) {
                return level.Level + 1;
            }

            return -1;
        }

        #endregion Utils

    };
}
