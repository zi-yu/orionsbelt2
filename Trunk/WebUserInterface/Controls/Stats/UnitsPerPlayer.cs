using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Resources;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;


namespace OrionsBelt.WebUserInterface.Controls
{
    public class UnitsPerPlayer : ControlBase
    {


        #region Control Events

        protected override void Render(HtmlTextWriter writer)
        {
            List<PlayersUnits> resources = GetUnits();
            
            string prop = HttpContext.Current.Request.QueryString["sort"];

            if(string.IsNullOrEmpty(prop))
            {
                prop = "FleetValue";
            }

            resources.Sort(delegate(PlayersUnits c1, PlayersUnits c2)
                    {
                        return Convert.ToInt32(c2.GetType().GetProperty(prop).GetValue(c2, null)).CompareTo(
                            Convert.ToInt32(c1.GetType().GetProperty(prop).GetValue(c1, null)));
  
                    });
            base.Render(writer);

            int count = resources.Count;
            int elemPage = 50;
            double numberOfPages = Math.Ceiling((double)count / elemPage);

            string id = HttpContext.Current.Request.QueryString["page"];
            int page=0;
            Int32.TryParse(id, out page);

            WebUtilities.RenderPages(writer, numberOfPages, "&sort=" + prop);

            WriteTableHeader(writer, page);
            
            for (int iter = page * elemPage; iter < resources.Count && iter < (page + 1) * elemPage; ++iter)
            {
                writer.Write("<tr><td><a href='{8}PlayerInfo.aspx?PlayerStorage={0}'>{1}</a></td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td>",
                            resources[iter].Id, resources[iter].Name, resources[iter].FleetValue, resources[iter].Rain, resources[iter].Raptor, resources[iter].Samurai,
                            resources[iter].Panther, resources[iter].Krill, WebUtilities.ApplicationPath);

                writer.Write("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td><td>{10}</td><td>{11}</td>",
                            resources[iter].Kahuna, resources[iter].Pretorian, resources[iter].Eagle, resources[iter].Crusader, resources[iter].Nova, resources[iter].Fenix,
                            resources[iter].Taurus, resources[iter].Blinker, resources[iter].DarkRain, resources[iter].Anubis, resources[iter].Toxic, resources[iter].Scarab);

                writer.Write("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td><td>{10}</td><td>{11}</td>",
                                resources[iter].Driller, resources[iter].Kamikaze, resources[iter].Vector, resources[iter].DarkCrusader, resources[iter].Bozer, resources[iter].Doomer,
                                resources[iter].DarkTaurus, resources[iter].BattleMoon, resources[iter].Seeker, resources[iter].Interceptor, resources[iter].Worm, resources[iter].Stinger);

                writer.Write("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",
                resources[iter].HiveProtector, resources[iter].Destroyer, resources[iter].Spider, resources[iter].HeavySeeker, resources[iter].HiveKing, resources[iter].BlackWidow,
                resources[iter].Queen);

            }
            
            writer.Write("</table>");
             
 
        }

        

        #endregion Control Events 
 
        private static void WriteTableHeader(TextWriter writer, int page)
        {
            writer.Write("<table class='table'><tr><th>{2}</th><th><a href='{0}?page={1}&sort=FleetValue'>{3}</a></th>",
                HttpContext.Current.Request.Url.AbsolutePath, page,
                LanguageManager.Instance.Get("Name"), LanguageManager.Instance.Get("Power"));

            WriteColumn(writer, page, "Rain");
            WriteColumn(writer, page, "Raptor");
            WriteColumn(writer, page, "Samurai");
            WriteColumn(writer, page, "Panther");
            WriteColumn(writer, page, "Krill");
            WriteColumn(writer, page, "Kahuna");
            WriteColumn(writer, page, "Pretorian");
            WriteColumn(writer, page, "Eagle");
            WriteColumn(writer, page, "Crusader");
            WriteColumn(writer, page, "Nova");
            WriteColumn(writer, page, "Fenix");
            WriteColumn(writer, page, "Taurus");
            WriteColumn(writer, page, "Blinker");
            WriteColumn(writer, page, "DarkRain");
            WriteColumn(writer, page, "Anubis");
            WriteColumn(writer, page, "Toxic");
            WriteColumn(writer, page, "Scarab");
            WriteColumn(writer, page, "Driller");
            WriteColumn(writer, page, "Kamikaze");
            WriteColumn(writer, page, "Vector");
            WriteColumn(writer, page, "DarkCrusader");
            WriteColumn(writer, page, "Bozer");
            WriteColumn(writer, page, "Doomer");
            WriteColumn(writer, page, "DarkTaurus");
            WriteColumn(writer, page, "BattleMoon");
            WriteColumn(writer, page, "Seeker");
            WriteColumn(writer, page, "Interceptor");
            WriteColumn(writer, page, "Worm");
            WriteColumn(writer, page, "Stinger");
            WriteColumn(writer, page, "HiveProtector");
            WriteColumn(writer, page, "Destroyer");
            WriteColumn(writer, page, "Spider");
            WriteColumn(writer, page, "HeavySeeker");
            WriteColumn(writer, page, "HiveKing");
            WriteColumn(writer, page, "BlackWidow");
            WriteColumn(writer, page, "Queen");

            writer.Write("</tr>");

        }

        private static void WriteColumn(TextWriter writer, int page, string ship)
        {
            string img = ResourcesManager.GetUnitImage(ship);

            writer.Write("<th><a href='{0}?page={1}&sort={4}'><img class='smallShip' src='{3}' alt='{2}'/></a></th>",
                         HttpContext.Current.Request.Url.AbsolutePath, page, LanguageManager.Instance.Get(ship), img, ship);
        }

        private static List<PlayersUnits> GetUnits()
        {
            IList<Fleet> data;
            using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance())
            {
                data = persistance.TypedQuery(
                        "SELECT e FROM SpecializedFleet e inner join fetch e.PlayerOwnerNHibernate p WHERE e.TournamentFleet=0 and e.Units<>'' ORDER BY p.Id");
            }
            return ResourceUtils.GetPlayersUnits(data);

        }

    }
}
