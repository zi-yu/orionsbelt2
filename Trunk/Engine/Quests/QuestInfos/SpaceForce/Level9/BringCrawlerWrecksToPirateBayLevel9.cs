using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringCrawlerWrecksToPirateBayLevel9 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 26; }
        }

		public override int TargetTransactions {
			get {return 7;}
		}

        protected override int TargetQuestLevel {
            get { return 9; }
        }

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(CrawlerGyroBalancer.Resource, 5);
                yield return new ResourceQuantity(CrawlerStaticPulse.Resource, 2);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("CrawlerGyroBalancer", 5);
            data.QuestIntConfig.Add("CrawlerStaticPulse", 2);

            data.QuestIntProgress.Add("CrawlerGyroBalancer", 0);
            data.QuestIntProgress.Add("CrawlerStaticPulse", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Cryptium.Resource, 7000);
                dic.Add(Prismal.Resource, 7000);
                dic.Add(Argon.Resource, 7000);
                return dic;
            }
        }

		#endregion Private
	};

}

