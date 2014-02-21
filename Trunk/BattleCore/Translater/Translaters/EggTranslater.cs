using System;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore.Translate {
	internal class EggTranslater : ITranslate {

		#region Fields

		private readonly IBattlePlayer player;
		private readonly char[] separator = new char[] { '-' };

		#endregion Fields

		#region ITranslate Members

		public string TranslateToSpecific(string move) {
			string[] m = move.Split(separator, StringSplitOptions.RemoveEmptyEntries);

			IBattleCoordinate dst = player.PositionConverter.ConvertCoordinateToSpecific(new BattleCoordinate(m[0]));

			return string.Format("{0}", dst);
		}

		public string TranslateToBase(string move) {
			string[] m = move.Split(separator, StringSplitOptions.RemoveEmptyEntries);

			IBattleCoordinate dst = player.PositionConverter.ConvertCoordinateToBase(new BattleCoordinate(m[0]));

			return string.Format("{0}", dst);
		}

		#endregion ITranslate Members

		#region Constructor

		internal EggTranslater(IBattlePlayer player) {
			this.player = player;
		}

		#endregion Constructor

	}
}
