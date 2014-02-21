using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls {

    public class SiteTopBackground : Control{

        #region Private

        private static bool InsertFullHeader(){
            if( State.HasItems("InsertFullHeader") ){
                return State.GetItemsInt("InsertFullHeader") == 1;
            }
            return false;
        }

        #endregion

        #region Control Events

        protected override void Render(HtmlTextWriter writer){
            if (InsertFullHeader()){
                writer.Write("<div class='mainBackground'>");
            }else{
				writer.Write("<div class='mainBackgroundSimple'>");
            }
            base.Render(writer);
            writer.Write("</div>");
        }

        #endregion Rendering

    };
}

