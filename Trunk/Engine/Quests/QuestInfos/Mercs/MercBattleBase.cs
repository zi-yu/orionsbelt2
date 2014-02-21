using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Base trade routes quest
    /// </summary>
    [NoAutoRegister]
    public abstract class MercBattleBase : MobBattleBase {

		#region BaseQuestInfo Implementation

		public override QuestContext Context {
			get { return QuestContext.Mercs; }
		}

		#endregion BaseQuestInfo Implementation
	};

}
