using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.WebComponents;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using System.IO;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class FleetRender : ControlBase
    {
        private Core.Tournament tour;

        public Core.Tournament Tournament
        {
            get { return tour; }
            set { tour = value; }
        }

        #region Control Events

        protected override void  OnLoad(EventArgs e)
        {
            int tourId = Int32.Parse(HttpContext.Current.Request.QueryString["Tournament"]);
            Fleet fleet = (Fleet)Page.Cache["tournamentFleet" + tourId];
            if (null == fleet)
            {
                using (IFleetPersistance persistance2 = Persistance.Instance.GetFleetPersistance())
                {
                    fleet = persistance2.SelectById(tour.FleetId)[0];
                    Page.Cache.Insert("tournamentFleet" + tourId, fleet);
                }              
            }

            IFleetInfo fleetInfo = new FleetInfo(fleet);
            Dictionary<string,IFleetElement> elems = fleetInfo.Units;
            WriteFleet(elems);
            
        }

        #endregion Control Events        
        
        protected void WriteFleet(Dictionary<string, IFleetElement> elems) {
            StringWriter writer = new StringWriter();

            writer.Write("<ul class='fleet'>");
            foreach (IFleetElement elem in elems.Values) {
                writer.Write("<li><a href='{0}'>", ManualUtils.GetUrl(elem.UnitInfo));
                writer.Write("<img src='{0}' alt='{1}' title='{1}'>", ResourcesManager.GetUnitImage(elem.Name.ToLower()), elem.Name);
                writer.Write("</a>");
                writer.Write(elem.Quantity.ToString());
                writer.Write("</li>");
            }
            writer.Write("</ul>");

            Write(writer.ToString());
        }

        public static void WriteUnits(TextWriter writer, IFleetInfo fleet) 
        {
            writer.Write("<ul class='fleet'>");
            foreach (IFleetElement element in fleet.Units.Values) {
                writer.Write("<li><a href='{0}'>", ManualUtils.GetUrl(element.UnitInfo));
                writer.Write("<img src='{0}' style='width:35px;' />", ResourcesManager.GetUnitImage(element.UnitInfo));
                writer.Write("</a>");
                writer.Write(element.Quantity.ToString());
                writer.Write("</li>");
            }
            writer.Write("</ul>");
        }
    }
}
