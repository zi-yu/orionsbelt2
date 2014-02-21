using System;
using Language.Core;
using Language.DataAccessLayer;
using Language.WebComponents;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;
using System.Collections;
using Loki.DataRepresentation;

namespace Language.WebUserInterface {
    public partial class ProjectFile : System.Web.UI.Page {

        #region Events

        protected Literal content;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ProjectFile.AssertCanEditLocale(Request.QueryString["Locale"]);
            content.Text = WriteContent();
        }

        #endregion Events

        #region Rendering

        private string WriteContent()
        {
            TextWriter writer = new StringWriter();

            writer.Write("<h1>Translations for file <u>{0}</u></h1>", Page.Request.QueryString["Name"]);

            writer.Write("<table class='table'>");
            foreach(Locale locale in GetLocales()){
                writer.Write("<tr>");
                writer.Write("<td><img src='http://resources.orionsbelt.eu/Images/Common/Flags/{0}.gif' alt='{0}'/></td>", locale.Name);
                writer.Write("<td>{0}</td>", locale.Name);
                double percent = GetTranslatedPercentage(locale);
                writer.Write("<td style='color:{1};'>{0:##0.00}%</td>", percent, GetColor(percent));
                writer.Write("<td>");
                if( CanEditLocale(locale) ) {
                    writer.Write("<a href='EditProjectFile.aspx?Id={0}&Locale={1}&Name={2}'>Edit</a>", 
                            Page.Request.QueryString["Id"],
                            locale.Name,
                            HttpUtility.UrlEncode( Page.Request.QueryString["Name"] )
                        );
                }
                writer.Write("</td>");
                writer.Write("</tr>");
            }
            writer.Write("</table>");

            return writer.ToString();
        }

        public static object GetColor(double percent)
        {
            if (percent > 95) {
                return "#3CB371";
            }
            if (percent > 90) {
                return "#2E8B57";
            }

            if (percent > 75) {
                return "#FF7F50";
            }
            if (percent > 40) {
                return "#FFD700";
            }
            if (percent > 20) {
                return "#B22222";
            }
            return "#8B0000";
        }

        private double GetTranslatedPercentage(Locale locale)
        {
            IList data = GetTranslatedStats(locale);

            double max = double.MinValue;
            double localeValue = 0;

            foreach (object[] info in data) { 
                double currValue = Convert.ToDouble(info[1]);
                string currLocale = (string) info[0];
                if (currLocale == locale.Name) {
                    localeValue = currValue;
                }
                if (currValue > max) {
                    max = currValue;
                }
            }

            return localeValue / max * 100;
        }

        private IList GetTranslatedStats(Locale locale)
        {
            if (State.HasItems("LangData")) {
                return (IList)State.GetItems("LangData");
            }
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                IList data = session.Query("select trans.Locale, count(entry) from SpecializedLanguageEntry entry left join entry.TranslationsNHibernate trans where entry.LanguageFileNHibernate.Id = {0} group by trans.Locale", Page.Request.QueryString["Id"]);
                State.SetItems("LangData", data);
                return data;
            }
        }

        public static bool CanEditLocale(string locale)
        {
            if (HttpContext.Current.User.IsInRole("admin")) {
                return true;
            }
            if (string.IsNullOrEmpty(locale)) {
                return HttpContext.Current.User.IsInRole("translator");
            }
            return HttpContext.Current.User.IsInRole("translator") && HttpContext.Current.User.IsInRole(locale);
        }

        public static bool CanEditLocale(Locale locale)
        {
            return CanEditLocale(locale.Name);
        }

        internal static void AssertCanEditLocale(string locale)
        {
            if (!CanEditLocale(locale)) {
                HttpContext.Current.Response.Redirect("Instructions.aspx", true);
            }
        }

        public static IEnumerable<Locale> GetLocales()
        {
            if( State.HasCache("Locales") ) {
                return (IEnumerable<Locale>)State.GetCache("Locales");
            }
            using (ILocalePersistance persistance = Persistance.Instance.GetLocalePersistance()) {
                IEnumerable<Locale> locales = persistance.Select("Name", true);
                State.SetCache("Locales", locales);
                return locales;
            }
        }

        #endregion Rendering

    };
}