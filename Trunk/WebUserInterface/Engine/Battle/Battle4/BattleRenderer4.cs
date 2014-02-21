using System.Collections.Generic;
using System.IO;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public class BattleRenderer4: BattleRendererBase4 {

		#region Private

		/// <summary>
		/// Writes the game Board
		/// </summary>
		protected override void WriteBoard() {
			writer.Write("<div id='battleField4' class='{0}4'>", battleInfo.Terrain);
			writer.Write("<table id='board4'><tbody>");
			Dictionary<string, IElement> board = battleInfo.GetBoard(battlePlayer);

			elementsJson.Append("var BattleElements = {");
			for( int i = 1; i < 13; ++i ) {
				writer.Write("<tr>");
				for( int j = 1; j < 13; ++j ) {
					string coord = string.Format("{0}_{1}", i, j);
					if( IsToIgnore(coord) ) {
						WriteIgnoreElement(coord);
					} else {
						IElement e = null;
						if( board.ContainsKey(coord) ) {
							e = board[coord];
						}
						WriteCoordinate(coord, e);
					}
				}
				writer.Write("</tr>");
			}

			elementsJson.Append("d:1};");
			writer.Write("</tbody></table>");
		    WriteBottomLayout();
			writer.Write("</div>");
		}

		private void WriteAllBoard() {
			writer.Write("<div id='battleArea4'>");
			WriteBoard();
			WriteRightMenu();
			writer.Write("</div>");
		}

		private void WriteEnemyElement( string coord, IElement e )  {
			writer.Write("<td id='{0}' class='enemyBorder{4}'><img src='{1}' alt='{2}' title='{3}' isEnemy='true' isFriendly='false' /></td>",
				coord,
				ResourcesManager.GetUnitImage(e.Unit.Name, e.Position.ToString().ToLower()[0]),
				e.Unit.Name.ToLower(),
				e.Quantity,
				manager.GetPlayerNumber(e.Owner.PlayerNumber)
			);
		}

		private void WriteFriendlyElement( string coord, IElement e ) {
			writer.Write("<td id='{0}' class='friendlyBorder'><img src='{1}' alt='{2}' title='{3}' isEnemy='false' isFriendly='true'/></td>",
				coord,
				ResourcesManager.GetUnitImage(e.Unit.Name, e.Position.ToString().ToLower()[0]),
				e.Unit.Name.ToLower(),
				e.Quantity
			);
		}

		/// <summary>
		/// Writes a coordinate
		/// </summary>
		/// <param name="coord">Coordinate to write</param>
		/// <param name="e">Object that represents the element in the coordinate</param>
		private void WriteCoordinate( string coord, IElement e ) {
			if( e != null ) {
				AddJsonElement(e);

				if( e.Owner == battlePlayer ) {
					WriteElement(coord, e);
				} else {
					if( e.Owner.TeamNumber == battlePlayer.TeamNumber ) {
						WriteFriendlyElement(coord, e);
					} else {
						WriteEnemyElement(coord, e);
					}
				}
			} else {
				WriteEmptySquare(coord);
			}
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
            writer.Write("<li id='pTab1' class='selected'><a href='javascript:Site.selectTab(\"pTab1\");'>{0}</a></li>", LanguageManager.Instance.Get("Calculator"));
            writer.Write("</ul>");
        }

        private void WriteBottomContent() {
            writer.Write("<div id='pTab1Content' class='visible'>");
            WriteBattleCalculator();
            writer.Write("</div>");
        }

        #endregion Bottom Layout

		#endregion Private

		#region BattleRendererBase Implementation

		/// <summary>
		/// Writes the scripts needed for the battle
		/// </summary>
		protected override void WriteScripts() {
			writer.Write("<script type='text/javascript'>var handlerKey = '{0}'; var globalCounter = {1}; {2}</script>", GetScriptHandler(), battleInfo.CurrentTurn, elementsJson);
		}

		/// <summary>
		/// Renders the Board in positioning mod
		/// </summary>
		/// <returns>The HTML code of all the board</returns>
		public override void Render(TextWriter w) {
			if( battleInfo.HasEnded() ) {
				new BattleEndRenderer4(battleInfo, battleOwner).Render( w );
				return;
			}
			writer = w;

			BoardInformation.Render(writer, BattleInfo, manager);
			WriteStaticImages();
			WriteAllBoard();
			WriteMessages();
			WriteScripts();
		}

		#endregion BattleRendererBase Implementation

		#region Constructor

		public BattleRenderer4( IBattleInfo battleInfo, IBattleOwner owner )
			: base(battleInfo, owner) {
		}

		#endregion Constructor

	}
}
