using System.Collections.Generic;
using DesignPatterns;
using NUnit.Framework;
using OrionsBelt.BattleCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBeltTests.RulesTests {
	[TestFixture]
	public class UnitTests {

		[Test]
		public void TestsUnitCodes() {
			FactoryContainer UnitFactory = new FactoryContainer(typeof(BaseUnit), typeof(BaseUnit).Assembly);
			List<string> codes = new List<string>();
			foreach (IUnitInfo unit in UnitFactory.Values) {
				Assert.IsFalse(codes.Contains(unit.Code));
				codes.Add(unit.Code);
			}

		}

	}
}
