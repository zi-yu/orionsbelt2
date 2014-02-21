using System;
using System.Collections.Generic;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;


namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Base trade routes quest
    /// </summary>
	public class MobQuest : BaseQuestInfo, IMobsQuest {

		#region Properties

		public virtual int TargetTransactions {
			get { return 1; }
		}

		public virtual int Ticks {
			get { return -1; }
		}

		public virtual int TargetResourceLevel {
			get { return 1; }
		}

		public virtual int Bonus {
			get { return TargetLevel; }
		}

		protected virtual int TargetQuestLevel {
			get { return 1; }
		}

		#endregion Properties

		#region Private

		protected virtual bool InvalidQuestLevel(SectorCoordinate coordinate) {
			return TargetQuestLevel > 0 && SectorUtils.GetLevel(coordinate.System) != TargetQuestLevel;
		}

		private static bool IsMatch(IEnumerable<IResourceQuantity> filter, IResourceQuantity[] resources) {
			foreach (IResourceQuantity info in filter) {
				foreach (IResourceQuantity res in resources) {
					if (res.Resource.Name.Equals(info.Resource.Name)) {
						return true;
					}
				}
			}
			return false;
		}

		private bool HasCorrectResourceLevel(IResourceQuantity[] resources) {
			if (TargetResourceLevel > 0) {
				return true;
			}
			foreach (IResourceQuantity res in resources) {
				if (res.Resource.StartLevel == TargetResourceLevel) {
					return true;
				}
			}
			return false;
		}

		protected virtual void Increment(IQuestData data, IResourceQuantity[] resources) {
			int totalProgress = 0;
			foreach (IResourceQuantity resource in resources) {
				int progress = data.QuestIntProgress[resource.Resource.Name];
				int currProgress = progress + resource.Quantity;
				data.QuestIntProgress[resource.Resource.Name] = currProgress;
			}

			foreach (IResourceQuantity resource in MustHaveResources) {
				totalProgress += data.QuestIntProgress[resource.Resource.Name];
			}

			data.Percentage = Math.Round((double)totalProgress / TargetTransactions * 100);
		}

		protected override void PrepareData(QuestData data) {
			foreach (ResourceQuantity resource in MustHaveResources) {
				data.QuestIntConfig.Add(resource.Resource.Name, 1);
			}
		}
		
		#endregion Private 

        #region BaseQuestInfo Implementation

		#region Private

		protected override Result DoCanComplete(IQuestData data) {
			foreach (IResourceQuantity resources in MustHaveResources) {
				if( data.QuestIntProgress[resources.Resource.Name] < data.QuestIntConfig[resources.Resource.Name] ) {
					return Result.Fail;
				}
			}
			return Result.Success;
		}

		protected override void DoComplete(IQuestData data) {
			base.DoComplete(data);
			OnAbandon(data);
		}

		#endregion Private

		#region Public

		public override int ScoreReward {
			get { return 500 * Bonus; }
		}

		public override bool IsProgressive {
			get { return true; }
		}

		public override int TargetLevel {
			get { return -1; }
		}

		public override IRaceInfo TargetRace {
			get { return null; }
		}

		public override QuestContext Context {
            get { return QuestContext.Mercs; }
		}

		public override void OnAbandon(IQuestData data) {
		} 

		#endregion Public

        #endregion BaseQuestInfo Implementation

		#region IMobsQuest Members

		public void Process(SectorCoordinate coordinate, IQuestData data, params IResourceQuantity[] resources) {
			if (data.Percentage >= 100) {
				return;
			}

			if (data.DeadlineTick > 0 && Clock.Instance.Tick > data.DeadlineTick) {
				return;
			}

			if (InvalidQuestLevel(coordinate)) {
				return;
			}

			if (MustHaveResources != null && !IsMatch(MustHaveResources, resources)) {
				return;
			}

			if (!HasCorrectResourceLevel(resources)) {
				return;
			}

			Increment(data, resources);
		}

		#endregion

	};

}
