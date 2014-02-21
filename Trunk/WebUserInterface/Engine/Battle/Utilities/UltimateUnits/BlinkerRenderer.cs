using System.IO;
using DesignPatterns.Attributes;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.WebBattle {

	[FactoryKey("bk")]
	internal class BlinkerRenderer : UltimateUnitsRendererBase {

		#region Fields

		private static readonly BlinkerRenderer instance = new BlinkerRenderer();

		#endregion Fields

		#region Public

		public override void Render(TextWriter writer) {
			writer.Write("<div id='ultimateUnit' ><table><tbody><tr><td id='9_9'>");
			writer.Write("<img src='{0}' isEnemy='false' isFriendly='false' isUltimate='true' alt='blinker' title='1'/>", ResourcesManager.GetUnitImage("blinker_n"));
			writer.Write("</td></tr></tbody></table></div>");
		}

		public override void RenderEnemy(TextWriter writer) {
			writer.Write("<div id='enemyUltimateUnit' class='blinker_s'><table><tbody><tr><td id='0_0'>");
			writer.Write("<img src='{0}' isEnemy='true' isUltimate='true' alt='blinker'/>", ResourcesManager.GetUnitImage("ultimateUnit"));
			writer.Write("</td></tr></tbody></table></div>");
		}

		#endregion Public

		#region IFactory Members

		public override object create(object args) {
			return instance;
		}

		#endregion IFactory Members
	}
}
