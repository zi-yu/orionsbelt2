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

    public class TaskTypeRender : BaseFieldControl<Task>
    {

        #region Events

        protected override void Render(HtmlTextWriter writer, Task entity, int renderCount, bool flipFlop)
        {
            writer.Write(LanguageManager.Instance.Get(entity.Necessity.Type));
        }

        #endregion Events

    };

}
