using System.Collections.Generic;
using System.IO;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.WebBattle;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.WebBattle {
    public class GenericRender {

        #region Fields

        private readonly TextWriter writer;
        private readonly Mode mode;

        #endregion Fields

        #region Public

		public virtual void Render( bool allBattles ) {
            StringWriter content = new StringWriter();

            if (mode.Has2PlayerBattles) {
                new GenericBattle2Render(mode, content, allBattles).Render();
            }
            if (mode.Has4PlayerBattles) {
                new GenericBattle4Render(mode, content, allBattles).Render();
            }

            string title = string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get(mode.BattleMode.ToString()));

            Border.RenderBig(writer, title, content.ToString());
        }

        #endregion Public

        #region Constructor

        public GenericRender(TextWriter writer, Mode mode) {
            this.writer = writer;
            this.mode = mode;
        }

        #endregion Constructor

    }

}
