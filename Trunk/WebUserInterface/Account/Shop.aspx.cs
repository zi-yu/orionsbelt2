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
using OrionsBelt.Engine.Alliances;
using OrionsBelt.Core;
using System.Collections.Generic;
using OrionsBelt.Engine;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Generic.Messages;
using OrionsBelt.WebComponents;
using System.IO;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.WebUserInterface.Account
{
    public class ShopPage : System.Web.UI.Page {

        #region Fields

        protected Literal buyQueueSpace;
        protected Literal buyIntrinsicDeduction;
        protected Literal buyRareDeduction;
        protected Literal buyFastSpeed;
        protected Literal buyNoUndiscoveredUniverse;
        protected Literal buyFullLineOfSight;
		protected Literal buyFiringSquadGeneral;
		protected Literal buyOneStarGeneral;
        protected Literal buyChristmasSpecial;
        protected Literal buyBirthdaySpecial;

        protected Literal latest;

        private IList<TimedActionStorage> actions;
        public IList<TimedActionStorage> Actions {
            get { return actions; }
            set { actions = value; }
        }

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
            actions = Hql.StatelessQuery<TimedActionStorage>("from SpecializedTimedActionStorage action where action.PlayerNHibernate.Id = :id and action.Name = 'ShopTimeout'", Hql.Param("id", PlayerUtils.Current.Id));
            WebUtilities.ProcessPostBackAction(this.Page, ProcessBuy, "Shop");
            SetUpIntrinsicPriceDeduction();
            SetUpRarePriceDeduction();
            SetUpQueueSpace();
            SetUpChristmasSpecial();
            SetUpBirthdaySpecial();
            SetUpFastSpeed();
            SetUpNoUndiscoveredUniverse();
            SetUpFullLineOfSight();
			SetUpFiringSquadGeneral();
			SetUpOneStarGeneral();
        	SetUpLatest();
			SetUpJavascriptHelper();
        }

        private void SetUpLatest()
        {
            if (!Utils.Principal.IsInRole("admin")) {
                return;
            }

            TextWriter writer = new StringWriter();

            IList<TimedActionStorage> list = Hql.StatelessQuery<TimedActionStorage>(
                    0, 25,
                    "from SpecializedTimedActionStorage a inner join fetch a.PlayerNHibernate player where a.Name = 'ShopTimeout' order by a.CreatedDate desc",
                    null
                );

            writer.Write("<div class='clear'></div>");
            writer.Write("<h2>Latest Active Sells</h2>");
            writer.Write("<table class='table'>");
            writer.Write("<tr>");
            writer.Write("<th>Service</th>");
            writer.Write("<th>Player</th>");
            writer.Write("<th>Duration</th>");
            writer.Write("</tr>");
            foreach (TimedActionStorage action in list) {
                writer.Write("<tr>");
                writer.Write("<td>{0}</td>", action.Data);
                writer.Write("<td><a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a></td>", WebUtilities.ApplicationPath, action.Player.Id, action.Player.Name);
                int delay = action.EndTick - Clock.Instance.Tick;
                writer.Write("<td>{0}</td>", TimeFormatter.GetFormattedTicks(delay));
                writer.Write("</tr>");
            }
            writer.Write("</table>");

            latest.Text = writer.ToString();
        }

        public void ProcessBuy(string type, string action, string data)
        {
            if (!AlreadyHas(data)) {
                int scale = Convert.ToInt32(Request.Form["scale"]);
                Shop.ProcessService(PlayerUtils.Current, data, scale);
                Response.Redirect("Shop.aspx");
            }
        }

        #endregion Events

        #region Utils

        private void SetUpJavascriptHelper()
        {
            TextWriter writer = new StringWriter();

            writer.Write("window.shopItemsScale = {");
            writer.Write("'BuyQueueSpace':{0},", Shop.BuyQueueSpaceCost);
            writer.Write("'BuyIntrinsicDeduction':{0},", Shop.BuyIntrinsicDeductionCost);
            writer.Write("'BuyRareDeduction':{0},", Shop.BuyRareDeductionCost);
            writer.Write("'BuyNoUndiscoveredUniverse':{0},", Shop.BuyNoUndiscoveredUniverseCost);
            writer.Write("'BuyFullLineOfSight':{0},", Shop.BuyFullLineOfSightCost);
            writer.Write("'BuyFastSpeed':{0},", Shop.BuyFastSpeedCost);
			writer.Write("'BuyFiringSquadGeneral':{0},", Shop.BuyFiringSquadGeneralCost);
			writer.Write("'BuyOneStarGeneral':{0},", Shop.BuyOneStarGeneralCost);
            writer.Write("'Date':'{0}'}};", DateTime.Now);

            ClientScript.RegisterClientScriptBlock(GetType(), "ShopItemsScale", writer.ToString(), true);
            ClientScript.RegisterHiddenField("scale", "1");
        }

        private void SetUpIntrinsicPriceDeduction()
        {
            SetUp(buyIntrinsicDeduction, "BuyIntrinsicDeductionInfo", "BuyIntrinsicDeduction", Shop.BuyIntrinsicDeductionCost, "Resources");
        }

        private void SetUpRarePriceDeduction()
        {
            SetUp(buyRareDeduction, "BuyRareDeductionInfo", "BuyRareDeduction", Shop.BuyRareDeductionCost, "Resources");
        }

        private void SetUpQueueSpace()
        {
            SetUp(buyQueueSpace, "BuyQueueSpaceInfo", "BuyQueueSpace", Shop.BuyQueueSpaceCost, "Planet");
        }

        private void SetUpFastSpeed()
        {
            SetUp(buyFastSpeed, "BuyFastSpeedInfo", "BuyFastSpeed", Shop.BuyFastSpeedCost, "Planet");
        }

        private void SetUpFullLineOfSight()
        {
            SetUp(buyFullLineOfSight, "BuyFullLineOfSightInfo", "BuyFullLineOfSight", Shop.BuyFullLineOfSightCost, "Universe");
        }

        private void SetUpNoUndiscoveredUniverse()
        {
            SetUp(buyNoUndiscoveredUniverse, "BuyNoUndiscoveredUniverseInfo", "BuyNoUndiscoveredUniverse", Shop.BuyNoUndiscoveredUniverseCost, "Universe");
        }

		private void SetUpFiringSquadGeneral() {
			if (!Utils.Principal.IsInRole("admin")) {
				buyFiringSquadGeneral.Visible = false;
				buyOneStarGeneral.Visible = false;
				return;
			} 
			SetUp(buyFiringSquadGeneral, "BuyFiringSquadGeneralInfo", "BuyFiringSquadGeneral", Shop.BuyFiringSquadGeneralCost, "Battle");
		}

		private void SetUpOneStarGeneral() {
			if (!Utils.Principal.IsInRole("admin")) {
				buyFiringSquadGeneral.Visible = false;
				buyOneStarGeneral.Visible = false;
				return;
			}
            SetUp(buyOneStarGeneral, "BuyOneStarGeneralInfo", "BuyOneStarGeneral", Shop.BuyOneStarGeneralCost, "Battle");
		}

        private void SetUpBirthdaySpecial()
        {
            if (DateTime.Now.Month == 1 && DateTime.Now.Day > 14 && DateTime.Now.Day <= 31) {
                StringWriter writer = new StringWriter();
                FleetRender.WriteUnits(writer, Shop.GetBirthdaySpecialFleet());
                
                SetUpGold(buyBirthdaySpecial, "BuyBirthdaySpecialInfo", "BuyBirthdaySpecial", Shop.BirthdaySpecialCost, "Special", writer.ToString());

                writer.Close();
            }
        }

        private void SetUpChristmasSpecial(){
            if (DateTime.Now.Month == 12) {
                StringWriter writer = new StringWriter();
                FleetRender.WriteUnits(writer, Shop.GetChristmasSpecialFleet());
                
                SetUpGold(buyChristmasSpecial, "BuyChristmasSpecialInfo", "BuyChristmasSpecial", Shop.ChristmasSpecialCost, "Special",writer.ToString());

                writer.Close();
            }
        }

        private void SetUpGold(Literal placeHolder, string labelKey, string serviceKey, int cost, string type, string descText) {
            string title = string.Format("<h2>{0}</h2>", LanguageManager.Localize(type));

            TextWriter content = new StringWriter();
            content.Write("<div class='shopImage {0}Image'></div>", labelKey);
            string helpLink = string.Format("<a href='{0}Commerce/Shop.aspx#{1}'>{2}</a>", ManualUtils.FrameUrl, serviceKey, LanguageManager.Instance.Get("Help"));
            content.Write("<div class='shopDescription'>{0} ({1})", LanguageManager.Instance.Get(labelKey), helpLink);
            if (!string.IsNullOrEmpty(descText)) {
                content.Write("</br>{0}", descText);
            }
            content.Write("</div><div class='shopPrice'><span id='{2}Cost'>{0}</span> {1}</div>", cost, LanguageManager.Instance.Get("Orions"), serviceKey);

            TextWriter bottom = new StringWriter();
            WriteBuy(bottom, serviceKey, cost);

            TextWriter writer = new StringWriter();
            writer.Write("<div class='shopItemSpecial'>");
            Border.RenderSmallGold(writer, title, content.ToString(), bottom.ToString());
            writer.Write("</div>");

            placeHolder.Text = writer.ToString();

            content.Close();
            bottom.Close();
            writer.Close();
        }

        private void SetUp(Literal placeHolder, string labelKey, string serviceKey, int cost, string type)
        {
            string title = string.Format("<h2>{0}</h2>", LanguageManager.Localize(type));

            TextWriter content = new StringWriter();
            content.Write("<div class='shopImage {0}Image'></div>", labelKey);
            string helpLink = string.Format("<a href='{0}Commerce/Shop.aspx#{1}'>{2}</a>", ManualUtils.FrameUrl, serviceKey, LanguageManager.Instance.Get("Help"));
            content.Write("<div class='shopDescription'>{0} ({1})</div>", LanguageManager.Instance.Get(labelKey), helpLink);
            content.Write("<div class='shopPrice'><span id='{2}Cost'>{0}</span> {1}</div>", GetSmallScale(cost), LanguageManager.Instance.Get("Orions"), serviceKey);

            TextWriter bottom = new StringWriter();
            bottom.Write("<div class='shopOptions'>{0}</div>", GetTimeOptions(serviceKey));
            WriteBuy(bottom, serviceKey, cost);
            
            TextWriter writer = new StringWriter();
            writer.Write("<div class='shopItem'>");
            Border.RenderSmall(writer, title, content.ToString(), bottom.ToString());
            writer.Write("</div>");

            placeHolder.Text = writer.ToString();

            content.Close();
            bottom.Close();
            writer.Close();
        }

        private int GetSmallScale(int c)
        {
            return Shop.GetCost(c, 1);
        }

        private string GetTimeOptions(string serviceKey)
        {
            if (AlreadyHas(serviceKey)) {
                return string.Empty;
            }
            TextWriter writer = new StringWriter();

            writer.Write("<select name='{0}Scale' onchange='Utils.changeOrionsPlan(this,\"{0}\");' class='styled'>", serviceKey);
            writer.Write("<option value='1'>{0}</a>", TimeFormatter.GetFormattedTime(TimeSpan.FromDays(10)));
            writer.Write("<option value='3'>{0}</a>", TimeFormatter.GetFormattedTime(TimeSpan.FromDays(30)));
            writer.Write("</select>");

            return writer.ToString();
        }

        private void WriteBuy(TextWriter writer, string serviceKey, int cost)
        {
            if (AlreadyHas(serviceKey)) {
                int ticks = GetDeadline(serviceKey) - Clock.Instance.Tick;
                writer.Write("<div class='shopTimeLeft'>{0}</div>",TimeFormatter.GetFormattedTicks(ticks));
            } else {
                if (Utils.Principal.Credits >= GetSmallScale(cost)) {
                    GenericRenderer.WriteSmallCenterLinkButton(writer, WebUtilities.GetActionJs("Shop", "Buy", serviceKey, true).ToString(), LanguageManager.Instance.Get("Buy"));
                }
            }
        }

        private int GetDeadline(string service)
        {
            foreach (TimedActionStorage storage in Actions) {
                if (storage.Data == service) {
                    return storage.EndTick;
                }
            }
            throw new UIException("No service");
        }

        private bool AlreadyHas(string service)
        {
            foreach (TimedActionStorage storage in Actions) {
                if (storage.Data == service) {
                    return true;
                }
            }
            return false;
        }

        #endregion Utils

    };
}
