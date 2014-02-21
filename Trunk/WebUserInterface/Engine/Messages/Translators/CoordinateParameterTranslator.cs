using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.WebUserInterface.Engine {
	public class CoordinateParameterTranslator : IMessageParameterTranslator {

		#region Fields

		private readonly IBattlePlayer battlePlayer;

		#endregion

		#region IMessageParameterTranslator Members

		public string Translate(string arg) {
			return battlePlayer.PositionConverter.ConvertCoordinateToSpecific(arg);
		}

        public string CurrentLanguage {
            get { return null; }
        }

		#endregion IMessageParameterTranslator Members

		#region Constructor

		public CoordinateParameterTranslator(IBattlePlayer battlePlayer) {
			this.battlePlayer = battlePlayer;
		}

		#endregion
	}
}
