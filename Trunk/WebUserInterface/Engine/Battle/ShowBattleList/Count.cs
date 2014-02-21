using System.Collections.Generic;

namespace OrionsBelt.WebUserInterface.WebBattle {
    public class Count {
        #region Fields	

        private readonly int count;
        private readonly List<SimpleBattleInfo> battles = new List<SimpleBattleInfo>();

        #endregion Fields

        #region Properties

        public int NumberOfPlayers {
            get { return count; }
        }

        public List<SimpleBattleInfo> Battles {
            get { return battles; }
        }

        #endregion Properties

        #region Private	

        #endregion Private

        #region Public	

        public void AddSimpleBattleInfo(SimpleBattleInfo simpleBattleInfo) {
            Battles.Add(simpleBattleInfo);
        }

        #endregion Public

        #region Constructor

        public Count(int count) {
            this.count = count;
        }

        #endregion Constructor
    }
}