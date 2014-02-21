
using System;
using DesignPatterns;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	internal static class ElementParser {

		#region Fields

		private static readonly FactoryContainer container = new FactoryContainer(typeof(Effect));
		private static readonly char[] effectSeparator = new char[] { '$' };
		private static readonly char[] separator = new char[] { '#' };

		#endregion Fields

		#region Private

		private static void ParseEffects( IElement element, string s ) {
			string[] effects = s.Split(effectSeparator, StringSplitOptions.RemoveEmptyEntries);
			foreach (string effect in effects) {
				string[] effectProps = effect.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				object[] args = new object[] {element, effectProps};
				IEffect effectObj = (IEffect) container.create(effectProps[0], args);
				element.AddEffect(effectObj);
			}
		}

		#endregion Private

		#region Public

		internal static IElement ParseElement( string data ) {
			string[] splittedData = data.Split('-');

			IUnitInfo unit = Unit.Create(splittedData[0]);

			IElement element = new Element(unit, int.Parse(splittedData[2]), new BattleCoordinate(splittedData[1]));
			element.Position = (PositionType) Enum.Parse(typeof(PositionType), splittedData[3], true);

			if( splittedData.Length > 4 ) {
				string s4 = splittedData[4];
				int rd;
				if( int.TryParse(s4, out rd) ) {
					if( !splittedData[4].Equals("e") ) {
						element.RemainingDefense = rd;
					}
					if( splittedData.Length > 5 ) {
						ParseEffects(element, splittedData[5]);
					}
				}else {
					ParseEffects(element, splittedData[4]);
				}
			}

			return element;
		}

		internal static IElement ParseInitialElement( string data ) {
			string[] splittedData = data.Split('-');

			IUnitInfo unit = Unit.Create(splittedData[0]);

			return new Element(unit, int.Parse(splittedData[1]));
		}

		#endregion Public


	
	}
}
