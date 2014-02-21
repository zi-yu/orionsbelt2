using System.Collections.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore {
	internal static class BonusUtils {

		#region Fields

		private delegate int BonusGet( Dictionary<string,IBonus> bonus, string key );

		#endregion

		#region Private

		private static int GetAttackValue( Dictionary<string,IBonus> bonus, string key ) {
			if( bonus.ContainsKey(key) ) {
				return bonus[key].GetAttack();
			}
			return 0;
		}

		private static int GetDefenseValue( Dictionary<string, IBonus> bonus, string key ) {
			if( bonus.ContainsKey(key) ) {
				return bonus[key].GetDefense();
			}
			return 0;
		}

		private static int GetRangeValue( Dictionary<string, IBonus> bonus, string key ) {
			if( bonus.ContainsKey(key) ) {
				return bonus[key].GetRange();
			}
			return 0;
		}

		/// <summary>
		/// Get's the value of the bonus
		/// </summary>
		/// <param name="bonusGet">Method to obtain the bonus from</param>
		/// <param name="terrain">Terrain where the unit is in</param>
		/// <param name="source">Unit that is attacking</param>
		/// <param name="target">Target that the unit is attacking</param>
		/// <returns></returns>
		private static int GetBonus( BonusGet bonusGet, Terrain terrain, IUnitInfo source, IUnitInfo target ) {
			int result = 0;

			result += bonusGet(source.Bonus, terrain.ToString());
			result += bonusGet(source.Bonus, target.UnitCategory.ToString());
			result += bonusGet(source.Bonus, target.UnitDisplacement.ToString());
			result += bonusGet(source.Bonus, target.UnitType.ToString());
			result += bonusGet(source.Bonus, target.Name);

			foreach( Race race in source.Races ) {
				result += bonusGet(source.Bonus, race.ToString());
			}

			return result;
		}

		#endregion Private

		#region Public
		
		/// <summary>
		/// Gets the attack with all the bonus
		/// </summary>
		public static int GetAttack( Terrain terrain, IUnitInfo source, IUnitInfo target ) {
			return GetBonus(GetAttackValue, terrain, source, target);
		}

		/// <summary>
		/// Gets the defense with all the bonus
		/// </summary>
		public static int GetDefense(Terrain terrain, IUnitInfo source, IUnitInfo target ) {
			return GetBonus(GetDefenseValue, terrain, source, target);
		}

		/// <summary>
		/// Gets the range with all the bonus
		/// </summary>
		public static int GetRange( Terrain terrain, IUnitInfo source, IUnitInfo target ) {
			return GetBonus(GetRangeValue, terrain, source, target);
		}

		#endregion Public
	}
}
