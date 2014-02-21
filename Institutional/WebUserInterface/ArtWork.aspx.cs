using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace WebUserInterface {
	public partial class ArtWork :ScreenShots {
      
        #region Rendering

        protected override string ImageType
        {
            get
            {
                return "ArtWork";
            }
        }

        protected override Literal GetLiteral()
        {
            return content;
        }

        #endregion Rendering

    };
}



