using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.WebComponents;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;
using System.IO;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {

    public static class GenericRenderer  {

        #region Buttons

        internal static void WriteLeftLinkButton(TextWriter writer, string href, string text)
        {
			writer.Write("<div class='buttonFixed'><a href='{0}'><div>{1}</div></a></div>", href, text);
        }

        internal static void WriteRightLinkButton(TextWriter writer, string href, string text)
        {
			writer.Write("<div class='button'><a href='{0}'><div>{1}</div></a></div>", href, text);
        }

        internal static void WriteBigCenterLinkButton(TextWriter writer, string href, string text)
        {
            writer.Write("<div class='button'><a href='{0}'><div>{1}</div></a></div>", href, text);
        }

        internal static void WriteSmallCenterLinkButton(TextWriter writer, string href, string text) {
            writer.Write("<div class='buttonSmall'><a href='{0}'><div>{1}</div></a></div>", href, text);
        }

		internal static void WriteInputButton(TextWriter writer, string id, string text) {
			writer.Write("<input id='{0}' class='button' type='button' value='{1}'/>", id, text);
		}

		internal static void WriteInputButton(TextWriter writer, string id, string text, string clickEvent) {
			writer.Write("<input id='{0}' class='button' type='button' value='{1}' onclick='{2}'/>", id, text, clickEvent);
		}

        #endregion Button

        #region Resources

        public static void RenderResourceQuantityList(TextWriter writer, IEnumerable<KeyValuePair<IResourceInfo, int>> resources, params string[] args)
        { 
            writer.Write("<ul class='resources'>");
            foreach (KeyValuePair<IResourceInfo, int> cost in resources) {
                writer.Write("<li>");
                writer.Write(cost.Value);
                writer.Write(" ");
                writer.Write("{0}",ResourcesManager.GetResourceSmallImageHtml(cost.Key));
                writer.Write("</li>");
            }
            if( args != null ) {
                foreach (string arg in args) {
                    writer.Write("<li>");
                    writer.Write(arg);
                    writer.Write("</li>");
                }
            }
            writer.Write("</ul>");
        }

        //public static void RenderRules(TextWriter writer, IEnumerable<IRule> rules)
        //{
        //    writer.Write("<ul class='rules'>");
        //    foreach (IRule rule in rules) {
        //        string ruleStr = rule.ToString(LanguageParameterTranslator.Instance, 1);
        //        if (!string.IsNullOrEmpty(ruleStr)){
        //            writer.Write("<li>");
        //            writer.Write(ruleStr);
        //            writer.Write("</li>");
        //        }
        //    }
        //    writer.Write("</ul>");
        //}

        #endregion Resources

    };
}
