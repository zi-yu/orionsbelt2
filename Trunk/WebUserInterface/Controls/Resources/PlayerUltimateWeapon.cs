using System.IO;
using OrionsBelt.Engine;
using System.Web.UI;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls{
	public class PlayerUltimateWeapon : ControlBase {

		#region Renders

		private static void RenderUltimate(TextWriter writer, string ultimateName, string manual) {
			IPlayer player = PlayerUtils.Current;

			writer.Write("href='{1}Manual.aspx?path=Universe/{0}.aspx' ", manual, WebUtilities.ApplicationPath);
			if (player.UltimateWeaponLevel > 0) {
				IUltimateWeapon ultimate = UltimateWeaponChooser.GetUltimateWeapon(player);
				string level = string.Format("({0} {1})", LanguageManager.Localize("Level"), player.UltimateWeaponLevel);
				if (PlayerUtils.Current.HasUltimateCooldown) {
					string text = string.Format(LanguageManager.Instance.Get(ultimateName + "Cooldown"), player.UltimateWeaponCooldown);
					writer.Write("title='{1} {2}' alt='{1} {2}'><div id='ultimatePanel' class='{0}Cooldown", ultimateName, text, level);
				}else {
					if( ultimate.IsReady(PlayerUtils.Current) ) {
						writer.Write("title='{1} {2}' alt='{1} {2}'><div id='ultimatePanel' class='{0}Ready", ultimateName, LanguageManager.Localize(ultimateName + "Ready"), level);	
					} else {
						writer.Write("title='{1} {2}' alt='{1} {2}'><div id='ultimatePanel' class='{0}NotReady", ultimateName, LanguageManager.Localize(ultimateName + "NotReady"), level);
					}
				} 
			} else {
				writer.Write("title='{1}' alt='{1}'><div id='ultimatePanel' class='{0}NotAvailable", ultimateName, LanguageManager.Localize(ultimateName + "NotAvailable"));
			}
		}

		#endregion

        #region Control Events

        protected override void Render(HtmlTextWriter writer){
			writer.Write("<a ");
			switch(PlayerUtils.Current.RaceInfo.Race) {
				case Race.Bugs:
					RenderUltimate(writer, "WormHole", "WormHole");
					break;
				case Race.DarkHumans:
					RenderUltimate(writer, "Devastation", "DevastationAttack");
					break;
				case Race.LightHumans:
					RenderUltimate(writer, "Beacon","Beacon");
					break;
			}
			writer.Write("'></div></a>");
        }

		#endregion Control Events

    };
}
