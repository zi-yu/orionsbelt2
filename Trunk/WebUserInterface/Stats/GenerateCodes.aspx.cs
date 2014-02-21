using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface {
    public partial class GenerateCodes : Page
    {

		protected override void OnInit(EventArgs e) {
            generate.Text = LanguageManager.Instance.Get("Generate");
		}

		protected void Generate(object sender, EventArgs e) {
		    string name = code.Text;
		    int quant = Convert.ToInt32(quantity.Text);
            int credits = Convert.ToInt32(orions.Text);
		    TextWriter tw = new StringWriter();
            tw.Write("<table class='table'><tr><th>{0}</th></tr>",LanguageManager.Instance.Get("Code"));

            IList<BonusCard> data = new List<BonusCard>(quant);
            using (IBonusCardPersistance persistance = Persistance.Instance.GetBonusCardPersistance())
            {
                Random rad = new Random();
                for(int iter = 0; iter < quant; ++iter)
                {
                    BonusCard card = persistance.Create();
                    card.Code = FormsAuthentication.HashPasswordForStoringInConfigFile(name+rad.Next(), "sha1");
                    card.Type = name;
                    card.Orions = credits;

                    data.Add(card);

                    tw.Write("<tr><td>{0}</td></tr>", card.Code);
                }
                tw.Write("</table>");
                persistance.Update(data);
                persistance.Flush();
               
            }
		    result.Text = tw.ToString();
		}
	}
}
