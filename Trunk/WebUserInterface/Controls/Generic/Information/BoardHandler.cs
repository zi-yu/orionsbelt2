using System.IO;
using System.Web;
using OrionsBelt.WebComponents;
using System.Web.UI;

namespace OrionsBelt.WebUserInterface.Controls {

	public class BoardHandler : Control {

        #region Events

        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(new SuccessBoard());
            Controls.Add(new ErrorBoard());
            Controls.Add(new InformationBoard());
        }

        #endregion Events

    };
}
