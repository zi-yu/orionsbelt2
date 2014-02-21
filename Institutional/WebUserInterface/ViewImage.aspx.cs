using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Institutional.WebUserInterface.Controls;
using Institutional.WebComponents;
using System.Collections.Generic;

namespace WebUserInterface {
	public partial class ViewImage : System.Web.UI.Page {

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            content.Text = GetContent();
        }

        #endregion Events

        #region Rendering

        private string GetContent()
        {
        	TextWriter writer = new StringWriter();

            string image = GetImage();

            GetNavigation(writer, image);
            //writer.Write("<div id='imageShoot'><img class='shoot' src='{0}' alt='Image' /></div>", WebUtilities.GetPreviewImageUrl(HttpContext.Current.Request.QueryString["Type"], image));

			writer.Write("<div id='imageShoot'><div id='secondDiv' onclick='SlideShow.next();'><div id='firstDiv'></div></div></div>");

            GetNavigation(writer, image);

            return writer.ToString();
        }

		private static void WriteImagesJson(TextWriter writer, List<string> images, int idx) {
			writer.Write("<script type='text/javascript'>var currIndex = {0}; var shots = ['{1}'", idx, images[0]);
			for (int i = 1; i < images.Count; ++i ) {
				writer.Write(",'{0}'",images[i]);
			}
			writer.Write("];</script>");
		}

        private void GetNavigation(TextWriter writer, string image)
        {
            List<string> images = WebUtilities.GetPreviewImages(HttpContext.Current.Request.QueryString["Type"]);
            int idx = GetImageIndex(images, image);

			WriteImagesJson(writer, images, idx);

            writer.Write("<div class='picnav'>");

            writer.Write("<div class='navPrev'>");
            if (idx > 0) {
                WriteImgUrl(writer, images[idx-1], image, LanguageManager.Instance.Get("Prev"));
            }
            writer.Write("</div>");

            writer.Write("<div class='navNumbers'>");
            int i = 0;
            foreach (string img in images) {
                WriteImgUrl(writer, img, image, (i+1).ToString());
                ++i;
            }
            writer.Write("</div>");

            writer.Write("<div class='navNext'>");
            if (idx < images.Count - 1) {
                WriteImgUrl(writer, images[idx+1], image, LanguageManager.Instance.Get("Next"));
            }
            writer.Write("</div>");


            writer.Write("</div>");

        }

		

        private void WriteImgUrl(TextWriter writer, string img, string image, string label)
        {
            string css = string.Empty;
            if (img == image) {
                css = "navCurr";
            }
            writer.Write("<a href='ViewImage.aspx?Type={0}&Pic={1}' class='{2}'>{3}</a>",
                    HttpContext.Current.Request.QueryString["Type"],
                    img, 
                    css,
                    label
                );
        }

        private int GetImageIndex(List<string> images, string image)
        {
            for (int i = 0; i < images.Count; ++i) { 
                string curr = images[i];
                if (curr == image) {
                    return i;
                }
            }
            throw new Exception("Can't find current image");
        }

        private string GetImage()
        {
            string pic = HttpContext.Current.Request.QueryString["Pic"];
            List<string> images = WebUtilities.GetPreviewImages(HttpContext.Current.Request.QueryString["Type"]);

            foreach (string image in images) {
                if (pic == image) {
                    return image;
                }
            }

            throw new Exception("Can't find image " + pic);
        }

        #endregion Rendering

    };
}



