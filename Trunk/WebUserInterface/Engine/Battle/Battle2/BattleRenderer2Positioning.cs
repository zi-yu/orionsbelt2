using System.Collections.Generic;
using System.IO;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebUserInterface.WebBattle;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public class BattleRenderer2Positioning: BattleRendererBase2 {

		#region Private

		#region Units to Position
		/// <summary>
		/// Writes the bottom initial container
		/// </summary>
		/// <param name="list">List of units to write</param>
		private void WriteBottom(List<IElement> list) {
			writer.Write("<table id='initialBottom'><tbody><tr>");
			foreach (IElement element in list) {
				writer.Write(
					"<td id='{0}'><img src='{1}' title='{2}' alt='{3}' /></td>",
					element.Unit.Name.ToLower(),
					ResourcesManager.GetUnitImage(element.Unit.Name),
					element.Quantity,
					element.Unit.Name.ToLower()
				);
			}

			writer.Write("<td class='initialBottomIgnore'><img src='{0}' alt='' title=''/></td>", ResourcesManager.GetImage("fill.gif"));
			writer.Write("</tr></tbody></table>");
		}

		/// <summary>
		/// Writes the top initial container
		/// </summary>
		/// <param name="list">List of units to write</param>
		private void WriteTop(List<IElement> list) {
			writer.Write("<table id='initialTop'><tbody><tr>");
			foreach (IElement element in list) {
				writer.Write(
					"<td><img src='{0}' title='{1}' alt='{2}' /></td>",
					ResourcesManager.GetUnitImage(element.Unit.Name),
					element.Quantity,
					element.Unit.Name.ToLower()
				);
			}
			writer.Write("</tr></tbody></table>");
		}

		private string GetClassPlayerUltimateUnit(bool isVisible) {
			string uuClass = string.Empty;
			if (battlePlayer.UltimateUnit != null) {
				uuClass = battlePlayer.UltimateUnit.Name;
			}
			if (isVisible) {
				return string.Format("class='visible {0}'", uuClass);
			}
			return string.Format("class='{0}'", uuClass);

		}


		private void WriteUnitsToPosition(InitialContainerManager manager) {
			writer.Write("<div id='initialContainers'>");
			writer.Write("<ul><li id='pTab1' class='selected'><a href='javascript:Site.selectTab(\"pTab1\");'>{0}</a></li><li id='pTab2'><a href='javascript:Site.selectTab(\"pTab2\");'>{1}</a></li></ul>", battlePlayer.Name, enemy.Name);
			writer.Write("<div id='pTab1Content' {0}>", GetClassPlayerUltimateUnit(true));
			if (!manager.BottomPositioned) {
				WriteBottom(manager.Bottom());
			}
			writer.Write("</div>");
			writer.Write("<div id='pTab2Content' {0}>", GetClassPlayerUltimateUnit(false));
			if (battleInfo.IsDeployTime) {
				WriteTop(manager.Top());
			}
			writer.Write("</div></div>");
		}

		#endregion Units to Position

		/// <summary>
		/// Writes all the board
		/// </summary>
		/// <param name="manager">Initial Container Manager</param>
		private void WriteAllBoard( InitialContainerManager manager ) {
			writer.Write("<div id='battleField' class='{0}'>", battleInfo.Terrain);
			if (manager.BottomPositioned) {
				WriteBoard();
			}else {
				WriteSimpleBoard();
			}
			WriteUnitsToPosition(manager);
			writer.Write("</div>");
		}

		/// <summary>
		/// Writes the game Board
		/// </summary>
		private void WriteSimpleBoard( ) {
			writer.Write("<table id='board2'><tbody>");
			for( int i = 1; i < 9; ++i ) {
				writer.Write("<tr>");
				for( int j = 1; j < 9; ++j ) {
					string id = string.Format("{0}_{1}", i, j);
					writer.Write("<td id='{0}'><span/></td>", id);
				}
				writer.Write("</tr>");
			}
			writer.Write("</tbody></table>");
		}

		private void WriteLayout(InitialContainerManager manager) {
			writer.Write("<div id='battleArea'>");
			WritePlayers();
			LeftBattleMenu2.Render(writer, manager);
			WriteAllBoard(manager);
			WriteRightMenu();
			writer.Write("</div>");
		}

		#endregion
		
		#region BattleRendererbase Implementation

		/// <summary>
		/// Writes a coordinate
		/// </summary>
		/// <param name="coord">Coordinate to write</param>
		/// <param name="e">Object that represents the element in the coordinate</param>
		protected override void WriteCoordinate( string coord, IElement e ) {
            if (e != null && e.Owner == battlePlayer && !isSpectator) {
				WriteElement(coord, e);
			} else {
				WriteEmptySquare(coord);
			}
		}

		/// <summary>
		/// Renders the Board in positioning mod
		/// </summary>
		/// <returns>The HTML code of all the board</returns>
		public override void Render(TextWriter w) {
			if( battleInfo.AllPlayersPositioned ) {
				new BattleRenderer2(battleInfo, battleOwner).Render( w );
				return;
			}
			writer = w;

			InitialContainerManager manager = new InitialContainerManager2(battleInfo.Players, battlePlayer);
			BoardInformation.Render(writer, BattleInfo, manager);
			WriteStaticImages();
			WriteLayout(manager);
			WriteMessages();
			WriteScripts();
			
		}
		

		#endregion BattleRendererbase Implementation

		#region Constructor

		public BattleRenderer2Positioning( IBattleInfo battleInfo, IBattleOwner owner )
			: base(battleInfo, owner) {
            if (ChooseOptionType() == OptionType.Deploy) {
                if (battleInfo.BattleType == OrionsBelt.RulesCore.Enum.BattleType.Regicide){
                    TutorialManager.Current = Tutorial.RegicideDeploy;
                } else {
                    TutorialManager.Current = Tutorial.BattleDeploy;
                }
            } else {
                TutorialManager.Current = Tutorial.InvalidBattle;
            }
        }


		#endregion Constructor

	}
}
