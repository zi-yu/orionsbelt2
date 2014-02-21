using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Resources;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;


namespace OrionsBelt.WebUserInterface.Controls
{
    public class ResourcesStats : ControlBase
    {


        #region Control Events

        protected override void Render(HtmlTextWriter writer)
        {
            List<PlayersResources> resources = GetResources();

            string prop = HttpContext.Current.Request.QueryString["sort"];

            if(string.IsNullOrEmpty(prop))
            {
                prop = "Id";
            }

            resources.Sort(delegate(PlayersResources c1, PlayersResources c2)
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
                writer.Write("<tr><td>{0}</td><td><a href='{8}PlayerInfo.aspx?PlayerStorage={0}'>{1}</a></td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td>",
                            resources[iter].Id, resources[iter].Name, resources[iter].Energy, resources[iter].Serium, resources[iter].Mithril, resources[iter].Gold,
                            resources[iter].Titanium, resources[iter].Uranium, WebUtilities.ApplicationPath);

                writer.Write("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",
                            resources[iter].Elk, resources[iter].Protol, resources[iter].Argon, resources[iter].Radon, resources[iter].Astatine, resources[iter].Prismal,
                            resources[iter].Cryptium);
            }

            writer.Write("</table>");
 
        }

        

        #endregion Control Events 
 
        private static void WriteTableHeader(TextWriter writer, int page)
        {
            writer.Write("<table class='table'><tr><th>{2}</th><th>{3}</th><th><a href='{0}?page={1}&sort=Energy'>{4}</a></th>",
                HttpContext.Current.Request.Url.AbsolutePath, page, LanguageManager.Instance.Get("Id"),
                LanguageManager.Instance.Get("Name"), LanguageManager.Instance.Get("Energy"));

            writer.Write("<th><a href='{0}?page={1}&sort=Serium'>{2}</a></th><th><a href='{0}?page={1}&sort=Mithril'>{3}</a></th>",
                HttpContext.Current.Request.Url.AbsolutePath, page, LanguageManager.Instance.Get("Serium"),
                LanguageManager.Instance.Get("Mithril"));

            writer.Write("<th><a href='{0}?page={1}&sort=Gold'>{2}</a></th><th><a href='{0}?page={1}&sort=Titanium'>{3}</a></th>",
                HttpContext.Current.Request.Url.AbsolutePath, page, LanguageManager.Instance.Get("Gold"),
                LanguageManager.Instance.Get("Titanium"));

            writer.Write("<th><a href='{0}?page={1}&sort=Uranium'>{2}</a></th><th><a href='{0}?page={1}&sort=Elk'>{3}</a></th>",
                HttpContext.Current.Request.Url.AbsolutePath, page, LanguageManager.Instance.Get("Uranium"),
                LanguageManager.Instance.Get("Elk"));

            writer.Write("<th><a href='{0}?page={1}&sort=Protol'>{2}</a></th><th><a href='{0}?page={1}&sort=Argon'>{3}</a></th>",
                HttpContext.Current.Request.Url.AbsolutePath, page, LanguageManager.Instance.Get("Protol"),
                LanguageManager.Instance.Get("Argon"));

            writer.Write("<th><a href='{0}?page={1}&sort=Radon'>{2}</a></th><th><a href='{0}?page={1}&sort=Astatine'>{3}</a></th>",
                HttpContext.Current.Request.Url.AbsolutePath, page, LanguageManager.Instance.Get("Radon"),
                LanguageManager.Instance.Get("Astatine"));

            writer.Write("<th><a href='{0}?page={1}&sort=Prismal'>{2}</a></th><th><a href='{0}?page={1}&sort=Cryptium'>{3}</th></tr>",
                HttpContext.Current.Request.Url.AbsolutePath, page, LanguageManager.Instance.Get("Prismal"),
                LanguageManager.Instance.Get("Cryptium"));

        }

        private static List<PlayersResources> GetResources()
        {
            IList data;
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())
            {
                data = persistance.Query("SELECT e.Id, e.Name, e.IntrinsicQuantities FROM SpecializedPlayerStorage e");
            }
            List<PlayersResources> toReturn = new List<PlayersResources>(data.Count);

            foreach (object info in data)
            {
                PlayersResources newOne = new PlayersResources(Convert.ToInt32(((IList) info)[0]),
                                                               Convert.ToString(((IList) info)[1]),
                                                               Convert.ToString(((IList) info)[2]));
                toReturn.Add(newOne);
            }

            return toReturn;
        }

    }
}
