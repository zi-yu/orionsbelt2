using System.Collections;
using System.Collections.Generic;
using DesignPatterns;
using NUnit.Framework;
using OrionsBelt.BattleCore;
using OrionsBelt.RulesCore.Common;

namespace OrionsBeltTests.BattleCoreTests {

	public class BattleGenericTests : BaseTests {

		private static readonly FactoryContainer UnitFactory = new FactoryContainer(typeof(BaseUnit), typeof(Unit).Assembly);

		public void TestUnitCodes() {
			List<string> codes = new List<string>();
			foreach (DictionaryEntry entry in UnitFactory) {
				BaseUnit unit = (BaseUnit) entry.Value;
				Assert.IsFalse(codes.Contains(unit.Code), string.Format("Duplicated Code found: '{0}'",unit.Code));
				codes.Add(unit.Code);
			}
		}
	}
}
