using System.IO;

namespace OrionsBelt.WebUserInterface.WebBattle {
    public class GenericBattle2Render : GenericBattleRenderBase {

        #region Constructor

        public GenericBattle2Render( Mode mode, TextWriter writer )
			: base(mode,writer) {
            battles = mode.GetBattles(2);
        }

		public GenericBattle2Render( Mode mode, TextWriter writer, bool allBattles )
			: base(mode, writer,allBattles) {
            battles = mode.GetBattles(2);
        }
        #endregion Constructor
    }
}