using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.WebUserInterface.WebBattle {

	public class InitialContainerManager4: InitialContainerManager {

		#region Fields

		private static readonly Dictionary<int, int[]> mapping = new Dictionary<int, int[]>();
		private readonly int[] playerMapping;

		#endregion Fields

		#region Properties

		public override bool LeftPositioned {
			get { return HasPositioned(2); }
		}

		public override bool RightPositioned {
			get { return HasPositioned(3); }
		}

		public override bool TopPositioned {
			get { return HasPositioned(0); }
		}

		public override bool BottomPositioned {
			get { return HasPositioned(1); }
		}

		#endregion Properties

		#region Public

		public override bool HasPositioned(int id) {
			if (id <= players.Count - 1) {
				int mappingId = playerMapping[id];
				return players[mappingId].HasPositioned;
			}
			return true;
		}

		public override List<IElement> GetPlayerElements(int id) {
			if (id <= players.Count - 1) {
				int mappingId = playerMapping[id];
                if (players.Count > mappingId)
                {
                    return players[mappingId].InitialContainer.InitialUnits;    
                }
                return new List<IElement>();
			}
			return new List<IElement>();
		}

		public override IBattlePlayer GetPlayer(int id) {
			if (id <= players.Count) {
				int mappingId = playerMapping[id];
                if (players.Count > mappingId)
                {
                    return players[mappingId];
                }
			}
			return null;
		}

		public override int GetPlayerNumber(int id) {
			return playerMapping[id];
		}

		#endregion Public

		#region InitialContainerManager Implementation

		public override List<IElement> Left() {
			return GetPlayerElements(2);
		}

		public override List<IElement> Right() {
			return GetPlayerElements(3);
		}

		public override List<IElement> Top() {
			return GetPlayerElements(1);
		}

		public override List<IElement> Bottom() {
			return GetPlayerElements(0);
		}

		#endregion InitialContainerManager Implementation

		#region Constructor

		static InitialContainerManager4() {
			// Mapping: 
			// Column 1 - playerNumber
			// Column 2 - playerMatch
			mapping.Add(0, new int[] { 0, 1, 2, 3 });
			mapping.Add(1, new int[] { 1, 0, 3, 2 });
			mapping.Add(2, new int[] { 2, 3, 0, 1 });
			mapping.Add(3, new int[] { 3, 2, 1, 0 });
		}

		public InitialContainerManager4( List<IBattlePlayer> players, IBattlePlayer player ): base(players) {
			IBattlePlayer current = player;
			playerMapping = mapping[current.PlayerNumber];
		}

		#endregion Constructor


		
	}
}
