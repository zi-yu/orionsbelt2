using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class AHBuyout : AuctionHouseBuyout
    {
        private bool showOperator = true;

        public bool ShowOperator
        {
            get { return showOperator; }
            set { showOperator = value; }
        }

        protected override void Render(HtmlTextWriter writer, AuctionHouse entity, int renderCount, bool flipFlop)
        {
            if (entity.Owner.Principal.Id == Utils.Principal.Id)
            {
                writer.Write(entity.Buyout);
                return;
            }
            if (entity.Buyout != 0)
            {
                
                if (Utils.Principal.Credits >= entity.Buyout &&
                    showOperator )//&&
                   // (/*!Utils.Principal.Player.Contains(entity.Owner)*/entity.Owner.Principal.Id != Utils.Principal.Id || entity.Owner.Id == PlayerUtils.Current.Id))
                {
                    GenericRenderer.WriteSmallCenterLinkButton(writer,
                        string.Format("AuctionHouse.aspx?buy={0}", entity.Id),
                        string.Format("{0} {1}", LanguageManager.Instance.Get("Buyout"), entity.Buyout)
                    );
                }
                else
                {
                    base.Render(writer, entity, renderCount, flipFlop);
                }
            }
            else
            {
                writer.Write("-");
            }
        }
    }
}
