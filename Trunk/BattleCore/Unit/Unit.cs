using DesignPatterns;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections;

namespace OrionsBelt.BattleCore {
	public static class Unit  {

		#region Fields

		private static readonly FactoryContainer UnitFactory = new FactoryContainer(typeof(BaseUnit), typeof(Unit).Assembly);

		#endregion Fields

		#region Properties

		public static ICollection Units {
			get {
				return UnitFactory.Values;
			}
		}
		
		#endregion Properties

		#region Public

		public static IUnitInfo Create(string key) {
			return (IUnitInfo) UnitFactory.create(key);
		}
		
		#endregion

        #region Ctor

        static Unit()
        {
            foreach (IUnitInfo unit in Units) {
                BaseResource baseResource = (BaseResource)unit;
                baseResource.Init();
            }
        }

        #endregion Ctor

    };
}
