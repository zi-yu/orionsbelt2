using System;
using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class DiscoveredAt : ControlBase
    {
        private ArenaStorage arena;

        public ArenaStorage Arena
        {
            get { return arena; }
            set { arena = value; }
        }

        #region Control Events

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
            int since = 0;
            foreach (ArenaHistorical historical in arena.Historical)
            {
                if(historical.WinningSequence == 0)
                {
                    since = historical.StartTick;
                    break;
                }
            }
            if(since != 0)
            {
                writer.Write(WebUtilities.GetFormattedTicksSince(since));
            }
            else
            {
                writer.Write(LanguageManager.Instance.Get("NotFoundYet"));
            }
            
        }

        #endregion Control Events        
        
    }
}
