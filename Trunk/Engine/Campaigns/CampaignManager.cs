using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.Engine.Actions;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using OrionsBelt.DataAccessLayer;
using Loki.DataRepresentation;
using OrionsBelt.RulesCore.UniverseInfo;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic.Messages;
using OrionsBelt.Engine.Common;

namespace OrionsBelt.Engine {

    /// <summary>
    /// Handles campaigns
    /// </summary>
    public static class CampaignManager {

        #region Creation

        public static CampaignStatus CreateStatusForLevel(Principal principal, CampaignLevel campaignLevel)
        {
            using (ICampaignStatusPersistance persistance = Persistance.Instance.GetCampaignStatusPersistance()) {
                persistance.StartTransaction();
                CampaignStatus status = CreateStatusForLevel(principal, campaignLevel, persistance);
                persistance.CommitTransaction();
                return status;
            }
        }

        private static CampaignStatus CreateStatusForLevel(Principal principal, CampaignLevel campaignLevel, IPersistanceSession session)
        {
            using (ICampaignStatusPersistance persistance = Persistance.Instance.GetCampaignStatusPersistance(session))
            {
                CampaignStatus status = persistance.Create();
                status.Campaign = campaignLevel.Campaign;
                status.Level = campaignLevel.Level;
                status.LevelTemplate = campaignLevel;
                status.Moves = 0;
                status.Completed = false;
                status.Principal = principal;
                status.Battle = CreateBattle(principal, campaignLevel, persistance);
                campaignLevel.CampaignStatus.Add(status);

                persistance.Update(status);

                return status;
            }

        }

        private static Battle CreateBattle(Principal principal, CampaignLevel campaignLevel, IPersistanceSession session)
        {
			return BattleManager.CreateCampaignBattle(principal, campaignLevel.PlayerFleet, campaignLevel.BotName, campaignLevel.BotFleet, session);
        }

        #endregion Creation

        #region Restart

        public static CampaignStatus RestartLevel(Principal principal, CampaignLevel targetLevel)
        {
            using (ICampaignStatusPersistance persistance = Persistance.Instance.GetCampaignStatusPersistance())
            {
                persistance.StartTransaction();
                persistance.Delete("from SpecializedCampaignStatus status where status.PrincipalNHibernate.Id = {0} and status.Level = {1}", principal.Id, targetLevel.Level );
                CampaignStatus status = CreateStatusForLevel(principal, targetLevel, persistance);
                persistance.CommitTransaction();
                return status;
            }
        }

        #endregion Restart

        #region End Campaign Battle

        public static void ProcessBattle(IBattleInfo battleInfo, bool playerWon) 
        {
            using (ICampaignStatusPersistance persistance = Persistance.Instance.GetCampaignStatusPersistance()) {
                IList<CampaignStatus> list = persistance.SelectByBattle(battleInfo.Battle);
                if (list == null || list.Count == 0) {
                    throw new EngineException("No CampaignStatus found of battle #{0}", battleInfo.Battle.Id);
                }

                CampaignStatus status = list[0];

                if (playerWon) {
                    status.Moves = battleInfo.CurrentTurn;
                    status.Completed = true;
                    persistance.Update(status);
                }  else {
                    persistance.Delete(status);
                }
            }
		}

		#endregion End Campaign Battle

    };
}
