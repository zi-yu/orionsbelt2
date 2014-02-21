using System.Collections.Generic;
using System.IO;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface.Engine {

	public class RightBattleMenu2 : RightBattleMenuBase {
		
		#region Public

		public static void Render(TextWriter writer, OptionType optionType, IBattleInfo battleInfo) {
			writer.Write("<div id='rightBattleMenu'>");
			writer.Write("<h3>{0}</h3>",LanguageManager.Instance.Get("Options"));
			RenderOptions(writer, optionType, battleInfo.IsDeployTime);
			
			RenderTurnMoves(writer, optionType);
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("Quantity"));
			writer.Write("<div class='quantityToMoveMenu'>");
            writer.Write("{0}:<input id='quantity' type='text' /><br/>", LanguageManager.Instance.Get("InsertQuantity"));
			if (!battleInfo.IsDeployTime){
                writer.Write("{0}:<span id='minquantity'></span><br/>", LanguageManager.Instance.Get("MinQuantity"));
                writer.Write("{0}:<span id='maxquantity'></span><br/>", LanguageManager.Instance.Get("MaxQuantity"));
			}
			writer.Write("</div>");
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("UnitsDestroyed"));
			writer.Write("<div class='unitsDestroyedMenu'><div id='damage'></div></div>");
			RenderSavePositioning(writer, optionType, battleInfo.BattleMode);
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("RotateUnit"));
			RenderRotationTable(writer);
			writer.Write("</div>");
		}

		private static void RenderSavePositioning(TextWriter writer, OptionType optionType, BattleMode mode) {
			if (mode == BattleMode.Tournament && optionType == OptionType.Deploy) {
				writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("SaveDeploy"));
				writer.Write("<div class='optionMenu'>");
				writer.Write("<div class='saveDeploy'><div id='saveDeploy' onClick='Positioning.saveDeploy();'>{0}</div></div>", LanguageManager.Instance.Get("SaveDeploy"));
				writer.Write("<div class='loadDeploy'><div id='loadDeploy' onClick='Positioning.loadDeploy();'>{0}</div></div>", LanguageManager.Instance.Get("LoadDeploy"));
				writer.Write("</div>");
			}
		}

		#endregion Public

	}
}