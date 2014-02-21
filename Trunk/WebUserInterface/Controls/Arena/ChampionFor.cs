using System;
using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class ChampionFor : ControlBase
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
            if(arena.ConquestTick != 0)
                writer.Write(TimeFormatter.GetFormattedTicksSince(arena.ConquestTick));
        }

        #endregion Control Events        
        
    }
}
