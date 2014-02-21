using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.Generic;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Represents quest data
    /// </summary>
    public class QuestData : IQuestData {

        #region IBackToStorage<QuestStorage> Members

        private QuestStorage storage = null;
        public QuestStorage Storage {
            get { return storage; }
            set { storage = value; }
        }

        public void UpdateStorage()
        {
            QuestConversion.SetStorage(Storage, this);
        }

        public void PrepareStorage()
        {
            if (Storage == null) {
                Storage = QuestConversion.ConvertQuestToStorage(this);
            }
        }

        public void Touch()
        {
            IsDirty = true;
        }

        private bool isDirty = false;
        public bool IsDirty {
            get { return isDirty; }
            set { isDirty = value;  }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks if the quest can be completed at this time
        /// </summary>
        /// <returns></returns>
        public Result CanComplete()
        {
            return Info.CanComplete(this);
        }    

        /// <summary>
        /// Completes the quest
        /// </summary>
        public virtual void Complete()
        {
            Info.Complete(this);
        }

        #endregion Methods

        #region IQuestData Members

        private IPlayer player;
        public IPlayer Player {
            get { return player; }
            set { player = value; Touch(); }
        }

        private bool isProgressive;
        public bool IsProgressive {
            get { return isProgressive; }
            set { isProgressive = value; Touch(); }
        }
	
        private bool completed;
        public bool Completed {
            get { return completed; }
            set { completed = value; Touch(); }
        }

        private double percentage;
        public double Percentage {
            get { return percentage; }
            set { percentage = value; Touch(); }
        }

        private bool isTemplate;
        public bool IsTemplate {
            get { return isTemplate; }
            set { isTemplate = value; Touch(); }
        }

        private string name;
        public string Name {
            get { return name; }
            set { name = value; Touch(); }
        }

        private IQuestInfo info;
        public IQuestInfo Info {
            get { return info; }
            set { info = value; Touch(); }
        }

        private int deadline;
        public int DeadlineTick {
            get { return deadline; }
            set { deadline = value; Touch(); }
        }

        private int start;
        public int StartTick {
            get { return start; }
            set { start = value; Touch(); }
        }

        private Dictionary<IResourceInfo, int> reward= new Dictionary<IResourceInfo,int>();
        public Dictionary<IResourceInfo, int> Reward {
            get { return reward; }
            set { reward = value; Touch(); }
        }

        private Dictionary<string, string> questStringConfig = new Dictionary<string,string>();
        public Dictionary<string, string> QuestStringConfig {
            get { return questStringConfig; }
            set { questStringConfig = value; Touch(); }
        }

        private Dictionary<string, int> questIntConfig = new Dictionary<string,int>();
        public Dictionary<string, int> QuestIntConfig {
            get { return questIntConfig; }
            set { questIntConfig = value; Touch(); }
        }

        private Dictionary<string, int> questIntProgress = new Dictionary<string,int>();
        public Dictionary<string, int> QuestIntProgress {
            get { return questIntProgress; }
            set { questIntProgress = value; Touch(); }
        }

        private Dictionary<string, string> questStringProgress = new Dictionary<string,string>();
        public Dictionary<string, string> QuestStringProgress {
            get { return questStringProgress; }
            set { questStringProgress = value; Touch(); }
        }

        #endregion

    };

}
