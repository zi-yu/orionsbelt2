using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.WebUserInterface.Engine {
	public class PositionParameterTranslator : IMessageParameterTranslator {

		#region Fields

		private readonly IBattlePlayer battlePlayer;

		#endregion

		#region IMessageParameterTranslator Members

		public string Translate(string arg) {
			return battlePlayer.PositionConverter.ConvertPositionToSpecific(arg);
		}

        public string CurrentLanguage {
            get { return null; }
        }

		#endregion IMessageParameterTranslator Members

		#region Constructor

		public PositionParameterTranslator(IBattlePlayer battlePlayer) {
			this.battlePlayer = battlePlayer;
		}

		#endregion
	}
}
