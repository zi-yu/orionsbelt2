using System;
using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class ArenaFleetRender : FleetRender
    {
        private ArenaStorage arena;

        public ArenaStorage Arena
        {
            get { return arena; }
            set { arena = value; }
        }

        #region Control Events

        protected override void  OnLoad(EventArgs e)
        {

            IFleetInfo fleetInfo = new FleetInfo(arena.Fleet);
            Dictionary<string,IFleetElement> elems = fleetInfo.Units;
            WriteFleet(elems);
            
        }

        #endregion Control Events        
        
    }
}
