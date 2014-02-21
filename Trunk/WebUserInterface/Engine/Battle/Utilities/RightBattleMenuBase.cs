using System.Collections.Generic;
using System.IO;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Engine {

	public enum OptionType {
		Spectator,
		Deploy,
		Turn,
		OtherPlayerTurn,
		Ended,
        Vacations,
		General
	}

	public class RightBattleMenuBase {
		
		#region Fields

		protected delegate void RenderOption(TextWriter writer, bool isDeployTime);
		protected static readonly Dictionary<OptionType, RenderOption> mapping = new Dictionary<OptionType, RenderOption>();
		
		#endregion Fields

		#region Delegates

		protected static void WriteDiv(TextWriter writer, string className, string id, string caption) {
			writer.Write("<div class='{0}'><div id='{1}'>{2}</div></div>", className, id, LanguageManager.Instance.Get(caption));
		}

		protected static void RenderSpectator(TextWriter writer, bool isDeployTime) {
		}

		protected static void RenderOtherPlayerTurn(TextWriter writer, bool isDeployTime) {
			if (!isDeployTime){
				WriteDiv(writer, "giveUpOtherPlayer", "giveUp", "GiveUp");
			}
		}

		protected static void RenderPosition(TextWriter writer, bool isDeployTime) {
			WriteDiv(writer, "resetPosition", "reset", "Reset");
			WriteDiv(writer, "position", "submit", "Deploy");
		}

		protected static void RenderTurn(TextWriter writer, bool isDeployTime) {
			WriteDiv(writer, "undo", "undo", "Undo");
			WriteDiv(writer, "reset", "reset", "Reset");
			WriteDiv(writer, "giveUp", "giveUp", "GiveUp");
			WriteDiv(writer, "makeMove", "submit", "EndTurn");
		}

		protected static void RenderEnded(TextWriter writer, bool isDeployTime) {
			writer.Write("<div class='replay'>");
			writer.Write("<table><tbody>");
			writer.Write("<tr><td rowspan='2' id='p2' onclick='Replay.loadFirstTurn();'></td><td id='p' onclick='Replay.backward();'></td><td colspan='2' id='play'></td><td id='n' onclick='Replay.forward();'></td><td rowspan='2' id='n2' onclick='Replay.loadLastTurn();'></td></tr>");
			writer.Write("<tr><td colspan='2' id='p1' onclick='Replay.previousTurn();'></td><td colspan='2' id='n1' onclick='Replay.nextTurn();'></td></tr>");
			writer.Write("</tbody></table>");
			writer.Write("</div>");
		}

        protected static void RenderVacations(TextWriter writer, bool isDeployTime) {
			writer.Write("<div class='battleVacations'><img src='{0}' alt='{1}' title='{1}'/></div>", ResourcesManager.GetBattleImage("Vacations"), LanguageManager.Instance.Get("Vacations"));
		}

		protected static void RenderGeneral(TextWriter writer, bool isDeployTime) {
			writer.Write("<div class='battleGeneral'>General</div>");
		}

		#endregion Delegates

		#region protected

		protected static void RenderOptions(TextWriter writer, OptionType optionType, bool isDeployTime) {
			writer.Write("<div class='optionMenu'>");
			mapping[optionType](writer, isDeployTime);
			writer.Write("</div>");
		}

		protected static void RenderRotationTable(TextWriter writer) {
			writer.Write("<div class='rotationMenu'><div id='rotationOption'>");
			writer.Write("<table><tbody>");
			writer.Write("<tr><td></td><td id='b'></td><td></td></tr>");
			writer.Write("<tr><td id='d'></td><td></td><td id='e'></td></tr>");
			writer.Write("<tr><td></td><td id='g'></td><td></td></tr>");
			writer.Write("</tbody></table></div></div>");
		}

		protected static void RenderTurnMoves(TextWriter writer, OptionType optionType) {
			if (optionType == OptionType.Ended) {
				writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("Turn"));
				writer.Write("<div class='totalMovesMenu'><div id='turn'>0</div></div>");
			} else {
				writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("MovesLeft"));
				writer.Write("<div class='totalMovesMenu'><div id='moves'>6</div></div>");
			}
		}


		#endregion protected

		#region Public

		
		#endregion Public

		#region Constructor

		static RightBattleMenuBase() {
			mapping[OptionType.Spectator] = RenderSpectator;
			mapping[OptionType.Deploy] = RenderPosition;
			mapping[OptionType.Turn] = RenderTurn;
			mapping[OptionType.Ended] = RenderEnded;
			mapping[OptionType.OtherPlayerTurn] = RenderOtherPlayerTurn;
            mapping[OptionType.Vacations] = RenderVacations;
			mapping[OptionType.General] = RenderGeneral;
		}

		#endregion Constructor

	}
}