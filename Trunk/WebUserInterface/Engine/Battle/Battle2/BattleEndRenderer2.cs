using System.IO;
using System.Web.UI;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public class BattleEndRenderer2: BattleRendererBase2 {

		#region Private

		private void WriteEnemyElement( string coord, IElement e ) {
			writer.Write("<td id='{0}' class='enemyBorder'><img src='{1}' alt='{2}' title='{3}' isEnemy='true'/></td>",
				coord,
				ResourcesManager.GetUnitImage(e.Unit.Name.ToLower(), e.Position.ToString().ToLower()[0]),
				e.Unit.Name.ToLower(),
				e.Quantity
			);
		}

		#endregion Private

		#region Public

		public override void RegisterFields( Page page ) {
			page.ClientScript.RegisterHiddenField("playerId", battlePlayer.PlayerNumber.ToString());
			page.ClientScript.RegisterHiddenField("numberOfPlayers", battleInfo.NumberOfPlayers.ToString());
		}

		#endregion Public

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
			InitialContainerManager manager = new InitialContainerManager2(battleInfo.Players, battlePlayer);
			BoardInformation.Render(writer, BattleInfo, manager);
			WriteStaticImages();

			if( Embedded ) {
				RenderReplayControl();
			}
			writer.Write("<div id='battleArea'>");
            if (!Embedded) {
				WritePlayers();
                LeftBattleMenu2.Render(writer, manager);
            }
			writer.Write("<div id='battleField' class='{0}'>", battleInfo.Terrain);
			WriteBoard();
			writer.Write("</div>");
            if (!Embedded) {
                RightBattleMenu2.Render(writer, OptionType.Ended, battleInfo);
            }
			writer.Write("</div>");
            if (!Embedded) {
                WriteMessages();
            }
			WriteScripts();
			
		}

		#endregion BattleRendererBase Implementation

		#region Constructor

		public BattleEndRenderer2( IBattleInfo battleInfo, IBattleOwner battleOwner )
			: base(battleInfo, battleOwner) {
			battleInfo.LoadInitialState();
		}

		#endregion Constructor
	}
}
