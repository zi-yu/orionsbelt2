using OrionsBelt.WebUserInterface.WebBattle;

namespace OrionsBelt.WebUserInterface.Controls {
	public class AllBattles : CurrentBattles {

        protected override SimpleBattleInfos LoadBattleInfos()
        {
            return BattleUtilities.GetAllBattles();
        }

		public AllBattles() {
			allBattles = true;
		}

	}
}
