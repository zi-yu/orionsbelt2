using OrionsBelt.Core;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine
{
    public class BattleResult: IBattleResult
    {
        public BattleResult(Principal battlePlayer, int score, bool haveLost)
        {
            player = battlePlayer;
            scoreMade = score;
            hasLost = haveLost;
        }

        #region private Fields

        private Principal player;
        private int scoreMade;
        private bool hasLost;

        #endregion private Fields

        #region IBattleResult Members

        public Principal Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
            }
        }

        public int ScoreMade
        {
            get
            {
                return scoreMade;
            }
            set
            {
                scoreMade = value;
            }
        }

        public bool HasLost
        {
            get
            {
                return hasLost;
            }
            set
            {
                hasLost = value;
            }
        }

        #endregion
    }
}
