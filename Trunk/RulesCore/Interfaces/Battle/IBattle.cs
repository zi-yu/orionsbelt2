using OrionsBelt.Core;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface  IBattle {
		Battle Storage{ get;}
		IBattleOwner GetBattleOwner(PlayerBattleInformation p);
	}
}
