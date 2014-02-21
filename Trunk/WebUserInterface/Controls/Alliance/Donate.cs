using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class Donate : BaseFieldControl<Offering>, INamingContainer
    {
        #region BaseFieldControl<Product> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, Offering entity, int renderCount, bool flipFlop)
        {

			//writer.Write("<input type='text' name='{0}' value='0'/><input type='submit' class='buttonSmall' name='b_{0}' value='{1}'/>", 
            //    entity.Id, LanguageManager.Instance.Get("Donate"));
            if (PlayerUtils.Current.AllianceRank == AllianceRank.Admiral)
            {
                writer.Write("<input type='submit' class='buttonSmall' name='b_{0}' value='{1}'/>",
                             entity.Id, LanguageManager.Instance.Get("Donate"));
            }
        }

        #endregion BaseFieldControl<Product> Implementatio
    }
}
