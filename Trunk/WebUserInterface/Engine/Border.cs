using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface.Engine {
    public static class Border {

        #region Private

        private static void WriteCenterContent(TextWriter writer, string className, string title, string content, string bottom) {
            WriteCenterContent(string.Empty, writer, className, title, content, bottom, false);
        }

        private static void WriteCenterContent(string id, TextWriter writer, string className, string title, string content, string bottom) {
            WriteCenterContent(id, writer, className, title, content, bottom, false);
        }

        private static void WriteCenterContent(string id, TextWriter writer, string className, string title, string content, string bottom, bool close) {
            writer.Write("<div ");
            if (!string.IsNullOrEmpty(id)) {
                writer.Write("id='{0}' ",id);
            }
            
            writer.Write("class='{0}'>", className);
            if (string.IsNullOrEmpty(title)) {
                writer.Write("<div class='top'></div>");
            } else {
                writer.Write("<div class='top'>{1}{0}</div>",title,close?WriteClose():string.Empty);
            }
            
            writer.Write("<div class='center'>{0}</div>",content);

            if (string.IsNullOrEmpty(bottom)) {
                writer.Write("<div class='bottom'></div>");
            } else {
                writer.Write("<div class='bottom'>{0}</div>",bottom);
            }
            writer.Write("</div>");
        }

        private static void WriteStraightContent(TextWriter writer, string className, string title, string content) {
            writer.Write("<div class='{0}'>", className);
            writer.Write("<div class='top'>{0}</div>", title);
            writer.Write("<div class='center'>{0}</div>", content);
            writer.Write("</div>");
        }

        private static string WriteClose() {
            return string.Format("<div class='closeBorder' onclick=\"Utils.closeFrame(this.parentNode.parentNode.parentNode.id);\"></div>");
        }

        #endregion Private

        #region Public

        public static void RenderBig(TextWriter writer, string title, string content, string bottom) {
            WriteCenterContent(writer, "bigBorder", title, content, bottom);
        }

        public static void RenderBig(string id, TextWriter writer, string title, string content, string bottom) {
            WriteCenterContent(id, writer, "bigBorder", title, content, bottom);
        }

        public static void RenderBig(TextWriter writer, string title, string content) {
            WriteCenterContent(writer, "bigBorder", title, content, null);
        }

        public static void RenderBig(string id, TextWriter writer, string title, string content) {
            WriteCenterContent(id, writer, "bigBorder", title, content, null);
        }

        public static void RenderBig(TextWriter writer, string content) {
            WriteCenterContent(writer, "bigBorder", null, content, null);   
        }

        public static void RenderNormal(TextWriter writer, string title, string content, string bottom) {
            WriteCenterContent(writer, "normalBorder", title, content, bottom);
        }

        public static void RenderNormal(string id, TextWriter writer, string title, string content, string bottom) {
            WriteCenterContent(id, writer, "normalBorder", title, content, bottom);
        }

        public static void RenderNormal(string id, TextWriter writer, string title, string content) {
            WriteCenterContent(id, writer, "normalBorder", title, content, null);
        }

        public static void RenderNormal(TextWriter writer, string title, string content) {
            WriteCenterContent(writer, "normalBorder", title, content, null);
        }

        public static void RenderSpecialNormal(TextWriter writer, string title, string content, string bottom) {
            WriteCenterContent(writer, "specialNormalBorder", title, content, bottom);
        }

        public static void RenderSpecialNormal(TextWriter writer, string title, string content) {
            WriteCenterContent(writer, "specialNormalBorder", title, content, null);
        }

        public static void RenderNormalNoBottom(TextWriter writer, string title, string content) {
            WriteCenterContent(writer, "normalBorder", title, content, null);
        }

        public static void RenderNormalContent(TextWriter writer, string content) {
            WriteCenterContent(writer, "normalBorder", null, content, null);
        }

        public static void RenderNormalOpac(TextWriter writer, string title, string content, string bottom) {
            WriteCenterContent(string.Empty, writer, "normalBorderOpac", title, content, bottom,true);
        }

        public static void RenderMedium(TextWriter writer, string title, string content, string bottom) {
            WriteCenterContent(writer, "mediumBorder", title, content, bottom);
        }

        public static void RenderMedium(TextWriter writer, string title, string content) {
            WriteCenterContent(writer, "mediumBorder", title, content, null);
        }
        
        public static void RenderMedium(string id,TextWriter writer, string title, string content, string bottom) {
            WriteCenterContent(id, writer, "mediumBorder", title, content, bottom);
        }

        public static void RenderMedium(string id,TextWriter writer, string title, string content) {
            WriteCenterContent(id, writer, "mediumBorder", title, content, null);
        }

        public static void RenderSpecialMedium(TextWriter writer, string title, string content, string bottom) {
            WriteCenterContent(writer, "specialMediumBorder", title, content, bottom);
        }

        public static void RenderMediumNoBottom(TextWriter writer, string title, string content) {
            WriteCenterContent(writer, "mediumBorder", title, content, null);
        }

        public static void RenderMediumNoBottom(string id, TextWriter writer, string title, string content) {
            WriteCenterContent(id, writer, "mediumBorder", title, content, null);
        }

        public static void RenderMediumContent(TextWriter writer, string content) {
            WriteCenterContent(writer, "mediumBorder", null, content, null);
        }

        public static void RenderSmall(TextWriter writer, string title, string content, string bottom) {
            WriteCenterContent(writer, "smallBorder", title, content, bottom);
        }

        public static void RenderSmall(string id, TextWriter writer, string title, string content, string bottom) {
            WriteCenterContent(id, writer, "smallBorder", title, content, bottom);
        }

        public static void RenderSmall(TextWriter writer, string title, string content) {
            WriteCenterContent(writer, "smallBorder", title, content, null);
        }

        public static void RenderSpecialSmall(TextWriter writer, string title, string content) {
            WriteCenterContent(writer, "specialSmallBorder", title, content, null);
        }

        public static void RenderSpecialSmall(TextWriter writer, string title, string content, string bottom) {
            WriteCenterContent(writer, "specialSmallBorder", title, content, bottom);
        }

        public static void RenderSmallNoBottom(TextWriter writer, string title, string content) {
            WriteCenterContent(writer, "smallBorder", title, content, null);
        }

        public static void RenderSmallContent(TextWriter writer, string content) {
            WriteCenterContent(writer, "smallBorder", null, content, null);
        }

        public static void RenderSmallGold(TextWriter writer, string title, string content, string bottom) {
            WriteCenterContent(writer, "smallBorder", title, content, bottom);
        }

        public static void RenderStraightSmall(TextWriter writer, string title, string content) {
            WriteStraightContent(writer, "straightSmallBorder", title, content);
        }

        public static void RenderByRace(TextWriter writer, string title, string content) {
            writer.Write("<div class='borderByRace {0}'>", PlayerUtils.Current.RaceInfo.Race);
            writer.Write("<div class='interactions'>{0}</div>",title);
            writer.Write("<div class='globalMessages'>{0}</div>",content);
            writer.Write("</div>");
        }

        public static void RenderByRaceInformation(TextWriter writer, string title, string content) {
            writer.Write("<div class='borderByRace {0}'>", PlayerUtils.Current.RaceInfo.Race);
            writer.Write("<div class='interactions'>{0}</div>", title);
            writer.Write("<div class='globalMessagesInformation'>{0}</div>", content);
            writer.Write("</div>");
        }

        #endregion Public

    }


}
