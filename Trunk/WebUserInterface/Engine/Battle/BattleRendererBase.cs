using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using System.Text;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public abstract class BattleRendererBase {

		#region Fields

		protected readonly IBattleInfo battleInfo;
		protected readonly IBattleOwner battleOwner;
		protected readonly IBattlePlayer battlePlayer;
		protected readonly BattleMessages battleMessages;
		protected TextWriter writer;
		protected readonly StringBuilder elementsJson = new StringBuilder();
		protected readonly bool isSpectator = false;
        private bool embedded = false;
        private bool isPreview = false;

		#endregion Fields

		#region Properties

		public IBattleInfo BattleInfo {
			get { return battleInfo; }
		}

        public bool Embedded {
            get { return embedded; }
            set { embedded = value; }
        }

        public bool IsPreview {
            get { return isPreview; }
            set { isPreview = value; Embedded = value; }
        }

		public bool IsSpectactor {
			get { return isSpectator; }
		}

		#endregion Properties

		#region Public

		public virtual void RegisterFields( Page page ) {
			page.ClientScript.RegisterHiddenField("movesMade", string.Empty);
			page.ClientScript.RegisterHiddenField("numberOfPlayers", battleInfo.NumberOfPlayers.ToString());
		}

		/// <summary>
		/// Renders the Board in positioning mod
		/// </summary>
		/// <returns>The HTML code of all the board</returns>
		public virtual string Render() {
			StringBuilder builder = new StringBuilder();
			StringWriter w = new StringWriter(builder);
			Render(w);
			return w.ToString();
		}

		#endregion Public

		#region Protected

		#region Scripts

		#region Json

		protected void AddJsonElement(IElement e) {
			string json = e.ToJson();
			if (json.Length > 0) {
				elementsJson.AppendFormat("{0},", json);
			}
		}

		#endregion Json

		/// <summary>
		/// Writes the scrips of this page
		/// </summary>
		protected virtual void WriteScripts() {
			writer.Write("<script type='text/javascript'>handlerKey = '{0}';var BattleElements={{}};</script>", GetScriptHandler());
		}

		/// <summary>
		/// Obtains the handler to execute in the end of the page load (client site)
		/// </summary>
		/// <returns>A string with the handler name</returns>
		protected string GetScriptHandler() {
			if (battleInfo.HasEnded() || IsSpectactor || battleOwner.IsOnVacations) {
				return "fill";
			}

			if( !battlePlayer.HasPositioned ) {
				return "positioning";
			}

			if( battlePlayer.IsTurn && !battleInfo.IsDeployTime) {
				return "battle";
			}

			return "fill";
		}

		protected void WriteReplayScripts() {
			BattleReplayInformation rp = new BattleReplayInformation(battleInfo,battlePlayer);
			writer.Write("<script type='text/javascript'>var movesList = {0}; var finalState = {1}; var movesIndexes = {2};</script>", rp.MovesList, rp.BattleFinalState, rp.MovesIndexes);
		}

		#endregion Scripts

		#region Writers

		/// <summary>
		/// Write board element
		/// </summary>
		/// <param name="coord">Coordinate of the element</param>
		/// <param name="e">Object that represents the element</param>
		protected void WriteElement( string coord, IElement e ) {
			writer.Write("<td id='{0}'><img src='{1}' alt='{2}' title='{3}' isEnemy='false' isFriendly='false' isInfestated='{4}'/></td>",
				coord,
				ResourcesManager.GetUnitImage(e.Unit.Name, e.Position.ToString().ToLower()[0]),
				e.Unit.Name.ToLower(),
				e.Quantity,
                e.IsInfestated.ToString().ToLower()
			);
		}

		/// <summary>
		/// Writes an empty Square
		/// </summary>
		/// <param name="id">Id of the Square</param>
		protected void WriteEmptySquare( string id ) {
			writer.Write("<td id='{0}'><span/></td>", id);
		}

		/// <summary>
		/// Writes the vertical coordinate numbers, X
		/// </summary>
		protected void WriteVerticalNumbers( int max ) {
			writer.Write("<td><table id='verticalGrid'><tbody>");
			for( int i = 1; i < max; ++i ) {
				writer.Write("<tr><td>{0}</td></tr>", i);
			}
			writer.Write("</tbody></table></td>");
		}

		/// <summary>
		/// Writes the horizontal coordinate numbers, Y
		/// </summary>
		protected void WriteHorizontalNumbers( int max ) {
			writer.Write("<tr><td colspan='2'><table id='horizontalGrid'><tbody><tr>");
			for( int i = 1; i < max; ++i ) {
				writer.Write("<td>{0}</td>", i);
			}
			writer.Write("</tr></tbody></table></td></tr>");
		}

		/// <summary>
		/// Write static images
		/// </summary>
		protected void WriteStaticImages() {
			writer.Write("<img id='cannotMove' class='invisible' src='{0}' alt=''/>", ResourcesManager.GetBattleImage("arrowRed","gif"));
			writer.Write("<img id='enemy' class='invisible' src='{0}' onclick='AttackUtils.attack();' alt='' />", ResourcesManager.GetBattleImage("enemy","gif"));
		}

		/// <summary>
		/// Render the battle messages
		/// </summary>
		protected void WriteMessages() {
			writer.Write("<div id='messages'>");
			battleMessages.Render(writer);
			writer.Write("</div>");
		} 

		#endregion Writers

		#region Calculator

		private static List<string> AllUnitsInBattle(IBattleInfo battleInfo) {
			List<string> units = new List<string>();
			Dictionary<string, IElement> e = battleInfo.GetBoard(battleInfo.Players[0]);
			foreach (IElement element in e.Values) {
				string name = element.Unit.Name.ToLower();
				if (!units.Contains(name)) {
					units.Add(name);
				}
			}
			return units;
		}

		protected void WriteBattleCalculator() {
			writer.Write("<div id='battleCalculator'>");
			writer.Write("<div id='selectedElement'>");
			writer.Write("<div id='elementSelected'>");
				writer.Write("<div id='elementSelectedImg'></div>");
				writer.Write("<div id='elementSelectedImgQuant'>{0}:<br/><input id='elementSelectedQuantInput' type='text'/></div>", LanguageManager.Instance.Get("Quantity"));
				writer.Write("<div id='elementSelectedRange'>{0}:<br/><input id='elementSelectedRangeInput' type='text'/></div>", LanguageManager.Instance.Get("Range"));
			writer.Write("</div>");
			
			writer.Write("<div id='enemyElements'>");
			List<string> units = AllUnitsInBattle(battleInfo);
			foreach (string unit in units) {
				writer.Write("<div type='{0}'>", unit);
				writer.Write("<img src='{0}' title='{1}' alt='{1}' type='{1}' />", ResourcesManager.GetUnitImage(unit), unit);
				writer.Write("<div>0</div>");
				writer.Write("</div>");
			}

			writer.Write("</div>");
			writer.Write("</div>");
			writer.Write("</div>");
		}

		#endregion Calculator
		
		#region Right Menu

		protected OptionType ChooseOptionType() {
			if (isSpectator || (battleInfo.IsDeployTime && battlePlayer.HasPositioned) ) {
				return OptionType.Spectator;
			}

			if (battleOwner.IsOnVacations) {
				return OptionType.Vacations;
			}

			if (battlePlayer.Owner.HasGeneral ) {
			    return OptionType.General;
			}

			if (!battlePlayer.HasPositioned) {
				return OptionType.Deploy;
			}

			if (battlePlayer.IsTurn) {
				return OptionType.Turn;
			}

			return OptionType.OtherPlayerTurn;
		}

		protected virtual void WriteRightMenu() {
			OptionType type = ChooseOptionType();
			RightBattleMenu2.Render(writer, type, battleInfo);
		}

		#endregion Right Menu

		protected void RenderReplayControl() {
			writer.Write("<div id='replayControl'>");
			writer.Write("<input type='button' value='|&lt;&lt;' onclick='Replay.loadFirstTurn();' />");
			writer.Write("<input type='button' value='&lt;&lt;' onclick='Replay.previousTurn();' />");
			writer.Write("<input type='button' value='&lt;' onclick='Replay.backward();' />");
			writer.Write("<input type='button' value='&gt;' onclick='Replay.forward();' />");
			writer.Write("<input type='button' value='&gt;&gt;' onclick='Replay.nextTurn();' />");
			writer.Write("<input type='button' value='&gt;&gt;|' onclick='Replay.loadLastTurn();' />");
			writer.Write("</div>");
		}

		#endregion Protected

		#region Abstract & Virtual

		public abstract void Render(TextWriter w);

		protected virtual void WriteCoordinate( string coord, IElement e ) { }

		#endregion Abstract & Virtual

		#region Constructor

		public BattleRendererBase( IBattleInfo battleInfo, IBattleOwner battleOwner) {
			this.battleInfo = battleInfo;
			this.battleOwner = battleOwner;
			IBattleOwner owner = BattleOwnerWeb.Get(battleInfo);
			if( owner != null ) {
				isSpectator = battleOwner.Id != owner.Id;
			}else {
				isSpectator = true;
			}
			battlePlayer = battleInfo.GetPlayer(battleOwner);
			battleMessages = new BattleMessages(battleInfo, battleOwner);
		}

		#endregion Constructor
	}
}
