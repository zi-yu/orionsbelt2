using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using System.Web;
using OrionsBelt.Core;

namespace OrionsBelt.WebUserInterface.Controls {
	public class GlobalMenu: Control {

		#region Private

		private static void WriteVote(HtmlTextWriter writer) {
			writer.Write("<li><a href='{1}VotePage.aspx' target='_top' class='highlight' >{0}</a></li>",
				LanguageManager.Instance.Get("Vote"), WebUtilities.ApplicationPath);
		}

		private static void WriteAnchorToBase(HtmlTextWriter writer, string anchor, string caption) {
            writer.Write("<li><a href='{2}{0}' target='_top'>{1}</a></li>", anchor,
				LanguageManager.Instance.Get(caption), WebUtilities.ApplicationPath );
        }

		private static void WriteSeparator( HtmlTextWriter writer, string className ) {
			writer.Write("<li class='{0}'><span/></li>",className);
		}

		private static void WriteSeparator(HtmlTextWriter writer) {
			WriteSeparator(writer, "globalMenuSeparator");
		}

		#endregion Private

		#region Constrol Fields

		protected override void Render( HtmlTextWriter writer ) {
			writer.Write("<div id='globalMenu'><ul>");


			WriteSeparator(writer, "globalMenuFirst");
            CheckImpersonating(writer);
            if (HttpContext.Current.User.IsInRole("gameMaster"))  {
                WriteAnchorToBase(writer, "Stats/Default.aspx", "Stats");
                WriteSeparator(writer);
            }
            if ( Utils.PrincipalExists && Utils.Principal.IsInRole("admin") )
            {
                WriteAnchorToBase(writer, "Admin/default.aspx", "Admin");
                WriteSeparator(writer);
            }

			WriteAnchorToBase(writer, "Account/Payment.aspx", "BuyOrions");
			WriteSeparator(writer);
			WriteAnchorToBase(writer, "Account/Shop.aspx", "Premium");
			WriteSeparator(writer);
			WriteVote(writer);
			WriteSeparator(writer);
            WriteAnchorToBase(writer, "PrincipalInfo.aspx?Account=true", "Account");
            WriteSeparator(writer);
			WriteAnchorToBase(writer, "Default.aspx", "Game");
            WriteSeparator(writer);
			WriteAnchorToBase(writer, "Tournaments.aspx", "WarZone");
			WriteSeparator(writer);
            WriteAnchorToBase(writer, "Tops/Score.aspx", "Tops");
            WriteSeparator(writer);
            WriteAnchorToBase(writer, "Manual.aspx", "Manual");
            WriteSeparator(writer);
			if (WebUtilities.IsForumAvailable) {
                WriteAnchorToBase(writer, "Forum.aspx", "Forum");
                WriteSeparator(writer);
            }
			
            if (HttpContext.Current.User.IsInRole("user")) {
                writer.Write("<li><a href='javascript:Site.logout();'>{0}</a></li>", LanguageManager.Instance.Get("Logout"), Utils.Principal.Name);
            } else {
                WriteAnchorToBase(writer, "Login.aspx", "Login");
            }

			writer.Write("</ul></div>");
		}

        private void CheckImpersonating(HtmlTextWriter writer)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Impersonate"];
            if (cookie != null && !string.IsNullOrEmpty(cookie.Value)) {
                writer.Write("<li><a href='{0}Default.aspx?UnImpersonate=1' target='_top'><span class='red'>UnImpersonate</span></a></li>",  WebUtilities.ApplicationPath);
                WriteSeparator(writer);
            }
        }

        

		#endregion Constrol Fields
	}
}

