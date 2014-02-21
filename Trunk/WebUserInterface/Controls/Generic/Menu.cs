using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class Menu: Control {

		#region Private

		private static void WriteAnchor( HtmlTextWriter writer, string anchor, string caption ) {
			writer.Write("<li><a href='{0}'>{1}</a></li>", anchor, LanguageManager.Instance.Get(caption));
		}

        private static void WriteAnchorToBase(HtmlTextWriter writer, string anchor, string caption)
        {
            writer.Write("<li><a href='{2}{0}'>{1}</a></li>", anchor,
				LanguageManager.Instance.Get(caption), WebUtilities.ApplicationPath );
        }

		private static void WriteSeparator( HtmlTextWriter writer ) {
			writer.Write("<li>|</li>");
		}

		#endregion Private

		#region Constrol Fields

		protected override void Render( HtmlTextWriter writer ) {
			writer.Write("<div id='loginStatus' ><ul>");

            WriteAnchorToBase(writer, "Default.aspx", "Home");
            WriteSeparator(writer);
            WriteAnchor(writer, "http://manual.orionsbelt.eu/en/", "Manual");
            WriteSeparator(writer);

			if( HttpContext.Current.User.IsInRole("guest") ) {
                WriteAnchorToBase(writer, "Login.aspx", "Login");
				WriteSeparator(writer);
                WriteAnchorToBase(writer, "Login.aspx", "Register");
			} else {
				WriteAnchorToBase(writer, "Battle/CreateFriendly.aspx", "CreateFriendly");
				WriteSeparator(writer);
                WriteAnchorToBase(writer, "LadderList.aspx", "LadderList");
				WriteSeparator(writer);
                WriteAnchorToBase(writer, "LadderTeamList.aspx", "LadderTeamList");
				WriteSeparator(writer);
                WriteAnchorToBase(writer, "Tournaments.aspx", "Tournaments");
                WriteSeparator(writer);
                WriteAnchorToBase(writer, "Battle/BattleList.aspx", "BattleList");
                WriteSeparator(writer);
				WriteAnchorToBase(writer, "Universe.aspx", "Universe");
				WriteSeparator(writer);
				WriteAnchorToBase(writer, "Military/Default.aspx", "Military");
				WriteSeparator(writer);
                WriteAnchorToBase(writer, "Arenas/Arena.aspx", "Arena");
                WriteSeparator(writer);
                WriteAnchorToBase(writer, "AuctionHouse/AuctionHouse.aspx", "AuctionHouse");
                WriteSeparator(writer);
                WriteAnchorToBase(writer, "Tops/Score.aspx", "Tops");
                WriteSeparator(writer);
                if (PlayerUtils.HasPlayer){
                    WriteAnchorToBase(writer, string.Format("Planets/Default.aspx?Id={0}", PlayerUtils.Current.Storage.HomePlanetId), "Planets");
                }
                WriteSeparator(writer);
                WriteAllianceLink(writer);
                WriteSeparator(writer);
                writer.Write("<li><a href='javascript:Site.logout();'>{0} ({1})</a></li>", LanguageManager.Instance.Get("Logout"),Utils.Principal.DisplayName);

				if( Utils.Principal.IsInRole("admin") ) {
					WriteSeparator(writer);
                    WriteAnchorToBase(writer, "Admin/Default.aspx","Admin");
				}
			}

			writer.Write("</ul></div>");
		}

        private static void WriteAllianceLink(HtmlTextWriter writer)
        {
            WriteAnchorToBase(writer, "Alliance/Default.aspx", "Alliance");
        }

		#endregion Constrol Fields

		#region Constructor
		
		static Menu() {
			

		}

		#endregion

	}
}

