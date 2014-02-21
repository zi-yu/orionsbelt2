using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class SubscriptionTimeRender : TournamentSubscriptionTime
    {

        #region BaseFieldControl<Tournament> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, Core.Tournament entity, int renderCount, bool flipFlop)
        {
            if (entity.SubscriptionTime != 0)
            {
                if (entity.WarningTick == 0)
                {
                    writer.Write(TimeFormatter.GetFormattedTicksTo(entity.SubscriptionTime + Clock.Instance.ConvertToTicks(TimeSpan.FromDays(3))));
                }
                else
                {
                    writer.Write(TimeFormatter.GetFormattedTicksTo(entity.WarningTick + 10));
                }
            }
            else
            {
                writer.Write(LanguageManager.Instance.Get("NoLimit"));
            }
            
        }

        #endregion BaseFieldControl<Tournament> Implementation
       
    }
}
