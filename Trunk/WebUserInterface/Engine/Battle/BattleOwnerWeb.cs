using System.Collections.Generic;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.WebBattle {
	internal class BattleOwnerWeb {

		#region Fields

		private static readonly Dictionary<BattleMode, OwnerGetter> playerDelegates = new Dictionary<BattleMode, OwnerGetter>();
		private delegate IBattleOwner OwnerGetter();

		#endregion Fields

		#region PlayerGetter Delegates

		/// <summary>
		/// Obtains the battle owner by principal
		/// </summary>
		/// <returns>Reference to the battleOwner</returns>
		private static IBattleOwner GetPlayerByPrincipal() {
			if( Utils.PrincipalExists ) {
				return BattleManager.GetBattleOwner(Utils.Principal);	
			}
			return null;
		}

		/// <summary>
		/// Obtains the battle owner by IPlayer
		/// </summary>
		/// <returns>Reference to the battleOwner</returns>
		private static IBattleOwner GetPlayerByIPlayer() {
			if (PlayerUtils.HasPlayer ) {
				return BattleManager.GetBattleOwner(PlayerUtils.Current);
			}
			return null;
		}

		#endregion PlayerGetter Delegates

		#region Public

		public static IBattleOwner Get( IBattleInfo battleInfo ) {
			return playerDelegates[battleInfo.BattleMode]();
		}

		#endregion Public

		#region Constructor

		static BattleOwnerWeb() {
			playerDelegates[BattleMode.Battle] = GetPlayerByIPlayer;
			playerDelegates[BattleMode.Friendly] = GetPlayerByPrincipal;
			playerDelegates[BattleMode.Tournament] = GetPlayerByPrincipal;
			playerDelegates[BattleMode.Arena] = GetPlayerByIPlayer;
			playerDelegates[BattleMode.Campaign] = GetPlayerByPrincipal;
		}

		#endregion Constructor

	}
}
