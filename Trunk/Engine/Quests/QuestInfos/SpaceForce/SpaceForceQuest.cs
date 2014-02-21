using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Enum;


namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Base trade routes quest
    /// </summary>
    public class SpaceForceQuest : MobQuest {

        #region BaseQuestInfo Implementation
		
		#region Public

		public override QuestContext Context {
			get { return QuestContext.SpaceForce; }
		}

		#endregion Public

        #endregion BaseQuestInfo Implementation

        #region Static Utils

        public static IQuestData Create(string name, int quantity)
        {
            return QuestManager.CreateEmpty(typeof(SpaceForceQuest), name);
        }

        #endregion Static Utils

	};

}
