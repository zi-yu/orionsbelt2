using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Core;

namespace OrionsBelt.WebUserInterface {

	public class DiscountBonus: Page
    {
        protected Button give;
	    protected TextBox code;

        protected override void OnLoad(EventArgs e)
        {
            give.Text = LanguageManager.Instance.Get("Discount");
        }
        protected void Discount(object sender, EventArgs e)
        {
            
            using (IBonusCardPersistance persistance = Persistance.Instance.GetBonusCardPersistance())
            {
                IList<BonusCard> cards= persistance.SelectByCode(code.Text);

                if(cards.Count != 1)
                {
                    ErrorBoard.AddLocalizedMessage("InvalidCode");
                    return;
                }

                if(cards[0].Used)
                {
                    ErrorBoard.AddLocalizedMessage("CodeAlreadyUsed");
                    return;
                }

                object oldCards =
                    Hql.ExecuteScalar("select count(b) from SpecializedBonusCard b where b.Type = :type and b.UsedByNHibernate.Id = :id",
                                           Hql.Param("type", cards[0].Type), Hql.Param("id", Utils.Principal.Id));

                if (oldCards != null && (long)oldCards!=0)
                {
                    ErrorBoard.AddLocalizedMessage("CampainUsed");
                    cards[0].UsedBy = Utils.Principal;
                    persistance.Update(cards[0]);
                    persistance.Flush();
                    return;
                }
                else
                {
                    cards[0].UsedBy = Utils.Principal;
                    cards[0].Used = true;
                    persistance.Update(cards[0]);

                    using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
                    {
                        persistance2.StartTransaction();
                        Utils.Principal.Credits += cards[0].Orions;
                        persistance2.Update(Utils.Principal);

                        TransactionManager.BonusCardTransaction(Utils.Principal, cards[0].Orions, cards[0], persistance2);

                        persistance2.CommitTransaction();
                    }

                    InformationBoard.AddLocalizedMessage("OrionsReceived", cards[0].Orions.ToString());
                    return;
                }
            }
            
        }
    }
}
