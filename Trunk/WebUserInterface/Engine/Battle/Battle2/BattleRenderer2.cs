using System.Collections.Generic;
using System.IO;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.WebBattle;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public class BattleRenderer2: BattleRendererBase2 {

		#region Private

		/// <summary>
		/// Writes an element and adds the effects to the StringBuilder
		/// </summary>
		/// <param name="coord">Coordinate to render</param>
		/// <param name="board">Board</param>
		/// <returns></returns>
		protected void WriteElement( string coord, Dictionary<string, IElement> board ) {
			IElement e = null;
			if( board.ContainsKey(coord) ) {
				e = board[coord];
				AddJsonElement(e);
			}
			WriteCoordinate(coord, e);
		}

		/// <summary>
		/// Writes the game Board
		/// </summary>
		protected override void WriteBoard() {
			writer.Write("<table id='board2'><tbody>");
			Dictionary<string, IElement> board = battleInfo.GetBoard(battlePlayer);
			for( int i = 1; i < 9; ++i ) {
				writer.Write("<tr>");
				for( int j = 1; j < 9; ++j ) {
					string coord = string.Format("{0}_{1}", i, j);
					WriteElement(coord, board);
				}
				writer.Write("</tr>");
			}
			writer.Write("</tbody></table>");
		}
		
		/// <summary>
		/// Writes the element of an enemy
		/// </summary>
		/// <param name="coord">Coordinate</param>
		/// <param name="e">Element</param>
		private void WriteEnemyElement( string coord, IElement e ) {
			writer.Write("<td id='{0}' class='enemyBorder'><img src='{1}' alt='{2}' title='{3}' isEnemy='true'/></td>",
				coord,
				ResourcesManager.GetUnitImage(e.Unit.Name, e.Position.ToString().ToLower()[0]),
				e.Unit.Name.ToLower(),
				e.Quantity
			);
		}

		private void WriteLayout() {
			InitialContainerManager manager = new InitialContainerManager2(battleInfo.Players, battlePlayer);
			BoardInformation.Render(writer, BattleInfo, manager);

			elementsJson.Append("var BattleElements = {");
			
			writer.Write("<div id='battleArea'>");
            if (!Embedded) {
                WritePlayers();
				WriteEnemyUltimateUnit();
                LeftBattleMenu2.Render(writer, manager);
            }
			WriteCenterLayout(manager);
            if (!Embedded) {
                WriteRightMenu();
            }
			writer.Write("</div>");

			elementsJson.Append("d:1};");
		}

		private void WriteCenterLayout(InitialContainerManager manager) {
			writer.Write("<div id='battleField' class='{0}'>", battleInfo.Terrain);
			WriteBoard();
            if (!Embedded) {
                WriteBottomLayout();
            }
			writer.Write("</div>");
		}

		#region Bottom Layout

		private void WriteBottomLayout() {
			writer.Write("<div id='bottomLayout'>");
			WriteBottomHeader();
			WriteBottomContent();
			writer.Write("</div>");
		}

		private void WriteBottomHeader() {
			writer.Write("<ul>");
			if (battlePlayer.HasUltimateUnit) {
				writer.Write("<li id='pTab1' class='selected'><a href='javascript:Site.selectTab(\"pTab1\");'>{0}</a></li>", LanguageManager.Instance.Get("UltimateUnit"));
				writer.Write("<li id='pTab2'><a href='javascript:Site.selectTab(\"pTab2\");'>{0}</a></li>", LanguageManager.Instance.Get("Calculator"));
			}else {
				writer.Write("<li id='pTab1' class='selected'><a href='javascript:Site.selectTab(\"pTab1\");'>{0}</a></li>", LanguageManager.Instance.Get("Calculator"));
			}

			writer.Write("</ul>");
		}

		private void WriteBottomContent() {
			int i = 1;
			string selected = "class='visible'";
			if (battlePlayer.HasUltimateUnit) {
				writer.Write("<div id='pTab1Content' {0}>", selected);
				WriteUltimateUnit();
				writer.Write("</div>");
				++i;
				selected = "";
			}
			
			writer.Write("<div id='pTab{0}Content' {1}>", i, selected);
			WriteBattleCalculator();
			writer.Write("</div>");
		}

		#endregion Bottom Layout

		#endregion Private

		#region BattleRendererBase Implementation

		/// <summary>
		/// Writes a coordinate
		/// </summary>
		/// <param name="coord">Coordinate to write</param>
		/// <param name="e">Object that represents the element in the coordinate</param>
		protected override void WriteCoordinate( string coord, IElement e ) {
			if( e != null ) {
				if( e.Owner == battlePlayer ) {
					WriteElement(coord, e);
				} else {
					WriteEnemyElement(coord, e);
				}
			} else {
				WriteEmptySquare(coord);
			}
		}

		/// <summary>
		/// Writes the scripts needed for the battle
		/// </summary>
		protected override void WriteScripts() {
			writer.Write("<script type='text/javascript'>var globalCounter = {0}; {1};", battleInfo.CurrentTurn, elementsJson);
			writer.Write("handlerKey = '{0}';</script>", GetScriptHandler());
		}

		/// <summary>
		/// Renders the Board in positioning mod
		/// </summary>
		/// <returns>The HTML code of all the board</returns>
		public override void Render(TextWriter w) {
			if( battleInfo.HasEnded() ) {
				new BattleEndRenderer2(battleInfo, battleOwner).Render( w );
				return;
			}
			writer = w;

			WriteStaticImages();
			WriteLayout();
            if (!Embedded) {
                WriteMessages();
            }
			WriteScripts();
		}

		#endregion BattleRendererBase Implementation

		#region Constructor

		public BattleRenderer2( IBattleInfo battleInfo, IBattleOwner owner)
			: base(battleInfo, owner) {

            if (ChooseOptionType() == OptionType.Turn) {
                TutorialManager.Current = Tutorial.Battle;
            } else {
                TutorialManager.Current = Tutorial.InvalidBattle;
            }
		}

		#endregion Constructor

		
	}
}