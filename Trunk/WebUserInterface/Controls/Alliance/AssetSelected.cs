using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {

    public class AssetSelected : BaseFieldControl<Asset>
    {

        #region Events

        protected override void Render(HtmlTextWriter writer, Asset entity, int renderCount, bool flipFlop)
        {

            if (entity.Task != null && entity.Task.Id == Convert.ToInt32(HttpContext.Current.Request.QueryString["Task"]))
            {
                writer.Write("<input id='ckA_{0}' checked='checked' name='ckA_{0}' type='checkbox'>", entity.Id);
            }
            else
            {
                writer.Write("<input id='ckA_{0}' name='ckA_{0}' type='checkbox'>", entity.Id);
            }
        }

        #endregion Events

    };

}
