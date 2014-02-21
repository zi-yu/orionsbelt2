using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public abstract class BattleRendererBase4 : BattleRendererBase {

		#region Fields

		private static readonly List<string> exceptions = new List<string>();
		protected readonly InitialContainerManager manager;

		#endregion

		#region Protected

		protected override void WriteRightMenu() {
			OptionType type = ChooseOptionType();
			RightBattleMenu4.Render(writer, type, battleInfo, manager);
		}

		/// <summary>
		/// Writes the game Board
		/// </summary>
		protected virtual void WriteBoard(  ) {
			writer.Write("<div id='battleField4' class='{0}4'>", battleInfo.Terrain);
			writer.Write("<table id='board4'><tbody>");

			Dictionary<string,IElement> board = battleInfo.GetBoard(battlePlayer);

			for( int i = 1; i < 13; ++i ) {
				writer.Write("<tr>");
				for( int j = 1; j < 13; ++j ) {
					string coord = string.Format("{0}_{1}", i, j);
					IElement e = null;
					if( board.ContainsKey(coord)) {
						e = board[coord];
					}
					if( IsToIgnore(coord)) {
						WriteIgnoreElement(coord);
					}else{
						WriteCoordinate(coord, e);
					}
				}
				writer.Write("</tr>");
			}
			writer.Write("</tbody></table></div>");

		}

		/// <summary>
		/// Verifies if the passed coordinate is to be ignored
		/// </summary>
		/// <param name="coord">Coordinate to validate</param>
		/// <returns><code>True</code> if the coordinate is to be ignored</returns>
		protected static bool IsToIgnore( string coord ) {
			return exceptions.Contains(coord);
		}

		/// <summary>
		/// Writes an element that is going to be ignored
		/// (coordinates of the 4 player battles that aren´t supposed to be valid)
		/// </summary>
		/// <param name="id">Identifier of teh coordinate</param>
		protected void WriteIgnoreElement( string id ) {
			writer.Write("<td id='{0}' class='noBorder'><span/></td>", id);
		}

		#endregion

		#region Constructor

		static BattleRendererBase4() {
			exceptions.Add("1_1");
			exceptions.Add("1_2");
			exceptions.Add("1_11");
			exceptions.Add("1_12" );
			exceptions.Add("2_1");
			exceptions.Add("2_2");
			exceptions.Add("2_11");
			exceptions.Add("2_12");
			exceptions.Add("11_1");
			exceptions.Add("11_2");
			exceptions.Add("11_11");
			exceptions.Add("11_12");
		    exceptions.Add("12_1");
			exceptions.Add("12_2");
			exceptions.Add("12_11");
			exceptions.Add("12_12");
		}

		public BattleRendererBase4( IBattleInfo battleInfo, IBattleOwner owner )
			: base(battleInfo, owner) {
			manager = new InitialContainerManager4(battleInfo.Players, battlePlayer);
		}

		#endregion Constructor
	
	}
}
