using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;
using System.Web.UI.WebControls;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Quests;
using Loki.DataRepresentation;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Controls {

    public class TradeRoutes : ControlBase {

        #region Properties

        private Market market;

        public Market TargetMarket
        {
            get { return market; }
            set { market = value; }
        }

        private IFleetInfo fleet;

        public IFleetInfo Fleet
        {
            get { return fleet; }
            set { fleet = value; }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private Button load = new Button();
        private Button unload = new Button();
	
        #endregion Properties

        #region Events

        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(load);
            Controls.Add(unload);
			
            load.Click += new System.EventHandler(load_Click);
        	load.CssClass = "buttonLarge";
            unload.Click += new System.EventHandler(unload_Click);
			unload.CssClass = "buttonLarge";
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            load.Text = string.Format(LanguageManager.Instance.Get("MarketLoadCargo"), LanguageManager.Instance.Get(GetCurrResource().Name), Fleet.Name);
            unload.Text = string.Format(LanguageManager.Instance.Get("MarketUnloadCargo"), Fleet.Name);

            if (!OnTradeRoute()) {
                load.Enabled = false;
                unload.Enabled = false;
            }
        }

        void unload_Click(object sender, System.EventArgs e)
        {
            List<IResourceQuantity> list = GetUnloadableGoods();
            if (list.Count == 0) {
                Message = LanguageManager.Instance.Get("MarketNoRelevanteResources");
                return;
            }

            foreach (IResourceQuantity res in list) {
                Fleet.RemoveCargo(res.Resource);
            }

            QuestManager.ProcessTradeRoute(TargetMarket, PlayerUtils.Current, list.ToArray());
            Message = LanguageManager.Instance.Get("MarketTradeRouteSuccess");

            
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                session.StartTransaction();

                Messenger.Add(Category.Player, typeof(UnloadTrades), PlayerUtils.Current.Id, fleet.Name, market.Name);
                GameEngine.Persist(PlayerUtils.Current, false, false);
                GameEngine.Persist(Fleet);

                session.CommitTransaction();
            }
        }

        void load_Click(object sender, System.EventArgs e)
        {
            int quantity = Fleet.GetCargoQuantity(GetCurrResource());
            if (quantity > 0) {
                Message = string.Format(LanguageManager.Instance.Get("MarketTradeGoodAlreadyExists"), LanguageManager.Instance.Get(GetCurrResource().Name), Fleet.Name);
            } else {
                Message = string.Format(LanguageManager.Instance.Get("MarketTradeGoodLoaded"), LanguageManager.Instance.Get(GetCurrResource().Name), Fleet.Name);
                Fleet.AddCargo(new ResourceQuantity(GetCurrResource(), 1));

                using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                    session.StartTransaction();

                    Messenger.Add(Category.Player, typeof(LoadTrades), PlayerUtils.Current.Id,
                                GetCurrResource().Name, fleet.Name, market.Name);
                    GameEngine.Persist(Fleet);

                    session.CommitTransaction();
                }
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("TradeRoutes"));

            if (!string.IsNullOrEmpty(Message)) {
                writer.Write("<div>{0}</div>", Message);
            }

            if (!load.Enabled) {
                writer.Write("<div>{0}</div>", LanguageManager.Instance.Get("CantLoadWhileNotInQuest"));
            }
            
            writer.Write("<table class='table'>");
            writer.Write("<tr>");
            writer.Write("<td>");
            load.RenderControl(writer);
            writer.Write("</td>");
            writer.Write("<td>");
            unload.RenderControl(writer);
            writer.Write("</td>");
            writer.Write("</tr>");
            writer.Write("</table>");
        }

        #endregion Events

        #region Utils

        private bool OnTradeRoute()
        {
            foreach (IQuestData data in PlayerUtils.Current.Quests) {
                if (data.Info is ITradeRouteQuest) {
                    return true;
                }
            }
            return false;
        }

        private IResourceInfo GetCurrResource()
        {
            return MarketUtil.GetTradeResource(TargetMarket);
        }

        private List<IResourceQuantity> GetUnloadableGoods()
        {
            List<IResourceQuantity> list = new List<IResourceQuantity>();
            if (Fleet.Cargo == null) {
                return list;
            }
            foreach (KeyValuePair<IResourceInfo, int> pair in Fleet.Cargo) {
                if (pair.Key.Name == GetCurrResource().Name) {
                    continue;
                }
                if (pair.Key.IsTradeRouteSpecific) {
                    list.Add(new ResourceQuantity(pair.Key, pair.Value));
                }
            }
            return list;
        }

        #endregion Utils

    };
}
