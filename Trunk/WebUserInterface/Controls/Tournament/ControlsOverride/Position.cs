using System;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class Position : BaseFieldControl<Principal>, INamingContainer
    {
        #region BaseFieldControl<Principal> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, Principal entity, int renderCount, bool flipFlop)
        {
            string page = HttpContext.Current.Request.QueryString["Page"];
            int count = 0;
            if (!string.IsNullOrEmpty(page)) {
                int aux = Int32.Parse(page);

                count = 50 * (aux);

            }
            writer.Write(renderCount + count);
            
            
            //string page = HttpContext.Current.Request.QueryString["page"];
            //int count = 0;
            //if (!string.IsNullOrEmpty(page))
            //{
            //    int aux = Int32.Parse(page);
            //    count = aux*50;
            //}
            //else
            //{
            //    if (State.InMemory("ladderCurrPage"))
            //    {
            //        count = Convert.ToInt32(State.GetFromMemory("ladderCurrPage")) * 50;
            //    }
            //}
            //writer.Write(renderCount + count);
        }

        #endregion BaseFieldControl<Principal> Implementatio
    }
}
