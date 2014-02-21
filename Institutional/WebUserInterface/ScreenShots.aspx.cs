using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using Institutional.WebUserInterface.Controls;
using Institutional.WebComponents;

namespace WebUserInterface {
	public partial class ScreenShots : BasePage {

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GetLiteral().Text = GetContent();
        }

        protected virtual Literal GetLiteral()
        {
            return content;
        }

        #endregion Events

        #region Rendering

        protected virtual string ImageType {
            get { return "ScreenShots"; }
        }

        private string GetContent()
        {
            TextWriter writer = new StringWriter();

            writer.Write("<ul class='images'>");
            foreach (string image in WebUtilities.GetPreviewImages(ImageType)) {
                writer.Write("<li>");
                writer.Write("<a href='ViewImage.aspx?Type={2}&Pic={0}' title='{1}'>", image, LanguageManager.Instance.Get("ScreenShots"), ImageType);
				writer.Write("<div class='imageFrame'></div><img src='{0}' alt='Image' ></img>", WebUtilities.GetPreviewImageUrl(ImageType, image));
                writer.Write("</a>");
                writer.Write("</li>");
            }
            writer.Write("</ul>");
            writer.Write("<div class='clear'></div>");

            return writer.ToString();
        }

        #endregion Rendering

    };
}



