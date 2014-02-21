using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using System.IO;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class MenuBase : Control{
        
        #region Fields

        private string currentUrl = HttpContext.Current.Request.Url.AbsoluteUri;

        protected string[] options;
        protected string[] optionsLabel;
        protected static string itemsKey = "MenuBaseCurrent";
        private int realLenght;

        #endregion Fields

        #region Private

        private int GetIndex() {
            string current = null;
            if (State.HasItems(itemsKey)) {
                current = State.GetItemsString(itemsKey);
            }

            for (int i = 0; i < realLenght; ++i) {
                string option = options[i];
                if (currentUrl.Contains(option) || (current != null && option.Contains(current))) {
                    return i;
                }
            }
            return -1;
        }

        private void RenderFirstOption(HtmlTextWriter writer,int index){
            if(index == 0) {
                RenderFirstOptionActive(writer);
            }else{
                RenderFirstOptionNotActive(writer);
                if (index < 0) {
                    writer.Write("<li class='end'></li>");
                }
            }
        }

        private void RenderFirstOptionActive(TextWriter writer) {    
            writer.Write("<li class='startActive'></li>");
            writer.Write("<li class='active'><a href='{0}{2}'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get(optionsLabel[0]), options[0]);
            if (realLenght == 1) {
                writer.Write("<li class='endActive'></li>");
            } else {
                writer.Write("<li class='middleStartActive'></li>");
            }
        }

        private void RenderFirstOptionNotActive(TextWriter writer) {    
            writer.Write("<li class='start'></li>");
            writer.Write("<li ><a href='{0}{2}'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get(optionsLabel[0]), options[0]);
        }

        private void RenderOption(TextWriter writer, int i) {
            writer.Write("<li><a href='{0}{2}'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get(optionsLabel[i]), options[i]);
        }

        private void RenderOptionActive(TextWriter writer, int i) {
            writer.Write("<li class='middleActive'></li>");
            writer.Write("<li class='active'><a href='{0}{2}'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get(optionsLabel[i]), options[i]);
            if (i == realLenght - 1) {
                writer.Write("<li class='endActive'></li>");
            } else {
                writer.Write("<li class='middleEndActive'></li>");
            }
        }

        private void RenderOption(TextWriter writer, int i, bool writeMiddle) {
            if (writeMiddle) {
                RenderMiddle(writer);
            }
            writer.Write("<li><a href='{0}{2}'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get(optionsLabel[i]), options[i]);
            if (i == realLenght - 1) {
                writer.Write("<li class='end'></li>");
            }
        }

        private void RenderMiddle(TextWriter writer) {
            writer.Write("<li class='middle'></li>");
        }

        private int GetRealLenght() {
            int count = 0;
            foreach (string option in options) {
                if (!string.IsNullOrEmpty(option)) {
                    ++count;
                }
            }
            return count;
        }

        #endregion Private
      
        #region Events

        protected override void Render(HtmlTextWriter writer){
            realLenght = GetRealLenght();
            int index = GetIndex();
            writer.Write("<ul class='mainMenu'>");

            RenderFirstOption(writer, index);

            for (int i = 1; i < realLenght; ++i) {
                if(string.IsNullOrEmpty(options[i])) {
                    continue;
                }
                if (i == index) {
                    RenderOptionActive(writer, i);
                    continue;
                }

                if (i == index + 1) {
                    RenderOption(writer, i, false);
                } else {
                    RenderOption(writer, i, true);
                }
            }
            writer.Write("</ul>");
        }

        #endregion Events

    }
}
