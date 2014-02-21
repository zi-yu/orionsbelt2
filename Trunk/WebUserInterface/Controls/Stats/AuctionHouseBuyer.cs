using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;


namespace OrionsBelt.WebUserInterface.Controls
{
    public class AuctionHouseBuyer : BaseFieldControl<AuctionHouse>, INamingContainer
    {
        private IList<Principal> principals = new List<Principal>();

        public IList<Principal> Principals
        {
            get { return principals; }
            set { principals = value; }
        }

        #region BaseFieldControl<PlayerStorage> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, AuctionHouse entity, int renderCount, bool flipFlop)
        {
            if (0 == entity.HigherBidOwner)
            {
                return;
            }
            foreach (Principal principal in principals)
            {
                foreach (PlayerStorage playerStorage in principal.Player)
                {
                    if(playerStorage.Id == entity.HigherBidOwner)
                    {
                        writer.Write(string.Format("{0}(<a href='{2}PlayerInfo.aspx?PlayerStorage={3}'>{1}</a>)",
                            principal.DisplayName, playerStorage.Name, WebUtilities.ApplicationPath, playerStorage.Id));
                        return;
                    }
                }
            }
            
        }

        #endregion BaseFieldControl<PlayerStorage> Implementatio
    }
}
