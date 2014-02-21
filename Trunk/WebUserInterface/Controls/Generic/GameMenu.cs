using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Engine;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using System.Web;
using System;

namespace OrionsBelt.WebUserInterface.Controls {
	public class GameMenu : Control {

        #region Private

        private static bool HaveMessages() {
	        if (null == HttpContext.Current.Request.Cookies["HasMessages"]){
	            bool haveMessages = WebUtilities.HaveMessages();
	            WebUtilities.ForceHasMessages(haveMessages);
                return haveMessages;
	        }
	        return Convert.ToBoolean(HttpContext.Current.Request.Cookies["HasMessages"].Value);
	    }

	    #endregion
	   
		#region Protected

		protected static void WriteAnchorToBase(HtmlTextWriter writer, string anchor, string caption) {
            writer.Write("<li>");
            writer.Write("<a href='{2}{0}'><div class='menuImg {3}Img'></div>{1}</a>", anchor,
				LanguageManager.Instance.Get(caption), WebUtilities.ApplicationPath, caption);
            writer.Write("</li>");
		}

        protected static void WriteAnchorToBase(HtmlTextWriter writer, string anchor, string caption, string className){
            writer.Write("<li class='{3}'><a href='{2}{0}'><div class='menuImg {4}Img'></div>{1}</a></li>", anchor,
				LanguageManager.Instance.Get(caption), WebUtilities.ApplicationPath, className, caption);
		}

        protected static void WritePrimaryMessageBoard(HtmlTextWriter writer){
            writer.Write("<li class='gameMenuSeparator'><div id='primaryMessageBoard'>");

            bool haveBattles = WebUtilities.HasBattles;

            if(haveBattles)
            {
                writer.Write("<div><a id='haveBattles' href='{1}Battle/Default.aspx'>{0}</a></div>", LanguageManager.Instance.Get("HaveBattles"), WebUtilities.ApplicationPath);
            }
            else
            {
                bool haveMessages = HaveMessages();

                if (haveMessages)
                {
                    writer.Write("<div><a href='{2}{1}{3}'><span class='green'>{0}</span></a></div>", LanguageManager.Instance.Get("HaveMessages"),
                    "PlayerInfo.aspx?PlayerStorage=", WebUtilities.ApplicationPath, PlayerUtils.Current.Id);
                }
                else
                {
                    IList<string> options = GetOptions();

                    Random r = new Random();
                    writer.Write(options[r.Next(options.Count)]);
                }
            }
            //writer.Write("<div><span class='green'><a href='http://blog.orionsbelt.eu/?p=1266'>OB lunch</a</span></div>");
            writer.Write("</div></li>");
		}

	    private static IList<string> GetOptions()
	    {
	        IList<string> options = new List<string>();
	        options.Add(string.Format("<div><a href='{2}{1}'>{0}</a></div>", LanguageManager.Instance.Get("OBShop"),
	                                  "Account/Shop.aspx", WebUtilities.ApplicationPath));
	        options.Add(string.Format("<div><a href='{2}{1}'>{0}</a></div>", LanguageManager.Instance.Get("BuyOrions"),
	                                  "Account/Payment.aspx", WebUtilities.ApplicationPath));
            options.Add(string.Format("<div><a href='{2}{1}'>{0}</a></div>", LanguageManager.Instance.Get("Bounties"),
                                      "Quests/Bounties.aspx", WebUtilities.ApplicationPath));
	        return options;
	    }

	    protected static void WriteAllianceLink(HtmlTextWriter writer){
            WriteAnchorToBase(writer, "Alliance/Default.aspx", "Alliance");
		}

        protected static void WritePlanetsLink(HtmlTextWriter writer){
            string url = string.Format("Planets/Default.aspx?Id={0}", PlayerUtils.Current.HomePlanetId);
            WriteAnchorToBase(writer, url, "Planets");
        }

		#endregion Private

		#region Constrol Fields

		protected override void Render( HtmlTextWriter writer ) {
			writer.Write("<div id='gameMenu'><ul>");
			WriteAnchorToBase(writer, "Default.aspx", "Home");
			WriteAnchorToBase(writer, "Universe.aspx", "Universe");
            WritePlanetsLink(writer);
			WriteAnchorToBase(writer, "AuctionHouse/AuctionHouse.aspx", "AuctionHouse", "inside");
			WritePrimaryMessageBoard(writer);
			WriteAnchorToBase(writer, "Battle/Default.aspx", "Battles", "inside");
			WriteAnchorToBase(writer, "Military/Default.aspx", "Military");
			WriteAllianceLink(writer);
			WriteAnchorToBase(writer, "Quests/Default.aspx", "Quests", "last");

			writer.Write("</ul></div>");
		}

		#endregion Constrol Fields
	}
}

