
using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class NearPirateFleets : ControlBase
    {
        protected override void Render(HtmlTextWriter writer)
        {
			Coordinate system = new Coordinate(HttpContext.Current.Request.QueryString["systemDst"]);
            
			SectorCoordinate sec = new SectorCoordinate(system, new Coordinate(0,0));
            IList fleets = AcademyUtils.GetPirateFleets(sec);

            if (fleets.Count == 0)
            {
                writer.Write("NoFleetFound");
                return;
            }
            foreach (IList info in fleets)
            {
                writer.Write("<p>{0}:{1}:{2}:{3} - {4} - {5} - {6} {7}</p>", info[0], info[1], info[2], info[3], info[4],
                    LanguageManager.Instance.Get(info[5].ToString()), LanguageManager.Instance.Get("Level"), info[6]);

            }

        }
    }
}
