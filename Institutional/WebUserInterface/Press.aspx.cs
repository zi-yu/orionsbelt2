using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Institutional.WebUserInterface.Controls;
using Institutional.WebComponents;
using Institutional.DataAccessLayer;
using Institutional.Core;

namespace WebUserInterface {
	public partial class Press : BasePage {

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            testimonials.Collection = Hql.StatelessQuery<Testimonial>("from SpecializedTestimonial t where t.Locale = :locale order by t.Id desc", Hql.Param("locale", LanguageManager.CurrentLanguage));
            mediaArticles.Collection = Hql.StatelessQuery<MediaArticle>("from SpecializedMediaArticle t order by t.Id desc", null);
        }

        #endregion Events

    };
}



