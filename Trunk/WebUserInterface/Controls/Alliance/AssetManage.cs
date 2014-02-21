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
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.WebUserInterface.Controls {

    public class AssetManage : BaseFieldControl<Asset>
    {

        #region Events

        protected override void Render(HtmlTextWriter writer, Asset entity, int renderCount, bool flipFlop)
        {
            PlayerStorage player = PlayerUtils.Current.Storage;
            if (entity.Owner == player || player.AllianceRank == AllianceRank.Admiral.ToString())
            {
                writer.Write(
                    "<a href='AssetEdit.aspx?Asset={2}'><img src='{0}' alt='edit' title='edit'></a>&nbsp;<a href='javascript:DeleteAsset({2})'><img src='{1}' alt='delete' title='delete'></a>",
                    ResourcesManager.GetForumImage("Edit.gif"), ResourcesManager.GetForumImage("Delete.gif"), entity.Id);
            }
        }

        #endregion Events

    };

}
