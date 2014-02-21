using System;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class PlayerPosition : BaseFieldControl<PlayerStorage>, INamingContainer
    {
        #region BaseFieldControl<PlayerStorage> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, PlayerStorage entity, int renderCount, bool flipFlop)
        {
            string page = HttpContext.Current.Request.QueryString["Page"];
            int count = 0;
            if(!string.IsNullOrEmpty(page))
            {
                int aux = Int32.Parse(page);
                if(aux > 1)
                {
                    count = 25*( aux - 1);
                }
            }
            writer.Write(renderCount + count);
        }

        #endregion BaseFieldControl<PlayerStorage> Implementatio
    }
}
