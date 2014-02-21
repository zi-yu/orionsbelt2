using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Language.WebComponents.Controls;
using Language.Core;
using System.Collections;
using Language.WebComponents;
using Loki.DataRepresentation;
using Language.DataAccessLayer;

namespace Language.WebUserInterface.Controls {

    public class LanguageFileTokensPerFlag : BaseFieldControl<LanguageFile> {

        #region Rendering

        protected override void Render(HtmlTextWriter writer, LanguageFile t, int renderCount, bool flipFlop)
        {
            IList data = GetData();
            foreach (Locale locale in ProjectFile.GetLocales()) {
                if (ProjectFile.CanEditLocale(locale)) {
                    writer.Write("<td>{0}</td>", GetCount(data, t, locale));
                }
            }
        }

        private string GetCount(IList data, LanguageFile file, Locale locale)
        {
            double total = LanguageFileTokens.GetTotalTokens(file);
            foreach (object[] info in data) {
                if ((string)info[0] == file.Name && (string)info[1] == locale.Name && Convert.ToInt32(info[3]) == file.Id) {
                    double actual = Convert.ToDouble(info[2]);
                    return string.Format("<span style='color:{0}'>{1}</span>", ProjectFile.GetColor(actual / total * 100), info[2]);
                }
            }

            return string.Format("<span style='color:{0}'>0</span>", ProjectFile.GetColor(0));
        }

        private IList GetData()
        {

            if (State.HasItems("FileTokensCountPerLang")) { 
                return (IList) State.GetItems("FileTokensCountPerLang");
            }

            using(IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                IList data = session.Query("select file.Name, trans.Locale, count(entry), file.Id from SpecializedLanguageFile file left join file.EntriesNHibernate entry left join entry.TranslationsNHibernate trans group by file.Id, trans.Locale");
                State.SetItems("FileTokensCountPerLang", data);
                return data;
            }
        }

        #endregion Rendering

    };
}
