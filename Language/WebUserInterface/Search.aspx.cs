using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Language.Core;
using Language.DataAccessLayer;
using System.IO;
using Language.WebComponents.Controls;

namespace Language.WebUserInterface {
    public partial class Search : System.Web.UI.Page {

        #region Events & Fields

        protected Button doSearch;
        protected TextBox searchToken;
        protected LanguageEntryList entryList;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            doSearch.Click += new EventHandler(doSearch_Click);
            doSearch.Focus();
            entryList.Collection = new List<LanguageEntry>();
        }

        void doSearch_Click(object sender, EventArgs e)
        {
            entryList.Collection = Hql.StatelessQuery<LanguageEntry>(0, 100, "select entry from SpecializedLanguageEntry entry inner join entry.TranslationsNHibernate trans where trans.Text like :token", new KeyValuePair<string, object>[] { Hql.Param("token", string.Format("%{0}%", searchToken.Text)) });
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        #endregion Events & Fields

    };
}
