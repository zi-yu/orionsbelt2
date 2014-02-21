using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Battle Timeout
    /// </summary>
    public class BattleTimeout : AutoRepeteAction {

        #region Ctor & Fields

        private int battleId;

        public int BattleId {
            get { return battleId; }
            set { battleId = value; }
        }

        public BattleTimeout()
        {
        }

        public BattleTimeout(int battleId, int delay)
        {
            BattleId = battleId;
            Start(delay);
        }

        #endregion Ctor & Fields

        #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Public; }
        }

        public override string Data {
            get {
                return BattleId.ToString();
            }
            set {
                BattleId = int.Parse(value);
            }
        }

        protected override void ProcessAction(bool forcedEnd)
        {
        	Ended = BattleManager.Timeout(BattleId);
        }

        #endregion Base Implementation

    };

}
