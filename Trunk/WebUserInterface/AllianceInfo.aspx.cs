using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface {

    public class AllianceInfo : Page 
    {
        protected AllianceInfoReader reader;
        protected AllianceStorage alliance;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            alliance = EntityUtils.GetFromQueryString<AllianceStorage>();

            reader.Alliance = alliance;
        }

        
    }
}
