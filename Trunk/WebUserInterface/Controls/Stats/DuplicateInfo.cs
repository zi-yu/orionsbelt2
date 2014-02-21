using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class DuplicateInfo : DuplicateDetectionExtraInfo
    {
        #region BaseFieldControl<PlayerStorage> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, DuplicateDetection entity, int renderCount, bool flipFlop)
        {

            if (entity.FindType == DuplicateType.MajorBuys.ToString() ||
                entity.FindType == DuplicateType.BigBuy.ToString())
            {
                string value = (Convert.ToDouble(entity.ExtraInfo)*100).ToString();
                if(value.Length > 5)
                {
                    value = value.Substring(0, 5);
                }
                writer.Write(string.Format("{0} %", value));
                return;
            }

            if (entity.FindType == DuplicateType.QuickBuyout.ToString() )
            {
                writer.Write(string.Format("<a href='BidRegist.aspx?Product={0}'>{0}</a>", entity.ExtraInfo));
                return;
            }
            base.Render(writer,entity,renderCount,flipFlop);
        }

        #endregion BaseFieldControl<PlayerStorage> Implementatio
    }
}
