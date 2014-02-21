using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Enum;


namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Base trade routes quest
    /// </summary>
    public class MercQuest : MobQuest {

        #region BaseQuestInfo Implementation
		
		#region Public

		public override QuestContext Context {
			get { return QuestContext.Mercs; }
		}

		#endregion Public

        #endregion BaseQuestInfo Implementation

        #region Static Utils

        public static IQuestData Create(string name, int quantity)
        {
			return QuestManager.CreateEmpty(typeof(MercQuest), name);
        }

        #endregion Static Utils

	};

}
