using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public class InitialContainerManager2: InitialContainerManager {

		#region Fields

		private readonly int playerIndex;
		private readonly int enemyIndex;

		#endregion Fields

		#region Properties

		public override bool BottomPositioned {
			get {
				return players[playerIndex].HasPositioned;
			}
		}

		public override bool TopPositioned {
			get {
				return players[enemyIndex].HasPositioned;
			}
		}

		#endregion Properties

		#region InitialContainerManager Implementation

		public override List<IElement> Top() {
			return players[enemyIndex].InitialContainer.InitialUnits;
		}

		public override List<IElement> Bottom() {
			return players[playerIndex].InitialContainer.InitialUnits;
		}

		#endregion InitialContainerManager Implementation

		#region Constructor

		public InitialContainerManager2( List<IBattlePlayer> players, IBattlePlayer player )
			:base(players) {
			if( players[0].PlayerNumber == player.PlayerNumber ) {
				playerIndex = 0;
				enemyIndex = 1;
			}else {
				playerIndex = 1;
				enemyIndex = 0;
			}
		}

		#endregion Constructor
		
	}
}
