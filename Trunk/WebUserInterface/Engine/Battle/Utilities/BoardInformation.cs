using System.Collections.Generic;
using System.IO;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebUserInterface.WebBattle;

namespace OrionsBelt.WebUserInterface.Engine {
	public class BoardInformation {

		#region Fields

		private Dictionary<string, string> jsonElements = new Dictionary<string, string>();
		
		#endregion Fields

		#region Private

		private static List<string> GetEnemyUnitNames(InitialContainerManager manager) {
			List<string> enemy = new List<string>();
			AddRange(enemy, manager.Top());
			AddRange(enemy, manager.Left());
			AddRange(enemy, manager.Right());
			return enemy;
		}

		private static void AddRange(List<string> enemy, List<IElement> list) {
			if (list != null) {
				foreach (IElement element in list) {
					string name = element.Unit.Name.ToLower();
					if (!enemy.Contains(name)) {
						enemy.Add(name);
					}
				}
			}
		}

		private static void WriteEnemyUnitsToJson(TextWriter writer, InitialContainerManager manager) {
			List<string> enemy = GetEnemyUnitNames(manager);
			writer.Write("enemyUnits : [");
			writer.Write("'{0}'", enemy[0]);

			for (int i = 1; i < enemy.Count; ++i) {
				writer.Write(",'{0}'", enemy[i]);
			}
			writer.Write("]");
		}

		private static void WriteTerrain(TextWriter writer, IBattleInfo battleInfo) {
			writer.Write("terrain : '{0}'", battleInfo.Terrain);
		}
		
		#endregion

		#region Public

		public static void Render(TextWriter writer, IBattleInfo battleInfo, InitialContainerManager manager) {
			writer.Write("<script type='text/javascript'>var boardInformation = {");

			WriteEnemyUnitsToJson(writer, manager);
			writer.Write(",");
			WriteTerrain(writer, battleInfo);

			writer.Write("}</script>");
		}

		#endregion Public

	}
}
