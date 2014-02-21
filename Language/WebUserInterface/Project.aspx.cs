using System;
using Language.Core;
using Language.DataAccessLayer;
using Language.WebComponents;
using System.Collections.Generic;
using Language.WebComponents.Controls;
using System.Web.UI.WebControls;

namespace Language.WebUserInterface {
    public partial class Project : System.Web.UI.Page
    {
        #region Events

        protected LanguageFileList fileList;
        protected Literal title;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ProjectFile.AssertCanEditLocale(Request.QueryString["Locale"]);
            title.Text = string.Format("Translation files for project <u>{0}</u>", Page.Request.QueryString["Name"]);
            fileList.Collection = Hql.StatelessQuery<LanguageFile>("select f from SpecializedLanguageFile f where f.ProjectNHibernate.Id = :id order by f.Name desc", Hql.Param("id", Page.Request.QueryString["Id"]));
        }

        #endregion Events
    }
}