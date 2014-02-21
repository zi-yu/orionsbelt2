using System.IO;
using System.Web.UI;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebUserInterface.WebBattle;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public class BattleEndRenderer4: BattleRendererBase4 {

		#region Private

		private void WriteEnemyElement( string coord, IElement e ) {
			writer.Write("<td id='{0}' class='enemyBorder{4}'><img src='{1}' alt='{2}' title='{3}' isEnemy='true'/></td>",
				coord,
				ResourcesManager.GetUnitImage(e.Unit.Name, e.Position.ToString().ToLower()[0]),
				e.Unit.Name.ToLower(),
				e.Quantity,
				manager.GetPlayerNumber(e.Owner.PlayerNumber)
			);
		}

		private void WriteAllBoard() {
			writer.Write("<div id='battleArea4'>");
			WriteBoard();
			RightBattleMenu4.Render(writer, OptionType.Ended, battleInfo, manager);
			writer.Write("</div>");
		}

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
			WriteReplayScripts();
			base.WriteScripts();
		}

		/// <summary>
		/// Renders the Board in positioning mod
		/// </summary>
		/// <returns>The HTML code of all the board</returns>
		public override void Render(TextWriter w) {
			writer = w;

			BoardInformation.Render(writer, BattleInfo, manager);
			WriteStaticImages();

			if (Embedded) {
				RenderReplayControl();
			}

			WriteAllBoard();
			WriteMessages();
			WriteScripts();
		}

		#endregion BattleRendererBase Implementation

		#region Public

		public override void RegisterFields( Page page ) {
			page.ClientScript.RegisterHiddenField("playerId", battlePlayer.PlayerNumber.ToString());
			page.ClientScript.RegisterHiddenField("numberOfPlayers", battleInfo.NumberOfPlayers.ToString());
		}

		#endregion Public

		#region Constructor

		public BattleEndRenderer4( IBattleInfo battleInfo, IBattleOwner owner )
			: base(battleInfo, owner) {
			battleInfo.LoadInitialState();
		}

		#endregion Constructor
	}
}
