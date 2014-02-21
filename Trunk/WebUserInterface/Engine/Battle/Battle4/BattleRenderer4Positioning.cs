using System.Collections.Generic;
using System.IO;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebUserInterface.WebBattle;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public class BattleRenderer4Positioning: BattleRendererBase4 {

		#region Private

		#region Ultimate Units

		private string GetClassPlayerUltimateUnit( bool isVisible) {
			string uuClass = string.Empty;
			if (battlePlayer.UltimateUnit != null) {
				uuClass = battlePlayer.UltimateUnit.Name;
			}
			if (isVisible) {
				return string.Format("class='visible {0}'", uuClass);
			}
			return string.Format("class='{0}'", uuClass);
			
		}

		#endregion Ultimate Units

		#region Write Initial Containers

		/// <summary>
		/// Writes the bottom initial container
		/// </summary>
		/// <param name="list">List of units to write</param>
		/// <param name="first">if the fleet to render is the fleet of the current player</param>
		private void WriteBottom(List<IElement> list, bool first) {
			if (first) {
				writer.Write("<table id='initialBottom4'><tbody><tr>");
			}else {
				writer.Write("<table><tbody><tr>");
			}
			foreach (IElement element in list) {
				writer.Write(
					"<td id='{0}'><img src='{1}' title='{2}' alt='{3}' /></td>",
					element.Unit.Name,
					ResourcesManager.GetUnitImage(element.Unit.Name),
					element.Quantity,
					element.Unit.Name.ToLower()
				);
			}

			writer.Write("<td class='initialBottomIgnore'><img src='{0}' alt='' title=''/></td>", ResourcesManager.GetImage("fill.gif"));
			writer.Write("</tr></tbody></table>");
		}

		private void WriteUnitsToPosition() {
			writer.Write("<div id='initialContainers'>");
			writer.Write("<ul id='initialContainersul4'><li id='pTab0' class='selected'><a href='javascript:Site.selectTab(\"pTab0\");'>{0}</a></li>", manager.GetPlayer(0).Name);
			for (int i = 1; i < 4; ++i) {
			    IBattlePlayer b = manager.GetPlayer(i);
                if (null != b)
                {
                    writer.Write("<li id='pTab{0}' ><a href='javascript:Site.selectTab(\"pTab{0}\");'>{1}</a></li>", i,
                                 b.Name);
                }
			}
			writer.Write("</ul>");

			for (int i = 0; i < battleInfo.Players.Count; ++i) {
				bool first = i == 0;
				writer.Write("<div id='pTab{0}Content' {1}>", i, GetClassPlayerUltimateUnit(first));
				if (battleInfo.IsDeployTime) {
					WriteBottom(manager.GetPlayerElements(i), first);
				}
				writer.Write("</div>");
			}
			
			writer.Write("</div>");
		}

		#endregion Write Initial Containers

		private void WritePositioningBoard() {
			writer.Write("<div id='battleArea4'>");
			WriteAllBoard();
			WriteRightMenu();
			writer.Write("</div>");
		}

		/// <summary>
		/// Writes all the board
		/// </summary>
		private void WriteAllBoard() {
			writer.Write("<div id='battleField4' class='{0}4'>", battleInfo.Terrain);
			if (battlePlayer.HasPositioned) {
				WriteBoard();
			}else {
				WriteSimpleBoard();
			}
			WriteUnitsToPosition();
			writer.Write("</div>");
		}

		/// <summary>
		/// Writes the game Board
		/// </summary>
		private void WriteSimpleBoard( ) {
			writer.Write("<table id='board4'><tbody>");
			for( int i = 1; i < 13; ++i ) {
				writer.Write("<tr>");
				for( int j = 1; j < 13; ++j ) {
					string coord = string.Format("{0}_{1}", i, j);
					if( IsToIgnore(coord) ) {
						writer.Write("<td id='{0}' class='noBorder'><span/></td>", coord);
					}else {
						writer.Write("<td id='{0}'><span/></td>", coord);
					}
				}
				writer.Write("</tr>");
			}
			writer.Write("</tbody></table>");
		}

		#endregion
		
		#region BattleRendererbase Implementation

		/// <summary>
		/// Writes a coordinate
		/// </summary>
		/// <param name="coord">Coordinate to write</param>
		/// <param name="e">Object that represents the element in the coordinate</param>
		protected override void WriteCoordinate(  string coord, IElement e ) {
			if( e != null && e.Owner == battlePlayer ) {
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
				new BattleRenderer4(battleInfo, battleOwner).Render( w );
				return;
			}
			writer = w;

			BoardInformation.Render(writer, BattleInfo, manager);
			WriteStaticImages();
			WritePositioningBoard();
			WriteMessages();
			WriteScripts();
		}

		#endregion BattleRendererbase Implementation

		#region Constructor

		public BattleRenderer4Positioning( IBattleInfo battleInfo, IBattleOwner owner )
			: base(battleInfo, owner) {
		}


		#endregion Constructor

	}
}
