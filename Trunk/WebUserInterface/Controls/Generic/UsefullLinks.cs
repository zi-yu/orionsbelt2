using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.Generic;
using OrionsBelt.DataAccessLayer;
using System;
using Loki.DataRepresentation;
using System.Web.Caching;

namespace OrionsBelt.WebUserInterface.Controls {

    public class UsefullLinks : Control {

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<div class='usefullinks'>");
            writer.Write("<h5>{0}</h5>", LanguageManager.Instance.Get("UsefulLinks"));
            writer.Write("<ul>");
			writer.Write("<li><a href='{0}Terms.aspx'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get("TermsConditions"));
            writer.Write("<li><a href='{0}Contact.aspx'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get("ContactUs"));
            writer.Write("<li><a href='{0}'>{1}</a></li>", TutorialManager.GetHref(), LanguageManager.Instance.Get("PageTutorial"));
            writer.Write("<li><a href='{0}Account/Invite.aspx'>{1}</a></li>", WebUtilities.ApplicationPath, LanguageManager.Instance.Get("InviteAFriend"));
            writer.Write("<li><a href='#topView'>&uArr; {0}</a></li>", LanguageManager.Instance.Get("Top"));
            writer.Write("</ul>");

            writer.Write("<ul id='socialLinks'>");
            writer.Write("<li><a href='http://www.facebook.com/pages/Orions-Belt/52655038458'><img src='http://static.zi-yu.com/Social/24X24/facebook.png' alt='Facebook' title='Facebook'/></a></li>");
            writer.Write("<li><a href='http://twitter.com/orionsbelt'><img src='http://static.zi-yu.com/Social/24X24/twitter.png' alt='Twitter' title='Twitter'/></a></li>");
            writer.Write("<li><a href='http://www.linkedin.com/groups?gid=100018'><img src='http://static.zi-yu.com/Social/24X24/linkedin.png' alt='LinkedIn' title='LinkedIn'/></a></li>");
            writer.Write("<li><a href='http://technorati.com/blogs/blog.orionsbelt.eu?reactions'><img src='http://static.zi-yu.com/Social/24X24/technorati.png' alt='Technorati' title='Technorati'/></a></li>");
            writer.Write("</ul>");

            writer.Write("</div>");
        }

        #endregion Rendering

    };
}

