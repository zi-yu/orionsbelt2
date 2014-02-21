using System.IO;
using DesignPatterns.Attributes;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.WebBattle {

	[FactoryKey("bm")]
	internal class BattleMoonRenderer : UltimateUnitsRendererBase {

		#region Fields

		private static readonly BattleMoonRenderer instance = new BattleMoonRenderer();

		#endregion Fields

		#region Public

		public override void Render(TextWriter writer) {
			writer.Write("<div id='ultimateUnit' ><table><tbody><tr><td id='9_9'>");
			writer.Write("<img src='{0}' isEnemy='false' isFriendly='false' isUltimate='true' alt='battlemoon' title='1'/>", ResourcesManager.GetUnitImage("battleMoon_n"));
			writer.Write("</td></tr></tbody></table></div>");
		}

		public override void RenderEnemy(TextWriter writer) {
			writer.Write("<div id='enemyUltimateUnit' class='battleMoon_s'><table><tbody><tr><td id='0_0'>");
			writer.Write("<img src='{0}' isEnemy='true' isUltimate='true' alt='battlemoon'/>", ResourcesManager.GetUnitImage("ultimateUnit"));
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
