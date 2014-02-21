using System;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore.Translate {
	internal class FinalStateTranslater {
		#region Fields

		private readonly IBattlePlayer player;
		private readonly char[] separator = new char[]{'-'};

		#endregion Fields

		#region ITranslate Members

		public string Translate( string move ) {
			string[] m = move.Split(separator, StringSplitOptions.RemoveEmptyEntries);

			IBattleCoordinate src = player.PositionConverter.ConvertCoordinateToSpecific(new BattleCoordinate(m[1]));

			PositionType positionType = (PositionType) Enum.Parse(typeof (PositionType), m[3]);
			positionType = player.PositionConverter.ConvertPositionToSpecific(positionType);

			return string.Format("{0}-{1}-{2}-{3}", m[0], src, m[2], positionType);
		}

		#endregion ITranslate Members

		#region Constructor

		internal FinalStateTranslater( IBattlePlayer player ) {
			this.player = player;
		}

		#endregion Constructor
	}
}
