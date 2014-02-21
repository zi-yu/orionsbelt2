using System;
using System.Web;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Alliances;
using OrionsBelt.Engine.Exceptions;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class Storehouse : System.Web.UI.Page {
        protected MembersControl members;
        protected OfferingPagedList paged;
        protected Literal link;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            members.Players = PlayerUtils.Current.Alliance.Storage.Players;
            paged.Where =
                string.Format("e.CurrentValue > 0 and e.AllianceNHibernate.Id={0}", PlayerUtils.Current.Alliance.Storage.Id);
            link.Text = string.Format("<a href='AddToStorehouse.aspx?Id={0}'>{1}</a>", PlayerUtils.Current.Alliance.Storage.Id, 
                                LanguageManager.Instance.Get("Deposit"));

            using (IOfferingPersistance persistance = Persistance.Instance.GetOfferingPersistance())
            {
                long count =
                    persistance.ExecuteScalar("select count(*) from SpecializedOffering e where {0}", paged.Where);


                State.SetItems(BasePagination<Offering>.CountKey, count);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AllianceWebUtils.AssertCurrentPlayerBelongsToCurrentAlliance();

            try
            {
                if (PlayerUtils.Current.AllianceRank == AllianceRank.Admiral)
                {
                    foreach (string key in Request.Form.AllKeys)
                    {
                        if (key.StartsWith("b_"))
                        {
                            string offer = key.Substring(2);
                            int principalId;
                            if (Int32.TryParse(Request.Form["members_" + offer], out principalId))
                            {
                                AllianceManager.MakeDonation(Convert.ToInt32(offer), principalId);
                                SuccessBoard.AddLocalizedMessage("Ok");
                            }
                        }
                    }
                }
            }catch(InvalidAllianceException)
            {
                ErrorBoard.AddLocalizedMessage("InvalidAlliance");
            }
            catch (InvalidPlayerException)
            {
                ErrorBoard.AddLocalizedMessage("InvalidPlayer");
            }
            catch (InvalidOfferException)
            {
                ErrorBoard.AddLocalizedMessage("InvalidOffer");
            }
        }


    }
}
