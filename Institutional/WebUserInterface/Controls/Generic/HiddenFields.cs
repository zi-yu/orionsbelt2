using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Institutional.WebComponents;

namespace Institutional.WebUserInterface.Controls {

	public class HiddenFields : Control {

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<input type='hidden' name='path' id='path' value='http://www.orionsbelt.eu/' />");
			writer.Write("<input type='hidden' name='imagePath' id='imagePath' value='http://resources.orionsbelt.eu/Images/Common' />");
			
#if DEBUG
			writer.Write("<input type='hidden' name='instImagePath' id='instImagePath' value='/Images/' />");
#else
			//writer.Write("<input type='hidden' name='instImagePath' id='instImagePath' value='http://resources.orionsbelt.eu/Institutional/Images/' />");
            writer.Write("<input type='hidden' name='instImagePath' id='instImagePath' value='http://resources.orionsbelt.eu/Institutional/Images/' />");
#endif
        }

        #endregion Rendering

    };

}
