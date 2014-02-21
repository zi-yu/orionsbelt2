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
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Engine.Alliances;
using OrionsBelt.Core;
using System.Collections.Generic;
using OrionsBelt.Engine;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Generic.Messages;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using System.IO;

namespace OrionsBelt.WebUserInterface.Account
{
    public class ReferrerPage : System.Web.UI.Page {

        #region Fields

        protected PrincipalPagedList referrals;
        protected Literal referralsMessage;
        protected Literal content;
        protected Literal referalLink;

        #endregion Fields

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            referrals.Collection = Hql.StatelessQuery<Principal>("from SpecializedPrincipal p where p.ReferrerId = :id order by p.CreatedDate desc", Hql.Param("id", Utils.Principal));
            if (referrals.Collection.Count == 0) {
                referralsMessage.Text = LanguageManager.Instance.Get("NoRecruitedPlayersYet");
            }
            SetContent();
        }

        private void SetContent()
        {
            content.Text = string.Format("<p>{0}</p>", LanguageManager.Instance.Get("YourReferralLinkIntro"));
            referalLink.Text = string.Format("<div class='referalLink'><span>http://www.orionsbelt.eu/?Server={0}&Referrer={1}</span></div>", OrionsBelt.Generic.Server.Properties.Name, Utils.Principal.Id);

            StringWriter writer = new StringWriter();

            WriteBanner(writer, "Banner01_468x60.jpg", 480, 60);
            WriteBanner(writer, "Banner01_120x600.jpg", 120, 600);
            WriteBanner(writer, "Banner01_125x125.jpg", 125, 125);
            WriteBanner(writer, "Banner01_120x240.jpg", 120, 240);
            WriteBanner(writer, "Banner01_234x60.jpg", 234, 60);

            WriteForumBanners(writer);

            referralsMessage.Text = writer.ToString();

            
        }

        private void WriteForumBanners(StringWriter writer) {
            writer.Write("<div id='forumBanner' class='referalBanner'>");
            writer.Write("<h4>Forum</h4>");



            WriteImage(writer, "DoomerBanner.jpg", 300, 40);
            WriteImage(writer, "FenixBanner.jpg", 300, 40);
            WriteImage(writer, "FlagBanner.jpg", 300, 40);
            WriteImage(writer, "PretorianBanner.jpg", 300, 40);
            WriteImage(writer, "SpiderBanner.jpg", 300, 40);
            WriteImage(writer, "ToxicBanner.jpg", 300, 40);

            WriteImage(writer, "OrionsBeltBanner.jpg", 350, 19);
            WriteImage(writer, "OrionsBeltBanner2.jpg", 350, 19);
            WriteImage(writer, "Banner01_100x15.jpg", 100, 15);
            
            writer.Write("</div>");
        }

        private string WriteImage(TextWriter writer, string imageName, int w, int h) {
            string code = string.Format("<a href='http://www.orionsbelt.eu?Server={0}&Referrer={1}' title='Orion´s Belt Browser Game'><img style='border:none;' src='{2}/Banners/{3}' width='{4}px' height='{5}px' alt='Orion´s Belt Browser Game'/></a>",
                 OrionsBelt.Generic.Server.Properties.Name,
                 Utils.Principal.Id,
                 ResourcesManager.ImagesCommonPath,
                 imageName,
                 w,
                 h
             );

            writer.Write(code);

            return Server.HtmlEncode(code);
        }

        private void WriteBanner(TextWriter writer, string imageName, int w, int h)
        {

            writer.Write("<div id='banner{0}x{1}' class='referalBanner'>",w,h);
            writer.Write("<h4>Banner {0}x{1}</h4>", w, h);

            string code = WriteImage(writer, imageName, w, h);

            writer.Write("<div class='bannerHtml'>{0}</div>", code);
            writer.Write("</div>");
        }

        #endregion Events

    };
}
