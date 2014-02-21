using System.Collections.Generic;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.WebUserInterface.WebBattle {
    public class Mode {
        #region Fields

        private readonly BattleMode mode;
        private readonly Dictionary< int, Count > battles = new Dictionary<int, Count>();

        #endregion Fields

        #region Properties

        public BattleMode BattleMode {
            get { return mode; }
        }

        public bool Has2PlayerBattles {
            get { return battles.ContainsKey(2); }
        }

        public bool Has4PlayerBattles {
            get { return battles.ContainsKey(4); }
        }

        #endregion Properties

        #region Private	

        #endregion Private

        #region Public

        public void AddSimpleBattleInfo(SimpleBattleInfo simpleBattleInfo) {
            int nop = simpleBattleInfo.NumberOfPlayers;
            if( !battles.ContainsKey(nop) ) {
                battles.Add(nop, new Count(nop));
            }

            battles[nop].AddSimpleBattleInfo(simpleBattleInfo);
        }

        public Count GetBattles(int count) {
            return battles[count];
        }

        #endregion Public

        #region Constructor

        public Mode( BattleMode mode ) {
            this.mode = mode;
        }

        #endregion Constructor

    }
}