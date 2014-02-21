
using System.Collections.Generic;
using DesignPatterns;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.WebUserInterface.WebBattle {
	public static class Units {

		#region Fields

		private static readonly FactoryContainer UnitFactory = new FactoryContainer(typeof(BaseUnit), typeof(BaseUnit).Assembly);
		private static readonly List<BaseUnit> light = new List<BaseUnit>();
		private static readonly List<BaseUnit> medium = new List<BaseUnit>();
		private static readonly List<BaseUnit> heavy = new List<BaseUnit>();
		private static readonly List<BaseUnit> ultimate = new List<BaseUnit>();
		private static readonly List<BaseUnit> allUnits = new List<BaseUnit>();

		#endregion Fields

		#region Properties

		public static List<BaseUnit> Light {
			get { return light; }
		}

		public static List<BaseUnit> Medium {
			get { return medium; }
		}

		public static List<BaseUnit> Heavy {
			get { return heavy; }
		}

		public static List<BaseUnit> Ultimate {
			get { return ultimate; }
		}

		public static List<BaseUnit> AllUnits {
			get { return allUnits; }
		}

		#endregion

		#region Private

		private static IEnumerable<BaseUnit> GetUnits() {
			foreach (string s in UnitFactory.Keys ) {
				BaseUnit unit = (BaseUnit) UnitFactory.create(s);
				yield return unit;
			}
		}

		private static void GatherUnits() {
			foreach (BaseUnit unit in GetUnits()) {
				switch(unit.UnitCategory) {
					case UnitCategory.Light:
						light.Add(unit);
						break;
					case UnitCategory.Medium:
						medium.Add(unit);
						break;
					case UnitCategory.Heavy:
						heavy.Add(unit);
						break;
					case UnitCategory.Ultimate:
						Ultimate.Add(unit);
						break;
					default:
						break;	
				}
				allUnits.Add(unit);
			}
		}

		#endregion Private

		#region Constructor

		static Units() {
			GatherUnits();
		}

		#endregion

		
	}
}
