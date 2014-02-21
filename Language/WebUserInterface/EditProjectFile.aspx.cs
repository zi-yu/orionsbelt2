using System;
using Language.Core;
using Language.DataAccessLayer;
using Language.WebComponents;
using System.Collections.Generic;
using Language.WebComponents.Controls;
using System.Web.UI.WebControls;
using System.Web;

namespace Language.WebUserInterface {
    public partial class EditProjectFile : System.Web.UI.Page {

        #region Events

        protected LanguageEntryList entryList;
        protected Literal title;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ProjectFile.AssertCanEditLocale(Request.QueryString["Locale"]);

            entryList.Collection = Hql.Query<LanguageEntry>("select entry from SpecializedLanguageEntry entry where entry.LanguageFileNHibernate.Id = :file",
                    Hql.Param("file", Request.QueryString["Id"])
                );
            IList<LanguageTranslation> translations = Hql.Query<LanguageTranslation>("select trans from SpecializedLanguageTranslation trans where trans.LanguageEntryNHibernate.LanguageFileNHibernate.Id = :file and trans.Locale = :locale",
                    Hql.Param("file", Request.QueryString["Id"]), Hql.Param("locale", Request.QueryString["Locale"])
                );

            foreach (LanguageEntry entry in entryList.Collection) {
                entry.Translations = new List<LanguageTranslation>();
                foreach (LanguageTranslation trans in translations) {
                    if (trans.LanguageEntry.Id == entry.Id) {
                        entry.Translations.Add(trans);
                    }
                }
            }

            ((List<LanguageEntry>)entryList.Collection).Sort(delegate(LanguageEntry e1, LanguageEntry e2) {
                return e1.Translations.Count.CompareTo(e2.Translations.Count);
                });

            title.Text = string.Format("<h1>Tokens for file <u><a href='ProjectFile.aspx?Id={3}&Name={4}'>{0}</a></u> and language <u>{1}</u> ({2} tokens)</h1>", 
                    Request.QueryString["Name"], Request.QueryString["Locale"], entryList.Collection.Count,
                    Request.QueryString["Id"], HttpUtility.HtmlEncode(Request.QueryString["Name"])
                );

            State.SetSession("CurrentEntryList", entryList.Collection);
        }

        #endregion Events

    };
}