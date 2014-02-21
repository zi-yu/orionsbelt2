using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.UI;

namespace OrionsBelt.WebComponents.Controls {
    public class FacebookScript : Control {

        #region Control Events

        protected override void Render(HtmlTextWriter writer) {
            writer.Write("<script src=\"http://static.ak.connect.facebook.com/js/api_lib/v0.4/FeatureLoader.js.php/en_GB\" type=\"text/javascript\"></script><script type=\"text/javascript\">FB.init(\"{0}\");</script>", FacebookSession.ApplicationKey);
        }

        #endregion Control Events

    }
}
