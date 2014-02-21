using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringDarkMatterToPirateBayLevel10 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 33; }
        }

		public override int TargetTransactions {
			get {return 2;}
		}

        protected override int TargetQuestLevel {
            get { return 10; }
        }

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(DarkMatter.Resource, 2);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("DarkMatter", 2);
            data.QuestIntProgress.Add("DarkMatter", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Prismal.Resource, 8000);
                dic.Add(Argon.Resource, 8000);
                dic.Add(Astatine.Resource, 8000);
                dic.Add(Radon.Resource, 8000);
                dic.Add(Cryptium.Resource, 8000);
                return dic;
            }
        }

		#endregion Private
	};

}

