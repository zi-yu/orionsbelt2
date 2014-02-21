using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Base trade routes quest
    /// </summary>
    [NoAutoRegister]
    public abstract class SpaceForceBattleBase : MobBattleBase {

		#region BaseQuestInfo Implementation

		public override QuestContext Context {
			get { return QuestContext.SpaceForce; }
		}

		#endregion BaseQuestInfo Implementation
	};

}
