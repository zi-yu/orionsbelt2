using System;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public class OtherPlayersInformations {

		#region Fields

		private readonly int timeouts;
		private readonly int score;
        private readonly bool hasLost;
        private readonly bool hasGaveUp;
        private readonly string name;
		private readonly BattleMode battleMode;
		private readonly int id;
        private readonly int victoryPercentage;
        private readonly int teamNumber;

	    #endregion Fields

		#region Properties


		public bool HasLost {
			get { return hasLost; }
		}

		public bool HasGaveUp {
			get { return hasGaveUp; }
		}

		public int Timeouts {
			get { return timeouts; }
		}

		public int Score {
			get { return score; }
		}

	    public string Name {
			get {
				return WebUtilities.GetBattlePlayerUrl(battleMode, name, id);
	        }
	    }

        public int VictoryPercentage{
            get { return victoryPercentage; }
        }

        public int TeamNumber{
            get { return teamNumber; }
        }

	    #endregion Properties

		#region Constructor

        public OtherPlayersInformations( PlayerBattleInformation info, int s, string battleMode ) {
            timeouts = info.Timeouts;
            hasLost = info.HasLost;
            hasGaveUp = info.HasGaveUp;
            name = info.Name;
        	score = s;
        	id = info.Owner;
			this.battleMode = (BattleMode)Enum.Parse(typeof(BattleMode), battleMode);
            teamNumber = info.TeamNumber;
            victoryPercentage = info.VictoryPercentage;
		}
       
		#endregion Constructor
	}
}
