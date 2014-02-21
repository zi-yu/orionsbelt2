using System;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore.Translate {
	internal class RotationTranslater : ITranslate {

		#region Fields

		private readonly IBattlePlayer player;
		private readonly char[] separator = new char[] { '-' };

		#endregion Fields

		#region Private

		private string TranslatePosition( string position ) {
			PositionType positionType = (PositionType) Enum.Parse(typeof(PositionType), position.ToUpper());
			positionType = player.PositionConverter.ConvertPositionToSpecific(positionType);
			return positionType.ToString();
		}

		private string TranslatePositionToBase( string position ) {
			PositionType positionType = (PositionType) Enum.Parse(typeof(PositionType), position.ToUpper());
			positionType = player.PositionConverter.ConvertPositionToBase(positionType);
			return positionType.ToString();
		}

		#endregion

		#region ITranslate Members

		public string TranslateToSpecific( string move ) {
			string[] m = move.Split(separator, StringSplitOptions.RemoveEmptyEntries);

			IBattleCoordinate src = player.PositionConverter.ConvertCoordinateToSpecific(new BattleCoordinate(m[0]));

			string oldPosition = TranslatePosition(m[1]);
			string newPosition = TranslatePosition(m[2]);

			return string.Format("{0}-{1}-{2}", src, oldPosition, newPosition);
		}

		public string TranslateToBase( string move ) {
			string[] m = move.Split(separator, StringSplitOptions.RemoveEmptyEntries);

			IBattleCoordinate src = player.PositionConverter.ConvertCoordinateToBase(new BattleCoordinate(m[0]));

			string oldPosition = TranslatePositionToBase(m[1]);
			string newPosition = TranslatePositionToBase(m[2]);

			return string.Format("{0}-{1}-{2}", src, oldPosition, newPosition);
		}

		#endregion ITranslate Members

		#region Constructor

		internal RotationTranslater( IBattlePlayer player ) {
			this.player = player;
		}

		#endregion Constructor

	}
}
