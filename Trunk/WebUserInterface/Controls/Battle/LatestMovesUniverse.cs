using OrionsBelt.Core;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls {
	public class LatestMovesUniverse : LatestMoves {

        #region Base Implementation

        protected override string GetKey()
        {
            return string.Format("LatestBattlesUniverse{0}-{1}", SpecificBattle, LanguageManager.CurrentLanguage);
        }

        public override bool IncludeBounties {
            get { return true; }
        }

        protected override IList<Battle> GetLatest()
        {
            return Hql.StatelessQuery<Battle>(0, 3,
                    "select battle from SpecializedBattle battle where battle.HasEnded = 0 and battle.IsDeployTime = 0 and battle.CurrentTurn > 10 and  battle.BattleType not like '%4' order by battle.UpdatedDate desc",
                    null
                );
        
        }

        #endregion Base Implementation

    };
}
