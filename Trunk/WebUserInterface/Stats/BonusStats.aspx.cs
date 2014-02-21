using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using System.IO;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface {
    public partial class BonusStats : Page
    {

		protected override void OnInit(EventArgs e) 
        {
            generate.Text = LanguageManager.Instance.Get("Filter");
            sortType.InnerHTML = LanguageManager.Instance.Get("Campaign");
            sortUsed.InnerHTML = LanguageManager.Instance.Get("Used");
            sortDate.InnerHTML = LanguageManager.Instance.Get("CreatedDate");
            sortUpdated.InnerHTML = LanguageManager.Instance.Get("UpdatedDate");

            FillDropDown();

		    
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!string.IsNullOrEmpty(campaign.Text))
            {
                paged.Where += string.Format("e.Type='{0}'", campaign.Text);
            }
            else
            {

                if (State.InMemory("CodeBonusFilter") && !string.IsNullOrEmpty(State.GetFromMemory("CodeBonusFilter").ToString()))
                {

                    string filter = State.GetFromMemory("CodeBonusFilter").ToString();
                    paged.Where += string.Format("e.Type='{0}'", filter);
                }
                else
                {
                    paged.Where = string.Empty;
                }
            }

            FillExtraInfo(campaign.Text, campaign.Items.Count - 1);
            State.SetMemory("CodeBonusFilter", campaign.Text);
        }

        private void FillExtraInfo(string filter, int nCampaigns)
        {
            TextWriter tw = new StringWriter();
            long nUsed;
            long nCards;
            long dups;
            using (IBonusCardPersistance persistance = Persistance.Instance.GetBonusCardPersistance())
            {
                string query = "select count(e.Used) from SpecializedBonusCard e where e.Used=1";
                if(!string.IsNullOrEmpty(filter))
                {
                    query += string.Format(" and e.Type='{0}'", filter);
                }
                nUsed = persistance.ExecuteScalar(query);

                query = "select count(e.Type) from SpecializedBonusCard e";
                if (!string.IsNullOrEmpty(filter))
                {
                    query += string.Format(" where e.Type='{0}'", filter);
                }
                nCards = persistance.ExecuteScalar(query);

                query = "select count(e.Type) from SpecializedBonusCard e where e.Used=0 and e.UsedByNHibernate is not null";
                if (!string.IsNullOrEmpty(filter))
                {
                    query += string.Format(" and e.Type='{0}'", filter);
                }
                dups = persistance.ExecuteScalar(query);
            }
            State.SetItems(BasePagination<BonusCard>.CountKey, nCards);

            tw.Write("<table class='table'><tr><th>{0}</th><td>{1}</td></tr>",LanguageManager.Instance.Get("NumberOfCampaigns"),nCampaigns);
            tw.Write("<tr><th>{0}</th><td>{1}</td></tr>", LanguageManager.Instance.Get("NumberOfCards"), nCards);
            tw.Write("<tr><th>{0}</th><td>{1}</td></tr>", LanguageManager.Instance.Get("NumberOfUsed"), nUsed);
            tw.Write("<tr><th>{0}</th><td>{1}</td></tr></table>", LanguageManager.Instance.Get("NumberOfIlegalUses"), dups);

            extraInfo.Text = tw.ToString();
        }

        private int FillDropDown()
        {
            campaign.Items.Add(new ListItem("","",true));

            IList data;
            using (IBonusCardPersistance persistance = Persistance.Instance.GetBonusCardPersistance())
            {
                data = persistance.Query("select distinct e.Type from SpecializedBonusCard e");
            }

            foreach (string value in data)
            {
                campaign.Items.Add(value); 
            }

            return data.Count;
        }

        protected void Generate(object sender, EventArgs e) {

            
		}
	}
}
