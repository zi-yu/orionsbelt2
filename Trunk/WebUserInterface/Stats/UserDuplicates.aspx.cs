using System;
using System.Web;
using OrionsBelt.WebComponents.Controls;


namespace OrionsBelt.WebUserInterface {

    public class UserDuplicates : Duplicates 
    {
        protected DuplicateDetectionPagedList paged;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            paged.Where = string.Format(" e.Cheater={0} or e.Duplicate={0}", 
                HttpContext.Current.Request.QueryString["Principal"]);
        }

    }
}
