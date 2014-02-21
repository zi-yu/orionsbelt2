using OrionsBelt.WebUserInterface.WebBattle;
using System.Web.UI;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using System.Collections;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Engine;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using OrionsBelt.WebUserInterface.Engine;
using System.IO;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.WebUserInterface.Controls {

	public class AllianceBattles : BattleHistory  {

        #region BattleHistory Implementation

        protected override bool BattlesEnded {
            get { return false; }
        }

        protected override string GetNoBattlesText()
        {
            return LanguageManager.Instance.Get("AllianceNoBattles");
        }

        protected override long GetCount()
        {
            object result = Hql.ExecuteScalar(GetHql(AllianceWebUtils.Current.Storage.Players).Replace("select b", "select count(b)"));

            if (result == null) {
                return 0;
            }

            return (long)result;
        }

        protected override IList<SimpleBattleInfo> LoadHistoryBattles()
        {
            IAlliance curr = AllianceWebUtils.Current;
            IList<PlayerStorage> players = curr.Storage.Players;
            string hql = GetHql(players);
            IList<Battle> battles = Hql.Query<Battle>(hql);
            if (battles.Count > 0) {
                return LoadAllBattles(SimpleBattleInfos.GetHql(SimpleBattleInfos.GetWhere(battles)));
            }
            return null;
        }

        private string GetHql(IList<PlayerStorage> players)
        {
            TextWriter writer = new StringWriter();

            writer.Write("select b from SpecializedBattle b inner join b.PlayerInformationNHibernate pi ");
            writer.Write("where b.HasEnded = false and ( 1=0 ");
            foreach (PlayerStorage storage in players) {
                writer.Write(" or ( b.BattleMode = 'Battle' and pi.Owner = {0} )", storage.Id);
            }
            writer.Write(")");

            return writer.ToString();
        }

        protected override SimpleBattleInfo GetSimpleBattleInfo(Battle battle)
        {
            return new SimpleBattleInfo(battle, AllianceWebUtils.Current.Storage.Players);
        }

        #endregion BattleHistory Implementation

    };
}
