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

    public class LanguageFileTokens : BaseFieldControl<LanguageFile> {

        #region Rendering

        protected override void Render(HtmlTextWriter writer, LanguageFile t, int renderCount, bool flipFlop)
        {
            IList data = GetData();
            foreach (object[] info in data) {
                if (t.Name == (string)info[0] && t.Id == Convert.ToInt32(info[2])) {
                    writer.Write(info[1]);
                }
            }
        }

        public static int GetTotalTokens(LanguageFile file)
        { 
            IList data = GetData();
            foreach (object[] info in data) {
                if (file.Name == (string)info[0] && file.Id == Convert.ToInt32(info[2])) {
                    return Convert.ToInt32(info[1]);
                }
            }
            return 0;
        }

        public static IList GetData()
        {
            if (State.HasItems("FileTokensCount")) { 
                return (IList) State.GetItems("FileTokensCount");
            }

            using(IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                IList data = session.Query("select file.Name, count(distinct entry), file.Id from SpecializedLanguageFile file join file.EntriesNHibernate entry group by file.Id");
                State.SetItems("FileTokensCount", data);
                return data;
            }

        }

        #endregion Rendering

    };
}
