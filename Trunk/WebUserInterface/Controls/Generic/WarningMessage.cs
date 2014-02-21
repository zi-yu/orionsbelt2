using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Shows entity messages
    /// </summary>
    public class WarningMessage : Control
    {

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            if(!string.IsNullOrEmpty(Utils.Principal.DuplicatedIds))
            {
				FramesHtml.FrameHtmlTitle(writer, "duplicateWarning", LanguageManager.Localize("Duplicate"),LanguageManager.Instance.Get("WarningMessage"));
            }
        }

        #endregion Rendering

    };
}

