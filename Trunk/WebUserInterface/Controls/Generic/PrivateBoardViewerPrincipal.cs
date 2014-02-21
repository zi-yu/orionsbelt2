using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class PrivateBoardViewerPrincipal : PrivateBoardViewer
    {

        protected override void EditFunctions(HtmlTextWriter writer, PrivateBoard board, int playerAllianceId)
        {
            if (board.Receiver == PlayerUtils.Current.Id)
            {
                writer.Write("<a href='javascript:DeletePM({0})'><img src='{1}' alt='delete' title='delete'></a>",
                             board.Id, ResourcesManager.GetForumImage("Delete.gif"));
            }            
        }

    };
}
