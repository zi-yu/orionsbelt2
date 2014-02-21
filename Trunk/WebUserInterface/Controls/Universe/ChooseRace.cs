using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.RulesCore.UniverseInfo;
using System.Web;
using System.IO;
using OrionsBelt.RulesCore;
using System;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.WebUserInterface.Controls {

	public class ChooseRace: ControlBase {

        #region Fields

        private TextBox name = new TextBox();
        private UnitCategory[] unitCategories = {UnitCategory.Light,UnitCategory.Medium,UnitCategory.Heavy,UnitCategory.Ultimate};

        #endregion Fields

        #region Private

        private string GetResourceUrl(IResourceInfo info) {
            return string.Format("/Manual.aspx?path=/{1}/{0}.aspx", info.Name, info.Type.ToString());
        }

        #endregion Private

        #region Render Units

        private IEnumerable<IUnitInfo> GetUnits(Race race) {
            foreach (UnitCategory category in unitCategories) {
                foreach (IUnitInfo unit in RulesUtils.GetUnitResources()) {
                    if (unit.UnitCategory == category && Array.Exists<Race>(unit.Races, delegate(Race r) { return r == race; })) {
                        yield return unit;
                    }
                }
            }
        }

        private string GetRaceUnits(IRaceInfo info) {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("<h3>{0}</h3>",LanguageManager.Localize("Units"));
                writer.Write("<div class='unitIndexList'><ul>");
                foreach (IUnitInfo unit in GetUnits(info.Race)) {
                    writer.Write("<li>");
                    writer.Write("<a href='{2}'><img class='{3}' src='{0}' alt='{1}' title='{1}' /></a>", ResourcesManager.GetUnitImage(unit.Name), LanguageManager.Instance.Get(unit.Name), GetResourceUrl(unit), unit.Name.ToLower());
                    writer.Write("</li>");
                }
                writer.Write("</ul></div>");
                return writer.ToString();
            }
        }

        private void RenderRace(TextWriter writer, IRaceInfo info) {
            writer.Write("<div class='preview'>");
            writer.Write("<a href='{0}CreatePlayer.aspx?Race={1}'>",
                    WebUtilities.ApplicationPath,
                    info.Race
                );
            writer.Write("<div id='preview{0}' class='preview{0}' onmouseover='Site.changeRace(\"preview{0}\",\"preview{0}Hover\");' onmouseout='Site.changeRace(\"preview{0}\",\"preview{0}\");' ></div>", info.Race);
            writer.Write("</a></div>");
        }

        #endregion Render Units

        #region Render Buildings

        private string GetFacilityImage(IFacilityInfo info, RaceInfo race) {
            if (info.IsAvailableToRace(Race.LightHumans)) {
                return string.Format("<img src='{0}' alt='{1}' Title='{1}'/>", ResourcesManager.GetFacilityImage(RaceInfo.LightHumans, info), LanguageManager.Instance.Get(info.Name));
            }
            return string.Format("<div class='base{1}Preview {1}{0}Preview manualPreview' title='{2}'></div>", info.Name, info.Races[0], LanguageManager.Instance.Get(info.Name));
        }

        private IEnumerable<IFacilityInfo> GetFacilities(Race race) {
            foreach (IFacilityInfo facility in RulesUtils.GetFacilityResources()) {
                if (Array.Exists<Race>(facility.Races, delegate(Race r) { return r == race; })) {
                    yield return facility;
                }
            }
        }

        private string GetRaceFacilities(IRaceInfo race) {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("<h3>{0}</h3>", LanguageManager.Localize("Facilities"));
                writer.Write("<div class='buildingsIndexList'><ul>");
                foreach (IFacilityInfo info in GetFacilities(race.Race)) {
                    writer.Write("<li>");
                    writer.Write("<li><a href='{1}'>{0}</a></li>", GetFacilityImage(info, (RaceInfo)race),GetResourceUrl(info));
                    writer.Write("</li>");
                }
                writer.Write("</ul></div>");
                return writer.ToString();
            }
        }

        #endregion Render Buildings

        #region Events

        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(name);
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            string race = HttpContext.Current.Request.QueryString["Race"];
            if (PlayerUtils.HasPlayer && !State.HasSession("PlayerName")) {
                HttpContext.Current.Response.Redirect("Default.aspx");
                return;
            }
            if (!string.IsNullOrEmpty(race)) {
                string name = Utils.Principal.DisplayName;
                if (State.HasSession("PlayerName")) {
                    name = State.GetSessionString("PlayerName");
                }
                IPlayer oldPlayer = null;
                if (PlayerUtils.HasPlayer) {
                    oldPlayer = PlayerUtils.Current;
                }
                IPlayer newPlayer = GameEngine.CreatePlayer(Utils.Principal, name, RaceInfo.Get(race));
                if (newPlayer == null) {
                    HttpContext.Current.Response.Redirect(string.Format("{0}Account/AddPlayer.aspx?Message=PlayerExists", WebUtilities.ApplicationPath));
                    return;
                }
                if (oldPlayer != null) {
                    oldPlayer.Active = false;
                    GameEngine.Persist(oldPlayer);
                }
                HttpContext.Current.Response.Redirect(string.Format("{0}Universe.aspx", WebUtilities.ApplicationPath));
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {

            string mainTitle = string.Format("<h2>{0}</h2>", LanguageManager.Localize("ChooseYourRace"));
            
            StringWriter mainContent = new StringWriter();
            if (!PlayerUtils.CanRegisterNewPlayers()) {
                mainContent.Write(LanguageManager.Instance.Get("ServerFull"));
                return;
            }
            mainContent.Write("<ul>");
            foreach (IRaceInfo info in RaceInfo.GetAvailableRaces()) {
                mainContent.Write("<li>");
                RenderRace(mainContent, info);
                mainContent.Write("</li>");
            }
            mainContent.Write("</ul>");

            StringWriter bottomContent = new StringWriter();
            foreach (IRaceInfo info in RaceInfo.GetAvailableRaces()) {
                RenderRaceCreate(bottomContent, info);
            }

            writer.Write("<div id='chooseRace'>");
            Border.RenderBig(writer, mainTitle, mainContent.ToString(),bottomContent.ToString());
            writer.Write("</div>");
            			
			foreach (IRaceInfo info in RaceInfo.GetAvailableRaces()) {
                writer.Write("<div id='{0}' class='lore'>", string.Format("preview{0}Lore", info.Race));

				string title = string.Format("<h2>{0} {1}</h2>", LanguageManager.Localize(info.Race.ToString()), LanguageManager.Localize("Lore"));                

                StringWriter content = new StringWriter();
                content.Write(LanguageManager.Localize(info.Race + "Lore"));
                content.Write(GetRaceUnits(info));
                content.Write(GetRaceFacilities(info));
                
                Border.RenderBig(writer, title, content.ToString());

                writer.Write("</div>");
			}
        }

        private void RenderRaceCreate(TextWriter writer, IRaceInfo info) {
            writer.Write("<div class='raceFrame' onmouseover='Site.changeRace(\"preview{0}\",\"preview{0}Hover\");' onmouseout='Site.changeRace(\"preview{0}\",\"preview{0}\");' >", info.Race);
            writer.Write("<a href='{0}CreatePlayer.aspx?Race={1}'>{2}</a>",
                    WebUtilities.ApplicationPath,
                    info.Race,
                    LanguageManager.Instance.Get(info.Race.ToString())
                );
            writer.Write("</div>");

        }
        #endregion Events

    };
}
