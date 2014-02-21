using System;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore.Translate {
	internal class MoveTranslater : ITranslate {

		#region Fields

		private readonly IBattlePlayer player;
		private readonly char[] separator = new char[]{'-'};

		#endregion Fields

		#region ITranslate Members

		public string TranslateToSpecific( string move ) {
			string[] m = move.Split(separator, StringSplitOptions.RemoveEmptyEntries);

			IBattleCoordinate src = player.PositionConverter.ConvertCoordinateToSpecific( new BattleCoordinate(m[0]) );
			IBattleCoordinate dst = player.PositionConverter.ConvertCoordinateToSpecific( new BattleCoordinate(m[1]) );

			return string.Format("{0}-{1}-{2}", src, dst, m[2]);
		}

		public string TranslateToBase( string move ) {
			string[] m = move.Split(separator, StringSplitOptions.RemoveEmptyEntries);

			IBattleCoordinate src = player.PositionConverter.ConvertCoordinateToBase(new BattleCoordinate(m[0]));
			IBattleCoordinate dst = player.PositionConverter.ConvertCoordinateToBase(new BattleCoordinate(m[1]));

			return string.Format("{0}-{1}-{2}", src, dst, m[2]);
		}

		#endregion ITranslate Members

		#region Constructor

		internal MoveTranslater(IBattlePlayer player) {
			this.player = player;
		}

		#endregion Constructor

	}
}
