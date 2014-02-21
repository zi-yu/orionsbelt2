using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;

namespace OrionsBelt.WebAdmin.Admin.Controls {
	public class LeftMenu : Control {
		
		#region Fields
		
		private string[] state = { "Application", "Session", "Cache", "Items" };
		private string[] utilities = { "SmtpSettings", "HttpHeaders", "HqlAnalyser", "SqlAnalyser", "SendMail" };
		private string[] entities =	{ "ActivatedPromotion","AllianceDiplomacy","AllianceStorage","ArenaHistorical","ArenaStorage","Asset","AuctionHouse","Battle","BattleExtention","BattleStats","BidHistorical","BonusCard","BotCredential","BotHandler","Campaign","CampaignLevel","CampaignStatus","Country","DuplicateDetection","ExceptionInfo","Fleet","FogOfWarStorage","ForumPost","ForumReadMarking","ForumThread","ForumTopic","FriendOrFoe","GlobalStats","GroupPointsStorage","Interaction","Invoice","LogStorage","Market","Medal","Message","Necessity","Offering","Payment","PaymentDescription","PendingBotRequest","PlanetResourceStorage","PlanetStorage","PlayerBattleInformation","PlayersGroupStorage","PlayerStats","PlayerStorage","Principal","PrincipalStats","PrincipalTournament","PrivateBoard","Product","Promotion","QuestStorage","SectorStorage","ServerProperties","SpecialEvent","Task","TeamStorage","TimedActionStorage","Tournament","Transaction","UniverseSpecialSector","VoteReferral","VoteStorage","WormHolePlayers" };
		
		#endregion
		
		#region Private

		private void WriteMenu( HtmlTextWriter writer, string name, string[] menu ) {
			writer.Write( "<dt>{0}</dt>", name );
			foreach( string s in menu ) {
				WriteLine( writer, s );
			}
		}

		private void WriteLine( HtmlTextWriter writer, string s ) {
			object entity = HttpContext.Current.Session["CurrentEntity"];
			if( entity != null && s.ToLower() == entity.ToString() ) {
				writer.Write( "<dd class='active'><a href='{0}Home.aspx'>{1}</a></dd>", s.ToLower(), s );
			} else {
				writer.Write( "<dd><a href='{0}Home.aspx'>{1}</a></dd>", s.ToLower(), s );
			}
		}
		
		#endregion
		
		#region Events

		protected override void Render( HtmlTextWriter writer ) {
			writer.Write( "<dl>" );

			object entity = HttpContext.Current.Session["CurrentEntity"];
			
			WriteMenu( writer, "State", state );
			WriteMenu( writer, "Utilities", utilities );
			WriteMenu( writer, "Entities", entities );
			
			writer.Write( "</dl>" );

			base.Render( writer );
		}
		
		#endregion
		
	}
}
